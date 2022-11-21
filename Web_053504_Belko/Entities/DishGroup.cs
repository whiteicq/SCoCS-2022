using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_053504_Belko.Entities
{
    public class DishGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DishGroup(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
