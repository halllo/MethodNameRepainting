using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace MethodsBigger
{
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "MethodNameBig")]
	[Name("MethodNameBig")]
	[UserVisible(true)] // This should be visible to the end user
	[Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
	internal sealed class MethodNameBigFormat : ClassificationFormatDefinition
	{
		public MethodNameBigFormat()
		{
			this.DisplayName = "MethodNameBig"; // Human readable version of the name
			this.FontRenderingSize = 25;
		}
	}
}
