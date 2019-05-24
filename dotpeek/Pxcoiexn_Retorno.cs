// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Retorno
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.Diagnostics;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Estrutura de retorno</summary>
  [DebuggerDisplay("Ok = {Ok}, Mensagem = {Mensagem.ParaOperador},nq}")]
  public struct Retorno
  {
    /// <summary>Indica se o método foi realizado com sucesso</summary>
    public readonly bool Ok;
    /// <summary>Mensagem retornada pelo método</summary>
    public readonly Mensagem Mensagem;

    /// <summary>Construtor da classe</summary>
    /// <param name="Ok"></param>
    /// <param name="mensagem">Mensagem, no caso de existir</param>
    internal Retorno(bool Ok, Mensagem mensagem)
    {
      this.Ok = Ok;
      if (mensagem == null)
        throw new MensagemInvalidaException();
      this.Mensagem = mensagem;
    }
  }
}
