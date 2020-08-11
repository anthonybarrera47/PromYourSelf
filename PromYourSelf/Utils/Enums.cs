using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Utils
{
    public enum TitleType
    {
        [Description("¡Operacion Exitosa!")]
        OperacionExitosa,
        [Description("!Operacion Fallida!")]
        OperacionFallida,
        [Description("!Informacion!")]
        Informacion
    }
    public enum MessageType
    {
        [Description("¡Registro Guardado!")]
        RegistroGuardado,
        [Description("¡No Se Guardo Su Registro")]
        RegistroNoGuardado,
        [Description("¡No Puede Modificar Un Registro Inexistente!")]
        RegistroInexistente,
        [Description("¡Registro Eliminado Correctamente!")]
        RegistroEliminado,
        [Description("¡Registro Modificado!")]
        RegistroModificado,
        [Description("¡Lo sentimos su código ya expiro, le reenviamos un nuevo correo con un código de confirmacion nuevo.!")]
        CodigoExpirado,
        [Description("¡Felicidades, su usuario ha sido confirmado.!")]
        UsuarioConfirmado,
        [Description("¡Lo sentimos, su usuario no ha sido confirmado.!")]
        UsuarioNoConfirmado
    }
    public enum IconType
    {
        success,
        error,
        warning,
        info,
        question
    }
}
