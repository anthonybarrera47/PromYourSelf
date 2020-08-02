using BLL;
using Models;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
   public interface IRepositoryCodeValidation : IRepository<CodeValidation>
    {
        CodeValidation GenerarToken(CodeValidation validation);
    }
}
