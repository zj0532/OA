<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OASys.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>统一办公平台</title>
    <link rel="stylesheet" type="text/css" href="css/alogin.css" />
    <style type="text/css">

    .input_valid { width: 91px; height:25px;}
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="bthLogin" defaultfocus="txtName">

        <div class="Main">
            <ul>
                <li class="top"></li>
                <li class="top2" style="font-size:14px;font-weight:bold;text-align:center"></li>
                <li class="topA"></li>
                <li class="topB"><span>
                    <img src="image/login/logo.gif" alt="" style="" />
                </span></li>
                <li class="topC"></li>
                <li class="topD">
                    <ul class="login">
                        <li><span class="left">用户名：</span> <span style="left;">
                            <input runat="server" id="txtName" type="text" class="txt" />

                        </span></li>
                        <li><span class="left">密 码：</span> 
                            <span class="left"><input runat="server" id="txtPwd" type="password" class="txt" /></span>
                            
                        </li>
                        <li style="height: 40px;margin-top:5px;">
                        <span class="left" style="display:block;float:left">验证码：</span>
                        <span style="display:block;float:left">&nbsp;<input id="tVerifyCode" type="text" class="input_valid" placeholder="验证码" runat="server" style="border-radius:5px; box-shadow:none" /></span>&nbsp;&nbsp;
                        <img src="common/verify_code.aspx" onclick="this.src+='?'" alt="图片看不清？点击重新得到验证码" style="line-height:28px;"  />
                        </li>
                    </ul>
                </li>
                <li class="topE"></li>
                <li class="middle_A"></li>
                <li class="middle_B"></li>
                <li class="middle_C">
                    <span class="btn">
                        <asp:ImageButton ID="bthLogin" runat="server" ImageUrl="image/login/btnlogin.gif" OnClick="UserLogin" />


                    </span>
                </li>
                <li class="middle_D"></li>
                <li class="bottom_A"></li>
                <li class="bottom_B"><h1>重要通知</h1>
                    <p>因服务器在S楼2楼机房运行不稳定，所以决定于2017年1月10日下午将服务器迁移至机房</p>
                    <p>OA登陆网址为：<a href="http://10.128.3.129">10.128.3.129</a>，知识库登陆网址为：
                        <a href="http://10.128.3.129:8002">10.128.3.129:8002</a></p>
                    <p>本服务器将于近期关闭，请互相转告，谢谢!</p>
                </li>
            </ul>
        </div>

    </form>
</body>
</html>
