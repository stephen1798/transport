

using System.Text;

public class PdfSaleRepository
{
    private readonly SaleRepository _repo;

    public PdfSaleRepository(SaleRepository repo)
    {
      _repo=repo ; 
    }
    public string GenerujRaport()
    {  
        var dane = _repo.RaportPremia(20000);

        var sb = new StringBuilder();

        // var ile =5;
        // sb.Append("aaaa");
        // sb.Append($"Test {ile} test!");
        // var res = sb.ToString();
        sb.Append($"<h1>Premia na dzien: {System.DateTime.Now.ToShortDateString()}</h1><br>");

        sb.Append("<ul>");
        foreach (var item in dane)
        {
            //osobe, która otrzymała największa premie (1 pozycja w rankingu) oznacz pogrubieniem i kolorem czerwonym
            //zwieksz czcionke raportu
            //dodaj odstepy pomiedzy wpisami
            sb.Append("<li>");

            if (item.Rank == 1)
            {
                sb.Append("<span style='color:red; font-weight:bold'>");
            }

            sb.Append($"Imie: {item.FirstName} ");
            sb.Append($"Nazwisko: {item.LastName} ");
            sb.Append($"Premia: {item.WartoscPremii} ");

            if (item.Rank == 1)
            {
                sb.Append("</span>");
            }

        }
        sb.Append("</ul>");
        return sb.ToString();
    }
}
