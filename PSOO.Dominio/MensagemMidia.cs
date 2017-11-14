using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Dominio
{
    public class MensagemMidia : Mensagem
    {
        public byte[] conteudo { get; set; }
        public void mensagemMidia(byte[] conteudo) { }
    }
}
