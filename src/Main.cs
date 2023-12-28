﻿using DotFeather;
using Sukiteto;
using SukiTeto;

DF.Window.Start += () =>
{
    DF.Window.Title = "Sukiteto";
    DF.Window.Size = (640, 480);
    DF.Root.Scale *= 2;
    
    Global.Initialize();
};

return DF.Run<TitleScene>();
