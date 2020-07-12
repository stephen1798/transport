using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IronPdf;
using Microsoft.Extensions.Configuration;

namespace Zajecia_07._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorRaportuController : ControllerBase
    {
        //   IConfiguration _config;
        CompanyData _cd;
        private readonly PdfSaleRepository _raport;

        public GeneratorRaportuController(IConfiguration cfg, PdfSaleRepository raport)
        {
            //_config = cfg;
            _cd = new CompanyData();
            _raport = raport;
            cfg.GetSection("Company").Bind(_cd);
        }


        // GET api/region/3
        [HttpGet()]
        public FileResult Get()
        {

            //tutaj nastepuje wywolanie repozytorium, a anstepnie utworzenie htmla

            var Renderer = new IronPdf.HtmlToPdf();
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Screen;
            var PDF = Renderer.RenderHtmlAsPdf("<h2>" + _cd.Name + "</h2>" + _raport.GenerujRaport());
            //return a  pdf document from a view
            var contentLength = PDF.BinaryData.Length;
            Response.Headers.Add("Content-Length", contentLength.ToString());
            Response.Headers.Add("Content-Disposition", "inline; filename=Document_.pdf");
            return File(PDF.BinaryData, "application/pdf;");

        }

        // GET api/values/5

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}