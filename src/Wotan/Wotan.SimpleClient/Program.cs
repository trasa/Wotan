using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Wotan.Engine.Net;

namespace Wotan.SimpleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpClientChannel channel = new TcpClientChannel();
			ChannelServices.RegisterChannel(channel, false);

			UniverseConnection conn = (UniverseConnection)Activator.GetObject(
				typeof(UniverseConnection),
				"tcp://localhost:8085/UniverseConnection");

			conn.DebugMessage("Hi");
			for (int i = 0; i < 10; i++)
			{
				conn.DebugMessage(DateTime.Now.ToString());
				System.Threading.Thread.Sleep(500);
			}
		}
	}
}
