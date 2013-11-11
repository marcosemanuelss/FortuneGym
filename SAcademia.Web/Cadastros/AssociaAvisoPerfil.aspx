<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AssociaAvisoPerfil.aspx.cs" Inherits="SFF.Web.Cadastros.AssociaAvisoPerfil" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Associar Perfis a um Aviso</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados de Perfil</h3>
            <div class="row-936">
                    <div class="bg-tabela">  
                        <asp:GridView ID="gvConsulta" runat="server" CssClass="tabela tabCad" 
                            AutoGenerateColumns="False" EmptyDataText="Não existem perfis cadastrados">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbPerfil" runat="server"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Descricao"  HeaderText="Descrição Perfil" />
                            </Columns>
                        </asp:GridView>                          
                    </div>
            </div>       
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" 
                    Text="Voltar" onclick="btnVoltar_Click" />
            </div>
        </div>
    </div>   
</asp:Content>
