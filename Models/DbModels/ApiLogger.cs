using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class ApiLogger
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
        public bool isFinished { get; set; }

    }
}
