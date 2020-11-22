using System;
using System.Collections.Generic;
using Desafio21diasAPI.Models;

namespace Desafio21diasAPI.Servicos.Database
{
    public interface IRepositorio
    {
        void Salvar<T>(T model);
        void Excluir<T>(int id);
        List<T> Todos<T>();
        List<T> Todos<T>(string criterio);
        T BuscaPorId<T>(int id);
        string DadosDoArmazenamento();
    }
}
