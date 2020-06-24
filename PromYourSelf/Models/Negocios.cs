using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Negocios : CamposEstandar
    {
        [Key]
        public int NegocioID { get; set; }
        public new int UsuarioID { get; set; }
        [Required(ErrorMessage = "Este esCampo obligatorio")]
        [StringLength(255,
            ErrorMessage = "El descripcion debe ser menor a 255 caracteres.")]
        [Display(Name = "Nombre Comercial")]
        public string NombreComercial { get; set; }
        [Required(ErrorMessage = "Este es Campo obligatorio")]
        [StringLength(255,
            ErrorMessage = "La descripcion no debe de tener mas de 255 caracteres.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este es Campo obligatorio")]
        [Display(Name = "Teléfono")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono1 { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono2 { get; set; }
        [Required(ErrorMessage = "Este es Campo obligatorio")]
        public int CiudadID { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

    }
}
