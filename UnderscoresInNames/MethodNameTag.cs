using System.Linq;
using Microsoft.VisualStudio.Text.Tagging;

namespace UnderscoresInNames
{
	internal class MethodNameTag : ITag
	{
		internal MethodNameTag(string name)
		{
			Name = name;
		}

		internal readonly string Name;

		internal static string UnCamelCase(string name)
		{
			return string.Concat(name.Zip((name + " ").Skip(1), (c, n) => new { c, n }).SelectMany(x => char.IsLower(x.c) && char.IsUpper(x.n) ? new[] { x.c, '_' } : new[] { x.c }));
		}
	}
}
