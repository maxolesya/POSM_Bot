using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToBuildBot
{
    public class Final:Route
    {
       
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
           
        }
       
        public Final(string name, string imagePath, Middle parent)
        {
            this.name = name;
            this.imagePath = imagePath;
            this.parent = parent;
            children = null;
        }
        public override void getMessage()
        {
            base.getMessage();
        }
    }
}
