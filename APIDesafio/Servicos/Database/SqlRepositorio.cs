using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Desafio21diasAPI.Models;
using Newtonsoft.Json.Linq;

namespace Desafio21diasAPI.Servicos.Database
{
  public class SqlRepositorio : IRepositorio
  {

    public string DadosDoArmazenamento()
    {
      JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
      return jAppSettings["sqlCnn"].ToString();
    }

    public static string PreparaCampoQuery(string valor)
    {
      valor = valor.Replace("'", "");
      valor = valor.Replace("[", "[[]");
      valor = valor.Replace("%", "[%]");
      valor = valor.Replace("_", "[_]");
      return valor;
    }

    private string nomeTabela(object modelo)
    {
      return $"{modelo.GetType().Name.ToLower()}s";
    }
    private void PreencherObjeto(object modelo, SqlDataReader dr)
    {
      foreach (var p in modelo.GetType().GetProperties())
      {
        try
        {
          if (dr[p.Name] == DBNull.Value) continue;
          p.SetValue(modelo, dr[p.Name]);
        }
        catch { }
      }
    }

    public List<T> Todos<T>(string criterio)
    {
      string sql;

      var list = new List<T>();
      using (SqlConnection conn = new SqlConnection(DadosDoArmazenamento()))
      {
        var obj = Activator.CreateInstance(typeof(T));

        string tabela = this.nomeTabela(obj);

        sql = $"select * from {tabela} ";
        if (!string.IsNullOrEmpty(criterio))
        {
          sql += $"where {criterio}";
        }

        SqlCommand cmd = new SqlCommand(sql, conn);
        try
        {

          cmd.CommandType = System.Data.CommandType.Text;

          conn.Open();

          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              var instancia = Activator.CreateInstance(typeof(T));
              this.PreencherObjeto(instancia, dr);
              list.Add((T)instancia);
            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
        return list;
      }
    }
    public List<T> Todos<T>()
    {
      return this.Todos<T>(string.Empty);
    }

    public T BuscaPorId<T>(int id)
    {
      throw new NotImplementedException();
    }

    public void Salvar<T>(T cliente)
    {
      throw new NotImplementedException();
    }

    public void Excluir<T>(int id)
    {
      throw new NotImplementedException();
    }
  }
}
