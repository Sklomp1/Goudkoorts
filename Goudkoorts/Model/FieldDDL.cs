using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class FieldDDL
	{
		public Field Field { get; set; }
		public FieldDDL Up { get; set; }
		public FieldDDL Down { get; set; }
		public FieldDDL Next { get; set; }
		public FieldDDL Previous { get; set; }
	}
}
