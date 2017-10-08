using System;
using TelerikAcademy.ForumSystem.Data.Model.Abstracts;

namespace TelerikAcademy.ForumSystem.Data.Model
{
    public class Meal : DataModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        //public virtual User Author { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }
    }
}
