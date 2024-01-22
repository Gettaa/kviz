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

	// kerdesek.txt feldolgozasa
	public class Kerdes {

		public char Kategoria { get; private set; }
		public string Szoveg { get; private set; }
		public string Helyes { get; private set; }
		public string Rossz1 { get; private set; }
		public string Rossz2 { get; private set; }
		public string[] RandValasz;

		public Kerdes(string sor) {
			string[] cuccok = sor.Split(';');
			Kategoria = cuccok[0].First();
			Szoveg = cuccok[1];
			Helyes = cuccok[2];
			Rossz1 = cuccok[3];
			Rossz2 = cuccok[4];
			RandValasz = new string[3] {Helyes, Rossz1, Rossz2};
			RandValasz = RandValasz.OrderBy(x => Guid.NewGuid()).ToArray();
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