using System;
using Wotan.Engine;
using Wotan.Engine.Factories;

namespace Wotan.Runner
{
	class Program
	{
		static void Main()
		{
			try
			{
                // set up engine:
			    new StateEngine(new GalaxyFactory().Create(), new ClockBasedStateTicker());

                // initialize communications after the engine is ready.

                // now we're ready for messages.
				Console.WriteLine("[Press Enter to Exit Runner]");
				Console.ReadLine();
			}
			catch (Exception e)
			{
                Console.WriteLine("Exception:");
				Console.WriteLine(e.ToString());
                Console.WriteLine("[Press Enter to Exit Runner]");
				Console.ReadLine();
			}
		}
	}
}
