using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class DoorUpdated
	{
		public DoorUpdated(int doorId, bool opened)
		{
			DoorId = doorId;
			Opened = opened;
		}

		public int DoorId { get; }
		public bool Opened { get; }
	}
}
