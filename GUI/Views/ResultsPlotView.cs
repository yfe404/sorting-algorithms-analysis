using System;
using GUI.Algorithms;

namespace GUI.Views
{
	public class ResultsPlotView : OxyPlot.GtkSharp.PlotView
	{
		public ResultsPlotView ()
		{
			ModifyBg (Gtk.StateType.Normal, new Gdk.Color (255, 255, 255));

			Model = new OxyPlot.PlotModel ();
		}

		public void PlotResult (Models.Result result)
		{
			var dataPoints = result.GetDataPoints ();
			var line = new OxyPlot.Series.LineSeries ();
			line.Title = result.Algorithm.Name;
			line.Tag = "Measured";

			foreach (var dataPoint in dataPoints) {
				line.Points.Add (new OxyPlot.DataPoint (dataPoint.Key, dataPoint.Value));
			}

			Model.Series.Add (line);
			Model.InvalidatePlot (true);
		}

		public void PlotTheoritical (SortingStrategy algorithm)
		{
			// TODO
//			var dataPoints = result.GetDataPoints ();
			var line = new OxyPlot.Series.LineSeries ();
			line.Title = algorithm.Name + "(theorique)";
			line.Tag = "Theoritical";
		}

		public void ClearResults ()
		{
			Model.Series.Clear ();
		}
	}
}

