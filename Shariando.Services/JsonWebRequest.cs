using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Services
{
    internal class JsonWebRequest<TResult>
    {
        private readonly Action<ShariandoException> _onError;
        private readonly Action<TResult> _onSuccess;

        private readonly Dictionary<string, Func<Exception>> _shariandoExceptionMapping = GetShariandoExceptionMapping();

        private HttpWebRequest _webRequest;

        public JsonWebRequest(string url, Action<TResult> onSuccess, Action<ShariandoException> onError)
        {
            _onSuccess = onSuccess;
            _onError = onError;

            _webRequest = (HttpWebRequest)WebRequest.Create(url);
            _webRequest.BeginGetResponse(WebRequestCallback, _webRequest);
        }

        internal static Dictionary<string, Func<Exception>> GetShariandoExceptionMapping()
        {
            return new Dictionary<string, Func<Exception>>
                       {
                           {"email not found", () => { return new ShariandoEmailNotFoundException(); }}
                       };
        }


        private void WebRequestCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                _webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                string json;
                using (var response = (HttpWebResponse)_webRequest.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = response.GetResponseStream())
                    {
                        using (var streamReader = new StreamReader(streamResponse))
                        {
                            json = streamReader.ReadToEnd();
                        }
                    }
                }
                ProcessJson(json);
            }
            catch (WebException)
            {
                _onError(new ShariandoServerConnectionException());
            }
            catch(ShariandoException e)
            {
                _onError(e);
            }
        }

        private void ProcessJson(string json)
        {
            try
            {
                _onSuccess(UnserializeJson<TResult>(json));
            }
            catch (InvalidCastException)
            {
                try
                {
                    var e = UnserializeJson<ShariandoError>(json);
                    if (_shariandoExceptionMapping.ContainsKey(e.Error)) throw _shariandoExceptionMapping[e.Error]();
                    throw new Exception(e.Error);
                }
                catch (InvalidCastException)
                {
                    throw new ShariandoServerConnectionException();
                }
            }
        }

        private static T UnserializeJson<T>(string json)
        {
            using (var jsonStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(jsonStream);
            }
        }
    }
}