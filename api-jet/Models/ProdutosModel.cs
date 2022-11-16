using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ProdutosModel
    {
        public int? codigo { get; set; }
        public string? nome { get; set; }
        public string? imagem { get; set; }
        public string? descricao { get; set; }
        public int? estoque { get; set; }
        public bool? status { get; set; }
        public float? preco { get; set; }
        public float? preco_promocao { get; set; }
    }
}
