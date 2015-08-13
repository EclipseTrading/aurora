using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Aurora.Core;
using Microsoft.Practices.Prism.Regions;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Aurora.DockingContainer.Views.DockingContainer
{
    public class AvalonDockRegionAdapter : RegionAdapterBase<DockingManager>
    {
        public AvalonDockRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) => OnViewsCollectionChanged(sender, e, region, regionTarget);
            regionTarget.DocumentClosed += (sender, e) => this.OnDocumentClosedEventArgs(sender, e, region);
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        private static void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, DockingManager regionTarget)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;

            foreach (ActiveView item in e.NewItems)
            {
                var view = item.View;
                if (view == null)
                    continue;
                
                //Create a new layout document to be included in the LayoutDocuemntPane (defined in xaml)
                var newLayoutDocument = new PresenterLayoutDocument(item);

                //Store all LayoutDocuments already pertaining to the LayoutDocumentPane (defined in xaml)
                var oldLayoutDocuments = new List<LayoutDocument>();
                //Get the current ILayoutDocumentPane ... Depending on the arrangement of the views this can be either 
                //a simple LayoutDocumentPane or a LayoutDocumentPaneGroup
                var currentILayoutDocumentPane = (ILayoutDocumentPane)regionTarget.Layout.RootPanel.Children[0];

                if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPaneGroup))
                {
                    //If the current ILayoutDocumentPane turns out to be a group
                    //Get the children (LayoutDocuments) of the first pane
                    var oldLayoutDocumentPane = (LayoutDocumentPane)currentILayoutDocumentPane.Children.ToList()[0];
                    foreach (var child in oldLayoutDocumentPane.Children.Cast<LayoutDocument>())
                    {
                        oldLayoutDocuments.Insert(0, child);
                    }
                }
                else if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPane))
                {
                    //If the current ILayoutDocumentPane turns out to be a simple pane
                    //Get the children (LayoutDocuments) of the single existing pane.
                    foreach (var child in currentILayoutDocumentPane.Children.Cast<LayoutDocument>())
                    {
                        oldLayoutDocuments.Insert(0, child);
                    }
                }

                //Create a new LayoutDocumentPane and inserts your new LayoutDocument
                var newLayoutDocumentPane = new LayoutDocumentPane();
                newLayoutDocumentPane.InsertChildAt(0, newLayoutDocument);

                //Append to the new LayoutDocumentPane the old LayoutDocuments
                foreach (var doc in oldLayoutDocuments)
                {
                    newLayoutDocumentPane.InsertChildAt(0, doc);
                }

                newLayoutDocumentPane.SelectedContentIndex = newLayoutDocumentPane.IndexOf(newLayoutDocument);


                //Traverse the visual tree of the xaml and replace the LayoutDocumentPane (or LayoutDocumentPaneGroup) in xaml
                //with your new LayoutDocumentPane (or LayoutDocumentPaneGroup)
                if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPane))
                    regionTarget.Layout.RootPanel.ReplaceChildAt(0, newLayoutDocumentPane);
                else if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPaneGroup))
                {
                    currentILayoutDocumentPane.ReplaceChild(currentILayoutDocumentPane.Children.ToList()[0], newLayoutDocumentPane);
                    regionTarget.Layout.RootPanel.ReplaceChildAt(0, currentILayoutDocumentPane);
                }
                newLayoutDocument.IsActive = true;
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
                region.Remove(presenterLayoutDocument.View);
        }
    }
}
