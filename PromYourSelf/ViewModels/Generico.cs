using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.ViewModels
{
    public class Generico
    {
		public string Id { get; set; }
		public string Name { get; set; }
		public Generico()
		{
			Id = string.Empty;
			Name = string.Empty;
		}
	}
}
