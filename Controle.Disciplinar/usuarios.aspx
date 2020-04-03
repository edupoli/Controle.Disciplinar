<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Controle.Disciplinar.usuarios1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
    <br />
    <div class="jumbotron">
        <br />
        <p class="text-center" style="font-size:35px">Cadastro de Usuários</p>
        <br />
        </div>
    <asp:Panel ID="painelErroGrid" runat="server">
       <div style="margin: auto; margin-bottom: 20px;" class="alert alert-info" role="alert">
          <asp:Label runat="server" ID="gridMensagemErro"></asp:Label><br />
       </div>
    </asp:Panel>
       <div align="right" style="margin: 25px">
          <asp:Button runat="server" type="button" Text="Adicionar" class="btn btn-success" PostBackUrl="~/addUser.aspx" />
       </div>
    
       

    
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
    <!-- jQuery CDN - Slim version (=without AJAX) -->
<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>

<!-- Popper.JS -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>

<!-- Bootstrap JS -->
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>

<!-- jQuery Data Tables CDN -->
<script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js" type="text/javascript" charset="utf8"></script>

<!-- Bootstrap Data Tables JS -->
<script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js" type="text/javascript" charset="utf8"></script>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bluebird/3.3.5/bluebird.min.js"></script>

        <script type="text/javascript" src='https://cdn.jsdelivr.net/sweetalert2/6.3.8/sweetalert2.min.js'> </script>
        <link rel="stylesheet" href='https://cdn.jsdelivr.net/sweetalert2/6.3.8/sweetalert2.min.css' media="screen" />


    <div class="table-responsive">
        <asp:GridView ID="GridUsuarios" runat="server" class="table table-striped table-hover table-responsive table-sm Grid"  AutoGenerateColumns="False" >
             <Columns>
                <asp:BoundField DataField="userId" HeaderText="ID" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="login" HeaderText="Login" />
                 <asp:TemplateField HeaderText="Ações">
                    <ItemTemplate>
                        <asp:Button class="btn badge-info" Text="Editar" ID="btnEditar" runat="server" CommandArgument='<%# Eval("userId") %>' OnClick="btnEditar_Click" />
                        <asp:Button class="btn badge-danger" Text="Deletar" ID="btnExcluir" runat="server" CommandArgument='<%# Eval("userId") %>'  onClick="btnExcluir_Click" />
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
            margin-bottom: 10 !important;
        }
           th, td {
            white-space: nowrap;
        }
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
     <script>
    $(document).ready(function () {
        $('#<%= GridUsuarios.ClientID%>').prepend($("<thead></thead>").append($("#<%= GridUsuarios.ClientID%>").find("tr:first"))).DataTable({
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
        function sucesso() {
            swal({
                title: 'Sucesso!',
                text: 'Exluido com sucesso!',
                type: 'success',
                timer: '2500'
            });
        }
        </script>
</asp:Content>
