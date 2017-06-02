using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace MethodsBigger
{
	internal class MethodNameBig : IClassifier
	{
		private readonly IClassificationType classificationType;

		private readonly MethodNameRecognizer methodNameRecognizer;

		internal MethodNameBig(IClassificationTypeRegistryService registry)
		{
			this.classificationType = registry.GetClassificationType("MethodNameBig");
			this.methodNameRecognizer = new MethodNameRecognizer();
		}

#pragma warning disable 67

		public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

		public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
		{
			var text = span.GetText();
			var match = this.methodNameRecognizer.Recognize(text);

			if (match != null)
			{
				var result = new List<ClassificationSpan>()
				{
					new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start + match.Index, match.Length)), this.classificationType)
				};

				return result;
			}
			else
			{
				return new List<ClassificationSpan>();
			}
		}
	}
}
