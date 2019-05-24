using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>
    /// Disponibiliza formatações de objetos para String: cpf, cnpj, data, datahora, agencia, conta
    /// </summary>
    public class Formatador : IFormatProvider, ICustomFormatter
    {
        /// <summary></summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return (object)this;
            return (object)null;
        }

        /// <summary>Formatos: "cpf", "cnpj", "data", "datahora", "conta" e "agencia"</summary>
        /// <param name="format"></param>
        /// <param name="argumento"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object argumento, IFormatProvider formatProvider)
        {
            string str = argumento.ToString();
            if (argumento == null || str != null && string.IsNullOrEmpty(str.Trim()))
                return string.Empty;
            try
            {
                switch (format)
                {
                    case "cpf":
                        return string.Format("{0:000\\.000\\.000\\-00}", argumento);
                    case "cnpj":
                        return string.Format("{0:00\\.000\\.000/0000\\-00}", argumento);
                    case "data":
                        return string.Format("{0:dd/MM/yyyy}", argumento);
                    case "datahora":
                        return string.Format("{0:dd/MM/yyyy HH:mm:ss.fffff}", argumento);
                    case "conta":
                        return string.Format("{0:00\\.000000\\.0\\-0}", argumento);
                    case "agencia":
                        return string.Format("{0:0000}", argumento);
                    default:
                        IFormattable formattable = argumento as IFormattable;
                        if (formattable != null)
                            return formattable.ToString(format, formatProvider);
                        return argumento.ToString();
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
