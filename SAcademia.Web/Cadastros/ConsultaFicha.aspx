<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaFicha.aspx.cs" Inherits="SAcademia.Web.Cadastros.ConsultaFicha" %>
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
                <h2>Consulta de Fichas</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite um usuário ou código da ficha para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" 
                        Text="Pesquisar" Cssclass="buttons" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" 
                        Text="Limpar" onclick="btnLimpar_Click"/>
                </div>
                <asp:GridView ID="gvConsulta" AutoGenerateColumns="False" CssClass="tabela" 
                    runat="server" DataKeyNames="Codigo" onrowcommand="gvConsulta_RowCommand">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="idUsuario" HeaderText="Usuário" />
                        <asp:BoundField HeaderText="Situação" DataField="Situcacao"/>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageEditar" runat="server" ImageUrl="~\img\icon-editar.png"
                                    ToolTip="Editar Ficha" CommandName="Editar" CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bloquear">
                            <ItemTemplate>
                                <asp:ImageButton ID="bloqueioImageButton" runat="server" ToolTip="Bloquear ficha" 
                                    OnClientClick="return mostraPopUpAlert('Confirma o bloqueio desta ficha?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Bloquear" ImageUrl="~\img\icon-bloqueado.png"
                                    CommandArgument='<%# Eval("Codigo") %>'/>
                                <asp:ImageButton ID="desbloqueioImageButton" runat="server" ToolTip="Desbloquear ficha" 
                                    OnClientClick="return mostraPopUpAlert('Confirma o desbloqueio desta ficha?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Desbloquear" ImageUrl="~\img\icon-desbloqueado.png"
                                    CommandArgument='<%# Eval("Codigo") %>'/>
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
