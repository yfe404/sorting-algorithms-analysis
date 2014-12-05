using System;

using GUI.Models;

namespace GUI.Views
{
	public delegate void VisibilityChangedEventHandler (string algorithmName, bool theoriticalVisible, bool measuredVisible);

	public class ResultsTreeView : Gtk.NodeView
	{
		public event VisibilityChangedEventHandler VisibilityChanged;

		public ResultsTreeView ()
		{
			var theoriticalVisibilityToggled = new Gtk.CellRendererToggle ();
			theoriticalVisibilityToggled.Activatable = true;
			theoriticalVisibilityToggled.Toggled += theoriticalVisibilityHandleToggled;

			var measuredVisibilityToggled = new Gtk.CellRendererToggle ();
			measuredVisibilityToggled.Activatable = true;
			measuredVisibilityToggled.Toggled += measuredVisibilityHandleToggled;

			AppendCustomColumn ("Theorique", theoriticalVisibilityToggled, "active", 0);
			AppendCustomColumn ("Pratique", measuredVisibilityToggled, "active", 1);
			AppendCustomColumn ("Algorithme", new Gtk.CellRendererText (), "text", 2);
			AppendCustomColumn ("Complexite", new Gtk.CellRendererText (), "text", 3);
			AppendCustomColumn ("Comparaisons", new Gtk.CellRendererText (), "text", 4);
			AppendCustomColumn ("Echanges", new Gtk.CellRendererText (), "text", 5);
			AppendCustomColumn ("Copies", new Gtk.CellRendererText (), "text", 6);

			NodeStore = new Gtk.NodeStore (typeof(Models.ResultsTreeNode));
		}

		void theoriticalVisibilityHandleToggled (object o, Gtk.ToggledArgs args)
		{
			var node = (Models.ResultsTreeNode)NodeStore.GetNode (new Gtk.TreePath (args.Path));
			node.TheoriticalVisible = !node.TheoriticalVisible;
			VisibilityChanged (node.Algorithm, node.TheoriticalVisible, node.MeasuredVisible);
		}

		void measuredVisibilityHandleToggled (object o, Gtk.ToggledArgs args)
		{
			var node = (Models.ResultsTreeNode)NodeStore.GetNode (new Gtk.TreePath (args.Path));
			node.MeasuredVisible = !node.MeasuredVisible;
			VisibilityChanged (node.Algorithm, node.TheoriticalVisible, node.MeasuredVisible);
		}

		public void AddResult (Result result)
		{
			NodeStore.AddNode (
				new Models.ResultsTreeNode (
					result.Algorithm.Name,
					result.Algorithm.AsymptoticComplexity.ToString (),
					result.GetSignificantComparisons (),
					result.GetSignificantCopies (),
					result.GetSignificantExchanges ()
				)
			);
		}

		public void ClearResults ()
		{
			NodeStore.Clear ();
		}

		private int AppendCustomColumn (string title, Gtk.CellRenderer cell, params object[] attrs)
		{
			var verdana = new Pango.FontDescription ();
			verdana.Family = "Verdana";

			var label = new Gtk.Label (title);
			label.ModifyFont (verdana);
			label.Show ();

			var column = new Gtk.TreeViewColumn (title, cell, attrs);
			column.Widget = label;

			return AppendColumn (column);
		}
	}
}

