<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaAnexoAviso.aspx.cs" Inherits="SFF.Web.Cadastros.ConsultaAnexoAviso" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Anexos</h2>
            </div>
            <div class="bg-tabela">
                <asp:GridView ID="gvConsulta" AutoGenerateColumns="false" CssClass="tabela tabCad" 
                    runat="server" EmptyDataText="Nenhum Dado encontrado">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageDownload" runat="server" ImageUrl="~\img\icon-download.png"
                                    ToolTip="Download" CommandName="Download" CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="excluirImageButton" runat="server" ToolTip="Excluir aviso" 
                                    OnClientClick="return mostraPopUpAlert('Confirma a exclusão desse anexo?','../img/icon-question.png',true,this.id);" 
                                    CommandName="Excluir" ImageUrl="~\img\icon-excluir.png"
                                    CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="btnsConsulta">
                    <asp:Button ID="btnVoltar" ToolTip="Voltar" Cssclass="buttons" runat="server" 
                        Text="Voltar"/>
                </div>
            </div>
        </div>
</asp:Content>
