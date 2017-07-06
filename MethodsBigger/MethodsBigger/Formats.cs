using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace MethodsBigger
{
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "MethodNameBigPrivate")]
	[Name("MethodNameBigPrivate")]
	[UserVisible(true)] // This should be visible to the end user
	[Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
	internal sealed class MethodNameBigPrivateFormat : ClassificationFormatDefinition
	{
		public MethodNameBigPrivateFormat()
		{
			this.DisplayName = "MethodNameBigPrivate"; // Human readable version of the name
			this.FontRenderingSize = 25;
			this.ForegroundOpacity = 0.75;
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "MethodNameBigPublic")]
	[Name("MethodNameBigPublic")]
	[UserVisible(true)] // This should be visible to the end user
	[Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
	internal sealed class MethodNameBigPublicFormat : ClassificationFormatDefinition
	{
		public MethodNameBigPublicFormat()
		{
			this.DisplayName = "MethodNameBigPublic"; // Human readable version of the name
			this.FontRenderingSize = 25;
		}
	}
}
