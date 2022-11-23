using Formula1.Core;
using Formula1.Core.Contracts;
using Formula1.Models.Entities;

namespace Formula1
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
