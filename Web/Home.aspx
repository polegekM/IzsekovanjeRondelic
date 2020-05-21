<%@ Page Title="Domov" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Home" %>

<%@ MasterType VirtualPath="~/MasterPage/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="row mx-auto justify-content-center">
        <div class="col-md-9 p-0">
            <div class="card mt-4" style="background-color: #f1f1f1;">
                <div class="card-body">
                    <h3 class="display-4" style="font-size: 45px;">Dobrodošli!</h3>
                    <p class="lead text-muted">Vstopili ste v spletno aplikacijo izračunavanja vsot rondelic na traku iz različnih zlitin. Lahko ustvarite nove izračune ali pregledate že obsotječe</p>
                </div>
            </div>
        </div>
    </div>
    <div class="row mx-auto justify-content-center">
        <div class="col-md-9">
            <div class="row justify-content-between">
                <div class="col-sm-6 p-0 pr-2">
                    <div class="card mt-4 border-primary" style="background-color: #f1f1f1;">
                        <div class="card-body">
                            <h4>Nov izračun</h4>
                            <p class="small">Aplikacija kreira nov izračun na podlagi podanih parametrov.</p>
                            <p class="text-muted">S pomočjo dimenzij ki so podani v milimetrih, aplikacija izračuna vsoto rondelic na traku.</p>
                            <p class="m-0"><a class="btn btn-primary" href="CalculateSlugsForm.aspx">Preveri &raquo;</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 p-0 pl-2">
                    <div class="card mt-4 border-success" style="background-color: #f1f1f1;">
                        <div class="card-body">
                            <h4>Pregled izračunov</h4>
                            <p class="small">Uporabnik ima možnost pregleda vseh izračunov.</p>
                            <p class="text-muted">Aplikacija ponuja možnost vpogleda vseh podatkov ki so se uporabljali za izračune.</p>
                            <p class="m-0"><a class="btn btn-success" href="SLugsTable.aspx">Preveri &raquo;</a></p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
