using api.Models;
namespace api.Models.Upload
{
    public class UploadImagemModel
    {
        public long codigo { get; set; }
        public int codigo_pedido { get; set; }
        public string base64imagem { get; set; } //Imagem em Base 64
        public string descricao { get; set; } //Descricao da imagem
        public DateTime data_input { get; set; }

        //Propriedade
        public string Data_output => data_input != null ? FormatDate(data_input.ToString()) : "";

        public string FormatDate(string Data)
        {
            DateTime dAux;
            var retorno = "";
            //var retorno = DateTime.TryParseExact(Data, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dAux) == false ? false : true;


            DateTime dataValida;

            if (DateTime.TryParse(Data, out dataValida))
            {
                var ano = dataValida.Year.ToString();
                var mes = dataValida.Month.ToString().Length == 1 ? $"0{ dataValida.Month}" : dataValida.Month.ToString();
                var dia = dataValida.Day.ToString().Length == 1 ? $"0{ dataValida.Day}" : dataValida.Day.ToString();
                var hora = dataValida.Hour.ToString().Length == 1 ? $"0{ dataValida.Hour}" : dataValida.Hour.ToString();
                var minuto = dataValida.Minute.ToString().Length == 1 ? $"0{ dataValida.Minute}" : dataValida.Minute.ToString();
                var segundo = dataValida.Second.ToString().Length == 1 ? $"0{ dataValida.Second}" : dataValida.Second.ToString();

                retorno = $"{dia}/{mes}/{ano} {hora}:{minuto}:{segundo}";
            }

            return retorno;
        }

    }
}
