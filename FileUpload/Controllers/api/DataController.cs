using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FileUpload.Models;
using FileUpload.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileUpload.Controllers.api
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IDataService _service;

        public DataController(IDataService service)
        {
            _service = service;
        }

        [HttpPost]
        //   public async Task<IActionResult> ShowData()
        public IActionResult ShowData() 
        {
            // get json data 
            List<User> json = FileUpload.Models.Utility.GetData();
            dynamic response = new
            {
                Data = json,
                Draw = "1",
                RecordsFiltered = json.Count,
                RecordsTotal = json.Count
            };
            return Ok(response);
        }
    }
}
