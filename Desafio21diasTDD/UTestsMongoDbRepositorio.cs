using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Desafio21diasTDD
{
  public class UTestsMongoDbRepositorio
  {
    [SetUp]
    public void Setup()
    {
      new MongoDbRepositorio().RemoverColecao<TesteMongo>();
    }

    [Test]
    public void TestaInserirNoDadoBanco()
    {
      var db = new MongoDbRepositorio();
      db.Salvar(new TesteMongo() { Nome = "Danilo teste 1", Aula = "Aula SQl" });
      db.Salvar(new TesteMongo() { Nome = "Danilo teste 2", Aula = "Aula Entity" });
      db.Salvar(new TesteMongo() { Nome = "Danilo teste 3", Aula = "Aula Mongo" });

      Assert.AreEqual(db.Todos<TesteMongo>().Count, 3);
    }


    [Test]
    public void TestaAlterarNoDadoBanco()
    {
      var db = new MongoDbRepositorio();
      db.Salvar(new TesteMongo() { Nome = "Danilo teste 1", Aula = "Aula SQl" });

      var item = db.Todos<TesteMongo>().First();
      item.Nome = "Nome alterado";

      db.Salvar<TesteMongo>(item);

      var itemBase = db.Todos<TesteMongo>().First();

      Assert.AreEqual(itemBase.Nome, "Nome alterado");
    }

    [Test]
    public void TestaExcluirNoDadoBanco()
    {
      var db = new MongoDbRepositorio();
      db.Salvar(new TesteMongo() { Nome = "Danilo teste 1", Aula = "Aula SQl" });
      db.Salvar(new TesteMongo() { Nome = "Danilo teste 3", Aula = "Aula Mongo" });

      var item = db.Todos<TesteMongo>().First();

      db.Excluir<TesteMongo>(item.Id);

      Assert.AreEqual(db.Todos<TesteMongo>().Count, 1);
    }

    [Test]
    public void TestaBuscaNoDadoBanco()
    {
      Assert.AreEqual(new MongoDbRepositorio().Todos<TesteMongo>().Count, 0);
    }
  }

  internal class TesteMongo : IDoc
  {
    [BsonId()]
    public ObjectId Id { get; set; }
    
    public string Nome { get; set; }
    public string Aula { get; set; }
  }
}