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
        [Description("¡Registro Modificado")]
        RegistroModificado,
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
