using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsBigger.Tests
{
	[TestClass]
	public class OnlyMethodNamesAreRecognized
	{
		private (string name, string accessibility) Method(string text)
		{
			var recognized = new MethodNameRecognizer().Recognize(" " + text);
			return (
				name: recognized?.Name.Value,
				accessibility: recognized?.Accessibilty.Value
			);
		}


		[TestMethod] public void Class() => Assert.AreEqual(null, Method("public class Loader<T> where T : class, IModel").name);
		[TestMethod] public void Field() => Assert.AreEqual(null, Method("private readonly Loader<T> mLoader;").name);
		[TestMethod] public void FieldAssignment() => Assert.AreEqual(null, Method("private static readonly ILookup<Type, PropertyInfo> mProperties = typeof(O).GetProperties(BindingFlags.Instance | BindingFlags.Public).ToLookup(pi => pi.PropertyType);").name);
		[TestMethod] public void MethodCall() => Assert.AreEqual(null, Method("var scinternal = sc.Internal();").name);

		[TestMethod] public void Void() => Assert.AreEqual(("ErzeugeDefault", "public"), Method("public void ErzeugeDefault(List<string> strings, IThing thing)"));
		[TestMethod] public void Static() => Assert.AreEqual(("Hallo", "public"), Method("public static void Hallo()"));
		[TestMethod] public void OneGenericParameter() => Assert.AreEqual(("StartWith", "private"), Method("private Loader<T> StartWith<T>(IReadOnlyList<T> objects) where T : class, IModel"));
		[TestMethod] public void OneGenericNullableParameter() => Assert.AreEqual(("StartWith", "private"), Method("private Loader<T> StartWith<T?>(IReadOnlyList<T> objects) where T : class, IModel"));
		[TestMethod] public void TwoGenericParameters() => Assert.AreEqual(("LoadByPseudoId", "protected"), Method("protected Loader<T> LoadByPseudoId<T, T2>(Expression<Func<T, object>> primaryKey, params IEnumerable<int>[] idss) where T : class, IModel"));
		[TestMethod] public void TwoGenericParametersReturned() => Assert.AreEqual("PrepareIds", Method("public LoaderWithPreparedIds<T, TAccumulator> PrepareIds<TAccumulator, T2>(TAccumulator seed, Action<TAccumulator, T> idCollector)").name);
		[TestMethod] public void Async() => Assert.AreEqual("AsyncMethod", Method("public async Task<int> AsyncMethod()").name);
		[TestMethod] public void NullableReturnType() => Assert.AreEqual("Method", Method("public Guid? Method()").name);
		[TestMethod] public void ArrayReturnType() => Assert.AreEqual("Method", Method("public Guid[] Method()").name);
		[TestMethod] public void AsyncNullableReturnType() => Assert.AreEqual("Method", Method("public async Task<Guid?> Method()").name);
		[TestMethod] public void TupleReturn() => Assert.AreEqual("TupleMethod", Method("private async (string name, string accessibility) TupleMethod()").name);
		[TestMethod] public void TupleNullableReturn() => Assert.AreEqual("TupleMethod", Method("private async (string? name, Guid? accessibility) TupleMethod()").name);
		[TestMethod] public void TaskTupleReturn() => Assert.AreEqual("TaskTupleMethod", Method("private async Task<(string name, string accessibility)> TaskTupleMethod()").name);
		[TestMethod] public void TupleInTupleReturn() => Assert.AreEqual("TupleInTupleMethod", Method("private Task<((int i, string s) t1, Task<(f, h)> t2, string t3)> TupleInTupleMethod()").name);
	}
}
