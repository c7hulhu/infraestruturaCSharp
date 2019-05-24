// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.ConstrutorSql
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using Bergs.Pxc.Pxcoiexn.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Automatiza parte da montagem de comandos SQL.</summary>
  [DebuggerDisplay("{Comando.Length > 0 ? QueryFormatada : ToString(),nq}")]
  public class ConstrutorSql
  {
    /// <summary>SQL que será executado na base de dados</summary>
    private readonly StringBuilder comando;
    /// <summary>SQL temporário utilizado para método Incluir</summary>
    private readonly StringBuilder temporario;
    /// <summary>
    /// Objeto de comando com parameter e que devem ter "@" no nome, ex.: SELECT * FROM T WHERE CAMPO1 = @campo1
    /// </summary>
    internal readonly OleDbCommand ComandoSql;

    /// <summary>Parâmetros do comando SQL</summary>
    public OleDbParameterCollection Parametros
    {
      get
      {
        return this.ComandoSql.Parameters;
      }
    }

    /// <summary>SQL que será executado na base de dados</summary>
    public StringBuilder Comando
    {
      get
      {
        return this.comando;
      }
    }

    /// <summary>SQL temporário utilizado para método Incluir</summary>
    public StringBuilder Temporario
    {
      get
      {
        return this.temporario;
      }
    }

    /// <summary>Construtor da classe de comando SQL</summary>
    public ConstrutorSql()
    {
      this.comando = new StringBuilder();
      this.temporario = new StringBuilder();
      this.ComandoSql = new OleDbCommand();
      this.ComandoSql.CommandType = CommandType.Text;
    }

    /// <summary>
    /// 
    /// </summary>
    public string QueryFormatada
    {
      get
      {
        string str = this.comando.ToString();
        foreach (OleDbParameter parametro in (DbParameterCollection) this.Parametros)
          str = str.Replace(parametro.ParameterName, "\"" + parametro.Value.ToString() + "\"");
        return str;
      }
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo, já incluindo a vírgula e o igual
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    public void MontarCampoSet(string nomeCampo, ICampo campo)
    {
      if (campo == null || !campo.FoiSetado)
        return;
      if (this.comando.Length > 0 && !this.comando.ToString().Trim().EndsWith(" SET"))
        this.comando.Append(", ");
      this.comando.Append(nomeCampo);
      this.comando.Append(" = ");
      this.MontaCampoDate(this.comando, nomeCampo, campo);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES"
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    public void MontarCampoInsert(string nomeCampo, ICampo campo)
    {
      if (campo == null || !campo.FoiSetado)
        return;
      if (this.comando.Length > 0 && !this.comando.ToString().Trim().EndsWith("("))
      {
        this.comando.Append(", ");
        this.temporario.Append(", ");
      }
      this.comando.Append(nomeCampo);
      this.MontaCampoDate(this.temporario, nomeCampo, campo);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    public void MontarCampoWhere(string nomeCampo)
    {
      this.MontarCampoWhere(nomeCampo, (ICampo) new CampoTabela<string>((string) null), ConstrutorSql.OperadorUnario.IsNull, ConstrutorSql.OperadorLogico.And, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(string nomeCampo, bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, (ICampo) new CampoTabela<string>((string) null), ConstrutorSql.OperadorUnario.IsNull, ConstrutorSql.OperadorLogico.And, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    public void MontarCampoWhere(string nomeCampo, ConstrutorSql.OperadorUnario operadorUnario)
    {
      this.MontarCampoWhere(nomeCampo, (ICampo) new CampoTabela<string>((string) null), operadorUnario, ConstrutorSql.OperadorLogico.And, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ConstrutorSql.OperadorUnario operadorUnario,
      bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, (ICampo) new CampoTabela<string>((string) null), operadorUnario, ConstrutorSql.OperadorLogico.And, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE e os ANDs à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    public void MontarCampoWhere(string nomeCampo, ICampo campo)
    {
      this.MontarCampoWhere(nomeCampo, campo, ConstrutorSql.OperadorUnario.Igual, ConstrutorSql.OperadorLogico.And, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE e os ANDs à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(string nomeCampo, ICampo campo, bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, campo, ConstrutorSql.OperadorUnario.Igual, ConstrutorSql.OperadorLogico.And, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ConstrutorSql.OperadorUnario operadorUnario)
    {
      this.MontarCampoWhere(nomeCampo, campo, operadorUnario, ConstrutorSql.OperadorLogico.And, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ConstrutorSql.OperadorUnario operadorUnario,
      bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, campo, operadorUnario, ConstrutorSql.OperadorLogico.And, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="operadorLogico">AND OR XOR</param>
    protected void MontarCampoWhere(
      string nomeCampo,
      ConstrutorSql.OperadorUnario operadorUnario,
      ConstrutorSql.OperadorLogico operadorLogico)
    {
      this.MontarCampoWhere(nomeCampo, (ICampo) new CampoTabela<string>((string) null), operadorUnario, operadorLogico, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="operadorLogico">AND OR XOR</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ConstrutorSql.OperadorUnario operadorUnario,
      ConstrutorSql.OperadorLogico operadorLogico,
      bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, (ICampo) new CampoTabela<string>((string) null), operadorUnario, operadorLogico, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="operadorLogico">AND OR XOR</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ConstrutorSql.OperadorUnario operadorUnario,
      ConstrutorSql.OperadorLogico operadorLogico)
    {
      this.MontarCampoWhere(nomeCampo, campo, operadorUnario, operadorLogico, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="operadorLogico">AND OR XOR</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ConstrutorSql.OperadorUnario operadorUnario,
      ConstrutorSql.OperadorLogico operadorLogico,
      bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, campo, (ICampo) null, operadorUnario, operadorLogico, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="campo2">CampoTabela da base de dados usado para o operador lógico BETWEEN</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ICampo campo2,
      ConstrutorSql.OperadorUnario operadorUnario)
    {
      this.MontarCampoWhere(nomeCampo, campo, campo2, operadorUnario, ConstrutorSql.OperadorLogico.And, true);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="campo2">CampoTabela da base de dados usado para o operador lógico BETWEEN</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ICampo campo2,
      ConstrutorSql.OperadorUnario operadorUnario,
      bool controleWhere)
    {
      this.MontarCampoWhere(nomeCampo, campo, campo2, operadorUnario, ConstrutorSql.OperadorLogico.And, controleWhere);
    }

    /// <summary>
    /// Acrescenta ao SQL um campo e seu conteúdo para a cláusula WHERE. Já inclui o WHERE à cláusula
    /// </summary>
    /// <param name="nomeCampo">Nome do campo na base de dados</param>
    /// <param name="campo">CampoTabela da base dados</param>
    /// <param name="campo2">CampoTabela da base de dados usado para o operador lógico BETWEEN</param>
    /// <param name="operadorUnario">igual, maior, menor, etc...</param>
    /// <param name="operadorLogico">AND OR XOR</param>
    /// <param name="controleWhere">Indica se deve haver controle do WHERE</param>
    public void MontarCampoWhere(
      string nomeCampo,
      ICampo campo,
      ICampo campo2,
      ConstrutorSql.OperadorUnario operadorUnario,
      ConstrutorSql.OperadorLogico operadorLogico,
      bool controleWhere)
    {
      if (campo == null || !campo.FoiSetado)
        return;
      if (controleWhere)
      {
        if (this.comando.ToString().IndexOf(" WHERE ") < 0)
          this.comando.Append(" WHERE ");
        else if (!this.comando.ToString().Trim().EndsWith(" AND") && !this.comando.ToString().Trim().EndsWith(" OR") && !this.comando.ToString().Trim().EndsWith(" XOR"))
        {
          this.comando.Append(" ");
          this.comando.Append(Util.DescricaoEnum((Enum) operadorLogico));
          this.comando.Append(" ");
        }
      }
      this.comando.Append(nomeCampo);
      this.comando.Append(" ");
      this.comando.Append(Util.DescricaoEnum((Enum) operadorUnario));
      int num;
      switch (operadorUnario)
      {
        case ConstrutorSql.OperadorUnario.IsNull:
          num = 1;
          break;
        case ConstrutorSql.OperadorUnario.Between:
          this.comando.Append(" ");
          this.MontaCampoDate(this.comando, nomeCampo, campo);
          this.comando.Append(" ");
          this.comando.Append(Util.DescricaoEnum((Enum) operadorLogico));
          this.comando.Append(" ");
          this.MontaCampoDate(this.comando, nomeCampo + (object) this.ComandoSql.Parameters.Count, campo2);
          goto label_13;
        default:
          num = operadorUnario == ConstrutorSql.OperadorUnario.IsNotNull ? 1 : 0;
          break;
      }
      if (num == 0)
      {
        this.comando.Append(" ");
        this.MontaCampoDate(this.comando, nomeCampo, campo);
      }
label_13:;
    }

    /// <summary>Monta o campo e o parameter</summary>
    /// <param name="sb"></param>
    /// <param name="nomeCampo"></param>
    /// <param name="campo"></param>
    private void MontaCampoDate(StringBuilder sb, string nomeCampo, ICampo campo)
    {
      string str = nomeCampo + (object) (this.ComandoSql.Parameters.Count + 1);
      if (campo.TemConteudo)
      {
        object conteudo = campo.Conteudo;
        if (conteudo.GetType() == typeof (DateTime))
        {
          DateTime dateTime = (DateTime) conteudo;
          sb.Append("FORMAT(@");
          sb.Append(str);
          if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0 && dateTime.Millisecond == 0)
          {
            sb.Append(", 'DD/MM/YYYY')");
            this.ComandoSql.Parameters.AddWithValue("@" + str, (object) string.Format("{0:dd/MM/yyyy}", conteudo));
          }
          else
          {
            sb.Append(", 'DD/MM/YYYY hh:nn:ss')");
            this.ComandoSql.Parameters.AddWithValue("@" + str, (object) string.Format("{0:dd/MM/yyyy hh:mm:ss}", conteudo));
          }
        }
        else
        {
          sb.Append("@");
          sb.Append(str);
          this.ComandoSql.Parameters.AddWithValue("@" + str, conteudo);
        }
      }
      else
      {
        sb.Append("@");
        sb.Append(str);
        this.ComandoSql.Parameters.AddWithValue("@" + str, (object) DBNull.Value).IsNullable = true;
      }
    }

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

    /// <summary>Operadores lógicos para o comando SQL</summary>
    public enum OperadorLogico
    {
      /// <summary>AND - E lógico para montagem do SQL</summary>
      [Description("AND")] And,
      /// <summary>OR - OU lógico para montagem do SQL</summary>
      [Description("OR")] Or,
      /// <summary>XOR - 'XOU' lógico para montagem do SQL</summary>
      [Description("XOR")] Xor,
    }
  }
}
