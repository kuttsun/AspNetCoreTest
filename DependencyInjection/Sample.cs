using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Sample1 : ISample
    {
        public string Name { get; } = "Sample1";
    }

    public class Sample2 : ISample
    {
        public string Name { get; } = "Sample2";
    }

    public class Sample3 : ISample
    {
        public string Name { get; } = "Sample3";
    }
}
