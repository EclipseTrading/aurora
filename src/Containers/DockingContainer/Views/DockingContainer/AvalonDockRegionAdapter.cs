using System.Collections.Specialized;
using System.Linq;
using Aurora.Core.Workspace;
using Microsoft.Practices.Prism.Regions;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class AvalonDockRegionAdapter : RegionAdapterBase<DockingManager>
    {
        private DockingManager dockingManager;    

        public AvalonDockRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
            this.dockingManager = regionTarget;
            region.Views.CollectionChanged += (sender, e) => OnViewsCollectionChanged(sender, e, region, regionTarget);
            regionTarget.DocumentClosed += (sender, e) => this.OnDocumentClosedEventArgs(sender, e, region);
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        private static void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, DockingManager regionTarget)
        {
           
            if (e.Action == NotifyCollectionChangedAction.Add)
            {

                foreach (ViewContext item in e.NewItems)
                {
                    var viewActivityInfo = item.Info;
                    var workspaceLocation = viewActivityInfo.WorkspaceLocation;

                    if (workspaceLocation == null)
                    {
                        //do normal docking as before
                        workspaceLocation = new WorkspaceLocation();
                        viewActivityInfo.WorkspaceLocation = workspaceLocation;
                        var paneGroup = (LayoutDocumentPaneGroup)regionTarget.Layout.RootPanel.Children[0];
                        var pane = (LayoutDocumentPane)paneGroup.Children.ToList()[0];
                        var newLayoutDocument = new PresenterLayoutDocument(item);
                        pane.InsertChildAt(0, newLayoutDocument);

                    }
                    else
                    {

                        if (workspaceLocation.IsFloating)
                        {
                            var newLayoutDocument = new PresenterLayoutDocument(item);
                            newLayoutDocument.FloatingTop = workspaceLocation.FloatingTop;
                            newLayoutDocument.FloatingLeft = workspaceLocation.FloatingLeft;
                            newLayoutDocument.FloatingWidth = workspaceLocation.FloatingWidth;
                            newLayoutDocument.FloatingHeight = workspaceLocation.FloatingHeight;

                            var paneGroup = (LayoutDocumentPaneGroup)regionTarget.Layout.RootPanel.Children[0];
                            var pane = (LayoutDocumentPane)paneGroup.Children[0];
                            pane.InsertChildAt(0, newLayoutDocument);
                            newLayoutDocument.Float();
                        }
                        else
                        {


                            var paneGroup = (LayoutDocumentPaneGroup)regionTarget.Layout.RootPanel.Children[0];
                            int paneGroupCount = paneGroup.Children.Count;
                            if (workspaceLocation.GroupIdx >= paneGroupCount)
                            {
                                var diff = workspaceLocation.GroupIdx - paneGroupCount + 1;

                                Enumerable.Range(0, diff).ToList().ForEach(arg =>
                                {
                                    var newPane = new LayoutDocumentPane();
                                    paneGroup.InsertChildAt(paneGroup.ChildrenCount, newPane);
                                });
                             
                            }

                            var pane = (LayoutDocumentPane)paneGroup.Children.ToList()[workspaceLocation.GroupIdx];
                            var newLayoutDocument = new PresenterLayoutDocument(item);
                            pane.InsertChildAt(0, newLayoutDocument);
                            var sorted = pane.Children.OrderBy(d => ((PresenterLayoutDocument)d).WorkspaceLocation.TabOrder).ToList();
                            pane.Children.Clear();
                            sorted.ForEach( (sortedItem) => { pane.InsertChildAt(pane.ChildrenCount, sortedItem); } );

                        }
                    }

                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ViewContext item in e.OldItems)
                {
                    if (item.View == null)
                        continue;

                    item.View.Presenter?.Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the DocumentClosedEventArgs event raised by the DockingNanager when
        /// one of the LayoutContent it hosts is closed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event.</param>
        /// <param name="region">The region.</param>
        void OnDocumentClosedEventArgs(object sender, DocumentClosedEventArgs e, IRegion region)
        {
            var presenterLayoutDocument = e.Document as PresenterLayoutDocument;
            if (presenterLayoutDocument != null)
            {
                region.Remove(presenterLayoutDocument.ViewContext);  
            }
        }
    }
}
