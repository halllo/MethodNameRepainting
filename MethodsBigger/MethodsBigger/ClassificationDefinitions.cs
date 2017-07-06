using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace MethodsBigger
{
	internal static class ClassificationDefinitions
	{
		// This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

		[Export(typeof(ClassificationTypeDefinition))]
		[Name("MethodNameBigPrivate")]
		private static ClassificationTypeDefinition typeDefinitionMethodNameBigPrivate;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name("MethodNameBigPublic")]
		private static ClassificationTypeDefinition typeDefinitionMethodNameBigPublic;

#pragma warning restore 169
	}
}
