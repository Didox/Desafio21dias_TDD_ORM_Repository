using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Cache;
using Desafio21diasAPI.Servicos.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Desafio21diasTDD
{
    public class UTestsCacheHelper
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestaAdicionarListaNoCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                var listaDeObjetos = new List<ModeloCache>();
                new CacheHelperTest().AdicionarListaNoCache<ModeloCache>(listaDeObjetos, "modelosNoTeste");
            });
        }
        
        [Test]
        public void TestaAdicionarModeloNoCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                var modelo = new ModeloCache();
                new CacheHelperTest().AdicionarModeloNoCache<ModeloCache>(modelo, "modeloNoTeste");
            });
        }

        [Test]
        public void TestaAdicionarListaNoCacheComMinutoCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                var listaDeObjetos = new List<ModeloCache>();
                new CacheHelperTest().AdicionarListaNoCache<ModeloCache>(listaDeObjetos, "modelosNoTeste", 20);
            });
        }
        
        [Test]
        public void TestaAdicionarModeloNoCacheComMinutoCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                var modelo = new ModeloCache();
                new CacheHelperTest().AdicionarModeloNoCache<ModeloCache>(modelo, "modeloNoTeste", 10);
            });
        }

        [Test]
        public void TestaLimpaCacheComMinutoCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new CacheHelperTest().LimpaCache("chaveDoCacheModel");
            });
        }

        [Test]
        public void TestaListaDeModelosEmCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new CacheHelperTest().ListaDeModelosEmCache<ModeloCache>("chaveDaListaDeObjetos");
            });
        }

        [Test]
        public void TestaModeloEmCache()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                new CacheHelperTest().ModeloEmCache<ModeloCache>("chaveDoModeloEmCache");
            });
        }
    }

    internal class ModeloCache
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }


  internal class CacheHelperTest : ICache
  {
    public void AdicionarListaNoCache<T>(List<T> modelos, string chave, int minutosCache = 0)
    {
      throw new NotImplementedException();
    }

    public void AdicionarModeloNoCache<T>(T modelo, string chave, int minutosCache = 0)
    {
      throw new NotImplementedException();
    }

    public void LimpaCache(string chave)
    {
      throw new NotImplementedException();
    }

    public List<T> ListaDeModelosEmCache<T>(string chave)
    {
      throw new NotImplementedException();
    }

    public T ModeloEmCache<T>(string chave)
    {
      throw new NotImplementedException();
    }
  }
}