using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UsuarioModel
    {
        public int codigo { get; set; }
        public string? usuario { get; set; }
        public string? senha { get; set; }
        public string? nome { get; set; }
    }
}
