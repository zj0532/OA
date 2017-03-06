﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayHistory.aspx.cs" Inherits="OASys.HrManager.HolidayHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目组请假历史记录</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtBeginDate").datebox({

                formatter: function (date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + "-" + (m < 10 ? ("0" + m) : m) + "-" + (d < 10 ? ("0" + d) : d);
                }


            });
        });

        $(function () {
            $("#txtEndDate").datebox({

                formatter: function (date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + "-" + (m < 10 ? ("0" + m) : m) + "-" + (d < 10 ? ("0" + d) : d);
                }


            });
        });

        function Show() {
            document.getElementById("hideDiv").style.display = "block";

        }

       

    </script>



</head>
<body style="overflow: hidden;" scroll="no" onload="Show()">
    <form id="form1" runat="server">
        <table id="dg" title="项目组请假历史记录" style="width: 1030px; height: 460px"
            data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/holiday/HolidayHistoryHandler.ashx',method:'POST'">
            <thead>
                <tr>
                    <th data-options="field:'usname',width:100,align:'center'">姓名</th>
                    <th data-options="field:'holidayclass',width:100,align:'center'">申请类别</th>
                    <th data-options="field:'postdate',width:160,align:'center'">申请时间</th>
                    <th data-options="field:'begindate',width:160,align:'center'">开始时间</th>
                    <th data-options="field:'enddate',width:160,align:'center'">结束时间</th>
                    <th data-options="field:'Holiday',width:100,align:'center'">申请时长</th>
                    <th data-options="field:'ShowInfo',width:100,align:'center'">详细</th>
                    <th data-options="field:'Audit',width:100,align:'center'">状态</th>
                    <th data-options="field:'atid',width:30,align:'center',hidden:'true'">id</th>
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


            function show(obj) {
                $(function () {

                    $.ajax({

                        type: "POST",

                        url: "../Ashx/Holiday/GetHolidayByATIDHandler.ashx",

                        data: { atid: obj },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                $("#txtQJClass").val(comment["holidayclass"]);
                                $("#txtQJBegin").val(comment["begindate"]);
                                $("#txtQJEnd").val(comment["enddate"]);

                                $("#txtQJCount").val(comment["holiday"]);
                                $("#txtGZJJ").val(comment["workcontent"]);
                                $("#txtJJR").val(comment["workpeson"]);
                            });

                        },
                        error: function () {


                        }

                    });

                });


                $('#dlg').dialog('open');
            }


            function Search() {
                var name = $('#txtUsname').val();
                var bedate = $('#txtBeginDate').datetimebox("getValue");
                var enddate = $('#txtEndDate').datetimebox("getValue");
                var holidayclass = $('#txtHolidayCLass').val();

               
                $(function () {

                    $.ajax({

                        type: "POST",

                        url: "../Ashx/holiday/HolidayHistorySearchHandler.ashx",

                        data: { UsName:name,BeginDate:bedate,EndDate:enddate,HolidayClass:holidayclass },

                        dataType: "json",

                        success: function (data) {
                            $("#dg").datagrid("loadData", data);
                            $("#dlgSearch").dialog("close");
                        },
                        error: function () {
                            alert("操作失败！");

                        }

                    });

                });


            }

            function ExportFun() {
              
                 $(function () {

                     $.ajax({

                         type: "POST",

                         url: "../Ashx/holiday/HolidayHistoryExportHandler.ashx",

                         data: { UsName: $("#txtUsname").val(), BeginDate: $('#txtBeginDate').datetimebox("getValue"), EndDate: $('#txtEndDate').datetimebox("getValue"), HolidayClass: $('#txtHolidayCLass').val() },

                         dataType: "json",

                         success: function (data) {
                             $.each(data, function (commentIndex, comment) {
                                 if (comment['result'] == 0) {
                                     alert("导出失败");

                                 } else {

                                     window.location.href = '../ExportEecel/' + comment['result'];

                                 }


                             });
                         },
                         error: function () {
                             alert("操作失败！");

                         }

                     });

                 });




            }



        </script>


        <div id="hideDiv" style="display:none">


        <div id="dlgSearch" class="easyui-dialog" closed="true" title="请假历史记录查询" style="width: 500px; height: 280px; padding: 50px; padding-top: 30px">
            <table>
                <tr>
                    <td style="width: 60px">姓名：
                    </td>
                    <td>
                        <input id="txtUsname" class="textbox03" style="width: 280px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>开始时间：
                    </td>
                    <td>
                         <input id="txtBeginDate"  type="text" style="width:285px" />
                       
                    </td>
                </tr>

                <tr>
                    <td>结束时间：
                    </td>
                    <td>
                        <input id="txtEndDate" type="text" style="width: 285px" />
                    </td>
                </tr>

                <tr>
                    <td>请假类型：</td>
                    <td>
                        <input id="txtHolidayCLass" class="textbox03" style="width: 280px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 50px; text-align: right;">
                        <input id="bthSearch" class="button white" type="button" value="查 询" onclick="Search()" />
                        <input id="ExportExl" class="button white" type="button" onclick="ExportFun()" value="导 出" />
                        <input id="Button2" class="button white" type="button" value="取 消" onclick="$('#dlgSearch').dialog('close')" />

                    </td>

                </tr>

            </table>

        </div>


        <%--请假div begin--%>
        <div id="dlg" class="easyui-dialog" closed="true" title="请假申请详细信息" style="width: 500px; height: 380px; padding: 50px; padding-top: 30px">
            <table>
                <tr>
                    <td style="width: 60px">标题：
                    </td>
                    <td>
                        <input id="Text1" class="textbox03" readonly="true" style="width: 280px" type="text" value="请假" />
                    </td>
                </tr>
                <tr>
                    <td>请假类别：
                    </td>
                    <td>
                        <input id="txtQJClass" class="textbox03" type="text" style="width: 280px" />
                    </td>
                </tr>

                <tr>
                    <td>开始期限：
                    </td>
                    <td>
                        <input id="txtQJBegin" type="text" style="width: 280px;" />
                    </td>
                </tr>
                <tr>
                    <td>结束期限：
                    </td>
                    <td>
                        <input id="txtQJEnd" type="text" style="width: 280px" />
                    </td>
                </tr>

                <tr>
                    <td>总计：
                    </td>
                    <td>
                        <input id="txtQJCount" type="text" style="width: 150px" />小时
                    </td>
                </tr>

                <tr>
                    <td>请假事由：
                    </td>
                    <td>
                        <textarea id="txtGZJJ" class="textbox03" cols="20" rows="4" style="width: 280px"></textarea>
                    </td>
                </tr>

                <tr>
                    <td>工作交接及交接人：
                    </td>
                    <td>
                       
                        <textarea id="txtJJR" class="textbox03" cols="20" rows="4" style="width: 280px"></textarea>
                    </td>
                </tr>
            </table>

        </div>
        <%--请假div end--%>

 </div>
       
        
        
    </form>
</body>
</html>
