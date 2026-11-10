using System;
using System.Collections.Generic;
using System.Text;

namespace AppLibertadoresHAS.Models
{
    public class Estadio
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Pais { get; set; } = string.Empty;

        public int Capacidade { get; set; }

        public ICollection<Partida> Partidas { get; set; } = new List<Partida>();
    }
}
