using System;

using TGC.MG.Viewer.GameModels;

namespace TGC.MG.Viewer
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            new TGCGame().Run();
        }
    }
}
