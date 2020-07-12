using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;

public class SaleRepository
{
    DbConfig db;
    public SaleRepository(IConfiguration csg)
    {
        db = new DbConfig();
        csg.GetSection("DB").Bind(db);
    }
    public List<SaleByCountry> GetSaleByCountry()
    {
        string sql = "EXEC GetSaleByCountry";

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<SaleByCountry>(sql).ToList();

            return res;
        }
    }
    public List<SaleByCountry> GetSaleByCountriyBetweenDate()
    {

        using (var connection = new SqlConnection(db.CS))
        {

            var res = connection.Query<SaleByCountry>("GetSaleByCountryBetweenDates",
             new
             {
                 dateFrom = new System.DateTime(1997, 01, 01),
                 dateTo = new System.DateTime(1997, 12, 31)
             },
    commandType: CommandType.StoredProcedure).ToList();

            return res;
        }
    }

    public List<TerritorisList> GetTerretorisByRegion(int regionId)
    {
        string sql = "EXEC GetTerritorisByRegion " + regionId;

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<TerritorisList>(sql).ToList();

            return res;
        }
    }

    public List<RaportPremia> RaportPremia(int wielkoscPremii)
    {
        string sql = "EXEC RaportPremia " + wielkoscPremii;

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<RaportPremia>(sql).ToList();

            return res;
        }
    }
    public List<CityList> ListCity()
    {
        string sql = "EXEC ListCity";

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<CityList>(sql).ToList();

            return res;
        }
    }

    public List<Customers> GetCostumersByCity(int Id)
    {
        string sql = "EXEC GetCustomersByCity " + Id;

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<Customers>(sql).ToList();

            return res;
        }
    }

    public void DeleteCustomerById(string Id)
    {
        string sql = "DELETE Customers WHERE CustomerID='" + Id + "'";

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Execute(sql);
        }
    }

     public List<Order> GetOrderDetails(string Id)
    {
        string sql = "EXEC GetOrderDetails " + Id;

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<Order>(sql).ToList();

            return res;
        }
    }
     public List<Order> GetOrder (string Id)
    {
        string sql = "EXEC GetOrder " + Id;

        using (var connection = new SqlConnection(db.CS))
        {
            var res = connection.Query<Order>(sql).ToList();

            return res;
        }
    }
}