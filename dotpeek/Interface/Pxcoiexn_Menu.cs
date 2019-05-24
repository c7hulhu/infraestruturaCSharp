// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.Menu
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.Collections.Generic;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>Menu de interação da Console</summary>
  public struct Menu
  {
    internal object parametro;
    /// <summary>Lista de itens de menu</summary>
    public readonly List<ItemMenu> Itens;

    /// <summary>
    /// Dicionário de dados que possui uma coleção dos itens de menu
    /// </summary>
    public Dictionary<int, string> DicionarioItens
    {
      get
      {
        Dictionary<int, string> dictionary1 = new Dictionary<int, string>();
        foreach (ItemMenu iten in this.Itens)
        {
          Dictionary<int, string> dictionary2 = dictionary1;
          KeyValuePair<int, string> keyValuePair = iten.Item;
          int key = keyValuePair.Key;
          keyValuePair = iten.Item;
          string str = keyValuePair.Value;
          dictionary2.Add(key, str);
        }
        return dictionary1;
      }
    }

    /// <summary>Contrutora da estrutura de menu.
    /// Ex.:
    /// Menu menu = new Menu(
    ///             new ItemMenu[] {
    ///             new ItemMenu( new KeyValuePair&lt;int,string&gt;(1, "Listar"), Listar, false),
    ///             new ItemMenu( new KeyValuePair&lt;int,string&gt;(0, "Sair"), null, true)
    ///             }, objetoParametro);
    /// </summary>
    /// <param name="itens">List de ItemMenu ou vetor de ItemMenu </param>
    /// <param name="parametro">Parâmetro a ser passado para a função de destino</param>
    public Menu(object itens, object parametro)
    {
      this.parametro = parametro;
      if (itens.GetType() == typeof (List<ItemMenu>))
        this.Itens = (List<ItemMenu>) itens;
      else if (itens.GetType() == typeof (ItemMenu[]))
      {
        this.Itens = new List<ItemMenu>();
        foreach (ItemMenu iten in (ItemMenu[]) itens)
          this.Itens.Add(iten);
      }
      else
        this.Itens = new List<ItemMenu>();
    }

    /// <summary>Assinatura do método de retorno quando uma ação do menu é acionada</summary>
    /// <param name="parametro">Parâmetro que foi passado ao construtor do Menu</param>
    public delegate void DelegateExecutaMenu(object parametro);

    /// <summary>Assinatura do método de retorno após a impressão do título do menu pelo método ControlaMenu</summary>
    public delegate void DelegateAcaoMenu();
  }
}
