using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EdgeApi.DataAccess;
using EdgeApi.POCO;
using System;


namespace EdgeApi_API.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("api/GetAllPosts")]
        public IActionResult GetAllPosts()
        {
            Response response = new Response();

            try
            {
                response = PostsAccess.GetAllPosts();

                if (response.ErrorCode == EdgeApi.ErrorCode.NoError)
                    return Ok(response);
                if (response.ErrorCode == EdgeApi.ErrorCode.Validation)
                    return BadRequest(response);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                response.ErrorCode = EdgeApi.ErrorCode.Other;
                response.ErrorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
