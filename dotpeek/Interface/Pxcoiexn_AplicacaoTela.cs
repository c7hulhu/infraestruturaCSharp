// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.AplicacaoTela
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using Bergs.Pxc.Pxcoiexn.BD;
using System;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>Aplicação que implementa a interface</summary>
  public class AplicacaoTela : Aplicacao, IDisposable
  {
    /// <summary>Construtora da classe</summary>
    /// <param name="caminho">Caminho do banco de dados Access</param>
    public AplicacaoTela(string caminho)
    {
      try
      {
        this.Infra.banco = new Access(caminho);
        this.Infra.banco.Abrir();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Construtora da classe</summary>
    /// <param name="caminho">Caminho do banco de dados Access</param>
    /// <param name="provider">Padrão: "Microsoft.Jet.OLEDB.4.0"</param>
    public AplicacaoTela(string caminho, string provider)
    {
      try
      {
        this.Infra.banco = new Access(caminho, provider);
        this.Infra.banco.Abrir();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Construtora da classe</summary>
    public AplicacaoTela()
    {
      try
      {
        this.Infra.banco = new Access();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Abre a conexão ao banco de dados</summary>
    public void Abrir()
    {
      this.Infra.banco.Abrir();
    }

    /// <summary>Abre a conexão ao banco de dados</summary>
    /// <param name="caminho">Caminho do banco de dados Access</param>
    public void Abrir(string caminho)
    {
      this.Infra.banco.database = caminho;
      this.Infra.banco.Abrir();
    }

    /// <summary>Libera os objetos da memória e fecha o banco de dados</summary>
    public void Dispose()
    {
      if (this.Infra.banco == null)
        return;
      this.Infra.banco.Dispose();
    }
  }
}
