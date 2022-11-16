namespace api.ViewModels.Users
{
    public class ListUsuarioViewModel
    {
        public long codigo { get; set; }
        public int? codigo_empresa { get; set; }
        public string? usuario { get; set; }
        public string? senha { get; set; }
        public string? nome { get; set; }
        public int? admin { get; set; }
        public int? empresa { get; set; }
        public int? ativo { get; set; }
        public int? codigo_vendedor { get; set; }

    }
}
