using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controle.Disciplinar
{
    public class Conexao
    {
        public string conec = "SERVER=10.0.2.9;DATABASE=disciplinar;UID=ura;PWD=ask123;Pooling=False";
        public MySqlConnection con = null;
        public void AbrirCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
                //HttpContext.Current.Response.Write("Conectado");
            }
            catch (System.Exception ex)
            {

                HttpContext.Current.Response.Write("Erro ao conectar" + ex);
            }
        }
        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (System.Exception ex)
            {

                HttpContext.Current.Response.Write("Erro ao conectar" + ex);
            }
        }
    }
}