using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IAppliesService appliesService;
        private readonly IMapper mapper;

        public JobController(IAppliesService appliesService, IMapper mapper)
        {
            this.appliesService = appliesService;
            this.mapper = mapper;
        }
        

        public ActionResult ApplyForJob()
        {
            Applies apply = new Applies() { Id = Guid.Parse(User.Identity.GetUserId()), UserName = User.Identity.Name };
            this.appliesService.Add(apply);

            return this.RedirectToAction("Index", "Manage");
        }
    }
}