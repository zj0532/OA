<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MdyPlanWrok.aspx.cs" Inherits="OASys.HrManager.MdyPlanWrok" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改计划性加班申请</title>
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

        function IsNew() {

            var pwid = GetQueryString("PWID");

            if (pwid == 0) {

                $("#ShowOPL").hide();
                $("#AddOPL").hide();
            }
            else {

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

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="计划性加班申请表" style="padding-left:20px">
              计划性加班申请表
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="PlanWorkApply.aspx">返回列表</a></div> 
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                 <tr>
                     <td style="width:50px"></td>
                     <td style="width:70px">
                        标题：
                     </td>
                     <td class="auto-style1">
                           <input  id="txtTitle" runat="server" class="textbox03" style="width:100%" type="text"  value="" />
                     </td>
                    
                 </tr>
              
                 <tr>
                     <td style="width:50px"></td>
                     <td>
                        
                     </td>
                     <td class="auto-style1;" style="text-align:right" colspan="3">                         
                         <input id="CreateInfo" class="button white" type="button" onclick="CreatePlanWork()" value="添加加班明细" />
                     </td>
                     <td></td>
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
                        <th data-options="field:'UsName',width:200,align:'center'">姓名</th>
                        <th data-options="field:'BeginDate',width:200,align:'center'">开始时间</th>
                        <th data-options="field:'EndDate',width:200,align:'center'">结束时间</th>
                        <th data-options="field:'Count',width:200,align:'center'">总计(时)</th>
                        <th data-options="field:'DelContent',width:200,align:'center'">删除</th>
                     </tr>
                   </thead>

                 </table>

                  </div>
             </div>

         <div id="AddOPL" style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="计划性加班" style="padding-left:20px">
             添加加班明细
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                       加班人姓名：
                     </td>
                     <td>
                         <input  id="txtUsName"  class="textbox03" style="width:450px" type="text"  value="" />
                     </td>
                 </tr>
                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                        开始时间：
                     </td>
                     <td>
                        <input  id="BeginDate" class="easyui-datetimebox" style="width:456px" type="text"  value="" />
                     </td>
                 </tr>

                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                        结束时间：
                     </td>
                     <td>
                        <input  id="EndDate" class="easyui-datetimebox" style="width:456px" type="text"  value="" />
                     </td>
                 </tr>
          
                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                        总计：
                     </td>
                     <td>
                         <input  id="txtContent"  class="textbox03" style="width:450px" type="text"  value="" />小时
                        
                     </td>
                 </tr>

                  <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                     
                     </td>
                     <td>
                        <input id="AddInfo" class="button white" type="button" onclick="AddWorkPlanInfo()" value="添 加" />
                     </td>
                 </tr>


       </table>
       </div>
        <div id="DivButton" style="width: 99%; height: auto;  left: 0; bottom: 0; padding:5px; text-align:right ">
            <input id="bthMdyPlanWrok" class="button white" type="button" onclick="ResetSubmit()" value="重新提交" />
            
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


         function CreatePlanWork() {
             var C_title = $("#txtTitle").val();

             if (C_title == "") {
                 $.messager.alert('标题错误', '作业计划标题不能为空！', 'error');
                 return;
             }

             $.ajax({

                 type: "POST",

                 url: "../Ashx/Attendance/CreatePlanWorkHandler.ashx",

                 data: { Title: C_title },

                 dataType: "json",

                 success: function (data) {

                     $.each(data, function (commentIndex, comment) {
                         if (comment['Result'] == 0) {
                             $.messager.alert('添加失败', comment['Message'], 'error');
                         }
                         else {
                             window.location.href = 'AddPlanWrok.aspx?PWID=' + comment['result'];

                         }

                     });
                 },
                 error: function () {
                     $.messager.alert('添加失败', '发生未知错误，请重新安装！', 'error');
                 }
             });
         }


         function AddWorkPlanInfo() {
             var h_Count = $("#txtContent").val();
             if (isNaN(h_Count)) {
                 $.messager.alert('总计错误', '总计必需为数值！', 'error');
                 return;
             }

             $.ajax({

                 type: "POST",

                 url: "../Ashx/Attendance/CreatePlanWorkInfoHandler.ashx",

                 data: { Usname: $("#txtUsName").val(), BeginDate: $("#BeginDate").datebox("getValue"), EndDate: $("#EndDate").datebox("getValue"), PWID: GetQueryString("PWID"), HCount: h_Count },

                 dataType: "json",

                 success: function (data) {
                     $.each(data, function (commentIndex, comment) {
                         if (comment['Result'] == 0) {
                             $.messager.alert('添加失败', comment['Message'], 'error');
                         }
                         else {
                             //读取文档信息begin、
                             $(function () {

                                 $.ajax({

                                     type: "POST",

                                     url: "../Ashx/Attendance/GetPlanWorkInfoByWpIDHandler.ashx",

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

                             //读取文档信息end、

                         }

                     });
                 },
                 error: function () {
                     $.messager.alert('添加失败', '发生未知错误，请重新安装！', 'error');
                 }
             });
         }


         function DelPlan(pwlid) {
             $(function () {

                 $.ajax({

                     type: "POST",

                     url: "../Ashx/Attendance/DelPWIContentHandler.ashx",

                     data: { PWLID: pwlid },

                     dataType: "json",

                     success: function (data) {
                         //读取文档信息begin、
                         $(function () {

                             $.ajax({

                                 type: "POST",

                                 url: "../Ashx/Attendance/GetPlanWorkInfoByWpIDHandler.ashx",

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

                         //读取文档信息end、
                     },
                     error: function () {
                         $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                     }
                 });
             });
         }

         function ResetSubmit()
         {
             $.ajax({

                 type: "POST",

                 url: "../Ashx/Attendance/ResetPlanWorkApplyHandler.ashx",

                 data: { PWID: GetQueryString("PWID") },

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


    </script>  
    </form>
</body>
</html>
