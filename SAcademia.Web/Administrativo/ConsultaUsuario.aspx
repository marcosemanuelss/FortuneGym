<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaUsuario.aspx.cs" Inherits="SAcademia.Web.Administrativo.ConsultaUsuario" %>
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
                <h2>Usuários do Sistema</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite um nome ou cpf para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" 
                        Text="Pesquisar" Cssclass="buttons" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" 
                        Text="Limpar" onclick="btnLimpar_Click"/>
                </div>
                <asp:GridView ID="gvConsulta" AutoGenerateColumns="False" CssClass="tabela" runat="server" DataKeyNames="Codigo">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Login" HeaderText="Login" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:TemplateField HeaderText="Academia">
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="imgAcademia" CommandName="Academia" CommandArgument='<%# Eval("Codigo") %>' ImageUrl="~/img/icon-academia.png" ToolTip="Academia" runat="server" />
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Situação" DataField="Situcacao"/>
                        <asp:TemplateField HeaderText="Ação">
                            <ItemTemplate>
                                <asp:ImageButton ID="bloqueioImageButton" runat="server" ToolTip="Bloquear usuário" 
                                    OnClientClick="return mostraPopUpAlert('Confirma o bloqueio deste usuário?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Bloquear" ImageUrl="~\img\icon-bloqueado.png"
                                    CommandArgument='<%# Container.DataItemIndex %>'/>
                                <asp:ImageButton ID="desbloqueioImageButton" runat="server" ToolTip="Desbloquear usuário" 
                                    OnClientClick="return mostraPopUpAlert('Confirma o desbloqueio deste usuário?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Desbloquear" ImageUrl="~\img\icon-desbloqueado.png"
                                    CommandArgument='<%# Container.DataItemIndex %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Resetar Senha">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageResetar" runat="server"
                                    ImageUrl="~\img\icon-resetar.png"
                                    OnClientClick="return mostraPopUpAlert('Deseja resetar a senha deste usuário?','../img/icon-question.png',true,this.id);"
                                    ToolTip="Resetar Senha" CommandName="Senha" CommandArgument='<%# Container.DataItemIndex + "|" + Eval("Login")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageEditar" runat="server" ImageUrl="~\img\icon-editar.png"
                                    ToolTip="Editar Usuário" CommandName="Editar" CommandArgument='<%# Container.DataItemIndex %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageExcluir" runat="server" ImageUrl="~\img\icon-excluir.png" 
                                    OnClientClick="return mostraPopUpAlert('Confirma a exclusão deste usuário do sistema?','../img/icon-question.png',true,this.id);" 
                                    ToolTip="Excluir Usuário" CommandName="Excluir" CommandArgument='<%# Container.DataItemIndex %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="btnsConsulta">
                    <asp:Button ID="btnNovo" ToolTip="Novo" runat="server" Text="Novo" 
                        Cssclass="buttons" onclick="btnNovo_Click"/>
                    <asp:Button ID="btnVoltar" ToolTip="Voltar" Cssclass="buttons" runat="server" 
                        Text="Voltar" onclick="btnVoltar_Click"/>
                </div>
            </div>
        </div>
</asp:Content>
