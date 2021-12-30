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

        List<Nauczyciel> nauczyciele = new List<Nauczyciel>();
        List<EmptyNauczyciel> emptyNauczyciele = new List<EmptyNauczyciel>();

        
        


        int raportNUMBER = 1;
        public MainWindow()
        {
            InitializeComponent();
            dgUczen.ItemsSource = uczniowie;
            dgNauczyciel.ItemsSource = nauczyciele;
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
        public class Nauczyciel
        {
            public string nImie { get; set; }
            public string nDrugieImie { get; set; }
            public string nNazwisko { get; set; }
            public string nNazwiskoPanienskie { get; set; }
            public string nImieOjca { get; set; }
            public string nImieMatki { get; set; }
            public DateTime nDataUr { get; set; }
            public string nPesel { get; set; }
            public Uri nZdjecie { get; set; }
            public string nPlec { get; set; }
            public string nWychowawstwo { get; set; }
            public string nPrzedmiotyNauczane { get; set; }
            public string nKlasaIloscGodzin { get; set; }
            public DateTime nDataZatr { get; set; }
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
        public class EmptyNauczyciel
        {
            public string nImie { get; set; }
            public string nDrugieImie { get; set; }
            public string nNazwisko { get; set; }
            public string nNazwiskoPanienskie { get; set; }
            public string nImieOjca { get; set; }
            public string nImieMatki { get; set; }
            public DateTime nDataUr { get; set; }
            public string nPesel { get; set; }
            public Uri nZdjecie { get; set; }
            public string nPlec { get; set; }
            public string nWychowawstwo { get; set; }
            public string nPrzedmiotyNauczane { get; set; }
            public string nKlasaIloscGodzin { get; set; }
            public DateTime nDataZatr { get; set; }
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
            string text = "";
                for (int i = 0; i < dgUczen.Items.Count; i++)
                {
                    
                    Uczen uczenTest = dgUczen.Items[i] as Uczen;
                
                    text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " " 
                    + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec 
                    + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                    if (i < dgUczen.Items.Count - 1)
                        text += "\n";
                }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia za pomoca slowa kluczowego:  " +tempNeeded + " \n"+ "Raport wykonany: "+ DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }

        }

        private void searchUczenPoDrugimImieniu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuDrugieImie.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uDrugieImie.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie drugiego imienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoNazwisku(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuNazwisko.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uNazwisko.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie nazwiska za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoNazwiskuPanienskim(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuNazwiskoPanienskie.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uNazwiskoPanienskie.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie nazwiska panienskiego za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoImieniuOjca(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuImieOjca.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uImieOjca.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia ojca za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoImieniuMatki(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuImieMatki.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uImieMatki.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia matki za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
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

                string path;
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
                string text = "";
                for (int i = 0; i < dgUczen.Items.Count; i++)
                {

                    Uczen uczenTest = dgUczen.Items[i] as Uczen;

                    text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                    + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                    + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                    if (i < dgUczen.Items.Count - 1)
                        text += "\n";
                }
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (var tw = new StreamWriter(path))
                    {
                        tw.WriteLine("Wyniki wyszukiwań na podstawie daty urodzenia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                        tw.WriteLine(text);
                    }
                }
                else
                {
                    path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
                }
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

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie peselu za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoPlci(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuPlec.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uPlec.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie plci za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoKlasie(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuKlasa.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uKlasa.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie klasy za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void searchUczenPoGrupie(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchuGrupa.Text.ToLower().ToString();

            var Zfiltrowane = uczniowie.Where(x => x.uGrupa.ToLower().Contains(tempNeeded));
            dgUczen.ItemsSource = empty;
            dgUczen.ItemsSource = Zfiltrowane;
            dgUczen.Items.Refresh();

            string path;
            path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Uczen uczenTest = dgUczen.Items[i] as Uczen;

                text += uczenTest.uImie + " " + uczenTest.uDrugieImie + " " + uczenTest.uNazwisko + " " + uczenTest.uNazwiskoPanienskie + " "
                + uczenTest.uImieOjca + " " + uczenTest.uImieMatki + " " + uczenTest.uDataUr.Date + " " + uczenTest.uPesel + " " + uczenTest.uPlec
                + " " + uczenTest.uKlasa + " " + uczenTest.uGrupa;

                if (i < dgUczen.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie grupy za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = "C:\\Users\\Tymon\\OneDrive\\Pulpit\\testRaport" + ++raportNUMBER + ".txt";
            }
        }

        private void addDaneNauczyciel(object sender, RoutedEventArgs e)
        {
            int lineCount = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName.ToString());
                StreamReader srLineCount = new StreamReader(openFileDialog.FileName.ToString());
                while (srLineCount.ReadLine() != null)
                {
                    lineCount++;
                }

                if (lineCount % 13 == 0)
                {
                    while (sr.EndOfStream != true)
                    {



                        var x = 0;
                        string[] tablicaLini = new string[13];
                        while (x < 13)
                        {
                            string linia = sr.ReadLine().ToString();
                            tablicaLini[x] = linia;
                            x++;
                        }
                        nauczyciele.Add(new Nauczyciel()
                        {
                            nImie = tablicaLini[0],
                            nDrugieImie = tablicaLini[1],
                            nNazwisko = tablicaLini[2],
                            nNazwiskoPanienskie = tablicaLini[3],
                            nImieOjca = tablicaLini[4],
                            nImieMatki = tablicaLini[5],
                            nDataUr = DateTime.Parse(tablicaLini[6]),
                            nPesel = tablicaLini[7],
                            nPlec = tablicaLini[8],
                            nWychowawstwo = tablicaLini[9],
                            nPrzedmiotyNauczane = tablicaLini[10],
                            nKlasaIloscGodzin = tablicaLini[11],
                            nDataZatr = DateTime.Parse(tablicaLini[12])
                        });
                        dgNauczyciel.Items.Refresh();
                    }
                    dgNauczyciel.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Sprawdź poprawność dodawanego pliku");
                }
            }
        }

        private void addNauczyciel(object sender, RoutedEventArgs e)
        {
            nauczyciele.Add(new Nauczyciel()
            {
                nImie = nImieTB.Text,
                nDrugieImie = nDrugieImieTB.Text,
                nNazwisko = nNazwiskoTB.Text,
                nNazwiskoPanienskie = nNazwiskoPanienskieTB.Text,
                nImieOjca = nImieMatkiTB.Text,
                nImieMatki = nImieOjcaTB.Text,
                nDataUr = nDataUrTB.SelectedDate.Value.Date,
                nPesel = nPeselTB.Text,
                nZdjecie = new Uri(nZdjecieTB.Text),
                nPlec = nPlecTB.Text,
                nWychowawstwo = nWychowawstwoTB.Text,
                nPrzedmiotyNauczane = nPrzedmiotyNauczaneTB.Text,
                nKlasaIloscGodzin = nKlasyIloscGodzinTB.Text,
                nDataZatr = nDataZatrTB.SelectedDate.Value.Date,
            });
            dgNauczyciel.Items.Refresh();
        }

        private void addImageNauczyciel(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                nZdjecieTB.Text = openFileDialog.FileName;
        }

        private void searchNauczycielPoImieniu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnImie.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();

            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";

            
            
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoDrugimImieniu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnDrugieImie.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie drugiego imienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie drugiego imienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoNazwisku(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnNazwisko.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie nazwiska za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie nazwiska za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoNazwiskuPanienskim(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnNazwiskoPanienskie.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie nazwiska panienskiego za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie nazwiska panienskiego za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoImieniuOjca(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnImieOjca.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia ojca za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia ojca za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoImieniuMatki(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnImieMatki.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia matki za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie imienia matki za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoDacieUr(object sender, RoutedEventArgs e)
        {
            DateTime tempNeeded = DateTime.Parse(searchnDataUr.Text);
            

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Equals(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie daty urodzenia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie daty urodzenia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoPeselu(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnPesel.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie peselu za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie peselu za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoPlci(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnPlec.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie płci za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie płci za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoWychowawstwie(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnWychowawstwo.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie wychowawstwa za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie wychowawstwa za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoPrzedmiotach(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnPrzedmioty.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie przedmiotów nauczynach za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie przedmiotów nauczynach za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoIlosciGodzin(object sender, RoutedEventArgs e)
        {
            string tempNeeded = searchnIloscGodzin.Text.ToLower().ToString();

            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Contains(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie ilosci godzin z dana klasa za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie ilosci godzin z dana klasa za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }

        private void searchNauczycielPoDacieZatr(object sender, RoutedEventArgs e)
        {
            DateTime tempNeeded = DateTime.Parse(searchnDataZatr.Text);


            var Zfiltrowane = nauczyciele.Where(x => x.nImie.ToLower().Equals(tempNeeded));
            dgNauczyciel.ItemsSource = emptyNauczyciele;
            dgNauczyciel.ItemsSource = Zfiltrowane;
            dgNauczyciel.Items.Refresh();


            string path;
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + raportNUMBER + ".txt";
            string text = "";
            for (int i = 0; i < dgUczen.Items.Count; i++)
            {

                Nauczyciel nauczycielTest = dgNauczyciel.Items[i] as Nauczyciel;

                text += nauczycielTest.nImie + " " + nauczycielTest.nDrugieImie + " " + nauczycielTest.nNazwisko + " " + nauczycielTest.nNazwiskoPanienskie + " "
                + nauczycielTest.nImieOjca + " " + nauczycielTest.nImieMatki + " " + nauczycielTest.nDataUr.Date + " " + nauczycielTest.nPesel + " " + nauczycielTest.nPlec
                + " " + nauczycielTest.nWychowawstwo + " " + nauczycielTest.nPrzedmiotyNauczane + " " + nauczycielTest.nKlasaIloscGodzin + " " + nauczycielTest.nDataZatr.Date;

                if (i < dgNauczyciel.Items.Count - 1)
                    text += "\n";
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie daty zatrudnienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
            else
            {

                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testRaport" + ++raportNUMBER + ".txt";
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine("Wyniki wyszukiwań na podstawie daty zatrudnienia za pomoca slowa kluczowego:  " + tempNeeded + " \n" + "Raport wykonany: " + DateTime.Now.ToString());
                    tw.WriteLine(text);
                }
            }
        }
    }
}
