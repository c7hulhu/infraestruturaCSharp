using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraKAIQUEv1.BD
{
    /// <summary>Executa um comando no banco</summary>
    public class AplicacaoDados
    {
        public AplicacaoDados()
        {

        }

    }

    public sealed class Campo
    {
        /// <summary>Construtora da classe</summary>
        /// <param name="nome">Nome do campo na base de dados</param>
        /// <param name="conteudo">Conteúdo do campo</param>
        public Campo(string nome, object conteudo)
        {

        }

    }

    /// <summary>Campo de um TO.</summary>
    public interface ICampo
    {
        object conteudo;
        bool foiSetado;

        bool FoiSetado { get { return this.foiSetado; } }
        object Conteudo { get { return this.conteudo; } }
    }
    
    /// <summary>Campo de um TO.</summary>
    /// <typeparam name="T">Tipo armazenado pelo campo.</typeparam>
    public interface ICampo<T>
    {
        T LerConteudoOuPadrao()
        {
            return 
        }
    }

    public sealed class Linha
    {
        /// <summary>Construtora da classe que inicializa a coleção de campos da tabela</summary>
        public Linha()
        {

        }
        public readonly System.Collections.Generic.List<Campo> Campos;
    }

    /// <summary>Enumeracao para os operadores utilizar para setar apenas um conteudos (=, like, is null).</summary>
    public enum OperadoresUnitarios
    {
        /// <summary>Operador <>.</summary>        
        Diferente = "<>",
        /// <summary>Operador =.</summary>  
        Igual = "=",
        /// <summary>Operador IS NOT NULL.</summary>  
        IsNotNull = "IS NOT NULL",
        /// <summary>Operador IS NULL.</summary>  
        IsNull = "IS NULL.",
        /// <summary>Operador LIKE.</summary>  
        Like = "LIKE",
        /// <summary>Operador >.</summary>  
        Maior = ">",
        /// <summary>Operador >.</summary>  
        MaiorIgual = ">=",
        /// <summary>Operador <.</summary>  
        Menor = "<",
        /// <summary>Operador <=.</summary>  
        MenorIgual = "<=",
    }
    /// <summary>Enumeracao para operador que suportam mais de um conteúdo (in, between, not in).</summary>
    public enum OperadoresMultivalor
    {
        /// <summary>Operador BETWEEN %1 AND %2.</summary>        
        Between = "BETWEEN",
        /// <summary>Operador IN (%1, %2, %n).</summary>  
        In = "IN",
        /// <summary>Operador NOT IN (%1, %2, %n).</summary>  
        NotIn = "NOT IN",
    }

    /// <summary>Operadores lógicos para o comando SQL</summary>
    public enum Conectores
    {
        /// <summary>AND - E lógico para montagem do SQL</summary>        
        And = "AND",
        /// <summary>OR - OU lógico para montagem do SQL</summary>  
        Or = "OR",
        /// <summary>XOR - 'EOU' lógico para montagem do SQL</summary>  
        Xor = "XOR",
    }

    /// <summary> Automatiza parte da montagem de comandos SQL. </summary>
    public sealed class ConstrutorSql
    {
        /// <summary>Enumeracao para os operadores utilizar para setar apenas um conteudos (=, like, is null).</summary>
        public enum OperadoresUnitarios
        {
            /// <summary>Operador <>.</summary>        
            Diferente = "<>",
            /// <summary>Operador =.</summary>  
            Igual = "=",
            /// <summary>Operador IS NOT NULL.</summary>  
            IsNotNull = "IS NOT NULL",
            /// <summary>Operador IS NULL.</summary>  
            IsNull = "IS NULL.",
            /// <summary>Operador LIKE.</summary>  
            Like = "LIKE",
            /// <summary>Operador >.</summary>  
            Maior = ">",
            /// <summary>Operador >.</summary>  
            MaiorIgual = ">=",
            /// <summary>Operador <.</summary>  
            Menor = "<",
            /// <summary>Operador <=.</summary>  
            MenorIgual = "<=",
        }
        /// <summary>Enumeracao para operador que suportam mais de um conteúdo (in, between, not in).</summary>
        public enum OperadoresMultivalor
        {
            /// <summary>Operador BETWEEN %1 AND %2.</summary>        
            Between = "BETWEEN",
            /// <summary>Operador IN (%1, %2, %n).</summary>  
            In = "IN",
            /// <summary>Operador NOT IN (%1, %2, %n).</summary>  
            NotIn = "NOT IN",
        }

        /// <summary>Operadores lógicos para o comando SQL</summary>
        public enum Conectores
        {
            /// <summary>AND - E lógico para montagem do SQL</summary>        
            And = "AND",
            /// <summary>OR - OU lógico para montagem do SQL</summary>  
            Or = "OR",
            /// <summary>XOR - 'EOU' lógico para montagem do SQL</summary>  
            Xor = "XOR",
        }

        /// <summary> Construtor da classe de comando SQL </summary>
        public ConstrutorSql()
        {

        }

        /// <summary> Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES" </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>       
        public void MontarCampoInsert(string nomeCampo)
        {

        }

        /// <summary> Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES" </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        public void MontarCampoInsert(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo)
        {

        }

        /// <summary> Acrescenta ao SQL um campo e seu conteúdo para o comando Insert. A variável Temporario receberá o conteúdo para o "VALUES" </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        public void MontarCampoJoin(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador = InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios.Igual, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector = InfraKAIQUEv1.BD.ConstrutorSql.Conectores.And)
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
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresMultivalor operador)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresMultivalor operador, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresMultivalor operador, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoMultivalor(string nomeCampo, System.Collections.ICollection conteudos, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresMultivalor operador, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector, bool controleWhere)
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
        public void MontarCampoSet(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo)
        {

        }

        /// <summary> Monta um campo na cláusula SET de um UPDATE.</summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">CampoTabela da base dados</param>
        /// <param name="complemento">Conteúdo customizado para atribuição ao campo.</param>
        public void MontarCampoSet(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, string complemento)
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
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador, bool controleWhere)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="conteudos">A lista de conteúdos que será utilizada na montagem do campo.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector)
        {

        }

        /// <summary> Monta um campo com múltiplos valores na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador, bool controleWhere)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector)
        {

        }

        /// <summary> Monta um campo de valor único na cláusula WHERE de um SELECT. </summary>
        /// <param name="nomeCampo">Nome do campo na base de dados</param>
        /// <param name="campo">Campo do TO que será utilizado na cláusula.</param>
        /// <param name="operador">O operador para montagem da cláusula.</param>
        /// <param name="conector">O conector que será utilizado para ligar a cláusula ao resto do comando.</param>
        /// <param name="controleWhere">Indica se infra deve controlar a montagem do WHERE e os conectores.</param>
        public void MontarCampoWhere(string nomeCampo, InfraKAIQUEv1.BD.ICampo campo, InfraKAIQUEv1.BD.ConstrutorSql.OperadoresUnitarios operador, InfraKAIQUEv1.BD.ConstrutorSql.Conectores conector, bool controleWhere)
        {

        }

        /// <summary>Monta um campo para StoredProcedure</summary>
        /// <param name="nomeParametro">Nome do parâmetro que será montado.</param>
        /// <param name="conteudo">Conteúdo do parâmetro.</param>
        public void MontarParametroStoredProcedure(string nomeParametro, object conteudo)
        {

        }

        /// <summary>String SQL.</summary>
        public System.Text.StringBuilder Comando { get; }

        /// <summary>Buffer auxiliar para montagem da string SQL.</summary>
        public System.Text.StringBuilder Temporario { get; }
    }



}
