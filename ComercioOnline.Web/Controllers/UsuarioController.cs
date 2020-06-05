using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComercioOnline.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController: Controller
    {


        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();

            } catch(Exception ex)

            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                return Ok();

            }
            catch (Exception ex)

            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {

                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email,usuario.Senha);



                if(usuarioRetorno != null)
                return Ok(usuarioRetorno);

                return BadRequest("Usuário ou senha Inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
