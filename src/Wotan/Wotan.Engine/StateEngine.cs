using Wotan.Engine.Model;

namespace Wotan.Engine
{
	/// <summary>
	/// Handles managing the State of the game and modiying the state
	/// from Tick to Tick.  
	/// </summary>
	public class StateEngine
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
		public StateEngine(Galaxy galaxy, IStateTicker stateTicker)
		{
		    Galaxy = galaxy;
            stateTicker.Tick += stateTicker_Tick;
		}

        void stateTicker_Tick(object sender, TickEventArgs e)
        {
            Galaxy.Tick();
        }

        public Galaxy Galaxy { get; private set; }
	}
}
