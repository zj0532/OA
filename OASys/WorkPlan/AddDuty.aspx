<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDuty.aspx.cs" Inherits="OASys.WorkPlan.AddDuty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加值班表</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body style="overflow:hidden;" scroll="no">
    <form id="form1" runat="server">
       
         <div style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="添加值班表" style="padding-left:20px">
              添加值班表
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="DutyTable.aspx">返回列表</a></div> 
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                <tr style="height:100px;">
                </tr>
                <tr>
                     <td style="width:200px"></td>
                     <td style="width:70px">
                        标题：
                     </td>
                     <td>
                           <input  id="txtTitle" runat="server" class="textbox03" style="width:500px" type="text"  value="" />
                     </td>
                 </tr>

                 <tr>
                     <td style="width:200px"></td>
                     <td>
                        开始时间：
                     </td>
                     <td>
                     <input  id="BeginDate" runat="server" class="easyui-datetimebox" style="width:506px" type="text"  value="" />
                     </td>
                 </tr>

                 <tr>
                     <td style="width:200px"></td>
                     <td>
                        结束时间：
                     </td>
                     <td>
                           <input  id="EndDate" runat="server" class="easyui-datetimebox" style="width:506px" type="text"  value="" />
                     </td>
                 </tr>

                  <tr>
                      <td style="width:200px"></td>
                     <td>
                        业务组：
                     </td>
                     <td>
                          <input  id="txtBusiness" runat="server" readonly="true" class="textbox03" style="width:500px" type="text"  value="" />
                     </td>
                 </tr>

                 

                 <tr>
                     <td style="width:200px">
                         </td>
                     <td>
                         上传文档：
                     </td>
                     <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="500px" />
                     </td>
                 </tr>



                  <tr>
                      <td >
                     </td>
                      <td>

                      </td>
                     <td>
                         <asp:Button ID="bthOK" CssClass="button white" runat="server" Text="提 交" OnClick="bthOK_Click" />
                         <asp:Button ID="bthCancel" CssClass="button white" runat="server" Text="取 消" OnClick="bthCancel_Click" />
                     </td>
                 </tr>
                 <tr style="height:150px">

                 </tr>



             </table>

    </div>

    </form>
</body>
</html>
