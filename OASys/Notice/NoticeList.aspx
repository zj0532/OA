<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="OASys.Notice.NoticeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> 通知公告列表</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <table id="dg" title="通知公告列表" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/Notice/GetNoticeListHandler.ashx',method:'POST'">
            <thead>
            <tr>
                <th data-options="field:'title',width:350">标题</th>
                <th data-options="field:'UsName',width:100,align:'center'">创建人</th>
                <th data-options="field:'CreateDate',width:120,align:'center'">提交时间</th>
                <th data-options="field:'BeginDate',width:120,align:'center'">有效期开始时间</th>
                <th data-options="field:'EndDate',width:120,align:'center'">有效期结束时间</th>
                <th data-options="field:'NoClass',width:100,align:'center'">通知类别</th>
                <th data-options="field:'Isfj',width:100,align:'center'">附件</th>
                <th data-options="field:'NoID',width:150,align:'center',hidden:'true'">WPID</th>
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

         function GetFile(FileID) {
             $(function () {

                 $.ajax({

                     type: "POST",

                     url: "../Ashx/Notice/DownLoadFileByNoIDHandler.ashx",

                     data: { NoID: FileID },

                     dataType: "json",

                     success: function (data) {
                         $.each(data, function (commentIndex, comment) {
                             window.location.href = "../ExportFile/" + comment["result"];
                         });
                     }

                 });
             })

         }



    </script>

    </form>
</body>
</html>
