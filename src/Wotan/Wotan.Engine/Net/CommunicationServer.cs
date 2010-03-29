using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Wotan.Engine.Settings;

namespace Wotan.Engine.Net
{
	/// <summary>
	/// This class manages the commuication channels for the StateEngine.
	/// </summary>
	public class CommunicationServer
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		/// <summary>
		/// Initializes a new instance of the <see cref="CommunicationServer"/> class.
		/// </summary>
		/// <remarks>This prepares the CommunicationServer to receive and send messages.</remarks>
		public CommunicationServer()
		{
			int port = EngineSettings.Instance.NetworkSettings.Port;
			log.Debug("Listen on Port " + port);
			var c = new TcpChannel(port);
			ChannelServices.RegisterChannel(c);
			RemotingConfiguration.RegisterWellKnownServiceType(new WellKnownServiceTypeEntry(
				typeof(UniverseConnection),
				"UniverseConnection", 
				WellKnownObjectMode.Singleton));
		}	
	}
}
