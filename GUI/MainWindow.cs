using System;

namespace GUI
{
	public class MainWindow : Gtk.Window
	{
		public MainWindow () : base ("Window")
		{
			SetSizeRequest (600, 400);

			var vpane = new Gtk.VPaned ();
			Add (vpane);

			var plotView = new OxyPlot.GtkSharp.PlotView ();
			plotView.SetSizeRequest (600, 200);
			vpane.Add1 (plotView);

			var resultsTreeView = new Views.ResultsTreeView ();
			vpane.Add2 (resultsTreeView);

			resultsTreeView.NodeSelection.Changed += resultsTreeViewSelectionChanged;

			// plotView configuration
			var model = new OxyPlot.PlotModel();
			model.Series.Add (new OxyPlot.Series.FunctionSeries (Math.Exp, 0, 2, 0.1, "BogoSort"));
			model.Series.Add (new OxyPlot.Series.FunctionSeries (Math.Log, 0, 2, 0.1, "BubbleSort"));

			plotView.Model = model;

			var store = new Gtk.NodeStore (typeof(Models.ResultsTreeNode));
			store.AddNode (new Models.ResultsTreeNode ("BogoSort", 10, 20, 30));
			store.AddNode (new Models.ResultsTreeNode ("BubbleSort", 10, 20, 30));

			resultsTreeView.NodeStore = store;

			ShowAll ();
		}

		void resultsTreeViewSelectionChanged (object sender, EventArgs e)
		{
			Gtk.NodeSelection selection = (Gtk.NodeSelection)sender;

			if (selection.SelectedNode != null) {
				var node = (Models.ResultsTreeNode)selection.SelectedNode;
			}
		}
	}
}

