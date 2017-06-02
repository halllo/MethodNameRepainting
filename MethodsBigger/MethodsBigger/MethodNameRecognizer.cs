using System.Text.RegularExpressions;

namespace MethodsBigger
{
	public class MethodNameRecognizer
	{
		private readonly Regex methodDeclarationRegex;

		public MethodNameRecognizer()
		{
			this.methodDeclarationRegex = new Regex("(?:(?:public)|(?:private)|(?:static)|(?:protected)|(?:internal)|(?:virtual)|(?:override)|(?:abstract))\\s(?!class)(?:(?:\\S|,\\s)+?)\\s(\\S+?)(?:<(?:\\S|,\\s)+?)?\\(", RegexOptions.Compiled);
		}

		public Group Recognize(string line)
		{
			var match = this.methodDeclarationRegex.Match(line);

			if (match.Success)
			{
				return match.Groups[1];
			}
			else
			{
				return null;
			}
		}
	}
}
