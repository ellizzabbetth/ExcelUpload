using System;
using Xunit;

using System.Collections.Generic;
using System.Linq;
using FileUpload.Contracts;

using FileUpload.Models;

namespace web_api_tests
{
    public class DataServiceFake: IDataService
    {
        private readonly List<User> _user;

        public DataServiceFake()
        {
            _user = new List<User>()
            {
                new User() { Id = 1,
                    FirstName = "Orange Juice", LastName = "Orange Juice", Age = 5, Status = Status.Hold  },

                new User() { Id = 3,
                    FirstName = "Wha", LastName = "Oaui", Age = 5, Status = Status.Active },

                new User() { Id = 2,
                    FirstName = "Stu", LastName = "Felty", Age = 5, Status = Status.Active }

            };
        }

        public IEnumerable<User> GetAll()
        {
            return _user;
        }
    }
}
