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
    public partial class PagHome : ContentPage
    {
        public PagHome()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Inserir
            MasterDetailPage masterDetailPage = (MasterDetailPage)Application.Current.MainPage;
            masterDetailPage.Detail = new NavigationPage(new PagCadastro());
            masterDetailPage.IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //Localizar
            MasterDetailPage masterDetailPage = (MasterDetailPage)Application.Current.MainPage;
            masterDetailPage.Detail = new NavigationPage(new PagListar());
            masterDetailPage.IsPresented = false;
        }
    }
}