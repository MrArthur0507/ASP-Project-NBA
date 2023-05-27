using ApiServices.Contracts;
using Microsoft.EntityFrameworkCore.Query;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services.MicroService
{
    public class BasicSeeder : IBasicSeeder
    {
        protected readonly IPrint _print;
        public BasicSeeder(IPrint print) {
            _print = print;
        }

    }
}
