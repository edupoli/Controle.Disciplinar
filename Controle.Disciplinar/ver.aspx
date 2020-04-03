<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="Controle.Disciplinar.ver" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
            <br />
        <p class="text-center" style="font-size:40px">Controle Disciplinar Operacional</p>
            <br />
        </div>
    <h3 style="text-align:center">Advertencia</h3><br />
    <asp:GridView ID="GridAdvertencia" runat="server" class="table table-striped table-hover table-sm Grid" AutoGenerateColumns="False">
        <Columns>
                <asp:BoundField DataField="advertenciaID" HeaderText="ID" />
                <asp:BoundField DataField="dataOcorrencia" HeaderText="Data Ocorrência" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="re" HeaderText="RE" />
                <asp:BoundField DataField="nome" HeaderText="Colaborador" />
                <asp:BoundField DataField="observacoes" HeaderText="Observações" />
                <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:Button class="btn badge-info" Text="Editar" ID="btnEditar" runat="server" CommandArgument='<%# Eval("advertenciaID") %>' OnClick="btnEditar_Click" />
                    
                </ItemTemplate>
            </asp:TemplateField>
         </Columns>
    </asp:GridView>

    <h3 style="text-align:center">Infrações</h3><br />
    <asp:GridView ID="GridInfracoes" runat="server" class="table table-striped table-hover table-sm Grid" AutoGenerateColumns="False" DataKeyNames="infracoesID" OnSelectedIndexChanged="GridInfracoes_SelectedIndexChanged" OnRowDataBound="GridInfracoes_RowDataBound" >
        <Columns>
                <asp:BoundField DataField="advertenciaID" HeaderText="ID" />
                <asp:BoundField DataField="item" HeaderText="Item" />
                <asp:BoundField DataField="subitem" HeaderText="Sub-Item" />
                <asp:BoundField DataField="artigo" HeaderText="Artigo" />
                <asp:BoundField DataField="inciso" HeaderText="Inciso" />
                <asp:BoundField DataField="medida" HeaderText="Medida" />
                <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:Button class="btn badge-info" Text="Editar" ID="btnEditarCodigoEtica" runat="server" CommandArgument='<%# Eval("infracoesID") %>' OnClick="btnEditarCodigoEtica_Click" />
                    <asp:Button class="btn badge-info" Text="Deletar" ID="btnDeletarCodigoEtica" runat="server" CommandArgument='<%# Eval("infracoesID") %>' OnClick="btnDeletarCodigoEtica_Click" />
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" ID="msg">
    <div class="alert alert-info" role="alert" id="mgs" runat="server">
        <strong>Sem Registro!</strong> Não Existem Infrações do Código de Etica Cadastrada para essa Advertência.
        <asp:Button CssClass="btn btn-primary pull-right" ID="btnAdicionarInfracao" Text="Adicionar Infrações" runat="server" OnClick="btnAdicionarInfracao_Click" />
    </div>
    </asp:Panel>
    <br />
    <br />
    <asp:TextBox runat="server" class="form-control" ID="txtInracoesID" type="hidden" />
    
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
        
  
    </style>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Grid td
        {
            background-color: #F7F7F7;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .Grid th
        {
            background-color: #344659;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid td
        {
            background-color: #e1e1e1 !important;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid th
        {
            background-color: #344659 !important;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
    </style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
        <script type="text/javascript">
        function sucessoExcluir() {
            swal({
                title: 'Sucesso!',
                text: 'Excluido com sucesso!',
                type: 'success',
                timer: '2500'
            });
        }
     </script>
</asp:Content>
