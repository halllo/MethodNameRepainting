using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderscoresInNames;

namespace Tests
{
	[TestClass]
	public class UnCamelCaseTests
	{
		[TestMethod]
		public void Samples()
		{
			Assert.AreEqual("Hallo_Welt", MethodNameTag.UnCamelCase("HalloWelt"));
			Assert.AreEqual("Internals_Visible_To", MethodNameTag.UnCamelCase("InternalsVisibleTo"));
		}

		[TestMethod]
		public void LangerMethodenname_100000x()
		{
			for (int i = 0; i < 100000; i++)
			{
				Assert.AreEqual("Internals_Visible_To_Internals_Visible_To_Internals_Visible_To_Internals_Visible_To_Internals_Visible_To", MethodNameTag.UnCamelCase("InternalsVisibleToInternalsVisibleToInternalsVisibleToInternalsVisibleToInternalsVisibleTo"));
			}
		}
	}
}
