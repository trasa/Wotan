using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace Wotan.Engine.Net
{

	public class UniverseConnection : MarshalByRefObject
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public event EventHandler MessagePending;

		private Guid guid;
		private Timer timer;
		private Collection<string> messages = new Collection<string>();

		public UniverseConnection()
		{
			guid = Guid.NewGuid();
			timer = new Timer(new TimerCallback(this.CreateMessage), null, 0, 2000);
		}

		public void DebugMessage(string s)
		{
			log.Debug("Message from " + guid.ToString() + ": " + s);
		}

		private void CreateMessage(object state)
		{
			messages.Add(DateTime.Now.ToString());
			OnMessagePending(new EventArgs());
		}

		protected virtual void OnMessagePending(EventArgs e)
		{
			EventHandler eh = MessagePending;
			if (eh != null)
			{
				eh(this, e);
			}
		}

		public Collection<string> Messages { get { return messages; } }
	}
}
