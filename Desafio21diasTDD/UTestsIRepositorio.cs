using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Desafio21diasTDD
{
    public class UTestsIRepositorio
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestaContratoExcluir()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().Excluir<Modelo>(3);
            });
        }

        [Test]
        public void TestaContratoSalvar()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().Salvar<Modelo>(new Modelo() {Id=1, Titulo= "Danilo teste"});
            });
        }

        [Test]
        public void TestaContratoSalvarSemTipo()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().Salvar(new Modelo() {Id=1, Titulo= "Danilo teste"});
            });
        }

        [Test]
        public void TestaBuscaPorId()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().BuscaPorId<Modelo>(1);
            });
        }

        [Test]
        public void TestaBuscaCriterio()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().Todos<Modelo>("Criterio de busca where");
            });
        }

        [Test]
        public void TestaBusca()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().Todos<Modelo>();
            });
        }

        [Test]
        public void TestaDadosArmazenamento()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().DadosDoArmazenamento();
            });
        }

        [Test]
        public void TestaExecutaSqlQuery()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().ExecutaSqlQuery<Modelo>("truncate table testes");
            });
        }

        [Test]
        public void TestaTodosSqlQuery()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new DbTexto().TodosSqlQuery<Modelo>("select testes.* from testes inner join ...");
            });
        }
    }

    internal class Modelo : IModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }


    internal class DbTexto : IRepositorio
    {
        public T BuscaPorId<T>(int id)
        {
            throw new NotImplementedException();
        }

        public string DadosDoArmazenamento()
        {
            throw new NotImplementedException();
        }

        public void Excluir<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Salvar<T>(T modelo)
        {
            throw new NotImplementedException();
        }

        public List<T> Todos<T>(string criterio)
        {
            throw new NotImplementedException();
        }

        public List<T> Todos<T>()
        {
            throw new NotImplementedException();
        }

        public void ExecutaSqlQuery<T>(string sql)
        {
            throw new NotImplementedException();
        }

        public List<T> TodosSqlQuery<T>(string sql)
        {
            throw new NotImplementedException();
        }
    }
}