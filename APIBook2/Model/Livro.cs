using System.ComponentModel.DataAnnotations;

namespace APIBook2.Model
{
    public class Livro
    {
        public Livro()
        {
        }

        [Key]

        [Required(ErrorMessage = "O campo Id é de preenchimento obrigatório")]
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
