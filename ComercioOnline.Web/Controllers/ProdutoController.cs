using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Dominio.Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComercioOnline.Web.Controllers
{

    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;


        public ProdutoController(IProdutoRepositorio produtoRepositorio, IHttpContextAccessor httpContextAccessor, 
            IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }


        //Metodo Get
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch(Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }


        // Metodo Post
        [HttpPost]
        public IActionResult Post([FromBody]Produto produto )
        {

            try {

                _produtoRepositorio.Adicionar(produto);

                return Created("api/produto", produto);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao);
                var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;

                using (var StreamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(StreamArquivo);
                }

                return Ok("Arquivo Enviado com Sucesso");


            }

            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");
            novoNomeArquivo = $"{novoNomeArquivo}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.{extensao}";
            return novoNomeArquivo;
        }
    }
}
