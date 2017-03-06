<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeeklyReportList.aspx.cs" Inherits="OASys.FileManager.WeeklyReportList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
      <table id="dg" title="<%=BusinessIDName %>工作报告列表 <div style='float:right'><a href='WeeklyReport.aspx' class='a1'>返回列表</a></div>" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/File/GetFileListByBusIDHandler.ashx?BusID=<%=BusID%>',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'FileName',width:480">周报</th>
                <th data-options="field:'UsName',width:100,align:'center'">提交人</th>
                <th data-options="field:'FileDate',width:200,align:'center'">日期</th>
               
                <th data-options="field:'FileClass',width:100,align:'center'">类别</th>
                <th data-options="field:'DownLoad',width:100,align:'center'">下载</th>
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

             


            function Download(FlID)
            {
                 
                $(function () {

                    $.ajax({

                        type: "POST",

                        url: "../Ashx/File/DownLoadFileByFileIDHandler.ashx",

                        data: { FiID: FlID },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                window.location.href ="../ExportFile/"+comment["result"];

                            });

                        }

                    });
                });
            }
    </script>

    </form>
</body>
</html>
