using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class IncrementDeathCount
	{
		public IncrementDeathCount(int numberOfDeaths)
		{
			NumberOfDeaths = numberOfDeaths;
		}

		public int NumberOfDeaths { get; }
	}
}
