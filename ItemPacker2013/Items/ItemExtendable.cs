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

		public void removeKeys(List<string> keysToRemove)
		{
			foreach (string key in keysToRemove)
			{
				integers.Remove(key);
				strings.Remove(key);
			}
		}

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
			ItemDefinitionType keyType = MainForm.CurrentProject.attributeDefinitions[key].Type;

			switch (keyType)
			{
				case ItemDefinitionType.Bool:
				case ItemDefinitionType.Int:
					if (integers.ContainsKey(key))
					{
						return integers[key].ToString();
					}
					break;
				case ItemDefinitionType.Sprite:
				case ItemDefinitionType.String:
					if (strings.ContainsKey(key))
					{
						return strings[key];
					}
					break;
			}

			// default value
			if (keyType == ItemDefinitionType.Sprite)
			{
				//if no sprite set yet, then set as first one on list :)
				string defVal = MainForm.CurrentProject.attributeDefinitions[key].DefaultValue;
				if (defVal.Length > 0 && MainForm.CurrentProject.GMXspritesFiltered.Contains(defVal))
				{
					return defVal;
				}

				return MainForm.CurrentProject.GMXspritesFiltered[0];
			}
			else
			{
				return MainForm.CurrentProject.attributeDefinitions[key].DefaultValue;
			}
		}
	}
}
