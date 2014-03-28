using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ItemPacker2013.Items
{
	public class Project
	{
		public string filename = "";
		public string GMXsource = "";
		public string GMXglobalItemsName = "global.item";
		public string gridView = "1";
		public Dictionary<string, List<string>> groupDefinitions = new Dictionary<string, List<string>>();
		public Dictionary<string, DefinitionData> attributeDefinitions = new Dictionary<string, DefinitionData>();
		public Dictionary<int, ItemExtendable> itemCollection = new Dictionary<int, ItemExtendable>();
		public List<string> GMXspritePattern = new List<string>() { "sprInv*", "sprEquip*" };
		public string GroupBy = "";
		public List<string> GMXsprites = new List<string>();
		public List<string> GMXspritesFiltered = new List<string>();

		public const string C_GMXSource = "gmxSource";
		public const string C_GMXglobalItemsName = "globalItemsName";
		public const string C_GMXspritePatternsGroup = "spritePatterns";

		public Project()
		{
			_defineDefault();
		}

		public Project(string sourceFile, string sourceName)
		{
			_defineDefault();
			GMXsource = sourceFile;
			preloadGMXsprites();
			if (sourceName == "")
			{
				sourceName = "items";
			}
			filename = Path.GetDirectoryName(GMXsource) + @"\" + sourceName + ".gear.itm";
			saveXml();
		}

		private void _defineDefault()
		{
			attributeDefinitions.Add("Name", new DefinitionData() { DataType = DefinitionDataType.String });
			attributeDefinitions.Add("Price", new DefinitionData() { DataType = DefinitionDataType.String });
		}

		public bool preloadGMXsprites()
		{
			string dir = Path.GetDirectoryName(this.GMXsource);

			GMXsprites.Clear();
			foreach (string file in Directory.GetFiles(dir + @"\sprites", "*.sprite.gmx"))
			{
				GMXsprites.Add(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(file)));
			}

			return true;
		}

		public bool filterGMXsprites()
		{
			GMXspritesFiltered.Clear();
			foreach (string sprite in GMXsprites)
			{
				foreach (string pattern in GMXspritePattern)
				{
					Regex mask = new Regex(pattern.Replace("*", ".*"));
					if (mask.IsMatch(sprite))
					{
						GMXspritesFiltered.Add(sprite);
					}
				}
			}
			return true;
		}

		public bool loadXml()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(filename);

			XmlNode settings = doc.SelectSingleNode("nodes/settings");
			if (GMXsource == "")
			{
				// load it from file only, when it wasn't forced by Main Window
				// it may be forced when not found and users points to new one
				GMXsource = settings.SelectSingleNode(C_GMXSource).InnerText;
			}

			if (!File.Exists(GMXsource))
			{
				return false;
			}

			GMXglobalItemsName = settings.SelectSingleNode(C_GMXglobalItemsName).InnerText;
			gridView = settings.SelectSingleNode("gridView").InnerText;

			// sprite patterns
			GMXspritePattern.Clear();
			foreach (XmlNode node in settings.SelectNodes(C_GMXspritePatternsGroup + "/pattern"))
			{
				GMXspritePattern.Add(node.InnerText);
			}

			// item groups
			foreach (XmlNode node in settings.SelectNodes("groupBy"))
			{
				GroupBy = node.InnerText;
			}

			//attributeDefinitions
			attributeDefinitions.Clear();
			foreach (XmlNode node in settings.SelectNodes("attributeDefinitions/*"))
			{
				DefinitionDataType type;

				if (Enum.TryParse(node.SelectSingleNode("type").InnerText, true, out type))
				{
					attributeDefinitions.Add(node.SelectSingleNode("name").InnerText, new DefinitionData()
					{
						Export = (node.SelectSingleNode("export").InnerText == "1") ? true : false,
						DataType = type,
						GroupLink = int.Parse(node.SelectSingleNode("group").InnerText),
						DefaultValue = node.SelectSingleNode("default").InnerText
					});
				}
			}

			//groupDefinitions
			groupDefinitions.Clear();
			foreach (XmlNode node in settings.SelectNodes("groupDefinitions/group"))
			{
				string name = node.SelectSingleNode("name").InnerText;
				List<string> options = new List<string>();
				foreach (XmlNode option in node.SelectNodes("options/option"))
				{
					options.Add(option.InnerText);
				}
				groupDefinitions.Add(name, options);
			}

			// preload those, cause we need them for SetValue!
			preloadGMXsprites();
			filterGMXsprites();

			//items
			itemCollection.Clear();
			foreach (XmlNode node in doc.SelectNodes("nodes/items/item"))
			{
				int id = int.Parse(node.SelectSingleNode("id").InnerText);
				ItemExtendable attr = new ItemExtendable() { ID = id };
				foreach (XmlNode subnode in node.SelectNodes("attr/*"))
				{
					switch (attributeDefinitions[subnode.Name].DataType)
					{
						case DefinitionDataType.Bool:
							attr.setValue(subnode.Name, subnode.InnerText == "1" ? true : false);
							break;
						case DefinitionDataType.Int:
							int val = 0;
							int.TryParse(subnode.InnerText, out val);
							attr.setValue(subnode.Name, val);
							break;
						case DefinitionDataType.Sprite:
						case DefinitionDataType.String:
							attr.setValue(subnode.Name, subnode.InnerText);
							break;
					}
				}
				itemCollection.Add(id, attr);
			}

			return true;
		}

		public bool saveXml()
		{
			XmlDocument doc = new XmlDocument();
			XmlComment comment = doc.CreateComment("This Document is generated by Almora Item Packer, if you edit it by hand then you do so at your own risk!");

			XmlElement nodes = doc.CreateElement("nodes");
			XmlElement settings = doc.CreateElement("settings");
			XmlElement items = doc.CreateElement("items");

			settings.AppendChild(_xme(doc, C_GMXSource, this.GMXsource));
			settings.AppendChild(_xme(doc, C_GMXglobalItemsName, this.GMXglobalItemsName));
			settings.AppendChild(_xme(doc, "gridView", gridView));

			// sprite pattern
			XmlElement xGroup;

			xGroup = doc.CreateElement(C_GMXspritePatternsGroup);
			foreach (string element in GMXspritePattern)
			{
				xGroup.AppendChild(_xme(doc, "pattern", element));
			}
			settings.AppendChild(xGroup);

			// item groups
			settings.AppendChild(_xme(doc, "groupBy", GroupBy));

			// attributeDefinitions
			xGroup = doc.CreateElement("attributeDefinitions");
			foreach (KeyValuePair<string, DefinitionData> pair in attributeDefinitions)
			{
				XmlElement _attr = doc.CreateElement("attribute");
				_attr.AppendChild(_xme(doc, "export", pair.Value.Export ? "1" : "0"));
				_attr.AppendChild(_xme(doc, "name", pair.Key));
				_attr.AppendChild(_xme(doc, "type", pair.Value.DataType.ToString()));
				_attr.AppendChild(_xme(doc, "group", pair.Value.GroupLink.ToString()));
				_attr.AppendChild(_xme(doc, "default", pair.Value.DefaultValue));

				xGroup.AppendChild(_attr);
			}
			settings.AppendChild(xGroup);

			// groupDefinitions
			xGroup = doc.CreateElement("groupDefinitions");
			foreach (KeyValuePair<string, List<string>> pair in groupDefinitions)
			{
				XmlElement _grp = doc.CreateElement("group");
				_grp.AppendChild(_xme(doc, "name", pair.Key));
				XmlElement _options = doc.CreateElement("options");
				foreach (string option in pair.Value)
				{
					_options.AppendChild(_xme(doc, "option", option));
				}
				_grp.AppendChild(_options);
				xGroup.AppendChild(_grp);
			}
			settings.AppendChild(xGroup);

			nodes.AppendChild(settings);

			// items
			foreach (KeyValuePair<int, ItemExtendable> item in itemCollection)
			{
				XmlElement _itm = doc.CreateElement("item");
				_itm.AppendChild(_xme(doc, "id", item.Value.ID.ToString()));

				XmlElement _attr = doc.CreateElement("attr");
				foreach (string param in this.attributeDefinitions.Keys)
				{
					_attr.AppendChild(_xme(doc, param, item.Value.getValue(param)));
				}
				_itm.AppendChild(_attr);
				items.AppendChild(_itm);
			}
			nodes.AppendChild(items);

			doc.AppendChild(comment);
			doc.AppendChild(nodes);

			try
			{
				doc.Save(filename);
			}
			catch (Exception e)
			{
				MessageBox.Show("Unable to save. " + e.Message);
				return false;
			}

			return true;
		}

		private XmlElement _xme(XmlDocument doc, string elemName, string elemValue)
		{
			XmlElement node = doc.CreateElement(elemName);
			node.InnerText = elemValue;
			return node;
		}

		internal void saveGML(string p)
		{
			StreamWriter f = new StreamWriter(p, false);

			foreach (KeyValuePair<int, ItemExtendable> item in itemCollection)
			{
				int row = 0;
				string variableValue = "";
				foreach (KeyValuePair<string, DefinitionData> definition in attributeDefinitions)
				{
					/*switch (definition.Value.DataType)
					{
						case DefinitionDataType.Bool:
							variableValue = item.Value.getValue(definition.Key) == "1" ? "true" : "false";
							break;
						case DefinitionDataType.Int:
							variableValue = int.Parse(item.Value.getValue(definition.Key)).ToString();
							break;
						case DefinitionDataType.Sprite:
							variableValue = item.Value.getValueGML(definition.Key);
							break;
						default:
							variableValue = "\"" + item.Value.getValueGML(definition.Key) + "\"";
							break;
					}*/
					if (definition.Value.Export)
					{
						variableValue = item.Value.getValueGML(definition.Key);
						f.WriteLine(GMXglobalItemsName + "[" + item.Key.ToString() + "," + (row++) + "] = " + variableValue + ";");
					}
				}
			}

			f.Close();
		}

		public void saveCSV(string p)
		{
			StreamWriter f = new StreamWriter(p, false);

			List<string> columns = new List<string>();
			foreach (string column in attributeDefinitions.Keys)
			{
				columns.Add(column);
			}
			f.WriteLine(string.Join(",", columns));

			foreach (KeyValuePair<int, ItemExtendable> item in itemCollection)
			{
				List<string> values = new List<string>();
				foreach (KeyValuePair<string, DefinitionData> definition in attributeDefinitions)
				{
					values.Add(item.Value.getValueLabel(definition.Key));
				}
				f.WriteLine(string.Join(",", values));
			}

			f.Close();
		}
	}
}
