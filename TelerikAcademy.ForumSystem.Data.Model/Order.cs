using System;
using TelerikAcademy.ForumSystem.Data.Model.Abstracts;

namespace TelerikAcademy.ForumSystem.Data.Model
{
    public class Order : DataModel
    {
        public string Title { get; set; }

        public string Address { get; set; }

        //public virtual User Author { get; set; }

        public string UserName { get; set; }
    }
}
