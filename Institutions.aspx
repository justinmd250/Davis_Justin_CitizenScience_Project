<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Institutions.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.Institutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   <main>
        <asp:Repeater ID="Institution" runat="server">
            <ItemTemplate>
                 
            <a href="ResearchAreas.aspx?InstID=<%#Eval("InstitutionID") %>">
                <%#Eval("InstitutionName") %>
                
              
                 <!--This calls on the researchareas page and pulls the instID to match the institutionID from the institutions table. This allows for you to click on the link for institutions and only get results for researchareas that match the institutionid--->
                </a>
                <br />
                
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>
