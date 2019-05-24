// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.RN.EscopoTransacional
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;

namespace Bergs.Pxc.Pxcoiexn.RN
{
  /// <summary>Classe que controla o escopo transacional de acesso ao banco de dados</summary>
  public sealed class EscopoTransacional : IDisposable
  {
    /// <summary>
    /// Método que será acionado ao final da transação, ou pelo Dispose ou pelo EfetivarTransacao
    /// </summary>
    internal EscopoTransacional.FimTransacao OnFimTransacao = (EscopoTransacional.FimTransacao) null;
    private bool fimTransacao = false;

    /// <summary>Método que encerra o escopo, se não tiver efetivado a transação, é realizado um Roolback na base</summary>
    public void Dispose()
    {
      if (this.fimTransacao)
        return;
      this.fimTransacao = true;
      if (this.OnFimTransacao != null)
        this.OnFimTransacao(false);
    }

    /// <summary>Realiza um commit na base após a criação do EscopoTransacional</summary>
    public void EfetivarTransacao()
    {
      if (this.fimTransacao)
        return;
      this.fimTransacao = true;
      if (this.OnFimTransacao != null)
        this.OnFimTransacao(true);
    }

    internal delegate void FimTransacao(bool Commit);
  }
}
