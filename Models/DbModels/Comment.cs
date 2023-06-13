using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

    }
}
