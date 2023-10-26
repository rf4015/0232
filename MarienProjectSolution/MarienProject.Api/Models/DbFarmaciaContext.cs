using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MarienProject.Api.Models;

public partial class DbFarmaciaContext : DbContext
{
    public DbFarmaciaContext()
    {
    }

    public DbFarmaciaContext(DbContextOptions<DbFarmaciaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatAlmacen> CatAlmacens { get; set; }

    public virtual DbSet<CatEstante> CatEstantes { get; set; }

    public virtual DbSet<CatUbicacionAlmacen> CatUbicacionAlmacens { get; set; }

    public virtual DbSet<CatUbicacionEstante> CatUbicacionEstantes { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Conversion> Conversions { get; set; }

    public virtual DbSet<DetalleDeCompra> DetalleDeCompras { get; set; }

    public virtual DbSet<DetalleDeVentum> DetalleDeVenta { get; set; }

    public virtual DbSet<DetalleMedicamento> DetalleMedicamentos { get; set; }

    public virtual DbSet<DireccionCliente> DireccionClientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoFactura> EstadoFacturas { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<MedicamentoAlmacenado> MedicamentoAlmacenados { get; set; }

    public virtual DbSet<MedicamentoCategorium> MedicamentoCategoria { get; set; }

    public virtual DbSet<MedicamentoEnStock> MedicamentoEnStocks { get; set; }

    public virtual DbSet<MedicamentoLaboratorio> MedicamentoLaboratorios { get; set; }

    public virtual DbSet<MedicamentoNombreGenerico> MedicamentoNombreGenericos { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<MovimientoInterno> MovimientoInternos { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDeCambio> TipoDeCambios { get; set; }

    public virtual DbSet<TipoDeEntrega> TipoDeEntregas { get; set; }

    public virtual DbSet<UnidadDeMedidum> UnidadDeMedida { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatAlmacen>(entity =>
        {
            entity.HasKey(e => e.AlmacenId).HasName("PK__Cat_Alma__699F0D4E243987E8");

            entity.ToTable("Cat_Almacen");

            entity.Property(e => e.AlmacenId).HasColumnName("Almacen_Id");
            entity.Property(e => e.AlmacenEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Almacen_Estado");
            entity.Property(e => e.AlmacenNombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Almacen_Nombre");
        });

        modelBuilder.Entity<CatEstante>(entity =>
        {
            entity.HasKey(e => e.EstanteId).HasName("PK__Cat_Esta__1D1B57D235FD3E7B");

            entity.ToTable("Cat_Estante");

            entity.Property(e => e.EstanteId).HasColumnName("Estante_Id");
            entity.Property(e => e.EstanteEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Estante_Estado");
            entity.Property(e => e.EstanteNombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Estante_Nombre");
        });

        modelBuilder.Entity<CatUbicacionAlmacen>(entity =>
        {
            entity.HasKey(e => e.UbicacionId).HasName("PK__Cat_Ubic__AE1439F24D2BCD7C");

            entity.ToTable("Cat_Ubicacion_Almacen");

            entity.Property(e => e.UbicacionId).HasColumnName("Ubicacion_Id");
            entity.Property(e => e.UbicacionAlmacenId).HasColumnName("Ubicacion_Almacen_Id");
            entity.Property(e => e.UbicacionEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Ubicacion_Estado");
            entity.Property(e => e.UbicacionNombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Ubicacion_Nombre");

            entity.HasOne(d => d.UbicacionAlmacen).WithMany(p => p.CatUbicacionAlmacens)
                .HasForeignKey(d => d.UbicacionAlmacenId)
                .HasConstraintName("FK__Cat_Ubica__Ubica__403A8C7D");
        });

        modelBuilder.Entity<CatUbicacionEstante>(entity =>
        {
            entity.HasKey(e => e.UbicacionId).HasName("PK__Cat_Ubic__AE1439F2E0FFC41A");

            entity.ToTable("Cat_Ubicacion_Estante");

            entity.Property(e => e.UbicacionId).HasColumnName("Ubicacion_Id");
            entity.Property(e => e.UbicacionEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Ubicacion_Estado");
            entity.Property(e => e.UbicacionEstanteId).HasColumnName("Ubicacion_Estante_Id");
            entity.Property(e => e.UbicacionNombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Ubicacion_Nombre");

            entity.HasOne(d => d.UbicacionEstante).WithMany(p => p.CatUbicacionEstantes)
                .HasForeignKey(d => d.UbicacionEstanteId)
                .HasConstraintName("FK__Cat_Ubica__Ubica__46E78A0C");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("PK__Ciudad__82E38B292499E840");

            entity.ToTable("Ciudad");

            entity.Property(e => e.CiudadId).HasColumnName("Ciudad_Id");
            entity.Property(e => e.CiudadNombre)
                .HasMaxLength(150)
                .HasColumnName("Ciudad_Nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__EB683C5413FBA5C6");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.ClienteNombreUsuario, "UQ__Cliente__2F9DE54D17BA5CE9").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");
            entity.Property(e => e.ClienteApellidos)
                .HasMaxLength(50)
                .HasColumnName("Cliente_Apellidos");
            entity.Property(e => e.ClienteContraseña)
                .HasMaxLength(32)
                .HasColumnName("Cliente_Contraseña");
            entity.Property(e => e.ClienteCorreoElectronico)
                .HasMaxLength(120)
                .HasColumnName("Cliente_CorreoElectronico");
            entity.Property(e => e.ClienteEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Cliente_Estado");
            entity.Property(e => e.ClienteNombreUsuario)
                .HasMaxLength(30)
                .HasColumnName("Cliente_NombreUsuario");
            entity.Property(e => e.ClienteNombres)
                .HasMaxLength(50)
                .HasColumnName("Cliente_Nombres");
            entity.Property(e => e.ClienteTelefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cliente_Telefono");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CompraId).HasName("PK__Compra__BAE9515BEF8BB892");

            entity.ToTable("Compra");

            entity.Property(e => e.CompraId).HasColumnName("Compra_Id");
            entity.Property(e => e.CompraFechaEntrega)
                .HasColumnType("date")
                .HasColumnName("Compra_FechaEntrega");
            entity.Property(e => e.EstadoFacturaId).HasColumnName("EstadoFactura_Id");
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_Id");

            entity.HasOne(d => d.EstadoFactura).WithMany(p => p.Compras)
                .HasForeignKey(d => d.EstadoFacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__EstadoFa__628FA481");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__Proveedo__619B8048");
        });

        modelBuilder.Entity<Conversion>(entity =>
        {
            entity.HasKey(e => e.ConversionId).HasName("PK__Conversi__9CD2517FC45D7D98");

            entity.ToTable("Conversion");

            entity.Property(e => e.ConversionId).HasColumnName("Conversion_Id");
            entity.Property(e => e.ConversionDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Conversion_Descripcion");
            entity.Property(e => e.ConversionValor).HasColumnName("Conversion_Valor");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.UnidadDeMedidaId).HasColumnName("UnidadDeMedida_Id");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.UnidadDeMedida).WithMany(p => p.Conversions)
                .HasForeignKey(d => d.UnidadDeMedidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conversio__Unida__3A81B327");
        });

        modelBuilder.Entity<DetalleDeCompra>(entity =>
        {
            entity.HasKey(e => e.DetalleDeCompraId).HasName("PK__DetalleD__C22EE138F42E4130");

            entity.ToTable("DetalleDeCompra");

            entity.Property(e => e.DetalleDeCompraId).HasColumnName("DetalleDeCompra_Id");
            entity.Property(e => e.CompraId).HasColumnName("Compra_Id");
            entity.Property(e => e.DetalleDeCompraCantidad).HasColumnName("DetalleDeCompra_Cantidad");
            entity.Property(e => e.DetalleDeCompraDescuento).HasColumnName("DetalleDeCompra_Descuento");
            entity.Property(e => e.DetalleDeCompraIva).HasColumnName("DetalleDeCompra_Iva");
            entity.Property(e => e.DetalleDeCompraPrecio).HasColumnName("DetalleDeCompra_Precio");
            entity.Property(e => e.DetalleDeCompraSubtotal).HasColumnName("DetalleDeCompra_Subtotal");
            entity.Property(e => e.DetalleDeCompraTotal).HasColumnName("DetalleDeCompra_Total");
            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_Id");
            entity.Property(e => e.MedicamentoAlmacenadoId).HasColumnName("MedicamentoAlmacenado_Id");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleDeCompras)
                .HasForeignKey(d => d.CompraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleDe__Compr__656C112C");

            entity.HasOne(d => d.Empleado).WithMany(p => p.DetalleDeCompras)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleDe__Emple__6754599E");

            entity.HasOne(d => d.MedicamentoAlmacenado).WithMany(p => p.DetalleDeCompras)
                .HasForeignKey(d => d.MedicamentoAlmacenadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleDe__Medic__66603565");
        });

        modelBuilder.Entity<DetalleDeVentum>(entity =>
        {
            entity.HasKey(e => e.DetalleDeVentaId).HasName("PK__DetalleD__E009D77B9CF0C3B2");

            entity.Property(e => e.DetalleDeVentaId).HasColumnName("DetalleDeVenta_Id");
            entity.Property(e => e.DetalleDeVentaCantidad).HasColumnName("DetalleDeVenta_Cantidad");
            entity.Property(e => e.DetalleDeVentaDescuento).HasColumnName("DetalleDeVenta_Descuento");
            entity.Property(e => e.DetalleDeVentaIva).HasColumnName("DetalleDeVenta_Iva");
            entity.Property(e => e.DetalleDeVentaPrecio).HasColumnName("DetalleDeVenta_Precio");
            entity.Property(e => e.DetalleDeVentaSubtotal).HasColumnName("DetalleDeVenta_Subtotal");
            entity.Property(e => e.DetalleDeVentaTotal).HasColumnName("DetalleDeVenta_Total");
            entity.Property(e => e.MedicamentoEnStockId).HasColumnName("MedicamentoEnStock_Id");
            entity.Property(e => e.VentaId).HasColumnName("Venta_Id");

            entity.HasOne(d => d.MedicamentoEnStock).WithMany(p => p.DetalleDeVenta)
                .HasForeignKey(d => d.MedicamentoEnStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleDe__Medic__01142BA1");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleDeVenta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleDe__Venta__00200768");
        });

        modelBuilder.Entity<DetalleMedicamento>(entity =>
        {
            entity.HasKey(e => e.DetalleMedicamentoId).HasName("PK__DetalleM__59762A12D4E0FDC1");

            entity.ToTable("DetalleMedicamento");

            entity.Property(e => e.DetalleMedicamentoId).HasColumnName("DetalleMedicamento_Id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.DetalleMedicamentoDescripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DetalleMedicamentoEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DetalleMedicamento_Estado");
            entity.Property(e => e.DetalleMedicamentoPrescripcion).HasColumnType("date");
            entity.Property(e => e.MedicamentoId).HasColumnName("Medicamento_Id");
            entity.Property(e => e.MedicamentoLaboratorioId).HasColumnName("MedicamentoLaboratorio_Id");
            entity.Property(e => e.MedicamentoNombreGenericoId).HasColumnName("MedicamentoNombreGenerico_Id");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.Medicamento).WithMany(p => p.DetalleMedicamentos)
                .HasForeignKey(d => d.MedicamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleMe__Medic__300424B4");

            entity.HasOne(d => d.MedicamentoLaboratorio).WithMany(p => p.DetalleMedicamentos)
                .HasForeignKey(d => d.MedicamentoLaboratorioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleMe__Medic__30F848ED");

            entity.HasOne(d => d.MedicamentoNombreGenerico).WithMany(p => p.DetalleMedicamentos)
                .HasForeignKey(d => d.MedicamentoNombreGenericoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleMe__Medic__31EC6D26");
        });

        modelBuilder.Entity<DireccionCliente>(entity =>
        {
            entity.HasKey(e => e.DireccionClienteId).HasName("PK__Direccio__587FAD6A56A4A5FC");

            entity.ToTable("DireccionCliente");

            entity.Property(e => e.DireccionClienteId).HasColumnName("DireccionCliente_Id");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");
            entity.Property(e => e.DireccionClienteCodigoPostal)
                .HasMaxLength(10)
                .HasColumnName("DireccionCliente_CodigoPostal");
            entity.Property(e => e.DireccionClienteDireccion)
                .HasMaxLength(150)
                .HasColumnName("DireccionCliente_Direccion");
            entity.Property(e => e.DireccionClienteVivienda)
                .HasMaxLength(150)
                .HasColumnName("DireccionCliente_Vivienda");
            entity.Property(e => e.MunicipioId).HasColumnName("Municipio_Id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.DireccionClientes)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Direccion__Clien__03F0984C");

            entity.HasOne(d => d.Municipio).WithMany(p => p.DireccionClientes)
                .HasForeignKey(d => d.MunicipioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Direccion__Munic__04E4BC85");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__B71A1D6B41E649EA");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.EmpleadoNombreUsuario, "UQ__Empleado__4DEEA5220F76C273").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_Id");
            entity.Property(e => e.EmpleadoApellidos)
                .HasMaxLength(50)
                .HasColumnName("Empleado_Apellidos");
            entity.Property(e => e.EmpleadoContraseña)
                .HasMaxLength(32)
                .HasColumnName("Empleado_Contraseña");
            entity.Property(e => e.EmpleadoCorreoElectronico)
                .HasMaxLength(120)
                .HasColumnName("Empleado_CorreoElectronico");
            entity.Property(e => e.EmpleadoDni)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Empleado_Dni");
            entity.Property(e => e.EmpleadoEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Empleado_Estado");
            entity.Property(e => e.EmpleadoNombreUsuario)
                .HasMaxLength(30)
                .HasColumnName("Empleado_NombreUsuario");
            entity.Property(e => e.EmpleadoNombres)
                .HasMaxLength(50)
                .HasColumnName("Empleado_Nombres");
            entity.Property(e => e.EmpleadoTelefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Empleado_Telefono");
            entity.Property(e => e.RolId).HasColumnName("Rol_Id");

            entity.HasOne(d => d.Rol).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__Rol_Id__5BE2A6F2");
        });

        modelBuilder.Entity<EstadoFactura>(entity =>
        {
            entity.HasKey(e => e.EstadoFacturaId).HasName("PK__EstadoFa__182CB5E426253961");

            entity.ToTable("EstadoFactura");

            entity.Property(e => e.EstadoFacturaId).HasColumnName("EstadoFactura_Id");
            entity.Property(e => e.EstadoFacturaDescripcion)
                .HasMaxLength(150)
                .HasColumnName("EstadoFactura_Descripcion");
            entity.Property(e => e.EstadoFacturaEstado)
                .HasMaxLength(150)
                .HasColumnName("EstadoFactura_Estado");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.MedicamentoId).HasName("PK__Medicame__FC04EBA4AD16FF09");

            entity.ToTable("Medicamento");

            entity.Property(e => e.MedicamentoId).HasColumnName("Medicamento_Id");
            entity.Property(e => e.MedicamentoCategoriaId).HasColumnName("MedicamentoCategoria_Id");
            entity.Property(e => e.MedicamentoEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Medicamento_Estado");
            entity.Property(e => e.MedicamentoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medicamento_Nombre");

            entity.HasOne(d => d.MedicamentoCategoria).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.MedicamentoCategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicamen__Medic__276EDEB3");
        });

        modelBuilder.Entity<MedicamentoAlmacenado>(entity =>
        {
            entity.HasKey(e => e.MedicamentoAlmacenadoId).HasName("PK__Medicame__240700AE6E5CDF53");

            entity.ToTable("MedicamentoAlmacenado");

            entity.Property(e => e.MedicamentoAlmacenadoId).HasColumnName("MedicamentoAlmacenado_Id");
            entity.Property(e => e.AlmcUbicacionId).HasColumnName("Almc_UbicacionId");
            entity.Property(e => e.AlmcUnidadMedidaId).HasColumnName("Almc_UnidadMedidaId");
            entity.Property(e => e.DetalleMedicamentoId).HasColumnName("DetalleMedicamento_Id");
            entity.Property(e => e.MedicamentoAlmacenadoAdvertenciaDeVencimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MedicamentoAlmacenado_AdvertenciaDeVencimiento");
            entity.Property(e => e.MedicamentoAlmacenadoEstado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("((1))")
                .HasColumnName("MedicamentoAlmacenado_Estado");
            entity.Property(e => e.MedicamentoAlmacenadoExistencias).HasColumnName("MedicamentoAlmacenado_Existencias");
            entity.Property(e => e.MedicamentoAlmacenadoFechaDeExpedicion)
                .HasColumnType("date")
                .HasColumnName("MedicamentoAlmacenado_FechaDeExpedicion");
            entity.Property(e => e.MedicamentoAlmacenadoFechaDeVencimiento)
                .HasColumnType("date")
                .HasColumnName("MedicamentoAlmacenado_FechaDeVencimiento");
            entity.Property(e => e.MedicamentoAlmacenadoLote)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("MedicamentoAlmacenado_Lote");
            entity.Property(e => e.MedicamentoAlmacenadoPrecioDeCompra)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("MedicamentoAlmacenado_PrecioDeCompra");
            entity.Property(e => e.MedicamentoAlmacenadoPrecioDeVenta)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("MedicamentoAlmacenado_PrecioDeVenta");
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_Id");

            entity.HasOne(d => d.AlmcUbicacion).WithMany(p => p.MedicamentoAlmacenados)
                .HasForeignKey(d => d.AlmcUbicacionId)
                .HasConstraintName("FK__Medicamen__Almc___4D94879B");

            entity.HasOne(d => d.AlmcUnidadMedida).WithMany(p => p.MedicamentoAlmacenados)
                .HasForeignKey(d => d.AlmcUnidadMedidaId)
                .HasConstraintName("FK__Medicamen__Almc___4CA06362");

            entity.HasOne(d => d.DetalleMedicamento).WithMany(p => p.MedicamentoAlmacenados)
                .HasForeignKey(d => d.DetalleMedicamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicamen__Detal__4AB81AF0");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.MedicamentoAlmacenados)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicamen__Prove__4BAC3F29");
        });

        modelBuilder.Entity<MedicamentoCategorium>(entity =>
        {
            entity.HasKey(e => e.MedicamentoCategoriaId).HasName("PK__Medicame__DC4483601C72B520");

            entity.Property(e => e.MedicamentoCategoriaId).HasColumnName("MedicamentoCategoria_Id");
            entity.Property(e => e.MedicamentoCategoriaEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("MedicamentoCategoria_Estado");
            entity.Property(e => e.MedicamentoCategoriaNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MedicamentoCategoria_Nombre");
        });

        modelBuilder.Entity<MedicamentoEnStock>(entity =>
        {
            entity.HasKey(e => e.MedicamentoEnStockId).HasName("PK__Medicame__1E57A071FBD69F7A");

            entity.ToTable("MedicamentoEnStock");

            entity.Property(e => e.MedicamentoEnStockId).HasColumnName("MedicamentoEnStock_Id");
            entity.Property(e => e.MedicamentoAlmacenadoId).HasColumnName("MedicamentoAlmacenado_Id");
            entity.Property(e => e.MedicamentoEnStockExistencias).HasColumnName("MedicamentoEnStock_Existencias");
            entity.Property(e => e.MedicamentoEnStockPrecioDeVenta)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("MedicamentoEnStock_PrecioDeVenta");
            entity.Property(e => e.MovimientoInternoId).HasColumnName("MovimientoInterno_Id");
            entity.Property(e => e.StckUbicacionId).HasColumnName("Stck_UbicacionId");

            entity.HasOne(d => d.MedicamentoAlmacenado).WithMany(p => p.MedicamentoEnStocks)
                .HasForeignKey(d => d.MedicamentoAlmacenadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicamen__Medic__5441852A");

            entity.HasOne(d => d.MovimientoInterno).WithMany(p => p.MedicamentoEnStocks)
                .HasForeignKey(d => d.MovimientoInternoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicamen__Movim__5535A963");

            entity.HasOne(d => d.StckUbicacion).WithMany(p => p.MedicamentoEnStocks)
                .HasForeignKey(d => d.StckUbicacionId)
                .HasConstraintName("FK__Medicamen__Stck___5629CD9C");
        });

        modelBuilder.Entity<MedicamentoLaboratorio>(entity =>
        {
            entity.HasKey(e => e.MedicamentoLaboratorioId).HasName("PK__Medicame__D022680EB94B7EA5");

            entity.ToTable("MedicamentoLaboratorio");

            entity.Property(e => e.MedicamentoLaboratorioId)
                .ValueGeneratedNever()
                .HasColumnName("MedicamentoLaboratorio_Id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.MedicamentoLaboratorioEstado)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("((1))")
                .HasColumnName("MedicamentoLaboratorio_Estado");
            entity.Property(e => e.MedicamentoLaboratorioNombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("MedicamentoLaboratorio_Nombre");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");
        });

        modelBuilder.Entity<MedicamentoNombreGenerico>(entity =>
        {
            entity.HasKey(e => e.MedicamentoNombreGenericoId).HasName("PK__Medicame__D71060EDB8C83D77");

            entity.ToTable("MedicamentoNombreGenerico");

            entity.Property(e => e.MedicamentoNombreGenericoId).HasColumnName("MedicamentoNombreGenerico_Id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.MedicamentoNombreGenericoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MedicamentoNombreGenerico_Nombre");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.MonedaId).HasName("PK__Moneda__96CEDC03AE1985EF");

            entity.Property(e => e.MonedaId).HasColumnName("Moneda_Id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MovimientoInterno>(entity =>
        {
            entity.HasKey(e => e.MovimientoInternoId).HasName("PK__Movimien__E77A29965692AA21");

            entity.ToTable("MovimientoInterno");

            entity.Property(e => e.MovimientoInternoId).HasColumnName("MovimientoInterno_Id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.MedicamentoAlmacenadoId).HasColumnName("MedicamentoAlmacenado_Id");
            entity.Property(e => e.MovimientoInternoDescripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("MovimientoInterno_Descripcion");
            entity.Property(e => e.MovimientoInternoFecha)
                .HasColumnType("date")
                .HasColumnName("MovimientoInterno_Fecha");
            entity.Property(e => e.MovimientoInternoLote)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("MovimientoInterno_Lote");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.MedicamentoAlmacenado).WithMany(p => p.MovimientoInternos)
                .HasForeignKey(d => d.MedicamentoAlmacenadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Medic__5165187F");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.MunicipioId).HasName("PK__Municipi__44FEB619623C0199");

            entity.ToTable("Municipio");

            entity.Property(e => e.MunicipioId).HasColumnName("Municipio_Id");
            entity.Property(e => e.CiudadId).HasColumnName("Ciudad_Id");
            entity.Property(e => e.MunicipioNombre)
                .HasMaxLength(150)
                .HasColumnName("Municipio_Nombre");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Municipio__Ciuda__71D1E811");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__0790A3CB570623CA");

            entity.ToTable("Proveedor");

            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_Id");
            entity.Property(e => e.ProveedorDni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Proveedor_DNI");
            entity.Property(e => e.ProveedorEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Proveedor_Email");
            entity.Property(e => e.ProveedorEstado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Proveedor_Estado");
            entity.Property(e => e.ProveedorNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Proveedor_Nombre");
            entity.Property(e => e.ProveedorTelefono).HasColumnName("Proveedor_Telefono");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__795EBD4948916AA0");

            entity.ToTable("Rol");

            entity.Property(e => e.RolId).HasColumnName("Rol_Id");
            entity.Property(e => e.RolDescripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Rol_Descripcion");
            entity.Property(e => e.RolNombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Rol_Nombre");
        });

        modelBuilder.Entity<TipoDeCambio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TipoDeCambio");

            entity.Property(e => e.MonedaId).HasColumnName("Moneda_Id");
            entity.Property(e => e.TipoDeCambioFecha)
                .HasColumnType("date")
                .HasColumnName("TipoDeCambio_Fecha");
            entity.Property(e => e.TipoDeCambioValorCompra).HasColumnName("TipoDeCambio_ValorCompra");
            entity.Property(e => e.TipoDeCambioValorventa).HasColumnName("TipoDeCambio_Valorventa");

            entity.HasOne(d => d.Moneda).WithMany()
                .HasForeignKey(d => d.MonedaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoDeCam__Moned__75A278F5");
        });

        modelBuilder.Entity<TipoDeEntrega>(entity =>
        {
            entity.HasKey(e => e.TipoDeEntregaId).HasName("PK__TipoDeEn__DC5AAE901A30676E");

            entity.ToTable("TipoDeEntrega");

            entity.Property(e => e.TipoDeEntregaId).HasColumnName("TipoDeEntrega_Id");
            entity.Property(e => e.TipoDeEntregaDescripcion)
                .HasMaxLength(250)
                .HasColumnName("TipoDeEntrega_Descripcion");
            entity.Property(e => e.TipoDeEntregaTipoEntrega)
                .HasMaxLength(150)
                .HasColumnName("TipoDeEntrega_TipoEntrega");
        });

        modelBuilder.Entity<UnidadDeMedidum>(entity =>
        {
            entity.HasKey(e => e.UnidadDeMedidaId).HasName("PK__UnidadDe__C95BBE40F4E79EB8");

            entity.Property(e => e.UnidadDeMedidaId).HasColumnName("UnidadDeMedida_Id");
            entity.Property(e => e.UnidadDeMedidaNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UnidadDeMedida_Nombre");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Venta__24B17730E43C29D5");

            entity.Property(e => e.VentaId).HasColumnName("Venta_Id");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");
            entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_Id");
            entity.Property(e => e.EmpleadoIdRepartidor).HasColumnName("Empleado_IdRepartidor");
            entity.Property(e => e.EstadoFacturaId).HasColumnName("EstadoFactura_Id");
            entity.Property(e => e.MunicipioId).HasColumnName("Municipio_Id");
            entity.Property(e => e.TipoDeEntregaId).HasColumnName("TipoDeEntrega_Id");
            entity.Property(e => e.VentaCodigoPostal)
                .HasMaxLength(15)
                .HasColumnName("Venta_CodigoPostal");
            entity.Property(e => e.VentaDireccion).HasMaxLength(150);
            entity.Property(e => e.VentaFechaEntrega)
                .HasColumnType("date")
                .HasColumnName("Venta_FechaEntrega");
            entity.Property(e => e.VentaFechaEnvio).HasColumnType("date");
            entity.Property(e => e.VentaFechaPedido).HasColumnType("date");
            entity.Property(e => e.VentaNumeroTarjeta)
                .HasMaxLength(16)
                .HasColumnName("Venta_NumeroTarjeta");
            entity.Property(e => e.VentaVivienda)
                .HasMaxLength(30)
                .HasColumnName("Venta_Vivienda");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__Cliente_I__787EE5A0");

            entity.HasOne(d => d.Empleado).WithMany(p => p.VentumEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Venta__Empleado___7B5B524B");

            entity.HasOne(d => d.EmpleadoIdRepartidorNavigation).WithMany(p => p.VentumEmpleadoIdRepartidorNavigations)
                .HasForeignKey(d => d.EmpleadoIdRepartidor)
                .HasConstraintName("FK__Venta__Empleado___7C4F7684");

            entity.HasOne(d => d.EstadoFactura).WithMany(p => p.Venta)
                .HasForeignKey(d => d.EstadoFacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__EstadoFac__797309D9");

            entity.HasOne(d => d.Municipio).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MunicipioId)
                .HasConstraintName("FK__Venta__Municipio__7D439ABD");

            entity.HasOne(d => d.TipoDeEntrega).WithMany(p => p.Venta)
                .HasForeignKey(d => d.TipoDeEntregaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__TipoDeEnt__7A672E12");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
