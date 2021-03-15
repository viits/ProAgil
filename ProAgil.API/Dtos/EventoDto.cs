using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        [StringLength(100,MinimumLength= 3, ErrorMessage="Local é entre 3 a 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage="O tema deve ser preenchido")]
        public string Tema { get; set; }
        [Range(1,120000,ErrorMessage="Quantidade de pessoas é entre 1 e 120000")]
        public int QtPessoas { get; set; }
        public string ImagemUrl { get; set;}
        [Phone]
        public string Telefone{get;set;}
        [EmailAddress(ErrorMessage="Email Invalido")]
        public string Email { get; set; }
        public string Lote { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }

    }
}