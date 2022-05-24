using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supertext.TermbaseXmlReader.Controllers
{
    public class TermModel
    {
        public TermModel()
        {
            AdditionalInformations = new List<KeyValueModel>();
        }
        public string LanguageName { get; set; }
        public string LanguageType { get; set; }

        public string Term { get; set; }

        public List<KeyValueModel> AdditionalInformations { get; set; }
    }

    public class TermLanguagesModel
    {
        public TermLanguagesModel()
        {
            TermLanguages = new List<TermModel>();
        }
        public List<TermModel> TermLanguages { get; set; }
    }

    public class KeyValueModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
