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

using LIB_EMETTEUR_4G;
using Microsoft.Maps.MapControl.WPF;

namespace WPF_LIB_EMETTEUR_4G
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        C_BASE La_Base;
        const string Token = "Ar4CoAvUoCqTlJKMSoBYcd358Guqfli7ULyoQdhMhlzibNzZOS-s6y3toAnMCR1Q";
        static bool Satellite = true;
        public MainWindow()
        {
            InitializeComponent();
            List_Region.DisplayMemberPath = "name";
            List_Departement.DisplayMemberPath = "name";
            List_Ville.DisplayMemberPath = "name";
            List_Emetteur.DisplayMemberPath = "Adm";
            try
            {
                La_Base = new C_BASE();
                La_Base.Charge_Data();
                Initialiser();

                La_Carte.CredentialsProvider = new ApplicationIdCredentialsProvider(Token);
                La_Carte.Mode = new RoadMode();

            }
            catch (Exception P_Erreur)
            {
                MessageBox.Show(P_Erreur.Message);
            }
        }

        void Initialiser()
        {
            var Les_Region = La_Base.Get_All_Region();
            for (int Index = 0; Index < Les_Region.Count; Index++)
            {
                List_Region.Items.Add(Les_Region[Index]);
            }
        }

        private void List_Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(List_Region.SelectedItem != null)
            {
                List_Departement.Items.Clear();
                La_Carte.Children.Clear();
                var La_Region = (C_REGION)List_Region.SelectedItem;
                var Mes_Departemnt = La_Base.Get_Departement_By_Code_Region(La_Region.code);
                for (int Index = 0; Index < Mes_Departemnt.Count; Index++)
                {
                    List_Departement.Items.Add(Mes_Departemnt[Index]);
                }
            }
        }

        private void List_Departement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(List_Departement.SelectedItem != null)
            {
                List_Ville.Items.Clear();
                La_Carte.Children.Clear();
                var Le_Departemnt = (C_DEPARTEMENT)List_Departement.SelectedItem;
                var Mes_Villes = La_Base.Get_Ville_By_Code_Departement(Le_Departemnt.code);
                for (int Index = 0; Index < Mes_Villes.Count; Index++)
                {
                    List_Ville.Items.Add(Mes_Villes[Index]);
                }
            }
        }

        private void List_Ville_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(List_Ville.SelectedItem != null)
            {
                List_Emetteur.Items.Clear();
                var La_Ville = (C_VILLE)List_Ville.SelectedItem;
                var Les_Emetteur = La_Base.Get_Emetteur_By_Code_Departement(La_Ville.department_code);

                var Latidute_Ville = La_Ville.gps_lat;
                var Longitude_Ville = La_Ville.gps_lng;

                
                La_Carte.Children.Clear();
                La_Carte.Center = new Location(Latidute_Ville, Longitude_Ville);
                La_Carte.ZoomLevel = 10;
                Label_Lat.Content = Latidute_Ville;
                Label_Long.Content = Longitude_Ville;

                for (int Index = 0; Index < Les_Emetteur.Count; Index++)
                {

                    const double R = 6371;

                    var Emetteur_X = Les_Emetteur[Index].XY[0];
                    var Emetteur_Y = Les_Emetteur[Index].XY[1];

                    double Radian_Lat = (Emetteur_X - Latidute_Ville) * Math.PI / 180;
                    double Radian_Long = (Emetteur_Y - Longitude_Ville) * Math.PI / 180;

                    double a = Math.Sin(Radian_Lat / 2) * Math.Sin(Radian_Lat / 2) +
                    Math.Cos(Latidute_Ville * Math.PI / 180) * Math.Cos(Emetteur_X * Math.PI / 180) *
                    Math.Sin(Radian_Long / 2) * Math.Sin(Radian_Long / 2);

                    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                    var distance = R * c;

                    if (distance <= Slider_Distance.Value)
                    {
                        List_Emetteur.Items.Add(Les_Emetteur[Index]);
                        Pushpin Le_Pin = new Pushpin() {

                            

                        };
                        Le_Pin.Location = new Location(Emetteur_X, Emetteur_Y);
                        La_Carte.Children.Add(Le_Pin);
                    }


                }

            }
        }

        private void Slider_Distance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Label_Km.Content = Slider_Distance.Value;
        }

        
        
        private void Change_Mode_Click(object sender, RoutedEventArgs e)
        {


            if (Satellite)
            {
                La_Carte.Mode = new AerialMode();
                Change_Mode.Content = "Satellite";
            }
            else
            {
                La_Carte.Mode = new RoadMode();
                Change_Mode.Content = "Routière";
            }
            Satellite = !Satellite;




        }
    }
}
