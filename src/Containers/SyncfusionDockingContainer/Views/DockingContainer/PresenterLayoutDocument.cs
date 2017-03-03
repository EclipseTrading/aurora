using System;
using System.Windows;
using System.Windows.Controls;
using Aurora.Core.ViewContainer;
using Aurora.Core.Workspace;
using Syncfusion.Windows.Tools.Controls;


namespace Aurora.SyncfusionDockingContainer.Views.DockingContainer
{
    public class PresenterLayoutDocument : ContentControl, IViewContainerService
    {
        public ViewContext ViewContext { get; }

        public ViewLocation ViewLocation { get; }

        public PresenterLayoutDocument(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
            this.Content = this.ViewContext.View.View;

            this.ViewLocation = this.ViewContext.Info?.ViewLocation;

            var viewContainerAware = this.ViewContext.View.Presenter as IViewContainerAware;
            if (viewContainerAware != null)
            {
                //attach PresenterLayoutDocument to Presenter
                viewContainerAware.ViewContainerService = this;

                if (this.ViewContext.Info?.HeaderTemplate != null)
                {               
                    SetHeader(this.ViewContext.Info?.HeaderTemplate, this.ViewContext.Info?.HeaderContent);
                }
            }
        }

        public void SetTitle(string title)
        {
            this.ViewContext.Info.Title = title;
            DockingManager.SetHeader(this, title);
        }

        public void CloseView()
        {
            DockingManager.GetDockingManager(this).Children.Remove(this);
        }

        public void SetHeader(DataTemplate headerTemplate, object headerContent)
        {
            DockingManager.SetHeader(this, headerContent);
            DockingManager.SetHeaderTemplate(this, headerTemplate);
        }

    }
}
