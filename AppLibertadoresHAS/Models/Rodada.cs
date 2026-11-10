using System;
using System.Collections.Generic;
using System.Text;

namespace AppLibertadoresHAS.Models
{
    public class Rodada
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public ICollection<Partida> Partidas { get; set; } = new List<Partida>();
    }
}
