﻿using POP_40_2016.Model;
using POP_40_2016.utill;
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
using System.Windows.Shapes;

namespace POP_SF_40_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void PrijaviSe(object sender, RoutedEventArgs e)
        {
            var korisnici = Projekat.Instance.Korisnik;
            foreach (var k in korisnici)
            {
                var korIme = tbIme.Text.Trim();
                var lozinka = pfLozinka.Password;
                if (korIme == "" || lozinka == "")
                {
                    MessageBox.Show("Polja za unos su ostala prazna. Unesite sve podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if(korIme == k.KorisnickoIme && lozinka == k.Lozinka)
                {
                    //Hide();
                    var glPMeni = new GlavniMeniWindow(k.TipKorisnika);
                    this.Close();
                    glPMeni.ShowDialog();
                    return;
                }

            }
            MessageBox.Show("Pogresno uneti podaci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            return;

        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
