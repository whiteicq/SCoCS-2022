using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_053504_Belko.Models
{
    public class MenuItem
    {
        public bool isPage;
        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Page { get; set; }
        public string Area { get; set; }
        public string Active { get; set; }
    }
}
