using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceSourceLink
{
    public class Measure : IDisposable
    {
        private Stopwatch stopwatch = Stopwatch.StartNew();
        private string title;

        public static IDisposable Time(string title)
        {
            return new Measure(title);
        }

        private Measure(string title)
        {
            this.title = title;
        }

        public void Dispose()
        {
            Debug.WriteLine(title + ": " + stopwatch.Elapsed);
        }
    }
}
