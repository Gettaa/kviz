using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;


namespace kviz {

	// kerdesek.txt feldolgozasa
	public class Kerdes {

		public char Kategoria { get; private set; }
		public bool TobbValasz { get; private set; }
		public string Szoveg { get; private set; }
		public string Valasz1 { get; private set; } // mindig helyes
		public string Valasz2 { get; private set; } // if TobbValasz = true akkor helyes else hamis
		public string Valasz3 { get; private set; } // mindig hamis
		public string[] KevertValaszok { get; private set; }

		public Kerdes(string sor) {
			string[] cuccok = sor.Split(';');
			Kategoria = cuccok[0].First();
			TobbValasz = bool.Parse(cuccok[1]);
			Szoveg = cuccok[2];
			Valasz1 = cuccok[3];
			Valasz2 = cuccok[4];
			Valasz3 = cuccok[5];
			KevertValaszok = new string[] { Valasz1, Valasz2, Valasz3 }.OrderBy(x => Guid.NewGuid()).ToArray();
		}

		public bool HelyesTipp(string input) {
			string lv1 = Valasz1.ToLower();
			string lv2 = Valasz2.ToLower();
			input = input.ToLower();
			if (TobbValasz && (input == lv1 || input == lv2)) return true;
			if (!TobbValasz && input == lv1) return true;
			else return false;
		}
	}

	public class Jatekos {

		// jatekosok.txt feldolgozasa
		public string Nev { get; private set; }
		public int B_Osszes { get; set; }
		public int B_Helyes { get; set; }
		public int C_Osszes { get; set; }
		public int C_Helyes { get; set; }
		public int I_Osszes { get; set; }
		public int I_Helyes { get; set; }

		public Jatekos(string sor) {
			string[] adatok = sor.Split(';');
			Nev = adatok[0];
			B_Osszes = int.Parse(adatok[1]);
			B_Helyes = int.Parse(adatok[2]);
			C_Osszes = int.Parse(adatok[3]);
			C_Helyes = int.Parse(adatok[4]);
			I_Osszes = int.Parse(adatok[5]);
			I_Helyes = int.Parse(adatok[6]);
		}

		public Jatekos(string nev, bool b) {
			Nev = nev;
			B_Osszes = 0;
			B_Helyes = 0;
			C_Osszes = 0;
			C_Helyes = 0;
			I_Osszes = 0;
			I_Helyes = 0;
		}
	}

	public static class Adatok {

		public static List<Kerdes> Kerdesek = new List<Kerdes>();
		public static List<Jatekos> Jatekosok = new List<Jatekos>();

		public static void Betolt() {
			string[] szavakFajl = File.ReadAllLines("kerdesek.txt", Encoding.UTF8);
			foreach (string sor in szavakFajl) Kerdesek.Add(new Kerdes(sor));
			string[] jatekosokFajl = File.ReadAllLines("jatekosok.txt", Encoding.UTF8);
			foreach (string sor in jatekosokFajl) Jatekosok.Add(new Jatekos(sor));
		}

		public static void Ment() {
			List<string> irandoJatekosok = new List<string>();
			Jatekosok.ForEach(s => irandoJatekosok.Add(
				$"{s.Nev};{s.B_Osszes};{s.B_Helyes};{s.C_Osszes};{s.C_Helyes};{s.I_Osszes};{s.I_Helyes}"
			));
			File.WriteAllLines("jatekosok.txt", irandoJatekosok);
		}
	}
}