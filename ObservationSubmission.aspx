<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ObservationSubmission.aspx.cs" Inherits="Davis_Justin_CitizenScience_Project.ObservationSubmission" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <main>
        <asp:Panel ID="errorMsgPan" runat ="server" Visible="false">
            Something has gone arry
            </asp:Panel>
            <asp:Panel ID="ObservationSubmissionID" runat="server" Visible="false">
                <h2> Submit an Observation</h2>
 


                <!-- This is the form for submitting the notes for an observation -->
                Notes: <asp:TextBox ID="NotesBox" runat="server"></asp:TextBox><br />
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
                </asp:Panel>

            <asp:Panel ID="SubmissionSuccess" runat="server" Visible="false">
                <h2>Submission Confrimation</h2>
                <p>
                    Thanks for submitting! Your submission confirmation number is 
                    <asp:Label ID ="SubmissionNumber" runat = "server"></asp:Label>
                </p>
                </asp:Panel>

       <asp:Panel runat="server" ID="CreateObservation" Visible="false">

           <asp:LoginView runat="server" ID="LoginView1">
               <LoggedInTemplate>




               </LoggedInTemplate>
           </asp:LoginView>
       </asp:Panel>

    </main>

</asp:Content>