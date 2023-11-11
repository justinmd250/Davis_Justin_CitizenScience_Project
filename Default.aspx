<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <main>
        <asp:Repeater ID="HomePage" runat="server">
            <ItemTemplate>
            <a href="Projects.aspx?ProjectID=<%# Eval("ReportID")%>"> 
                <%# Eval("ProjectID") %>
  
                </a>
                <br />
                
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>

