<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastraAviso.aspx.cs" Inherits="SAcademia.Web.Cadastros.CadastraAviso" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Cadastro/Alteração de Avisos</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados do Aviso</h3>
            <div class="row-936">
                <label>
                    Título*:</label>
                <asp:TextBox ID="txtTitulo" Cssclass="required" runat="server" ToolTip="Título" />
            </div>
            <div class="row-936">
                <label>
                    Descrição*:</label>
                <asp:TextBox ID="txtDescricao" TextMode="MultiLine" Cssclass="required" runat="server" ToolTip="Descrição" />
            </div>  
            <div class="row-936-btn">
                <label>
                    Associar Perfis de Visualização:</label>
                <asp:DropDownList ID="dpAssociarPerfil" runat="server">
                    <asp:ListItem Text="Selecione" Value="" />
                </asp:DropDownList>
                <asp:Button ID="btnAdicionarPerfil" CssClass="buttons" runat="server" 
                    Text="Adicionar Perfil" ToolTip="Adicionar Perfil" 
                    onclick="btnAdicionarPerfil_Click" />  
                <div class="bg-tabela">
                    <asp:GridView ID="gvPerfisAdd" runat="server" CssClass="tabela tabCad" 
                        AutoGenerateColumns="False" onrowcommand="gvPerfisAdd_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Descricao"  HeaderText="Perfil" />
                            <asp:TemplateField HeaderText="Remover">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageRemover" runat="server" ImageUrl="~\img\icon-excluir.png"
                                        ToolTip="Remover Perfil" CommandName="Remover" CommandArgument='<%# Eval("CodigoTipoUsuario") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>               
            </div>  
            <div class="row-936-btn">
                <label>
                    Anexar Arquivo:</label>
                <input id="fakeupload" name="fakeupload" class="fakeupload" type="text" />
                <asp:FileUpload ID="FUpload" CssClass="realupload" runat="server" onchange="this.form.fakeupload.value = this.value;limitaCaracterArquivo(this.form.fakeupload.value);" />
                <asp:Button ID="btnAdicionarAnexo" CssClass="buttons" runat="server" 
                    Text="Adicionar Anexo" ToolTip="Adicionar Anexo" 
                    onclick="btnAdicionarAnexo_Click" />  
                <div class="bg-tabela">
                    <asp:GridView ID="gvAnexos" runat="server" CssClass="tabela tabCad" 
                        AutoGenerateColumns="False" onrowcommand="gvAnexos_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Descricao"  HeaderText="Título" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageDownload" runat="server" ImageUrl="~\img\icon-download.png"
                                        ToolTip="Download" CommandName="Download" CommandArgument='<%# Eval("Codigo") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remover">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageRemover" runat="server" ImageUrl="~\img\icon-excluir.png"
                                        ToolTip="Remover Anexo" CommandName="Remover" CommandArgument='<%# Eval("Codigo") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>               
            </div>          
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" 
                    onclick="btnSalvar_Click" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" 
                    Text="Voltar" onclick="btnVoltar_Click" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>   
</asp:Content>
