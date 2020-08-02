using BLL;
using Microsoft.AspNetCore.Http;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioCodeValidation : RepositorioBase<CodeValidation>, IRepositoryCodeValidation
    {
        private readonly Contexto _context;
        public RepositorioCodeValidation(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }
        public CodeValidation GenerarToken(CodeValidation validation)
        {
            int longitud = 4;
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            validation.Codigo = token.Substring(0, longitud);
            return validation;
        }
    }
}
