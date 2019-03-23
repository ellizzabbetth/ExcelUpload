using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Contracts;
using FileUpload.Models;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileUpload.Services
{ 
    public class DataService : IDataService
    {       
        public IEnumerable<User> GetAll()
        {
            return FileUpload.Models.Utility.GetData();
        }      
    }
}
