using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToBuildBot
{
    class ChatInfo
    {
        public long ChatId { get; set; }
        public bool Login { get; set; }
        public bool Password { get; set; }
        public Route CurrentNode { get; set; }
    }
}
