// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.OperadorLogico
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.ComponentModel;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Operadores lógicos para o comando SQL</summary>
  public enum OperadorLogico
  {
    /// <summary>AND - E lógico para montagem do SQL</summary>
    [Description("AND")] And,
    /// <summary>OR - OU lógico para montagem do SQL</summary>
    [Description("OR")] Or,
    /// <summary>XOR - 'XOU' lógico para montagem do SQL</summary>
    [Description("XOR")] Xor,
  }
}
