<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAjaxModalPopup.ascx.cs" Inherits="SAcademia.Web.ucAjaxModalPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

    <div id="DivPopup" runat="server">
        <asp:Panel ID="PanelPopup" runat="server" CssClass="modalPopup" 
            Style="display: table" Height="111px" Width="400px" >
            <div id="divMensagemPopup">
                <img src="" alt="imagem" id="iconeMensagem" class="iconePopup" runat="server" />
                <asp:Label ID="lblMensagemPopup" runat="server" Text=""></asp:Label>
            </div>
            <div class="btns">
                <asp:Button ID="btnConfirmarPopup" runat="server" CssClass="buttons" 
                    Text="OK" onclick="btnConfirmarPopup_Click" />
            </div>
        </asp:Panel> 
    </div>
    <asp:LinkButton ID="btnModalPopup" runat="server" Visible="true"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderPopup" runat="server"
            TargetControlID="btnModalPopup"
            PopupControlID="PanelPopup"
            BackgroundCssClass="modalBackground"
            DropShadow="true"  />
    
    <script type="text/javascript">
        function btnConfirmarFocus() {
                $("#<%=btnConfirmarPopup.ClientID %>").focus();
            }
    </script>
        

