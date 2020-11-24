using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Desafio21diasTDD
{
    public class UTestsSqlRepositorio
    {
        [SetUp]
        public void Setup()
        { 
            new SqlRepositorio().ExecutaSqlQuery<Teste>("truncate table testes");
        }

        [Test]
        public void TestaInserirNoDadoBanco()
        {
            var db = new SqlRepositorio();
            db.Salvar(new Teste() {Nome= "Danilo teste 1"});
            db.Salvar(new Teste() {Nome= "Danilo teste 2"});
            db.Salvar(new Teste() {Nome= "Danilo teste 3"});

            Assert.AreEqual(db.Todos<Teste>().Count, 3);
        }

        [Test]
        public void TestaAlterarNoDadoBanco()
        {
            var db = new SqlRepositorio();
            var teste = new Teste() {Nome= "Danilo teste 1"};
            db.Salvar(teste);

            var testeSalvo = db.BuscaPorId<Teste>(1);

            testeSalvo.Nome = "Nome alterado";
            db.Salvar(testeSalvo);

            var testeSalvoProva = db.BuscaPorId<Teste>(1);

            Assert.AreEqual(testeSalvoProva.Nome, "Nome alterado");
        }

        [Test]
        public void TestaBuscaPorIdNoDadoBanco()
        {
            var db = new SqlRepositorio();
            var teste = new Teste() {Nome= "Danilo teste 1"};
            db.Salvar(teste);

            var testeSalvo = db.BuscaPorId<Teste>(1);
            Assert.AreEqual(testeSalvo.Id, 1);
        }

        [Test]
        public void TestaBuscaComQueryNoDadoBanco()
        {
            var db = new SqlRepositorio();
            var teste = new Teste() {Nome= "Danilo teste 1"};
            db.Salvar(teste);

            var lista = db.Todos<Teste>("Nome like '%Danilo%'");
            Assert.AreEqual(lista.Count, 1);
        }

        [Test]
        public void TestaBuscaComSqlQueryNoDadoBanco()
        {
            var db = new SqlRepositorio();
            var teste = new Teste() {Nome= "Danilo teste 1"};
            db.Salvar(teste);

            var lista = db.TodosSqlQuery<Teste>("select * from testes where Nome like '%Danilo%'");
            Assert.AreEqual(lista.Count, 1);
        }

        [Test]
        public void TestaExecutaSqlQueryNoDadoBanco()
        {
            var db = new SqlRepositorio();
            var teste = new Teste() {Nome= "Danilo teste 1"};
            db.Salvar(teste);

            db.ExecutaSqlQuery<Teste>("delete from testes");
            var lista = db.Todos<Teste>();
            
            Assert.AreEqual(lista.Count, 0);
        }
    }

    internal partial class Teste : IModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}