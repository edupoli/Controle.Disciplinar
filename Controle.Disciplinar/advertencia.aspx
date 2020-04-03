<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="advertencia.aspx.cs" Inherits="Controle.Disciplinar.advertencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    <h3 style="text-align:center">Historico de Advertências</h3><br />
    <div style="margin: auto; width: 900px; margin-top: 10px">
        <div class="row form-inline">
            <asp:Panel ID="Panel1" runat="server">
                    <asp:TextBox runat="server" class="form-control" ID="txtAdvertenciaID" type="hidden" />
                    <asp:TextBox runat="server" class="form-control" ID="ultimoID" type="hidden" />
                    <asp:TextBox runat="server" class="form-control" ID="txtidColaborador" type="hidden" />
                    <div class="form-group row" style="width:100%">
                    <div class="form-group">
                        RE:
                        <asp:TextBox runat="server" class="form-control re" ID="txtRE" AutoPostBack="true"  OnTextChanged="txtRE_TextChanged"  />
                    </div>
                    
                    <div class="form-group">
                        Nome:
                        <asp:TextBox runat="server" class="form-control nome" ID="txtNome"  />
                    </div>
                    
                    <div class="form-group">
                        Data Adminissão:
                        <asp:TextBox runat="server" class="form-control data" ID="txtDataAdmissao"  />
                    </div>
                </div>
                </asp:Panel>
            </div>
       </div>
    <div class="container-fluid">
        <br />
        <asp:Label ID="Label1" runat="server" CssClass="alert-info" Text=""></asp:Label>
        <asp:GridView ID="GridView1" CssClass="table-responsive table-striped table" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="dataOcorrencia" HeaderText="Data Ocorrencia" />
                <asp:BoundField DataField="item" HeaderText="Item" />
                <asp:BoundField DataField="subItem" HeaderText="Sub-Item" />
                <asp:BoundField DataField="artigo" HeaderText="Artigo" />
                <asp:BoundField DataField="inciso" HeaderText="Inciso" />
                <asp:BoundField DataField="medida" HeaderText="Medida" />
                <asp:BoundField DataField="observacoes" HeaderText="Observações" />
            </Columns>
            <EmptyDataTemplate>Não foram encontrados registros para o Colaborador Informado</EmptyDataTemplate>
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
   .re{
       max-width:80px;
   }
   .nome{
       width:320px!important;
   }
   .data{
      max-width:100px;
   }
   .item, .subitem, .artigo, .inciso, .obs, .medida {
    width:100%!important;
}
   .view{
       width:100%!important;
       height:200px!important;
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
        function errorColaborador() {
            swal({
                title: 'Erro!',
                text: 'Colaborador não Encontrado !',
                type: 'error',
                timer: '2000'
            });
        }
        function erroPreencColaborador() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo RE',
                type: 'error'
            });
        }
        function errorMedida() {
            swal({
                title: 'Erro!',
                text: 'Por favor Selecione qual o tipo de Medida Aplicada ',
                type: 'error'
            });
        }
        function errorData() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha a data da Ocorrencia',
                type: 'error'
            });
        }
        function errorItem() {
            swal({
                title: 'Erro!',
                text: 'Por favor Selecione Qual Item do Codigo de Conduta será aplicado',
                type: 'error'
            });
        }
        function sucessoExcluir() {
            swal({
                title: 'Sucesso!',
                text: 'Excluido com Sucesso!',
                type: 'success',
                timer: '2500'
            });
            }
    </script>
    <script type="text/javascript">
    $(function () {
        $('[id*=dataOcorrencia]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd/mm/yyyy",
            language: "pt-br",
            autoclose: true
        });
    });
        </script>
    
</asp:Content>
