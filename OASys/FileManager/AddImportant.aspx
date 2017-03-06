<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImportant.aspx.cs" Inherits="OASys.FileManager.AddImportant" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加核心资料</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body style="overflow:hidden;" scroll="no" >
    <form id="form1" runat="server">
    <div style="width:1046px; margin:auto;height:500px ">
			 <div  class="panel-header"  title="工作纪要" style="padding-left:20px; ">
              <%=PageStaute%>核心资料
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="Important.aspx">返回列表</a></div> 
			 </div>
             <table style="padding-right:10px; padding-left:18px; padding-top:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; ">
            
              <tr>
                 <td style=" width:50px"></td>
                  <td>
                   标题:
                  </td>
                  <td>
                   <input id="txtTitle" runat="server" class="textbox03" style="width:800px"/>
                  </td>
                  <td style=" width:50px"></td>
              </tr>  

                 <tr>
                 <td style=" width:50px"></td>
                  <td>
                   日期:
                  </td>
                  <td>
                  <input id="txtDate" runat="server" class="easyui-datetimebox" style="width:806px"  /> 
                  </td>
                 <td style=" width:50px"></td>
                 </tr> 

                   <tr>
                   <td style=" width:50px"></td>
                  <td>
                   作者:
                  </td>
                  <td>
                  <input id="txtUsName" runat="server" class="textbox03" style="width:800px"  /> 
                  </td>
                  <td style=" width:50px"></td>
              </tr> 

              <tr>
                   <td style=" width:50px"></td>
                  <td>
                   内容:
                  </td>
                  <td>
                  <CE:Editor ID="Editor1" runat="server" Width="806px"  AutoConfigure="Simple">
                  </CE:Editor>
                  </td>
                 <td style=" width:50px"></td>
              </tr>
              
              <tr>
                  <td style=" width:50px"></td>
                  <td>
                  
                  </td>
                  <td>
                      <asp:Button ID="bthSumbit"  CssClass="button white" runat="server" Text="提 交" OnClick="bthSumbit_Click" />
                      <asp:Button ID="bthCancel" CssClass="button white" runat="server" Text="取 消" OnClick="bthCancel_Click" />
                  </td>
                 <td style=" width:50px"></td>
              </tr> 

             </table>
    </div>
    </form>
</body>
</html>
