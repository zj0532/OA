<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanWorkRecord.aspx.cs" Inherits="OASys.HrManager.PlanWorkRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>计划性加班历史记录</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../script/jquery-datatimebox.js"></script>
    <script>
        function Show() {
            document.getElementById("hideDiv").style.display = "block";

        }
    </script>
</head>
<body onload="Show()">
    <form id="form1" runat="server">
     <table id="dg" title="计划性加班历史记录" style="width:1046px; height: 460px"
            data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/Attendance/GetPlanWorkRecordHandler.ashx',method:'POST'">
            <thead>
                <tr>
                    <th data-options="field:'PwTitle',width:300,">标题</th>
                    <th data-options="field:'UsName',width:160,align:'center'">加班人</th>
                    <th data-options="field:'BeginDate',width:160,align:'center'">开始时间</th>
                    <th data-options="field:'EndDate',width:160,align:'center'">结束时间</th>
                    <th data-options="field:'Count',width:100,align:'center'">总计(时)</th>
                    <th data-options="field:'BusName',width:130,align:'center'">业务组</th>               
                </tr>

            </thead>

        </table>

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
                <td colspan="2" style="height:50px;text-align:right;">
                    
                
                    <input id="bthSearch" class="button white" type="button" value="查 询" onclick="SearchRecord()" />
                    <input id="bthExport" class="button white" type="button" value="导 出" onclick="ExportRecord()" />
                    <input id="bthCanel" class="button white" type="button" value="取 消" onclick="$('#dlgSearch').dialog('close')" />

                </td>
                
            </tr>
          

        </table>

    </div>  
  
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

            function SearchRecord()
            {
                $.ajax({

                    type: "POST",

                    url: "../Ashx/Attendance/SearchPlanWorkRecordHandler.ashx",

                    data: {
                        UsName: $("#txtUsname").val(),
                        BeginDate: $("#txtBeginDate").datetimebox("getValue"),
                        EndDate: $("#txtEndDate").datetimebox("getValue")
                        
                    },

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("loadData", data);
                        $("#txtBeginDate").datetimebox("setValue", "");
                        $("#txtEndDate").datetimebox("setValue", "");
                        $("#dlgSearch").dialog("close");
                    },
                    error: function () {
                        alert("操作失败！");

                    }

                });

               

            }

            function ExportRecord()
            {
                $.ajax({

                    type: "POST",

                    url: "../Ashx/Attendance/ExportPlanWorkRecordHandler.ashx",

                    data: {
                        UsName: $("#txtUsname").val(),
                        BeginDate: $("#txtBeginDate").datetimebox("getValue"),
                        EndDate: $("#txtEndDate").datetimebox("getValue")

                    },

                    dataType: "json",

                    success: function (data) {


                        $.each(data, function (commentIndex, comment) {
                            if (comment['result'] == 0) {
                                $.messager.alert("导出失败","导出计划性加班历史记录表失败！","error");

                            } else {
                                var obj = '../ExportEecel/' + comment['result'];

                                window.location.href = obj;

                            }


                        });
                        
                    },
                    error: function () {
                        alert("操作失败！");

                    }

                });
            }


        </script>   



    </form>
</body>
</html>
