using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EdgeApi.POCO;


namespace EdgeApi_API.Controllers
{
    [Authorize]
    public class AuthenticationController : ControllerBase //api para devolver el token de autenticacion
    {
        private readonly IJWTAuthenticationManager AuthenticationManager;

        public AuthenticationController(IJWTAuthenticationManager authenticationManager) 
        {
            this.AuthenticationManager = authenticationManager;
        }

        /// <summary>
        /// Devuelve el token de autenticación.
        /// </summary>
        /// <param name="credentials">Objeto con definición de usuario y contraseña.</param>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate/")]
        public ActionResult Authenticate([FromBody] Credentials credentials)
        {
            var token = this.AuthenticationManager.Authenticate(credentials);

            if (token != null)
                return Ok(token);
            else
                return Unauthorized();
        }

     
    }
}
