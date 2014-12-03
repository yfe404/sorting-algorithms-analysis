using System;

namespace GUI.Views
{
	public class ResultsTreeView : Gtk.NodeView
	{
		public ResultsTreeView ()
		{
			AppendColumn ("Visible", new Gtk.CellRendererToggle (), "active", 0);
			AppendColumn ("Algorithme", new Gtk.CellRendererText (), "text", 1);
			AppendColumn ("Dataset", new Gtk.CellRendererText (), "text", 2);
			AppendColumn ("Comparaisons", new Gtk.CellRendererText (), "text", 3);
			AppendColumn ("Echanges", new Gtk.CellRendererText (), "text", 4);
			AppendColumn ("Copies", new Gtk.CellRendererText (), "text", 5);
		}
	}
}

