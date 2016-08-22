using System;
using System.Diagnostics;

namespace ReferenceSourceLink {

	public class SymbolInfo {
		public string AssemblyName { set; get; }
		public string IndexId { set; get; }
	}

	public class Navigator {
		private string _baseUrl = null;

		public Navigator(string baseUrl) {
			_baseUrl = baseUrl;
		}

		public string GetUrl(SymbolInfo symbol) {
			var url = _baseUrl + "/" + symbol.AssemblyName + "/a.html#" + Hash.GetMD5Hash(symbol.IndexId, 16);
			return url;
		}
	}
}
