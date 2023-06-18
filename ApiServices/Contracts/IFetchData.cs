using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Contracts
{
    public interface IFetchData
    {
        public Task Fetch();
        public List<ApiLogger> GetLog();
    }
}
