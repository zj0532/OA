<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="OASys.Notice.AddNotice" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加通知公告</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script>
        function Show() {
            document.getElementById("hideDiv").style.display = "block";

        }
    </script>
</head>
<body onload="Show()">
    <form id="form1" runat="server">
    <div id="hideDiv" style="display:none">

      <div style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="添加值班表" style="padding-left:20px">
              添加通知公告
             
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                <tr style="height:10px;">
                </tr>
                <tr>
                     <td style="width:60px"></td>
                     <td style="width:100px">
                        标题：
                     </td>
                     <td>
                           <input  id="txtTitle" runat="server" class="textbox03" style="width:770px" type="text"  value="" />
                     </td>
                 </tr>

                 <tr>
                     <td style="width:60px"></td>
                     <td>
                        有效期开始时间：
                     </td>
                     <td>
                     <input  id="BeginDate" runat="server" class="easyui-datetimebox" style="width:776px" type="text"  value="" />
                     </td>
                 </tr>
                 
                 <tr>
                    <td style="width:30px"></td>
                     <td>
                        有效期结束时间：
                     </td>
                     <td>
                           <input  id="EndDate" runat="server" class="easyui-datetimebox" style="width:776px" type="text"  value="" />
                     </td>
                 </tr>

                 <tr style="height:10px">

                 </tr>

                  <tr>
                      <td style="width:60px"></td>
                     <td>
                        通知类别：
                     </td>
                     <td>
                          <div style="height:30px;"><asp:RadioButton ID="Rb1" GroupName="cl" runat="server" Checked="true"  Text="全部用户"/></div>
                          <div style="height:30px;">
                              <asp:RadioButton ID="Rb2" GroupName="cl" runat="server"  Text="区域用户："/>
                              <asp:DropDownList ID="ddpWordGroup" CssClass="combo" runat="server" Width="692px"></asp:DropDownList>

                          </div>
                         <div style="height:30px;">
                              <asp:RadioButton ID="Rb3" GroupName="cl" runat="server"  Text="业    务    组：  "/>&nbsp;
                              <asp:DropDownList ID="ddpBus" CssClass="combo" runat="server" Width="692px"></asp:DropDownList>

                          </div>

                         <%--<div style="height:30px">
                              <asp:RadioButton ID="Rb4" GroupName="cl" runat="server"  Text="用户列表："/>
                               <input  id="txtUserList" runat="server" class="textbox03" style="width:686px" type="text"  value="" />
                     

                         </div>--%>


                     </td>
                 </tr>

                  <tr style="height:10px">
                  </tr>

                  <tr>
                     <td style="width:60px"></td>
                     <td>
                         通知内容：
                     </td>
                     <td>
                      <CE:Editor ID="Editor1" runat="server" AutoConfigure="Simple">
                          </CE:Editor>
                     </td>
                 </tr>

                 

                 <tr>
                     <td style="width:60px"></td>
                     <td>
                         上传文档：
                     </td>
                     <td>
                        <asp:FileUpload ID="FileUpload1" CssClass="textbox03" runat="server" Width="700px" />
                     </td>
                 </tr>

                  <tr>
                      <td style="width:60px"></td>
                        <td>

                      </td>
                     <td>
                         <asp:Button ID="Button1" CssClass="button white" runat="server" Text="提 交" OnCommand="Button1_Command" />
                         <asp:Button ID="Button2" CssClass="button white" runat="server" Text="取 消" />
                     </td>
                      
                 </tr>
                  <tr style="height:10px">
                  </tr>
                 </table>
               </div>

    </div>
    </form>
</body>
</html>
