<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Controle.Disciplinar.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="advertenciaID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="advertenciaID" HeaderText="advertenciaID" InsertVisible="False" ReadOnly="True" SortExpression="advertenciaID" />
            <asp:BoundField DataField="idColaborador" HeaderText="idColaborador" SortExpression="idColaborador" />
            <asp:BoundField DataField="dataOcorrencia" HeaderText="dataOcorrencia" SortExpression="dataOcorrencia" />
            <asp:BoundField DataField="observacoes" HeaderText="observacoes" SortExpression="observacoes" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sistemas_internosConnectionString %>" ProviderName="<%$ ConnectionStrings:sistemas_internosConnectionString.ProviderName %>" SelectCommand="SELECT advertenciaID, idColaborador, dataOcorrencia, observacoes FROM advertencia"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sistemas_internosConnectionString %>" DeleteCommand="DELETE FROM infracoes WHERE infracoesID = ?" InsertCommand="INSERT INTO infracoes (infracoesID, advertenciaID, itemID, subItemID, artigoID, incisoID, medida) VALUES (?, ?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:sistemas_internosConnectionString.ProviderName %>" SelectCommand="SELECT infracoesID, advertenciaID, itemID, subItemID, artigoID, incisoID, medida FROM infracoes WHERE (advertenciaID = @Param1)" UpdateCommand="UPDATE infracoes SET advertenciaID = ?, itemID = ?, subItemID = ?, artigoID = ?, incisoID = ?, medida = ? WHERE infracoesID = ?">
        <DeleteParameters>
            <asp:Parameter Name="infracoesID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="infracoesID" Type="Int32" />
            <asp:Parameter Name="advertenciaID" Type="Int32" />
            <asp:Parameter Name="itemID" Type="Int32" />
            <asp:Parameter Name="subItemID" Type="Int32" />
            <asp:Parameter Name="artigoID" Type="Int32" />
            <asp:Parameter Name="incisoID" Type="Int32" />
            <asp:Parameter Name="medida" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="advertenciaID" Type="Int32" />
            <asp:Parameter Name="itemID" Type="Int32" />
            <asp:Parameter Name="subItemID" Type="Int32" />
            <asp:Parameter Name="artigoID" Type="Int32" />
            <asp:Parameter Name="incisoID" Type="Int32" />
            <asp:Parameter Name="medida" Type="String" />
            <asp:Parameter Name="infracoesID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
