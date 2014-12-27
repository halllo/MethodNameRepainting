using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using UnderscoresInNames.Support;

namespace UnderscoresInNames
{
	internal sealed class MethodNameAdornmentTagger : IntraTextAdornmentTagTransformer<MethodNameTag, MethodNameAdornment>
	{
		internal static ITagger<IntraTextAdornmentTag> GetTagger(IWpfTextView view, Lazy<ITagAggregator<MethodNameTag>> colorTagger)
		{
			return view.Properties.GetOrCreateSingletonProperty<MethodNameAdornmentTagger>(
				() => new MethodNameAdornmentTagger(view, colorTagger.Value));
		}

		private MethodNameAdornmentTagger(IWpfTextView view, ITagAggregator<MethodNameTag> tagger)
			: base(view, tagger)
		{
		}

		public override void Dispose()
		{
			base.view.Properties.RemoveProperty(typeof(MethodNameAdornmentTagger));
		}

		protected override MethodNameAdornment CreateAdornment(MethodNameTag tag, SnapshotSpan span)
		{
			return new MethodNameAdornment(tag);
		}

		protected override bool UpdateAdornment(MethodNameAdornment adornment, MethodNameTag tag)
		{
			adornment.Update(tag);
			return true;
		}
	}
}
