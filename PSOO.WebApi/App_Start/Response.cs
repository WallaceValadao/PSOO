using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace PSOO.WebApi
{
    public static class Response
    {
        public static HttpResponseMessage RetornoOK<T>(this List<T> lista)
        {
            var retorno = new HttpResponseMessage(HttpStatusCode.OK);

            retorno.Content = new StringContent(JsonConvert.SerializeObject(lista));

            return retorno;
        }

        public static HttpResponseMessage RetornoOK<T>(this T entidade)
        {
            var retorno = new HttpResponseMessage(HttpStatusCode.OK);

            retorno.Content = new StringContent(JsonConvert.SerializeObject(entidade));

            return retorno;
        }

        public static HttpResponseMessage Retorno(this string mensagem, HttpStatusCode status = HttpStatusCode.OK)
        {
            var retorno = new HttpResponseMessage(status);
            
            retorno.Content = new StringContent(mensagem);

            return retorno;
        }
    }
}