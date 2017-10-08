using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Web.Infrastructure;

namespace TelerikAcademy.ForumSystem.Web.Models.Home
{
    public class OrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {

        public string Title { get; set; }

        public string Address { get; set; }

        //public virtual User Author { get; set; }

        public string UserName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, OrderViewModel>()
                .ForMember(OrderViewModel => OrderViewModel.PostedOn, cfg => cfg.MapFrom(order => order.CreatedOn));
        }
    }
}