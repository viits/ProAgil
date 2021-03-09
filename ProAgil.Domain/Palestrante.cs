using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculo { get; set; }   
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestrantesEvento { get; set; }
    }
}