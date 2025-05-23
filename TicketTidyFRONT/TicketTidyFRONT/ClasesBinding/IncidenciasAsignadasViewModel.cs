using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIBuenaTicketing.Models;
using TicketTidyFRONT.Generic;

namespace TicketTidyFRONT.ClasesBinding
{
    public class IncidenciasAsignadasViewModel: BaseBinding
    {

        private ObservableCollection<Incidencia> _incidencias;
        public ObservableCollection<Incidencia> Incidencias
        {
            get => _incidencias;
            set => setValue(ref _incidencias, value);
        }

        private ObservableCollection<Tecnico> _tecnicos;
        public ObservableCollection<Tecnico> Tecnicos
        {
            get => _tecnicos;
            set => setValue(ref _tecnicos, value);
        }

        private ObservableCollection<Gestor> _gestores;
        public ObservableCollection<Gestor> Gestores
        {
            get => _gestores;
            set => setValue(ref _gestores, value);
        }

        private ObservableCollection<UsuarioBasico> _usuariosBasicos;
        public ObservableCollection<UsuarioBasico> UsuariosBasicos
        {
            get => _usuariosBasicos;
            set => setValue(ref _usuariosBasicos, value);
        }

        public string image { get; set; }

        private bool _cargando;
        public bool cargando
        {
            get { return _cargando; }
            set { setValue(ref _cargando, value); }
        }


        private bool _loading;
        public bool loading
        {
            get { return _loading; }
            set { setValue(ref _loading, value); }
        }

        public string incidenciaIcono { get; set; }
        public string fecha { get; set; }

        private Incidencia _incidencia;
        public Incidencia Incidencia
        {
            get => _incidencia;
            set => setValue(ref _incidencia, value);
        }

        private Dispositivo _dispositivoSeleccionado;
        public Dispositivo DispositivoSeleccionado
        {
            get => _dispositivoSeleccionado;
            set => setValue(ref _dispositivoSeleccionado, value);
        }

        private Espacio _espacioSeleccionado;
        public Espacio EspacioSeleccionado
        {
            get => _espacioSeleccionado;
            set => setValue(ref _espacioSeleccionado, value);
        }

        private Gestor _gestorSeleccionado;
        public Gestor GestorSeleccionado
        {
            get => _gestorSeleccionado;
            set => setValue(ref _gestorSeleccionado, value);
        }

        private Tecnico _tecnicoSeleccionado;
        public Tecnico TecnicoSeleccionado
        {
            get => _tecnicoSeleccionado;
            set => setValue(ref _tecnicoSeleccionado, value);
        }
        private UsuarioBasico _usuarioSeleccionado;
        public UsuarioBasico UsuarioSeleccionado
        {
            get => _usuarioSeleccionado;
            set => setValue(ref _usuarioSeleccionado, value);
        }

        private ObservableCollection<Dispositivo> _dispositivos;
        public ObservableCollection<Dispositivo> Dispositivos
        {
            get => _dispositivos;
            set => setValue(ref _dispositivos, value);
        }

        private ObservableCollection<Espacio> _espacios;
        public ObservableCollection<Espacio> Espacios
        {
            get => _espacios;
            set => setValue(ref _espacios, value);
        }

        private string _nameDispositivo;
        public string nameDispositivo
        {
            get => _nameDispositivo;
            set => setValue(ref _nameDispositivo, value);
        }

        private string _nameEspacio;
        public string nameEspacio
        {
            get => _nameEspacio;
            set => setValue(ref _nameEspacio, value);
        }

        private string _nameTecnico;
        public string nameTecnico
        {
            get => _nameTecnico;
            set => setValue(ref _nameTecnico, value);
        }

        private string _nameGestor;
        public string nameGestor
        {
            get => _nameGestor;
            set => setValue(ref _nameGestor, value);
        }

        private string _nameBasico;
        public string nameBasico
        {
            get => _nameBasico;
            set => setValue(ref _nameBasico, value);
        }
    }

}
