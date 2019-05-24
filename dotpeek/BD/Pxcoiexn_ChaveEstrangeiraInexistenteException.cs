// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.ChaveEstrangeiraInexistenteException
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Exceção para chave estrangeira inexistente</summary>
  public class ChaveEstrangeiraInexistenteException : Exception
  {
    /// <summary>Não é possível adicionar ou alterar registros, pois é necessário que eles tenham um registro relacionado na tabela XXXXX.</summary>
    public ChaveEstrangeiraInexistenteException(string msg)
      : base(msg)
    {
    }
  }
}
