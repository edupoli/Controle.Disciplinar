using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class historico : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        bool encontrou;
        protected void Page_Load(object sender, EventArgs e)
        {
            painelErroGrid.Visible = false;
        }
        private void buscaColaborador(string re)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable ds = new DataTable();
            sql = "SELECT * FROM colaborador WHERE re=@re";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@re", txtRE.Text);
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Rows.Count == 0)
            {
                encontrou = false;
                txtRE.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtDataAdmissao.Text = string.Empty;
                advertencia.Visible = false;
                GridResumo.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorColaborador();", true);
            }
            
            else
            {
                encontrou = true;
                advertencia.Visible = true;
                GridResumo.Visible = true;
                txtNome.Text = ds.Rows[0][1].ToString();
                txtDataAdmissao.Text = ds.Rows[0][3].ToString();
                txtidColaborador.Text = ds.Rows[0][0].ToString();
            }
            con.FecharCon();

        }
        protected void ListarAdvertencias()
        {
            DataTable ds = new DataTable();
            con.AbrirCon();
            string cmdstr = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia, infracoes.medida, advertencia.observacoes, advertencia.usuario, colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador left join infracoes on advertencia.advertenciaID = infracoes.advertenciaID where colaborador.idColaborador = @idColaborador order by advertenciaID desc";
            //string cmdstr = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia, infracoes.medida, advertencia.observacoes, colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador where colaborador.idColaborador = @idColaborador order by advertenciaID desc";
            MySqlCommand cmd = new MySqlCommand(cmdstr, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", Convert.ToInt32(txtidColaborador.Text));
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            cmd.ExecuteNonQuery();
            if (ds.Rows.Count > 0 )
            {
                painelErroGrid.Visible = false;
                advertencia.DataSource = ds;
                advertencia.DataBind();
            }
            else
            {
                painelErroGrid.Visible = true;
                gridMensagemErro.Text = "Não existem Lançamentos Cadastrados!";
            }
            con.FecharCon();
            

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string advertenciaID = advertencia.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView infracoes = e.Row.FindControl("infracoes") as GridView;

                DataSet ds = new DataSet();
                con.AbrirCon();
                string cmdstr = "select infracoes.advertenciaID, item.item, subitem.subItem,artigo.artigo,inciso.inciso,infracoes.medida from infracoes left join item on infracoes.itemID = item.itemID left join subitem on infracoes.subItemID = subitem.subItemID left join artigo on infracoes.artigoID = artigo.artigoID left join inciso on infracoes.incisoID = inciso.incisoID where infracoes.advertenciaID =@advertenciaID";
                MySqlCommand cmd = new MySqlCommand(cmdstr, con.con);
                cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.ExecuteNonQuery();
                //con.FecharCon();

                infracoes.DataSource = ds;
                infracoes.DataBind();

                if (e.Row.RowIndex >= 0)
                {
                    string medida = DataBinder.Eval(e.Row.DataItem, "medida").ToString();
                    if (medida == "Feedback")
                    {
                        e.Row.Cells[2].BackColor = Color.Violet;
                        e.Row.Cells[2].ForeColor = Color.White;
                    }
                    if (medida == "Orientação")
                    {
                        e.Row.Cells[2].BackColor = Color.DarkCyan;
                        e.Row.Cells[2].ForeColor = Color.White;
                    }
                    if (medida == "Advertencia Verbal")
                    {
                        e.Row.Cells[2].BackColor = Color.Green;
                        e.Row.Cells[2].ForeColor = Color.White;
                    }
                    if (medida == "Advertencia Escrita")
                    {
                        e.Row.Cells[2].BackColor = Color.Yellow;
                        e.Row.Cells[2].ForeColor = Color.Black;
                    }
                    if (medida == "Suspensão")
                    {
                        e.Row.Cells[2].BackColor = Color.Red;
                        e.Row.Cells[2].ForeColor = Color.White;
                    }

                }


            }
        }

        protected void txtRE_TextChanged(object sender, EventArgs e)
        {
            if (txtRE.Text == "")
            {
                advertencia.Visible = false;
            }
            
                if (txtRE.Text !="")
            {
                buscaColaborador(txtRE.Text);
            }
            
                if (encontrou == true)
            {
                ListarAdvertencias();
                ListarTotalAdvertencias();
            }
            
        }

        protected void infracoes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                string medida = DataBinder.Eval(e.Row.DataItem, "medida").ToString();
                if (medida == "Feedback")
                {
                    e.Row.Cells[5].BackColor = Color.Violet;
                    e.Row.Cells[5].ForeColor = Color.White;
                }
                if (medida == "Orientação")
                {
                    e.Row.Cells[5].BackColor = Color.DarkCyan;
                    e.Row.Cells[5].ForeColor = Color.White;
                }
                if (medida == "Advertencia Verbal")
                {
                    e.Row.Cells[5].BackColor = Color.Green;
                    e.Row.Cells[5].ForeColor = Color.White;
                }
                if (medida == "Advertencia Escrita")
                {
                    e.Row.Cells[5].BackColor = Color.Yellow;
                    e.Row.Cells[5].ForeColor = Color.Black;
                }
                if (medida == "Suspensão")
                {
                    e.Row.Cells[5].BackColor = Color.Red;
                    e.Row.Cells[5].ForeColor = Color.White;
                }

            }
        }
        protected void ListarTotalAdvertencias()
        {
            DataSet ds = new DataSet();
            con.AbrirCon();
            string sql = "select advertencia.idColaborador, infracoes.medida,  sum(case when infracoes.medida = 'Orientação' then 1 else 0 end) Total_Orientacao,  sum(case when infracoes.medida = 'Feedback'  then 1 else 0 end) Total_Feedback,  sum(case when infracoes.medida = 'Advertencia Verbal'  then 1 else 0 end) Total_adv_Verbal,  sum(case when infracoes.medida = 'Advertencia Escrita'  then 1 else 0 end) Total_Adv_Escrita,  sum(case when infracoes.medida = 'Suspensão'  then 1 else 0 end) Total_Suspensao from infracoes inner join advertencia on infracoes.advertenciaID = advertencia.advertenciaID where advertencia.idColaborador = @idColaborador group by infracoes.medida order by infracoes.medida asc";
            //string cmdstr = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,advertencia.observacoes,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador where colaborador.idColaborador = @idColaborador order by advertenciaID desc";
            MySqlCommand cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", Convert.ToInt32(txtidColaborador.Text));
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            cmd.ExecuteNonQuery();
            con.FecharCon();
            GridResumo.DataSource = ds;
            GridResumo.DataBind();

        }

        protected void GridResumo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                string medida = DataBinder.Eval(e.Row.DataItem, "medida").ToString();
                string Total_Orientacao = DataBinder.Eval(e.Row.DataItem, "Total_Orientacao").ToString();
                string Total_Feedback = DataBinder.Eval(e.Row.DataItem, "Total_Feedback").ToString();
                string Total_adv_Verbal = DataBinder.Eval(e.Row.DataItem, "Total_adv_Verbal").ToString();
                string Total_Adv_Escrita = DataBinder.Eval(e.Row.DataItem, "Total_Adv_Escrita").ToString();
                string Total_Suspensao = DataBinder.Eval(e.Row.DataItem, "Total_Suspensao").ToString();
                
                if (medida == "Feedback")
                {
                    e.Row.Cells[0].BackColor = Color.Violet;
                    e.Row.Cells[0].ForeColor = Color.White;
                }
                if (Convert.ToInt32(Total_Feedback) > 0)
                {
                    e.Row.Cells[5].BackColor = Color.Violet;
                    e.Row.Cells[5].ForeColor = Color.White;
                }

                if (medida == "Orientação")
                {
                    e.Row.Cells[0].BackColor = Color.DarkCyan;
                    e.Row.Cells[0].ForeColor = Color.White;
                }
                if (Convert.ToInt32(Total_Orientacao) > 0)
                {
                    e.Row.Cells[3].BackColor = Color.DarkCyan;
                    e.Row.Cells[3].ForeColor = Color.White;
                }

                if (medida == "Advertencia Verbal")
                {
                    e.Row.Cells[0].BackColor = Color.Green;
                    e.Row.Cells[0].ForeColor = Color.White;
                }
                if (Convert.ToInt32(Total_adv_Verbal) > 0)
                {
                    e.Row.Cells[2].BackColor = Color.Green;
                    e.Row.Cells[2].ForeColor = Color.White;
                }

                if (medida == "Advertencia Escrita")
                {
                    e.Row.Cells[0].BackColor = Color.Yellow;
                    e.Row.Cells[0].ForeColor = Color.Black;
                }
                if (Convert.ToInt32(Total_Adv_Escrita) > 0)
                {
                    e.Row.Cells[1].BackColor = Color.Yellow;
                    e.Row.Cells[1].ForeColor = Color.Black;
                }

                if (medida == "Suspensão")
                {
                    e.Row.Cells[0].BackColor = Color.Red;
                    e.Row.Cells[0].ForeColor = Color.White;
                }
                if (Convert.ToInt32(Total_Suspensao) > 0 )
                {
                    e.Row.Cells[4].BackColor = Color.Red;
                    e.Row.Cells[4].ForeColor = Color.White;
                }

            }
        }

        protected void advertencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}