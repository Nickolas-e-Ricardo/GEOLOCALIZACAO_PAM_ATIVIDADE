using System;
using System.Collections.Generic;
using System.Text;

namespace AppLibertadoresHAS.Models
{
    public class Jogador
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public int Numero { get; set; }

        public DateTime DataNascimento { get; set; }

        public int TimeId { get; set; }

        public int PosicaoId { get; set; }

        public Time? Time { get; set; }

        public Posicao? Posicao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
