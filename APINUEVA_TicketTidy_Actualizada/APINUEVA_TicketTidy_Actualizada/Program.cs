
using APINUEVA_TicketTidy_Actualizada.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();



app.MapGet("/loginTecnico/{user}/{psw}", (string user, string psw) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var tecnicos = db.Tecnicos.Where(o => o.NombreUsuario.ToUpper() == user.ToUpper() &&
        o.Contraseña == psw).FirstOrDefault();


        if (tecnicos != null)
        {
            return Results.Ok(tecnicos);

        }
        else
            return Results.Problem("No se encontró el usuario");
    }
});

app.MapGet("/loginGestor/{user}/{psw}", (string user, string psw) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {


        var gestores = db.Gestors.Where(o => o.NombreUsuario.ToUpper() == user.ToUpper() &&
        o.Contraseña == psw).FirstOrDefault();

        if (gestores != null)
        {
            return Results.Ok(gestores);

        }


        else
            return Results.Problem("No se encontró el usuario");
    }
});

app.MapGet("/getAdmins", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var administrador = db.Administradors.ToList();
        if (administrador != null)
        {
            return Results.Ok(administrador);

        }


        else
            return Results.Problem("No hay administradores disponibles");
    }
});

app.MapGet("/loginAdmin/{user}/{psw}", (string user, string psw) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {


        var admin = db.Administradors.Where(o => o.NombreUsuario.ToUpper() == user.ToUpper() &&
        o.Contraseña == psw).FirstOrDefault();

        if (admin != null)
        {
            return Results.Ok(admin);

        }


        else
            return Results.Problem("No se encontró el usuario");
    }
});

app.MapGet("/loginBasico/{user}/{psw}", (string user, string psw) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {


        var basico = db.Usuariobasicos.Where(o => o.NombreUsuario.ToUpper() == user.ToUpper() &&
        o.Contraseña == psw).FirstOrDefault();

        if (basico != null)
        {
            return Results.Ok(basico);

        }


        else
            return Results.Problem("No se encontró el usuario");
    }
});

app.MapGet("/usuarios", () =>
{

    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        return db.Tecnicos.ToList();
    }
});

app.MapGet("/incidencias", () =>
{

    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        return db.Incidencia.ToList();
    }
});

//APIS DE TÉCNICO
app.MapGet("/getTecnico/{id}", (int idtecnico) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var tecnico = db.Tecnicos.Where(o => o.Id == idtecnico).FirstOrDefault();
        if (tecnico != null)
        {
            return Results.Ok(tecnico);

        }


        else
            return Results.Problem("No se encontró el usuario");
    }
});
app.MapGet("/getAdminById/{id}", (int idAdmin) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var admin = db.Administradors.Where(o => o.Id == idAdmin).FirstOrDefault();
        if (admin != null)
        {
            return Results.Ok(admin);
        }
        else
        {
            return Results.Problem("No se encontró el administrador");
        }
    }
});


app.MapGet("/getIncidenciasByTecnico/{id}", (int idtecnico) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia.Where(o => o.TecnicoId == idtecnico && o.Estado == "Asignada").ToList();
        if (incidencias.Count() > 0)
        {
            return Results.Ok(incidencias);

        }


        else
            return Results.Problem("No hay incidencias asignadas a este técnico");
    }
});

app.MapGet("/getIncidenciasTotalesByTecnico/{id}", (int idtecnico) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia.Where(o => o.TecnicoId == idtecnico).ToList();
        if (incidencias.Count() > 0)
        {
            return Results.Ok(incidencias);

        }


        else
            return Results.Problem("No hay incidencias asignadas a este técnico");
    }
});

app.MapGet("/getIncidenciasById/{id}", (int idIncidencia) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia.Where(o => o.Id == idIncidencia).FirstOrDefault();
        if (incidencias != null)
        {
            return Results.Ok(incidencias);

        }


        else
            return Results.Problem("No hay incidencias con ese id");
    }
});


