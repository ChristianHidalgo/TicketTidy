using System;
using System.Collections.ObjectModel;
using APIBuenaTicketing.Models;
using TicketTidyFRONT.ClasesBinding;
using TicketTidyFRONT.Generic;

namespace TicketTidyFRONT.Pages.AccionesBasico;

public partial class CrearIncidenciasUsuarioBasico : ContentPage
{
    public CrearIncidenciaUsuarioBasicoViewModel ViewModel { get; set; }

    public Incidencia incidencia { get; set; }

    // Necesitarás pasar el ID del usuario básico de alguna manera
    private int _usuarioBasicoId;

    public CrearIncidenciasUsuarioBasico(int usuarioBasicoId)
    {
        InitializeComponent();
        _usuarioBasicoId = usuarioBasicoId;
        ViewModel = new CrearIncidenciaUsuarioBasicoViewModel();
        ViewModel.FechaApertura = DateTime.Now.ToString("dd/MM/yyyy");
        _ = GetDispositivos();
        _ = GetEspacios();
        BindingContext = ViewModel;
    }

    public async Task GetDispositivos()
    {
        try
        {
            ViewModel.Dispositivos = new ObservableCollection<Dispositivo>();
            var dispositivos = await HTTPHelper.GetAll<Dispositivo>("http://finaltickettidy.somee.com/getDispositivos");
            foreach (var dispositivo in dispositivos)
            {
                ViewModel.Dispositivos.Add(dispositivo);
            }
            if (ViewModel.Dispositivos.Count > 0)
            {
                ViewModel.DispositivoSeleccionado = ViewModel.Dispositivos[0];
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar los dispositivos", "OK");
        }
    }

    public async Task GetEspacios()
    {
        try
        {
            ViewModel.Espacios = new ObservableCollection<Espacio>();
            var espacios = await HTTPHelper.GetAll<Espacio>("http://finaltickettidy.somee.com/getEspacios");
            foreach (var espacio in espacios)
            {
                ViewModel.Espacios.Add(espacio);
            }
            if (ViewModel.Espacios.Count > 0)
            {
                ViewModel.EspacioSeleccionado = ViewModel.Espacios[0];
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar los espacios", "OK");
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
            incidencia = new Incidencia();

            if (string.IsNullOrEmpty(descripcionEditor.Text))
            {
                await DisplayAlert("Error", "Por favor, describe la incidencia", "Volver");
                return;
            }

            incidencia.FechaDeApertura = DateOnly.FromDateTime(DateTime.Now);
            incidencia.Estado = "Alta";
            incidencia.DescripcionDeLaIncidencia = descripcionEditor.Text;
            incidencia.TecnicoId = null;
            incidencia.GestorId = null;
            incidencia.UbasicoId = _usuarioBasicoId; // Asignamos el ID del usuario básico
            incidencia.FechaDeCierre = null;
            incidencia.DescripcionDeLaSolución = null;
            incidencia.TipoDeIncidencia = null; // El usuario básico no selecciona el tipo
            Dispositivo dispositivoSeleccionado = (Dispositivo)pickerDispositivos.SelectedItem;
            if (dispositivoSeleccionado != null)
            {
                incidencia.DispositivoId = dispositivoSeleccionado.Id;
            }
            Espacio espacioSeleccionado = (Espacio)pickerEspacios.SelectedItem;
            if (espacioSeleccionado != null)
            {
                incidencia.EspacioId = espacioSeleccionado.Id;
            }

            bool confirmacion = await DisplayAlert("Aviso", "¿Guardar esta incidencia?", "Sí", "No");

            if (confirmacion)
            {
                var response = await HTTPHelper.Post<Incidencia>(
                    "http://finaltickettidy.somee.com/saveIncidenciaNueva", incidencia
                );

                if (response == 1)
                {
                    await DisplayAlert("Éxito", "Incidencia creada correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se ha podido guardar la incidencia", "Volver");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al guardar la incidencia", "Volver");
        }
    }
}

public class CrearIncidenciaUsuarioBasicoViewModel : BindableObject
{
    public string FechaApertura { get; set; }

    private ObservableCollection<Dispositivo> _dispositivos;
    public ObservableCollection<Dispositivo> Dispositivos
    {
        get => _dispositivos;
        set
        {
            _dispositivos = value;
            OnPropertyChanged();
        }
    }

    private Dispositivo _dispositivoSeleccionado;
    public Dispositivo DispositivoSeleccionado
    {
        get => _dispositivoSeleccionado;
        set
        {
            _dispositivoSeleccionado = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<Espacio> _espacios;
    public ObservableCollection<Espacio> Espacios
    {
        get => _espacios;
        set
        {
            _espacios = value;
            OnPropertyChanged();
        }
    }

    private Espacio _espacioSeleccionado;
    public Espacio EspacioSeleccionado
    {
        get => _espacioSeleccionado;
        set
        {
            _espacioSeleccionado = value;
            OnPropertyChanged();
        }
    }
}