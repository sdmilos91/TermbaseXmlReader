using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Supertext.TermbaseXmlReader.Models
{
	[XmlRoot(ElementName = "language")]
	public class Language
	{
		[XmlAttribute(AttributeName = "lang")]
		public string Lang { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "descrip")]
	public class Descrip
	{
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "transac")]
	public class Transac
	{
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "transacGrp")]
	public class TransacGrp
	{
		[XmlElement(ElementName = "transac")]
		public Transac Transac { get; set; }
		[XmlElement(ElementName = "date")]
		public string Date { get; set; }
	}

	[XmlRoot(ElementName = "descripGrp")]
	public class DescripGrp
	{
		[XmlElement(ElementName = "descrip")]
		public Descrip Descrip { get; set; }
		[XmlElement(ElementName = "transacGrp")]
		public List<TransacGrp> TransacGrp { get; set; }
	}

	[XmlRoot(ElementName = "termGrp")]
	public class TermGrp
	{
		[XmlElement(ElementName = "term")]
		public string Term { get; set; }
		[XmlElement(ElementName = "descripGrp")]
		public List<DescripGrp> DescripGrp { get; set; }
		[XmlElement(ElementName = "transacGrp")]
		public List<TransacGrp> TransacGrp { get; set; }
	}

	[XmlRoot(ElementName = "languageGrp")]
	public class LanguageGrp
	{
		[XmlElement(ElementName = "language")]
		public Language Language { get; set; }
		[XmlElement(ElementName = "termGrp")]
		public List<TermGrp> TermGrp { get; set; }
	}

	[XmlRoot(ElementName = "conceptGrp")]
	public class ConceptGrp
	{
		[XmlElement(ElementName = "concept")]
		public string Concept { get; set; }
		[XmlElement(ElementName = "languageGrp")]
		public List<LanguageGrp> LanguageGrp { get; set; }
		[XmlElement(ElementName = "transacGrp")]
		public List<TransacGrp> TransacGrp { get; set; }
	}

	[XmlRoot(ElementName = "mtf")]
	public class Mtf
	{
		[XmlElement(ElementName = "conceptGrp")]
		public List<ConceptGrp> ConceptGrp { get; set; }
	}

}
