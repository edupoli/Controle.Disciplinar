<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="Controle.Disciplinar.addUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: auto; width: 900px; margin-top: 50px; ">
        <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
    
    <h3>Cadastro de Usuários</h3>
    <br />
    <div class="row">
        <asp:TextBox runat="server" class="form-control" ID="txtuserid" type="hidden" />
            <div class="form-group">
                <asp:Label runat="server">Nome</asp:Label>
                <asp:TextBox runat="server" class="form-control" ID="txtNome"  />
            </div>
        <div class="form-group">
            <asp:Label runat="server">Login</asp:Label>
            <asp:TextBox runat="server" class="form-control" ID="txtLogin" />
        </div>
        <div class="form-group">
            <asp:Label runat="server">Senha</asp:Label>
            <asp:TextBox runat="server" class="form-control" ID="txtSenha" type="password" />
        </div>
        <div class="form-group">
            <asp:Label runat="server">Redigite a Senha</asp:Label>
            <asp:TextBox runat="server" class="form-control" ID="txtConfirmaSenha" type="password" />
        </div>
        
        <div class="form-group">
        <asp:Button runat="server" type="submit" Text="Salvar" class="btn btn-primary" ID="btnSalvar" OnClick="btnSalvar_Click" />
            <asp:Button runat="server" Text="Voltar" CssClass="btn btn-danger" ID="btnVoltar" PostBackUrl="~/usuarios.aspx"/>
        </div>
    </div>
        <asp:Panel ID="painelErro" runat="server">
                <div style="margin: auto;" class="alert alert-danger" role="alert">
                    <asp:Label runat="server" ID="lblMensagemErro"></asp:Label><br />
                </div>
            </asp:Panel>
    
            <asp:Panel ID="painelOk" runat="server">
                <div style="margin: auto;" class="alert alert-success" role="alert">
                    <asp:Label runat="server" ID="lblMensagemOK"></asp:Label><br />
                </div>
            </asp:Panel>
        
    </div>
<script type="text/javascript">
        function sucesso() {
            swal({
                title: 'Sucesso!',
                text: 'Cadastrado com sucesso!',
                type: 'success',
                timer: '2500'
            });
        }
        function sucessoAlterado() {
            swal({
                title: 'Sucesso!',
                text: 'Dados Alterados com Sucesso!',
                type: 'success',
                timer: '2500'
            });
        }
        function errorNome() {
            swal({
                title: 'Erro!',
                text: 'Favor Preencher o Nome do Usuário!',
                type: 'error',
                timer: '2000'
            });
        }
        function erroLogin() {
            swal({
                title: 'Erro!',
                text: 'Favor Preencher o Login do Usuário!',
                type: 'error'
            });
        }
        function errorSenha() {
            swal({
                title: 'Erro!',
                text: 'Favor Preencher o Campo Senha!',
                type: 'error'
            });
        }
        function errorConfirmarSenha() {
            swal({
                title: 'Erro!',
                text: 'Favor Confirmar Senha!',
                type: 'error'
            });
        }
        function errorSenhaIguais() {
            swal({
                title: 'Erro!',
                text: 'As Senhas digitadas não estão iguais, Favor verificar!',
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
</asp:Content>

