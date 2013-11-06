<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaCliente.aspx.cs" Inherits="SAcademia.Web.Administrativo.ConsultaCliente" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
    $(function () {
        window.onload = function () {
            document.getElementById('MainContent_txtPesquisa').onkeypress = function (e) {
                doClick('MainContent_btnPesquisar', e);
            };
        };
    });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Clientes do Sistema</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite um nome ou cpf ou matrícula para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" 
                        Text="Pesquisar" Cssclass="buttons" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" 
                        Text="Limpar" onclick="btnLimpar_Click"/>
                </div>
                <asp:GridView ID="gvConsulta" CssClass="tabela" runat="server" DataKeyNames="Codigo" AutoGenerateColumns="False">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Login" HeaderText="Login" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:BoundField DataField="CPF" HeaderText="CPF" />                        
                        <asp:BoundField HeaderText="Situação" DataField="Situcacao"/>
                        <asp:TemplateField HeaderText="Redefinir Senha">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageResetar" runat="server"
                                    ImageUrl="~\img\icon-resetar.png"
                                    OnClientClick="return mostraPopUpAlert('Deseja resetar a senha deste usuário?','../img/icon-question.png',true,this.id);"
                                    ToolTip="Resetar Senha" CommandName="Senha" CommandArgument='<%# Eval("Codigo")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageEditar" runat="server" ImageUrl="~\img\icon-editar.png"
                                    ToolTip="Editar Usuário" CommandName="Editar" CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bloquear">
                            <ItemTemplate>
                                <asp:ImageButton ID="bloqueioImageButton" runat="server" ToolTip="Bloquear aluno" 
                                    OnClientClick="return mostraPopUpAlert('Confirma o bloqueio deste aluno?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Bloquear" ImageUrl="~\img\icon-bloqueado.png"
                                    CommandArgument='<%# Eval("Codigo") %>'/>
                                <asp:ImageButton ID="desbloqueioImageButton" runat="server" ToolTip="Desbloquear aluno" 
                                    OnClientClick="return mostraPopUpAlert('Confirma o desbloqueio deste aluno?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Desbloquear" ImageUrl="~\img\icon-desbloqueado.png"
                                    CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="btnsConsulta">
                    <asp:Button ID="btnNovo" onclick="btnNovo_Click" ToolTip="Novo" runat="server" Text="Novo" Cssclass="buttons"/>
                    <asp:Button ID="btnVoltar" onclick="btnVoltar_Click" ToolTip="Voltar" Cssclass="buttons" runat="server" Text="Voltar"/>
                </div>
            </div>
        </div>
</asp:Content>
