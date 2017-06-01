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

		private readonly Regex methodDeclarationRegex;

		internal MethodNameBig(IClassificationTypeRegistryService registry)
		{
			this.classificationType = registry.GetClassificationType("MethodNameBig");
			this.methodDeclarationRegex = new Regex("(?:(?:public)|(?:private)|(?:static)|(?:protected)|(?:virtual)|(?:override)|(?:abstract))\\s(?:\\S+)\\s(\\S+)\\(", RegexOptions.Compiled);
		}

#pragma warning disable 67

		public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

		public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
		{
			var text = span.GetText();
			var match = this.methodDeclarationRegex.Match(text);

			if (match.Success)
			{
				var methodName = match.Groups[1];
				var result = new List<ClassificationSpan>()
				{
					new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start + methodName.Index, methodName.Length)), this.classificationType)
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
