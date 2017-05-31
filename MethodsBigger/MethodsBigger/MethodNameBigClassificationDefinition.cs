using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace MethodsBigger
{
	internal static class MethodNameBigClassificationDefinition
	{
		// This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

		[Export(typeof(ClassificationTypeDefinition))]
		[Name("MethodNameBig")]
		private static ClassificationTypeDefinition typeDefinition;

#pragma warning restore 169
	}
}
