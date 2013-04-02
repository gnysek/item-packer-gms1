using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemPacker2013.Items
{
	public class ItemExtendable
	{
		public int ID;
		public Dictionary<string, int> integers = new Dictionary<string, int>();
		public Dictionary<string, string> strings = new Dictionary<string, string>();

		public void setValue(string key, string value)
		{
			if (strings.ContainsKey(key))
			{
				strings[key] = value;
			}
			else
			{
				strings.Add(key, value);
			}
		}

		public void setValue(string key, int value)
		{
			if (integers.ContainsKey(key))
			{
				integers[key] = value;
			}
			else
			{
				integers.Add(key, value);
			}
		}

		public void setValue(string key, bool value)
		{
			setValue(key, (value == true) ? 1 : 0);
		}

		public string getValue(string key)
		{
			if (integers.ContainsKey(key))
			{
				return integers[key].ToString();
			}
			else if (strings.ContainsKey(key))
			{
				return strings[key];
			}
			return "-";
		}
	}
}
