using DMSkin.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlMedicoWpf.Catalogo.Medicamento;
using ControlMedicoWpf.Paciente;
using MahApps.Metro.Controls;

namespace ControlMedicoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            //ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            //ShowHideMenu("sbShowLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, DockPanel pnl)
        {
            //DMSkinSimpleWindow dMSkinSimpleWindow = new DMSkinSimpleWindow();
            //dMSkinSimpleWindow.Resources
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void MenuItemCatalogos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubMenuItemMedicamentos_Click(object sender, RoutedEventArgs e)
        {
            AgregarMedicamento cw = new AgregarMedicamento();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;            
            cw.Show();
        }

        private void PacientesMenuItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ControlPacientes cw = new ControlPacientes();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
        }
    }
}
