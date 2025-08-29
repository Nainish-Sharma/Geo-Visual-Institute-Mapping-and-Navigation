using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using map.Models;

namespace map.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Index()
        {
            var locations = GetInstitutesFromDatabase();
            return View(locations);
        }

        private List<InstituteLocation> GetInstitutesFromDatabase()
        {
            List<InstituteLocation> list = new List<InstituteLocation>();
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT InstID, InstName, InstAddress, CityID, Latitude, Longitude,accCount FROM accrInst ", conn);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new InstituteLocation
                        {
                            InstID = Convert.ToInt32(reader["InstID"]),
                            InstName = reader["InstName"].ToString(),
                            InstAddress = reader["InstAddress"].ToString(),
                            CityID = reader["CityID"].ToString(),
                            Latitude = Convert.ToDouble(reader["Latitude"]),
                            Longitude = Convert.ToDouble(reader["Longitude"]),
                            AccCount = Convert.ToInt32(reader["accCount"])
                        });

                    }
                }
            }
            return list;
        }
    }
}
