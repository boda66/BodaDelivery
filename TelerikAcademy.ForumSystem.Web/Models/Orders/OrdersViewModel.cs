﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikAcademy.ForumSystem.Web.Models.Home
{
    public class OrdersViewModel
    {
        public ICollection<OrderViewModel> Order { get; set; }
    }
}