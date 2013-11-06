<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastraCliente.aspx.cs"
    Inherits="SAcademia.Web.Administrativo.CadastraCliente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            //MÁSCARAS
            $('#MainContent_txtCpf').mask('999.999.999-99');
            $('#MainContent_txtDtNascimento').mask('99/99/9999');
            $('#MainContent_txtCep').mask('99.999-999');
            $('#MainContent_txtTelRes').mask('(99)9999-9999');
            $('#MainContent_txtTelCel').mask('(99)9999-9999?9');
            $('#MainContent_txtMatricula').keypress(verificaNumero);
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Cadastro/Alteração de Cliente</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados do Usuário</h3>
            <div class="row-290">
                <label>
                    Login*:</label>
                <asp:TextBox ID="txtLogin" runat="server" Cssclass="required" ToolTip="login" />
            </div>
            <div class="row-290">
                <label>
                    CPF*:</label>
                <asp:TextBox ID="txtCpf" Cssclass="required" onBlur="if(!validarCPF(this.value)){limpaCampo(this.id); mostraPopUpAlert('CPF inválido! Digite novamente.','../img/icon-erro.png',false,this.id);}"
                    runat="server" ToolTip="CPF" />
            </div>
            <div class="row-290">
                <label>
                    Nome*:</label>
                <asp:TextBox ID="txtNome" Cssclass="required" runat="server" ToolTip="Nome" />
            </div>
            <div class="row-290">
                <label>
                    Situação*:</label>
                <asp:DropDownList ID="dpSituacao" Cssclass="required" runat="server">
                    <asp:ListItem Text="Ativo" Value="Ativo" Selected="True"/>
                    <asp:ListItem Text="Inativo" Value="Inativo" />
                </asp:DropDownList>
            </div>
            <div class="row-290">
                <label>
                    E-mail*:</label>
                <asp:TextBox ID="txtEmail" Cssclass="required mail" runat="server" ToolTip="E-mail" />
            </div>
            <div class="row-290">
                <label>
                    Matrícula*:</label>
                <asp:TextBox ID="txtMatricula" Cssclass="required" runat="server" ToolTip="Matricula" />
            </div>
            <div class="row-452">
                <label>
                    Data de Nascimento*:</label>
                <asp:TextBox ID="txtDtNascimento" Cssclass="required" runat="server" ToolTip="Data de Nascimento" />
            </div>
            <div class="row-452">
                <label>
                    CEP*:</label>
                <asp:TextBox ID="txtCep" Cssclass="required" onBlur="buscaCep(this.value);" runat="server" ToolTip="CEP" />
            </div>
            <div class="row-750">
                <label>
                    Endereço*:</label>
                <asp:TextBox ID="txtEndereco" Cssclass="required" runat="server" ToolTip="Endereço" />
            </div>
            <div class="row-154">
                <label>
                    Número*:</label>
                <asp:TextBox ID="txtNumero" Cssclass="required" runat="server" ToolTip="Número" />
            </div>
            <div class="row-290">
                <label>
                    Complemento:</label>
                <asp:TextBox ID="txtComplemento" runat="server" ToolTip="Complemento" />
            </div>
            <div class="row-290">
                <label>
                    Bairro*:</label>
                <asp:TextBox ID="txtBairro" Cssclass="required" runat="server" ToolTip="Bairro" />
            </div>
            <div class="row-290">
                <label>
                    Cidade*:</label>
                <asp:TextBox ID="txtCidade" Cssclass="required" runat="server" ToolTip="Cidade" />
            </div>
            <div class="row-290">
                <label>
                    UF*:</label>
                <asp:DropDownList ID="dpUf" runat="server">
                    	<asp:ListItem Value="Selecione">Selecione</asp:ListItem>
                        <asp:ListItem value="AC">Acre</asp:ListItem>
                        <asp:ListItem value="AL">Alagoas</asp:ListItem>
                        <asp:ListItem value="AP">Amapá</asp:ListItem>
                        <asp:ListItem value="AM">Amazonas</asp:ListItem>
                        <asp:ListItem value="BA">Bahia</asp:ListItem>
                        <asp:ListItem value="CE">Ceará</asp:ListItem>
                        <asp:ListItem value="DF">Distrito Federal</asp:ListItem>
                        <asp:ListItem value="ES">Espirito Santo</asp:ListItem>
                        <asp:ListItem value="GO">Goiás</asp:ListItem>
                        <asp:ListItem value="MA">Maranhão</asp:ListItem>
                        <asp:ListItem value="MT">Mato Grosso</asp:ListItem>
                        <asp:ListItem value="MS">Mato Grosso do Sul</asp:ListItem>
                        <asp:ListItem value="MG">Minas Gerais</asp:ListItem>
                        <asp:ListItem value="PA">Pará</asp:ListItem>
                        <asp:ListItem value="PB">Paraiba</asp:ListItem>
                        <asp:ListItem value="PR">Paraná</asp:ListItem>
                        <asp:ListItem value="PE">Pernambuco</asp:ListItem>
                        <asp:ListItem value="PI">Piauí</asp:ListItem>
                        <asp:ListItem value="RJ">Rio de Janeiro</asp:ListItem>
                        <asp:ListItem value="RN">Rio Grande do Norte</asp:ListItem>
                        <asp:ListItem value="RS">Rio Grande do Sul</asp:ListItem>
                        <asp:ListItem value="RO">Rondônia</asp:ListItem>
                        <asp:ListItem value="RR">Roraima</asp:ListItem>
                        <asp:ListItem value="SC">Santa Catarina</asp:ListItem>
                        <asp:ListItem value="SP">São Paulo</asp:ListItem>
                        <asp:ListItem value="SE">Sergipe</asp:ListItem>
                        <asp:ListItem value="TO">Tocantis</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="row-290">
                <label>
                    Telefone Residencial*:</label>
                <asp:TextBox ID="txtTelRes" Cssclass="required" runat="server" ToolTip="Telefone Residencial" />
            </div>
            <div class="row-290">
                <label>
                    Telefone Celular:</label>
                <asp:TextBox ID="txtTelCel" runat="server" ToolTip="Telefone Celular" />
            </div>
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" onclick="btnSalvar_Click" />
                <asp:Button ID="btnVoltar" onclick="btnVoltar_Click" ToolTip="Voltar" CssClass="buttons" runat="server" Text="Voltar" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>
    <script type="text/javascript">
        //FUNÇÃO BUSCA CEP
        function buscaCep(cep) {
            if ($.trim(cep) !== "") {
                $.getScript(
                          "http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + cep,
                          function () {
                              if (resultadoCEP["resultado"]) {
                                  $('#<%=txtBairro.ClientID%>').val(unescape(resultadoCEP["bairro"]));
                                  $('#<%=txtCidade.ClientID%>').val(unescape(resultadoCEP["cidade"]));
                                  $('#<%=dpUf.ClientID%>').val(unescape(resultadoCEP["uf"]));
                                  $('#<%=txtEndereco.ClientID%>').val(unescape(resultadoCEP["tipo_logradouro"] + " " + resultadoCEP["logradouro"]));
                              } else {
                                  mostraPopUpAlert('Endereço não encontrado', '../img/icon-atencao.png', false, '');
                              }
                          }
                        );
            }
        }
    </script>
</asp:Content>
