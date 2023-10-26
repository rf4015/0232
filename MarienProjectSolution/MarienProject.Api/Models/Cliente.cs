using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string ClienteNombres { get; set; } = null!;

    public string ClienteApellidos { get; set; } = null!;

    public string ClienteTelefono { get; set; } = null!;

    public string ClienteCorreoElectronico { get; set; } = null!;

    public string ClienteNombreUsuario { get; set; } = null!;

    public string ClienteContraseña { get; set; } = null!;

    public bool? ClienteEstado { get; set; }

    public virtual ICollection<DireccionCliente> DireccionClientes { get; set; } = new List<DireccionCliente>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
