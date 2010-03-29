using System;

namespace Wotan.Engine
{
    public interface IStateTicker
    {
        event EventHandler<TickEventArgs> Tick;

        bool IsRunning { get; set; }
    }


    public class TickEventArgs : EventArgs{}
}
