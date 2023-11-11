<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.ProjectDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



<body>
   
        <div>
           <h2> <asp:Label ID="lblName" runat="server"></asp:Label>

               </h2>
            <p><asp:Label ID="lblProjectID" runat="server" Text="ProjectID"></asp:Label></p>
             <p><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></p>
            <p> <asp:Label ID="lblStartDate" runat="server" Text="0"></asp:Label></p>
            <p> <asp:Label ID="lblEndDate" runat="server" Text="0"></asp:Label></p>
            <p><asp:Label ID="lblCoordinator" runat="server" Text="0"></asp:Label></p>
            <p><asp:Label ID="lblObsCount" runat="server" Tecxt="0"></asp:Label></p>
            <p><asp:Label ID="lblResearchID" runat="server" Text="ResearchID"></asp:Label></p>
            
        </div>
    
</body>
</html>
   </asp:Content>