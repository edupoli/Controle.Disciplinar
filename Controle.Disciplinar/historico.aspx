<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="historico.aspx.cs" Inherits="Controle.Disciplinar.historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
            <br />
        <p class="text-center" style="font-size:40px">Controle Disciplinar Operacional</p>
            <br />
        </div>
    <h3 style="text-align:center">Historico de Advertências</h3><br />
    <div align="right" style="margin: 25px">
                <asp:Button runat="server" type="button" ID="btnAdicionar" Text="Adicionar" class="btn btn-success" PostBackUrl="~/advertencia1.aspx" />
            </div>
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
        <br />
        <br />
        <asp:Panel ID="painelErroGrid" runat="server">
       <div style="margin: auto; margin-bottom: 20px;" class="alert alert-danger" role="alert">
          <asp:Label runat="server" ID="gridMensagemErro"></asp:Label><br />
       </div>
    </asp:Panel>
       </div>    
    
    
    
    
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
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "Imagens/minus.gif");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "Imagens/plus.gif");
        $(this).closest("tr").next().remove();
    });
</script>
    <br />
    <asp:GridView ID="GridResumo" runat="server" AutoGenerateColumns="False" class="table table-striped table-hover table-sm Grid" OnRowDataBound="GridResumo_RowDataBound">
        <Columns>
            <asp:BoundField DataField="medida" HeaderText="Medida" />
            <asp:BoundField DataField="Total_Adv_Escrita" HeaderText="Total Advertência Escrita" />
            <asp:BoundField DataField="Total_adv_Verbal" HeaderText="Total Advertência Verbal" />
            <asp:BoundField DataField="Total_Orientacao" HeaderText="Total Orientação" />
            <asp:BoundField DataField="Total_Suspensao" HeaderText="Total Suspenção" />
            <asp:BoundField DataField="Total_Feedback" HeaderText="Total Feedback" />
        </Columns>
    </asp:GridView>

    <div class="table-responsive">
    <asp:GridView ID="advertencia" runat="server" AutoGenerateColumns="False" class="table table-striped table-hover table-sm Grid"
        DataKeyNames="advertenciaID" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="Imagens/plus.gif" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none ">
                        <asp:GridView ID="infracoes" runat="server" AutoGenerateColumns="false" CssClass = "ChildGrid" OnRowDataBound="infracoes_RowDataBound">
                            <Columns>
                                <asp:BoundField ItemStyle-Width="150px" DataField="advertenciaID" HeaderText="ID" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="item" HeaderText="Item" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="subitem" HeaderText="Sub-Item" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="artigo" HeaderText="Artigo" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="inciso" HeaderText="Inciso" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="medida" HeaderText="Medida" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="150px" DataField="advertenciaID" HeaderText="ID" >
<ItemStyle Width="30px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="medida" HeaderText="Medida" >
<ItemStyle Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="dataOcorrencia" HeaderText="Data Ocorrência" DataFormatString="{0:dd/MM/yyyy}" >
<ItemStyle Width="150px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="250px" DataField="nome" HeaderText="Colaborador" >
<ItemStyle Width="150px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="re" HeaderText="RE" >
<ItemStyle Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="observacoes" HeaderText="Descrição" >
<ItemStyle Width="850px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="usuario" HeaderText="Responsável" >
<ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
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
        

    </style>
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
    <script>
            $(document).ready(function () {
            $('#<%= advertencia.ClientID%>').prepend($("<thead></thead>").append($("#<%= advertencia.ClientID%>").find("tr:first"))).DataTable({
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
        function errorColaborador() {
            swal({
                title: 'Erro!',
                text: 'Colaborador não Encontrado!',
                type: 'error',
                timer: '2500'
            });
        }
     </script>
</asp:Content>
