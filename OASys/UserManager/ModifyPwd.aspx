<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="OASys.UserManager.ModifyPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css"/>
     <link rel="stylesheet" type="text/css" href="../css/icon.css"/>
     <link rel="stylesheet" type="text/css" href="../css/comm.css"/>
     <link rel="stylesheet" type="text/css" href="../css/demo.css"/>
     <script type="text/javascript" src="../script/jquery.min.js"></script>
     <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
   <form id="form1" runat="server">
   <div style="  width:1046px;margin-right:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="新员工须知" style="padding-left:20px">
              修改密码
                
			 </div>
        <table style="padding-right:10px; padding-left:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;">
        <tr style="height:100px"></tr>
             <tr>
            <td style="width:200px;">

            </td>

            <td>
                原密码:
            </td>
            <td>
                <asp:TextBox ID="txtYpwd" CssClass="textbox03" Width="200px" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td style="width:200px;">

            </td>
            <td style="width:100px">
                新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNpwd" CssClass="textbox03" Width="200px" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RevPassword" ControlToValidate="txtNpwd" runat="server" ValidationExpression="^(?![a-zA-Z0-9]+$)(?![^a-zA-Z/D]+$)(?![^0-9/D]+$).{6,12}$" ErrorMessage="必须包含字母数字以及特殊字符并且不能少于6位"  Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
            <tr>
                <td style="width:200px;">

            </td>
            <td>
                确认新密码：
            </td>
            <td>
                <asp:TextBox ID="txtTNpwd" CssClass="textbox03" Width="200px"  runat="server" TextMode="Password"></asp:TextBox>
            </td>
            </tr>
            <tr>
                 <td style="width:200px;">

            </td>
            <td>
                
            </td>
            <td>
                <asp:Button ID="Button1" CssClass="button white" runat="server" Text="确 定" OnClick="Button1_Click" />
                
            </td>
        </tr>
            <tr style="min-height:230px">

            </tr>
        </table>
    </div>
  </form>
</body>
</html>
