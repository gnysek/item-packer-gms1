using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemPacker2013.Items
{

	public class DefinitionData
	{
		public DefinitionDataType DataType = DefinitionDataType.String;
		public int GroupLink = -1;
		private int _dataInt = 0;
		private string _dataString = "";

		public string TypeString
		{
			get { return DataType.ToString(); }
			set
			{
				if (!Enum.TryParse(value, true, out DataType))
				{
					DataType = DefinitionDataType.String;
				}
			}
		}

		public string DefaultValue
		{
			get { return _dataString; }
			set { _dataString = value; int.TryParse(value, out _dataInt); }
		}
	}
}
