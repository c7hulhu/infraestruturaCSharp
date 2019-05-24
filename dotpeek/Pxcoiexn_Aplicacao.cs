// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Aplicacao
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Classe de infraestrutura</summary>
  public abstract class Aplicacao
  {
    /// <summary>Console do MMC disponível para a aplicação.</summary>
    private Infra infra;

    /// <summary>Console do MMC disponível para a aplicação.</summary>
    protected internal Infra Infra
    {
      get
      {
        return this.infra;
      }
    }

    /// <summary>Construtora da classe</summary>
    public Aplicacao()
    {
      this.infra = new Infra();
    }
  }
}
