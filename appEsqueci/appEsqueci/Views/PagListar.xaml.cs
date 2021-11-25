using appEsqueci.Models;
using appEsqueci.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appEsqueci.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagListar : ContentPage
    {
        public PagListar()
        {
            InitializeComponent();
            ServicesDbNotas objServiceDb = new ServicesDbNotas(App.DbPath);
            LstNotas.ItemsSource = objServiceDb.ListarNotas();
        }

        public void AtualizaLista()
        {
           
            ServicesDbNotas objServiceDb = new ServicesDbNotas(App.DbPath);
            LstNotas.ItemsSource = objServiceDb.Localizar(txt_Pesquisa.Text, Sw_Favorito.IsToggled);
        }

        private void LstNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                ModelNotas objNotas = (ModelNotas)LstNotas.SelectedItem;
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PagCadastro(objNotas));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Txt_Pesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizaLista();
        }

        private void Sw_Favorito_Toggled(object sender, ToggledEventArgs e)
        {
            AtualizaLista();
        }
    }
}