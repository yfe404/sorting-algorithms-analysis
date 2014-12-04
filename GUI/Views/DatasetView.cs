using System;

namespace GUI.Views
{
	public class DatasetView : Gtk.Table
	{
		public DatasetView () : base(5, 1, false)
		{
			var verdana = new Pango.FontDescription ();
			verdana.Family = "Verdana";

			var datasetSizeLabel = new Gtk.Label ("Taille");
			datasetSizeLabel.ModifyFont (verdana);
			Attach (datasetSizeLabel, 0, 1, 0, 1);

			var datasetSizeBox = new Gtk.SpinButton (0, 10000000, 1);
			datasetSizeBox.ModifyFont (verdana);
			Attach (datasetSizeBox, 0, 1, 1, 2);

			var datasetOrderLabel = new Gtk.Label ("Ordre");
			datasetOrderLabel.ModifyFont (verdana);
			Attach (datasetOrderLabel, 0, 1, 2, 3);

			var datasetOrderBox = new Gtk.ComboBox (new string[] {"Aleatoire", "Croissant", "Decroissant"});
			datasetOrderBox.ModifyFont (verdana);
			datasetOrderBox.Active = 0;
			Attach (datasetOrderBox, 0, 1, 3, 4);

			var datasetRunButton = new Gtk.Button ("Evaluer");
			datasetRunButton.ModifyFont (verdana);
			Attach (datasetRunButton, 0, 1, 4, 5);
		}


	}
}

