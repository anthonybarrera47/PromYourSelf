﻿using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepositoryHorarios : IRepository<Horarios>
    {
        Task<Horarios> FindAsyncByNegocio(int? id);
    }
}
