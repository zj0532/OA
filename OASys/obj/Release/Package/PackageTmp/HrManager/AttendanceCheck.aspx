<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceCheck.aspx.cs" Inherits="OASys.HrManager.AttendanceCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>考勤记录考核</title>
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

         function ExportExlDay()
         {
             
             var ExBeginDate = $("#txtBeginDate").datetimebox("getValue");
             if (ExBeginDate == null ||$.trim(ExBeginDate)== "") {
                 alert("请在开始时间框中选择要查询的日期")
             }
             else
             {

                 $(function () {

                     $.ajax({

                         type: "GET",

                         url: "../Ashx/Attendance/GetAttendanceDayHandler.ashx",

                         data: { BeginDate: ExBeginDate },

                         dataType: "json",

                         success: function (data) {

                             $.each(data, function (commentIndex, comment) {
                                 if (comment['result'] == 1) {
                                     alert("导出成功,文档保存目录c:根目录");
                                 } else {
                                     alert("导出失败");
                                 }


                             });
                         }
                     });
                 });
             }
         }

         function ExportExlTime() {

             var ExBeginDate = $("#txtBeginDate").datetimebox("getValue");
             var ExEndDate = $("#txtEndDate").datetimebox("getValue");
             if (ExBeginDate == null || $.trim(ExBeginDate) == "") {
                 alert("请在开始时间框中选择要查询的开始日期")
             }
             else {

                 if (ExEndDate == null || $.trim(ExEndDate) == "") {
                     alert("请在开始时间框中选择要查询的结束日期")
                 }
                 else
                 {
                     $(function () {

                         $.ajax({

                             type: "GET",

                             url: "../Ashx/Attendance/GetAttendanceTimeHandler.ashx",

                             data: { BeginDate: ExBeginDate,EndDate:ExEndDate },

                             dataType: "json",

                             success: function (data) {

                                 $.each(data, function (commentIndex, comment) {
                                     if (comment['result'] == 1) {
                                         alert("导出成功,文档保存目录c:根目录");
                                     } else {
                                         alert("导出失败");
                                     }


                                 });
                             }
                         });
                     });

                 }
             }
         }



    </script>

</head>
<body style="overflow:hidden;" scroll="no" onload="Show()">
    <form id="form1" runat="server">
      <table id="dg" title="项目组考勤记录查询" style="width:1030px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../ashx/AttendanceCheckHandler.ashx',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'usname',width:146">姓名</th>
                <th data-options="field:'postCause',width:106">打卡类别</th>
                <th data-options="field:'postdate',width:206,align:'center'">打卡时间</th>
                <th data-options="field:'postip',width:206,align:'center'">登陆IP</th>
                <th data-options="field:'Remark',width:306">备注</th>
                <th data-options="field:'atid',width:70,align:'center',hidden:'true'"  >id</th>
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

        function SearchRecord()
        {
            var name = $("#txtUsname").val();
            var bedate = $("#txtBeginDate").datetimebox("getValue");
            var endate = $("#txtEndDate").datetimebox("getValue");
            var pip = $("#txtLoginIP").val();
            
            $(function () {
                $.ajax({

                    type: "POST",

                    url: "../Ashx/Attendance/SearchAttendanceHandler.ashx",

                    data: {
                        UsName: name,BeginDate:bedate,EndDate:endate,PostIp:pip

                    },

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("loadData", data);
                        $("#dlgSearch").dialog("close");
                    },
                    error: function () {
                        alert("操作失败！");

                    }

                });


            })
        }
        

    </script>

    <div id="hideDiv" style="display:none">

    
    <div id="dlgSearch" class="easyui-dialog" closed="true" title="考勤查询" style="width:500px;height:280px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                姓名：
                </td>
                <td >
                    <input id="txtUsname" class="textbox03" style=" width:280px" type="text" />     
                </td>
            </tr>
            <tr>
                <td >
                开始时间：
                </td>
                <td>
                <input id="txtBeginDate"   class="easyui-datetimebox" type="text" style="width:285px" />
                </td>
            </tr>
            
            <tr>
                <td >
                  结束时间：
                </td>
                <td>
                <input id="txtEndDate" class="easyui-datetimebox"  type="text" style="width:285px" />
                </td>
            </tr>
            
            <tr>
                <td>登陆IP：</td>
                <td>
                     <input id="txtLoginIP" class="textbox03" style=" width:280px" type="text" />  
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height:50px;text-align:right;">
                    
                
                    <input id="bthSearch" class="button white" type="button" value="查 询" onclick="SearchRecord()" />
                    
                    <input id="bthCanel" class="button white" type="button" value="取 消" onclick="$('#dlgSearch').dialog('close')" />

                </td>
                
            </tr>
            <tr>
                <td colspan="2" style="height:50px;text-align:right;">
                   <input id="bthExportDay" class="button white" type="button" value="导出日表" onclick="ExportExlDay()" />
                   <input id="bthExportMonth" class="button white" type="button" value="导出汇总表" onclick="ExportExlTime()" />

                </td>
                
            </tr>

        </table>

    </div>  


</div>

    </form>
</body>
</html>
