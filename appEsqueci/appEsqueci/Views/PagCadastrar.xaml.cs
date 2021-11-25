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
    public partial class PagCadastro : ContentPage
    {
        public PagCadastro()
        {
            InitializeComponent();
        }

        public PagCadastro(ModelNotas objNotas)
        {
            try
            {
                InitializeComponent();
                Btn_Salvar.Text = "Alterar";
                Txt_Titulo.Text = objNotas.Titulo;
                Txt_Dados.Text = objNotas.Dados;
                Sw_Favorito.IsToggled = objNotas.Favorito;
                Txt_Codigo.Text = objNotas.Id.ToString();
                Txt_Codigo.IsVisible = true;
                Btn_Excluir.IsVisible = true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Btn_Salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ServicesDbNotas objServiceDb = new ServicesDbNotas(App.DbPath);
                ModelNotas objNotas = new ModelNotas
                {
                    Titulo = Txt_Titulo.Text,
                    Dados = Txt_Dados.Text,
                    Favorito = Sw_Favorito.IsToggled
                };

                if(Btn_Salvar.Text == "Inserir")
                {              
                    objServiceDb.Inserir(objNotas);
                    _ = DisplayAlert("Resultado:", objServiceDb.StatuMessage, "Ok");
                }
                else
                {           
                    objNotas.Id = Convert.ToInt32(Txt_Codigo.Text);
                    objServiceDb.Alterar(objNotas);
                    _ = DisplayAlert("Resultado:", objServiceDb.StatuMessage, "Ok");
                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PagHome());
              
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
          
        }

        private void Btn_Cancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail =  new NavigationPage(new PagHome());
        }

        private async void Btn_Excluir_Clicked(object sender, EventArgs e)
        {
            try
            {
               
                var resp = await DisplayAlert("Excluir registro", "Deseja excluir a nota atual?", "Sim", "Não");
                if (resp)
                {
                    ServicesDbNotas objServiceDb = new ServicesDbNotas(App.DbPath);
                    int id = Convert.ToInt32(Txt_Codigo.Text);
                    objServiceDb.Excluir(id);
                    _ = DisplayAlert("Resultado:", objServiceDb.StatuMessage, "Ok");
                    MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                    p.Detail = new NavigationPage(new PagHome());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}