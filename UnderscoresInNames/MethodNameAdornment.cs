using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UnderscoresInNames
{
	internal sealed class MethodNameAdornment : Grid
	{
		public MethodNameAdornment()
		{
			Initialize();

			var platzhalter = "platzhalter";
			Width = platzhalter.Length * 7.2;
			((TextBlock)Children[0]).Text = platzhalter;
		}

		internal MethodNameAdornment(MethodNameTag tag)
		{
			Initialize();

			Update(tag);
		}

		private void Initialize()
		{
			Background = Brushes.Yellow;
			Height = 12;
			Children.Add(new TextBlock
			{
				Margin = new Thickness(0, -3, 0, 0),
				VerticalAlignment = VerticalAlignment.Top,
				FontFamily = new FontFamily("Consolas"),
				FontSize = 13,
			});
		}

		internal void Update(MethodNameTag tag)
		{
			((TextBlock)Children[0]).Text = tag.Name;
			Width = tag.Name.Length * 7.2;
		}
	}
}