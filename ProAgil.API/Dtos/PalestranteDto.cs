using System.Collections.Generic;

namespace ProAgil.API.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculo { get; set; }   
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<EventoDto> Evento { get; set; }
    }
}