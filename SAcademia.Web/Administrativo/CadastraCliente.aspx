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
                    <asp:ListItem Text="Selecione" Value="" />
                    <asp:ListItem Text="Ativo" Value="Ativo" />
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
                <asp:TextBox ID="txtUf" Cssclass="required" runat="server" MaxLength="2" ToolTip="UF" />
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
                                  if (unescape(resultadoCEP["uf"]).toUpperCase() !== '') {

                                      $('#<%=txtBairro.ClientID%>').val(unescape(resultadoCEP["bairro"]));
                                      $('#<%=txtCidade.ClientID%>').val(unescape(resultadoCEP["cidade"]));
                                      $('#<%=txtUf.ClientID%>').val(resultadoCEP["uf"]);
                                      $('#<%=txtEndereco.ClientID%>').val(unescape(resultadoCEP["tipo_logradouro"] + " " + resultadoCEP["logradouro"]));
                                  } else {
                                      mostraPopUpAlert('CEP não encontrado.', '../img/icon-atencao.png', false, '');
                                      $('#<%=txtCep.ClientID%>').val("");
                                      $('#<%=txtBairro.ClientID%>').val("");
                                      $('#<%=txtCidade.ClientID%>').val("");
                                      $('#<%=txtUf.ClientID%>').val("");
                                      $('#<%=txtEndereco.ClientID%>').val("");
                                  }
                              } else {
                                  mostraPopUpAlert('Endereço não encontrado', '../img/icon-atencao.png', false, '');
                              }
                          }
                        );
            }
        }
        // VALIDA DATA DE NASCIMENTO
//       
    </script>
</asp:Content>
