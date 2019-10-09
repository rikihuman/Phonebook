<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web.Employees.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %>.</h2>
    <p>This is Version 1.0.1 of Employee Portal made using ASP.NET Webforms. Employee Portal uses Microsofts built in Identity framework to enable logging in and registering on the portal.
        It also connects to a SQL Database and some bootstrapper features were used for styling.
        I will continue to enhance Employee Portal.
    </p>
    <p>Designed by Riki Human.</p>
</asp:Content>
