using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsBigger.Tests
{
	[TestClass]
	public class OnlyMethodNamesAreRecognized
	{
		public string MethodName(string text) => new MethodNameRecognizer().Recognize(text)?.Value;

		[TestMethod] public void Class() => Assert.AreEqual(null, MethodName("public class Loader<T> where T : class, IModel"));
		[TestMethod] public void Field() => Assert.AreEqual(null, MethodName("private readonly Loader<T> mLoader;"));
		[TestMethod] public void FieldAssignment() => Assert.AreEqual(null, MethodName("private static readonly ILookup<Type, PropertyInfo> mProperties = typeof(O).GetProperties(BindingFlags.Instance | BindingFlags.Public).ToLookup(pi => pi.PropertyType);"));

		[TestMethod] public void Void() => Assert.AreEqual("ErzeugeDefault", MethodName("public void ErzeugeDefault(List<string> strings, IThing thing)"));
		[TestMethod] public void OneGenericParameter() => Assert.AreEqual("StartWith", MethodName("public Loader<T> StartWith<T>(IReadOnlyList<T> objects) where T : class, IModel"));
		[TestMethod] public void TwoGenericParameters() => Assert.AreEqual("LoadByPseudoId", MethodName("public Loader<T> LoadByPseudoId<T, T2>(Expression<Func<T, object>> primaryKey, params IEnumerable<int>[] idss) where T : class, IModel"));
		[TestMethod] public void TwoGenericParametersReturned() => Assert.AreEqual("PrepareIds", MethodName("public LoaderWithPreparedIds<T, TAccumulator> PrepareIds<TAccumulator, T2>(TAccumulator seed, Action<TAccumulator, T> idCollector)"));
	}
}
