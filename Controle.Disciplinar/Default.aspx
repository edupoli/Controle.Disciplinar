﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Controle.Disciplinar._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
        <div class="jumbotron">
            <br />
        <p class="text-center" style="font-size:40px">Controle Disciplinar Operacional</p>
            <br />
        </div>
    <div align="right" style="margin: 25px">
                <asp:Button runat="server" type="button" ID="btnAdicionar" Text="Adicionar" class="btn btn-success" PostBackUrl="~/punir.aspx" />
            </div>
    <div class="table-responsive">
        <asp:GridView ID="GridView1" runat="server" class="table table-striped table-hover table-sm" AutoGenerateColumns="False" DataKeyNames="advertenciaID" DataSourceID="SqlDataSourceGeral">
            <Columns>
                
                <asp:BoundField DataField="advertenciaID" HeaderText="ID" />
                <asp:BoundField DataField="dataOcorrencia" HeaderText="Data Ocorrência" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="nome" HeaderText="Colaborador" />
                
                <asp:BoundField DataField="observacoes" HeaderText="Observações" />
                <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:Button class="btn badge-info" Text="Ver" ID="btnResponder" runat="server" CommandArgument='<%# Eval("advertenciaID") %>' OnClick="btnResponder_Click" />
                    <asp:Button class="btn badge-danger" Text="Deletar" ID="btnExcluir" runat="server" CommandArgument='<%# Eval("advertenciaID") %>' OnClick="btnExcluir_Click" />
                </ItemTemplate>
            </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceGeral" runat="server" ConnectionString="<%$ ConnectionStrings:sistemas_internosConnectionString %>" ProviderName="<%$ ConnectionStrings:sistemas_internosConnectionString.ProviderName %>" SelectCommand="select advertencia.advertenciaID,advertencia.dataOcorrencia, colaborador.nome,advertencia.observacoes  from advertencia inner join colaborador on advertencia.idColaborador = colaborador.idColaborador order by advertencia.dataocorrencia ASC"></asp:SqlDataSource>
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
    <script>
            $(document).ready(function () {
            $('#<%= GridView1.ClientID%>').prepend($("<thead></thead>").append($("#<%= GridView1.ClientID%>").find("tr:first"))).DataTable({
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
