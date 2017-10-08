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
    public class MealViewModel : IMapFrom<Meal>, IHaveCustomMappings
    {
        
        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Meal, MealViewModel>()
                .ForMember(MealViewModel => MealViewModel.PostedOn, cfg => cfg.MapFrom(meal => meal.CreatedOn));
        }
    }
}