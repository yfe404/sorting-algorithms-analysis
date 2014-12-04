using System;

namespace GUI.Views
{
	public class ResultsPlotView : OxyPlot.GtkSharp.PlotView
	{
		public ResultsPlotView ()
		{
			ModifyBg (Gtk.StateType.Normal, new Gdk.Color (255, 255, 255));
		}
	}
}

