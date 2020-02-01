using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class ToggleDoor
	{
		public ToggleDoor(int doorId)
		{
			DoorId = doorId;
		}

		public int DoorId { get; }
	}
}
