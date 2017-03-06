<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployeeShow.aspx.cs" Inherits="OASys.HrManager.NewEmplyeeShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新员工须知</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css"/>
     <link rel="stylesheet" type="text/css" href="../css/icon.css"/>
     <link rel="stylesheet" type="text/css" href="../css/comm.css"/>
     <link rel="stylesheet" type="text/css" href="../css/demo.css"/>
     <script type="text/javascript" src="../script/jquery.min.js"></script>
     <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body style="overflow:hidden;" scroll="no">
    
    
       <div style="  width:1030px;margin-right:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="新员工须知" style="padding-left:20px">
              修改密码
              
			 </div>
              <table style="padding-right:10px; padding-left:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;">
                  <tr >
                      <td >
                      
                      </td>

                  </tr>

                  <tr >
                      <td style="padding-left:10px;border-bottom:dashed 1px #ccc; text-align:center;height:30px; ">
                      <b style="font-size:18px;">
                          <asp:Label ID="labTitle" runat="server" Text=""></asp:Label></b> 
                      </td>

                  </tr>
                  <tr >
                      <td style="padding-left:10px;text-align:center;height:30px; ">
                       发布人：<asp:Label ID="labAuthor" runat="server" Text=""></asp:Label>
                          
                           <br /> 发布时间：<asp:Label ID="labDate" runat="server" Text=""></asp:Label>
                      </td>

                  </tr>
                   
                    <tr>
                      <td style="padding-left:10px;text-align:center;height:10px; ">
                       
                      </td>
                  </tr>
                  <tr>
                      <td style="padding:10px; border-bottom:dashed 1px #cccccc">
                       <asp:Label ID="labContent" runat="server" Text=""></asp:Label>

                      </td>
                  </tr>
                  <tr>
                      <td style="padding:10px;">
                    
                      <div style="float:left;width:700px">备注：<asp:Label ID="labRemark" runat="server" Text=""></asp:Label></div>
                      <div style="float:right;text-align:right; width:50px"><a class="a1" title="返回列表" href="NewEmployeeKnowGroup.aspx">返回列表</a></div>
                      </td>

                  </tr>

              </table>

             </div>
             


   
</body>
</html>