//ESTA API SOLO MODIFICA EL ESTADO DE LA INCIDENCIA, PARA SOLO GUARDAR INCIDENCIAS ES LA "/saveIncidenciaNueva"
app.MapPost("/saveIncidencia", (Incidencium incidencia) =>
{
    try
    {
        using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
        {
            // Verificar si la incidencia existe en la base de datos
            var existingIncidencia = db.Incidencia.Find(incidencia.Id);

            // Si no existe, retornamos un error
            if (existingIncidencia == null)
            {
                return Results.NotFound("La incidencia no existe.");
            }

            // Si existe, actualizamos los valores
            db.Entry(existingIncidencia).CurrentValues.SetValues(incidencia);
            db.SaveChanges();
            return Results.Ok(1);
        }
    }
    catch (Exception e)
    {
        return Results.Problem($"Ocurrió un error: {e.Message}");
    }
});

app.MapGet("/getIncidenciasByTipoTecnico/{tipo}", (string tipo) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia.Where(o => o.TipoDeIncidencia == tipo).ToList();
        if (incidencias.Count() > 0)
        {
            return Results.Ok(incidencias);

        }


        else
            return Results.Problem("No hay incidencias de este tipo");
    }
});


app.MapGet("/getIncidenciasByFechaApertura/{fecha1}/{fecha2}", (DateOnly fecha1, DateOnly fecha2) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia
                            .Where(o => o.FechaDeApertura >= fecha1 && o.FechaDeApertura <= fecha2)
                            .ToList();

        if (incidencias.Count > 0)
        {
            return Results.Ok(incidencias);
        }
        else
        {
            return Results.Problem("No hay incidencias dentro de este rango de fechas");
        }
    }
});

app.MapGet("/getBasicoById/{id}", (int idBasico) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var tecnico = db.Usuariobasicos.Where(o => o.Id == idBasico).FirstOrDefault();
        if (tecnico != null)
        {
            return Results.Ok(tecnico);

        }


        else
            return Results.Problem("No se encontró el usuario");
    }
});

//APIS GESTOR

app.MapGet("/getGestor/{id}", (int idGestor) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var gestor = db.Gestors.Where(o => o.Id == idGestor).FirstOrDefault();
        if (gestor != null)
        {
            return Results.Ok(gestor);

        }


        else
            return Results.Problem("No se encontró el usuario");
    }
});

app.MapGet("/getDispositivos", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var dispositivos = db.Dispositivos.ToList();
        if (dispositivos != null)
        {
            return Results.Ok(dispositivos);

        }


        else
            return Results.Problem("No hay dispositivos disponibles");
    }
});

app.MapGet("/getEspacios", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var espacios = db.Espacios.ToList();
        if (espacios != null)
        {
            return Results.Ok(espacios);

        }


        else
            return Results.Problem("No hay espacios disponibles");
    }
});

app.MapPost("/saveIncidenciaNueva", (Incidencium incidencia) =>
{
    try
    {
        using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
        {
            // Agregar la nueva incidencia en lugar de buscarla por Id
            db.Incidencia.Add(incidencia);  // Esto agrega la incidencia a la base de datos

            // Guardar los cambios
            db.SaveChanges();

            // Retorna el Id de la nueva incidencia que se creó
            return Results.Ok(1);
        }
    }
    catch (Exception e)
    {
        return Results.Problem($"Ocurrió un error: {e.Message}");
    }
});

app.MapGet("/getIncidenciasSinAsignar", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia.Where(o => o.Estado == "Alta").ToList();
        if (incidencias.Count() > 0)
        {
            return Results.Ok(incidencias);

        }


        else
            return Results.Problem("No hay incidencias asignadas a este técnico");
    }
});

app.MapGet("/getTecnicos", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var tecnicos = db.Tecnicos.ToList();
        if (tecnicos != null)
        {
            return Results.Ok(tecnicos);

        }


        else
            return Results.Problem("No hay técnicos disponibles");
    }
});

