using System.Collections.Generic;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.Common.ResponseExamples
{
    public class BadRequestResponseExampleProvider : ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new
            {
                Message = "Запрос недопустим.",
                ModelState = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "ParamName",
                        new List<string>
                        {
                            "Здесь текст ошибки параметра ParamName"
                        }
                    },
                    {
                        "ParamName2",
                        new List<string>
                        {
                            "Здесь текст ошибки параметра ParamName2",
                            "Здесь текст еще одной ошибки параметра ParamName2"
                        }
                    }
                }
            };
        }
    }
}