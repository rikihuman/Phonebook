<%@ Page Title="Phonebook" Language="C#" MasterPageFile="~/Phonebook.Master" AutoEventWireup="true" CodeBehind="Phonebook.aspx.cs" Inherits="Phonebook.Phonebook1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
        <asp:Button ID="btnAdd" runat="server" Text="Add New Contact"/>
    </div>
</asp:Content>
