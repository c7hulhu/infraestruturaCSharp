// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.RegistroDuplicadoException
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Exceção de chave primária duplicada</summary>
  public class RegistroDuplicadoException : Exception
  {
    /// <summary>As alterações solicitadas para a tabela não foram satisfatórias já que criariam valores duplicados no índice, chave primária ou relação. Altere os dados no campo ou campos que contêm os dados duplicados, remova o índice ou redefina o índice para possibilitar entradas duplicadas e tente novamente.</summary>
    public RegistroDuplicadoException(string msg)
      : base(msg)
    {
    }
  }
}
