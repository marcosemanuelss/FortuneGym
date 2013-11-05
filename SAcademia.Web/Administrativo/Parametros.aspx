<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Parametros.aspx.cs" Inherits="SAcademia.Web.Administrativo.Parametros" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Parâmetros da Academia</h2>
            </div>
            <div class="bg-tabela">
                <h3>Dados dos Parâmetros</h3>
                <div class="row-290">
                    <label>Tempo de Duração da Ficha (meses)*:</label>
                    <asp:TextBox ID="txtTempoFicha" runat="server" CssClass="required" ToolTip="Tempo de Avaliação" />
                </div>
                <div class="row-290">
                    <label>Possui Avaliação?*</label>
                    <asp:RadioButtonList ID="rblistAvaliacao" CssClass="radio" runat="server">
                        <asp:ListItem Value="True" >Sim</asp:ListItem>
                        <asp:ListItem Value="False">Não</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="row-290">
                    <label>Tempo de Avaliação*:</label>
                    <asp:TextBox ID="txtTempoAvaliacao" runat="server" CssClass="required" ToolTip="Tempo de Avaliação" />
                </div>
                <div class="row-290">
                    <label>Cor:</label>
                    <asp:TextBox ID="txtCor" runat="server" ToolTip="cor"/>
                </div>                                
                <div class="btnsCadastro">
                    <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                        runat="server" Text="Salvar" Cssclass="buttons" onclick="btnSalvar_Click"/>
                    <asp:Button ID="btnVoltar" ToolTip="Voltar" Cssclass="buttons" runat="server" 
                        Text="Voltar" onclick="btnVoltar_Click"/>
                </div>
                <span class="campObrigatorio">(*) Campo Obrigatório</span>
            </div>
        </div>
</asp:Content>

