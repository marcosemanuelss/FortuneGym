<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InicioAdmin.aspx.cs" Inherits="SAcademia.Web.InicioAdmin" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Avisos</h2>
            </div>            
            <div class="bg-tabela-peq">
                 <asp:GridView ID="gvAvisos" CssClass="tabela-peq" runat="server">
                        <Columns> 
                        <asp:BoundField DataField="Data" HeaderText="Data" /> 
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" /> 
                        <asp:TemplateField HeaderText="Detalhes">  
                            <ItemTemplate> 
                                <asp:ImageButton ID="btnDetalhes" runat="server" ImageUrl="../img/icon-ver.png" CommandName="Detalhes" Text="Detalhes" CommandArgument='<%#Eval("Codigo") %>' /> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                    </Columns>
                 </asp:GridView>
            </div>
        </div>
</asp:Content>
