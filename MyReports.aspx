<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyReports.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.MyReports" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <main>
        <asp:Panel ID="MyReportsPanel" runat ="server" Visible="false">
        <asp:Repeater ID="ReportsTable" runat="server">
            <ItemTemplate>
                <div class ="report">
                  <p>  <%#Eval("ProjectName") %> </p>
            <p><a href="ReportDetails.aspx?ID=<%# Eval("ReportID")%>">View Report <%# Eval("ReportID") %></a></p> <!-- This is the link to the report details page -->
                
                </div>
                
             
            </ItemTemplate>
        </asp:Repeater>
        </asp:Panel>

    </main>

</asp:Content>