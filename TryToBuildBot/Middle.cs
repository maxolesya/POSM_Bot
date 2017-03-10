using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToBuildBot
{
    public class Middle : Route
    {
        
        public Middle(Middle parent, List<Route> children, string name)
        {
            this.parent = parent;
            this.name = name;
            this.children = children;
        }
        public override void getMessage()
        {
            base.getMessage();
        }


    }
}
