using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class Print : IPrint
    {
        public void PrintMsg(string input)
        {
            Console.WriteLine(input);
        }
    }
}
