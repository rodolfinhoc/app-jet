using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class MenuModel
    {
        public int id { get; set; }
        public int codigo_empresa { get; set; }
        public string? title { get; set; }
        public string? router { get; set; }
        public int? ativo { get; set; }
        public string? children { get; set; }
        public int? admin { get; set; }
    }
}
