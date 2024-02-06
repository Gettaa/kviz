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

namespace kviz
{
    public partial class Page3 : Page {

        private Jatek jatek = Page2.jatek;
        public Page3() {
            InitializeComponent();
            jatekeredmenytema.Content = $"A játék eredménye ({
                jatek.Temakor switch {
				    'b' => "Biológia",
				    'c' => "Csillagászat",
				    'i' => "Irodalom",
				    _ => "téma"
			}}):";
            neveredmenyei.Content = $"{jatek.Embi.Nev} eddigi eredményei:";
            fillCurrentStats();
            fillAlltimeStats();
        }

        private void fillCurrentStats() {
            foreach (var kerdes in jatek.Kerdesek) {
                kerdesosszeg.Items.Add($"Kérdés: {kerdes.Szoveg} --- Helyes válasz(ok): {(kerdes.TobbValasz ? $"{kerdes.Valasz1}, {kerdes.Valasz2}" : kerdes.Valasz1)}");
            }
        }

        private void fillAlltimeStats() {
            eddigieredmeny.Items.Add($"Biológia témakörben eddigi eredmény: {jatek.Embi.B_Helyes}/{jatek.Embi.B_Osszes}");
            eddigieredmeny.Items.Add($"Csillagászat témakörben eddigi eredmény: {jatek.Embi.C_Helyes}/{jatek.Embi.C_Osszes}");
            eddigieredmeny.Items.Add($"Irodalom témakörben eddigi eredmény: {jatek.Embi.I_Helyes}/{jatek.Embi.I_Osszes}");
        }
    }
}
