<%@ Page Title="Prijava" Language="C#" MasterPageFile="~/MasterPage/Welcome.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#LoginCard').keypress(function (event) {
                var key = event.which;
                if (key == 13) {
                    CauseValidation(this, event);
                    txtUsername.GetInputElement().blur();
                    txtPassword.GetInputElement().blur();
                    return false;
                }
            });
        });

        function CauseValidation(s, e) {
            var process = false;
            var inputItems = [txtUsername, txtPassword];

            process = InputFieldsValidation(null, inputItems, null, null);

            if (process) {
                LoadingPanel.Show();
                LoginCallback.PerformCallback("SignInUserCredentials");
            }
        }

        function LoginCallback_EndCallback(s, e)
        {
            LoadingPanel.Hide();

            txtUsername.SetText("");
            txtPassword.SetText("");

            if (s.cpResult != "" && s.cpResult !== undefined) {
                lblError.SetText(s.cpResult);
                delete (s.cpResult);
            }
            else
                window.location.assign('Home.aspx');
        }

        function ClearText(s, e) {
            lblError.SetText("");

            $(txtUsername.GetInputElement()).parent().parent().parent().removeClass("focus-text-box-input-error");
            $(txtPassword.GetInputElement()).parent().parent().parent().removeClass("focus-text-box-input-error")
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="text-center">
        <img class="img-fluid" src="http://www.judoklubimpol.si/wp-content/uploads/2017/12/impolLogo-300x191.png" />
    </div>
    <div id="LoginCard" class="card w-25 mx-auto" style="background-color: #f1f1f1;">
        <div class="card-body">
            <div class="display-4" style="font-size: 19px;">Izsekovanje rondelic</div>
            <hr style="margin-top: 10px;" />
            <div class="row mt-4">
                <div class="col p-0">
                    <dx:ASPxLabel ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" ClientInstanceName="lblError"></dx:ASPxLabel>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col p-0 px-3">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Size="14px" Text="Uporabniško ime"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="txtUsername" runat="server" Width="100%" ClientInstanceName="txtUsername"
                        CssClass="text-box-input" Font-Size="14px" AutoCompleteType="Disabled">
                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                        <ClientSideEvents  GotFocus="ClearText" />
                        <Paddings Padding="10" />
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div class="row mt-4">
                <div class="col p-0 px-3">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Size="14px" Text="Geslo"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="txtPassword" runat="server" Width="100%" ClientInstanceName="txtPassword"
                        CssClass="text-box-input" Font-Size="14px" AutoCompleteType="Disabled" Password="true">
                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                        <ClientSideEvents  GotFocus="ClearText" />
                        <Paddings Padding="10" />
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div class="row mt-4 mb-2">
                <div class="col p-0 px-3">
                    <dx:ASPxCallback ID="LoginCallback" runat="server" OnCallback="CallbackLogin_Callback" ClientInstanceName="LoginCallback">
                        <ClientSideEvents EndCallback="LoginCallback_EndCallback" />
                    </dx:ASPxCallback>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
