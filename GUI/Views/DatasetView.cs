using System;

using GUI.Models;

namespace GUI.Views
{
	public delegate void DatasetChangedEventHandler(DataSet dataset);

	public class DatasetView : Gtk.Table
	{
		public event DatasetChangedEventHandler DatasetChanged;

		private Gtk.SpinButton datasetSizeBox;
		private Gtk.ComboBox datasetOrderBox;

		public DatasetView () : base(5, 1, false)
		{
			var verdana = new Pango.FontDescription ();
			verdana.Family = "Verdana";

			var datasetSizeLabel = new Gtk.Label ("Taille");
			datasetSizeLabel.ModifyFont (verdana);
			Attach (datasetSizeLabel, 0, 1, 0, 1);

			datasetSizeBox = new Gtk.SpinButton (0, 500, 1);
			datasetSizeBox.Value = 10;
			datasetSizeBox.ModifyFont (verdana);
			Attach (datasetSizeBox, 0, 1, 1, 2);

			var datasetOrderLabel = new Gtk.Label ("Ordre");
			datasetOrderLabel.ModifyFont (verdana);
			Attach (datasetOrderLabel, 0, 1, 2, 3);

			datasetOrderBox = new Gtk.ComboBox (new string[] {"Croissant", "Decroissant", "Aleatoire"});
			datasetOrderBox.ModifyFont (verdana);
			datasetOrderBox.Active = 0;
			Attach (datasetOrderBox, 0, 1, 3, 4);

			var datasetRunButton = new Gtk.Button ("Evaluer");
			datasetRunButton.ModifyFont (verdana);
			Attach (datasetRunButton, 0, 1, 4, 5);

			datasetRunButton.Clicked += HandleClicked;
		}

		void HandleClicked (object sender, EventArgs e)
		{
			DataSet dataset = new DataSet (datasetSizeBox.ValueAsInt, (InitialSort)datasetOrderBox.Active);
			DatasetChanged (dataset);
		}

	}
}

