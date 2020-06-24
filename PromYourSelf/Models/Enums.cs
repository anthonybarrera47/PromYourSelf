﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public enum TipoGenero
    {
        Masculino = 0,
        Femenino = 1,
        Otros = 2
    }
    public enum TiposUsuario
    {
        Cliente = 0,
        Administrador = 1
    }
    public enum EstadoCita
    {
        Solicitado = 0,
        EnProceso = 1,
        Finalizado = 2
    }
    public enum TipoProducto
    {
        Producto = 0,
        Servicio = 1
    }
}