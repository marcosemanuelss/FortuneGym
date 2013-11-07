<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InicioInstrutor.aspx.cs" Inherits="SAcademia.Web.InicioInstrutor" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(document).ready(function () {
            //Hide (Collapse) the toggle containers on load
            $(".togglebox").hide();

            //Slide up and down on hover
            $(".efeito").click(function () {
                $('.togglebox').slideUp("slow");
                $(this).next(".togglebox").slideDown("slow");
                return false;
            });
            //mostra uma mensagem no balão ao colocar mouse em cima do h2
            $(document).ready(function () {
                $(".efeito").easyTooltip();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="box">
                <div class="seta-right"></div>
                <h2 class="efeito" title="Clique aqui para visualizar">Avisos</h2>
                <div class="togglebox">
	                <div class="bg-tabela-peq">
                         <asp:GridView ID="gvAvisos" CssClass="tabela-peq" AutoGenerateColumns="False" runat="server">
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
            </div>

            <div class="box">
                <div class="seta-right"></div>
                <h2 class="efeito" title="Clique aqui para visualizar">Fichas</h2>           
                <div class="togglebox">
                    <div class="bg-tabela-peq">
                         <asp:GridView ID="gvFichas" CssClass="tabela-peq" AutoGenerateColumns="False" runat="server">
                                <Columns> 
                                    <asp:BoundField DataField="Data" HeaderText="Data de Vencimento" /> 
                                    <asp:BoundField DataField="Aluno" HeaderText="Aluno" /> 
                                    <asp:BoundField DataField="Objetivo" HeaderText="Objetivo" />
                                    <asp:TemplateField HeaderText="Ação">  
                                        <ItemTemplate> 
                                            <asp:ImageButton ID="btnAcao" runat="server" ImageUrl="../img/icon-irpara.png" CommandName="Acao" Text="Ação" CommandArgument='<%#Eval("Codigo") %>' /> 
                                        </ItemTemplate> 
                                    </asp:TemplateField> 
                                </Columns>
                         </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
</asp:Content>
