
namespace Wotan.Engine
{
    /// <summary>
    /// You have to crank this one by hand.
    /// </summary>
    public class ManualStateTicker : StateTicker
    {
        public override bool IsRunning { get; set; }

        public void PerformOneTick()
        {
            OnTick(new TickEventArgs());
        }
    }
}
