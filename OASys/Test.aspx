<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="OASys.Test" %>

<%@ Register Src="~/Control/ButtonCtrl.ascx" TagPrefix="uc1" TagName="ButtonCtrl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body style="margin:0px; padding:0px">
    <form id="form1" runat="server">
    <div style="background-color:red">
       <span>测试页</span>
        <div style="">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="插入数据" OnClick="Button2_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />

            <asp:Label ID="labText" runat="server" Text="Label"></asp:Label>

        </div>
    </div>
    </form>
</body>
</html>


