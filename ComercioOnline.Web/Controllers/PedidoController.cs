using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComercioOnline.Web.Controllers
{
    public class PedidoController: Controller { 

        private IPedidoRepositorio _pedidoRepositorio;
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            this._pedidoRepositorio = pedidoRepositorio;
        }

        public IActionResult Post([FromBody] Pedido pedido)
        {
            try
            {
                _pedidoRepositorio.Adicionar(pedido);
                return Ok(pedido.Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }          
        }
    }
}
