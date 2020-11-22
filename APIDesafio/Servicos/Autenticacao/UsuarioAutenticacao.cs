using System;
using System.Collections.Generic;
using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;

namespace Desafio21diasAPI.Servicos.Autenticacao
{
	public class UsuarioAutenticacao
	{
			public static Cliente Autenticar(string login, string senha)
			{					
					var clientes = new SqlRepositorio().Todos<Cliente>($"login = '{SqlRepositorio.PreparaCampoQuery(login)}' and senha = '{SqlRepositorio.PreparaCampoQuery(senha)}'");

					if (clientes.Count == 0)
							return null;

					Cliente cliente = (Cliente)clientes[0];
					cliente.Token = Token.GerarToken(cliente);

					//cliente.Senha = null;

					return cliente;
			}
  }
}