app.MapGet("/getGestores", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var gestores = db.Gestors.ToList();
        if (gestores != null)
        {
            return Results.Ok(gestores);

        }


        else
            return Results.Problem("No hay gestores disponibles");
    }
});

app.MapGet("/getBasicos", () =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var basicos = db.Usuariobasicos.ToList();
        if (basicos != null)
        {
            return Results.Ok(basicos);

        }


        else
            return Results.Problem("No hay usuarios básicos disponibles");
    }
});
app.MapGet("/getDispositivoById/{id}", (int idDis) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var dis = db.Dispositivos.Where(o => o.Id == idDis).FirstOrDefault();
        if (dis != null)
        {
            return Results.Ok(dis);

        }


        else
            return Results.Problem("No se encontró el dispositivo");
    }
});

app.MapGet("/getEspacioById/{id}", (int idEsp) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var esp = db.Espacios.Where(o => o.Id == idEsp).FirstOrDefault();
        if (esp != null)
        {
            return Results.Ok(esp);

        }


        else
            return Results.Problem("No se encontró el espacio");
    }
});

app.MapGet("/getTecnicoByName/{name}", (string name) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var tec = db.Tecnicos.Where(o => o.NombreUsuario.Trim() == name.Trim()).FirstOrDefault();
        if (tec != null)
        {
            return Results.Ok(tec.Id);

        }


        else
            return Results.Problem("No se encontró el técnico");
    }
});

app.MapGet("/getGestorByName/{name}", (string name) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var ges = db.Gestors.Where(o => o.NombreUsuario.Trim() == name.Trim()).FirstOrDefault();
        if (ges != null)
        {
            return Results.Ok(ges.Id);
        }

        else
            return Results.Problem("No se encontró el gestor");
    }
});

app.MapGet("/getBasicoByName/{name}", (string name) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var bas = db.Usuariobasicos.Where(o => o.NombreUsuario.Trim() == name.Trim()).FirstOrDefault();
        if (bas != null)
        {
            return Results.Ok(bas.Id);
        }
        else
            return Results.Problem("No se encontró el técnico");
    }
});
app.MapGet("/getIncidenciasByBasico/{id}", (int idBasico) =>
{
    using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
    {
        var incidencias = db.Incidencia
            .Where(o => o.UBasicoId == idBasico)
            .ToList();

        if (incidencias.Count > 0)
        {
            return Results.Ok(incidencias);
        }
        else
        {
            return Results.Problem("No hay incidencias creadas por este usuario básico");
        }
    }
});

app.MapGet("/listarIncidenciasCerradas", (long idUsuario) =>
{
    try
    {
        using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
        {
            var incidenciasCerradas = db.Incidencia
                .Where(i => i.UBasicoId == idUsuario && i.Estado == "Cerrada")
                .ToList();

            return Results.Ok(incidenciasCerradas);
        }
    }
    catch (Exception e)
    {
        return Results.Problem($"Ocurrió un error: {e.Message}");
    }
});

app.MapPost("/reabrirIncidencia", (long idIncidencia) =>
{
    try
    {
        using (DbAb946dMinimalapiContext db = new DbAb946dMinimalapiContext())
        {
            var incidencia = db.Incidencia.Find(idIncidencia);

            if (incidencia == null)
            {
                return Results.NotFound("La incidencia no existe.");
            }

            incidencia.Estado = "Reabierta";

            db.SaveChanges();

            return Results.Ok("Incidencia reabierta correctamente.");
        }
    }
    catch (Exception e)
    {
        return Results.Problem($"Ocurrió un error: {e.Message}");
    }
});
app.MapPost("/crearEspacio", async (Espacio espacio) =>
    {
        try
        {
            if (espacio == null)
                return Results.BadRequest("El objeto espacio es nulo.");

            await using var db = new DbAb946dMinimalapiContext();

            db.Espacios.Add(espacio);
            await db.SaveChangesAsync();

            return Results.Ok(new { mensaje = "Espacio creado correctamente", id = espacio.Id });
        }
        catch (Exception e)
        {
            return Results.Problem($"Ocurrió un error: {e.Message}");
        }
    });
    app.MapPost("/crearDispositivo", async (Dispositivo dispositivo) =>
    {
        try
        {
            if (dispositivo == null)
                return Results.BadRequest("El objeto dispositivo es nulo.");

            await using var db = new DbAb946dMinimalapiContext();

            db.Dispositivos.Add(dispositivo);
            await db.SaveChangesAsync();

            return Results.Ok(new { mensaje = "Dispositivo creado correctamente", id = dispositivo.Id });
        }
        catch (Exception e)
        {
            return Results.Problem($"Ocurrió un error: {e.Message}");
        }
    });

