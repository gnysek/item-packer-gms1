using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemPacker2013.Items
{
	public class ItemExtendable
	{
		public int ID;
		public Dictionary<string, string> values = new Dictionary<string, string>();

		public void removeKey(string key)
		{
			removeKeys(new List<string>(new string[] { key }));
		}

		public void removeKeys(List<string> keysToRemove)
		{
			foreach (string key in keysToRemove)
			{
				values.Remove(key);
			}
		}

		public Project Database
		{
			get { return MainForm.CurrentProject; }
		}

		public void setValue(string key, string value)
		{
			if (!values.ContainsKey(key))
			{
				values.Add(key, "");
			}

			if (Database.attributeDefinitions[key].DataType == DefinitionDataType.Sprite)
			{
				values[key] = Database.attributeDefinitions[key].DefaultValue;

				if (Database.GMXspritesFiltered.IndexOf(value) > -1) values[key] = value;
			}
			else if (Database.attributeDefinitions[key].GroupLink > -1)
			{
				if (Database.attributeDefinitions[key].DataType == DefinitionDataType.Sprite ||
					Database.attributeDefinitions[key].DataType == DefinitionDataType.String)
				{

					if (Database.groupDefinitions.ElementAt(Database.attributeDefinitions[key].GroupLink).Value.IndexOf(value) < 0)
					{
						values[key] = Database.attributeDefinitions[key].DefaultValue;
					}
				}
				else
				{
					int val = 0;
					int.TryParse(value, out val);

					values[key] = Math.Min(Math.Max(0, val), Database.groupDefinitions.ElementAt(Database.attributeDefinitions[key].GroupLink).Value.Count).ToString();
				}
			}
			else
			{
				values[key] = value;
			}
		}

		public void setValue(string key, int value)
		{
			setValue(key, value.ToString());
		}

		public void setValue(string key, bool value)
		{
			setValue(key, (value == true) ? "1" : "0");
		}

		// if dropdown will return value label instead real value
		public string getValueLabel(string key)
		{
			if (Database.attributeDefinitions[key].GroupLink > -1)
			{
				DefinitionDataType keyType = Database.attributeDefinitions[key].DataType;
				switch (keyType)
				{
					case DefinitionDataType.Bool:
					case DefinitionDataType.Int:
						if (values.ContainsKey(key))
						{
							return Database.groupDefinitions.ElementAt(Database.attributeDefinitions[key].GroupLink).Value[int.Parse(values[key])];
						}
						else
						{
							return Database.attributeDefinitions[key].DefaultValue;
						}
				}
				// for others value is actually proper label...
			}

			return getValue(key);
		}


		// returns value
		public string getValue(string key)
		{
			DefinitionDataType keyType = Database.attributeDefinitions[key].DataType;

			if (values.ContainsKey(key))
			{
				return values[key];
			}
			else
			{
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

		public string getValueGML(string key)
		{
			switch (Database.attributeDefinitions[key].DataType)
			{
				case DefinitionDataType.String:
					return "\"" + getValue(key) + "\"";
				case DefinitionDataType.Bool:
					return getValue(key) == "1" ? "true" : "false";
			}

			return getValue(key);
		}

		internal void re_setValues()
		{
			List<string> keys = values.Keys.ToList();
			foreach (string key in keys)
			{
				this.setValue(key, values[key]);
			}
		}
	}
}
