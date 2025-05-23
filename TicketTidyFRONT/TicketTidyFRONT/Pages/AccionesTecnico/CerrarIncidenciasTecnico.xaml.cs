using System.Threading.Tasks;
using APIBuenaTicketing.Models;
using TicketTidyFRONT.ClasesBinding;
using TicketTidyFRONT.Generic;

namespace TicketTidyFRONT.Pages.AccionesTecnico;

public partial class CerrarIncidenciasTecnico : ContentPage
{
	//public string fecha { get; set; }
 //   public Incidencia incidenciaFront { get; set; }

 //   public long idIncidenciaFront { get; set; }

 //   public DateOnly? FechaApertura { get; set; }

 //   public long dispositivoId { get; set; }

 //   public long espacioId { get; set; }

 //   public long gestorId { get; set; }

 //   public long tecnicoId { get; set; }

 //   public string nameTecnico { get; set; }
 //   public string nameGestor { get; set; }
 //   public string nameBasico { get; set; }

 //   public string nameEspacio { get; set; }
 //   public string nameDispositivo { get; set; }

 //   public long ubasicoId { get; set; }

 //   public string? descripcionIncidencia { get; set; }

 //   public string? descripcionSolucion { get; set; }

 //   public string? tipoIncidencia { get; set; }

 //   public string? estado { get; set; }

    public IncidenciasAsignadasViewModel viewModel { get; set; }

    public CerrarIncidenciasTecnico()
	{
		InitializeComponent();
        viewModel = new IncidenciasAsignadasViewModel();
        viewModel.image = "crono_icon.png"; 
		viewModel.fecha = DateTime.Now.ToString("dd-MM-yyyy");
        BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing(); // Esto ahora es válido

        pickerTipoIncidencia.SelectedIndex = 0;
        pickerCierre.SelectedIndex = 0;
        try
        {
            int idIncidencia = Convert.ToInt32(Preferences.Get("idIncidencia", 0));
            var incidencia = await HTTPHelper.Get<Incidencia>(
                $"http://tickettidy.somee.com/getIncidenciasById/{idIncidencia}?idIncidencia=" + (long)idIncidencia
            );
            viewModel.Incidencia = incidencia;

            // Forzar actualización en la UI si es necesario


            if (viewModel.Incidencia != null)
            {
                
                //get del dispositivo
                var dispo = await HTTPHelper.Get<Dispositivo>("http://tickettidy.somee.com/getDispositivoById/{id}?idDis=" + viewModel.Incidencia.DispositivoId);
                viewModel.nameDispositivo = dispo.Descripcion;

                //get del espacio
                var espacio = await HTTPHelper.Get<Espacio>("http://tickettidy.somee.com/getEspacioById/{id}?idEsp=" + viewModel.Incidencia.EspacioId);
                viewModel.nameEspacio = espacio.Descripcion;

                //get del tecnico
                var tecnico = await HTTPHelper.Get<Tecnico>("http://tickettidy.somee.com/getTecnico/{id}?idtecnico=" + viewModel.Incidencia.TecnicoId);
                viewModel.nameTecnico = tecnico.NombreUsuario;


                //get del gestor
                var gestor = await HTTPHelper.Get<Gestor>("http://tickettidy.somee.com/getGestor/{id}?idGestor=" + viewModel.Incidencia.GestorId);
                viewModel.nameGestor = gestor.NombreUsuario;

                //get del gestor
                var basico = await HTTPHelper.Get<UsuarioBasico>("http://tickettidy.somee.com/getBasicoById/{id}?idBasico=" + viewModel.Incidencia.UbasicoId);
                viewModel.nameBasico = basico.NombreUsuario;

                
            }
            else
            {
                DisplayAlert("Error", "No se ha encontrado la incidencia", "OK");
                return;
                
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se ha encontrado la incidencia", "OK");
        }
    }



    private async void backBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void saveBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            viewModel.Incidencia.DescripcionDeLaSolución = lblSolucion.Text;
            viewModel.Incidencia.FechaDeCierre = DateOnly.FromDateTime(pickerFecha.Date);
            viewModel.Incidencia.Estado = pickerCierre.SelectedItem?.ToString();
            viewModel.Incidencia.TipoDeIncidencia = pickerTipoIncidencia.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(viewModel.Incidencia.DescripcionDeLaSolución))
            {
                DisplayAlert("Error","Tienes que escribir cómo has solucionado la incidencia", "Volver");
                return;
            }


            bool confirmacion = await DisplayAlert("Aviso", "¿Estás seguro que quieres cerrar la incidencia con estos datos?", "Sí", "No");

            if (!confirmacion)
            {
                // Si el usuario selecciona "No", salimos del método
                return;
            }

            var response = await HTTPHelper.Post<Incidencia>(
            "http://tickettidy.somee.com/saveIncidencia", viewModel.Incidencia
            );

            if (response != null)
            {
                await DisplayAlert("Éxito", "Incidencia cerrada correctamente", "OK");
                await Navigation.PopAsync(); // Usamos await aquí también
            }


        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo cerrar la incidencia", "OK");
        }

    }
}