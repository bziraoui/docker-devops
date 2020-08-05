using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FamillyShare.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamillyShare.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PhotoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Photo item)
        {
            ModelState.Remove(nameof(Photo.PhotoUrl));

            if (ModelState.IsValid)
            {
                IFormFile photoFile = item.PhotoFile;

                string extension = Path.GetExtension(photoFile.FileName);

                if (extension == ".png" || extension == ".jpg")
                {
                    string newFileName = item.Name;

                    if (photoFile.Length > 0)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "images", newFileName + extension);
                        item.PhotoUrl = "images/" + newFileName + extension;

                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            await photoFile.CopyToAsync(fs);
                        }
                        TempData["Message"] = "Téléchargement réussi.".ToBootstrapAlerts("success");
                        return RedirectToAction(nameof(Index));
                    }
                }


            }
            TempData["Message"] = "Opération échouée.".ToBootstrapAlerts("danger");
            return View(nameof(Index));
        }
    }
}
