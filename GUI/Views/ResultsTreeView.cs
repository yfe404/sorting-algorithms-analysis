using System;

namespace GUI.Views
{
	public class ResultsTreeView : Gtk.NodeView
	{
		public ResultsTreeView ()
		{
			AppendCustomColumn ("Visible", new Gtk.CellRendererToggle (), "active", 0);
			AppendCustomColumn ("Algorithme", new Gtk.CellRendererText (), "text", 1);
			AppendCustomColumn ("Complexite", new Gtk.CellRendererText (), "text", 2);
			AppendCustomColumn ("Comparaisons", new Gtk.CellRendererText (), "text", 3);
			AppendCustomColumn ("Echanges", new Gtk.CellRendererText (), "text", 4);
			AppendCustomColumn ("Copies", new Gtk.CellRendererText (), "text", 5);
		}

		private int AppendCustomColumn(string title, Gtk.CellRenderer cell, params object[] attrs) {
			var verdana = new Pango.FontDescription ();
			verdana.Family = "Verdana";

			var label = new Gtk.Label (title);
			label.ModifyFont (verdana);
			label.Show ();

			var column = new Gtk.TreeViewColumn(title, cell, attrs);
			column.Widget = label;

			return AppendColumn (column);
		}
	}
}

