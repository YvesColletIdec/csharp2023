using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    public class PrintController : Controller
    {
        private readonly SqlServerContext _context;
        public IActionResult Print(int factureId)
        {
            Facture f = _context.Factures.Include(y => y.LigneFactures).
                ThenInclude(a => a.Article).
                Include(c => c.Client).
                FirstOrDefault(x => x.Id == factureId);
            string templateChemin = "C:\\Users\\Yves\\github\\csharp2023\\WebApplicationSolution\\WebApplicationDemo2023\\template\\facture_template.docx";
            string pdf = WebApplicationDemo2023.Helpers.Print.CreerDocumentAPartirDuTemplate(f, templateChemin);
            byte[] pdfBytes = System.IO.File.ReadAllBytes(pdf);
            MemoryStream ms = new MemoryStream(pdfBytes);
            return new FileStreamResult(ms, "application/pdf");

        }

        public PrintController(SqlServerContext context)
        {
            _context = context;
        }
    }
}
