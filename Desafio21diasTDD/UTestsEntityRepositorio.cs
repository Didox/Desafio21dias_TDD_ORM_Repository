using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;

namespace Desafio21diasTDD
{
  public class UTestsEntityRepositorio
  {
    [SetUp]
    public void Setup()
    {
      new EntityRepositorio().Database.ExecuteSqlRaw("truncate table testes");
    }

    [Test]
    public void TestaInserirNoDadoBanco()
    {
      var db = new EntityRepositorio();
      db.Add(new Teste() { Nome = "Danilo teste 1" });
      db.Add(new Teste() { Nome = "Danilo teste 2" });
      db.Add(new Teste() { Nome = "Danilo teste 3" });
      db.SaveChanges();

      Assert.AreEqual(db.Testes.Count(), 3);
    }

    [Test]
    public void TestaAlterarNoDadoBanco()
    {
      var dbInsert = new EntityRepositorio();
      var teste = new Teste() { Nome = "Danilo teste 1" };
      dbInsert.Add(teste);
      dbInsert.SaveChanges();
      dbInsert.Dispose();

      var dbAltera = new EntityRepositorio();
      var testeSalvo = dbAltera.Testes.Where(t => t.Id == 1).First();

      testeSalvo.Nome = "Nome alterado";
      dbAltera.Update(testeSalvo);
      dbAltera.SaveChanges();
      dbAltera.Dispose();

      var db = new EntityRepositorio();
      var testeSalvoProva = db.Testes.Where(t => t.Id == 1).First();

      Assert.AreEqual(testeSalvoProva.Nome, "Nome alterado");
    }

    [Test]
    public void TestaBuscaPorIdNoDadoBanco()
    {
      var db = new EntityRepositorio();
      var teste = new Teste() { Nome = "Danilo teste 1" };
      db.Add(teste);
      db.SaveChanges();

      var testeSalvo = db.Testes.Where(t => t.Id == 1).First();
      Assert.AreEqual(testeSalvo.Id, 1);
    }

    [Test]
    public void TestaBuscaComQueryNoDadoBanco()
    {
      var db = new EntityRepositorio();
      var teste = new Teste() { Nome = "Danilo teste 1" };
      db.Add(teste);
      db.SaveChanges();

      var lista = db.Testes.Where(t => t.Nome.ToLower().Contains("danilo")).ToList();
      Assert.AreEqual(lista.Count, 1);
    }

    [Test]
    public void TestaBuscaComSqlQueryNoDadoBanco()
    {
      var db = new EntityRepositorio();
      var teste = new Teste() { Nome = "Danilo teste 1" };
      db.Add(teste);
      db.SaveChanges();

      var lista = db.Testes.FromSqlRaw("select * from testes where Nome like '%Danilo%'").ToList();
      Assert.AreEqual(lista.Count, 1);
    }

    [Test]
    public void TestaExecutaSqlQueryNoDadoBanco()
    {
      var db = new EntityRepositorio();
      var teste = new Teste() { Nome = "Danilo teste 1" };
      db.Add(teste);
      db.SaveChanges();

      db.Database.ExecuteSqlRaw("truncate table testes");
      Assert.AreEqual(db.Testes.Count(), 0);
    }
  }

  internal partial class Teste : IModel 
  { 
    [NotMapped]
    public string Token {get;set;}
  }

  internal partial class EntityRepositorio : DbContext
  {
    public DbSet<Teste> Testes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
      optionsBuilder.UseSqlServer(jAppSettings["sqlCnn"].ToString());
    }
  }
}