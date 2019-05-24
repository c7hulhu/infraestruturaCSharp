// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.OperadorUnario
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.ComponentModel;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Operadores unários para o comando SQL</summary>
  public enum OperadorUnario
  {
    /// <summary>Maior</summary>
    [Description(">")] Maior,
    /// <summary>Maior ou igual</summary>
    [Description(">=")] MaiorIgual,
    /// <summary>Menor</summary>
    [Description("<")] Menor,
    /// <summary>Menor ou igual</summary>
    [Description("<=")] MenorIgual,
    /// <summary>Diferente</summary>
    [Description("<>")] Diferente,
    /// <summary>Igual</summary>
    [Description("=")] Igual,
    /// <summary>Like</summary>
    [Description("LIKE")] Like,
    /// <summary>Is Null</summary>
    [Description("IS NULL")] IsNull,
    /// <summary>Is Not Null</summary>
    [Description("IS NOT NULL")] IsNotNull,
    /// <summary>Between</summary>
    [Description("BETWEEN")] Between,
  }
}
