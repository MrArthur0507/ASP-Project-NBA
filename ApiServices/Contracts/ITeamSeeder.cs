﻿using Models.ApiModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Contracts
{
    public interface ITeamSeeder
    {
        public void Seed(PlayerRoot root, ApplicationDbContext _context);
    }
}
