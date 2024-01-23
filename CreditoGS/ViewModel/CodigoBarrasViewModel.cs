using Capa_Entidad;
using Capa_Negocio;
using CreditoGS.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CreditoGS.ViewModel
{
    public class CodigoBarrasViewModel : ViewModelBase
    {
        readonly CN_Pagos cN_Pagos = new CN_Pagos();
        private bool _isViewVisibleModal = false;
        private bool _isViewVisible = false;
        private CE_PaymentResp paymentResp = new CE_PaymentResp();
        private CE_PaymentCreditResp creditResp = new CE_PaymentCreditResp();
        private MainViewModel _mainViewModel;
        private Loader loaderView = new Loader();

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

        private string _codigobarra;
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

        public bool IsViewVisibleModal
        {
            get
            {
                return _isViewVisibleModal;
            }

            set
            {
                _isViewVisibleModal = value;
                OnPropertyChanged(nameof(IsViewVisibleModal));
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

        public ICommand ExecuteCommand { get; }
        public ICommand PagarCreditoCommand { get; }
        public MainViewModel mainViewModel { get => _mainViewModel; set => _mainViewModel = value; }

        public CodigoBarrasViewModel()
        {
            ExecuteCommand = new ViewModelCommand(ExecutePagarCommand);
            PagarCreditoCommand = new ViewModelCommand(ExecutePagoCredito);
        }

        private async void ExecutePagoCredito(object obj)
        {
            string token = (string)App.Current.Properties["TokenAuth"];
            IsViewVisibleModal = false;
         
            if (creditResp != null)
            {
                loaderView.Show();
                var res = await cN_Pagos.PagarCredito(new Capa_Entidad.CECreditPayment()
                {
                    amount_pay = creditResp.data.amount_pay,
                    idclient = creditResp.data.info_client.idcliente,
                    idcode = creditResp.data.idcode,
                    branch_number = "C-56",
                    idcredit = creditResp.data.idcredit
                }, token);
                loaderView.Close();
                if (res != null)
                    if (res.issuccess)
                        MessageBox.Show(res.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show(res.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);

                IsViewVisible = false;
                mainViewModel.IsViewVisible = true;
            }
            else
            {
                MessageBox.Show("Ocurrio un error al intentar realizar el pago, si el problema persiste contacte al administrador.", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private async void ExecutePagarCommand(object obj)
        {
            
            string token = (string)App.Current.Properties["TokenAuth"];
            switch (TipoTarea)
            {
                case 1:
                    loaderView.Show();
                    var response = await cN_Pagos.BuscarCodigoPago(new Capa_Entidad.CE_CodePayment() { code_payment = CodigoBarra }, token);
                    loaderView.Close();
                    if (response != null)
                        if (response.issuccess)
                        {
                           
                            loaderView.Show();
                            var res = await cN_Pagos.PagarProducto(new Capa_Entidad.CE_PayPayment()
                            {
                                amount_pay = response.data.amount_pay,
                                idclient = response.data.info_client.idcliente,
                                idcode = response.data.idcode,
                                branch_number = "C-56"

                            }, token);
                            loaderView.Close();
                            if (res != null)
                                if (res.issuccess)
                                    MessageBox.Show(res.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                                else
                                    MessageBox.Show(res.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);


                        }
                        else
                            MessageBox.Show(response.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 2:
                   
                    loaderView.Show();
                    var responseC = await cN_Pagos.BuscarCodigoAbono(new Capa_Entidad.CE_CodePayment() { code_payment = CodigoBarra }, token);
                    loaderView.Close();
                    if (responseC != null)
                        if (responseC.issuccess)
                        {
                            creditResp = responseC;
                            IsViewVisibleModal = true;
                            ModalWindow modalWindow = new ModalWindow("Reciba la cantidad de " + string.Format("{0:C2}", responseC.data.amount_pay) + " del cliente", this);
                          

                            modalWindow.ShowDialog();

                        }
                        else
                            MessageBox.Show(responseC.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 3:
                  
                    loaderView.Show();
                    await cN_Pagos.BuscarCodigoPago(new Capa_Entidad.CE_CodePayment() { code_payment = CodigoBarra }, token);
                    loaderView.Close();
                    break;
            }

        }
    }
}
