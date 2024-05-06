using Blazorise.TreeView;
using System.Collections.ObjectModel;

namespace BlazoriseTreeviewUpdateBug.Client.Pages
{
    public partial class MenuBuilder
    {
        WsvanMenuSettings _menu = new WsvanMenuSettings();
        ObservableCollection<WsvanMenuRow> _menuRows = new ObservableCollection<WsvanMenuRow>();
        IList<WsvanMenuRow> expandedNodes = new List<WsvanMenuRow>();
        WsvanMenuRow selectedNode;

        bool showContextMenu = false;
        double contextMenuPosX;
        double contextMenuPosY;
        WsvanMenuRow contextMenuNode;

        TreeView<WsvanMenuRow> _treeView;

        private string _newRowName = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            //_menu = await _menuService.GetMenuSettings();
            _menuRows = new ObservableCollection<WsvanMenuRow>

                {
                    new WsvanMenuRow
                    {
                        Id = 1,
                        Label = "Zutphen",
                        Subrows = new List<WsvanMenuRow>
                        {
                            new WsvanMenuRow
                            {
                                Id = 2,
                                Label = "GFT"
                            },
                            new WsvanMenuRow
                            {
                                Id = 3,
                                Label = "Rest"
                            }
                        }
                    },
                    new WsvanMenuRow
                    {
                        Id = 4,
                        Label = "Apeldoorn"
                    }
            };
        }

        protected Task OnNodeContextMenu(TreeViewNodeMouseEventArgs<WsvanMenuRow> eventArgs)
        {
            _newRowName = "New row";
            showContextMenu = true;
            contextMenuNode = eventArgs.Node;
            contextMenuPosX = eventArgs.MouseEventArgs.ClientX;
            contextMenuPosY = eventArgs.MouseEventArgs.ClientY;
            if (!expandedNodes.Contains(contextMenuNode))
                expandedNodes.Add(contextMenuNode);
            return Task.CompletedTask;
        }

        protected Task OnContextItemNewClicked(WsvanMenuRow item)
        {
            showContextMenu = false;
            if (item.Subrows == null)
            {
                item.Subrows = new List<WsvanMenuRow>();
            }
            item.Subrows.Add(new WsvanMenuRow
            {
                Id = item.Subrows.Count + 1,
                Label = _newRowName
            });
            _treeView.Reload();
            StateHasChanged();
            return Task.CompletedTask;
        }

        protected Task OnContextItemEditClicked(WsvanMenuRow item)
        {
            showContextMenu = false;

            return Task.CompletedTask;
        }

        protected async Task OnContextItemDeleteClicked(WsvanMenuRow item)
        {
            await _treeView.RemoveNode(item);
            //await _treeView.Reload();
            showContextMenu = false;
            //return Task.CompletedTask;
        }
    }
}