using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Supertext.TermbaseXmlReader.Helpers;
using Supertext.TermbaseXmlReader.Models;

namespace Supertext.TermbaseXmlReader.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermbaseReaderController : ControllerBase
    {

        private readonly ILogger<TermbaseReaderController> _logger;

        public TermbaseReaderController(ILogger<TermbaseReaderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromForm]FileModel fileModel)
        {
            try
            {
                IFormFile file = fileModel.XmlFile;

                if (file == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "XML file is mandatory");
                }
                else if (!file.FileName.ToLower().EndsWith(".xml"))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Wrong file format");
                }
                else
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Mtf));
                    Mtf mtfObject;
                   
                    using (Stream fileStream = file.OpenReadStream())
                    {
                        using (XmlReader reader = XmlReader.Create(fileStream))
                        {
                            mtfObject = (Mtf)ser.Deserialize(reader);

                            if (mtfObject != null)
                            {
                                IEnumerable<TermLanguagesModel> termbaseReaderList = mtfObject.ToTermLanguageModel();
                                return StatusCode(StatusCodes.Status200OK, termbaseReaderList);
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, "Wrong file format");
                            }
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
