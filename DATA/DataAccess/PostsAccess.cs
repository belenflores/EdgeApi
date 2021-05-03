using EdgeApi.Data;
using EdgeApi.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;

namespace EdgeApi.DataAccess
{
    public static class PostsAccess
    {
        private static HttpClient client = new HttpClient();                                                   
        private static string baseUrl = @"https://jsonplaceholder.typicode.com";

       
        public static Response GetAllPosts()
        {
            Response apiResponse = new Response();
            apiResponse.IdReference = Guid.NewGuid(); //devolver un valor de referencia, asumimos que se guarda
            apiResponse.Method = "GetAllPosts";

            try
            {
                var response = client.GetAsync(baseUrl + "/posts").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    apiResponse.Posts = JsonSerializer.Deserialize<List<Post>>(responseString);
                }
                else 
                {
                    throw new Exception("Error al consultar a API fuente.");
                }
            }
            catch (Exception ex)
            {
                apiResponse.ErrorCode = ErrorCode.Other;
                apiResponse.ErrorMessage = ex.Message;
            }

            return apiResponse;
        }
    }

    [Serializable]
    internal class ApiValException : Exception
    {
        public ApiValException()
        {
        }

        public ApiValException(string message) : base(message)
        {
        }

        public ApiValException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiValException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
