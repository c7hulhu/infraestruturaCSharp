// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.Interface.Util
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Bergs.Pxc.Pxcoiexn.Interface
{
  /// <summary>Classe com método úteis para facilitar o aprendizado</summary>
  public static class Util
  {
    /// <summary>Fornece a descrição de um item de um enum</summary>
    /// <param name="e">Valor do enum</param>
    /// <returns></returns>
    public static string DescricaoEnum(Enum e)
    {
      return ((DescriptionAttribute) e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof (DescriptionAttribute), false)[0]).Description;
    }

    /// <summary>Valida se um CPF é válido</summary>
    /// <param name="cpf">CPF com 11 dígitos e zeros à esquerda</param>
    /// <returns>True se o CPF for válido</returns>
    public static bool ValidaCpf(string cpf)
    {
      int[] numArray1 = new int[9]
      {
        10,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
      };
      int[] numArray2 = new int[10]
      {
        11,
        10,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
      };
      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;
      string str1 = cpf.Substring(0, 9);
      int num1 = 0;
      for (int index = 0; index < 9; ++index)
        num1 += int.Parse(str1[index].ToString()) * numArray1[index];
      int num2 = num1 % 11;
      int num3 = num2 >= 2 ? 11 - num2 : 0;
      string str2 = num3.ToString();
      string str3 = str1 + str2;
      int num4 = 0;
      for (int index = 0; index < 10; ++index)
        num4 += int.Parse(str3[index].ToString()) * numArray2[index];
      num3 = num4 % 11;
      num3 = num3 >= 2 ? 11 - num3 : 0;
      string str4 = str2 + num3.ToString();
      return cpf.EndsWith(str4);
    }

    /// <summary>Valida se um CNPJ é válido</summary>
    /// <param name="cnpj">CNPJ com 14 dígitos e zeros à esquerda</param>
    /// <returns>True se o CNPJ for válido</returns>
    public static bool ValidaCnpj(string cnpj)
    {
      int[] numArray1 = new int[12]
      {
        5,
        4,
        3,
        2,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
      };
      int[] numArray2 = new int[13]
      {
        6,
        5,
        4,
        3,
        2,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
      };
      cnpj = cnpj.Trim();
      cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
      if (cnpj.Length != 14)
        return false;
      string str1 = cnpj.Substring(0, 12);
      int num1 = 0;
      for (int index = 0; index < 12; ++index)
        num1 += int.Parse(str1[index].ToString()) * numArray1[index];
      int num2 = num1 % 11;
      int num3 = num2 >= 2 ? 11 - num2 : 0;
      string str2 = num3.ToString();
      string str3 = str1 + str2;
      int num4 = 0;
      for (int index = 0; index < 13; ++index)
        num4 += int.Parse(str3[index].ToString()) * numArray2[index];
      num3 = num4 % 11;
      num3 = num3 >= 2 ? 11 - num3 : 0;
      string str4 = str2 + num3.ToString();
      return cnpj.EndsWith(str4);
    }

    /// <summary>Converte um tipo de classe ou estrutura T em String serializado</summary>
    /// <param name="classe">Objeto a ser convertido</param>
    /// <returns></returns>
    public static string T2String<T>(T classe) where T : new()
    {
      Type type = typeof (T);
      if (type.IsValueType && !type.IsPrimitive && !type.IsEnum && !type.Name.StartsWith("System"))
      {
        int num1 = Marshal.SizeOf((object) classe);
        IntPtr num2 = Marshal.AllocHGlobal(num1);
        Marshal.StructureToPtr((object) classe, num2, true);
        string str = Marshal.PtrToStringAnsi(num2, num1).Replace(char.MinValue, ' ');
        Marshal.FreeHGlobal(num2);
        return str;
      }
      try
      {
        using (StringWriter stringWriter = new StringWriter())
        {
          new XmlSerializer(type).Serialize((TextWriter) stringWriter, (object) classe);
          return stringWriter.ToString();
        }
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    /// <summary>Converte um tipo string XML serializado em um tipo de classe ou struct</summary>
    /// <param name="xml">XML serializado ou string da área da estrutura</param>
    /// <returns></returns>
    public static T String2T<T>(string xml) where T : new()
    {
      Type type = typeof (T);
      if (type.IsValueType && !type.IsPrimitive && !type.IsEnum && !type.Name.StartsWith("System"))
      {
        T obj = new T();
        int totalWidth = Marshal.SizeOf(type);
        IntPtr num = IntPtr.Zero;
        try
        {
          num = Marshal.StringToHGlobalAnsi(xml.PadRight(totalWidth, ' '));
          obj = (T) Marshal.PtrToStructure(num, type);
        }
        finally
        {
          Marshal.FreeHGlobal(num);
        }
        return obj;
      }
      using (StringReader stringReader = new StringReader(xml))
        return (T) new XmlSerializer(type).Deserialize((TextReader) stringReader);
    }

    /// <summary>Converte um vetor de bytes em uma estrutura</summary>
    /// <param name="vetor">Vetor de bytes</param>
    /// <returns>Struct do tipo T</returns>
    public static T Byte2T<T>(byte[] vetor) where T : new()
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (T)));
      Marshal.Copy(vetor, 0, num, vetor.Length);
      T structure = (T) Marshal.PtrToStructure(num, typeof (T));
      Marshal.FreeHGlobal(num);
      return structure;
    }

    /// <summary>Converte um vetor de chars em uma estrutura</summary>
    /// <param name="vetor">Vetor de chars</param>
    /// <returns>Struct do tipo T</returns>
    public static T Char2T<T>(char[] vetor) where T : new()
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (T)));
      Marshal.Copy(vetor, 0, num, vetor.Length);
      T structure = (T) Marshal.PtrToStructure(num, typeof (T));
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
