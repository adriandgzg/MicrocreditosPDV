using MicrocreditoDesktop.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace MicrocreditoDesktop.ViewModel
{
    public class CodigoBarrasViewModel :ViewModelBase
    {        
        private int _tipotarea;
        public int TipoTarea
        {
            get
            {
                return _tipotarea;
            }

            set
            {
                _tipotarea = value;
                OnPropertyChanged(nameof(_tipotarea));
            }
        }

        private string _codigobarra="";
        public string CodigoBarra
        {
            get
            {
                return _codigobarra;
            }

            set
            {
                _codigobarra = value;
                OnPropertyChanged(nameof(_codigobarra));
            }
        }

        public ICommand ExecuteCommand { get; }


        public CodigoBarrasViewModel()
        {
            ExecuteCommand = new ViewModelCommand(ExecutePagarCommand);

        }

        private void ExecutePagarCommand(object obj)
        {            
            Debug.Print("EL tipo de tarea es: " + TipoTarea);
        }
    }
}
