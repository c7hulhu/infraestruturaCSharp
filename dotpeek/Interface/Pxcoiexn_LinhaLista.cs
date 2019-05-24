// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.LinhaLista
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>Conjunto de células para impressão na tela</summary>
  [DebuggerDisplay("{Celulas != null ? \"Celulas.Count = \" + Celulas.Count.ToString() : ToString()}, Celulas = {ToString(),nq}")]
  public class LinhaLista
  {
    private List<string> celulas;

    /// <summary>Células da linha da lista</summary>
    public List<string> Celulas
    {
      get
      {
        return this.celulas;
      }
    }

    /// <summary>Construtora da classe</summary>
    public LinhaLista()
    {
      this.celulas = new List<string>();
    }

    /// <summary>Retorna todas células concatenadas</summary>
    /// <returns></returns>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string celula in this.Celulas)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append("; ");
        stringBuilder.Append(celula);
      }
      return stringBuilder.ToString();
    }
  }
}
