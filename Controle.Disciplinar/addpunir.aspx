<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addpunir.aspx.cs" Inherits="Controle.Disciplinar.addpunir" %>
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
                    <br />
                    <h3 style="text-align:center">Informe qual o item é aplicado a essa Infração.<!-- <asp:Label ID="Label1" runat="server" Text=""></asp:Label> --></h3>
                    <asp:TextBox runat="server" class="form-control" ID="txtAdvertenciaID" type="hidden" />
                    <div class="form-group row" style="width:100%">
                        Selecione:
                        <asp:DropDownList CssClass="form-control item" runat="server" ID="cboxTipo" AutoPostBack="true"  OnSelectedIndexChanged="cboxTipo_SelectedIndexChanged">
                            <asp:ListItem Value="selecione" Text="--SELECIONE--" />
                            <asp:ListItem Value="codEtica" Text="Código de Etica" />
                            <asp:ListItem Value="regulamento" Text="Regulamento Interno" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group row" style="width:100%">
                        Itens:
                        <asp:DropDownList ID="cboxItem" CssClass="form-control item" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="cboxItem_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group row" style="width:100%">
                        Sub-Itens:
                        <asp:DropDownList ID="cboxSubItem" CssClass="form-control subitem" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="cboxSubItem_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group row" style="width:100%">
                        Artigos:
                        <asp:DropDownList ID="cboxArtigo" CssClass="form-control artigo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboxArtigo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group row" style="width:100%">
                        Incisos:
                        <asp:DropDownList ID="cboxInciso" CssClass="form-control inciso" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboxInciso_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group row" style="width:100%">
                        Tipo de Medida Aplicada:
                        <asp:DropDownList ID="cboxMedida" CssClass="form-control medida" runat="server">
                            <asp:ListItem>SELECIONE</asp:ListItem>
                            <asp:ListItem Value="Feedback">Feedback</asp:ListItem>
                            <asp:ListItem Value="Orientação">Orientação</asp:ListItem>
                            <asp:ListItem Value="Advertencia Verbal">Advertencia Verbal</asp:ListItem>
                            <asp:ListItem Value="Advertencia Escrita">Advertencia Escrita</asp:ListItem>
                            <asp:ListItem Value="Suspensão">Suspensão</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group row" style="width:100%">
                        &nbsp;
                        <asp:TextBox ID="TextBoxView" CssClass="form-control view" runat="server" lines="100" cols="100" wrap="true" textmode="multiline" ReadOnly="true"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                <div class="form-group row" style="width:100%">
                <asp:GridView ID="GridView1" CssClass="table-striped table" runat="server">

                </asp:GridView>
                </div>
            
                   
                    <br />
                    <br />
                   
                    <asp:Button runat="server" type="submit" Text="Adicionar Infrações" class="btn btn-danger" ID="btnInfracao" OnClick="btnInfracao_Click" />
                    <asp:Button runat="server" type="submit" Text="Não há Violação ao Código de Etica" class="btn btn-primary" ID="btnSemInfracao" OnClick="btnSemInfracao_Click" />
                </div>
        

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
