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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SekretariatPAD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void goToUczen(object sender, RoutedEventArgs e)
        {
            tabUczen.IsSelected = true;
            
        }

        private void goToNauczyciel(object sender, RoutedEventArgs e)
        {
            
            tabNauczyciel.IsSelected = true;
            
        }

        private void goToPracownik(object sender, RoutedEventArgs e)
        {
            tabPracownik.IsSelected = true;
        }
    }
}
