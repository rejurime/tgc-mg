﻿using System;

using TGC.MG.Viewer.GameModels;

namespace TGC.MG.Viewer
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TGCGame())
                game.Run();
        }
    }
}
