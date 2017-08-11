using System.Windows;
using System.Windows.Controls;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer
{
    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MenuItemCommand)
                return MenuItemTemplate;
            if (item is DividerItem)
                return SeparatorTemplate;

            return base.SelectTemplate(item, container);
        }

        public DataTemplate MenuItemTemplate { get; set; }

        public DataTemplate SeparatorTemplate { get; set; }
    }
}