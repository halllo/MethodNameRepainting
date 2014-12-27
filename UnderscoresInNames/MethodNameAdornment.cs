using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UnderscoresInNames
{
	internal sealed class MethodNameAdornment : TextBlock
	{
		public MethodNameAdornment()
		{
			Background = Brushes.Yellow;
			VerticalAlignment = VerticalAlignment.Top;
			FontFamily = new FontFamily("Consolas");
			FontSize = 13;
			Width = 60;
			Height = 12;
			Text = "platzhalter";
		}

		internal MethodNameAdornment(MethodNameTag tag)
			: this()
		{
			Update(tag);
		}

		internal void Update(MethodNameTag tag)
		{
			this.Text = tag.Name;
		}
	}
}