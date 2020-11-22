using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;
using NUnit.Framework;
using System.Collections.Generic;

namespace Desafio21diasTDD
{
    public class UTestsIRepositorio
    {
        //[SetUp]
        //public void Setup()
        //{
        //    var db = new DbTexto();
        //    db.Salvar(new Modelo() { Titulo = "Modelo 1" });
        //    db.Salvar(new Modelo() { Titulo = "Modelo 2" });
        //    db.Salvar(new Modelo() { Titulo = "Modelo 3" });
        //    db.Salvar(new Modelo() { Titulo = "Modelo 4" });
        //    db.Salvar(new Modelo() { Titulo = "Modelo 5" });
        //}

        //[Test]
        //public void ExcluirDadosRepo()
        //{
        //    var db = new DbTexto();
        //    int qtdOriginal = db.Todos<Modelo>().Count;

        //    db.Excluir<Modelo>(3);

        //    int qtdExcluido = db.Todos<Modelo>().Count;

        //    Assert.IsTrue(qtdExcluido < qtdOriginal);
        //}

        //[Test]
        //public void IncluirDadosRepo()
        //{
        //    var db = new DbTexto();
        //    int qtdOriginal = db.Todos<Modelo>().Count;

        //    db.Salvar(new Modelo(){Titulo = "12345678"});

        //    int qtdNova = db.Todos<Modelo>().Count;

        //    Assert.IsTrue(qtdNova > qtdOriginal);
        //}

        //[Test]
        //public void BuscarModelo2()
        //{
        //    var db = new DbTexto();
        //    Modelo modelo = (Modelo)db.BuscaPorId<Modelo>(2);
        //    Assert.IsTrue(modelo.Titulo == "Modelo 2");
        //}
    }

    internal class Modelo : IModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }


  //  internal class DbTexto : IRepositorio
  //  {
  //      private static int idIdentity = 1;
  //      private static List<T> db = new List<T>();
  //      public T BuscaPorId<T>(int id)
  //      {
  //          return db.Find(c => c.Id == id);
  //      }

  //      public string DadosDoArmazenamento()
  //      {
  //          return string.Empty;
  //      }

  //      public void Excluir<T>(int id)
  //      {
  //          db.RemoveAll(c => c.Id == id);
  //      }

  //      public void Salvar(IModel modelo)
  //      {
  //          if (modelo.Id == 0)
  //          {
  //              modelo.Id = idIdentity;
  //              db.Add(modelo);
  //              idIdentity++;
  //              return;
  //          }

  //          foreach (var objeto in db)
  //          {
  //              if (objeto.Id == modelo.Id)
  //              {
  //                  // clienteBase.Nome = cliente.Nome;
  //                  // clienteBase.Telefone = cliente.Telefone;
  //                  // clienteBase.Endereco = cliente.Endereco;
  //              }
  //          }
  //      }

  //      public List<T> Todos<T>()
  //      {
  //          return db;
  //      }
  //}
}