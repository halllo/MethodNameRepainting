using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;

namespace UnderscoresInNames
{
	[Export(typeof(ITaggerProvider))]
	[ContentType("text")]
	[TagType(typeof(MethodNameTag))]
	internal sealed class MethodNameTaggerProvider : ITaggerProvider
	{
		public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
		{
			if (buffer == null)
				throw new ArgumentNullException("buffer");

			return buffer.Properties.GetOrCreateSingletonProperty<MethodNameTagger>(() => new MethodNameTagger(buffer)) as ITagger<T>;
		}
	}
}
