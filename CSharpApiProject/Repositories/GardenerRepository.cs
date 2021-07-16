using CSharpApiProject.Models;
using System.Collections.Generic;
using CSharpApiProject.Data;
using System.Linq;

namespace CSharpApiProject.Repositories
{
    public class GardenerRepository
    {
        private readonly ApplicationDbContext _context;

        public GardenerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Gardener> GetAllGardeners()
        {
            return _context.Gardener
                .ToList();
        }

        public Gardener GetGardenerById(int id)
        {
            return _context.Gardener
                .FirstOrDefault(i => i.Id == id);
        }

        // ADO.NET: 
        //private readonly string _connectionString;

        //public GardenerRepository(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");
        //}

        //public SqlConnection Connection
        //{
        //    get { return new SqlConnection(_connectionString); }
        //}

        //public List<Gardener> GetAllGardeners()
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                SELECT
        //                    g.Id,
        //                    g.FirstName,
        //                    g.LastName,
        //                    g.Email,
        //                    g.Phone,
        //                    g.PlotId,
        //                    p.Id,
        //                    p.Bed
        //                FROM
        //                    Gardener as g
        //                LEFT JOIN
        //                    Plot as p ON p.Id = g.PlotId
        //                ORDER BY
        //                    g.FirstName;
        //               ";

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            List<Gardener> gardeners = new List<Gardener>();

        //            while (reader.Read())
        //            {
        //                var gardener = new Gardener()
        //                {
        //                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
        //                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
        //                    Email = reader.GetString(reader.GetOrdinal("Email")),
        //                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
        //                    PlotId = reader.GetInt32(reader.GetOrdinal("PlotId")),
        //                    Plot = new Plot()
        //                    {
        //                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                        Bed = reader.GetString(reader.GetOrdinal("Bed"))
        //                    }
        //                };

        //                gardeners.Add(gardener);
        //            }

        //            reader.Close();

        //            return gardeners;
        //        }
        //    }
        //}

        //public Gardener GetGardenerById(int id)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                SELECT
        //                    g.Id,
        //                    g.FirstName,
        //                    g.LastName,
        //                    g.Email,
        //                    g.Phone,
        //                    g.PlotId,
        //                    p.Id,
        //                    p.Bed
        //                FROM
        //                    Gardener as g
        //                LEFT JOIN
        //                    Plot as p ON p.Id = g.PlotId
        //                WHERE g.Id = @id;
        //            ";
        //            cmd.Parameters.AddWithValue("@id", id);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Gardener gardener = null;

        //            if (reader.Read())
        //            {
        //                gardener = new Gardener
        //                {
        //                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
        //                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
        //                    Email = reader.GetString(reader.GetOrdinal("Email")),
        //                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
        //                    PlotId = reader.GetInt32(reader.GetOrdinal("PlotId")),
        //                    Plot = new Plot()
        //                    {
        //                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                        Bed = reader.GetString(reader.GetOrdinal("Bed"))
        //                    }
        //                };
        //            }

        //            reader.Close();

        //            return gardener;
        //        }
        //    }
        //}
    }
}