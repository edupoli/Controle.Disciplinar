using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class notificacao : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        string advertenciaID;
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            Listar();
        }

        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "select advertencia.advertenciaID,advertencia.dataOcorrencia, colaborador.nome,colaborador.re,colaborador.data_admissao, concat(item.item, ' ', item.descricao) as item, concat(subitem.subitem,' ', subitem.descricao) as subitem, concat(artigo.artigo,' ', artigo.descricao) as artigo, concat(inciso.inciso, ' ', inciso.descricao) as inciso, infracoes.medida, advertencia.observacoes  from infracoes inner join item on infracoes.itemID = item.itemID left join subitem on infracoes.subitemid = subitem.subitemid left join inciso on infracoes.incisoID = inciso.incisoID left join artigo on infracoes.itemID = artigo.artigoID inner join advertencia on infracoes.advertenciaID = advertencia.advertenciaID inner join colaborador on advertencia.idColaborador = colaborador.idColaborador where advertencia.advertenciaID =@advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            da.SelectCommand = cmd;
            da.Fill(dt);
            da.Fill(ds);
            MySqlDataReader dr = cmd.ExecuteReader();
            ListViewItem lv;
            ListView1.DataSource = ds;
            ListView1.DataBind();

            int n = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
               // dataOcorrencia.Text = dt.Rows[0][1].ToString();
                nome.Text = dt.Rows[0][2].ToString();
                re.Text = dt.Rows[0][3].ToString();
                Convert.ToDateTime(dataAdmissao.Text = dt.Rows[0][4].ToString());
                Convert.ToDateTime(dataOcorrencia.Text = dt.Rows[0][1].ToString());
                string[] infracoes = new string[8];
                /* for (int i = 0; i < 4; i++)
                 {
                     infracoes[0] =  dt.Rows[0][5].ToString();
                     infracoes[1] =  dt.Rows[0][6].ToString();
                     infracoes[2] =  dt.Rows[0][7].ToString();
                     infracoes[3] =  dt.Rows[0][8].ToString();

                     infracoes[4] = dt.Rows[0][5].ToString();
                     infracoes[5] = dt.Rows[0][6].ToString();
                     infracoes[6] = dt.Rows[0][7].ToString();
                     infracoes[7] = dt.Rows[0][8].ToString();
                 }
                 ListBox1.Items.Clear();
                 for (int i = 0; i < 4; i++)
                 {
                     ListBox1.Items.Add(infracoes[i]);
                 }
                 

                // exibe os itens no controle ListView 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = dt.Rows[i];

                    // Somente as linhas que não foram deletadas
                    if (drow.RowState != DataRowState.Deleted)
                    {
                        // Define os itens da lista
                        ListViewItem lvi = new ListViewItem(drow["infracoes"].ToString());
                        lvi.SubItems.Add(drow["ProductID"].ToString());
                        lvi.SubItems.Add(drow["UnitPrice"].ToString());

                        // Inclui os itens no ListView
                        ListView1.Items.Add(lvi);
                    }
                }
                */
                
                observacoes.Text = dt.Rows[0][10].ToString();
                
            }

            con.FecharCon();
        }


    }
}