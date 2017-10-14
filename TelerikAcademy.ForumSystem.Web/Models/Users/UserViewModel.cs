using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Web.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TelerikAcademy.ForumSystem.Web.Models.Home
{
    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        //public virtual User Author { get; set; }

        public ICollection<IdentityUserRole> Roles { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(UserViewModel => UserViewModel.PostedOn, cfg => cfg.MapFrom(user => user.CreatedOn));
        }
    }
}