using System.Threading;

namespace Wotan.Engine
{
    public class ClockBasedStateTicker : StateTicker
    {

        private const int Period = 1000; // ms

        private readonly Timer timer;
        

        public ClockBasedStateTicker()
        {
            timer = new Timer(state => OnTick(new TickEventArgs()), 
                null, 
                Timeout.Infinite, 
                Period);
        }

        protected override void OnStateChanged()
        {
            timer.Change(IsRunning ? 0 : Timeout.Infinite, Period);
            base.OnStateChanged();
        }
    }
}
