using System;

namespace GUI
{
	public class MainWindow : Gtk.Window
	{
		const int WIDTH = 800;
		const int HEIGHT = 530;

		public MainWindow () : base ("Resultats")
		{
			SetSizeRequest (WIDTH, HEIGHT);
			Resizable = false;
			ModifyBg (Gtk.StateType.Normal, new Gdk.Color (255, 255, 255));

			var table = new Gtk.Table (10, 10, true);
			Add (table);

			var plotView = new Views.ResultsPlotView ();
			table.Attach (plotView, 0, 10, 0, 7);

			var datasetsView = new Views.DatasetView ();
			table.Attach (datasetsView, 0, 2, 7, 10);

			var resultsTreeView = new Views.ResultsTreeView ();
			table.Attach (resultsTreeView, 2, 10, 7, 10);

			resultsTreeView.NodeSelection.Changed += resultsTreeViewSelectionChanged;

			ShowAll ();
		}

		void resultsTreeViewSelectionChanged (object sender, EventArgs e)
		{
			Gtk.NodeSelection selection = (Gtk.NodeSelection)sender;

			if (selection.SelectedNode != null) {
				var node = (Models.ResultsTreeNode)selection.SelectedNode;
			}
		}

//		var model = new OxyPlot.PlotModel ();
//		model.Series.Add (new OxyPlot.Series.FunctionSeries (Math.Exp, 0, 2, 0.1, "BogoSort"));
//		model.Series.Add (new OxyPlot.Series.FunctionSeries (Math.Log, 0, 2, 0.1, "BubbleSort"));
//		var a = new OxyPlot.Series.LineSeries ();
//		a.Points.Add (new OxyPlot.DataPoint (1, 3));
//		a.Points.Add (new OxyPlot.DataPoint (0, 1));
//		model.Series.Add (a);
//
//		plotView.Model = model;
//
//		var store = new Gtk.NodeStore (typeof(Models.ResultsTreeNode));
//		store.AddNode (new Models.ResultsTreeNode ("BogoSort", "O(N)", 10, 20, 30));
//		store.AddNode (new Models.ResultsTreeNode ("BubbleSort", "O(N)", 10, 20, 30));
//		resultsTreeView.NodeStore = store;
//
	}
}

