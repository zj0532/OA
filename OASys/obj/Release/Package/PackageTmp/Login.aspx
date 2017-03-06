<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OASys.Login" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>统一办公平台</title>
    <link rel="stylesheet" type="text/css" href="css/alogin.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="bthLogin" defaultfocus="txtName">
     <div class="Main">
        <ul>
            <li class="top"></li>
            <li class="top2"></li>
            <li class="topA"></li>
            <li class="topB"><span>
                <img src="image/login/logo.gif" alt="" style="" />
            </span></li>
            <li class="topC"></li>
            <li class="topD">
                <ul class="login" >
                    <li><span class="left">用户名：</span> <span style="left">
                        <input runat="server" id="txtName" type="text" class="txt" />  
                     
                    </span></li>
                    <li><span class="left">密 码：</span> <span style="left">
                       <input runat="server" id="txtPwd" type="password" class="txt" />  
                    </span></li>
                         <li style="height:40px;"><span class="left">验证码：</span> 
                    <input runat="server"  id ="txtCode" type="text" class="txtCode" /> 
                      <span style="  position: relative; left:5px;top:9px">     
                       <asp:ImageButton ID="ImageButton1" runat="server"   ToolTip="点击刷新" ImageUrl="~/Control/GetViCode.aspx" />
                          
                      </span>  
                      </li>
                     
                      
                      
                   
                    
                </ul>
            </li>
            <li class="topE"></li>
            <li class="middle_A"></li>
            <li class="middle_B"></li>
            <li class="middle_C">
            <span class="btn">
            <asp:ImageButton ID="bthLogin" runat="server" ImageUrl="image/login/btnlogin.gif"  OnClick="UserLogin" />
            
             
            </span>
            </li>
            <li class="middle_D"></li>
            <li class="bottom_A"></li>
            <li class="bottom_B">
            
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
