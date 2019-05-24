// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.CabecalhoLista
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.Diagnostics;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>Célula de uma linha da lista</summary>
  [DebuggerDisplay("Conteudo = {Conteudo}, Alinhamento = {Alinhamento}")]
  public class CabecalhoLista
  {
    private bool visivel;
    private string conteudo;
    private CabecalhoLista.AlinhamentoCelula alinhamento;
    private int largura;

    /// <summary>Conteúdo da célula</summary>
    public string Conteudo
    {
      get
      {
        return this.conteudo;
      }
      set
      {
        this.conteudo = value;
      }
    }

    /// <summary>Indica se o conteúdo é visível na lista</summary>
    public bool Visivel
    {
      get
      {
        return this.visivel;
      }
      set
      {
        this.visivel = true;
      }
    }

    /// <summary>Alinhamento do conteúdo da célula</summary>
    public CabecalhoLista.AlinhamentoCelula Alinhamento
    {
      get
      {
        return this.alinhamento;
      }
      set
      {
        this.alinhamento = value;
      }
    }

    /// <summary>Largura máxima da coluna</summary>
    public int Largura
    {
      get
      {
        return this.largura;
      }
      set
      {
        this.largura = value;
      }
    }

    /// <summary>Construtora da célula</summary>
    public CabecalhoLista()
    {
      this.visivel = true;
      this.conteudo = string.Empty;
      this.largura = 76;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo</param>
    /// <param name="visivel">Indica se é visível ou não</param>
    public CabecalhoLista(string conteudo, bool visivel)
    {
      this.conteudo = conteudo;
      this.visivel = visivel;
      this.alinhamento = CabecalhoLista.AlinhamentoCelula.Esquerda;
      this.largura = 76;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo da célula</param>
    public CabecalhoLista(string conteudo)
    {
      this.conteudo = conteudo;
      this.visivel = true;
      this.alinhamento = CabecalhoLista.AlinhamentoCelula.Esquerda;
      this.largura = 76;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo da célula</param>
    /// <param name="alinhamento">Alinhamento do conteúdo</param>
    /// <param name="visivel">Indica se é visível ou não</param>
    public CabecalhoLista(
      string conteudo,
      CabecalhoLista.AlinhamentoCelula alinhamento,
      bool visivel)
    {
      this.conteudo = conteudo;
      this.alinhamento = alinhamento;
      this.visivel = visivel;
      this.largura = 76;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo da célula</param>
    /// <param name="alinhamento">Alinhamento do conteúdo</param>
    public CabecalhoLista(string conteudo, CabecalhoLista.AlinhamentoCelula alinhamento)
    {
      this.conteudo = conteudo;
      this.alinhamento = alinhamento;
      this.visivel = true;
      this.largura = 76;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo da célula</param>
    /// <param name="alinhamento">Alinhamento do conteúdo</param>
    /// <param name="visivel">Indica se é visível ou não</param>
    /// <param name="largura">Largura máxima da coluna</param>
    public CabecalhoLista(
      string conteudo,
      CabecalhoLista.AlinhamentoCelula alinhamento,
      bool visivel,
      int largura)
    {
      this.conteudo = conteudo;
      this.alinhamento = alinhamento;
      this.visivel = visivel;
      this.largura = largura;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo da célula</param>
    /// <param name="alinhamento">Alinhamento do conteúdo</param>
    /// <param name="largura">Largura máxima da coluna</param>
    public CabecalhoLista(
      string conteudo,
      CabecalhoLista.AlinhamentoCelula alinhamento,
      int largura)
    {
      this.conteudo = conteudo;
      this.alinhamento = alinhamento;
      this.visivel = true;
      this.largura = largura;
    }

    /// <summary>Construtora da célula</summary>
    /// <param name="conteudo">Conteúdo da célula</param>
    /// <param name="largura">Largura máxima da coluna</param>
    public CabecalhoLista(string conteudo, int largura)
    {
      this.conteudo = conteudo;
      this.alinhamento = CabecalhoLista.AlinhamentoCelula.Esquerda;
      this.visivel = true;
      this.largura = largura;
    }

    /// <summary>Alinhamento do conteúdo da célula</summary>
    public enum AlinhamentoCelula
    {
      /// <summary>Alinhamento à esquerda</summary>
      Esquerda,
      /// <summary>Alinhamento à direita</summary>
      Direita,
      /// <summary>Alinhamento à centralizado</summary>
      Centralizado,
    }
  }
}
