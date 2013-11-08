<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TipoSerieCategoria.aspx.cs" Inherits="SAcademia.Web.Cadastros.TipoSerieCategoria" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Vincular Categorias a um Tipo de Série</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados da Categoria</h3>
            <div class="row-936">
                    <div class="bg-tabela">  
                        <asp:GridView ID="gvConsulta" runat="server" CssClass="tabela tabCad" 
                            AutoGenerateColumns="True" EmptyDataText="Não existem categorias cadastradas">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbCategoria" runat="server"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Descricao"  HeaderText="Descrição Categoria" />
                            </Columns>
                        </asp:GridView>                          
                    </div>
            </div>       
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" 
                    Text="Voltar" onclick="btnVoltar_Click" />
            </div>
        </div>
    </div>   
</asp:Content>