app.MapPost("/crearUsuarioBasico", async (Usuariobasico usuario) =>
{
    try
    {
        if (usuario == null)
            return Results.BadRequest("El objeto es nulo.");

        await using var db = new DbAb946dMinimalapiContext();

        var existe = await db.Usuariobasicos
            .AnyAsync(u => u.Email == usuario.Email || u.NombreUsuario == usuario.NombreUsuario);

        if (existe)
            return Results.BadRequest("El usuario ya ha sido registrado como usuario básico.");

        db.Usuariobasicos.Add(usuario);
        await db.SaveChangesAsync();

        return Results.Ok(new { mensaje = "Usuario básico creado correctamente", id = usuario.Id });
    }
    catch (Exception e)
    {
        return Results.Problem($"Error: {e.Message}");
    }
});

app.MapPost("/crearAdministrador", async (Administrador usuario) =>
{
    try
    {
        if (usuario == null)
            return Results.BadRequest("El objeto es nulo.");

        await using var db = new DbAb946dMinimalapiContext();

        var existe = await db.Administradors
            .AnyAsync(u => u.Email == usuario.Email || u.NombreUsuario == usuario.NombreUsuario);

        if (existe)
            return Results.BadRequest("El usuario ya ha sido registrado como administrador.");

        db.Administradors.Add(usuario);
        await db.SaveChangesAsync();

        return Results.Ok(new { mensaje = "Administrador creado correctamente", id = usuario.Id });
    }
    catch (Exception e)
    {
        return Results.Problem($"Error: {e.Message}");
    }
});

app.MapPost("/crearGestor", async (Gestor usuario) =>
{
    try
    {
        if (usuario == null)
            return Results.BadRequest("El objeto es nulo.");

        await using var db = new DbAb946dMinimalapiContext();

        var existe = await db.Gestors
            .AnyAsync(u => u.Email == usuario.Email || u.NombreUsuario == usuario.NombreUsuario);

        if (existe)
            return Results.BadRequest("El usuario ya ha sido registrado como gestor.");

        db.Gestors.Add(usuario);
        await db.SaveChangesAsync();

        return Results.Ok(new { mensaje = "Gestor creado correctamente", id = usuario.Id });
    }
    catch (Exception e)
    {
        return Results.Problem($"Error: {e.Message}");
    }
});

app.MapPost("/crearTecnico", async (Tecnico usuario) =>
{
    try
    {
        if (usuario == null)
            return Results.BadRequest("El objeto es nulo.");

        await using var db = new DbAb946dMinimalapiContext();

        var existe = await db.Tecnicos
            .AnyAsync(u => u.Email == usuario.Email || u.NombreUsuario == usuario.NombreUsuario);

        if (existe)
            return Results.BadRequest("El usuario ya ha sido registrado como técnico.");

        db.Tecnicos.Add(usuario); 
        await db.SaveChangesAsync();

        return Results.Ok(new { mensaje = "Técnico creado correctamente", id = usuario.Id });
    }
    catch (Exception e)
    {
        return Results.Problem($"Error: {e.Message}");
    }
});



app.Run();