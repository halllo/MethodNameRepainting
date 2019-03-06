using System.Windows.Controls;
using System.Windows.Media;

namespace MethodsReadable
{
	internal sealed class SpacingAdornment : TextBlock
	{
		internal SpacingAdornment(SpacingTag spacingTag)
		{
			this.Width = 5;
			this.Height = 5;
			this.Text = string.Empty;
			this.Background = Brushes.Transparent;
		}

		internal void Update(SpacingTag spacingTag)
		{
		}
	}
}
