using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class LogEvent
	{
		public LogEvent(string message)
		{
			Message = message;
		}

		public string Message { get; }
	}
}
