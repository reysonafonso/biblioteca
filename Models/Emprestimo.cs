using System;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    
        public bool Devolvido { get; set; }
        
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}