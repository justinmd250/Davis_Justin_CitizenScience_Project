<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.ResearchAreas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Repeater ID="ResearchAreasPage" runat ="server">
            <ItemTemplate>
              
                <a href="Projects.aspx?id=<%# Eval("ProjectID") %>">
                  
                    <!--- Creates a clickable link that links the name of the RA given in the project table to the proper researcharea--->
                </a>
           
            </ItemTemplate>


        </asp:Repeater>

        </main>
 
</asp:Content>
