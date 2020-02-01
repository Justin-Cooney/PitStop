using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
	public class AddPoints
	{
		public AddPoints(float points)
		{
			Points = points;
		}

		public float Points { get; }
	}
}
