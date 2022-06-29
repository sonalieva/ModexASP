using Medex.DAL;
using Medex.Helpers;
using Medex.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Areas.Manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var model = _context.Teams.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (team.ImageFiles != null)
            {
                if (team.ImageFiles.ContentType != "image/png" && team.ImageFiles.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Imagefiles", "File format must be jpeg or png");
                    return View();
                }
                if (team.ImageFiles.Length > 2097521)
                {
                    ModelState.AddModelError("ImageFiles", "File size must be less than 2mb");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("ImageFiles", "ImageFiles is required");
                    return View();
                }
            }

            //Team.Image = FileManager.Save(_env.WebRootPath, "uploads/team", team.ImageFiles);
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            
            return View(team);
        }
        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
