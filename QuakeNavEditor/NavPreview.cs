using QuakeNavEditor.Extensions;
using QuakeNavSharp.Navigation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuakeNavEditor
{
    public class NavPreview : IDisposable
    {
        private const float NodeSize = 4f;

        private float _zoom = 1f;
        public float Zoom { get => _zoom; set { _zoom = value; Render(); } }

        private PointF _camera;
        public PointF Camera { get => _camera; set { _camera = value; Render(); } }

        private NavigationGraph _nav;
        public NavigationGraph Nav { get => _nav; set { _nav = value; Render(); } }


        private bool _showNodeIds;
        public bool ShowNodeIds { get => _showNodeIds; set { _showNodeIds = value; Render(); } }
        private bool _showNodes;
        public bool ShowNodes { get => _showNodes; set { _showNodes = value; Render(); } }
        private bool _showLinks;
        public bool ShowLinks { get => _showLinks; set { _showLinks = value; Render(); } }
        private bool _showEdicts;
        public bool ShowEdicts { get => _showEdicts; set { _showEdicts = value; Render(); } }

        private PictureBox _pictureBox;
        private bool disposedValue;

        private bool isMoving;
        private PointF moveStartPosition;
        private Point moveStartMousePosition;
        private Point moveCursorPosition;

        private IEnumerable<int> _selectedNodes = new int[0];
        public IEnumerable<int> SelectedNodes { get => _selectedNodes; set { _selectedNodes = value; Render(); } }

        public PictureBox PictureBox
        {
            get
            {
                return _pictureBox;
            }

            set
            {
                if (_pictureBox != null)
                    UnhookEvents(_pictureBox);

                _pictureBox = value;
                HookEvents(_pictureBox);

                Render();
            }
        }


        private void HookEvents(PictureBox pictureBox)
        {
            pictureBox.MouseWheel += OnMouseWheel;
            pictureBox.Paint += OnPaint;
            pictureBox.MouseDown += OnMouseDown;
            pictureBox.MouseUp += OnMouseUp;
            pictureBox.MouseMove += OnMouseMove;
        }


        private void UnhookEvents(PictureBox pictureBox)
        {
            pictureBox.MouseWheel -= OnMouseWheel;
            pictureBox.Paint -= OnPaint;
            pictureBox.MouseDown -= OnMouseDown;
            pictureBox.MouseMove -= OnMouseMove;
            pictureBox.MouseUp -= OnMouseUp;
        }


        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                var screenLocation = PictureBox.PointToScreen(e.Location);
                var delta = new Point(screenLocation.X - moveCursorPosition.X, screenLocation.Y - moveCursorPosition.Y);
                Cursor.Position = moveCursorPosition;

                _camera.X += delta.X;
                _camera.Y += delta.Y;

                Render();
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (!isMoving || e.Button != MouseButtons.Left)
                return;

            isMoving = false;

            // Restore cursor position & show it again
            Cursor.Position = moveCursorPosition;
            Cursor.Show();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            // Hide cursor, put in the middle and save coordinates
            Cursor.Hide();
            moveCursorPosition = Cursor.Position;

            moveStartPosition = _camera;
            moveStartMousePosition = Cursor.Position;
            isMoving = true;
        }


        public void Render()
        {
            _pictureBox.Invalidate();
        }


        private PointF QuakeToPreviewCoords(Vector3 quakePosition)
        {
            return new PointF()
            {
                X = -quakePosition.X,
                Y = quakePosition.Y
            };
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gfx = e.Graphics;


            gfx.Clear(Color.Black);

            gfx.TranslateTransform(_camera.X, _camera.Y);
            gfx.ScaleTransform(_zoom, _zoom);


            // Draw edicts
            if (_showEdicts)
            {
                foreach (var edict in _nav.Nodes.SelectMany(node => node.Links).Where(link => link.Edict != null).Select(link => link.Edict))
                {
                    var rectangle = new Rectangle();

                    var mins = QuakeToPreviewCoords(edict.Mins);
                    var maxs = QuakeToPreviewCoords(edict.Maxs);

                    // Flip the mins / maxs
                    var temp = mins.X;
                    mins.X = maxs.X;
                    maxs.X = temp;

                    rectangle.X = (int)mins.X;
                    rectangle.Y = (int)mins.Y;
                    rectangle.Width = (int)maxs.X - rectangle.X;
                    rectangle.Height = (int)maxs.Y - rectangle.Y;

                    gfx.DrawRectangle(Pens.Yellow, rectangle);

                }
            }

            // Draw radius
            if (_showNodes)
            {
                for (int nodeId = 0; nodeId < _nav.Nodes.Count; nodeId++)
                {
                    var node = _nav.Nodes[nodeId];
                    var pos = QuakeToPreviewCoords(node.Origin);

                    // Draw selected
                    if (SelectedNodes.Contains(nodeId))
                        using (var brush = new SolidBrush(Color.FromArgb(100, 0, 255, 0)))
                            gfx.FillEllipse(brush, pos.X - node.Radius, pos.Y - node.Radius, node.Radius * 2f, node.Radius * 2f);

                    gfx.DrawEllipse(Pens.LawnGreen, pos.X - node.Radius, pos.Y - node.Radius, node.Radius * 2f, node.Radius * 2f);
                }
            }



            // Draw links
            if (_showLinks)
            {
                for (int nodeId = 0; nodeId < _nav.Nodes.Count; nodeId++)
                {
                    var node = _nav.Nodes[nodeId];
                    var pos = QuakeToPreviewCoords(node.Origin);

                    foreach (var link in node.Links)
                    {
                        var targetNode = link.Target;
                        var targetPos = QuakeToPreviewCoords(targetNode.Origin);

                        Pen pen;

                        if (link.Type == NavigationGraph.LinkType.Teleport)
                            pen = Pens.Purple;
                        else if (link.Type == NavigationGraph.LinkType.WalkOffLedge)
                            pen = Pens.Green;
                        else if (link.Type == NavigationGraph.LinkType.BarrierJump || link.Type == NavigationGraph.LinkType.ManualJump)
                            pen = Pens.Blue;
                        else if (targetNode.Links.Any(l => l.Target.Id == nodeId))
                            pen = Pens.White;
                        else
                            pen = Pens.Cyan;

                        gfx.DrawLine(pen, pos, targetPos);
                    }
                }
            }

            // Draw node centers
            if (_showNodes)
            {
                foreach (var node in _nav.Nodes)
                {
                    var pos = QuakeToPreviewCoords(node.Origin);

                    gfx.FillEllipse(Brushes.Cyan, pos.X - (NodeSize / 2f), pos.Y - (NodeSize / 2f), NodeSize, NodeSize);
                }

            }

            // Draw node ids
            if (_showNodeIds)
            {
                using (var font = new Font("Calibri", 12f))
                    for (int i = 0; i < _nav.Nodes.Count; i++)
                    {
                        var node = _nav.Nodes[i];
                        var pos = QuakeToPreviewCoords(node.Origin);

                        var id = i.ToString();
                        var measure = gfx.MeasureString(id, font);
                        gfx.DrawString(id, font, Brushes.White, pos.X - (measure.Width / 2f), pos.Y - 24);
                    }
            }
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            Zoom = Zoom + ((e.Delta / 4000f) * Zoom);

            if (Zoom < 0.001) Zoom = 0.001f;
            Render();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_pictureBox != null)
                        UnhookEvents(_pictureBox);
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~NavPreview()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
