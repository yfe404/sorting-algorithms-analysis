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

			var probe1 = new Models.Probe ();
			probe1.nbComparisons = 100;

			var probe2 = new Models.Probe ();
			probe2.nbComparisons = 50;

			var probe3 = new Models.Probe ();
			probe2.nbComparisons = 150;

			var result = new Models.Result ("Tri bulle");
			result.AddProbe (1, probe1);
			result.AddProbe (10, probe2);
			result.AddProbe (12, probe3);

			plotView.PlotResult (result);

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

