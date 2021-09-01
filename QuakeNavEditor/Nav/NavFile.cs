using QuakeNavEditor.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Nav
{
    public class NavFile
    {
        private struct FileNode
        {
            public ushort Flags { get; set; }
            public ushort ConnectionCount { get; set; }
            public ushort ConnectionStartIndex { get; set; }
            public ushort Radius { get; set; }
        }

        private struct FileLink
        {
            public ushort Destination { get; set; }
            public ushort Type { get; set; }
            public ushort TraversalIndex { get; set; }
        }

        private struct FileNodeOrigin
        {
            public Vector3 Origin { get; set; }
        }

        private struct FileTraversal
        {
            public Vector3 NodeExit { get; set; }
            public Vector3 JumpStart { get; set; }
            public Vector3 JumpEnd { get; set; }
        }

        private struct FileEdict
        {
            public ushort LinkId { get; set; }
            public Vector3 Mins { get; set; }
            public Vector3 Maxs { get; set; }
            public int Targetname { get; set; }
            public int Classname { get; set; }
        }

        public List<NavNode> Nodes { get; private set; } = new List<NavNode>();


        public async Task SaveToStreamAsync(Stream stream)
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                // Write header
                writer.Write(new char[] { 'N', 'A', 'V', '2' }); // Magic number
                writer.Write((uint)14); // Version
                writer.Write((uint)Nodes.Count); // Node count

                var linkCountPosition = ms.Position;
                writer.Write((uint)0); // Link count

                var traversalCountPosition = ms.Position;
                writer.Write((uint)0); // Traversal count


                var links = new List<NavLink>();

                // Write nodes
                for(var i=0;i<Nodes.Count;i++)
                {
                    var node = Nodes[i];
                    
                    writer.Write((ushort)node.Flags); // Flags
                    writer.Write((ushort)node.OutgoingLinks.Count); // Connection count
                    writer.Write((ushort)links.Count); // Connection start index
                    writer.Write((ushort)node.Radius); // Radius

                    // Add links for later writting them
                    links.AddRange(node.OutgoingLinks);
                }

                // Write node origins
                for(var i = 0; i < Nodes.Count; i++)
                {
                    writer.Write(Nodes[i].Position);
                }

                var traversals = new List<NavLinkTraversal>();

                // Write links
                for(var i=0;i<links.Count;i++)
                {
                    var link = links[i];
                    writer.Write((ushort)link.Destination);
                    writer.Write((ushort)link.Type);

                    if(link.Traversal != null)
                    {
                        writer.Write((ushort)traversals.Count);
                        traversals.Add(link.Traversal);
                    }
                    else
                    {
                        writer.Write((ushort)0xFFFF);
                    }
                }

                // Write traversals
                for(var i=0;i<traversals.Count;i++)
                {
                    var traversal = traversals[i];

                    writer.Write(traversal.NodeExit);
                    writer.Write(traversal.JumpStart);
                    writer.Write(traversal.JumpEnd);
                }

                // Write edicts
                var edictCountPosition = ms.Position;
                writer.Write((uint)0); // Edict count

                var edictCount = 0;
                for(var i=0;i<links.Count;i++)
                {
                    var link = links[i];

                    if (link.Edict == null)
                        continue;

                    edictCount++;

                    var edict = link.Edict;

                    writer.Write((ushort)i); // Link id
                    writer.Write(edict.Mins); // Mins
                    writer.Write(edict.Maxs); // Maxs
                    writer.Write(edict.Targetname); // Targetname
                    writer.Write(edict.Classname); // Classname
                }

                // Write edict count
                ms.Seek(edictCountPosition, SeekOrigin.Begin);
                writer.Write((uint)edictCount);

                // Write header counters
                ms.Seek(linkCountPosition, SeekOrigin.Begin);
                writer.Write((uint)links.Count);
                ms.Seek(traversalCountPosition, SeekOrigin.Begin);
                writer.Write((uint)traversals.Count);

                writer.Flush();

                ms.Position = 0;
                await ms.CopyToAsync(stream);
            }
        }

        public static async Task<NavFile> LoadFromStreamAsync(Stream stream)
        {
            var nav = new NavFile();

            using (var ms = new MemoryStream())
            using (var reader = new BinaryReader(ms))
            {
                await stream.CopyToAsync(ms);
                ms.Position = 0;

                var magicNumber = reader.ReadChars(4);
                if (magicNumber[0] != 'N' || magicNumber[1] != 'A' || magicNumber[2] != 'V' || magicNumber[3] != '2')
                    throw new InvalidDataException("Stream is not NAV2 format");

                var version = reader.ReadUInt32();
                if (version != 14)
                    throw new InvalidDataException($"Unsuported NAV2 version {version}");

                var nodeCount = reader.ReadUInt32();
                var linkCount = reader.ReadUInt32();
                var traversalCount = reader.ReadUInt32();

                // Read nodes
                var nodes = new FileNode[nodeCount];
                for(var i=0;i<nodeCount;i++)
                {
                    nodes[i] = new FileNode()
                    {
                        Flags = reader.ReadUInt16(),
                        ConnectionCount = reader.ReadUInt16(),
                        ConnectionStartIndex = reader.ReadUInt16(),
                        Radius = reader.ReadUInt16()
                    };
                }

                // Read node positions
                var nodeOrigins = new FileNodeOrigin[nodeCount];
                for (var i = 0; i < nodeCount; i++)
                {
                    nodeOrigins[i] = new FileNodeOrigin() { Origin = reader.ReadVector3() };
                }

                // Read links
                var links = new FileLink[linkCount];
                for(var i=0;i<linkCount;i++)
                {
                    links[i] = new FileLink()
                    {
                        Destination = reader.ReadUInt16(),
                        Type = reader.ReadUInt16(),
                        TraversalIndex = reader.ReadUInt16()
                    };
                }

                // Read traversals
                var traversals = new FileTraversal[traversalCount];
                for(var i=0;i<traversalCount;i++)
                {
                    traversals[i] = new FileTraversal()
                    {
                        NodeExit = reader.ReadVector3(),
                        JumpStart = reader.ReadVector3(),
                        JumpEnd = reader.ReadVector3()
                    };
                }

                // Read edicts
                var edictCount = reader.ReadUInt32();
                var edicts = new FileEdict[edictCount];
                for(var i = 0; i < edictCount; i++)
                {
                    edicts[i] = new FileEdict()
                    {
                        LinkId = reader.ReadUInt16(),
                        Mins = reader.ReadVector3(),
                        Maxs = reader.ReadVector3(),
                        Targetname = reader.ReadInt32(),
                        Classname = reader.ReadInt32()
                    };
                }

                // Create the nodes
                var linkIdToObj = new Dictionary<int, NavLink>();

                for(var i = 0; i < nodeCount; i++)
                {
                    var node = new NavNode();
                    node.Flags = (NavNodeFlags)nodes[i].Flags;
                    node.Position = nodeOrigins[i].Origin;
                    node.Radius = nodes[i].Radius;

                    // Create the links
                    var linkStart = nodes[i].ConnectionStartIndex;
                    var linkEnd = linkStart + nodes[i].ConnectionCount;
                    for(var lid=linkStart;lid<linkEnd;lid++)
                    {
                        var link = new NavLink()
                        {
                            Destination = links[lid].Destination,
                            Type = (NavLinkType)links[lid].Type
                        };

                        // Create traversals
                        var traversalIndex = links[lid].TraversalIndex;
                        if (traversalIndex != 0xFFFF)
                        {
                            link.Traversal = new NavLinkTraversal()
                            {
                                NodeExit = traversals[traversalIndex].NodeExit,
                                JumpStart = traversals[traversalIndex].JumpStart,
                                JumpEnd = traversals[traversalIndex].JumpEnd
                            };
                        }

                        linkIdToObj[lid] = link;

                        node.OutgoingLinks.Add(link);
                    }

                    nav.Nodes.Add(node);
                }

                // Set the edicts
                for(var i=0;i<edictCount;i++)
                {
                    var link = linkIdToObj[edicts[i].LinkId];

                    var edict = new NavLinkEdict();

                    edict.Mins = edicts[i].Mins;
                    edict.Maxs = edicts[i].Maxs;
                    edict.Targetname = edicts[i].Targetname;
                    edict.Classname = edicts[i].Classname;

                    link.Edict = edict;
                }
            }

            return nav;
        }
    }
}
