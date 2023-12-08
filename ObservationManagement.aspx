<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ObservationManagement.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.ObservationManagement" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Repeater ID="ObservationRepeater" runat="server">
            <ItemTemplate>
                <div>
                    <p>Observation ID: <%# Eval("ObservationID") %></p>
                    <p>Value: <%# Eval("Value") %></p>
                    <p>Observation Date: <%# Eval("ObservedDate") %></p> <!-- Shows all the values in Observations and links to the ReportDetails page that correlates with the correct ReportID -->    
                    <p>Notes: <%# Eval("Notes") %></p>
                    <p>Tool ID: <%# Eval("ToolID") %></p>
                    <p>Latitude: <%# Eval("Latitude") %></p>
                    <p>Longitude: <%# Eval("Longitude") %></p>  
                    
                     <asp:HyperLink ID="ReportLink" runat="server" Text="View Report" NavigateUrl='<%# Eval("ReportID", "~/ReportDetails.aspx?ID={0}") %>'></asp:HyperLink>
                    </p>

               
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </main>
</asp:Content>