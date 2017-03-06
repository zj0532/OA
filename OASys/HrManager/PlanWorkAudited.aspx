<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanWorkAudited.aspx.cs" Inherits="OASys.HrManager.PlanWorkAudited" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>计划性加班申请详细信息</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../script/jquery-datatimebox.js"></script>
    <script>
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function GetLoad()
        {
            $.ajax({

                type: "POST",

                url: "../Ashx/Attendance/GetPlanWrokHandler.ashx",

                data: { PWID: GetQueryString("PWID") },

                dataType: "json",

                success: function (data) {
                    $.each(data, function (commentIndex, comment) {
                        $("#txtTitle").val(comment['Title']);
                        $("#txtTitle").attr("readonly", "true");
                        $("#ShowOPL").show();
                        $("#AddOPL").show();
                       
                    });
                },
                error: function () {
                    $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                }
            });


        }

    </script>
</head>
<body onload="GetLoad()">
    <form id="form1" runat="server">
      <div style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="计划性加班申请表详细信息" style="padding-left:20px">
              计划性加班申请表详细信息
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="PlanWorkAuditing.aspx">返回列表</a></div> 
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                 <tr>
                     <td style="width:50px"></td>
                     <td style="width:70px">
                        标题：
                     </td>
                     <td class="auto-style1">
                           <input  id="txtTitle" runat="server" readonly="true" class="textbox03" style="width:98%" type="text"  value="" />
                     </td>
                    
                 </tr>
              
                 <tr>
                     
                </tr>
                </table>
        </div>

         <div id="ShowOPL" style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="加班明细表" style="padding-left:20px">
              申请加班明细表    
			 </div>
                  <div style="margin-left:auto;margin-right:auto;">
                    <table id="dg" style="width:1046px;" data-options="singleSelect:true,method:'POST'">
                     <thead>
                        <tr>
                        <th data-options="field:'UsName',width:250,align:'center'">姓名</th>
                        <th data-options="field:'BeginDate',width:250,align:'center'">开始时间</th>
                        <th data-options="field:'EndDate',width:250,align:'center'">结束时间</th>
                        <th data-options="field:'Count',width:280,align:'center'">总计(时)</th>
                        <th data-options="field:'PWLID',width:200,align:'center',hidden:'true'">字段ID</th>
                     </tr>
                   </thead>

                 </table>

                  </div>
             </div>

        <div id="DivButton" style="width: 99%; height: auto;  left: 0; bottom: 0; padding:5px; text-align:right ">
            <input id="bthAddPlanWrok" class="button white" type="button" onclick="JudeApply(1)" value="申请通过" />
            <input id="bthMdyPlanWrok" class="button white" type="button" onclick="JudeApply(0)" value="拒绝申请" />
        </div>

        <script>
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

                    url: "../ashx/Attendance/GetPlanWorkInfoByWpIDHandler.ashx",

                    data: { PWID: GetQueryString("PWID") },

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("loadData", data);

                    },
                    error: function () {
                        $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                    }
                });
            });

            function JudeApply(obj)
            {
                var sMsg;
                if (obj == 0) {
                    
                    $.messager.prompt('拒绝原因', '请在文本框中写明拒绝原因，以方便申请人修改！', function(sMsg){
                        if (sMsg) {
                            //alert(sMsg);
                            //拒绝申请。原因参数sMsg
                            $.ajax({

                                type: "POST",

                                url: "../ashx/Attendance/PlanWorkAuditByPwidHandler.ashx",

                                data: { PWID: GetQueryString("PWID"), Result: obj, Remark: sMsg },

                                dataType: "json",

                                success: function (data) {
                                    $.each(data, function (commentIndex, comment) {
                                        $.messager.alert('提示信息', comment['Result'], 'info');
                                    });
                                },
                                error: function () {
                                    $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                                }
                            });

                        }
                        else {
                            $.messager.alert("操作提示", "如果不填写拒绝原因,系统将默认放弃本次操作！", "info");
                        }

                    })
                    
                }
                else {
                    //申请通过
                    sMsg = "";
                    $.ajax({

                        type: "POST",

                        url: "../ashx/Attendance/PlanWorkAuditByPwidHandler.ashx",

                        data: { PWID: GetQueryString("PWID"), Result: obj, Remark: sMsg },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                $.messager.alert('提示信息', comment['Result'], 'info');
                            });
                        },
                        error: function () {
                            $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                        }
                    });
                }

                


            }
        </script>



    </form>
</body>
</html>
