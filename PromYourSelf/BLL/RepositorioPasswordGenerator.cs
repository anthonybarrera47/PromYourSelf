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
    public class RepositorioPasswordGenerator : RepositorioBase<PasswordGenerator>, IRepositoryPasswordGenerator
    {
        private readonly Contexto _context;
        public RepositorioPasswordGenerator(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }
        public string GenerarToken()
        {
            int longitud = 8;
            string str = string.Empty;
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            str = token.Substring(0, longitud);
            return str;
        }
    }
}
