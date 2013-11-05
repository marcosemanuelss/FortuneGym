<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastraAcademia.aspx.cs"
    Inherits="SAcademia.Web.Administrativo.CadastraAcademia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            //MÁSCARAS
            $('#MainContent_txtCnpj').mask('99.999.999/9999-99');
            $('#MainContent_txtTelefone').mask('(99)9999-9999');
            $('#MainContent_txtCep').mask('99.999-999');
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Cadastro/Alteração de Academia</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados da Academia</h3>
            <img id="ImagemAcademia" alt="" src="" runat="server" />
            <asp:HiddenField ID="hddCodigoAcademia" runat="server"/>
            <div class="row-290">
                <label>
                    CNPJ*:</label>
                <asp:TextBox ID="txtCnpj" CssClass="required" runat="server" ToolTip="CNPJ" OnBlur="if(!validarCNPJ(this.value)){ mostraPopUpAlert('CNPJ inválido.', '../img/icon-atencao.png',false,''); this.value = '';}" />
            </div>
            <div class="row-290">
                <label>
                    Nome*:</label>
                <asp:TextBox ID="txtNome" CssClass="required" runat="server" ToolTip="Nome" />
            </div>
            <div class="row-290">
                <label>
                    Imagem (Logomarca):</label>
                <input id="fakeupload" name="fakeupload" class="fakeupload" type="text" />
                <asp:FileUpload ID="FUpload" CssClass="realupload" runat="server" onchange="this.form.fakeupload.value = this.value;limitaCaracterArquivo(this.form.fakeupload.value);" />
            </div>
            <div class="row-452">
                <label>
                    E-mail*:</label>
                <asp:TextBox ID="txtEmail" CssClass="required" runat="server" ToolTip="E-mail" />
            </div>
            <div class="row-452">
                <label>
                    CEP*:</label>
                <asp:TextBox ID="txtCep" CssClass="required" runat="server"
                    ToolTip="CEP" />
            </div>
            <div class="row-750">
                <label>
                    Endereço*:</label>
                <asp:TextBox ID="txtEndereco" CssClass="required" runat="server" ToolTip="Endereço" />
            </div>
            <div class="row-154">
                <label>
                    Número*:</label>
                <asp:TextBox ID="txtNumero" CssClass="required" runat="server" ToolTip="Número" />
            </div>
            <div class="row-290">
                <label>
                    Complemento:</label>
                <asp:TextBox ID="txtComplemento" runat="server" ToolTip="Complemento" />
            </div>
            <div class="row-290">
                <label>
                    Bairro*:</label>
                <asp:TextBox ID="txtBairro" CssClass="required" runat="server" ToolTip="Bairro" />
            </div>
            <div class="row-290">
                <label>
                    Cidade*:</label>
                <asp:TextBox ID="txtCidade" CssClass="required" runat="server" ToolTip="Cidade" />
            </div>
            <div class="row-290">
                <label>
                    UF*:</label>
                <asp:TextBox ID="txtUf" CssClass="required" runat="server" MaxLength="2" ToolTip="UF" />
            </div>
            <div class="row-290">
                <label>
                    Telefone*:</label>
                <asp:TextBox ID="txtTelefone" CssClass="required" runat="server" ToolTip="Telefone" />
            </div>
            <div class="row-290">
                <label>
                    Situação*:</label>
                <asp:DropDownList ID="dpSituacao" runat="server"></asp:DropDownList>
            </div>
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" runat="server"
                    Text="Salvar" CssClass="buttons" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" Text="Voltar"
                    OnClick="btnVoltar_Click" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>
    <script type="text/javascript">
            //BUSCA CEP
            $("#<%=txtCep.ClientID%>").blur(function (event) {
                var cep = $("#<%=txtCep.ClientID%>").val();
                if ($.trim(cep) !== "") {
                    $.getScript(
                          "http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + cep,
                          function () {
                              if (resultadoCEP["resultado"]) {
                                  if (unescape(resultadoCEP["uf"]).toUpperCase() !== '') {

                                      $('#<%=txtBairro.ClientID%>').val(unescape(resultadoCEP["bairro"]));
                                      $('#<%=txtCidade.ClientID%>').val(unescape(resultadoCEP["cidade"]));
                                      $('#<%=txtUf.ClientID%>').val(resultadoCEP["uf"]);
                                      $('#<%=txtEndereco.ClientID%>').val(unescape(resultadoCEP["tipo_logradouro"]+" "+resultadoCEP["logradouro"]));
                                  } else {
                                      mostraPopUpAlert('CEP não encontrado.', '../img/icon-atencao.png', false, '');
                                      //alert('CEP não encontrado.');   
                                      $('#<%=txtCep.ClientID%>').val("");
                                      $('#<%=txtBairro.ClientID%>').val("");
                                      $('#<%=txtCidade.ClientID%>').val("");
                                      $('#<%=txtUf.ClientID%>').val("");
                                      $('#<%=txtEndereco.ClientID%>').val("");
                                  }
                              } else {
                                  mostraPopUpAlert('Endereço não encontrado', '../img/icon-atencao.png', false, '');
                                  //alert("Endereço não encontrado");
                              }
                          }
                        );
                }
                  });
       </script>
</asp:Content>
