using System;

namespace GUI.Models
{
	[Gtk.TreeNode (ListOnly = true)]
	public class ResultsTreeNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue (Column = 0)]
		public bool Visible;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Algorithm;

		[Gtk.TreeNodeValue (Column = 2)]
		public string Complexity;

		[Gtk.TreeNodeValue (Column = 3)]
		public int Comparisons;

		[Gtk.TreeNodeValue (Column = 4)]
		public int Exchanges;

		[Gtk.TreeNodeValue (Column = 5)]
		public int Copies;

		public ResultsTreeNode (string algorithm, string complexity, int comparisons, int exchanges, int copies)
		{
			Visible = true;
			Algorithm = algorithm;
			Complexity = complexity;
			Comparisons = comparisons;
			Exchanges = exchanges;
			Copies = copies;
		}
	}
}

