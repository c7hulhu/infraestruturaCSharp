// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.ChaveEstrangeiraReferenciadaException
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>
  /// Exceção de múltiplos registros afetados pela execução do comando
  /// </summary>
  public class ChaveEstrangeiraReferenciadaException : Exception
  {
    /// <summary>O registro não pode ser excluído ou alterado porque existe uma ou mais tabelas que incluem registros relacionados a ele.</summary>
    public ChaveEstrangeiraReferenciadaException(string msg)
      : base(msg)
    {
    }
  }
}
