<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaTipoSerie.aspx.cs" Inherits="SAcademia.Web.Cadastros.ConsultaTipoSerie" %>
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
                <h2>Tipo de Séries</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite um tipo de série para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" 
                        Text="Pesquisar" Cssclass="buttons" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" 
                        Text="Limpar" onclick="btnLimpar_Click"/>
                </div>
                <asp:GridView ID="gvConsulta" CssClass="tabela" runat="server"  
                    AutoGenerateColumns="False" DataKeyNames="Codigo" 
                    onrowcommand="gvConsulta_RowCommand" EmptyDataText="Nenhum Dado encontrado">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:TemplateField HeaderText="Vincular Categoria">
                            <ItemTemplate>
                                <asp:ImageButton ID="VincularCatEditar" runat="server" ImageUrl="~\img\icon-vincular.png"
                                    ToolTip="Vincular Categoria" CommandName="Vincular Categoria" CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageEditar" runat="server" ImageUrl="~\img\icon-editar.png"
                                    ToolTip="Editar" CommandName="Editar" CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="excluirImageButton" runat="server" ToolTip="Excluir" 
                                    OnClientClick="return mostraPopUpAlert('Confirma a exclusão desta série?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Excluir" ImageUrl="~\img\icon-excluir.png"
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
