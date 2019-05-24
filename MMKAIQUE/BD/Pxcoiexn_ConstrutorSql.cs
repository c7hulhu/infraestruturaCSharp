using Bergs.Pxc.Pxcoiexn.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;

namespace Pxcoiexn.BD
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
                foreach (OleDbParameter parametro in (DbParameterCollection)this.Parametros)
                    str = str.Replace(parametro.ParameterName, "\"" + parametro.Value.ToString() + "\"");
                return str;
            }
        }

        /// <summary>Operadores unários para o comando SQL</summary>
        public enum OperadoresUnitarios
        {
            /// <summary>Maior</summary>
            [Description(">")]
            Maior,
            /// <summary>Maior ou igual</summary>
            [Description(">=")]
            MaiorIgual,
            /// <summary>Menor</summary>
            [Description("<")]
            Menor,
            /// <summary>Menor ou igual</summary>
            [Description("<=")]
            MenorIgual,
            /// <summary>Diferente</summary>
            [Description("<>")]
            Diferente,
            /// <summary>Igual</summary>
            [Description("=")]
            Igual,
            /// <summary>Like</summary>
            [Description("LIKE")]
            Like,
            /// <summary>Is Null</summary>
            [Description("IS NULL")]
            IsNull,
            /// <summary>Is Not Null</summary>
            [Description("IS NOT NULL")]
            IsNotNull,
        }

        /// <summary>Operadores unários para o comando SQL</summary>
        public enum OperadoresMultivalor
        {
            /// <summary>Between</summary>
            [Description("BETWEEN")]
            Between,
            /// <summary>In</summary>
            [Description("IN")]
            In,
            /// <summary>Not In</summary>
            [Description("NOT IN")]
            NotIn,
        }

        /// <summary>Operadores lógicos para o comando SQL</summary>
        public enum Conectores
        {
            /// <summary>AND - E lógico para montagem do SQL</summary>
            [Description("AND")]
            And,
            /// <summary>OR - OU lógico para montagem do SQL</summary>
            [Description("OR")]
            Or,
            /// <summary>XOR - 'XOU' lógico para montagem do SQL</summary>
            [Description("XOR")]
            Xor,
        }

        /// <summary> Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES" </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>       
        public void MontarCampoInsert(string nomeCampo)
        {

        }

        /// <summary> Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES" </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        public void MontarCampoInsert(string nomeCampo, ICampo campo)
        {

        }

        /// <summary> Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES" </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        public void MontarCampoJoin(string nomeCampo, ICampo campo, OperadoresUnitarios operador = OperadoresUnitarios.Igual, Conectores conector = Conectores.And)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, OperadoresMultivalor operador)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, OperadoresMultivalor operador, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, OperadoresMultivalor operador, Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, OperadoresMultivalor operador, Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo na cláusula SET de um UPDATE.</summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        public void MontarCampoSet(string nomeCampo)
        {

        }

        /// <summary> Monta um campo na cláusula SET de um UPDATE.</summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        public void MontarCampoSet(string nomeCampo, ICampo campo)
        {

        }

        /// <summary> Monta um campo na cláusula SET de um UPDATE.</summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        /// <param name="complemento">Conteúdo customizado para atribuição ao campo.</param>
        public void MontarCampoSet(string nomeCampo, ICampo campo, string complemento)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        public void MontarCampoWhere(string nomeCampo)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        public void MontarCampoWhere(string nomeCampo, OperadoresUnitarios operador)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, OperadoresUnitarios operador, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, OperadoresUnitarios operador, Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, OperadoresUnitarios operador, Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo, Conectores conector)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo, Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo, OperadoresUnitarios operador, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo, OperadoresUnitarios operador, Conectores conector)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, ICampo campo, OperadoresUnitarios operador, Conectores conector, bool controleWhere)
        {

        }

        /// <summary>Monta um campo para StoredProcedure</summary>
        /// <param name="nomeParametro">Nome do parâmetro que será montado.</param>
        /// <param name="conteudo">Conteúdo do parâmetro.</param>
        public void MontarParametroStoredProcedure(string nomeParametro, object conteudo)
        {

        }
    }
}
