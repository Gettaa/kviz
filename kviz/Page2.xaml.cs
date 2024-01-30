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

namespace kviz {
	/// <summary>
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class Page2 : Page {

		private int kerdesAllas = 0;
		public Jatek jatek = new Jatek(Page1.ValasztottJatekos, Page1.ValasztottKat);

		public Page2() {
			InitializeComponent();
			updateContent();
		}

		private void tovabb_Click(object sender, RoutedEventArgs e) {
			nextRound();
		}

		private void updateContent() {
			kerdesszam.Content = $"{kerdesAllas+1}/10";
			if (kerdesAllas < 10) {
				Kerdes jelenKerdes = jatek.Kerdesek[kerdesAllas];
				kerdes.Content = jelenKerdes.Szoveg;
				if (jelenKerdes.TobbValasz) {
					valasz1.Visibility = Visibility.Hidden;
					valasz2.Visibility = Visibility.Hidden;
					valasz3.Visibility = Visibility.Hidden;
					valasz1t.Visibility = Visibility.Visible;
					valasz2t.Visibility = Visibility.Visible;
					valasz3t.Visibility = Visibility.Visible;
					valasz1t.Content = jelenKerdes.KevertValaszok[0];
					valasz2t.Content = jelenKerdes.KevertValaszok[1];
					valasz3t.Content = jelenKerdes.KevertValaszok[2];
				}
				else {
					valasz1.Visibility = Visibility.Visible;
					valasz2.Visibility = Visibility.Visible;
					valasz3.Visibility = Visibility.Visible;
					valasz1t.Visibility = Visibility.Hidden;
					valasz2t.Visibility = Visibility.Hidden;
					valasz3t.Visibility = Visibility.Hidden;
					valasz1.Content = jelenKerdes.KevertValaszok[0];
					valasz2.Content = jelenKerdes.KevertValaszok[1];
					valasz3.Content = jelenKerdes.KevertValaszok[2];
				}
			}
		}

		private void nextRound() {
			if (kerdesAllas < 9) {
				kerdesAllas++;
				updateContent();
			}
		}
	}
}
