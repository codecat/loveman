using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Loveman
{
	public abstract class PlistValue
	{
		public abstract string GetName();
		public abstract void WriteValue(int indent, StreamWriter writer);

		public virtual void Write(int indent, StreamWriter writer)
		{
			WriteIndent(indent, writer);

			var name = GetName();
			writer.Write("<" + name + ">");

			WriteValue(indent, writer);

			writer.WriteLine("</" + name + ">");
		}

		protected virtual void WriteIndent(int indent, StreamWriter writer)
		{
			for (int i = 0; i < indent; i++) {
				writer.Write('\t');
			}
		}

		protected void Assert(bool condition)
		{
			if (!condition) {
				InvalidFile();
			}
		}

		protected void InvalidFile()
		{
			throw new Exception("Invalid plist file, unexpected token while parsing " + GetName() + "!");
		}

		public static PlistValue FromXml(XmlReader reader)
		{
			//TODO: date (NSDate) & data (NSData, base64 encoded binary data)

			switch (reader.Name) {
				case "dict": return new PlistDict(reader);
				case "array": return new PlistArray(reader);

				case "string": return new PlistString(reader);
				case "integer": return new PlistInteger(reader);
				case "real": return new PlistReal(reader);

				case "true": return new PlistBoolean(reader);
				case "false": return new PlistBoolean(reader);
			}
			return null;
		}
	}

	public class PlistDict : PlistValue
	{
		public Dictionary<string, PlistValue> Values { get; set; }

		public PlistDict(XmlReader reader)
		{
			Values = new Dictionary<string, PlistValue>();

			while (reader.Read()) {
				if (reader.NodeType == XmlNodeType.Element) {
					Assert(reader.Name == "key");
					Assert(reader.Read());
					Assert(reader.NodeType == XmlNodeType.Text);
					var key = reader.Value;
					Assert(reader.Read());
					Assert(reader.NodeType == XmlNodeType.EndElement);
					Assert(reader.Read());
					Assert(reader.NodeType == XmlNodeType.Element);
					var value = FromXml(reader);
					Values.Add(key, value);
				} else if (reader.NodeType == XmlNodeType.EndElement) {
					if (reader.Name == "dict") {
						break;
					}
				} else {
					InvalidFile();
				}
			}
		}

		public override string GetName() { return "dict"; }

		public override void WriteValue(int indent, StreamWriter writer)
		{
			writer.WriteLine();

			foreach (var pair in Values) {
				WriteIndent(indent + 1, writer);
				writer.WriteLine("<key>" + SecurityElement.Escape(pair.Key) + "</key>");

				pair.Value.Write(indent + 1, writer);
			}

			WriteIndent(indent, writer);
		}
	}

	public class PlistArray : PlistValue
	{
		public List<PlistValue> Values { get; set; }

		public PlistArray(XmlReader reader)
		{
			Values = new List<PlistValue>();

			while (reader.Read()) {
				if (reader.NodeType == XmlNodeType.Element) {
					Values.Add(FromXml(reader));
				} else if (reader.NodeType == XmlNodeType.EndElement) {
					if (reader.Name == "array") {
						break;
					}
				} else {
					InvalidFile();
				}
			}
		}

		public override string GetName() { return "array"; }

		public override void WriteValue(int indent, StreamWriter writer)
		{
			writer.WriteLine();

			foreach (var value in Values) {
				value.Write(indent + 1, writer);
			}

			WriteIndent(indent, writer);
		}
	}

	public class PlistString : PlistValue
	{
		public string Value { get; set; }

		public PlistString(XmlReader reader)
		{
			reader.Read();
			if (reader.NodeType == XmlNodeType.Text) {
				Value = reader.Value;
			} else if (reader.NodeType == XmlNodeType.EndElement) {
				Value = "";
			} else {
				InvalidFile();
			}
		}

		public override string GetName() { return "string"; }
		public override string ToString() { return "\"" + Value + "\""; }

		public override void WriteValue(int indent, StreamWriter writer)
		{
			writer.Write(SecurityElement.Escape(Value));
		}
	}

	public class PlistInteger : PlistValue
	{
		public int Value { get; set; }

		public PlistInteger(XmlReader reader)
		{
			reader.Read();
			Assert(reader.NodeType == XmlNodeType.Text);
			Value = int.Parse(reader.Value);
		}

		public override string GetName() { return "integer"; }
		public override string ToString() { return Value.ToString(); }

		public override void WriteValue(int indent, StreamWriter writer)
		{
			writer.Write(Value.ToString());
		}
	}

	public class PlistReal : PlistValue
	{
		public float Value { get; set; }

		public PlistReal(XmlReader reader)
		{
			reader.Read();
			Assert(reader.NodeType == XmlNodeType.Text);
			Value = float.Parse(reader.Value);
		}

		public override string GetName() { return "real"; }
		public override string ToString() { return Value.ToString(); }

		public override void WriteValue(int indent, StreamWriter writer)
		{
			writer.Write(Value.ToString());
		}
	}

	public class PlistBoolean : PlistValue
	{
		public bool Value { get; set; }

		public PlistBoolean(XmlReader reader)
		{
			Value = bool.Parse(reader.Name);
		}

		public override string GetName() { return Value.ToString().ToLower(); }
		public override string ToString() { return Value.ToString(); }

		public override void Write(int indent, StreamWriter writer)
		{
			WriteIndent(indent, writer);
			writer.WriteLine("<" + GetName() + "/>");
		}

		public override void WriteValue(int indent, StreamWriter writer)
		{
			throw new NotImplementedException();
		}
	}

	public class Plist
	{
		public string Filename { get; set; }
		public PlistValue Value { get; set; }

		public Plist()
		{
		}

		public Plist(string filename)
		{
			Read(filename);
		}

		public void Read(string filename)
		{
			Filename = filename;

			var xmlReaderSettings = new XmlReaderSettings() {
				DtdProcessing = DtdProcessing.Parse,
				IgnoreWhitespace = true,
				IgnoreComments = true,
			};

			using (var fs = File.OpenRead(filename)) {
				using (var reader = XmlReader.Create(fs, xmlReaderSettings)) {
					var readingPlist = false;

					while (reader.Read()) {
						if (reader.NodeType == XmlNodeType.Element) {
							if (readingPlist) {
								Value = PlistValue.FromXml(reader);
							} else {
								if (reader.Name == "plist") {
									readingPlist = true;
								}
							}
						}
						continue;
					}
				}
			}
		}

		public void Save(string filename = "")
		{
			if (filename == "") {
				filename = Filename;
			}
			Filename = filename;

			if (File.Exists(filename)) {
				File.Delete(filename);
			}

			using (var fs = File.Create(filename)) {
				using (var writer = new StreamWriter(fs)) {
					writer.NewLine = "\n";
					writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
					writer.WriteLine(@"<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">");
					writer.WriteLine(@"<plist version=""1.0"">");
					Value.Write(0, writer);
					writer.WriteLine(@"</plist>");
				}
			}
		}

		public PlistValue GetValue(string path = "")
		{
			PlistValue current = Value;

			if (path == "") {
				return Value;
			}

			var parse = path.Split('/');
			for (int i = 0; i < parse.Length; i++) {
				var dict = (current as PlistDict);
				if (dict != null) {
					PlistValue value;
					if (!dict.Values.TryGetValue(parse[i], out value)) {
						return null;
					}
					current = value;
					continue;
				}

				var array = (current as PlistArray);
				if (array != null) {
					var index = int.Parse(parse[i]);
					current = array.Values[index];
					continue;
				}

				return null;
			}

			return current;
		}
	}
}
