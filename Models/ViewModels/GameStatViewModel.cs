﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class GameStatViewModel
    {
        public int GameId { get; set; }

        public List<PlayerViewModel> Stats { get; set; } = new List<PlayerViewModel>();
    }
}
