<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="advertencia1.aspx.cs" Inherits="Controle.Disciplinar.advertencia1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
    <div class="jumbotron">
        <br />
            <p class="text-center" style="font-size:40px">Controle Disciplinar Operacional</p>
        <br />
    </div>
     
    <h3 style="text-align:center">Lançamento de Advertencia</h3><br />
    <div style="margin: auto; width: 900px; margin-top: 10px">
        <div class="row form-inline">
            <asp:Panel ID="Panel1" runat="server">
                <div class="altert ">
                    <asp:TextBox runat="server" class="form-control" ID="txtAdvertenciaID" type="hidden" />
                    <asp:TextBox runat="server" class="form-control" ID="ultimoID" type="hidden" />
                    <asp:TextBox runat="server" class="form-control" ID="txtidColaborador" type="hidden" />
                    <asp:TextBox runat="server" class="form-control" ID="textUsuario"  type="hidden"/>
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
                        <div class="form-group">
                        Data da Ocorrência:
                        <asp:TextBox runat="server" class="form-control data" ID="dataOcorrencia"  /><br />
                    </div>
                        <div class="form-group" style="width:100%">
                            <br />
                        Descreva a Infração Cometida pelo Colaborador:
                        <asp:TextBox runat="server" CssClass="form-control obs" ID="txtobs" lines="100" cols="100" wrap="true" textmode="multiline"></asp:TextBox>
                    </div>
                    </div>
                    </div>
                <br />
                
                    <asp:Button runat="server" type="submit" Text="Salvar" class="btn btn-primary" ID="btnSalvar" OnClick="btnSalvar_Click" />
                </asp:Panel>
                

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
