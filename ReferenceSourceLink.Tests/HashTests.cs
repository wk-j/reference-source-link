using NUnit.Framework;
using FluentAssertions;

namespace ReferenceSourceLink.Tests {
	public class HashTests {
		[Test]
		public void TestHash() {
			var symbolId = "T:Microsoft.CodeAnalysis.CSharp.Symbols.SourceNamedTypeSymbol";
			var bytes = Hash.GetMD5Hash(symbolId, 16);
			bytes.Should().Be("a7aec3faae7fe65b");
		}

		[Test]
		public void TestMethod()
		{
			var id = "T:Microsoft.Win32.SafeHandles.SafeFileHandle";
			var info = new SymbolInfo { IndexId = id, AssemblyName = "mscorlib" };
			var navigator = new Navigator("http://referencesource.microsoft.com");
			var rs = navigator.GetUrl(info);
			rs.Should().Be("http://referencesource.microsoft.com/mscorlib/a.html#9b08210f3be75520");
		}
	}
}
