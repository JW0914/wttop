using System;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui;
using wttop.Widgets.Common;
using Mono.Terminal;
using wttop.Helpers;

namespace wttop.Widgets {
    
    public class MemoryGraph : Widget
    { 
        Label details;
        
        Bar bar;
        
        ISystemInfo systemInfo;

        public MemoryGraph(string text, IServiceProvider serviceProvider) : base(text)
        {
            systemInfo = serviceProvider.GetService<ISystemInfo>();
            DrawWidget();
        }

        void DrawWidget()
        {
            Label title = new Label("Memory usage: ")
            {
                X = 1,
                Y = 2
            };
            
            bar = new Bar(Color.Red, Color.DarkGray)
            {
                X = Pos.Right(title),
                Y = 2,
                Width = Dim.Percent(30),
                Height= Dim.Sized(1)
            };

            details = new Label(string.Empty)
            {
                X = Pos.Left(bar) + 1,
                Y = Pos.Bottom(bar)
            };
           
            Add(title);
            Add(bar);
            Add(details);
        }
        
        public override bool Update(MainLoop MainLoop)
        {
            var memoryUsage = systemInfo.GetMemoryUsage();
            bar.Update(MainLoop, memoryUsage.PercentageUsed);
            details.Text = $"{memoryUsage.AvailableGB} GB available";
            return true;
        }
    }
}