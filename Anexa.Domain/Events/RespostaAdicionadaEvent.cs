using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Events
{
    public class RespostaAdicionadaEvent
    {
        public Guid PerguntaId { get; }
        public Guid AutorPerguntaId { get; }
        public Guid AutorRespostaId { get; }
        public string TextoResposta { get; }

        public RespostaAdicionadaEvent(Guid perguntaId, Guid autorPerguntaId, Guid autorRespostaId, string textoResposta)
        {
            PerguntaId = perguntaId;
            AutorPerguntaId = autorPerguntaId;
            AutorRespostaId = autorRespostaId;
            TextoResposta = textoResposta;
        }
    }
}
