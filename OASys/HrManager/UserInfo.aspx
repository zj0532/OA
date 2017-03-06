<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="OASys.HrManager.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>统一办公平台_个人详细信息</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
     <link rel="stylesheet" type="text/css" href="../css/icon.css" />
     <link rel="stylesheet" type="text/css" href="../css/comm.css" />
     <link rel="stylesheet" type="text/css" href="../css/demo.css"/>
     <script type="text/javascript" src="../script/jquery.min.js"></script>
     <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <div style="  width:1046px;margin-right:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="项目组成员个人信息" style="padding-left:20px">
              项目组成员个人信息
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="AddressList.aspx">返回列表</a></div> 
			 </div>
              <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;">
                  <tr >
                      <td style="width:200px;background-color:#F2F2F2;">
                       姓名：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                      <asp:Label ID="labUsname" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                       服务形式：
                      </td >
                      <td style="background-color:#F2F2F2">
                      <asp:Label ID="labServerStyle" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>
                   <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       手机：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labPhone" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                       所属公司：
                      </td>
                      <td style="background-color:#F2F2F2">
                        <asp:Label ID="labCompany" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>
                   <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       邮箱：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labEmail" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                       办公地点：
                      </td>
                      <td style="background-color:#F2F2F2">
                        <asp:Label ID="labOffice" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>

                   <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       职务：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labJob" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                       入职时间：
                      </td>
                      <td style="background-color:#F2F2F2">
                        <asp:Label ID="labEmptyInDate" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>

                   <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       状态：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labStauts" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                       入职原因：
                      </td>
                      <td style="background-color:#F2F2F2">
                      <asp:Label ID="labEmptyCause" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>

                  <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       业务：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labBusiness" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                      离职时间：
                      </td>
                      <td style="background-color:#F2F2F2">
                      <asp:Label ID="labEmptyOutDate" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>

                  <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       日常上班时间：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labCommUp" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                      日常下班时间：
                      </td>
                      <td style="background-color:#F2F2F2">
                      <asp:Label ID="labCommDown" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>

                   <tr >
                      <td style="width:200px;background-color:#F2F2F2">
                       周六上班时间：
                      </td>
                      <td style="width:300px;background-color:#F2F2F2">
                        <asp:Label ID="labSatUp" runat="server" Text=""></asp:Label>
                      </td>
                      <td style="width:200px;background-color:#F2F2F2">
                      周六下班时间：
                      </td>
                      <td style="background-color:#F2F2F2">
                      <asp:Label ID="labSatDown" runat="server" Text=""></asp:Label>
                      </td>
                  </tr>
                  

              </table>

             </div>

            <%-- 工作内容--%>
            <div style="  width:1046px;margin-right:20px;margin-bottom:20px">
			 <div  class="panel-header"  title=" 工作内容" style="padding-left:20px">
              工作内容
             
			 </div>
              <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:115px">
                  <tr >
                      <td style=" padding:10px">
                       
                       <asp:HyperLink ID="hlkWorkContent" runat="server">工作内容</asp:HyperLink>
                      </td>
                  </tr>

              </table>

             </div>


            <%--岗位职责--%>
        <div style="  width:1046px;margin-right:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="项目组成员个人信息" style="padding-left:20px">
              岗位职责
            
			 </div>
              <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:115px">
                  <tr>
                      <td style="padding:10px">
                       <asp:HyperLink ID="hlkGW" runat="server">岗位职责</asp:HyperLink>
                      </td>
                  </tr>

              </table>

             </div>


    </form>
</body>
</html>
