using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wotan.Engine.Settings
{
	/// <summary>
	/// Contains settings applicable to the State Engine.  Read from app.config.
	/// </summary>
	public class EngineSettings : ConfigurationSection
	{

		private static EngineSettings instance = ConfigurationManager.GetSection("Wotan.Engine") as EngineSettings;

		
		/// <summary>
		/// Gets the instance of EngineSettings for this application.
		/// </summary>
		public static EngineSettings Instance { get { return instance; } }


		/// <summary>
		/// Gets or sets a value indicating whether we show the StateTick debug messages.
		/// </summary>
		/// <value><c>true</c> if you want the messages; otherwise, <c>false</c>.</value>
		/// <remarks>These messages are generated per State Tick, so there will be a LOT of them.</remarks>
		[ConfigurationProperty("ShowStateTickDebug", DefaultValue = false, IsRequired = false)]
		public bool ShowStateTickDebug
		{
			get
			{
				return (bool)this["ShowStateTickDebug"];
			}
			set { this["ShowStateTickDebug"] = value; }
		}


		/// <summary>
		/// Gets or sets the number of milliseconds between StateTick timer events.
		/// </summary>
		/// <value>milliseconds for the StateTick timer.</value>
		/// <remarks>If no value is provided in the configuration file then the system defaults to 1000 ms.</remarks>
		[ConfigurationProperty("StateTickMs", DefaultValue=1000, IsRequired=false)]
		public int StateTickMs
		{
			get
			{
				return (int)this["StateTickMs"];
			}
			set { this["StateTickMs"] = value; }
		}

		[ConfigurationProperty("Network")]
		public NetworkSettings NetworkSettings
		{
			get { return (NetworkSettings)this["Network"]; }
		}
	}
}
