// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.Tela
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.Collections.Generic;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>
  /// Classe de interação com o usuário utilizando "Console.Write"
  /// </summary>
  public class Tela
  {
    private static string margem = "╔═╗║╚╝╦╩╠╣╬";

    /// <summary>Função que controla o menu</summary>
    /// <param name="titulo">Título do menu</param>
    /// <param name="menu">Menu do programa</param>
    /// <returns>Retorna o item selecionado que tenha a opção de interrupção</returns>
    public static int ControlaMenu(string titulo, Menu menu)
    {
      return Tela.ControlaMenu(titulo, menu, (Menu.DelegateAcaoMenu) null);
    }

    /// <summary>Função que controla o menu</summary>
    /// <param name="titulo">Título do menu</param>
    /// <param name="menu">Menu do programa</param>
    /// <param name="funcao">Método a ser chamado após a impressão do título</param>
    /// <returns>Retorna o item selecionado que tenha a opção de interrupção</returns>
    public static int ControlaMenu(string titulo, Menu menu, Menu.DelegateAcaoMenu funcao)
    {
      try
      {
        int op = -1;
        bool flag1 = false;
        do
        {
          if (Tela.MostrarMenu(titulo, menu.DicionarioItens, out op, funcao))
          {
            foreach (ItemMenu iten in menu.Itens)
            {
              bool flag2 = false;
              if (iten.Item.Key == op)
              {
                if (iten.OnExecuta != null)
                  iten.OnExecuta(menu.parametro);
                if (iten.InterrompeExecucao || flag2)
                {
                  flag1 = true;
                  break;
                }
                if (iten.SolicitaTecleAlgo)
                {
                  Console.Write("Tecle algo para continuar...");
                  Console.ReadKey();
                }
                break;
              }
            }
          }
          else
          {
            Console.Write("Opção inválida. Tecle algo...");
            Console.ReadKey();
          }
        }
        while (!flag1);
        return op;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Lê um texto/número do teclado</summary>
    /// <typeparam name="T">Tipo "primitivo" de dados esperado como retorno, deve implementar a interface IConvertible</typeparam>
    /// <param name="label">Texto a ser apresentado ao usuário</param>
    /// <returns>Retorna o texto convertido</returns>
    public static T Ler<T>(string label)
    {
      T retorno;
      Tela.Ler<T>(label, true, out retorno);
      return retorno;
    }

    private static bool Ler<T>(string label, bool exigeValidacao, out T retorno)
    {
      try
      {
        retorno = default (T);
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;
        string[] strArray = label.Split('\n');
        int num1 = 0;
        foreach (string str in strArray)
        {
          double num2 = (double) str.Length / (double) Console.WindowWidth + 0.5;
          num1 += (int) Math.Round(num2, 0);
        }
        while (true)
        {
          Console.SetCursorPosition(cursorLeft, cursorTop);
          Console.Write(label.PadRight(Console.WindowWidth - 1));
          Console.SetCursorPosition(cursorLeft + label.Length, cursorTop + num1 - 1);
          string str = Console.ReadLine();
          Console.Write(string.Empty.PadRight(Console.WindowWidth - 1));
          Console.SetCursorPosition(cursorLeft, cursorTop + num1);
          try
          {
            retorno = (T) Convert.ChangeType((object) str, typeof (T));
            return true;
          }
          catch (Exception ex)
          {
            Console.WriteLine("Erro de conversão.");
            if (!exigeValidacao)
              break;
          }
        }
        return false;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Função que lê uma informação da tela</summary>
    /// <typeparam name="T">Tipo esperado de retorno na leitura, deve implementar a interface IConvertible</typeparam>
    /// <param name="label">Texto a ser apresentado ao usuário</param>
    /// <returns></returns>
    public static Tela.RetornoLeitura<T> LerInfo<T>(string label)
    {
      T retorno;
      if (Tela.Ler<T>(label, false, out retorno))
        return new Tela.RetornoLeitura<T>(true, retorno);
      return new Tela.RetornoLeitura<T>(false, retorno);
    }

    /// <summary>Função que lê S/N do teclado</summary>
    /// <param name="mensagem">Mensagem a ser apresentada ao usuário</param>
    /// <returns>Retorna true se o usuário digitou 'S' ou 's'</returns>
    public static bool Confirma(string mensagem)
    {
      return Tela.Confirma(mensagem, "SN") == 'S';
    }

    /// <summary>Função que lê um caracter do teclado</summary>
    /// <param name="mensagem">Texto a ser apresentado ao usuário</param>
    /// <param name="validos">Caracteres aceitos pela função</param>
    /// <returns>Retorna o caracter válido digitado</returns>
    public static char Confirma(string mensagem, string validos)
    {
      try
      {
        Console.Write(mensagem);
        Console.Write(" ");
        char ch;
        do
        {
          int cursorLeft = Console.CursorLeft;
          int cursorTop = Console.CursorTop;
          ch = Console.ReadKey().KeyChar.ToString().ToUpper()[0];
          if (!validos.Contains(ch.ToString()))
          {
            Console.SetCursorPosition(cursorLeft + 1, cursorTop);
            Console.Write(" ({0})", (object) validos);
          }
          Console.SetCursorPosition(cursorLeft, cursorTop);
        }
        while (!validos.Contains(ch.ToString()));
        Console.WriteLine();
        return ch;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Monta o menu de interação a partir de um dicionário de dados
    /// </summary>
    /// <param name="titulo">Título do menu</param>
    /// <param name="menu">Lista de opções do menu</param>
    /// <param name="op">opção informada pelo usuário</param>
    /// <returns>Retorna true se a opção informada é um item existente na lista</returns>
    public static bool MostrarMenu(string titulo, Dictionary<int, string> menu, out int op)
    {
      return Tela.MostrarMenu(titulo, menu, out op, (Menu.DelegateAcaoMenu) null);
    }

    /// <summary>
    /// Monta o menu de interação a partir de um dicionário de dados
    /// </summary>
    /// <param name="titulo">Título do menu</param>
    /// <param name="menu">Lista de opções do menu</param>
    /// <param name="op">opção informada pelo usuário</param>
    /// <param name="funcao">Método a ser chamado após a impressão do título</param>
    /// <returns>Retorna true se a opção informada é um item existente na lista</returns>
    public static bool MostrarMenu(
      string titulo,
      Dictionary<int, string> menu,
      out int op,
      Menu.DelegateAcaoMenu funcao)
    {
      try
      {
        string str = "╔═╗║╚╝";
        bool flag1 = false;
        int totalWidth1 = 0;
        int totalWidth2 = 0;
        op = -1;
        Console.Clear();
        Console.Title = titulo;
        Console.WriteLine(titulo);
        Console.WriteLine(string.Empty.PadRight(titulo.Length > Console.BufferWidth ? Console.BufferWidth : titulo.Length, str[1]));
        if (funcao != null)
          funcao();
        foreach (KeyValuePair<int, string> keyValuePair in menu)
        {
          int key = keyValuePair.Key;
          if (key.ToString().Length > totalWidth2)
          {
            key = keyValuePair.Key;
            totalWidth2 = key.ToString().Length;
          }
          if (keyValuePair.Value.ToString().Length > totalWidth1)
            totalWidth1 = keyValuePair.Value.ToString().Length;
        }
        Console.WriteLine("\n{0}{1}{2}", (object) str[0], (object) string.Empty.PadRight(totalWidth2 + totalWidth1 + 5, str[1]), (object) str[2]);
        int cursorTop = Console.CursorTop;
        int num1 = cursorTop;
        int num2 = cursorTop + menu.Count;
        bool flag2 = false;
        do
        {
          Console.SetCursorPosition(0, cursorTop);
          foreach (KeyValuePair<int, string> keyValuePair in menu)
          {
            Console.Write(str[3]);
            if (num1 == Console.CursorTop)
              Tela.InverteCores();
            Console.Write(" {0} - {1} ", (object) keyValuePair.Key.ToString().PadLeft(totalWidth2), (object) keyValuePair.Value.PadRight(totalWidth1));
            if (num1 == Console.CursorTop)
              Tela.InverteCores();
            Console.WriteLine(str[3]);
          }
          Console.WriteLine("{0}{1}{2}", (object) str[4], (object) string.Empty.PadRight(totalWidth2 + totalWidth1 + 5, str[1]), (object) str[5]);
          Console.CursorVisible = false;
          ConsoleColor foregroundColor = Console.ForegroundColor;
          Console.ForegroundColor = Console.BackgroundColor;
          ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
          Console.ForegroundColor = foregroundColor;
          Console.CursorVisible = true;
          if (consoleKeyInfo.Key == ConsoleKey.Home)
            num1 = cursorTop;
          else if (consoleKeyInfo.Key == ConsoleKey.End)
            num1 = num2 - 1;
          else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
          {
            if (num1 > cursorTop)
              --num1;
          }
          else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
          {
            if (num1 + 1 < num2)
              ++num1;
          }
          else if (consoleKeyInfo.Key == ConsoleKey.Enter)
          {
            int num3 = 0;
            foreach (KeyValuePair<int, string> keyValuePair in menu)
            {
              if (num3 == num1 - cursorTop)
              {
                op = keyValuePair.Key;
                flag2 = true;
                flag1 = true;
                Console.Title = keyValuePair.Value;
                break;
              }
              ++num3;
            }
          }
          else if (consoleKeyInfo.Key == ConsoleKey.Escape)
          {
            if (num1 == num2 - 1)
            {
              flag1 = false;
              flag2 = true;
            }
            else
              num1 = num2 - 1;
          }
          else
          {
            int num3 = cursorTop - 1;
            foreach (KeyValuePair<int, string> keyValuePair in menu)
            {
              ++num3;
              if (keyValuePair.Key.ToString() == consoleKeyInfo.KeyChar.ToString())
              {
                num1 = num3;
                break;
              }
            }
          }
        }
        while (!flag2);
        return flag1;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Função que mostra o menu na tela</summary>
    /// <param name="titulo"></param>
    /// <param name="menu"></param>
    /// <param name="opcaoInt">True se as opções forem numéricas, False caso seja char</param>
    public static void MostrarMenu(string titulo, Enum menu, bool opcaoInt)
    {
      try
      {
        string str1 = "╔═╗║╚╝";
        int totalWidth1 = 0;
        int totalWidth2 = 0;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.Title = titulo;
        Console.WriteLine(titulo);
        Console.WriteLine(string.Empty.PadRight(titulo.Length > Console.BufferWidth ? Console.BufferWidth : titulo.Length, str1[1]));
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        int length = Enum.GetValues(menu.GetType()).Length;
        int num;
        for (int index = 0; index < length; ++index)
        {
          if (opcaoInt)
          {
            num = (int) Enum.GetValues(menu.GetType()).GetValue(index);
            if (num.ToString().Length > totalWidth2)
            {
              num = (int) Enum.GetValues(menu.GetType()).GetValue(index);
              totalWidth2 = num.ToString().Length;
            }
          }
          else
            totalWidth2 = 1;
          if (Util.DescricaoEnum((Enum) Enum.GetValues(menu.GetType()).GetValue(index)).Length > totalWidth1)
            totalWidth1 = Util.DescricaoEnum((Enum) Enum.GetValues(menu.GetType()).GetValue(index)).Length;
        }
        Console.WriteLine("\n{0}{1}{2}", (object) str1[0], (object) string.Empty.PadRight(totalWidth2 + totalWidth1 + 5, str1[1]), (object) str1[2]);
        for (int index = 0; index < length; ++index)
        {
          string empty = string.Empty;
          string str2;
          if (opcaoInt)
          {
            num = (int) Enum.GetValues(menu.GetType()).GetValue(index);
            str2 = num.ToString();
          }
          else
            str2 = Convert.ToChar(Enum.GetValues(menu.GetType()).GetValue(index)).ToString();
          Console.WriteLine("{0} {1} - {2} {3}", new object[4]
          {
            (object) str1[3],
            (object) str2.PadLeft(totalWidth2),
            (object) Util.DescricaoEnum((Enum) Enum.GetValues(menu.GetType()).GetValue(index)).PadRight(totalWidth1),
            (object) str1[3]
          });
        }
        Console.WriteLine("{0}{1}{2}\n", (object) str1[4], (object) string.Empty.PadRight(totalWidth2 + totalWidth1 + 5, str1[1]), (object) str1[5]);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>Imprime uma lista na tela</summary>
    /// <param name="titulo">Título da lista</param>
    /// <param name="cabecalho">Nome do cabeçalho das colunas</param>
    /// <param name="registros">Conteúdo da lista</param>
    /// <returns>Retorna o índice da lista selecionada</returns>
    public static int ImprimeLista(
      string titulo,
      CabecalhoLista[] cabecalho,
      List<LinhaLista> registros)
    {
      return Tela.ImprimeLista(titulo, cabecalho, registros, true);
    }

    /// <summary>Imprime uma lista na tela</summary>
    /// <param name="titulo">Título da lista</param>
    /// <param name="cabecalho">Nome do cabeçalho das colunas</param>
    /// <param name="registros">Conteúdo da lista</param>
    /// <param name="controlaPaginacao">Indica se deve controlar a paginação na lista</param>
    /// <returns>Retorna o índice da lista selecionada</returns>
    public static int ImprimeLista(
      string titulo,
      CabecalhoLista[] cabecalho,
      List<LinhaLista> registros,
      bool controlaPaginacao)
    {
      try
      {
        int tamMaiorColuna = 0;
        for (int index = 0; index < cabecalho.Length; ++index)
        {
          if (cabecalho[index].Visivel && tamMaiorColuna < cabecalho[index].Conteudo.Length)
            tamMaiorColuna = cabecalho[index].Conteudo.Length;
        }
        bool flag1 = false;
        int num = -1;
        int i = 0;
        while (!flag1 && registros.Count > 0)
        {
          if (i < registros.Count)
          {
            Tela.ImprimeRegistro(titulo, i, cabecalho, registros, tamMaiorColuna);
            if (controlaPaginacao)
            {
              Console.Write("\nHome/End/Up/Down/Esc/Enter...");
              int cursorLeft = Console.CursorLeft;
              int cursorTop = Console.CursorTop;
              bool flag2 = true;
              do
              {
                Console.SetCursorPosition(cursorLeft, cursorTop);
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Home)
                {
                  i = 0;
                  flag2 = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.End)
                {
                  i = registros.Count - 1;
                  flag2 = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                {
                  --i;
                  if (i < 0)
                    i = 0;
                  flag2 = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                {
                  ++i;
                  if (i >= registros.Count)
                    i = registros.Count - 1;
                  flag2 = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                  i = -1;
                  flag1 = true;
                  flag2 = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                  num = i;
                  flag1 = true;
                  flag2 = false;
                }
              }
              while (flag2);
            }
            else
              flag1 = true;
          }
          if (flag1)
            break;
        }
        Console.WriteLine();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private static void ImprimeRegistro(
      string titulo,
      int i,
      CabecalhoLista[] cabecalho,
      List<LinhaLista> registros,
      int tamMaiorColuna)
    {
      Console.Clear();
      Console.WriteLine(titulo);
      for (int index = 0; index < cabecalho.Length; ++index)
      {
        if (cabecalho[index].Visivel)
          Console.WriteLine("{0}: {1}", (object) cabecalho[index].Conteudo.PadLeft(tamMaiorColuna), (object) registros[i].Celulas[index]);
      }
    }

    /// <summary>Imprime uma lista na tela</summary>
    /// <param name="titulo">Título da lista</param>
    /// <param name="cabecalho">Nome do cabeçalho das colunas</param>
    /// <param name="registros">Conteúdo da lista</param>
    /// <param name="registrosPorPagina">Número de registros por página para paginação</param>
    /// <returns>Retorna o índice da lista selecionada</returns>
    public static int ImprimeLista(
      string titulo,
      CabecalhoLista[] cabecalho,
      List<LinhaLista> registros,
      int registrosPorPagina)
    {
      try
      {
        int index1 = -1;
        int length = 0;
        for (int index2 = 0; index2 < cabecalho.Length; ++index2)
        {
          if (cabecalho[index2].Visivel)
            ++length;
        }
        int[] tamMaiorColuna = new int[length];
        for (int index2 = 0; index2 < cabecalho.Length; ++index2)
        {
          if (cabecalho[index2].Visivel)
          {
            ++index1;
            tamMaiorColuna[index1] = cabecalho[index2].Conteudo.Length;
          }
        }
        foreach (LinhaLista registro in registros)
        {
          int index2 = -1;
          for (int index3 = 0; index3 < registro.Celulas.Count; ++index3)
          {
            if (cabecalho[index3].Visivel)
            {
              ++index2;
              if (registro.Celulas[index3].Length > tamMaiorColuna[index2])
              {
                tamMaiorColuna[index2] = registro.Celulas[index3].Length;
                if (tamMaiorColuna[index2] > cabecalho[index3].Largura)
                  tamMaiorColuna[index2] = cabecalho[index3].Largura;
              }
            }
          }
        }
        return Tela.ImprimeLista(titulo, cabecalho, registros, registrosPorPagina, tamMaiorColuna);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private static int ImprimeLista(
      string titulo,
      CabecalhoLista[] cabecalho,
      List<LinhaLista> registros,
      int registrosPorPagina,
      int[] tamMaiorColuna)
    {
      int linhaTopo;
      if (!string.IsNullOrEmpty(titulo))
        linhaTopo = 3 + titulo.Split('\n').Length;
      else
        linhaTopo = 3;
      int num1 = 1;
      for (int index = 0; index < tamMaiorColuna.Length; ++index)
        num1 += tamMaiorColuna[index] + 3;
      if (num1 > Console.BufferWidth)
        throw new Exception(string.Format("Largura total da linha ultrapassa {0} caracteres.", (object) Console.BufferWidth));
      Tela.ImprimeCabecalho(titulo, tamMaiorColuna, cabecalho);
      short num2 = 0;
      if (registrosPorPagina + linhaTopo + 2 > 25)
        registrosPorPagina = 25 - linhaTopo - 2;
      bool interrompe = false;
      int registroInicial = 1;
      int linhaSelecionada = linhaTopo;
      int num3 = -1;
      int i = 0;
      while (!interrompe)
      {
        if (i < registros.Count)
        {
          int cursorTop = Console.CursorTop;
          Tela.ImprimeLinha(i, cabecalho, registros, false, tamMaiorColuna);
          ++num2;
          Console.SetCursorPosition(0, cursorTop + 1);
          ++i;
        }
        if ((int) num2 >= registrosPorPagina || i == registros.Count && !interrompe || i >= registros.Count)
        {
          Tela.ImprimeRodape(tamMaiorColuna, registroInicial, i, registrosPorPagina, registros.Count);
          if (i == 0)
            interrompe = true;
          else
            num3 = Tela.ControlaListaPaginacao(linhaTopo, ref i, ref interrompe, ref linhaSelecionada, registrosPorPagina, registros, cabecalho, tamMaiorColuna);
          if (!interrompe)
          {
            Tela.ImprimeCabecalho(titulo, tamMaiorColuna, cabecalho);
            registroInicial = i + 1;
            num2 = (short) 0;
          }
          else
            break;
        }
      }
      Console.WriteLine();
      return num3;
    }

    private static void ImprimeLinha(
      int i,
      CabecalhoLista[] cabecalho,
      List<LinhaLista> registros,
      bool selecionado,
      int[] tamMaiorColuna)
    {
      Console.Write(Tela.margem[3]);
      int index1 = -1;
      for (int index2 = 0; index2 < registros[i].Celulas.Count; ++index2)
      {
        if (cabecalho[index2].Visivel)
        {
          ++index1;
          int length = tamMaiorColuna[index1];
          if (length > registros[i].Celulas[index2].Length)
            length = registros[i].Celulas[index2].Length;
          string str = string.Empty;
          if (registros[i].Celulas.Count > index2)
            str = registros[i].Celulas[index2].Substring(0, length);
          if (selecionado)
            Tela.InverteCores();
          switch (cabecalho[index2].Alinhamento)
          {
            case CabecalhoLista.AlinhamentoCelula.Esquerda:
              Console.Write(" {0} ", (object) str.PadRight(tamMaiorColuna[index1]));
              break;
            case CabecalhoLista.AlinhamentoCelula.Direita:
              Console.Write(" {0} ", (object) str.PadLeft(tamMaiorColuna[index1]));
              break;
            case CabecalhoLista.AlinhamentoCelula.Centralizado:
              int result;
              int totalWidth = Math.DivRem(tamMaiorColuna[index1] - str.Length, 2, out result) + str.Length;
              Console.Write(" {0} ", (object) str.PadLeft(totalWidth).PadRight(tamMaiorColuna[index1]));
              break;
          }
          if (selecionado)
            Tela.InverteCores();
          Console.Write(Tela.margem[3]);
        }
      }
      Console.WriteLine();
    }

    private static void InverteCores()
    {
      ConsoleColor backgroundColor = Console.BackgroundColor;
      Console.BackgroundColor = Console.ForegroundColor;
      Console.ForegroundColor = backgroundColor;
    }

    private static int ControlaListaPaginacao(
      int linhaTopo,
      ref int i,
      ref bool interrompe,
      ref int linhaSelecionada,
      int registrosPorPagina,
      List<LinhaLista> registros,
      CabecalhoLista[] cabecalho,
      int[] tamMaiorColuna)
    {
      int num1 = -1;
      bool flag = true;
      int num2 = 0;
      foreach (int num3 in tamMaiorColuna)
        num2 += num3;
      int num4 = num2 + (tamMaiorColuna.Length * 3 - 1);
      int cursorTop = Console.CursorTop;
      int left = num4;
      int top = linhaSelecionada;
      int count = registros.Count;
      int i1 = i - registrosPorPagina + (linhaSelecionada - linhaTopo);
      if (count <= registrosPorPagina)
        i1 = 0;
      else if (i1 < 0)
        i1 += registrosPorPagina;
      ConsoleKey consoleKey;
      do
      {
        Console.SetCursorPosition(0, top);
        Tela.ImprimeLinha(i1, cabecalho, registros, true, tamMaiorColuna);
        Console.SetCursorPosition(left, top);
        Console.CursorVisible = false;
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
        Console.CursorVisible = true;
        Console.SetCursorPosition(0, top);
        Tela.ImprimeLinha(i1, cabecalho, registros, false, tamMaiorColuna);
        consoleKey = consoleKeyInfo.Key;
        switch (consoleKey)
        {
          case ConsoleKey.UpArrow:
            --top;
            --i1;
            if (i1 < 0)
            {
              i1 = 0;
              top = linhaTopo;
              break;
            }
            if (top < linhaTopo)
            {
              top = registrosPorPagina + (linhaTopo - 1);
              consoleKey = ConsoleKey.PageUp;
            }
            linhaSelecionada = top;
            break;
          case ConsoleKey.DownArrow:
            ++i1;
            if (i1 >= registros.Count)
              i1 = registros.Count - 1;
            else if (top < registrosPorPagina + (linhaTopo - 1))
            {
              ++top;
            }
            else
            {
              top = linhaTopo;
              consoleKey = ConsoleKey.PageDown;
            }
            linhaSelecionada = top;
            break;
        }
        if (consoleKey == ConsoleKey.Home && i1 > 0 && i1 < registrosPorPagina)
        {
          top = linhaTopo;
          linhaSelecionada = top;
          i1 = 0;
        }
        else if ((consoleKeyInfo.Key != ConsoleKey.PageUp || i1 >= registrosPorPagina) && (consoleKeyInfo.Key != ConsoleKey.End || i1 < count - registrosPorPagina))
        {
          if (consoleKey == ConsoleKey.PageUp || consoleKey == ConsoleKey.LeftArrow || (consoleKey == ConsoleKey.Home || consoleKey == ConsoleKey.End) || consoleKey == ConsoleKey.Escape)
            flag = false;
          else if (consoleKey == ConsoleKey.PageDown || consoleKey == ConsoleKey.RightArrow)
          {
            if (i < count)
              flag = false;
          }
          else if (consoleKey == ConsoleKey.Enter)
          {
            num1 = i1;
            flag = false;
          }
        }
      }
      while (flag);
      if (consoleKey == ConsoleKey.PageUp || consoleKey == ConsoleKey.UpArrow || consoleKey == ConsoleKey.LeftArrow)
      {
        i -= registrosPorPagina * 2;
        if (i < 0)
        {
          i = 0;
          linhaSelecionada = linhaTopo;
        }
      }
      else
      {
        int num3;
        switch (consoleKey)
        {
          case ConsoleKey.Escape:
            num3 = 0;
            break;
          case ConsoleKey.End:
            int result;
            int num5 = Math.DivRem(count, registrosPorPagina, out result);
            if (result > 0)
              ++num5;
            i = Convert.ToInt32((num5 - 1) * registrosPorPagina);
            if (i < 0)
            {
              i = 0;
              goto label_44;
            }
            else
              goto label_44;
          case ConsoleKey.Home:
            i = 0;
            linhaSelecionada = linhaTopo;
            goto label_44;
          default:
            num3 = consoleKey != ConsoleKey.Enter ? 1 : 0;
            break;
        }
        if (num3 == 0)
        {
          interrompe = true;
          Console.SetCursorPosition(left, cursorTop);
        }
      }
label_44:
      if (i > count)
        i = count - 1;
      return num1;
    }

    private static void ImprimeCabecalho(
      string titulo,
      int[] tamMaiorColuna,
      CabecalhoLista[] cabecalho)
    {
      Console.Clear();
      if (!string.IsNullOrEmpty(titulo))
        Console.WriteLine(titulo);
      bool flag1 = true;
      foreach (int num in tamMaiorColuna)
      {
        if (flag1)
        {
          Console.Write(Tela.margem[0]);
          flag1 = false;
        }
        else
          Console.Write(Tela.margem[6]);
        Console.Write(string.Empty.PadRight(num + 2, Tela.margem[1]));
      }
      Console.WriteLine(Tela.margem[2]);
      Console.Write(Tela.margem[3]);
      int index1 = -1;
      for (int index2 = 0; index2 < cabecalho.Length; ++index2)
      {
        if (cabecalho[index2].Visivel)
        {
          ++index1;
          Console.Write(" {0} {1}", (object) cabecalho[index2].Conteudo.PadRight(tamMaiorColuna[index1]), (object) Tela.margem[3]);
        }
      }
      Console.WriteLine();
      bool flag2 = true;
      foreach (int num in tamMaiorColuna)
      {
        if (flag2)
        {
          Console.Write(Tela.margem[8]);
          flag2 = false;
        }
        else
          Console.Write(Tela.margem[10]);
        Console.Write(string.Empty.PadRight(num + 2, Tela.margem[1]));
      }
      Console.WriteLine(Tela.margem[9]);
    }

    private static void ImprimeRodape(
      int[] tamMaiorColuna,
      int registroInicial,
      int registroAtual,
      int registrosPorPagina,
      int totalRegistros)
    {
      bool flag = true;
      foreach (int num in tamMaiorColuna)
      {
        if (flag)
        {
          Console.Write(Tela.margem[4]);
          flag = false;
        }
        else
          Console.Write(Tela.margem[7]);
        Console.Write(string.Empty.PadRight(num + 2, Tela.margem[1]));
      }
      Console.WriteLine(Tela.margem[5]);
      if (totalRegistros <= 0)
        return;
      int result;
      int num1 = Math.DivRem(totalRegistros, registrosPorPagina, out result);
      if (result > 0)
        ++num1;
      double num2 = Math.Round((double) registroAtual / (double) registrosPorPagina, 0);
      if (num2 == 0.0)
        num2 = 1.0;
      Console.Write("Registros {0} até {1} de {2}, página {3} de {4}.", (object) registroInicial, (object) registroAtual, (object) totalRegistros, (object) num2, (object) num1);
    }

    /// <summary>Estrutura de retorno com controle de conversão</summary>
    /// <typeparam name="T"></typeparam>
    public struct RetornoLeitura<T>
    {
      /// <summary>Indica se o método executou sem erros</summary>
      public readonly bool Ok;
      /// <summary>Dados retornados pelo método chamado</summary>
      public readonly T Dados;

      /// <summary>Contrutor</summary>
      /// <param name="Ok"></param>
      /// <param name="Dados"></param>
      public RetornoLeitura(bool Ok, T Dados)
      {
        this.Ok = Ok;
        this.Dados = Dados;
      }
    }
  }
}
