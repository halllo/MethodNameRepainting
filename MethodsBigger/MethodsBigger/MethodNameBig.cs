using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace MethodsBigger
{
	internal class MethodNameBig : IClassifier
	{
		private readonly IClassificationType classificationTypeMethodNameBigPrivate;
		private readonly IClassificationType classificationTypeMethodNameBigPublic;

		private readonly MethodNameRecognizer methodNameRecognizer;

		internal MethodNameBig(ITextBuffer buffer, IClassificationTypeRegistryService registry)
		{
			this.classificationTypeMethodNameBigPrivate = registry.GetClassificationType("MethodNameBigPrivate");
			this.classificationTypeMethodNameBigPublic = registry.GetClassificationType("MethodNameBigPublic");
			this.methodNameRecognizer = new MethodNameRecognizer();
		}

#pragma warning disable 67

		public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

		public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
		{
			var line = span.Snapshot.GetLineFromPosition(span.Start);
			var text = line.GetText();
			var match = this.methodNameRecognizer.Recognize(text);

			if (match != null)
			{
				var classicationType = match.Accessibilty.Value == "public"
					? this.classificationTypeMethodNameBigPublic
					: this.classificationTypeMethodNameBigPrivate;

				var result = new List<ClassificationSpan>()
				{
					new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(line.Start + match.Name.Index, match.Name.Length)), classicationType)
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
