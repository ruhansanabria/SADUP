using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using System.Web;

namespace SAUP
{
    public partial class Manter_Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void Gravar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                if (Session["User_name"] == null)
                {
                    Response.Redirect("~/Account/Logout.aspx");
                }
                if (DescProduto.Text != "" && IdentificadorDescricao.Text != null)
                {
                    ProdutoBC produto = new ProdutoBC();
                    ProdutoModel ProdutoModel = new ProdutoModel();

                    String descricao, unidade;

                    descricao = DescProduto.Text.Replace("'", "");
                    unidade = IdentificadorDescricao.Text.Replace("'", "");

                    ProdutoModel.descricao = descricao;
                    ProdutoModel.unidade = unidade;

                    Label1.Visible = true;
                    Label1.Text = "<script>alert('" + produto.Inserir_Produto(ProdutoModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";

                    GridViewProdutos.DataBind();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "<script>alert('Campos para preenchimento estão inválidos')</script>";

                }
            }
        }

        protected void GridViewProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label1.Visible = false;
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProdutos.Rows[index];

                ListItem item = new ListItem();
                item.Text = row.Cells[1].Text + "    " +
                            row.Cells[2].Text + "    " +
                            row.Cells[3].Text;

                Session["idProduto"] = row.Cells[1].Text;
                DescProduto.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                IdentificadorDescricao.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);

                Gravar.Visible = false;
                Editar.Visible = true;
                Cadastrolink.Visible = true;

            }
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            { 
            if (DescProduto.Text != "" && IdentificadorDescricao.Text != null)
            {
                ProdutoBC produto = new ProdutoBC();
                ProdutoModel ProdutoModel = new ProdutoModel();

                String descricao, unidade;
                int IDProduto;

                IDProduto = Convert.ToInt32(Session["idProduto"].ToString());
                descricao = DescProduto.Text.Replace("'", "");
                unidade = IdentificadorDescricao.Text.Replace("'", "");

                ProdutoModel.id = IDProduto;
                ProdutoModel.descricao = descricao;
                ProdutoModel.unidade = unidade;

                Label1.Visible = true;
                Label1.Text = "<script>alert('" +produto.Editar_Produto(ProdutoModel)+ "')</script>";

                GridViewProdutos.DataBind();

                //Após Edição
                Session["idProduto"] = null;
                DescProduto.Text = null;
                IdentificadorDescricao.Text = null;
            }
            else 
            {
                Label1.Visible = true;
                Label1.Text = "<script>alert('Campos para edição estão inválidos')</script>";
                
            }
           }
        }

        protected void MenuPrincipal_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }
        protected void Cadastrolink_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Session["idProduto"] = null;
            DescProduto.Text = null;
            IdentificadorDescricao.Text = null;

            Gravar.Visible = true;
            Editar.Visible = false;
            Cadastrolink.Visible = false;
        }
    }
}