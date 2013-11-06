<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaAcademia.aspx.cs" Inherits="SAcademia.Web.Administrativo.ConsultaAcademia" %>
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
                <h2>Listagem de Academias</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite um nome para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" 
                        Text="Pesquisar" Cssclass="buttons" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" Text="Limpar"/>
                </div>
                <asp:GridView ID="gvConsulta" CssClass="tabela" runat="server" 
                    AutoGenerateColumns="False" EmptyDataText="Nenhum Dado encontrado" 
                    onrowcommand="gvConsulta_RowCommand" 
                    onrowdatabound="gvConsulta_RowDataBound">
                    <Columns> 
                        <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" /> 
                        <asp:BoundField DataField="Nome" HeaderText="Nome" /> 
                        <asp:BoundField DataField="Ativo" HeaderText="Situação" />
                        <asp:TemplateField HeaderText="Parâmetros"> 
                            <ItemTemplate> 
                                <asp:ImageButton ID="btnParametros" runat="server" ImageUrl="../img/icon-parametro.png" CommandName="Parametros" CommandArgument='<%#Eval("Codigo") %>' /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar"> 
                            <ItemTemplate> 
                                <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="../img/icon-editar.png" CommandName="Editar" Text="Editar" CommandArgument='<%#Eval("Codigo") %>' /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ação">  
                            <ItemTemplate> 
                                <asp:ImageButton ID="btnBloquear" runat="server" ImageUrl="../img/icon-bloqueado.png" CommandName="Bloquear" CommandArgument='<%#Eval("Codigo") %>' 
                                    OnClientClick="return mostraPopUpAlert('Confirma o bloqueio desta academia?','../img/icon-question.png',true,this.id);" /> 
                                <asp:ImageButton ID="btnDesbloquear" runat="server" ImageUrl="../img/icon-desbloqueado.png" CommandName="Desbloquear" CommandArgument='<%#Eval("Codigo") %>' 
                                     OnClientClick="return mostraPopUpAlert('Confirma o desbloqueio desta academia?','../img/icon-question.png',true,this.id);" /> 
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
