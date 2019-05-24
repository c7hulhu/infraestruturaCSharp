// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.AplicacaoDados
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Executa um comando no banco</summary>
  public class AplicacaoDados : Aplicacao
  {
    /// <summary>SQL que será executado na base de dados</summary>
    protected readonly ConstrutorSql Sql;

    /// <summary>Construtora da classe</summary>
    public AplicacaoDados()
    {
      this.Sql = new ConstrutorSql();
    }

    /// <summary>Executa uma consulta ao banco</summary>
    /// <returns>Lista de linhas retornadas</returns>
    protected Retorno<List<Linha>> Consultar()
    {
      try
      {
        List<Linha> dados = new List<Linha>();
        this.Sql.ComandoSql.Connection = this.Infra.banco.Connection;
        this.Sql.ComandoSql.Transaction = this.Infra.banco.Transacao;
        this.Sql.ComandoSql.CommandText = this.Sql.Comando.ToString();
        this.Sql.ComandoSql.CommandType = CommandType.Text;
        using (OleDbDataReader oleDbDataReader = this.Sql.ComandoSql.ExecuteReader())
        {
          while (oleDbDataReader.Read())
          {
            Linha linha = new Linha();
            for (int ordinal = 0; ordinal < oleDbDataReader.FieldCount; ++ordinal)
              linha.Campos.Add(new Campo(oleDbDataReader.GetName(ordinal).ToUpper(), oleDbDataReader.GetValue(ordinal)));
            dados.Add(linha);
          }
          oleDbDataReader.Close();
        }
        return this.Infra.RetornarSucesso<List<Linha>>(dados, (Mensagem) new OperacaoRealizadaMensagem());
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Executa um comando no banco de dados, gera exceção MultiplosDadosException caso mais de 1 registro seja excluído/alterado/incluído
    /// </summary>
    /// <returns>Retorno a quantidade de registros afetados</returns>
    protected Retorno<int> Executar()
    {
      try
      {
        this.Sql.ComandoSql.Connection = this.Infra.banco.Connection;
        this.Sql.ComandoSql.Transaction = this.Infra.banco.Transacao;
        this.Sql.ComandoSql.CommandText = this.Sql.Comando.ToString();
        this.Sql.ComandoSql.CommandType = CommandType.Text;
        int dados = this.Sql.ComandoSql.ExecuteNonQuery();
        if (dados > 1)
          throw new MultiplosDadosException();
        return this.Infra.RetornarSucesso<int>(dados, (Mensagem) new OperacaoRealizadaMensagem());
      }
      catch (OleDbException ex)
      {
        if (ex.Message.ToUpper().IndexOf("NÃO PODE SER EXCLUÍDO") >= 0)
          throw new ChaveEstrangeiraReferenciadaException(ex.Message);
        if (ex.Message.ToUpper().IndexOf("CRIARAM VALORES DUPLICADOS NO ÍNDICE, CHAVE PRIMÁRIA") >= 0)
          throw new RegistroDuplicadoException(ex.Message);
        if (ex.Message.ToUpper().IndexOf("NÃO É POSSÍVEL ADICIONAR OU ALTERAR REGISTROS, POIS É NECESSÁRIO QUE ELES TENHAM UM REGISTRO RELACIONADO NA TABELA") >= 0)
          throw new ChaveEstrangeiraInexistenteException(ex.Message);
        throw ex;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Executa um comando no banco de dados</summary>
    /// <returns>Retorno a quantidade de registros afetados</returns>
    protected Retorno<int> ExecutarMultiplosDados()
    {
      try
      {
        this.Sql.ComandoSql.Connection = this.Infra.banco.Connection;
        this.Sql.ComandoSql.Transaction = this.Infra.banco.Transacao;
        this.Sql.ComandoSql.CommandText = this.Sql.Comando.ToString();
        this.Sql.ComandoSql.CommandType = CommandType.Text;
        return this.Infra.RetornarSucesso<int>(this.Sql.ComandoSql.ExecuteNonQuery(), (Mensagem) new OperacaoRealizadaMensagem());
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Delegate que será executado na montagem dos campos</summary>
    /// <param name="nomeCampo"></param>
    /// <param name="campo"></param>
    protected delegate void MontarCampo(string nomeCampo, ICampo campo);
  }
}
