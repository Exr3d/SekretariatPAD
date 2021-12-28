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
        List<Uczen> uczniowie = new List<Uczen>();
        public MainWindow()
        {
            InitializeComponent();
            
            uczniowie.Add(new Uczen()
            {
                uImie = "Tymon2",
                uDrugieImie = "Jakub2"
            });
            

            uczniowie.Add(new Uczen()
            {
                uImie = "Tymon2",
                uDrugieImie = "Jakub2"
            });
           




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

        public class Uczen
        {
            public string uImie { get; set; }
            public string uDrugieImie { get; set; }
            public string uNazwisko { get; set; }
            public string uNazwiskoPanienskie { get; set; }
            public string uImieOjca { get; set; }
            public string uImieMatki { get; set; }
            public string uDataUr { get; set; }
            public string uPesel { get; set; }
        }

        private void addUczen(object sender, RoutedEventArgs e)
        {

            uczniowie.Add(new Uczen()
            {
                uImie = uImieTB.Text
            });
            uczniowie.Add(new Uczen()
            {
                uImie = "Tymon2",
                uDrugieImie = "Jakub2"
            });
            dgUczen.ItemsSource = uczniowie;
            dgUczen.Items.Refresh();


        }
        public List<Uczen> LadujUczen()
        {
            List<Uczen> uczniowie = new List<Uczen>();
            uczniowie.Add(new Uczen()
            {
                uImie = "Tymon2",
                uDrugieImie = "Jakub2"
            });

           
            return uczniowie;
        }
    }
}
