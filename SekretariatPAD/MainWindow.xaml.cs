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
        List<Empty> empty = new List<Empty>();
        int raportNUMBER = 1;
        public MainWindow()
        {
            InitializeComponent();
            dgUczen.ItemsSource = uczniowie;
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
        public class Empty
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
            int lineCount = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {   
                StreamReader sr = new StreamReader(openFileDialog.FileName.ToString());
                StreamReader srLineCount = new StreamReader(openFileDialog.FileName.ToString());
                while (srLineCount.ReadLine() != null)
                {
                    lineCount++;
                }
               
                if (lineCount % 11 == 0)
                {
                    while (sr.EndOfStream != true)
                    {



                        var x = 0;
                        string[] tablicaLini = new string[11];
                        while (x < 11)
                        {
                            string linia = sr.ReadLine().ToString();
                            tablicaLini[x] = linia;
                            x++;
                        }
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
                    dgUczen.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Sprawdź poprawność dodawanego pliku");
                }
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {}
            else
            {
                Close();
            }
            
        }

        private void AuthorClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Tymon Wojtanowski");
        }

        private void ShortcutMenuClickUczen(object sender, RoutedEventArgs e)
        {
            dgUczen.ItemsSource = null;
            uczniowie.Clear();
            dgUczen.ItemsSource = uczniowie;
        }

        private void ShortcutMenuClickNauczyciel(object sender, RoutedEventArgs e)
        {
            dgNauczyciel.ItemsSource = null;
        }

        private void ShortcutMenuClickPracownik(object sender, RoutedEventArgs e)
        {
            dgPracownik.ItemsSource = null;
        }

        private void searchUczenPoImieniu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuImie.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uImie.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" +raportNUMBER + ".txt";
            if (!File.Exists(path))
            {

                string text = "";
                for (int i = 0; i < dgUczen.Items.Count; i++)
                {
                    Uczen uczenTest = dgUczen.Items[i] as Uczen;
                    text += (uczenTest.uImie + " " + uczenTest.uDrugieImie);

                    if (i < dgUczen.Items.Count - 1)
                        text += ", ";
                }
                

                string result = string.Join(";",dgUczen.Items[0].ToString());
              
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine(text);
                }
                
            }

        }

        private void searchUczenPoDrugimImieniu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuDrugieImie.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uDrugieImie.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoNazwisku(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuNazwisko.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uNazwisko.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoNazwiskuPanienskim(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuNazwiskoPanienskie.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uNazwiskoPanienskie.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoImieniuOjca(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuImieOjca.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uImieOjca.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoImieniuMatki(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuImieMatki.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uImieMatki.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoDacieUr(object sender, RoutedEventArgs e)
        {
            if(searchuDataUr.Text != "")
            {
            DateTime tempNeeded = DateTime.Parse(searchuDataUr.Text);

            var Zfiltrowane = uczniowie.Where(x => x.uDataUr.Equals(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
            }
            else
            {
                dgUczen.ItemsSource = uczniowie;
            }
            
        }

        private void searchUczenPoPeselu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuPesel.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uPesel.ToLower().Equals(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoPlci(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuPlec.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uPlec.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoKlasie(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuKlasa.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uKlasa.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }

        private void searchUczenPoGrupie(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuGrupa.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uGrupa.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();
        }
    }
}
