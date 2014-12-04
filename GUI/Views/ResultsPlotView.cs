using System;

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
			line.Title = result.Algorithm;

			foreach (var dataPoint in dataPoints) {
				line.Points.Add (new OxyPlot.DataPoint(dataPoint.Key, dataPoint.Value));
			}

			Model.Series.Add (line);
		}
	}
}

