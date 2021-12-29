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
            public string uPlec { get; set; }
            public string uKlasa { get; set; }
            public string uGrupa { get; set; }
        }

        private void addUczen(object sender, RoutedEventArgs e)
        {

            uczniowie.Add(new Uczen()
            {
                uImie = uImieTB.Text,
                uDrugieImie = uDrugieImieTB.Text,
                uNazwisko = uNazwiskoTB.Text,
                uNazwiskoPanienskie = uNazwiskoTB.Text,
                uImieOjca = uImieMatkiTB.Text,
                uImieMatki = uImieMatkiTB.Text,
                uDataUr = uDataUrodzenia.SelectedDate.Value.Date,
                uPesel = uPeselTB.Text,
                uZdjecie = new Uri(uczenImage.Text),
                uPlec = uPlecTB.Text,
                uKlasa = uKlasaTB.Text,
                uGrupa = uGrupaTB.Text
            });
            dgUczen.Items.Refresh();


        }

        private void uczenAddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                uczenImage.Text = openFileDialog.FileName;
        }

        private void addDane(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                
                    
                StreamReader sr = new StreamReader(openFileDialog.FileName.ToString());
                var x = 0;
                string[] tablicaLini = new string[11];
                while (x < 11)
                {
                    string linia = sr.ReadLine().ToString();
                    //uGrupaTB.Text += linia + "\n";
                    tablicaLini[x] = linia;
                    x++;

                }
                

                sr.Close();
               
               
                uczniowie.Add(new Uczen()
                    {
                        uImie = tablicaLini[0],
                        uDrugieImie = tablicaLini[1],
                        uNazwisko = tablicaLini[2],
                        uNazwiskoPanienskie = tablicaLini[3],
                        uImieOjca = tablicaLini[4],
                        uImieMatki = tablicaLini[5],
                        uDataUr = DateTime.Parse(tablicaLini[6]),
                        uPesel = tablicaLini[7],
                        uPlec = tablicaLini[8],
                        uKlasa = tablicaLini[9],
                        uGrupa = tablicaLini[10]
                });
                
                    dgUczen.Items.Refresh();
                    
                
                    
                
                    
                
                
            }
        }
    }
}
