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

		//public int getDefaultValueForKey(string key)
		//{
		//    int result = 0;
		//    int.TryParse(Database.attributeDefinitions[key].DefaultValue, out result);
		//    return result;
		//}

		//public string getDefaultValueForKey(string key)
		//{
		//    return Database.attributeDefinitions[key].DefaultValue;
		//}

		public void removeKeys(List<string> keysToRemove)
		{
			foreach (string key in keysToRemove)
			{
				integers.Remove(key);
				strings.Remove(key);
			}
		}

		public Project Database
		{
			get { return MainForm.CurrentProject; }
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


		// returns value
		public string getValue(string key)
		{
			DefinitionDataType keyType = Database.attributeDefinitions[key].DataType;

			switch (keyType)
			{
				case DefinitionDataType.Bool:
				case DefinitionDataType.Int:
					//if (Database.attributeDefinitions[key].GroupLink > -1)
					//{
					//    if (integers.ContainsKey(key))
					//    {
					//        return Database.groupDefinitions.ElementAt(Database.attributeDefinitions[key].GroupLink).Value[integers[key]];
					//    }
					//}

					if (integers.ContainsKey(key))
					{
						return integers[key].ToString();
					}
					break;
				case DefinitionDataType.Sprite:
				case DefinitionDataType.String:
					if (MainForm.CurrentProject.attributeDefinitions[key].GroupLink > -1)
					{
						if (strings.ContainsKey(key))
						{
							int value = 0;
							int.TryParse(strings[key], out value);
							return Database.groupDefinitions.ElementAt(Database.attributeDefinitions[key].GroupLink).Value[value];
						}
					}

					if (strings.ContainsKey(key))
					{
						return strings[key];
					}
					break;
			}

			// default value
			if (keyType == DefinitionDataType.Sprite)
			{
				//if no sprite set yet, then set as first one on list :)
				string defVal = Database.attributeDefinitions[key].DefaultValue;
				if (defVal.Length > 0 && Database.GMXspritesFiltered.Contains(defVal))
				{
					return defVal;
				}

				return Database.GMXspritesFiltered[0];
			}
			else
			{
				return Database.attributeDefinitions[key].DefaultValue;
			}
		}
	}
}
