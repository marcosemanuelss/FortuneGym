<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucModalPopUpPesquisaMatricula.ascx.cs" Inherits="SAcademia.Web.Controls.ucModalPopUpPesquisaMatricula" %>
<%@ Register src="~/Controls/ucAjaxModalPopup.ascx" tagname="ucAjaxModalPopup" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript" src="../Scripts/jquery.min.js"></script>
<script type="text/javascript">
    //Função que obriga o usuário a digitar apenas numeros
    function verificaNumero(e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    }
    $(function () {
        $("#MainContent_ucModalPopupPesquisaMatricula1_txtMatricula").keypress(verificaNumero);
    });
</script>
    <div id="DivPopup" runat="Server">
        <asp:LinkButton ID="btnModal" runat="server" ></asp:LinkButton>
        <asp:Panel ID="PanelPopup" runat="server" CssClass="modalPopup" 
            Style="display: table" Height="250px" Width="548px" >
            <div class="rowPopUp-452" runat="server">
			    <label>Matrícula:</label><br />
                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
    	    </div>
            <asp:Button ID="btnPesquisar" runat="server" ToolTip="Pesquisar" CssClass="buttons" 
                    Text="Pesquisar" />
            <asp:GridView ID="gvConsulta" AutoGenerateColumns="true" CssClass="tabPopUp" 
                    runat="server" EmptyDataText="Nenhum Dado encontrado">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                        <asp:TemplateField HeaderText="Selecionar">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelecione" runat="server" />
                                <asp:HiddenField ID="Codigo" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            <div class="btns">
                <asp:Button ID="btnConfirmarPopup" runat="server" ToolTip="Confirmar" CssClass="buttons" 
                    Text="Confirmar" />
                <asp:Button ID="btnCancelarPopup" runat="server" ToolTip="Cancelar" CssClass="buttons" 
                    Text="Cancelar" onclick="btnCancelarPopup_Click" />
            </div>
        </asp:Panel>
    </div>
    <asp:ModalPopupExtender ID="ModalPopupExtenderPopup" runat="server"
            TargetControlID="btnModal"
            PopupControlID="PanelPopup"
            BackgroundCssClass="modalBackground"
            DropShadow="true"  />

    <uc1:ucAjaxModalPopup ID="ucAjaxModalPopup1" runat="server" />
