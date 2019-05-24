// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.ViolacaoBDException
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Exceção de violação de integridade arquitetural</summary>
  public class ViolacaoBDException : Exception
  {
    /// <summary>Construtora da classe</summary>
    public ViolacaoBDException()
      : base("Não é permitido instanciar uma camada de BD ou RN a partir da camada de BD.")
    {
    }
  }
}
