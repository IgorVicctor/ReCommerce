using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
namespace AspNet_UploadImagem.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ImagemController : ControllerBase
    //{
    //    public static IWebHostEnvironment _environment;
    //    public ImagemController(IWebHostEnvironment environment)
    //    {
    //        _environment = environment;
    //    }

    //    [HttpGet]
    //    public string Get()
    //    {
    //        string texto = " Web API - ImagemController em execu��o : " + DateTime.Now.ToLongTimeString();
    //        texto += $"\n Ambiente :  {_environment.EnvironmentName}";
    //        return texto;
    //    }

    //    [HttpPost("upload")]
    //    public async Task<string> EnviaArquivo([FromForm] IFormFile arquivo)
    //    {
    //        if (arquivo.Length > 0)
    //        {
    //            try
    //            {
    //                if (!Directory.Exists(_environment.WebRootPath + "\\imagens\\"))
    //                {
    //                    Directory.CreateDirectory(_environment.WebRootPath + "\\imagens\\");
    //                }
    //                using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\imagens\\" + arquivo.FileName))
    //                {
    //                    await arquivo.CopyToAsync(filestream);
    //                    filestream.Flush();
    //                    return "\\imagens\\" + arquivo.FileName;
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return ex.ToString();
    //            }
    //        }
    //        else
    //        {
    //            return "Ocorreu uma falha no envio do arquivo...";
    //        }
    //    }
    //}
}