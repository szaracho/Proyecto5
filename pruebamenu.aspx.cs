using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5
{
    public partial class pruebamenu : System.Web.UI.Page
    {
       public List<Empresas> registros = new List<Empresas>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    string query = "SELECT empresa, basedatos FROM empresas";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Empresas registro = new Empresas();
                        registro.empresa = reader["empresa"].ToString();
                        registro.bd = reader["basedatos"].ToString();
                        registros.Add(registro);
                    }
                    reader.Close();
                }
            }





        }



        public class Empresas
        {
            public string empresa { get; set; }
            public string bd { get; set; }
            // Agrega las propiedades adicionales que necesites
        }
    }
}