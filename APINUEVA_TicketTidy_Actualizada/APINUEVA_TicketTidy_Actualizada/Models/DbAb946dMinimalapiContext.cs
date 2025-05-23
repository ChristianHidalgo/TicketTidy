using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APINUEVA_TicketTidy_Actualizada.Models;

public partial class DbAb946dMinimalapiContext : DbContext
{
    public DbAb946dMinimalapiContext()
    {
    }

    public DbAb946dMinimalapiContext(DbContextOptions<DbAb946dMinimalapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<Dium> Dia { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EnfermedadesIntervencionesPersona> EnfermedadesIntervencionesPersonas { get; set; }

    public virtual DbSet<Espacio> Espacios { get; set; }

    public virtual DbSet<ExpedienteVacunacion> ExpedienteVacunacions { get; set; }

    public virtual DbSet<FichaMedica> FichaMedicas { get; set; }

    public virtual DbSet<Gestor> Gestors { get; set; }

    public virtual DbSet<GrupoSanguineo> GrupoSanguineos { get; set; }

    public virtual DbSet<Hora> Horas { get; set; }

    public virtual DbSet<HoraDiaActividadPersona> HoraDiaActividadPersonas { get; set; }

    public virtual DbSet<Incidencium> Incidencia { get; set; }

    public virtual DbSet<MarcaVacuna> MarcaVacunas { get; set; }

    public virtual DbSet<MedicamentoConsumoPersona> MedicamentoConsumoPersonas { get; set; }

    public virtual DbSet<MedicoTelefonoPersona> MedicoTelefonoPersonas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuTipoUsuario> MenuTipoUsuarios { get; set; }

    public virtual DbSet<ObservacionesPersona> ObservacionesPersonas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<SistemaSalud> SistemaSaluds { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    public virtual DbSet<TipoAlergium> TipoAlergia { get; set; }

    public virtual DbSet<TipoDocumentoIdentificacion> TipoDocumentoIdentificacions { get; set; }

    public virtual DbSet<Tipousuario> Tipousuarios { get; set; }

    public virtual DbSet<TratamientoMedicoPersona> TratamientoMedicoPersonas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuariobasico> Usuariobasicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql1003.site4now.net;Database=db_ab946d_minimalapi;User=db_ab946d_minimalapi_admin;Password=Sporting24;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83F7A52AF65");

            entity.ToTable("administrador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Iidalumno).HasName("PK__Alumno__235366ED63AB916A");

            entity.ToTable("Alumno");

            entity.Property(e => e.Iidalumno).HasColumnName("IIDALUMNO");
            entity.Property(e => e.Apmaterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APMATERNO");
            entity.Property(e => e.Appaterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APPATERNO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Fechanacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IidsexoNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.Iidsexo)
                .HasConstraintName("FK__Alumno__IIDSEXO__46B27FE2");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Iidcategoria).HasName("PK__Categori__B57A3B9FC6090144");

            entity.Property(e => e.Iidcategoria).HasColumnName("IIDCATEGORIA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcioncategoria)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCIONCATEGORIA");
            entity.Property(e => e.Imagen).HasColumnName("IMAGEN");
            entity.Property(e => e.Nombrecategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRECATEGORIA");
            entity.Property(e => e.Nombreimagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREIMAGEN");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Iidcliente).HasName("PK_Compañia");

            entity.ToTable("Cliente");

            entity.Property(e => e.Iidcliente).HasColumnName("IIDCLIENTE");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CIUDAD");
            entity.Property(e => e.Codigopostal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CODIGOPOSTAL");
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombrecompañia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRECOMPAÑIA");
            entity.Property(e => e.Personaafacturar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PERSONAAFACTURAR");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.Iiddetallepedido).HasName("PK__DetalleP__6189D32AA2B26C64");

            entity.ToTable("DetallePedido");

            entity.Property(e => e.Iiddetallepedido).HasColumnName("IIDDETALLEPEDIDO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Iidpedido).HasColumnName("IIDPEDIDO");
            entity.Property(e => e.Iidproducto).HasColumnName("IIDPRODUCTO");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IidpedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.Iidpedido)
                .HasConstraintName("FK__DetallePe__IIDPE__42E1EEFE");

            entity.HasOne(d => d.IidproductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.Iidproducto)
                .HasConstraintName("FK__DetallePe__IIDPR__43D61337");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__disposit__3213E83FDC7B33EC");

            entity.ToTable("dispositivo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .HasColumnName("modelo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Dium>(entity =>
        {
            entity.HasKey(e => e.Iiddia);

            entity.Property(e => e.Iiddia).HasColumnName("IIDDIA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombredia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREDIA");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Iidempleado).HasName("PK_Persona");

            entity.ToTable("Empleado");

            entity.Property(e => e.Iidempleado).HasColumnName("IIDEMPLEADO");
            entity.Property(e => e.Apmaterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APMATERNO");
            entity.Property(e => e.Appaterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APPATERNO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CALLE");
            entity.Property(e => e.Colonia)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COLONIA");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Cp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.Estadopais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOPAIS");
            entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");
            entity.Property(e => e.Iidtipodocumento).HasColumnName("IIDTIPODOCUMENTO");
            entity.Property(e => e.Municipiopais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUNICIPIOPAIS");
            entity.Property(e => e.Nexterior)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NEXTERIOR");
            entity.Property(e => e.Ninterior)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NINTERIOR");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Nombrefoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBREFOTO");
            entity.Property(e => e.Numeroidentificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NUMEROIDENTIFICACION");
            entity.Property(e => e.Numeroregistrounicocontribuyente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NUMEROREGISTROUNICOCONTRIBUYENTE");
            entity.Property(e => e.Telefonoocelular1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONOOCELULAR1");
            entity.Property(e => e.Telefonoocelular2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONOOCELULAR2");

            entity.HasOne(d => d.IidsexoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Iidsexo)
                .HasConstraintName("FK_Persona_Sexo1");

            entity.HasOne(d => d.IidtipodocumentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Iidtipodocumento)
                .HasConstraintName("FK_Persona_Sexo");
        });

        modelBuilder.Entity<EnfermedadesIntervencionesPersona>(entity =>
        {
            entity.HasKey(e => e.Iidenfermedadesintervenciones).HasName("PK_EnfermedadesIntervenciones");

            entity.ToTable("EnfermedadesIntervencionesPersona");

            entity.Property(e => e.Iidenfermedadesintervenciones).HasColumnName("IIDENFERMEDADESINTERVENCIONES");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.EnfermedadesIntervencionesPersonas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_EnfermedadesIntervencionesPersona_EnfermedadesIntervencionesPersona");
        });

        modelBuilder.Entity<Espacio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__espacio__3213E83FA7C5B409");

            entity.ToTable("espacio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<ExpedienteVacunacion>(entity =>
        {
            entity.HasKey(e => e.Iidexpedientevacunacion);

            entity.ToTable("ExpedienteVacunacion");

            entity.Property(e => e.Iidexpedientevacunacion).HasColumnName("IIDEXPEDIENTEVACUNACION");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Diabetes).HasColumnName("DIABETES");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Fechavacunacion).HasColumnName("FECHAVACUNACION");
            entity.Property(e => e.Hipertencion).HasColumnName("HIPERTENCION");
            entity.Property(e => e.Iidmarcavacuna).HasColumnName("IIDMARCAVACUNA");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Lotevacuna).HasColumnName("LOTEVACUNA");
            entity.Property(e => e.Numerodosis).HasColumnName("NUMERODOSIS");
            entity.Property(e => e.Otropadecimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OTROPADECIMIENTO");

            entity.HasOne(d => d.IidmarcavacunaNavigation).WithMany(p => p.ExpedienteVacunacions)
                .HasForeignKey(d => d.Iidmarcavacuna)
                .HasConstraintName("FK_ExpedienteVacunacion_MarcaVacuna");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.ExpedienteVacunacions)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_ExpedienteVacunacion_Persona");
        });

        modelBuilder.Entity<FichaMedica>(entity =>
        {
            entity.HasKey(e => e.Iidfichamedica);

            entity.ToTable("FichaMedica");

            entity.Property(e => e.Iidfichamedica).HasColumnName("IIDFICHAMEDICA");
            entity.Property(e => e.Descripcionalergia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCIONALERGIA");
            entity.Property(e => e.Enfermedadcronica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENFERMEDADCRONICA");
            entity.Property(e => e.Iidgruposanguineo).HasColumnName("IIDGRUPOSANGUINEO");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Iidsistemasalud).HasColumnName("IIDSISTEMASALUD");
            entity.Property(e => e.Iidtipoalergia).HasColumnName("IIDTIPOALERGIA");
            entity.Property(e => e.Medicoatiende)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MEDICOATIENDE");
            entity.Property(e => e.Nombresistemasalud)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRESISTEMASALUD");

            entity.HasOne(d => d.IidgruposanguineoNavigation).WithMany(p => p.FichaMedicas)
                .HasForeignKey(d => d.Iidgruposanguineo)
                .HasConstraintName("FK_FichaMedica_GrupoSanguineo");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.FichaMedicas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_FichaMedica_Persona");

            entity.HasOne(d => d.IidsistemasaludNavigation).WithMany(p => p.FichaMedicas)
                .HasForeignKey(d => d.Iidsistemasalud)
                .HasConstraintName("FK_FichaMedica_SistemaSalud");

            entity.HasOne(d => d.IidtipoalergiaNavigation).WithMany(p => p.FichaMedicas)
                .HasForeignKey(d => d.Iidtipoalergia)
                .HasConstraintName("FK_FichaMedica_TipoAlergia");
        });

        modelBuilder.Entity<Gestor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gestor__3213E83FD5B61538");

            entity.ToTable("gestor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<GrupoSanguineo>(entity =>
        {
            entity.HasKey(e => e.Iidgruposanguineo);

            entity.ToTable("GrupoSanguineo");

            entity.Property(e => e.Iidgruposanguineo).HasColumnName("IIDGRUPOSANGUINEO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombresanguineo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRESANGUINEO");
        });

        modelBuilder.Entity<Hora>(entity =>
        {
            entity.HasKey(e => e.Iidhora).HasName("PK_Horass");

            entity.ToTable("Hora");

            entity.Property(e => e.Iidhora).HasColumnName("IIDHORA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Hora1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HORA");
        });

        modelBuilder.Entity<HoraDiaActividadPersona>(entity =>
        {
            entity.HasKey(e => e.Iidhoradiaactividadpersona);

            entity.ToTable("HoraDiaActividadPersona");

            entity.Property(e => e.Iidhoradiaactividadpersona).HasColumnName("IIDHORADIAACTIVIDADPERSONA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Iiddia).HasColumnName("IIDDIA");
            entity.Property(e => e.Iidhora).HasColumnName("IIDHORA");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Nombreactividad)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBREACTIVIDAD");

            entity.HasOne(d => d.IiddiaNavigation).WithMany(p => p.HoraDiaActividadPersonas)
                .HasForeignKey(d => d.Iiddia)
                .HasConstraintName("FK_HoraDiaActividadPersona_Dia");

            entity.HasOne(d => d.IidhoraNavigation).WithMany(p => p.HoraDiaActividadPersonas)
                .HasForeignKey(d => d.Iidhora)
                .HasConstraintName("FK_HoraDiaActividadPersona_Hora");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.HoraDiaActividadPersonas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_HoraDiaActividadPersona_Persona");
        });

        modelBuilder.Entity<Incidencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__incidenc__3213E83FAE37C3CF");

            entity.ToTable("incidencia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescripcionDeLaIncidencia)
                .HasMaxLength(255)
                .HasColumnName("Descripcion de la incidencia");
            entity.Property(e => e.DescripcionDeLaSolución)
                .HasMaxLength(255)
                .HasColumnName("Descripcion de la solución");
            entity.Property(e => e.DispositivoId).HasColumnName("dispositivo_id");
            entity.Property(e => e.EspacioId).HasColumnName("espacio_id");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaDeApertura).HasColumnName("Fecha de Apertura");
            entity.Property(e => e.FechaDeCierre).HasColumnName("Fecha de Cierre");
            entity.Property(e => e.GestorId).HasColumnName("gestor_id");
            entity.Property(e => e.TecnicoId).HasColumnName("tecnico_id");
            entity.Property(e => e.TipoDeIncidencia)
                .HasMaxLength(255)
                .HasColumnName("Tipo de Incidencia");
            entity.Property(e => e.UBasicoId).HasColumnName("uBasico_id");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("FK__incidenci__dispo__15DA3E5D");

            entity.HasOne(d => d.Espacio).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.EspacioId)
                .HasConstraintName("FK__incidenci__espac__16CE6296");

            entity.HasOne(d => d.Gestor).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.GestorId)
                .HasConstraintName("FK__incidenci__gesto__17C286CF");

            entity.HasOne(d => d.Tecnico).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.TecnicoId)
                .HasConstraintName("FK__incidenci__tecni__18B6AB08");

            entity.HasOne(d => d.UBasico).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.UBasicoId)
                .HasConstraintName("FK__incidenci__uBasi__19AACF41");
        });

        modelBuilder.Entity<MarcaVacuna>(entity =>
        {
            entity.HasKey(e => e.Iidmarcavacuna);

            entity.ToTable("MarcaVacuna");

            entity.Property(e => e.Iidmarcavacuna).HasColumnName("IIDMARCAVACUNA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombremarca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREMARCA");
        });

        modelBuilder.Entity<MedicamentoConsumoPersona>(entity =>
        {
            entity.HasKey(e => e.Iidmedicamentoconsumopersona);

            entity.ToTable("MedicamentoConsumoPersona");

            entity.Property(e => e.Iidmedicamentoconsumopersona).HasColumnName("IIDMEDICAMENTOCONSUMOPERSONA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.MedicamentoConsumoPersonas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_MedicamentoConsumoPersona_Persona");
        });

        modelBuilder.Entity<MedicoTelefonoPersona>(entity =>
        {
            entity.HasKey(e => e.Iidmedicotelefono);

            entity.ToTable("MedicoTelefonoPersona");

            entity.HasIndex(e => e.Iidmedicotelefono, "IX_MedicoTelefonoPersona");

            entity.Property(e => e.Iidmedicotelefono).HasColumnName("IIDMEDICOTELEFONO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Numerotelefonicomedico)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NUMEROTELEFONICOMEDICO");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.MedicoTelefonoPersonas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_MedicoTelefonoPersona_Persona");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Iidmenu).HasName("PK__Menu__0B6B841AEFE5D2BB");

            entity.ToTable("Menu");

            entity.Property(e => e.Iidmenu).HasColumnName("iidmenu");
            entity.Property(e => e.Bhabilitado).HasColumnName("bhabilitado");
            entity.Property(e => e.Nombreicono)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreicono");
            entity.Property(e => e.Nombreopcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreopcion");
        });

        modelBuilder.Entity<MenuTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Iidmenutipousuario).HasName("PK__MenuTipo__5DD77EAC950A90AE");

            entity.ToTable("MenuTipoUsuario");

            entity.Property(e => e.Iidmenutipousuario).HasColumnName("iidmenutipousuario");
            entity.Property(e => e.Bhabilitado).HasColumnName("bhabilitado");
            entity.Property(e => e.Iidmenu).HasColumnName("iidmenu");
            entity.Property(e => e.Iidtipousuario).HasColumnName("iidtipousuario");

            entity.HasOne(d => d.IidmenuNavigation).WithMany(p => p.MenuTipoUsuarios)
                .HasForeignKey(d => d.Iidmenu)
                .HasConstraintName("FK__MenuTipoU__iidme__73852659");

            entity.HasOne(d => d.IidtipousuarioNavigation).WithMany(p => p.MenuTipoUsuarios)
                .HasForeignKey(d => d.Iidtipousuario)
                .HasConstraintName("FK__MenuTipoU__iidti__74794A92");
        });

        modelBuilder.Entity<ObservacionesPersona>(entity =>
        {
            entity.HasKey(e => e.Iidobservacionespersona);

            entity.ToTable("ObservacionesPersona");

            entity.Property(e => e.Iidobservacionespersona).HasColumnName("IIDOBSERVACIONESPERSONA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.ObservacionesPersonas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_ObservacionesPersona_Persona");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Iidpago).HasName("PK__Pago__09288D6BF71C9312");

            entity.ToTable("Pago");

            entity.Property(e => e.Iidpago).HasColumnName("IIDPAGO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Iidalumno).HasColumnName("IIDALUMNO");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO");

            entity.HasOne(d => d.IidalumnoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Iidalumno)
                .HasConstraintName("FK__Pago__IIDALUMNO__498EEC8D");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Iidpedido).HasName("PK__Pedido__E7B677004C86A7C3");

            entity.ToTable("Pedido");

            entity.Property(e => e.Iidpedido).HasColumnName("IIDPEDIDO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Fechaorden)
                .HasColumnType("datetime")
                .HasColumnName("FECHAORDEN");
            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");
            entity.Property(e => e.Precioorden)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIOORDEN");

            entity.HasOne(d => d.IidusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Iidusuario)
                .HasConstraintName("FK_Pedido_Usuario");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Iidproducto);

            entity.ToTable("Producto");

            entity.Property(e => e.Iidproducto).HasColumnName("IIDPRODUCTO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Iidcategoria).HasColumnName("IIDCATEGORIA");
            entity.Property(e => e.Imagen).HasColumnName("IMAGEN");
            entity.Property(e => e.Nombreimagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREIMAGEN");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");

            entity.HasOne(d => d.IidcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Iidcategoria)
                .HasConstraintName("FK__Producto__IIDCAT__4C6B5938");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Iidsexo);

            entity.ToTable("Sexo");

            entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<SistemaSalud>(entity =>
        {
            entity.HasKey(e => e.Iidsistemasalud);

            entity.ToTable("SistemaSalud");

            entity.Property(e => e.Iidsistemasalud).HasColumnName("IIDSISTEMASALUD");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tecnico__3213E83F57EC83C9");

            entity.ToTable("tecnico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TipoAlergium>(entity =>
        {
            entity.HasKey(e => e.Iidtipoalergia);

            entity.Property(e => e.Iidtipoalergia).HasColumnName("IIDTIPOALERGIA");
            entity.Property(e => e.Bhabilitado)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombretipoalergia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRETIPOALERGIA");
        });

        modelBuilder.Entity<TipoDocumentoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.Iidtipodocumento);

            entity.ToTable("TipoDocumentoIdentificacion");

            entity.Property(e => e.Iidtipodocumento).HasColumnName("IIDTIPODOCUMENTO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tipousuario>(entity =>
        {
            entity.HasKey(e => e.Iidtipousuario).HasName("PK__Tipousua__A05A9116FE569626");

            entity.ToTable("Tipousuario");

            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombretipousuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRETIPOUSUARIO");
        });

        modelBuilder.Entity<TratamientoMedicoPersona>(entity =>
        {
            entity.HasKey(e => e.Iidtratamientomedicopersona);

            entity.ToTable("TratamientoMedicoPersona");

            entity.Property(e => e.Iidtratamientomedicopersona).HasColumnName("IIDTRATAMIENTOMEDICOPERSONA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.TratamientoMedicoPersonas)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_TratamientoMedicoPersona_Persona");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iidusuario).HasName("PK__Usuario__26DBFF59705207FE");

            entity.ToTable("Usuario");

            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Contra)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CONTRA");
            entity.Property(e => e.Iidcliente).HasColumnName("IIDCLIENTE");
            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBREUSUARIO");

            entity.HasOne(d => d.IidclienteNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Iidcliente)
                .HasConstraintName("FK__Usuario__IIDCLIE__5CA1C101");

            entity.HasOne(d => d.IidtipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Iidtipousuario)
                .HasConstraintName("FK__Usuario__IIDTIPO__5D95E53A");
        });

        modelBuilder.Entity<Usuariobasico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuariob__3213E83FA87987EE");

            entity.ToTable("usuariobasico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
