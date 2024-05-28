using System.Text.Json.Serialization;

namespace Fina.Core.Responses
{
    public class Response<TData>
    {
        private int _code = 200;

        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code >= 200 && _code <= 299;

        [JsonConstructor] // define qual construtor utilizar para gerar o JSON, por padrão ele sempre procura um construtor vazio
        public Response()
            => _code = Configuration.DefaultStatusCode;

        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }
    }
}