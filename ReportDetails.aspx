<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ReportDetails.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.ReportDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Panel ID="errorMsgPan" runat ="server" Visible="false">
            Something has gone arry
            </asp:Panel>  
        <asp:Panel ID="ObservationTablePanel" runat="server" Visible="false">
            <asp:Repeater ID ="ObservationTable" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>ObservationID</th>
                               
                                <th>Value</th>
                                <th>Notes</th>
                                <th>Tool ID</th>
                                <th>Latitude</th>
                                <th>Longitude</th>
                                <th>Report ID</th>
                            </tr>
                        </thead>
                        <tbody>
                            </HeaderTemplate>
                <ItemTemplate>
                <tr>
                    <td> <%# Eval("ObservationID") %></td>
                    <td> <%# Eval("Value") %></td>
                    <td> <%# Eval("Notes") %></td>
                    <td> <%# Eval("ToolID") %></td>
                    <td> <%# Eval("Latitude") %></td>
                    <td> <%# Eval("Longitude") %></td>
                    <td> <%# Eval("ReportID") %></td>
                </tr>

                     



                    
              </ItemTemplate>






            </asp:Repeater>
            <a href="ObservationSubmission.aspx" class="btn">Add Observation</a>
        </asp:Panel>
    </main>
</asp:Content>