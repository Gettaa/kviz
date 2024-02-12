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
using System.Diagnostics;

namespace kviz {
	public partial class Page2 : Page {

		public static Jatek jatek = new Jatek(Page1.ValasztottJatekos, Page1.ValasztottKat, Page1.lang);
		private List<RadioButton> radioButtons = [];
		private List<CheckBox> checkBoxes = [];

		public Page2() {
			InitializeComponent();
			radioButtons.Add(valasz1); radioButtons.Add(valasz2); radioButtons.Add(valasz3);
			checkBoxes.Add(valasz1t); checkBoxes.Add(valasz2t); checkBoxes.Add(valasz3t);
			updateContent();
		}

		private void tovabb_Click(object sender, RoutedEventArgs e) {
			Next();
			updateContent();
		}

		private void Next() {
			var cb = checkBoxes.Where(c => c.IsChecked == true);
			var rb = radioButtons.Where(c => c.IsChecked == true);
			if (cb.Any() && jatek.JelenKerdes().TobbValasz) jatek.Next(cb.Select(c => c.Content.ToString()).ToList());
			if (rb.Any() && !jatek.JelenKerdes().TobbValasz) jatek.Next(rb.Select(c => c.Content.ToString()).First());
			else Console.WriteLine("nincs kijelolve");
			checkBoxes.ForEach(c => c.IsChecked = false);
			radioButtons.ForEach(r => r.IsChecked = false);
			if (jatek.saved) {
				Page3 page3 = new();
				NavigationService.Navigate(page3);
			}
			
		}

		private void updateContent() {
			kerdesszam.Content = $"{jatek.KerdesAllas}/10";
			kerdes.Text = jatek.JelenKerdes().Szoveg;
			if (jatek.JelenKerdes().TobbValasz) {
				radioButtons.ForEach(r => r.Visibility = Visibility.Hidden);
				checkBoxes.ForEach(c => c.Visibility = Visibility.Visible);
				for (int i = 0; i < 3; i++) {
					checkBoxes[i].Content = jatek.JelenKerdes().KevertValaszok[i];
				}
			}
			else {
				radioButtons.ForEach(r => r.Visibility = Visibility.Visible);
				checkBoxes.ForEach(c => c.Visibility = Visibility.Hidden);
				for (int i = 0; i < 3; i++) {
					radioButtons[i].Content = jatek.JelenKerdes().KevertValaszok[i];
				}
			}
		}
	}
}
