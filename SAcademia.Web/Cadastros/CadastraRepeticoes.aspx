<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastraRepeticoes.aspx.cs" Inherits="SAcademia.Web.Cadastros.CadastraRepeticoes" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Cadastro/Alteração de Repetições</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados da Repetição</h3>
            <div class="row-452">
                <label>
                    Nome*:</label>
                <asp:TextBox ID="txtNome" Cssclass="required" runat="server" ToolTip="Nome" />
            </div> 
            <div class="row-452">
                <label>
                    Tipo de Combinação:</label>
                <asp:RadioButtonList ID="rbtipoCombinacao" CssClass="radio" runat="server">
                    <asp:ListItem Value="S" Selected="True"> Simples</asp:ListItem>
                    <asp:ListItem Value="C"> Combinada</asp:ListItem>
                </asp:RadioButtonList>
            </div>    
            <div class="row-936">
                <div class="simples">
                    <div class="bg-tabela">
                        <div class="row-265">
                            <label>
                                Nº de Vezes*:</label>
                            <asp:TextBox ID="txtNumVezes" Cssclass="required" runat="server" ToolTip="Número de Vezes" />
                        </div>
                        <div class="row-265">
                            <label>
                                Repetição*:</label>
                            <asp:TextBox ID="txtRepeticao" Cssclass="required" runat="server" ToolTip="Repetição" />
                        </div>
                        <div class="row-265">
                            <label>
                                Variação*:</label>
                            <asp:DropDownList ID="dpVariacao" Cssclass="required" runat="server">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="teste" Value="teste" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="combinada">
                    <div class="bg-tabela">
                        <div class="adicione"><a href="javascript:;" onclick="addItem();" title="Adicionar repetição">Adicionar repetição</a></div>
                        <div id="tabela">
                        
                        </div>
                    </div>
                </div>
            </div>       
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" Text="Voltar" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>   
    <script type="text/javascript">
        //EXECUTA QUANDO CARREGA A PÁGINA
        $(document).ready(function () {
            var val = $("input[name='ctl00$MainContent$rbtipoCombinacao']:checked").val(); //pega  valor do radio
            if (val == "S") {
                $(".combinada").hide(); //esconde a div combinada
                $(".simples").show(); //mostra a div simples
                //Atribui o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezes").attr("class", "required");
                $("#MainContent_txtRepeticao").attr("class", "required");
                $("#MainContent_dpVariacao").attr("class", "required");
                //end

            } else {
                $(".simples").hide(); //esconde a div simples
                //Tira o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezes").attr("class", "");
                $("#MainContent_txtRepeticao").attr("class", "");
                $("#MainContent_dpVariacao").attr("class", "");
                //end
                $(".combinada").show(); //mostra a div combinada
            }
        });

        //EXECUTA QUANDO MUDA DE RADIOBUTTON
        $("#MainContent_rbtipoCombinacao").change(function () { // bind a function to the change event
            var val = $("input[name='ctl00$MainContent$rbtipoCombinacao']:checked").val(); //pega  valor do radio
            if (val == "S") {
                $(".combinada").hide(); //esconde a div combinada
                $(".simples").show(); //mostra a div simples
                //Atribui o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezes").attr("class", "required");
                $("#MainContent_txtRepeticao").attr("class", "required");
                $("#MainContent_dpVariacao").attr("class", "required");
                //end
                
            } else {
                $(".simples").hide(); //esconde a div simples
                //Tira o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezes").attr("class", "");
                $("#MainContent_txtRepeticao").attr("class", "");
                $("#MainContent_dpVariacao").attr("class", "");
                //end
                $(".combinada").show(); //mostra a div combinada
            }
        });
    </script>
</asp:Content>
