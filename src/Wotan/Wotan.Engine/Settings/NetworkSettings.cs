using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Wotan.Engine.Settings
{
	/// <summary>
	/// Network-related settings from ConfigurationElement
	/// </summary>
	public class NetworkSettings : ConfigurationElement
	{

		[ConfigurationProperty("Port", IsRequired=true)]
		public int Port
		{
			get { return (int)this["Port"]; }
		}
	}
}
