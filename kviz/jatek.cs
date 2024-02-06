using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace kviz {
	public class Jatek {

		public Jatekos Embi {  get; private set; }
		public char Temakor { get; private set; }
		public Kerdes[] Kerdesek { get; private set; }
		public int KerdesAllas { get; private set; } = 1;
		public int JoTipp { get; private set; } = 0;
		public int RosszTipp { get; private set; } = 0;
		public Kerdes JelenKerdes() { return Kerdesek[KerdesAllas-1]; }
		private bool gameOver = false;
		private bool saved = false;

		public Jatek(Jatekos j, char c, string lang) {
			Embi = j;
			Temakor = c;
			Kerdesek = lang switch {
				"en" => Adatok.KerdesekEN.Where(k => k.Kategoria == Temakor).OrderBy(k => Guid.NewGuid()).Take(10).ToArray(),
				"de" => Adatok.KerdesekDE.Where(k => k.Kategoria == Temakor).OrderBy(k => Guid.NewGuid()).Take(10).ToArray(),
				_ => Adatok.Kerdesek.Where(k => k.Kategoria == Temakor).OrderBy(k => Guid.NewGuid()).Take(10).ToArray(),
			};
		}
		
		public void checkGameOver() {
			if (!gameOver && (JoTipp + RosszTipp == 10)) gameOver = true;
			if (gameOver && !saved) {
				switch (Temakor) {
					case 'b':
						Embi.B_Osszes += 10;
						Embi.B_Helyes += JoTipp;
						break;
					case 'i':
						Embi.I_Osszes += 10;
						Embi.I_Helyes += JoTipp;
						break;
					case 'c':
						Embi.C_Osszes += 10;
						Embi.C_Helyes += JoTipp;
						break;
					default: break;
				}
				Adatok.Ment();
				saved = true;
			}
		}

		public void Next(string szoveg) {
			if (!gameOver && JelenKerdes().HelyesTipp(szoveg)) JoTipp++;
			RosszTipp = KerdesAllas++ - JoTipp;
			if (KerdesAllas > 10) KerdesAllas = 10;
			checkGameOver();
			Trace.WriteLine($"Jotipp: {JoTipp} Rossztipp: {RosszTipp} Kerdesallas: {KerdesAllas}");
		}

		public void Next(List<string> szovegek) {
			if (!gameOver && szovegek.Where(s => JelenKerdes().KevertValaszok.Contains(s)).Count() == 2) JoTipp++;
			RosszTipp = KerdesAllas++ - JoTipp;
			if (KerdesAllas > 10) KerdesAllas = 10;
			checkGameOver() ;
			Trace.WriteLine($"Jotipp: {JoTipp} Rossztipp: {RosszTipp} Kerdesallas: {KerdesAllas}");
		}
	}
}
