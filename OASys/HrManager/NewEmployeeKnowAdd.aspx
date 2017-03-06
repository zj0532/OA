<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployeeKnowAdd.aspx.cs" Inherits="OASys.HrManager.NewEmployeeKnowAdd" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加新员工知识</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body style="overflow:hidden;" scroll="no">
    <form id="form1" runat="server">
    <div style="  width:1046px;margin-right:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="添加新知识" style="padding-left:20px">
              添加新知识
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="NewEmployeeKnowGroup.aspx">返回列表</a></div> 
			 </div>
              <table style="padding-right:10px; padding-left:18px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;">
                  <tr >
                      <td style="width:80px">
                       标 题：  
                      </td>
                      <td>
                          <asp:TextBox ID="txtTitle" Width="900px" CssClass="textbox03" runat="server"></asp:TextBox> 
                      </td>
                  </tr>

                   <tr >
                      <td style="width:80px">
                       发布时间：  
                      </td>
                      <td>
                          <input runat="server" id="txtDate"  class="textbox03" style="width:900px" type="text" />
                      </td>
                  </tr>
                 
                   <tr >
                      <td style="width:80px">
                       发布人：  
                      </td>
                      <td>
                          <input runat="server" id="txtUsname"  class="textbox03" style="width:900px" type="text" />
                      </td>
                  </tr>

                   <tr >
                      <td style="width:80px">
                       备注：  
                      </td>
                      <td>
                          <input id="txtRemark" runat="server"  class="textbox03" style="width:755px" type="text" />
                          <asp:CheckBox ID="CheckBox1" runat="server" />
                          <span style="position: relative; left:1px;top:-3px">是否在其它业务组显示</span>
                      </td>
                  </tr>

                  <tr >
                      <td style="width:80px">
                       内容：  
                      </td>
                      <td>
                          
                          <CE:Editor ID="Editor1" runat="server" Width="905px" AutoConfigure="Simple">
                          </CE:Editor>
                          
                      </td>
                  </tr>

              </table>

             </div>

        <div style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
            <%--<input id="bthAdd" runat="server" class="button white" type="button"  value="添 加"  />--%>
             <asp:Button ID="Button1" CssClass="button white" runat="server" Text="保 存" OnClick="Button1_Click" />
             <input id="bthCanel" class="button white" type="button"  value="返 回" onclick="document.location='NewEmployeeKnowGroup.aspx'" />
            
         </div>

    </form>
</body>
</html>


