<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetSummary.aspx.cs" Inherits="OASys.FileManager.MeetSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会议纪要</title>
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
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/File/GetMeetListHandler.ashx',method:'POST'">
        <thead>
            <tr>
                <th data-options="field:'Title',width:400">标题</th>
                <th data-options="field:'MSDate',width:150,align:'center'">会议时间</th>
                <th data-options="field:'MSAddress',width:100,align:'center'">会议地点</th>
                <th data-options="field:'UsName',width:100,align:'center'">提交人</th>
                <th data-options="field:'Remark',width:150,align:'center'">提交时间</th>
                <th data-options="field:'DownLoad',width:95,align:'center'">下载</th>
                <th data-options="field:'MsID',width:50,align:'center',hidden:'true'"  >MsID</th>
            </tr>
           
        </thead>
        
    </table>

    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
        <input id="bthAddMeet" class="button white" type="button" onclick="window.location.href='AddAndMeet.aspx'"  value="添加纪要" />
        
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

      
       function Download(obj)
       {
           $(function () {

               $.ajax({

                   type: "POST",

                   url: "../Ashx/File/DownLoadSummaryByMsIDHandler.ashx",

                   data: { MsID: obj },

                   dataType: "json",

                   success: function (data) {
                       $.each(data, function (commentIndex, comment) {
                           window.location.href = "../ExportFile/" + comment["result"];

                       });

                   }

               });
           });

       }
       
      </script>

    </form>
</body>
</html>
