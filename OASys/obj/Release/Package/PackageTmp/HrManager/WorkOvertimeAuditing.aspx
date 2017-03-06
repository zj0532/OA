<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkOvertimeAuditing.aspx.cs" Inherits="OASys.HrManager.WorkOvertimeAuditing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>加班审核</title>
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
    </script>
</head>
<body style="overflow:hidden;" scroll="no" onload="Show()">
    <form id="form1" runat="server">
     <table id="dg" title="加班审核" style="width:1030px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/workovertime/WorkOvertimeListhandler.ashx',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'usname',width:100,align:'center'">姓名</th>
                <th data-options="field:'holidayclass',width:100,align:'center'">申请类别</th>
                <th data-options="field:'postdate',width:160,align:'center'">申请时间</th>
                <th data-options="field:'begindate',width:160,align:'center'">开始时间</th>
                <th data-options="field:'enddate',width:160,align:'center'">结束时间</th>
                <th data-options="field:'Holiday',width:100,align:'center'">申请时长</th>
                <th data-options="field:'ShowInfo',width:100,align:'center'">详细</th>
                <th data-options="field:'Audit',width:100,align:'center'">审核</th>
                <th data-options="field:'atid',width:30,align:'center',hidden:'true'"  >id</th>
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

        function Audit(Atid,obj) {
           
            //$(function () { alert("AtID:"+$('#dg').datagrid('getSelected').atid + "审核通过") })
            $(function () {

                $.ajax({

                    type: "POST",

                    url: "../Ashx/Workovertime/WorkovertimeAuditedHandler.ashx",

                    data: { AtID: Atid,Stauts:obj},

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("reload");

                    },
                    error: function () {


                    }

                });

            });



        }
        

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

    </script>
<div id="hideDiv" style="display:none">    
 <%--加班div begin--%>
    <div id="dlg" class="easyui-dialog" closed="true" title="加班申请详细信息" style="width:500px;height:360px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                标题：
                </td>
                <td >
                    <input id="Text1" class="textbox03" readonly="true" style=" width:280px" type="text" value="加班" />     
                </td>
            </tr>
          

            <tr>
                <td >
                开始期限：
                </td>
                <td>
                <input id="txtQJBegin"   type="text" style=" width:280px;" />
                </td>
            </tr>
             <tr>
                <td >
                结束期限：
                </td>
                <td>
                <input id="txtQJEnd"   type="text" style=" width:280px" />
                </td>
            </tr>

             <tr>
                <td >
                总计：
                </td>
                <td>
                <input id="txtQJCount"  type="text" style=" width:150px" />小时
                </td>
            </tr>

            <tr>
                <td >
                加班事由：
                </td>
                <td>
                <textarea id="txtGZJJ" class="textbox03" cols="20" rows="4" style=" width:280px"></textarea>
                </td>
            </tr>

             <tr>
                <td >
                加班见证：
                </td>
                <td>
                <textarea id="txtJJR" class="textbox03" cols="20" rows="4" style=" width:280px"></textarea>
                </td>
            </tr>
        </table>

    </div>  
    <%--请假div end--%>
</div>
    </form>
</body>
</html>
