using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_SDK.Dtos
{
    public class AtividadeDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public ushort Prioridade { get; set; }
    }
}
