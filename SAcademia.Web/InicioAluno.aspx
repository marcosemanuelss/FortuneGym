<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InicioAluno.aspx.cs" Inherits="SAcademia.Web.InicioAluno" %>
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
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Ficha</h2>
            </div>            
            <div class="bg-tabela-peq">
                 <asp:GridView ID="gvFichaAtual" CssClass="tabela-peq" runat="server">
                        <Columns> 
                        <asp:BoundField DataField="Objetivo" HeaderText="Objetivo" />
                        <asp:TemplateField HeaderText="Ação">  
                            <ItemTemplate> 
                                <asp:ImageButton ID="btnAcao" runat="server" ImageUrl="../img/icon-irpara.png" CommandName="Acao" Text="Ação" CommandArgument='<%#Eval("Codigo") %>' /> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                    </Columns>
                 </asp:GridView>
            </div>
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Fichas Anteriores</h2>
            </div>            
            <div class="bg-tabela-peq">
                 <asp:GridView ID="gvFichasAnteriores" CssClass="tabela-peq" runat="server">
                        <Columns> 
                        <asp:BoundField DataField="Data" HeaderText="Data de Vencimento" /> 
                        <asp:BoundField DataField="Objetivo" HeaderText="Objetivo" />
                        <asp:TemplateField HeaderText="Ação">  
                            <ItemTemplate> 
                                <asp:ImageButton ID="btnAcao" runat="server" ImageUrl="../img/icon-irpara.png" CommandName="Acao" Text="Ação" CommandArgument='<%#Eval("Codigo") %>' /> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                    </Columns>
                 </asp:GridView>
            </div>
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Sugestões de Suplementos</h2>
            </div>            
            <div class="lbrow-936">
                 <asp:TextBox ID="txtSuplemento" TextMode="MultiLine" ToolTip="Suplementos" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
</asp:Content>
