<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Technical.aspx.cs" Inherits="OASys.FileManager.Technical" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>技术资料</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <table id="dg" title="技术资料分类" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'FceName',width:300">分类名称</th>
                <th data-options="field:'remark',width:700">简介</th>
            </tr>
        </thead>
    </table>

    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
        <input id="bthAddTechnical" class="button white" type="button" onclick="window.location.href = 'AddTechnical.aspx'" value="添加文档" />
    </div>


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

             $(function () {

                 $.ajax({

                     type: "POST",

                     url: "../Ashx/File/GetFileClassExplicitHandler.ashx",

                     data: { FcID: 2 },

                     dataType: "json",

                     success: function (data){

                         $("#dg").datagrid("loadData", data);
                     },
                     error: function ()
                     {alert("加载失败")}

                 });

             });


        </script>


    </form>
</body>
</html>
