using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static FileUpload.Models.Utility;
using Microsoft.AspNetCore.Http;
using System.IO;

using System;
using Newtonsoft.Json;

using System.Net.Http.Headers;
using ExcelDataReader;
using FileUpload.Models;
using FileUpload.Helpers;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult Data()
        {
            ViewData["Message"] = "Your data page.";
            return View();
        }
      


        [HttpPost]
        public async Task<IActionResult> UploadSmallFile(IFormFile file)
        {
            // Full path to file in temp location
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            //Pprocess uploaded files
            try
            {
                var folderName = Path.Combine("StaticFiles", "Excel");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var destinationPath = Constants.JSON_PATH;

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    ConvertXSLX(fileName);
                    return View("Data");

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }  
    }   
}
