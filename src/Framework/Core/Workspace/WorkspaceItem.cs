using Aurora.Core.Activities;
using System;

namespace Aurora.Core.Workspace
{

    public class WorkspaceItem
    {
        public WorkspaceItem(ViewActivityInfo viewInfo, Type presenterType, ActiveView view)
        {
            this.ViewInfo = viewInfo;
            this.PresenterType = presenterType;
            this.View = view;
        }

        public ViewActivityInfo ViewInfo { get; }
        public Type PresenterType { get; }
        public ActiveView View { get; }
    }
}
