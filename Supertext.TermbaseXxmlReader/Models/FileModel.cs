using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supertext.TermbaseXmlReader.Models
{
    public class FileModel
    {
        public IFormFile XmlFile { get; set; }
    }
}
