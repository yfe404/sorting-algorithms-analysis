using System;

namespace GUI
{
	public class Application
	{
		public static void Main ()
		{
			Gtk.Application.Init ();
			new Application ();
			Gtk.Application.Run ();
		}

		public Application ()
		{
			Gtk.Window window = new Gtk.Window ("Comparaison algorithmes");
			window.SetSizeRequest (500,200);

			Gtk.VPaned vpane = new Gtk.VPaned ();
			window.Add (vpane);

			window.ShowAll ();
		}
	}
}

