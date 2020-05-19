<%@ Page Title="Pregled Izračunov rondelic" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="SlugsTable.aspx.cs" Inherits="Web.SlugsTable" %>

<%@ MasterType VirtualPath="~/MasterPage/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="px-1">
        <dx:ASPxGridView ID="GridViewSlugs" runat="server" Width="100%" KeyFieldName="product_id" OnDataBinding="GridViewSlugs_DataBinding"
            CssClass="gridview-no-header-padding" EnableRowsCache="false" AutoGenerateColumns="False" ClientInstanceName="gridSlugs">
            <Paddings Padding="0" />
            <Settings ShowVerticalScrollBar="True"
                ShowFilterBar="Auto" ShowFilterRow="True" VerticalScrollableHeight="400"
                ShowFilterRowMenu="True" VerticalScrollBarStyle="Standard" VerticalScrollBarMode="Auto" />
            <SettingsPager PageSize="50" ShowNumericButtons="true" NumericButtonCount="6">
                <PageSizeItemSettings Visible="true" Items="50,80,100" Caption="Zapisi na stran : " AllItemText="Vsi">
                </PageSizeItemSettings>
                <Summary Visible="true" Text="Vseh zapisov : {2}" EmptyText="Ni zapisov" />
            </SettingsPager>
            <SettingsBehavior AllowFocusedRow="true" AllowEllipsisInText="true" />
            <Styles>
                <Header Paddings-PaddingTop="5" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true"></Header>
                <FocusedRow BackColor="#d1e6fe" Font-Bold="true" ForeColor="#606060"></FocusedRow>
                <Cell Wrap="False" />
            </Styles>
            <SettingsText EmptyDataRow="Trenutno ni podatka o izračunih rondelic. Dodaj novega." />

            <Columns>
                <dx:GridViewDataTextColumn Caption="Šifra" FieldName="code" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Naziv" FieldName="name" Width="20%" />
                <dx:GridViewDataTextColumn Caption="Širia traku" FieldName="width" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Dolžin traku" FieldName="length" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Robovi ob dolžini" FieldName="edge_length" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Robovi ob širini" FieldName="edge_width" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Min. razd. med rondelicami" FieldName="min_distance_item" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Polmer" FieldName="radius" Width="10%" />
                <dx:GridViewDataTextColumn Caption="Vsota rondelic" FieldName="items_sum" Width="10%" />
                <dx:GridViewDataDateColumn Caption="Datum" FieldName="ts" Width="10%">
                    <PropertiesDateEdit DisplayFormatString="dd. MMMM yyyy" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn Caption="Izračun izdelal" Width="10%">
                    <DataItemTemplate>
                        <%# Eval("User.FirstName") %> <%# Eval("User.LastName") %>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
            </Columns>

        </dx:ASPxGridView>
    </div>
</asp:Content>
