using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_053504_Belko.Entities
{
    public class Dish
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public float Calories { get; set; }
        public string Image { get; set; }
        public Dish(string title, string description, float calories, string image, int groupId)
        {
            Title = title;
            Description = description;
            Calories = calories;
            Image = image;
            GroupId = groupId;
        }
    }
}
