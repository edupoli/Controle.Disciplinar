<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addColaborador.aspx.cs" Inherits="Controle.Disciplinar.addColaborador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
            <div style="margin: auto; width: 900px; margin-top: 50px">
            <h3>Cadastro de Colaboradores</h3><br /><br />
            <div class="row">
                    <asp:TextBox runat="server" class="form-control" ID="txtidColaborador" type="hidden" />
                    <div class="form-group">
                        <asp:Label runat="server">Nome</asp:Label>
                        <asp:TextBox runat="server" class="form-control" ID="txtNome"  />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server">RE</asp:Label>
                        <asp:TextBox runat="server" class="form-control" ID="txtRE"  />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server">Data Admissão</asp:Label>
                        <asp:TextBox runat="server" class="form-control" ID="txtDataAdmissao"  />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server">Observações</asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtobs" lines="10" cols="10" wrap="true" textmode="multiline"></asp:TextBox>
                        
                    </div>
                   <asp:Button runat="server" type="submit" Text="Salvar" class="btn btn-primary" ID="btnSalvar" OnClick="btnSalvar_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Image runat="server" Width="300px" ID="imgSel" />
                </div>
            </div>
            <br />
            <br />
    
            <asp:Panel ID="painelErro" runat="server">
                <div style="margin: auto;" class="alert alert-danger" role="alert">
                    <asp:Label runat="server" ID="lblMensagemErro"></asp:Label><br />
                </div>
            </asp:Panel>
    
            <asp:Panel ID="painelOk" runat="server">
                <div style="margin: auto;" class="alert alert-success" role="alert">
                    <asp:Label runat="server" ID="lblMensagemOK"></asp:Label><br />
                    <asp:Label runat="server" ID="lblCaminhoImg" Visible="false"></asp:Label><br />
                    <asp:Label runat="server" ID="lblId" Visible="false"></asp:Label><br />
                </div>
            </asp:Panel>
        <ajaxToolkit:AnimationExtender ID="AnimationExtender1" runat="server" TargetControlID="painelOk">
            <Animations>
                <OnLoad>
                <FadeOut Duration="5" MinimumOpacity=".1" MaximumOpacity="2" />
                </OnLoad>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender ID="AnimationExtender2" runat="server" TargetControlID="painelErro">
            <Animations>
                <OnLoad>
                <FadeOut Duration="5" MinimumOpacity=".1" MaximumOpacity="2" />
                </OnLoad>
            </Animations>
        </ajaxToolkit:AnimationExtender>    
    <script type="text/javascript">
    $(function () {
        $('[id*=txtDataAdmissao]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd/mm/yyyy",
            language: "pt-br"
        });
    });
    </script>
</asp:Content>
