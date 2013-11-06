<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastroFicha.aspx.cs" Inherits="SAcademia.Web.Cadastros.CadastroFicha" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Cadastro/Alteração de Ficha</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados da Ficha</h3>
            <div class="lbrow-936">
                <label>
                    Objetivo:</label>
                <asp:TextBox ID="txtObjetivo" TextMode="MultiLine" runat="server" ReadOnly="True" ToolTip="Objetivo" />
            </div>  
            <div class="row-936">
                <label>
                    Série*:</label>
                <asp:DropDownList ID="dpSerie" Cssclass="required" runat="server">
                    <asp:ListItem Text="Selecione" Value="" />
                    <asp:ListItem Text="Teste" Value="Teste" />
                </asp:DropDownList>
            </div> 
            <div class="row-936">
                <label>Séries Disponíveis:</label>
                <asp:GridView ID="gvSeries" runat="server" CssClass="tabela" 
                    AutoGenerateColumns="False" EmptyDataText="Não existem parcelas" 
                    onrowdatabound="gvHistoricoParcelas_RowDataBound" 
                    onpageindexchanging="gvHistoricoParcelas_PageIndexChanging" PageSize="10" 
                    AllowPaging="True" onrowcommand="gvHistoricoParcelas_RowCommand" >
                    <Columns>

                    </Columns>
                </asp:GridView>
            </div>         
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" Text="Voltar" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>   
</asp:Content>
