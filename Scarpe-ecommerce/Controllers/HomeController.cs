using Scarpe_ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace Scarpe_ecommerce.Controllers
{
    public class HomeController : Controller
    {

        //private List<Articoli> connessionetoDB()
        //{


        //    return listaArticoli;
        //}





        public ActionResult Index()
        {
            List<Articoli> listaArticoli= new List<Articoli>();
          
            SqlConnection conessione = new SqlConnection();
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["scarpissDB"].ToString();
            conessione.Open();

            
                SqlCommand commando= conessione.CreateCommand();
                commando.CommandText = "select * from articoli ";
                commando.Connection= conessione;
                SqlDataReader reader= commando.ExecuteReader();
                if(reader.HasRows) 
                {
                    while(reader.Read())
                    {
                        Articoli A = new Articoli();
                        A.IDarticolo = Convert.ToInt32(reader["IDarticolo"]);
                        A.NomeArticolo = reader["nome"].ToString();
                        A.Prezzo = Convert.ToDecimal(reader["prezzo"]);                     
                        A.imgCopertina = reader["imgCopertina"].ToString();                 
                        listaArticoli.Add(A);
                    }
                }
                        return View(listaArticoli);

           
        }

        public ActionResult detagliArticolo(int ID)
        {

            SqlConnection conessione = new SqlConnection();
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["scarpissDB"].ToString();
            conessione.Open();


            SqlCommand commando = conessione.CreateCommand();
            commando.Parameters.AddWithValue("@ID", ID);
            commando.CommandText = "select * from articoli where IDarticolo=@ID";
            commando.Connection = conessione;
            SqlDataReader reader = commando.ExecuteReader();
             Articoli A = new Articoli();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    A.IDarticolo = ID;
                    A.NomeArticolo = reader["nome"].ToString();
                    A.Prezzo = Convert.ToDecimal(reader["prezzo"]);
                    A.Descrizione = reader["Descrizione"].ToString();
                    A.imgCopertina = reader["imgCopertina"].ToString();
                    A.IMG1 = reader["img1"].ToString();
                    A.IMG2 = reader["img2"].ToString();
                }
            }
            return View(A);
        }
         
     public ActionResult delete(int ID)
        {
            SqlConnection conessione = new SqlConnection();

            try {     
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["scarpissDB"].ToString();
            conessione.Open();


            SqlCommand commando = conessione.CreateCommand();
            commando.Parameters.AddWithValue("@ID", ID);
            commando.CommandText = "DELETE FROM articoli WHERE IDarticolo=@ID";
            commando.Connection = conessione;
            commando.ExecuteNonQuery();
            }catch(Exception ex)
            {

            }
            finally
            {
                conessione.Close();
            }
            return RedirectToAction("Index");



        }




        public ActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Articoli A)
        {
            return View();
        }

        //[HttpPost]
        //[]
        //public ActionResult CreateArticolo(Articoli A)
        //{
        //    return View();
        //}
    }

    


}