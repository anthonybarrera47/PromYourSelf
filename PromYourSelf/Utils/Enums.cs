﻿using System;
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
        UsuarioNoConfirmado,
        [Description("¡Lo sentimos, esta contraseña provisional ya expiro , solicite un nuevo reestablecimiento de contraseña!")]
        PasswordExpired,
        [Description("¡La contraseña temporal ha sido enviada, tiene 24Horas para reestrablecer su contraseña !")]
        PasswordSend,
        [Description("¡Su contraseña ha sido reestablecida temporalmente recuerde por favor cambiar sus credenciales!")]
        PasswordReset,
        [Description("¡Su contraseña o usuario son inválidas, verifique su información!")]
        CredencialesInvalidas,

    }
    public enum IconType
    {
        success,
        error,
        warning,
        info,
        question
    }
    public enum TypeClaims
    {
        Nombres = 0,
        Foto = 1,
        Posicion = 2,
        Empresa = 3,
        Horarios = 4
    }
}
