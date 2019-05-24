// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Mensagem
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Classe de retorno de mensagens</summary>
  public class Mensagem
  {
    /// <summary>Conteúdo da mensagem</summary>
    protected string mensagem;

    /// <summary>Mensagem retornada para o operador</summary>
    public string ParaOperador
    {
      get
      {
        return this.mensagem;
      }
    }

    /// <summary>Construtor da classe</summary>
    public Mensagem()
    {
      this.mensagem = string.Empty;
    }

    /// <summary>Construtor da classe</summary>
    /// <param name="excecao"></param>
    public Mensagem(Exception excecao)
    {
      this.mensagem = excecao.Message;
    }

    /// <summary>Construtor da classe</summary>
    /// <param name="mensagem"></param>
    internal Mensagem(string mensagem)
    {
      this.mensagem = mensagem;
    }

    /// <summary>Mensagem</summary>
    /// <returns></returns>
    public override string ToString()
    {
      return this.mensagem;
    }
  }
}
