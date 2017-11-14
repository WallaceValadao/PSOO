using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace PSOO.WebApi.App_Start
{
    public class ResponseFormatter : JsonMediaTypeFormatter
    {
        public ResponseFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);

            mediaType.MediaType = "application/json";
            mediaType.CharSet = "utf-8";

            headers.ContentType = mediaType;
        }
    }
}