using Acr.UserDialogs;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TD1_Xamarin.Models;
using TD1_Xamarin.Services;

namespace TD1_Xamarin.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();


        private ObservableCollection<Devise> _listesDevises;
        public ObservableCollection<Devise> ListeDevises
        {
            get { return _listesDevises; }
            set
            {
                _listesDevises = value;
                RaisePropertyChanged();// Pour notifier de la modification de ses données
            }
        }

        private Devise _selectedDevise;
        public Devise SelectedDevise
        {
            get { return _selectedDevise; }
            set
            {
                _selectedDevise = value;
                RaisePropertyChanged();// Pour notifier de la modification de ses données
            }
        }

        public ICommand BtnSetConversion { get; private set; }

        private string _montantEuros;
        public string MontantEuros
        {
            get { return _montantEuros; }
            set
            {
                _montantEuros = value;
                RaisePropertyChanged();
            }
        }

        private string _montantDevises;
        public string MontantDevises
        {
            get { return _montantDevises; }
            set
            {
                _montantDevises = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        private async void ActionGetData()
        {
            var result = await DeviseService.Instance.getAllDevisesAsync();
            this.ListeDevises = new ObservableCollection<Devise>(result);

        }

        private void ActionSetConversion()
        {
            Devise deviseSelected = this.SelectedDevise;
            string mntEuros = this.MontantEuros;
            
            if (mntEuros == null)
            {
                UserDialogs.Instance.AlertAsync("Merci de mettre un montant", "Erreur");
                return;
            }

            try
            {
                Double.Parse(mntEuros);
            } catch
            {
                UserDialogs.Instance.AlertAsync("Merci de mettre une valeur correcte", "Erreur");
                return;
            }


            if (deviseSelected == null)
            {
                UserDialogs.Instance.AlertAsync("Merci de choisir une devise", "Erreur");
                return;
            }


            this.MontantDevises = (deviseSelected.Taux * Double.Parse(mntEuros)).ToString();
            
        }
    }
}
