using Microsoft.VisualStudio.Text.Tagging;

namespace UnderscoresInNames
{
	internal class MethodNameTag : ITag
	{
		internal MethodNameTag(string name)
		{
			this.Name = name;
		}

		internal readonly string Name;
	}
}
