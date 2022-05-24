using Supertext.TermbaseXmlReader.Controllers;
using Supertext.TermbaseXmlReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supertext.TermbaseXmlReader.Helpers
{
    public static class TermbaseHelper
    {
        public static IEnumerable<TermLanguagesModel> ToTermLanguageModel(this Mtf mtf) 
        {
            List<TermLanguagesModel> termbaseReaderList = new List<TermLanguagesModel>();

            foreach (var item in mtf.ConceptGrp)
            {
                TermLanguagesModel termbaseReaderItem = new TermLanguagesModel();
                foreach (var subItem in item.LanguageGrp)
                {
                    TermModel termbase = new TermModel();

                    termbase.LanguageName = subItem.Language.Lang;
                    termbase.LanguageType = subItem.Language.Type;

                    foreach (var termGroup in subItem.TermGrp)
                    {
                        if (string.IsNullOrEmpty(termbase.Term))
                        {
                            termbase.Term = termGroup.Term;
                        }
                        foreach (var descripGrp in termGroup.DescripGrp)
                        {
                            termbase.AdditionalInformations.Add(new KeyValueModel { Key = descripGrp.Descrip.Type, Value = descripGrp.Descrip.Text });

                        }
                    }

                    termbaseReaderItem.TermLanguages.Add(termbase);
                }
                termbaseReaderList.Add(termbaseReaderItem);
            }

            return termbaseReaderList;
        }
    }
}
