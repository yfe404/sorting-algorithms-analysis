using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using GUI.Algorithms;
using GUI.Models;
using GUI.Views;

namespace GUI
{
	public class MainWindow : Gtk.Window
	{
		const int WIDTH = 800;
		const int HEIGHT = 530;

		public Type[] Algorithms {
			get;
			private set;
		}

		private ResultsPlotView plotView;
		private ResultsTreeView resultsTreeView;
		private DatasetView datasetView;

		public MainWindow () : base ("Resultats")
		{
			// Initialize UI
			SetSizeRequest (WIDTH, HEIGHT);
			Resizable = false;
			ModifyBg (Gtk.StateType.Normal, new Gdk.Color (255, 255, 255));

			var table = new Gtk.Table (10, 10, true);
			Add (table);

			plotView = new ResultsPlotView ();
			table.Attach (plotView, 0, 10, 0, 7);

			datasetView = new DatasetView ();
			table.Attach (datasetView, 0, 2, 7, 10);

			resultsTreeView = new ResultsTreeView ();
			table.Attach (resultsTreeView, 2, 10, 7, 10);

			// Register algorithms
			Algorithms = GetAlgorithms (Assembly.GetExecutingAssembly ());
			foreach (var algorithmType in Algorithms) {
				var algorithm = (SortingStrategy)Activator.CreateInstance (algorithmType);
				resultsTreeView.AddResult(new Result (algorithm));
			}
				
			// Handle events
			resultsTreeView.NodeSelection.Changed += resultsTreeViewSelectionChanged;
			datasetView.DatasetChanged += HandleDatasetChanged;

			// Populate with initial data
			DataSet dataset = new DataSet (0, InitialSort.RANDOM);
			HandleDatasetChanged (dataset);

			ShowAll ();
		}

		private void HandleDatasetChanged (DataSet dataset)
		{
			resultsTreeView.ClearResults ();
			plotView.ClearResults ();

			foreach (var algorithmType in Algorithms) {
				var algorithm = (SortingStrategy)Activator.CreateInstance (algorithmType);
				var result = EvaluateAlgorithm (algorithm, dataset);

				resultsTreeView.AddResult(result);
				plotView.PlotResult (result);
			}
		}

		private void resultsTreeViewSelectionChanged (object sender, EventArgs e)
		{
			Gtk.NodeSelection selection = (Gtk.NodeSelection)sender;

			if (selection.SelectedNode != null) {
				var node = (Models.ResultsTreeNode)selection.SelectedNode;
			}
		}

		private Result EvaluateAlgorithm(SortingStrategy algorithm, DataSet dataset) {
			var result = new Result (algorithm);

			for (int i = 0; i < dataset.size; i++) {
				Sorter sorter = new Sorter ();
				sorter.sortingStrategy = algorithm;

				Probe probe = sorter.Sort (dataset, 0, dataset.size - i);
				result.AddProbe (dataset.size - i, probe);
			}

			return result;
		}

		private Type[] GetAlgorithms (Assembly assembly)
		{
			return assembly.GetTypes ().Where (t => String.Equals (t.BaseType.ToString (), "GUI.Algorithms.SortingStrategy", StringComparison.Ordinal)).ToArray ();
		}
	}
}

