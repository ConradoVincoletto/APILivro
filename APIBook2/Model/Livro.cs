using System.ComponentModel.DataAnnotations;

namespace APIBook2.Model
{
    public class Livro
    {
        [Key]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "O campo precisa conter pelo menos um número ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório")]
        [StringLength(100, MinimumLength = 1)]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório")]
        [StringLength(100, MinimumLength = 1)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é de preenchimento obrigatório")]
        [StringLength(100, MinimumLength = 1)]
        public string Titulo { get; set; }
    }
}
