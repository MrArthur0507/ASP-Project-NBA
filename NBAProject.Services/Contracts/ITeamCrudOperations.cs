﻿using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITeamCrudOperations
    {
        public List<TeamViewModel> GetAll();

        public TeamViewModel GetById(int teamId);
    }
}
