using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Autenticacao;
using Desafio21diasAPI.Servicos.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio21diasAPI.Controllers
{
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/clientes/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Cliente clienteLogin)
        {
            try
            {
                var cliente = UsuarioAutenticacao.Autenticar(clienteLogin.Login, clienteLogin.Senha);

                if (cliente == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("/clientes")]
        public IEnumerable<Cliente> Get()
        {
            return new SqlRepositorio().Todos<Cliente>();
        }

        [HttpPost]
        [Route("/clientes")]
        public Cliente Criar([FromBody] Cliente cliente)
        {
            new SqlRepositorio().Salvar<Cliente>(cliente);
            return cliente;
        }

        [HttpGet]
        [Route("/clientes/{id}")]
        public Cliente Ver(int id)
        {
            Cliente cliente = new SqlRepositorio().BuscaPorId<Cliente>(id);
            return cliente;
        }

        [HttpPut]
        [Route("/clientes/{id}")]
        [Authorize(Roles = "editor, administrador")]
        public IActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            var cli = new SqlRepositorio().BuscaPorId<Cliente>(id);

            var ruleAdm = HttpContext.User.Claims.SingleOrDefault(p => p.Value == "administrador");
            if(ruleAdm == null){
                var loginDado = HttpContext.User.Claims.SingleOrDefault(p => p.Value == ((Cliente)cli).Login);
                if(loginDado == null){
                    return Unauthorized(new { message = "Você não tem acesso para alterar informações de usuário" });
                }
            }

            cliente.Id = id;
            new SqlRepositorio().Salvar(cliente);

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        [Route("/clientes/{id}")]
        public void Apagar(int id)
        {
            new SqlRepositorio().Excluir<Cliente>(id);
        }
    }
}
