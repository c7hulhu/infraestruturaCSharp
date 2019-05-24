// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.ItemMenu
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.Collections.Generic;
using System.Diagnostics;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>Item de menu utilizado na Tela</summary>
  [DebuggerDisplay("Key = {Item.Key.ToString()}, Value = {Item.Value}, InterrompeExecucao = {InterrompeExecucao}, SolicitaTecleAlgo = {SolicitaTecleAlgo}")]
  public struct ItemMenu
  {
    /// <summary>Opções de menu</summary>
    public KeyValuePair<int, string> Item;
    /// <summary>Função a ser chamada quando a opção for acionada</summary>
    public Menu.DelegateExecutaMenu OnExecuta;
    /// <summary>Indica se é uma opção que interrompe a execução do controle de menu</summary>
    public bool InterrompeExecucao;
    /// <summary>Indica se é uma opção que apresenta Console.ReadKey() após sua execução</summary>
    public bool SolicitaTecleAlgo;

    /// <summary>Construtor do item de menu</summary>
    /// <param name="item">Item de menu com seu número e descrição para listagem na tela</param>
    /// <param name="onExecuta">Método a ser chamado quando o item de menu for selecionado</param>
    /// <param name="interrompeExecucao">Indica se deve interromper a execução do controle de menu ao ser acionado esse item</param>
    public ItemMenu(
      KeyValuePair<int, string> item,
      Menu.DelegateExecutaMenu onExecuta,
      bool interrompeExecucao)
    {
      this = new ItemMenu(item, onExecuta, interrompeExecucao, true);
    }

    /// <summary>Construtor do item de menu</summary>
    /// <param name="item">Item de menu com seu número e descrição para listagem na tela</param>
    /// <param name="onExecuta">Método a ser chamado quando o item de menu for selecionado</param>
    /// <param name="interrompeExecucao">Indica se deve interromper a execução do controle de menu ao ser acionado esse item</param>
    /// <param name="solicitaTecleAlgo">Indica se o controle do menu apresentará o 'Tecle algo para continuar' ao final da execução</param>
    public ItemMenu(
      KeyValuePair<int, string> item,
      Menu.DelegateExecutaMenu onExecuta,
      bool interrompeExecucao,
      bool solicitaTecleAlgo)
    {
      this.Item = item;
      this.OnExecuta = onExecuta;
      this.InterrompeExecucao = interrompeExecucao;
      this.SolicitaTecleAlgo = solicitaTecleAlgo;
    }
  }
}
