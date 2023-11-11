<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Institutions.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.Institutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   <main>
        <asp:Repeater ID="Institution" runat="server">
            <ItemTemplate>
                 
            <a href="ResearchAreas.aspx?InstID=@InstID">
              
               
                </a>
                <br />
                
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>
