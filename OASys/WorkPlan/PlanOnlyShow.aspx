<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanOnlyShow.aspx.cs" Inherits="OASys.WorkPlan.PlanOnlyShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>作业计划详细信息</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
     <style type="text/css">
        #txt04 {
            width: 350px;
        }
    </style>

    <script>
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        function IsNew() {
            var WPID = GetQueryString("wpid");

            $.ajax({

                type: "POST",

                url: "../Ashx/Plan/GetPlanByWPIDHandler.ashx",

                data: { WpID: WPID },

                dataType: "json",

                success: function (data) {

                    $.each(data, function (commentIndex, comment) {
                        $("#txtTitle").val(comment['Title']);
                        $("#txtTitle").attr("readonly", "true");
                        $("#txtCycle").val(comment['Cycle']);
                        $("#txtCycle").attr("readonly", "true");
                        $("#BeginDate").datebox("setValue", comment['BeginDate']);
                        $("#EndDate").datebox("setValue", comment['EndDate']);
                        $("#ShowOPL").show();
                        $("#AddOPL").show();
                    });
                },
                error: function () {
                    $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                }
            });

        }

        function DownLoadFile(obj) {

            $(function () {

                $.ajax({

                    type: "POST",

                    url: "../Ashx/Plan/DownLoadFileByWpIDHandler.ashx",

                    data: { Wpiid: obj },

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
</head>
<body onload="IsNew()">
    <form id="form1" runat="server">
     <div style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="作业计划" style="padding-left:20px">
              回复作业计划
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="PlanList.aspx">返回列表</a></div> 
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                 <tr>
                     <td style="width:50px"></td>
                     <td style="width:70px">
                        标题：
                     </td>
                     <td class="auto-style1">
                           <input  id="txtTitle" runat="server" class="textbox03" style="width:350px" type="text"  value="" />
                     </td>
                     <td class="auto-style2">
                        周期天期：
                     </td>
                     <td class="auto-style3">
                           <input  id="txtCycle" runat="server" class="textbox03" style="width:350px" type="text"  value="" />
                     </td>
                     <td></td>
                 </tr>

                 <tr>
                     <td style="width:50px"></td>
                     <td>
                        开始时间：
                     </td>
                     <td class="auto-style1">
                           <input  id="BeginDate" runat="server" class="easyui-datebox" style="width:356px" type="text"  value="" />
                     </td>
                      <td class="auto-style2">
                        结束时间：
                     </td>
                     <td class="auto-style3">
                           <input  id="EndDate" runat="server" class="easyui-datebox" style="width:357px" type="text"  value="" />
                     </td>
                     <td></td>
                 </tr>

                 <tr>
                     <td style="width:50px"></td>
                     <td>
                        
                     </td>
                     <td class="auto-style1;" style="text-align:right" colspan="3">                         
                         
                     </td>
                     <td></td>
                </tr>
                </table>
    </div>


    <div id="ShowOPL" style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="作业计划" style="padding-left:20px">
              计划每期应完成作业    
			 </div>
                  <div style="margin-left:auto;margin-right:auto;">
                    <table id="dg" style="width:1046px;" data-options="singleSelect:true,method:'POST'">
                     <thead>
                        <tr>
                        <th data-options="field:'Times',width:100,align:'center'">期数</th>
                        <th data-options="field:'WpiPlanInfo',width:410,align:'center'">本期计划内容</th>
                        <th data-options="field:'ShouldDate',width:150,align:'center'">本期预计回复时间</th>
                        <th data-options="field:'TruthDate',width:150,align:'center'">本期实际回复时间</th>
                        <th data-options="field:'IsReply',width:100,align:'center'">是否回复</th>
                        <th data-options="field:'IsFile',width:100,align:'center'">是否附件</th>
                        <th data-options="field:'WPIID',width:100,align:'center',hidden:'true'">WPIID</th>
                     </tr>
                   </thead>

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

       $(function () {

           $.ajax({

               type: "POST",

               url: "../Ashx/Plan/GetWorkPlanInfoByWpIDHandler.ashx",

               data: { Wpid: GetQueryString("wpid") },

               dataType: "json",

               success: function (data) {
                   $("#dg").datagrid("loadData", data);

               },
               error: function () {
                   $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
               }
           });
       });


       function CreateWorkPlan() {
           var C_title = $("#txtTitle").val();

           if (C_title == "") {
               $.messager.alert('标题错误', '作业计划标题不能为空！', 'error');
               return;
           }

           var C_Cycle = $("#txtCycle").val();
           if (isNaN(C_Cycle)) {
               $.messager.alert('周期天数错误', '作业计划周期天数必需为数值！', 'error');
               return;
           }

           var C_beDate = $("#BeginDate").datebox("getValue");
           var c_endDate = $("#EndDate").datebox("getValue");

           $.ajax({

               type: "POST",

               url: "../Ashx/Plan/CreateWorkPlanHandler.ashx",

               data: { Title: C_title, Cycle: C_Cycle, BDate: C_beDate, EDate: c_endDate },

               dataType: "json",

               success: function (data) {

                   $.each(data, function (commentIndex, comment) {
                       if (comment['Result'] == 0) {
                           $.messager.alert('添加失败', comment['Message'], 'error');
                       }
                       else {
                           window.location.href = 'AddPlan.aspx?WpID=' + comment['Result'];

                       }

                   });
               },
               error: function () {
                   $.messager.alert('添加失败', '发生未知错误，请重新安装！', 'error');
               }
           });
       }


       function AddWorkPlanInfo() {
           var A_Ntimes = $("#txtQs").val();
           if (isNaN(A_Ntimes)) {
               $.messager.alert('期数错误', '期数必需为数值！', 'error');
               return;
           }
           var A_Shouldtime = $("#ShouldDate").datebox("getValue");
           var A_Content = $("#txtContent").val();
           $.ajax({

               type: "POST",

               url: "../Ashx/Plan/CreateWorkPlanInfoHandler.ashx",

               data: { Times: A_Ntimes, ShouldTime: A_Shouldtime, Content: A_Content, Wpid: GetQueryString("WpID") },

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

                                   url: "../Ashx/Plan/GetWorkPlanInfoByWpIDHandler.ashx",

                                   data: { Wpid: GetQueryString("WpID") },

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

       function LookInfo(Wp_iid) {
           $(function () {

               $.ajax({

                   type: "POST",

                   url: "../Ashx/Plan/GetWPIContentHandler.ashx",

                   data: { Wpiid: Wp_iid },

                   dataType: "json",

                   success: function (data) {
                       $.each(data, function (commentIndex, comment) {

                           $("#tdShowInfo").html(comment["WPIPlanInfo"]);
                           $("#tdShowReplyInfo").html(comment["WPIContent"]);
                           if (comment["FileName"] != "") {
                               $("#tdFileInfo").html("<a href='#' class='a1' title='点击下载' onclick='DownLoadFile(" + comment["WPIID"] + ")'>点此下载附件</a>");
                           }
                           $("#dlg").dialog("open");

                       });
                   },
                   error: function () {
                       $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                   }
               });
           });
       }

        </script>

   <div id="dlg" class="easyui-dialog" closed="true" title="显示作业计划任务信息"  style="width:600px; height:300px;padding:10px;" >
    <table style="margin:20px">
        <tr>
            <td style="border-bottom:dashed 1px #ccc;width:70px;">计划任务：</td>
            <td id="tdShowInfo" style="border-bottom:dashed 1px #ccc;width:87%"></td>
        </tr>
         <tr>
            <td style="border-bottom:dashed 1px #ccc">回复信息：</td>
            <td id="tdShowReplyInfo" style="border-bottom:dashed 1px #ccc;width:87%"></td>
        </tr>
         <tr>
            <td style="border-bottom:dashed 1px #ccc">输出文档：</td>
            <td id="tdFileInfo" style="border-bottom:dashed 1px #ccc;width:87%"></td>
        </tr>

    </table>
    </div>

    </form>
</body>
</html>
