using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Contracts
{
    public interface IDataService
    {
        IEnumerable<User> GetAll();
    }
}
