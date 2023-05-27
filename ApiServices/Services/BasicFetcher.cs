using ApiServices.Contracts;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services
{
    public class BasicFetcher : IBasicFetcher
    {

        protected readonly ApplicationDbContext _context;

        protected readonly HttpClient _client;
        public BasicFetcher(ApplicationDbContext context, HttpClient client)
        {
            _context = context;
            _client = client;
        }
    }
}
