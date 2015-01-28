using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using UnderscoresInNames.Support;

namespace UnderscoresInNames
{
	internal sealed class MethodNameTagger : RegexTagger<MethodNameTag>
	{
		internal MethodNameTagger(ITextBuffer buffer)
			: base(buffer, new[] { new Regex(@"\b\w*Test\b", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase) })
		{
		}

		protected override MethodNameTag TryCreateTagForMatch(Match match)
		{
			return new MethodNameTag(match.ToString());
		}
	}
}
