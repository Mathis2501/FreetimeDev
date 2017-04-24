using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
// ReSharper disable PossibleInvalidOperationException

namespace VestGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Spiller> NotPlayingList = new ObservableCollection<Spiller>();
        ObservableCollection<Spiller> IsPlayingList = new ObservableCollection<Spiller>();
        ObservableCollection<Spiller> AnnouncedList = new ObservableCollection<Spiller>();
        List<Spiller> WonList = new List<Spiller>();
        List<Spiller> LostList = new List<Spiller>();
        public MainWindow()
        {
            InitializeComponent();
            btn_AddSpiller.IsEnabled = false;
            btn_Udregn.IsEnabled = false;
            btn_NotPlaying.IsEnabled = false;
            btn_IsPlaying.IsEnabled = false;
            btn_NotAnnouncing.IsEnabled = false;
            btn_IsAnnouncing.IsEnabled = false;
            DataGrid_Spillere.ItemsSource = NotPlayingList;
            DataGrid_IsPlaying.ItemsSource = IsPlayingList;
            DataGrid_Announced.ItemsSource = AnnouncedList;

        }

        private void IsPlaying_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Spillere.SelectedIndex != -1)
            {
                Spiller IsPlaying = (Spiller)DataGrid_Spillere.SelectedItem;
                NotPlayingList.Remove((Spiller)DataGrid_Spillere.SelectedItem);
                IsPlayingList.Add(IsPlaying);
                if (NotPlayingList.Count == 0)
                {
                    btn_IsPlaying.IsEnabled = false;
                }
                else
                {
                    btn_IsPlaying.IsEnabled = true;
                }
                btn_IsAnnouncing.IsEnabled = true;
                btn_NotPlaying.IsEnabled = true;
            }
            else
            {
                MainWindow.NoSelection();
            }
        }

        

        private void NotPlaying_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_IsPlaying.SelectedIndex != -1)
            {
                Spiller NotPlaying = (Spiller)DataGrid_IsPlaying.SelectedItem;
                IsPlayingList.Remove((Spiller)DataGrid_IsPlaying.SelectedItem);
                NotPlayingList.Add(NotPlaying);
                if (IsPlayingList.Count == 0)
                {
                    btn_NotPlaying.IsEnabled = false;
                }
                else
                {
                    btn_NotPlaying.IsEnabled = true;
                }
                btn_IsPlaying.IsEnabled = true;
                btn_IsAnnouncing.IsEnabled = false;
            }
            else
            {
                MainWindow.NoSelection();
            }

        }
        private void NotAnnouncing_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Announced.SelectedIndex != -1)
            {
                Spiller NotAnnouncing = (Spiller)DataGrid_Announced.SelectedItem;
                AnnouncedList.Remove((Spiller)DataGrid_Announced.SelectedItem);
                IsPlayingList.Add(NotAnnouncing);
                if (AnnouncedList.Count == 0)
                {
                    btn_NotAnnouncing.IsEnabled = false;
                }
                else
                {
                    btn_NotAnnouncing.IsEnabled = true;
                }
                btn_IsAnnouncing.IsEnabled = true;
                btn_NotPlaying.IsEnabled = true;
            }
            else
            {
                MainWindow.NoSelection();
            }
        }

        private void IsAnnouncing_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_IsPlaying.SelectedIndex != -1)
            {
                Spiller IsAnnouncing = (Spiller)DataGrid_IsPlaying.SelectedItem;
                IsPlayingList.Remove((Spiller)DataGrid_IsPlaying.SelectedItem);
                AnnouncedList.Add(IsAnnouncing);
                if (IsPlayingList.Count == 0)
                {
                    btn_IsAnnouncing.IsEnabled = false;
                }
                else
                {
                    btn_IsAnnouncing.IsEnabled = true;
                }
                btn_NotAnnouncing.IsEnabled = true;
                btn_NotPlaying.IsEnabled = false;
            }
            else
            {
                MainWindow.NoSelection();
            }
        }

        private void AddSpiller_Click(object sender, RoutedEventArgs e)
        {
            Spiller NewSpiller = new Spiller(SpillerNavn.Text);
            NotPlayingList.Add(NewSpiller);
            btn_IsPlaying.IsEnabled = true;
            SpillerNavn.Clear();
        }

        private void Udregn_Click(object sender, RoutedEventArgs e)
        {
            int Point = 0;
            bool Gran = false;
            
            if ((bool)RB_7.IsChecked)
            {
                Point = 10;
                Gran = true;
            }
            if ((bool)RB_8.IsChecked)
            {
                Point = 20;
                Gran = true;
            }
            if ((bool)RB_9.IsChecked)
            {
                Point = 40;
                Gran = true;
            }
            if ((bool)RB_10.IsChecked)
            {
                Point = 60;
                Gran = true;
            }
            if ((bool)RB_11.IsChecked)
            {
                Point = 80;
                Gran = true;
            }
            if ((bool)RB_12.IsChecked)
            {
                Point = 100;
                Gran = true;
            }
            if ((bool)RB_13.IsChecked)
            {
                Point = 200;
                Gran = true;
            }
            if ((bool)RB_Sol.IsChecked)
            {
                Point = 90;
                Gran = false;
            }
            if ((bool)RB_RenSol.IsChecked)
            {
                Point = 180;
                Gran = false;
            }
            if ((bool)RB_Bordlaegger.IsChecked)
            {
                Point = 360;
                Gran = false;
            }
            if ((bool)RB_Dublet.IsChecked)
            {
                Point = 180;
                Gran = false;
            }

            if (Gran)
            {
                if (Udregner.Text == "0")
                {
                    foreach (var Spiller in AnnouncedList)
                    {
                        Spiller.Point += Point;
                    }
                    foreach (var Spiller in IsPlayingList)
                    {
                        Spiller.Point -= Point;
                    }
                }
                else
                {
                    foreach (var Spiller in AnnouncedList)
                    {
                        Spiller.Point -= 2*int.Parse(Udregner.Text)*Point;
                    }
                    foreach (var Spiller in IsPlayingList)
                    {
                        Spiller.Point += 2 * int.Parse(Udregner.Text) * Point;
                    }
                }
            }
            else
            {
                if (Udregner.Text == "0")
                {
                    foreach (var Spiller in AnnouncedList)
                    {
                        Spiller.Point += Point;
                    }
                    foreach (var Spiller in IsPlayingList)
                    {
                        Spiller.Point -= Point/3;
                    }
                }
                else
                {
                    foreach (var Spiller in AnnouncedList)
                    {
                        Spiller.Point -= Point*2*int.Parse(Udregner.Text);
                    }
                    foreach (var Spiller in IsPlayingList)
                    {
                        Spiller.Point += Point*2*int.Parse(Udregner.Text)/3;
                    }
                }
                    

            }
            DataGrid_IsPlaying.Items.Refresh();
            DataGrid_Announced.Items.Refresh();
        }

        private void SpillerNavn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SpillerNavn.Text))
            {
                btn_AddSpiller.IsEnabled = true;
            }
            else
            {
                btn_AddSpiller.IsEnabled = false;
            }
        }

        private void Udregner_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (AnnouncedList.Count != 0)
            {
                if (IsPlayingList.Count != 0)
                {
                    if (!string.IsNullOrWhiteSpace(Udregner.Text))
                    {
                        btn_Udregn.IsEnabled = true;
                    }
                    else
                    {
                        btn_Udregn.IsEnabled = false;
                    }
                }
            }
        }
        private static void NoSelection()
        {
            MessageBox.Show("Vælg venligst en spiller");
        }
    }
}
