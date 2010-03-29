using System;

namespace Wotan.Engine
{
    public abstract class StateTicker : IStateTicker
    {
        public event EventHandler<TickEventArgs> Tick;

        private bool running;


        protected virtual void OnTick(TickEventArgs args)
        {
            var h = Tick;
            if (h != null)
                h(this, args);
        }

        public virtual bool IsRunning
        {
            get
            {
                return running;
            }
            set
            {
                running = value;
                OnStateChanged();
            }
        }

        protected virtual void OnStateChanged()
        {
            // base has no implementation.
        }
    }
}
