<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <main>
        <asp:Repeater ID="Project" runat="server">
            <ItemTemplate>
            <a href="ProjectDetails.aspx?ProjectID=<%# Eval("ProjectID")%>">
                <%#Eval("Name") %>
                </a>
                <br />
                <!--Matches the information displayed in projectdetails based on the projectid given.-->
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>

