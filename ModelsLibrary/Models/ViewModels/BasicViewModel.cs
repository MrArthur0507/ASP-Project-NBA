using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.ViewModels
{
    public class BasicViewModel
    {
        public string Id { get; }

        public BasicViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
