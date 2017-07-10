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

using System.Collections.Generic;
using System.Text.RegularExpressions;
using MethodsReadable.Support;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;

namespace MethodsReadable
{
	/// <summary>
	/// Determines which spans of text likely refer to color values.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This is a data-only component. The tagging system is a good fit for presenting data-about-text.
	/// The <see cref="SpacingAdornmentTagger"/> takes color tags produced by this tagger and creates corresponding UI for this data.
	/// </para>
	/// <para>
	/// This class is a sample usage of the <see cref="RegexTagger{T}"/> utility base class.
	/// </para>
	/// </remarks>
	internal sealed class SpacingTagger : RegexTagger<SpacingTag>
	{
		internal SpacingTagger(ITextBuffer buffer)
			: base(buffer, new[] { new Regex("((?:public)|(?:private)|(?:protected)|(?:internal))(?:\\s(?:(?:static)|(?:virtual)|(?:override)|(?:abstract)))?\\s(?!class)(?:(?:\\S|,\\s)+?)\\s(\\S+?)(?:<(?:\\S|,\\s)+?)?\\(", RegexOptions.Compiled) })
		{
		}

		protected override IEnumerable<TagSpan<SpacingTag>> TryCreateTagForMatch(SnapshotPoint lineStart, Match match)
		{
			var methodName = match.Groups[2];
			var methodNameStart = lineStart + methodName.Index;

			var caseSwitches = DissectCamelCase(methodName.Value);
			foreach (var caseSwitch in caseSwitches)
			{
				var span = new SnapshotSpan(methodNameStart + caseSwitch, 1);
				var tag = new SpacingTag(string.Empty);
				var tagspan = new TagSpan<SpacingTag>(span, tag);
				yield return tagspan;
			}
		}

		internal static IEnumerable<int> DissectCamelCase(string name)
		{
			for (int i = 0; i < name.Length - 1; i++)
			{
				var current = name[i];
				var next = name[i + 1];

				if (
					(char.IsLower(current) && char.IsUpper(next))
					||
					(!char.IsDigit(current) && char.IsDigit(next))
					||
					(char.IsDigit(current) && !char.IsDigit(next))
					)
				{
					yield return i + 1;
				}
			}
		}
	}
}
