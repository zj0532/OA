<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanWorkAuditing.aspx.cs" Inherits="OASys.HrManager.PlanWorkAuditing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>计划性加班审核</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <table id="dg" title="计划性加班审核" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/Attendance/GetPlanWrokAuditingListHandler.ashx',method:'POST'">
        <thead>
            <tr>
                <th data-options="field:'Title',width:410">标题</th>
                <th data-options="field:'ApplyDate',width:150,align:'center'">申请时间</th>
                <th data-options="field:'UsName',width:150,align:'center'">申请人</th>
                <th data-options="field:'BusName',width:150,align:'center'">业务组</th>
                <th data-options="field:'Stauts',width:150,align:'center'">申请状态</th>
                <th data-options="field:'PWID',width:30,align:'center',hidden:'true'"  >PWID</th>
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
