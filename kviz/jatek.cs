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
		public Jatek(Jatekos j, char c) {
			Embi = j;
			Temakor = c;
			Kerdesek = Adatok.Kerdesek
				.Where(k => k.Kategoria == Temakor)
				.OrderBy(k => Guid.NewGuid())
				.Take(10)
				.ToArray();
		}
	}
}
