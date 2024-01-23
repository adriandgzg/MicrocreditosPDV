using MicrocreditoDesktop.Services;
using MicrocreditoDesktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MicrocreditoDesktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        CodigoBarras codigoBarras ;
        private bool _isViewVisible = true;
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

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand PagarCommand { get; }
        public ICommand PagarCreditoCommand { get; }
        public ICommand AbonarCommand { get; }

        public CodigoBarrasViewModel codigoBarrasViewModel;

        public MainViewModel()
        {           
            PagarCommand = new ViewModelCommand(ExecutePagarCommand);
            PagarCreditoCommand = new ViewModelCommand(ExecutePagarCreditoCommand);
            AbonarCommand = new ViewModelCommand(ExecuteAbonarCommand);
            codigoBarrasViewModel = new CodigoBarrasViewModel();
            codigoBarras = new CodigoBarras(codigoBarrasViewModel);
        }

        private void ExecutePagarCommand(object obj)
        {
            codigoBarrasViewModel.TipoTarea = 1;
            IsViewVisible = false;
            codigoBarras.Show();
        }

        private void ExecutePagarCreditoCommand(object obj)
        {
            codigoBarrasViewModel.TipoTarea = 2;
            IsViewVisible = false;
            codigoBarras.Show();
        }

        private void ExecuteAbonarCommand(object obj)
        {
            codigoBarrasViewModel.TipoTarea = 3;
            IsViewVisible = false;
            codigoBarras.Show();
        }
    }
}