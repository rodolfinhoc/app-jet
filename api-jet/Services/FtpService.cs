using api.Extensions;
using api.Models;
using api.ViewModels.Result;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace api.Services
{
    public class FtpService
    {
        private string _host { get; set; } = "ftp://actidesenvolvimento.com/";
        private string _username { get; set; } = "u787840538.app_plataforma";
        private string _password { get; set; } = "Teste123*";

        public bool CheckDirectory(string path)
        {
            string[] splitPath = path.Split("/");
            string pathReturn = "";
            try
            {
                foreach(var split in splitPath)
                {
                    if (pathReturn.Length == 0)
                    {
                        pathReturn = split;
                    }
                    else
                    {
                        pathReturn = pathReturn + "/" + split;
                    }

                    try
                    {
                        WebRequest request = WebRequest.Create(_host + pathReturn);
                        request.Credentials = new NetworkCredential(_username, _password);
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        var response = request.GetResponse();

                        response.Close();
                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (response.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
                            return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            };
        }

        public string CreateRequest(string path, IFormFile file, string Method)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(_host + path + "/" + file.FileName);
                request.Credentials = new NetworkCredential(_username, _password);
                request.Method = Method;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                //Load to fileStream 
                long length = file.Length;
                if (length < 0)
                    return $"Arquivo vazio {file.FileName}";

                using var fileStream = file.OpenReadStream();
                byte[] bytes = new byte[length];
                fileStream.Read(bytes, 0, (int)file.Length);
                fileStream.Close();


                ////Upload file
                using (Stream reqStream = request.GetRequestStream())
                {
                    file.CopyTo(reqStream);
                    reqStream.Close();
                }

                return "";
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }
}
