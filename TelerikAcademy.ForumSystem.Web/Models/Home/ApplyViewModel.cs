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
    public class ApplyViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public Guid id { get; set; }

        //public virtual User Author { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Applies, ApplyViewModel>()
                .ForMember(ApplyViewModel => ApplyViewModel.PostedOn, cfg => cfg.MapFrom(order => order.CreatedOn));
        }
    }
}