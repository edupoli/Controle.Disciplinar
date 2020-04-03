<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificacao.aspx.cs" Inherits="Controle.Disciplinar.notificacao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <title></title>
</head>
<body>
    
    <div class="container">
        <div class="col col-lg-12" style="text-align:right!important">
      <asp:Image ImageUrl="/Imagens/logo_scc_cab.png" runat="server" />
    </div>
  <div class="col col-lg-12" style="text-align:center">
    
      <h2>Advertência Disciplinar</h2>
  
      <br />
      <br />
    
  </div>
        
    <div class="col col-lg-12" style="text-align:left!important;margin-left:0px">
        <div class="col-lg-4">
            <label>Colaborador:&nbsp;</label><asp:Label Text="" ID="nome" runat="server" />
        </div>
        <div class="col-lg-2">
            <label>RE:&nbsp;</label><asp:Label Text="" ID="re" runat="server" />
        </div>
        <div class="col-lg-3">
            <label>Data Admissão:&nbsp;</label><asp:Label Text="" ID="dataAdmissao" runat="server"  DataFormatString="{0:dd/MM/yyyy}"/>
        </div>
        <div class="col-lg-3">
            <label>Data da Ocorrência:&nbsp;</label><asp:Label Text="" ID="dataOcorrencia" runat="server"  DataFormatString="{0:dd/MM/yyyy}"/>
        </div>
        
        
    </div>
            
    <div class="col-lg-12">
        <table  class="table-bordeless">
            <tr>
                <td><label>Descrição da Infração:</label></td>
            </tr>
            <tr>
                <td><asp:Label Text="" runat="server" ID="observacoes" /></td><br />
                
            </tr>
            <tr>
                <tr><td>&nbsp;</td></tr>
                <td><label>Aplicação do Código de Etica:<br /></label></td>
            </tr>

            <tr>
                <td><asp:Label Text="" runat="server" ID="item" /></td><br />
            </tr>
            <tr>
                <td><asp:Label Text="" runat="server" ID="subitem" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="" runat="server" ID="artigo" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="" runat="server" ID="inciso" /></td>
            </tr>
            <tr>
                
            </tr>
        </table>
        <asp:ListView ID="ListView1" 
        
        DataKeyNames="advertenciaID"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="100%" border="1" runat="server" id="tblProducts">
            <tr runat="server">
              <th runat="server"></th>  
              <th runat="server">Item</th>
              <th runat="server">SubItem</th>
              <th runat="server">Artigo</th>
              <th runat="server">Inciso</th>  
              <th runat="server">Medida Aplicada</th>  
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("item") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="LastNameLabel" runat="Server" Text='<%#Eval("subitem") %>' />
            </td>
              <td>
              <asp:Label ID="Label1" runat="Server" Text='<%#Eval("artigo") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="Label2" runat="Server" Text='<%#Eval("inciso") %>' />
            </td>
              <td valign="top">
              <asp:Label ID="Label3" runat="Server" Text='<%#Eval("medida") %>' />
            </td>
          </tr>
        </ItemTemplate>
        
      </asp:ListView>

        
        
    </div>
</div>
            
    <br />
    <br />
    <br />
    <br />
    <div class="row">
        <div id="teste">
        <p>Colaborador</p><p></p>
         </div>
            <br />
    <br />
    <br />
        <div id="teste1">
        <p>Supervisor</p><p></p>
         </div>
    </div>
    <style>
        hr{
  border-color:#aaa;
  box-sizing:border-box;
  width:100%;  
}
#teste{
    border-top:solid;
    border-bottom:none!important;
    border-right:none!important;
    border-left:none!important;
    border-style: solid;
    border-width: 1px;
    margin-left:100px;
    width:200px;
}
#teste1{
    border-top:solid;
    border-bottom:none!important;
    border-right:none!important;
    border-left:none!important;
    border-style: solid;
    border-width: 1px;
    margin-left:100px;
    width:200px;
}
p{
    text-align:center
}
        
    </style>
</body>
</html>
