<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Controle.Disciplinar.Contact" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron">
            <br />
        <p class="text-center" style="font-size:40px">Cadastro de Colaborador</p>
            <br />
        </div>
     <div align="right" style="margin: 25px">
        <asp:Button runat="server" type="button" ID="btnAdicionar" Text="Adicionar" class="btn btn-success" PostBackUrl="~/addColaborador.aspx" />
        <!--<asp:Button runat="server" type="button" Text="Relatorio" class="btn btn-info" ID="btnRelatorio" OnClick="btnRelatorio_Click"  />-->
    </div>
    <!--<h2>Atendimento PABX Detran-PR</h2>-->
    <asp:Panel ID="painelErroGrid" runat="server">
       <div style="margin: auto; margin-bottom: 20px;" class="alert alert-danger" role="alert">
          <asp:Label runat="server" ID="gridMensagemErro"></asp:Label><br />
       </div>
    </asp:Panel>
    
    <br />
    
    


    
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
    <!-- jQuery CDN - Slim version (=without AJAX) -->
<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
<!-- Popper.JS -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>

<!-- Bootstrap JS -->
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>

<!-- jQuery Data Tables CDN -->
<script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js" type="text/javascript" charset="utf8"></script>

<!-- Bootstrap Data Tables JS -->
<script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js" type="text/javascript" charset="utf8"></script>

    <div class="table-responsive">

    <asp:GridView ID="grid" class="table table-striped table-hover table-sm Grid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="idColaborador" HeaderText="ID" />
            <asp:BoundField DataField="nome" HeaderText="Nome" />
            <asp:BoundField DataField="re" HeaderText="RE" />
            <asp:BoundField DataField="data_admissao" HeaderText="Data Admissão" />
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:Button class="btn badge-info" Text="Editar" ID="btnEditar" runat="server" CommandArgument='<%# Eval("idColaborador") %>' OnClick="btnEditar_Click" />
                    <asp:Button class="btn badge-danger" Text="Deletar" ID="btnExcluir" runat="server" CommandArgument='<%# Eval("idColaborador") %>' OnClick="btnExcluir_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    </div>
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

    </style>


    <script>
            $(document).ready(function () {
            $('#<%= grid.ClientID%>').prepend($("<thead></thead>").append($("#<%= grid.ClientID%>").find("tr:first"))).DataTable({
                "bJQueryUI": true,
                "autoWidth": true,
                 
                "oLanguage": {
                    "sProcessing":   "Processando...",
                    "sLengthMenu":   "Mostrar _MENU_ registros",
                    "sZeroRecords":  "Não foram encontrados resultados",
                    "sInfo":         "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                    "sInfoEmpty":    "Mostrando de 0 até 0 de 0 registros",
                    "sInfoFiltered": "",
                    "sInfoPostFix":  "",
                    "sSearch":       "Pesquisar:",
                    "sUrl":          "",
                    "oPaginate": {
                        "sFirst":    "Primeiro",
                        "sPrevious": "Anterior",
                        "sNext":     "Seguinte",
                        "sLast":     "Último"
                    }
                }
            }) 
            });
    </script>
</asp:Content>
