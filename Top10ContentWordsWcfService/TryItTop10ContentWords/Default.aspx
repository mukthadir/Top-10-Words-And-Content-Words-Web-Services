<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h2>Mukthadir H Choudhury&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Assignment 3 Part 2</h2>
        </div>

        <div class="col-lg-12">
            <h4>Description - Top 10 Content Words&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; URL - <a href="http://localhost:1971/Service1.svc">http://localhost:1971/Service1.svc</a> </h4>
            <p>
                This WebService analyzes a given Web Page and returns the top ten most- frequently occured Content words in the web page. This web service removes all the non-content words i.e the STOP words before counting the appearance of rest of the words. The words that are returned are arranged in the decreasing order of their appearing frequencies. In case two words appearing frequencies are exactly the same, then the word that appears first in the web page is placed higher.
            </p>
            <p />
                Method Name - Top10ContentWords()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Parameter type - String&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return type - String[]<p>
                Please enter the URL here:
                <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="424px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="GetTop10ContentWords" OnClick="Button2_Click" style ="LEFT: 500px; POSITION: absolute" />
            </p>
            <p>
                <asp:TextBox ID="TextBox3" runat="server" Height="220px" Width="1031px" Wrap="True" TextMode="MultiLine" style = "LEFT: 500px; POSITION: absolute; OVERFLOW: hidden; Z-INDEX: 101" Rows ="10"></asp:TextBox>
            </p>
        </div>
    </div>
</asp:Content>
