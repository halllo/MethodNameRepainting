//***************************************************************************
//
//    Copyright (c) Microsoft Corporation. All rights reserved.
//    This code is licensed under the Visual Studio SDK license terms.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//***************************************************************************

using System;
using System.Collections.Generic;
using MethodsReadable.Support;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace MethodsReadable
{
	/// <summary>
	/// Provides color swatch adornments in place of color constants.
	/// </summary>
	/// <remarks>
	/// </remarks>
	internal sealed class SpacingAdornmentTagger : IntraTextAdornmentTagger<SpacingTag, SpacingAdornment>
	{
		internal static ITagger<IntraTextAdornmentTag> GetTagger(IWpfTextView view, Lazy<ITagAggregator<SpacingTag>> colorTagger)
		{
			return view.Properties.GetOrCreateSingletonProperty<SpacingAdornmentTagger>(
				() => new SpacingAdornmentTagger(view, colorTagger.Value));
		}

		private ITagAggregator<SpacingTag> colorTagger;

		private SpacingAdornmentTagger(IWpfTextView view, ITagAggregator<SpacingTag> colorTagger)
			: base(view)
		{
			this.colorTagger = colorTagger;
		}

		public void Dispose()
		{
			this.colorTagger.Dispose();

			base.view.Properties.RemoveProperty(typeof(SpacingAdornmentTagger));
		}

		// To produce adornments that don't obscure the text, the adornment tags
		// should have zero length spans. Overriding this method allows control
		// over the tag spans.
		protected override IEnumerable<Tuple<SnapshotSpan, PositionAffinity?, SpacingTag>> GetAdornmentData(NormalizedSnapshotSpanCollection spans)
		{
			if (spans.Count == 0)
				yield break;

			ITextSnapshot snapshot = spans[0].Snapshot;

			var colorTags = this.colorTagger.GetTags(spans);

			foreach (IMappingTagSpan<SpacingTag> dataTagSpan in colorTags)
			{
				NormalizedSnapshotSpanCollection colorTagSpans = dataTagSpan.Span.GetSpans(snapshot);

				// Ignore data tags that are split by projection.
				// This is theoretically possible but unlikely in current scenarios.
				if (colorTagSpans.Count != 1)
					continue;

				SnapshotSpan adornmentSpan = new SnapshotSpan(colorTagSpans[0].Start, 0);

				yield return Tuple.Create(adornmentSpan, (PositionAffinity?)PositionAffinity.Successor, dataTagSpan.Tag);
			}
		}

		protected override SpacingAdornment CreateAdornment(SpacingTag dataTag, SnapshotSpan span)
		{
			return new SpacingAdornment(dataTag);
		}

		protected override bool UpdateAdornment(SpacingAdornment adornment, SpacingTag dataTag)
		{
			adornment.Update(dataTag);
			return true;
		}
	}
}
