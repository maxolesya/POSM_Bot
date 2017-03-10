using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToBuildBot
{
    public abstract class Route
    {
        protected List<Route> children;

        public List<Route> Children
        {
            get { return children; }
            set { children = value; }

        }

        protected Middle parent;

        public Middle Parent
        {
            get { return parent; }

        }
        protected string name;

        public string Name
        {
            get { return name; }

        }

        public virtual void getMessage ()
        {

        }
    }
}
