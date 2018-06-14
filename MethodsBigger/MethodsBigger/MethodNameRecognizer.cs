using System.Text.RegularExpressions;

namespace MethodsBigger
{
	public class MethodNameRecognizer
	{
		private readonly Regex methodDeclarationRegex;

		public MethodNameRecognizer()
		{
			this.methodDeclarationRegex = new Regex("\\s((?:public)|(?:private)|(?:protected)|(?:internal))(?:\\s(?:(?:static)|(?:virtual)|(?:override)|(?:abstract)))?(?:\\s(?:async))?\\s(?!class)(?:(?:[a-zA-Z_0-9?<>\\[\\]()]|[a-zA-Z_0-9?<>\\[\\]()]\\s[a-z]|,\\s)+?)\\s(\\S+?)(?:<(?:[a-zA-Z_0-9?<>\\[\\]]|,\\s)+?)?\\(", RegexOptions.Compiled);
		}

		public Recognized Recognize(string line)
		{
			var match = this.methodDeclarationRegex.Match(line);

			if (match.Success)
			{
				return new Recognized { Accessibilty = match.Groups[1], Name = match.Groups[2] };
			}
			else
			{
				return null;
			}
		}

		public class Recognized
		{
			public Group Accessibilty { get; set; }
			public Group Name { get; set; }
		}
	}
}
