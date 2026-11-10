using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppLibertadoresHAS.Models
{
    public class Usuario
    {
        public int Id { get; set; } //Atalho para propridade (PROP + TAB)
        public string Username { get; set; } = string.Empty;        
        public byte[]? Foto { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? DataAcesso { get; set; }         
        public string PasswordString { get; set; } = string.Empty;
        public string? Perfil { get; set; }
        public string? Email { get; set; } = string.Empty;                
        public string Token { get; set; } = string.Empty;

        public ICollection<Jogador> Jogadores { get; set; }
            = new List<Jogador>();
    }
}
