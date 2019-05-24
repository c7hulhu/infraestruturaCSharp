// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.Access
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Classe de acesso ao Access</summary>
  internal sealed class Access : IDisposable
  {
    /// <summary>Obejto de conexão ao banco de dados</summary>
    public readonly OleDbConnection Connection = (OleDbConnection) null;
    /// <summary>Caminho do banco de dados Access</summary>
    internal string database = string.Empty;
    private string providerName = "Microsoft.Jet.OLEDB.4.0";
    private string connectionString = string.Empty;
    internal int transacoes = 0;
    internal OleDbTransaction transacao = (OleDbTransaction) null;

    /// <summary>Retorna a transação corrente</summary>
    internal OleDbTransaction Transacao
    {
      get
      {
        return this.transacao;
      }
    }

    /// <summary>Construtora da classe para acesso ao um banco Access</summary>
    public Access()
    {
      try
      {
        this.Connection = new OleDbConnection();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Construtora da classe para acesso ao um banco Access</summary>
    /// <param name="database">Caminho completo do arquivo Access</param>
    public Access(string database)
    {
      try
      {
        this.database = database;
        this.Connection = new OleDbConnection();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Construtora da classe para acesso ao um banco Access</summary>
    /// <param name="database">Caminho completo do arquivo Access</param>
    /// <param name="provider">Nome do provedor da conexão ao Access</param>
    public Access(string database, string provider)
    {
      try
      {
        this.database = database;
        this.providerName = provider;
        this.Connection = new OleDbConnection();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Abre uma conexão com o Access</summary>
    /// <returns></returns>
    public void Abrir()
    {
      try
      {
        if (this.Connection.State == ConnectionState.Open)
          return;
        if (!File.Exists(this.database))
          throw new FileNotFoundException(string.Format("Arquivo {0} não encontrado", (object) this.database));
        this.connectionString = string.Format("Provider={0};Data Source={1}", (object) this.providerName, (object) this.database);
        this.Connection.ConnectionString = this.connectionString;
        this.Connection.Open();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Encerra a conexão ao banco de dados, caso tenha uma transação aberta, a mesma terá um Roolback executado
    /// </summary>
    public void Dispose()
    {
      if (this.Connection == null)
        return;
      if (this.transacao != null)
        this.transacao.Rollback();
      this.Connection.Dispose();
    }
  }
}
