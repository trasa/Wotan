using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Wotan.Engine.Net;


namespace Wotan.SimpleWinClient
{
	public partial class Form1 : Form
	{
		UniverseConnection conn;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			TcpClientChannel channel = new TcpClientChannel();
			ChannelServices.RegisterChannel(channel, false);

			conn = (UniverseConnection)Activator.GetObject(
				typeof(UniverseConnection),
				"tcp://localhost:8085/UniverseConnection");
			conn.MessagePending += new EventHandler(conn_MessagePending);
			conn.DebugMessage("Hi");
			//for (int i = 0; i < 10; i++)
			//{
			//    conn.DebugMessage(DateTime.Now.ToString());
			//    System.Threading.Thread.Sleep(500);
			//}
		}

		void conn_MessagePending(object sender, EventArgs e)
		{
			textBox1.Text += "MessagePending (" + conn.Messages.Count + ")";
		}
	}
}