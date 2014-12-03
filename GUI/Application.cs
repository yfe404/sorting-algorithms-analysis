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
			new MainWindow ();
		}
	}
}

