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
    public partial class PagPrincipal :MasterDetailPage
    {
        public PagPrincipal()
        {
            InitializeComponent();
            Bt_Home_Clicked(null, null);
        }

        private void Bt_Home_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PagHome());
            IsPresented = false;
        }

        private void Bt_Cadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PagCadastro());
            IsPresented = false;
        }

        private void Bt_Listar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PagListar());
            IsPresented = false;
        }

        private void Bt_Sobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PagSobre());
            IsPresented = false;
        }
    }
}