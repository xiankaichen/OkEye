using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace OkEye.Modules.ModuleCamera
{
    internal class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement view in e.NewItems)
                        {
                            regionTarget.Children.Add(view);
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (FrameworkElement view in e.OldItems)
                        {
                            regionTarget.Children.Remove(view);
                        }
                        break;
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
