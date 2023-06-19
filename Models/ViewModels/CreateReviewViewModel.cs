using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class CreateReviewViewModel
    {

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(500, ErrorMessage = "Content must not be more than 500 characters")]
        public string Content { get; set; }
        public int GameId { get; set; }
    }
}
