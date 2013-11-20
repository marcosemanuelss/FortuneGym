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
                <asp:DropDownList ID="dpSerie" Cssclass="required" runat="server" 
                    AutoPostBack="True">
                    <asp:ListItem Text="Selecione" Value="" />
                    <asp:ListItem Text="Teste" Value="Teste" />
                </asp:DropDownList>
            </div> 
            <div class="div-936">
                <div class="tableSerie">
                    <label>Exercícios Disponíveis:</label>
                    <asp:GridView ID="gvSeries" runat="server" CssClass="tabela" 
                        AutoGenerateColumns="True" EmptyDataText="Não existem séries cadastradas">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-CssClass="ckbox">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbExercicio" runat="server"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Exercicio"  HeaderText="Exercício" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnAdicionarExercicios" CssClass="buttons" runat="server" Text="Adicionar Exercícios" ToolTip="Adicionar Exercícios" />
                </div>
            </div>    
            <div class="div-936">
                <asp:GridView ID="gvExerciciosAdicionados" runat="server" CssClass="tabela" 
                    AutoGenerateColumns="True" EmptyDataText="Não existem exercícios adicionados">
                    <Columns>
                        <asp:BoundField DataField="Exercicio"  HeaderText="Exercício" />
                        <asp:TemplateField HeaderText="Repetições">
                            <ItemTemplate>
                                <asp:DropDownList ID="dpRepeticao" CssClass="dropInput" Width="140px" Height="20px" runat="server" >
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remover">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgRemoverItem" ToolTip="Remover Exercício" runat="server"
                                    ImageUrl="~/img/icon-excluir.png" CommandName="Remover" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>     
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" Text="Voltar" />
                <asp:Button ID="btnFichasAnteriores" ToolTip="Anteriores" CssClass="buttons" runat="server" Text="Anteriores" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>   
    <script type="text/javascript">
        $(document).ready(function () {
            var val = $("#MainContent_dpSerie option:selected").val(); //pega  valor do select
            if (val == "") {
                $(".tableSerie").hide(); //esconde a div tabela serie
            } else {
                $(".tableSerie").show(); //mostra a div tempo de avaliação
            }
        });
        $("#MainContent_dpSerie").change(function () { // bind a function to the change event
            var val = $("#MainContent_dpSerie option:selected").val(); //pega  valor do select
            if (val == "") {
                $(".tableSerie").hide(); //esconde a div tabela serie
            } else {
                $(".tableSerie").show(); //mostra a div tempo de avaliação
            }
        });
        </script>
</asp:Content>
