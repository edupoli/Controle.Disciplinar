<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="codigoEtica.aspx.cs" Inherits="Controle.Disciplinar.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
    <div class="jumbotron">
        <br />
            <p class="text-center" style="font-size:40px">Controle Disciplinar Operacional</p>
        <br />
    </div>
     <h3>Codigo de Ética e Regulamento Interno</h3><br />
        <div class="form-row col-md-12">
            <div class="col-md-10">
                Selecione:
                <asp:DropDownList CssClass="form-control" runat="server" ID="cboxTipo" AutoPostBack="true"  OnSelectedIndexChanged="cboxTipo_SelectedIndexChanged">
                    <asp:ListItem Value="selecione" Text="--SELECIONE--" />
                    <asp:ListItem Value="codEtica" Text="Código de Etica" />
                    <asp:ListItem Value="regulamento" Text="Regulamento Interno" />
                </asp:DropDownList>
            </div>
        </div>
    <!--
        <div class="form-row col-md-12">
            
            <div class="col-md-2">
                Item:
                <asp:TextBox type="text" class="form-control" style="text-align:center" id="item" runat="server" />
            </div>
            <div class="col-md-8">
                Descrição:
                <asp:TextBox type="text" class="form-control" id="descricao" runat="server" />
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button Text="Salvar" CssClass="btn btn-primary" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" />
            </div> 
        </div> 
    -->
        <div class="form-row col-md-12">
            <div class="col-md-10">
                Itens Cadastrados:
                <asp:DropDownList ID="cboxItem" CssClass="form-control" runat="server" OwnerDraw="true" AutoPostBack="true" OnSelectedIndexChanged="cboxItem_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    <!--
        <div class="form-row col-md-12">
            <div class="col-md-2">
                Sub Item:
                <asp:TextBox type="text" class="form-control" style="text-align:center" id="subIem" runat="server" />
            </div>
            <div class="col-md-8">
                Descrição:
                <asp:TextBox type="text" class="form-control" id="descricaoSubItem" runat="server" />
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button Text="Salvar" CssClass="btn btn-primary" runat="server" ID="btnSubItem" OnClick="btnSubItem_Click"  />
            </div> 
        </div> 
  -->
        <div class="form-row col-md-12">
            <div class="col-md-10">
                Sub-Itens Cadastrados:
                <asp:DropDownList ID="cboxSubItem" CssClass="form-control" runat="server" OwnerDraw="true" AutoPostBack="true" OnSelectedIndexChanged="cboxSubItem_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    <!--
        <div class="form-row col-md-12">
            <div class="col-md-2">
                Artigo:
                <asp:TextBox type="text" class="form-control" style="text-align:center" id="artigo" runat="server" />
            </div>
            <div class="col-md-8">
                Descrição:
                <asp:TextBox type="text" class="form-control" id="descricaoArtigo" runat="server" />
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button Text="Salvar" CssClass="btn btn-primary" runat="server" ID="btnArtigo" OnClick="btnArtigo_Click"  />
            </div> 
        </div>
    -->
        <div class="form-row col-md-12">
            <div class="col-md-10">
                Artigos Cadastrados:
                <asp:DropDownList ID="cboxArtigo" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboxArtigo_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    <!--
        <div class="form-row col-md-12">
            <div class="col-md-2">
                Inciso:
                <asp:TextBox type="text" class="form-control" style="text-align:center" id="inciso" runat="server" />
            </div>
            <div class="col-md-8">
                Descrição:
                <asp:TextBox type="text" class="form-control" id="descricaoInciso" runat="server" />
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button Text="Salvar" CssClass="btn btn-primary" runat="server" ID="btnInciso" OnClick="btnInciso_Click"  />
            </div> 
        </div>
    -->
        <div class="form-row col-md-12">
            <div class="col-md-10">
                Incisos Cadastrados:
                <asp:DropDownList ID="cboxInciso" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboxInciso_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    <br />
    <div class="form-row col-md-12">
        <div class="col-md-10">
               &nbsp;
               <asp:TextBox ID="TextBoxView" CssClass="form-control view" runat="server" lines="400" cols="100" wrap="true" textmode="multiline" ></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    
  <!--<h2>Atendimento PABX Detran-PR</h2> -->
    <asp:Panel ID="painelErroGrid" runat="server">
       <div style="margin: auto; margin-bottom: 20px;" class="alert alert-danger" role="alert">
          <asp:Label runat="server" ID="gridMensagemErro"></asp:Label><br />
       </div>
    </asp:Panel>
        
    
    <br />
            <style>
        .jumbotron{
    position: relative;
    padding:0 !important;
    margin-top:40px !important;
    background: #eee;
    margin-top: 28px;
    text-align:center;
    margin-bottom: 0 !important;
}
        
   th, td {
    white-space: nowrap;
}
   .view{
       height:250px!important;

   }
    </style>
    <script type="text/javascript">
        function sucesso() {
            swal({
                title: 'Sucesso!',
                text: 'Cadastrado com sucesso!',
                type: 'success',
                timer: '2500'
            });
        }
        function errorSubItem() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Sub Item',
                type: 'error'
            });
        }
        function errorSubItemDescricao() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Descrição',
                type: 'error'
            });
        }
        function errorItemID() {
            swal({
                title: 'Erro!',
                text: 'Por favor Selecione o Item na qual será vinculado este Sub Item',
                type: 'error'
            });
        }
        function errorArtigo() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Artigo',
                type: 'error'
            });
        }
        function errorArtigoDescricao() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Descrição',
                type: 'error'
            });
        }
        function errorSubItemID() {
            swal({
                title: 'Erro!',
                text: 'Por favor Selecione o Sub-Item na qual será vinculado este Artigo',
                type: 'error'
            });
        }
        function errorInciso() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Inciso',
                type: 'error'
            });
        }
        function errorIncisoDescricao() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Descrição',
                type: 'error'
            });
        }
        function errorArtigoID() {
            swal({
                title: 'Erro!',
                text: 'Por favor Selecione o Artigo na qual será vinculado este Inciso',
                type: 'error'
            });
            }
    </script>
</asp:Content>
