//using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
using CSharpApiProject.Models;
using System.Collections.Generic;
using CSharpApiProject.Data;
using System.Linq;

namespace CSharpApiProject.Repositories
{
    public class PlotRepository
    {
        private readonly ApplicationDbContext _context;

        public PlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Plot> GetAllPlots()
        {
            return _context.Plot
                .ToList();
        }

        public Plot GetPlotById(int id)
        {
            return _context.Plot
                .FirstOrDefault(i => i.Id == id);
        }

        // ADO.NET:
        //private readonly string _connectionString;

        //public PlotRepository(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");
        //}

        //public SqlConnection Connection
        //{
        //    get { return new SqlConnection(_connectionString); }
        //}

        //public List<Plot> GetAllPlots()
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT Id, Bed FROM Plot";

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            List<Plot> plots = new List<Plot>();

        //            while (reader.Read())
        //            {
        //                var plot = new Plot()
        //                {
        //                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                    Bed = reader.GetString(reader.GetOrdinal("Bed"))
        //                };

        //                plots.Add(plot);
        //            }

        //            reader.Close();

        //            return plots;
        //        }
        //    }
        //}

        //public Plot GetPlotById(int id)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT Id, Bed FROM Plot WHERE Id = @id";
        //            cmd.Parameters.AddWithValue("@id", id);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Plot plot = null;

        //            if (reader.Read())
        //            {
        //                plot = new Plot
        //                {
        //                    Id = id,
        //                    Bed = reader.GetString(reader.GetOrdinal("Bed"))
        //                };
        //            }

        //            reader.Close();

        //            return plot;
        //        }
        //    }
        //}
    }
}