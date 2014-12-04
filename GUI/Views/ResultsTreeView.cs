using System;

using GUI.Models;

namespace GUI.Views
{
	public class ResultsTreeView : Gtk.NodeView
	{
		public ResultsTreeView ()
		{
			var visibleCellRenderer = new Gtk.CellRendererToggle ();
			visibleCellRenderer.Activatable = true;
			visibleCellRenderer.Toggled += HandleToggled;

			AppendCustomColumn ("Visible", visibleCellRenderer, "active", 0);
			AppendCustomColumn ("Algorithme", new Gtk.CellRendererText (), "text", 1);
			AppendCustomColumn ("Complexite", new Gtk.CellRendererText (), "text", 2);
			AppendCustomColumn ("Comparaisons", new Gtk.CellRendererText (), "text", 3);
			AppendCustomColumn ("Echanges", new Gtk.CellRendererText (), "text", 4);
			AppendCustomColumn ("Copies", new Gtk.CellRendererText (), "text", 5);

			NodeStore = new Gtk.NodeStore (typeof(Models.ResultsTreeNode));
		}

		void HandleToggled (object o, Gtk.ToggledArgs args)
		{
			var node = (Models.ResultsTreeNode)NodeStore.GetNode (new Gtk.TreePath (args.Path));
			node.Visible = !node.Visible;
		}

		public void AddResult(Result result) {
			NodeStore.AddNode (
				new Models.ResultsTreeNode (
					result.Algorithm.Name,
					result.Algorithm.AsymptoticComplexity.ToString(),
					result.GetSignificantComparisons(),
					result.GetSignificantCopies(),
					result.GetSignificantExchanges()
				)
			);
		}

		public void ClearResults() {
			NodeStore.Clear();
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

