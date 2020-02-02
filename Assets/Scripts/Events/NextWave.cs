using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class NextWave
	{
		public NextWave(int number)
		{
			Number = number;
		}

		public int Number { get; }
	}
}
