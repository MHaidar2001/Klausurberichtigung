<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dozentsverwaltung.aspx.cs" Inherits="Klausur_Nr._2.Views.Dozentsverwaltung1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Dozentsverwaltung</title>
    
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <h1>Dozentsverwaltung</h1>
            <br />

            <div class="form-group">
            Name:
            <asp:TextBox CssClass="form-control"  ID="TextBox1" runat="server" Height="28px" Width="200px"></asp:TextBox><br />
            Fach:
            <asp:TextBox CssClass="form-control"  ID="TextBox2" runat="server" Height="28px" Width="200px"></asp:TextBox>
            <asp:Button  ID="Button1" runat="server" Text="Einfügen" OnClick="Button1_Click"  CssClass="btn btn-success"/>
            <asp:Button ID="Button2" runat="server" Text="Änderung Speichern" OnClick="Button2_Click" CssClass="btn btn-success" />

                </div>
            <br />
            ID eingeben:
            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Height="28px" Width="200px"></asp:TextBox><asp:Button ID="Button3" runat="server" Text="Löschen" CssClass="btn btn-danger" OnClick="Button3_Click" /><br />
            ID eingeben<asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" Height="28px" Width="200px"></asp:TextBox><asp:Button ID="Button4" runat="server" Text="Bearbeiten" CssClass="btn btn-primary" OnClick="Button4_Click" />

            <br />
            <br />
            <asp:Table ID="Table1" runat="server" CssClass="table table-striped">
                <asp:TableHeaderRow>
                     <asp:TableCell><b>ID</b></asp:TableCell>
                    <asp:TableCell><b>Name</b></asp:TableCell>
                  <asp:TableCell><b>Fach</b></asp:TableCell>
                </asp:TableHeaderRow>
               
            </asp:Table>
        </div>
    </form>
</body>
</html>
