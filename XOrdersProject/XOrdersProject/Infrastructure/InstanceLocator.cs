using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOrdersProject.ViewModels;

namespace XOrdersProject.Infrastructure
{
    public class InstanceLocator
    {
        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
        public MainViewModel Main { get; set; }
    }
}
