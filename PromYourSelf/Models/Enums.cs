using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public enum EstadoCita
	{
		Solicitado = 0,
		Aceptada = 1,
		EnProceso = 2,
		Finalizado = 3,
		Cancelada = 4
	}
	public enum TipoProducto
	{
		Producto = 0,
		Servicio = 1
	}

	public enum Posicion
	{
		[Description("Administrador")]
		Administrador = 0,
		[Description("Normal")]
		Normal = 1
	}
	public enum TipoContenido
	{
		Texto = 0,
		Base64 = 1,
		Documento = 2
	}
	public enum EstadoMensaje
    {
		Enviado  = 0,
		Leido = 1
    }
}
