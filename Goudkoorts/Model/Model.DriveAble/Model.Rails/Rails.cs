using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public abstract class Rails : DriveAble
	{
		public string Direction { get; set; }
		public bool Finish { get; set; }
		public Rails()
		{

		}
	}
}
