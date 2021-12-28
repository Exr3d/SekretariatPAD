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
using System.IO;
using Microsoft.Win32;

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
            dgUczen.ItemsSource = uczniowie;

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
            public DateTime uDataUr { get; set; }
            public string uPesel { get; set; }
            public Uri uZdjecie { get; set; }
        }

        private void addUczen(object sender, RoutedEventArgs e)
        {

            uczniowie.Add(new Uczen()
            {
                uImie = uImieTB.Text,
                uDataUr = uDataUrodzenia.SelectedDate.Value.Date,
                uZdjecie = new Uri("C:\\Users\\Tymon\\Desktop\\pngTest.png")

            });
            dgUczen.Items.Refresh();


        }

        private void uczenAddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                uczenImage.Text = openFileDialog.FileName;
        }
    }
}
