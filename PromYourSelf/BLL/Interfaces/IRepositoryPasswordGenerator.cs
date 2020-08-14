﻿using BLL;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepositoryPasswordGenerator : IRepository<PasswordGenerator>
    {
        string GenerarToken();
    }
}
