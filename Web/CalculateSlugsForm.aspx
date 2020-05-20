<%@ Page Title="Izračun rondelic" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="CalculateSlugsForm.aspx.cs" Inherits="Web.CalculateSlugsForm" %>

<%@ MasterType VirtualPath="~/MasterPage/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function CauseValidation(s, e) {
            var process = false;
            var inputItems = [txtLength, txtWidth, txtLengthEdge, txtWidthEdge, txtMinDistanceSlugs, txtRadius];

            process = InputFieldsValidation(null, inputItems, null, null);

            if (process) {
                LoadingPanel.Show();
                e.processOnServer = true;
            }
            else
                e.processOnServer = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="row m-0 pt-3">

                <div class="col-md-6">
                    <div class="row m-0 pb-3">
                        <div class="col-lg-6 mb-2 mb-lg-0">
                            <div class="row m-0 align-items-center">
                                <div class="col-0 p-0" style="margin-right: 55px;">
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Size="12px" Text="DOLŽINA TRAKU : *" Font-Bold="true"></dx:ASPxLabel>
                                </div>
                                <div class="col p-0">
                                    <dx:ASPxTextBox runat="server" ID="txtLength" ClientInstanceName="txtLength"
                                        CssClass="text-box-input" Font-Size="13px" Width="100%" MaxLength="50" AutoCompleteType="Disabled">
                                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                                        <ClientSideEvents KeyPress="isNumberKey_decimal" />
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 mb-2 mb-lg-0">
                            <div class="row m-0 align-items-center justify-content-end">
                                <div class="col-0 p-0" style="margin-right: 36px">
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Size="12px" Text="ŠIRINA TRAKU : *" Font-Bold="true"></dx:ASPxLabel>
                                </div>
                                <div class="col p-0">
                                    <dx:ASPxTextBox runat="server" ID="txtWidth" ClientInstanceName="txtWidth"
                                        CssClass="text-box-input" Font-Size="13px" Width="100%" MaxLength="100" AutoCompleteType="Disabled">
                                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                                        <ClientSideEvents KeyPress="isNumberKey_decimal" />
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row m-0 pb-3">
                        <div class="col-lg-6 mb-2 mb-lg-0">
                            <div class="row m-0 align-items-center">
                                <div class="col-0 p-0" style="margin-right: 35px;">
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Size="12px" Text="ROBOVI OB DOLŽINI : *" Font-Bold="true"></dx:ASPxLabel>
                                </div>
                                <div class="col p-0">
                                    <dx:ASPxTextBox runat="server" ID="txtLengthEdge" ClientInstanceName="txtLengthEdge"
                                        CssClass="text-box-input" Font-Size="13px" Width="100%" MaxLength="50" AutoCompleteType="Disabled">
                                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                                        <ClientSideEvents KeyPress="isNumberKey_decimal" />
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 mb-2 mb-lg-0">
                            <div class="row m-0 align-items-center justify-content-end">
                                <div class="col-0 p-0 mr-3">
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Size="12px" Text="ROBOVI OB ŠIRINI : *" Font-Bold="true"></dx:ASPxLabel>
                                </div>
                                <div class="col p-0">
                                    <dx:ASPxTextBox runat="server" ID="txtWidthEdge" ClientInstanceName="txtWidthEdge"
                                        CssClass="text-box-input" Font-Size="13px" Width="100%" MaxLength="100" AutoCompleteType="Disabled">
                                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                                        <ClientSideEvents KeyPress="isNumberKey_decimal" />
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row m-0 pb-3">
                        <div class="col-lg-6 mb-2 mb-lg-0">
                            <div class="row m-0 align-items-center">
                                <div class="col-0 p-0 mr-3">
                                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Size="12px" Text="MIN. RAZD. MED ROND. : *" Font-Bold="true"></dx:ASPxLabel>
                                </div>
                                <div class="col p-0">
                                    <dx:ASPxTextBox runat="server" ID="txtMinDistanceSlugs" ClientInstanceName="txtMinDistanceSlugs"
                                        CssClass="text-box-input" Font-Size="13px" Width="100%" MaxLength="50" AutoCompleteType="Disabled">
                                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                                        <ClientSideEvents KeyPress="isNumberKey_decimal" />
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 mb-2 mb-lg-0">
                            <div class="row m-0 align-items-center justify-content-end">
                                <div class="col-0 p-0" style="margin-right: 73px;">
                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Size="12px" Text="POLMER : *" Font-Bold="true"></dx:ASPxLabel>
                                </div>
                                <div class="col p-0">
                                    <dx:ASPxTextBox runat="server" ID="txtRadius" ClientInstanceName="txtRadius"
                                        CssClass="text-box-input" Font-Size="13px" Width="100%" MaxLength="100" AutoCompleteType="Disabled">
                                        <FocusedStyle CssClass="focus-text-box-input"></FocusedStyle>
                                        <ClientSideEvents KeyPress="isNumberKey_decimal" />
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row m-0 pb-3 pt-3">
                        <div class="col text-center">
                            <dx:ASPxButton ID="btnCalculate" runat="server" Text="Izračunaj število rondelic" AutoPostBack="false"
                                Height="25" Width="90" ClientInstanceName="btnEdit" OnClick="btnCalculate_Click">
                                <Paddings PaddingLeft="10" PaddingRight="10" />
                                <ClientSideEvents Click="CauseValidation" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 justify-content-center text-center">
                    <img class="img-fluid" src="Images/PostavitevRondelic.png" alt="postavitevRondelic" />
                    Opombe: Vse količine so izražene v milimetrih
                </div>
            </div>

        </div>
    </div>
</asp:Content>
