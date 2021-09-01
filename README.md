# QuakeNavEditor
A bot navigation file (.nav) editor for Quake 2021 re-release.

Made in C# .NET Core using WinForms.

![Screenshot](/docs/images/main.png)

# Features
* Create a nav file from scratch, if you wish.
* Edit any value from nodes, links, edicts and traversals.
* 2D preview of the node graph.
* Patch system to easily record and apply changes to a navigation file.

# Requirements

* .NET Core 5.0 Desktop Runtime


# Instructions

* Double-click or right-click on Nodes and Links to edit, add to patch or delete them.
* Add new nodes or links via the buttons at the toolbar
* Toggle some view modes with the butons at the toolbar

## Patches

Patches is a system to apply changes on top of an existing nav system. 
The idea is to record some information (eg: Traversals) and apply them later to another file.
This is because the in-game navigation editor only generates traversals for the currently available geometry and can't deal with moving geometry.
Saving at the correct point in-game will generate the correct traversals which then can be saved on a nav patch and applied later regardless of the in-game state.

* Right-click Node or Link to add to a patch.
* Remember to save & load patches as they're attached to your nav window.
* Click the "Patch" menu to apply a patch.

# Credits

Original author: JPiolho

# Disclaimer

The whole program is a bit janky right now as it was made in merely 2.5 days. But now the foundation is done and from here on out it can be updated.