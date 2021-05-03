using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EdgeApi.DataAccess;
using EdgeApi.POCO;
using System;
using EdgeApi.Data;

namespace EdgeApi_API.Controllers
{
    [ApiController]
    [Authorize] //Indicar que la función usara autenticacion JWT
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// Obtiene todos los posts.
        /// </summary>
        [HttpGet]
        [Route("api/GetAllPosts")]
        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public IActionResult GetAllPosts() 
        {
            Response response = new Response();

            try
            {
                response = PostsAccess.GetAllPosts();

                if (response.ErrorCode == EdgeApi.ErrorCode.NoError)
                    return Ok(response);
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

        /// <summary>
        /// Obtiene un post por ID.
        /// </summary>
        /// <param name="postId">Número de id del post (0,100)</param>
        [HttpGet]
        [Route("api/GetPostById/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public IActionResult GetAllPosts(int postId)
        {
            Response response = new Response();

            try
            {
                response = PostsAccess.GetPostById(postId);

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

        /// <summary>
        /// Crea un nuevo post.
        /// </summary>
        /// <param name="post">Objeto post que se quiere crear.</param>
        [HttpPost]
        [Route("api/CreatePost")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public IActionResult CreatePost(Post post)
        {
            Response response = new Response();

            try
            {
                response = PostsAccess.CreatePost(post);

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

        /// <summary>
        /// Actualizar un post.
        /// </summary>
        /// <param name="post">Objeto post que se quiere crear.</param>
        [HttpPut]
        [Route("api/UpdatePost")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public IActionResult UpdatePost(Post post)
        {
            Response response = new Response();

            try
            {
                response = PostsAccess.UpdatePost(post);

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
