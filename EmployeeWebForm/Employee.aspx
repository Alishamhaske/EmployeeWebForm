<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeWebForm.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Namelbl" runat="server" Text="Name"></asp:Label>
            <br />
            <asp:TextBox ID="Nametxt" runat="server" OnTextChanged="Nametxt_TextChanged"></asp:TextBox>
        </div>
        <asp:Label ID="salarylbl" runat="server" Text="Salary"></asp:Label>
        <p>
            <asp:TextBox ID="salarytxt" runat="server"></asp:TextBox>
            <asp:GridView ID="gridview" runat="server" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField CommandName="Edit" ShowHeader="True" Text="Edit" />
                    <asp:ButtonField CommandName="Delete" Text="Delete" />
                </Columns>
            </asp:GridView>
           
        </p>
        <p>
            <asp:Label ID="deplbl" runat="server" Text="department"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtdep" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="ldlID" runat="server" Text="ID"></asp:Label>
        </p>
        <!--<p>
            <asp:TextBox ID="txtID" runat="server" OnTextChanged="txtID_TextChanged"></asp:TextBox>
        </p>-->
        <p>
            <asp:TextBox ID="txtid1" runat="server" OnTextChanged="txtID_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search" />
            <asp:Button ID="deletebtn" runat="server" OnClick="deletebtn_Click" Text="delete" />
        </p>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
        <asp:Button ID="Updatetxt" runat="server" OnClick="Updatetxt_Click" Text="Update" />
       
    </form>

</body>
</html>
