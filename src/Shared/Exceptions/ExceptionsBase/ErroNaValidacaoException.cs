using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsBase
{
    public class ErroNaValidacaoException : MeuLivroDeReceitasException
    {
        public IList<string> MensagensDeErro { get; set; }
        public ErroNaValidacaoException(IList<string> mensagensDeErro)
        {
            MensagensDeErro = mensagensDeErro;
        }
    }
}