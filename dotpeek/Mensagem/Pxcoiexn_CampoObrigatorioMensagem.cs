// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.CampoObrigatorioMensagem
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

namespace Bergs.Pxc.Pxcoiexn
{
  /// <summary>Operação realizada com sucesso</summary>
  public class CampoObrigatorioMensagem : Mensagem
  {
    /// <summary>Campo obrigatório {0} não foi informado</summary>
    /// <param name="campo"></param>
    public CampoObrigatorioMensagem(string campo)
      : base(string.Format("Campo obrigatório {0} não foi informado", (object) campo))
    {
    }
  }
}
