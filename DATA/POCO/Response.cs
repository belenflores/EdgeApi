using EdgeApi.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgeApi.POCO
{
    public  class Response
    {
        public Response() 
        {
            this.ErrorCode = ErrorCode.NoError;
        }
        public Guid IdReference { get; set; }
        public string Method { get; set; }
        public string ErrorMessage { get; set; }       
        public ErrorCode ErrorCode { get; set; }
        public List<Post> Posts { get; set; }

    }

}

namespace EdgeApi
{
    public enum ErrorCode
    {
        NoError= 0,
        Validation = 100,
        Other = 101
    }
}