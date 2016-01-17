using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class ValuesController : ApiController
    {
        const string CONNECTION_STRING = @"workstation id=portfobase.mssql.somee.com;packet size=4096;user id=kronos_SQLLogin_2;pwd=y1mbrk5ev3;data source=portfobase.mssql.somee.com;persist security info=False;initial catalog=portfobase";
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            List<string> l = new List<string>();

            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PortfolioItems", CONNECTION_STRING))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    string s = "{" + String.Format(@"""ID"":""{0}"", ""Name"":""{1}"", ""Description"":""{2}"", ""Image"":""{3}"", ""Video"":""{4}""", r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString()) + "}";
                    l.Add(s);
                }
            }

            return l.ToArray();
        }

        // GET api/values/5
        public string Get(int id)
        {
            string s = "";
            
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PortfolioItems WHERE ID = '"+id+"'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            s = "{" + String.Format(@"""ID"":""{0}"", ""Name"":""{1}"", ""Description"":""{2}"", ""Image"":""{3}"", ""Video"":""{4}""", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()) + "}";
            
            return s;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
