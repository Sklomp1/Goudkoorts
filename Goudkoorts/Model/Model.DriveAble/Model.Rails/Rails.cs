using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public abstract class Rails : Field
	{
		public string Direction { get; set; }
		public bool Finish { get; set; }
		public Rails()
		{

		}
	}
}
