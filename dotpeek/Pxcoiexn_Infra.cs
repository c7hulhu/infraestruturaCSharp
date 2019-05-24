// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Infra
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using Bergs.Pxc.Pxcoiexn.BD;
using Bergs.Pxc.Pxcoiexn.RN;
using System;
using System.Data.OleDb;
using System.Reflection;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>
  /// Concentrador da infra-estrutura MMC - Meta Modelo C# - ConsoleApplication
  /// </summary>
  public sealed class Infra
  {
    internal Access banco;

    /// <summary>
    /// Cria um escopo transacional para atualização dos campos na tabela
    /// </summary>
    /// <returns></returns>
    public EscopoTransacional CriarEscopoTransacional()
    {
      EscopoTransacional escopoTransacional = new EscopoTransacional();
      escopoTransacional.OnFimTransacao += new EscopoTransacional.FimTransacao(this.FimTransacao);
      ++this.banco.transacoes;
      if (this.banco.transacoes == 1)
        this.banco.transacao = this.banco.Connection.BeginTransaction();
      return escopoTransacional;
    }

    /// <summary>
    /// Método acionado no Dispose do escopotransacional ou na execução do EfetivarTransacao
    /// </summary>
    /// <param name="Commit"></param>
    private void FimTransacao(bool Commit)
    {
      if (this.banco.transacoes <= 0)
        return;
      --this.banco.transacoes;
      if (this.banco.transacoes == 0)
      {
        if (Commit)
          this.banco.transacao.Commit();
        else
          this.banco.transacao.Rollback();
        this.banco.transacao = (OleDbTransaction) null;
      }
    }

    /// <summary>Retorna sucesso</summary>
    /// <param name="mensagem">Mensagem a ser retornada</param>
    /// <returns>Retorna sucesso</returns>
    public Retorno RetornarSucesso(Mensagem mensagem)
    {
      return new Retorno(true, mensagem);
    }

    /// <summary>Retorna sucesso com os dados</summary>
    /// <typeparam name="T">Tipo de dado a ser retornado</typeparam>
    /// <param name="dados">Dados de retorno</param>
    /// <param name="mensagem">Mensagem a ser retornada</param>
    /// <returns>Retorna sucesso</returns>
    public Retorno<T> RetornarSucesso<T>(T dados, Mensagem mensagem)
    {
      return new Retorno<T>(true, dados, mensagem);
    }

    /// <summary>Retorna falha com a mensagem</summary>
    /// <typeparam name="T">Tipo de dado a ser retornado</typeparam>
    /// <param name="mensagem">Mensagem a ser retornada</param>
    /// <returns>Retorna falha</returns>
    public Retorno<T> RetornarFalha<T>(Mensagem mensagem)
    {
      if (mensagem == null || string.IsNullOrEmpty(mensagem.ToString()))
        throw new Exception("Mensagem inválida. Não pode ser nula ou vazia.");
      return new Retorno<T>(false, default (T), mensagem);
    }

    /// <summary>Retorna falha com a mensagem</summary>
    /// <param name="mensagem">Mensagem a ser retornada</param>
    /// <returns>Retorna falha</returns>
    public Retorno RetornarFalha(Mensagem mensagem)
    {
      if (mensagem == null || string.IsNullOrEmpty(mensagem.ToString()))
        throw new Exception("Mensagem inválida. Não pode ser nula ou vazia.");
      return new Retorno(false, mensagem);
    }

    /// <summary>Instancia uma classe de BD</summary>
    /// <typeparam name="T">Tipo de classe de Bergs.Pxc.Pxcoiexn.BD.AplicacaoDados</typeparam>
    /// <returns>Instância da classe</returns>
    public T InstanciarBD<T>() where T : AplicacaoDados, new()
    {
      string upper1 = Assembly.GetAssembly(this.GetType()).ManifestModule.Name.ToUpper();
      string upper2 = Assembly.GetAssembly(typeof (T)).ManifestModule.Name.ToUpper();
      if (upper1.Length == 12 && upper2.Length == 12)
      {
        if (upper1[3] == 'S' && upper2[3] == 'Q' && upper1.Substring(4, 2) != upper2.Substring(4, 2))
          throw new ViolacaoArquiteturalException();
        if (upper1[3] == 'Q')
          throw new ViolacaoBDException();
      }
      if (this.banco == null)
        throw new BancoDadosException();
      return new T() { Infra = { banco = this.banco } };
    }

    /// <summary>Instancia uma classe de RN</summary>
    /// <typeparam name="T">Tipo de classe de Bergs.Pxc.Pxcoiexn.RN.AplicacaoRegraNegocio</typeparam>
    /// <returns>Instância da classe</returns>
    public T InstanciarRN<T>() where T : AplicacaoRegraNegocio, new()
    {
      return new T() { Infra = { banco = this.banco } };
    }
  }
}
