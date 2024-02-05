using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text;

namespace kviz {
	public class Jatek {

		public Jatekos Embi {  get; private set; }
		public char Temakor { get; private set; }
		public Kerdes[] Kerdesek { get; private set; }
		public int KerdesAllas { get; private set; } = 0;
		public int JoTipp { get; private set; } = 0;
		public int RosszTipp { get; private set; } = 0;
		public Kerdes JelenKerdes() { return Kerdesek[KerdesAllas]; }

		public Jatek(Jatekos j, char c) {
			Embi = j;
			Temakor = c;
			Kerdesek =
				Adatok.Kerdesek
				.Where(k => k.Kategoria == Temakor)
				.OrderBy(k => Guid.NewGuid())
				.Take(10)
				.ToArray()
			;
		}

		public void Next(string szoveg) {
			if (KerdesAllas < 9 && Kerdesek[KerdesAllas++].HelyesTipp(szoveg)) JoTipp++;
			RosszTipp = KerdesAllas - JoTipp;
			Console.WriteLine($"Jotipp: {JoTipp} Rossztipp : {RosszTipp} Kerdesallas: {KerdesAllas}");
		}

		public void Next(List<string> szovegek) {
			bool j = true;
			if (KerdesAllas < 9) {
				foreach (string s in szovegek) if (!JelenKerdes().KevertValaszok.Contains(s)) j = false;
				if (j) JoTipp++;
				KerdesAllas++;
			}
			RosszTipp = KerdesAllas - JoTipp;
			Console.WriteLine($"Jotipp: {JoTipp} Rossztipp : {RosszTipp} Kerdesallas: {KerdesAllas}");
		}
	}
}
