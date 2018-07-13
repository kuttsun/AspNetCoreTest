using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Sample1 : ISample
    {
        public string Hoge { get; set; } = "";
    }

    public class Sample2 : ISample
    {
        public string Hoge { get; set; } = "";
    }

    public class Sample3 : ISample
    {
        public string Hoge { get; set; } = "";
    }
}
