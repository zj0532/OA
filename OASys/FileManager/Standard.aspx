<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Standard.aspx.cs" Inherits="OASys.FileManager.Standard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>制度规范</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="dg" title="项目组业务组分类" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/File/GetProjectNameListHandler.ashx',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'FCENAME',width:300">业务组名称</th>
                <th data-options="field:'style',width:700">标准格式</th>
            </tr>
           
        </thead>
        
    </table>

    


     <script type="text/javascript">
         $(function () {
             var pager = $('#dg').datagrid().datagrid('getPager');	// get the pager of datagrid
             pager.pagination({
                 buttons: [{
                     iconCls: 'icon-search',
                     handler: function () {
                         $('#dlgSearch').dialog('open')
                     }
                 }]
             });
         })



      </script>

    </form>
</body>
</html>
