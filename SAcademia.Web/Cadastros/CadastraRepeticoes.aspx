<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastraRepeticoes.aspx.cs" Inherits="SAcademia.Web.Cadastros.CadastraRepeticoes" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            $('#MainContent_txtNumVezesSimples').keypress(verificaNumero);
            $('#MainContent_txtRepetSimples').keypress(verificaNumero);
            $('#MainContent_txtNumVezesCombinada').keypress(verificaNumero);
            $('#MainContent_txtRepetCombinada').keypress(verificaNumero);
        });
    </script>
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
                            <asp:TextBox ID="txtNumVezesSimples" Cssclass="required" runat="server" ToolTip="Número de Vezes" />
                        </div>
                        <div class="row-265">
                            <label>
                                Repetição*:</label>
                            <asp:TextBox ID="txtRepetSimples" Cssclass="required" runat="server" ToolTip="Repetição" />
                        </div>
                        <div class="row-265">
                            <label>
                                Variação*:</label>
                            <asp:DropDownList ID="dpVariacaoSimples" Cssclass="required" runat="server">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="teste" Value="teste" />
                            </asp:DropDownList>
                        </div>
                        
                    </div>
                </div>
                <div class="combinada">
                    <div class="bg-tabela">
                        <div class="row-265">
                            <label>
                                Nº de Vezes*:</label>
                            <asp:TextBox ID="txtNumVezesCombinada" Cssclass="required" runat="server" ToolTip="Número de Vezes" />
                        </div>
                        <div class="row-265">
                            <label>
                                Repetição*:</label>
                            <asp:TextBox ID="txtRepetCombinada" Cssclass="required" runat="server" ToolTip="Repetição" />
                        </div>
                        <div class="row-265">
                            <label>
                                Variação*:</label>
                            <asp:DropDownList ID="dpVariacaoCombinada" Cssclass="required" runat="server">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="teste" Value="teste" />
                            </asp:DropDownList>
                        </div>           
                        <asp:Button ID="btnAdicionar" CssClass="buttons" runat="server" Text="Adicionar Combinação" ToolTip="Adicionar Combinação" />      
                        <asp:GridView ID="gvCombinada" runat="server" CssClass="tabela" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="QtdVezes"  HeaderText="Número de Vezes" />
                                <asp:BoundField DataField="QtdRepeticao"  HeaderText="Repetição" />
                                <asp:BoundField DataField="Variacao"  HeaderText="Variação" />
                                <asp:TemplateField HeaderText="Remover">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageRemover" runat="server" ImageUrl="~\img\icon-excluir.png"
                                            ToolTip="Remover Repetição" CommandName="Remover" CommandArgument='<%# Eval("Codigo") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>                               
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
                //Tira o campo obrigatorio para os campos da div combinada
                $("#MainContent_txtNumVezesCombinada").attr("class", "");
                $("#MainContent_txtRepetCombinada").attr("class", "");
                $("#MainContent_dpVariacaoCombinada").attr("class", "");
                //limpa campos
                $("#MainContent_txtNumVezesCombinada").val("");
                $("#MainContent_txtRepetCombinada").val("");
                $("#MainContent_dpVariacaoCombinada").val("");
                //END
                $(".simples").show(); //mostra a div simples
                //Atribui o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezesSimples").attr("class", "required");
                $("#MainContent_txtRepetSimples").attr("class", "required");
                $("#MainContent_dpVariacaoSimples").attr("class", "required");
                //end

            } else {
                $(".simples").hide(); //esconde a div simples
                //Tira o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezesSimples").attr("class", "");
                $("#MainContent_txtRepetSimples").attr("class", "");
                $("#MainContent_dpVariacaoSimples").attr("class", "");
                //limpa campos
                $("#MainContent_txtNumVezesSimples").val("");
                $("#MainContent_txtRepetSimples").val("");
                $("#MainContent_dpVariacaoSimples").val("");
                //end
                $(".combinada").show(); //mostra a div combinada
                //Atribui o campo obrigatorio para os campos da div combinada
                $("#MainContent_txtNumVezesCombinada").attr("class", "required");
                $("#MainContent_txtRepetCombinada").attr("class", "required");
                $("#MainContent_dpVariacaoCombinada").attr("class", "required")
            }
        });

        //EXECUTA QUANDO MUDA DE RADIOBUTTON
        $("#MainContent_rbtipoCombinacao").change(function () { // bind a function to the change event
            var val = $("input[name='ctl00$MainContent$rbtipoCombinacao']:checked").val(); //pega  valor do radio
            if (val == "S") {
                $(".combinada").hide(); //esconde a div combinada
                //Tira o campo obrigatorio para os campos da div combinada
                    $("#MainContent_txtNumVezesCombinada").attr("class", "");
                    $("#MainContent_txtRepetCombinada").attr("class", "");
                    $("#MainContent_dpVariacaoCombinada").attr("class", "");
                    //limpa campos
                    $("#MainContent_txtNumVezesCombinada").val("");
                    $("#MainContent_txtRepetCombinada").val("");
                    $("#MainContent_dpVariacaoCombinada").val("");
                //END
                $(".simples").show(); //mostra a div simples
                //Atribui o campo obrigatorio para os campos da div simples
                $("#MainContent_txtNumVezesSimples").attr("class", "required");
                $("#MainContent_txtRepetSimples").attr("class", "required");
                $("#MainContent_dpVariacaoSimples").attr("class", "required");
                //end

            } else {
                $(".simples").hide(); //esconde a div simples
                //Tira o campo obrigatorio para os campos da div simples
                    $("#MainContent_txtNumVezesSimples").attr("class", "");
                    $("#MainContent_txtRepetSimples").attr("class", "");
                    $("#MainContent_dpVariacaoSimples").attr("class", "");
                    //limpa campos
                    $("#MainContent_txtNumVezesSimples").val("");
                    $("#MainContent_txtRepetSimples").val("");
                    $("#MainContent_dpVariacaoSimples").val("");
                //end
                $(".combinada").show(); //mostra a div combinada
                //Atribui o campo obrigatorio para os campos da div combinada
                $("#MainContent_txtNumVezesCombinada").attr("class", "required");
                $("#MainContent_txtRepetCombinada").attr("class", "required");
                $("#MainContent_dpVariacaoCombinada").attr("class", "required")
            }
        });
    </script>
</asp:Content>
