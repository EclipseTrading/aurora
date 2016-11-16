using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aurora.Core
{
    public static class ViewPropertyHelper
    {
        public static readonly DependencyProperty DependencyHandlerProperty = DependencyProperty.RegisterAttached(
           "DependencyHandler", typeof(IDependencyHandler), typeof(ViewPropertyHelper), new PropertyMetadata(default(IDependencyHandler)));

        public static void SetDependencyHandler(DependencyObject element, IDependencyHandler value)
        {
            element.SetValue(DependencyHandlerProperty, value);
        }

        public static IDependencyHandler GetDependencyHandler(DependencyObject element)
        {
            return (IDependencyHandler)element.GetValue(DependencyHandlerProperty);
        }
    }
}
