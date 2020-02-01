using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class OxygenCritical
	{
		public OxygenCritical(bool isCritical)
		{
			IsCritical = isCritical;
		}

		public bool IsCritical { get; }
	}
}
