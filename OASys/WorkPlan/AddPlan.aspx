<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPlan.aspx.cs" Inherits="OASys.WorkPlan.AddPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>操作作业计划</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script>
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function IsNew() {
            var WPID = GetQueryString("WpID");
            if (WPID == 0) {
                $("#ShowOPL").hide();
                $("#AddOPL").hide();
            }
            else {
                $.ajax({

                    type: "POST",

                    url: "../Ashx/Plan/GetPlanByWPIDHandler.ashx",

                    data: {WpID:WPID},

                    dataType: "json",

                    success: function (data) {

                        $.each(data, function (commentIndex, comment) {
                            $("#txtTitle").val(comment['Title']);
                            $("#txtTitle").attr("readonly", "true");
                            $("#txtCycle").val(comment['Cycle']);
                            $("#txtCycle").attr("readonly", "true");
                            $("#BeginDate").datebox("setValue", comment['BeginDate']);
                            $("#EndDate").datebox("setValue",comment['EndDate']);
                            $("#ShowOPL").show();
                            $("#AddOPL").show();
                        });
                    },
                    error: function ()
                    {
                        $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                    }
                });

            }

        }


    </script>
    <style type="text/css">
        .auto-style1 {
            width: 380px;
        }
        .auto-style2 {
            width: 70px;
        }
        .auto-style3 {
            width: 341px;
        }
    </style>

</head>
<body onload="IsNew()">
    <form id="form1" runat="server">
    <div style="width:1046px;margin-right:20px;margin-bottom:20px;">
			 <div  class="panel-header"  title="作业计划" style="padding-left:20px">
              <%=PageSetName%>
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="MyPlan.aspx">返回列表</a></div> 
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
                        周期天数：
                     </td>
                     <td class="auto-style3">
                           <input  id="txtCycle" runat="server" class="textbox03" style="width:350px" type="text"  value="" />
                     </td>
                     <td></td>
                 </tr>

                 <tr>
                     <td style="width:50px"></td>
                     <td>
                        开始日期：
                     </td>
                     <td class="auto-style1">
                           <input  id="BeginDate" runat="server" class="easyui-datebox" style="width:356px" type="text"  value="" />
                     </td>
                      <td class="auto-style2">
                        结束日期：
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
                         <input id="CreateInfo" class="button white" type="button" onclick="CreateWorkPlan()" value="添加明细" />
                     </td>
                     <td></td>
                </tr>
                </table>
    </div>


    <div id="ShowOPL" style="width:1046px;margin-right:20px;margin-bottom:20px;display:none">
			 <div  class="panel-header"  title="作业计划" style="padding-left:20px">
              计划每期应完成作业    
			 </div>
                  <div style="margin-left:auto;margin-right:auto;">
                    <table id="dg" style="width:1046px;" data-options="singleSelect:true,method:'POST'">
                     <thead>
                        <tr>

                        <th data-options="field:'Times',width:100,align:'center'">期数</th>
                        <th data-options="field:'WpiPlanInfo',width:610,align:'center'">本期计划内容</th>
                        <th data-options="field:'ShouldDate',width:200,align:'center'">本期预计回复时间</th>
                        <th data-options="field:'DelContent',width:100,align:'center'">删除</th>
                     </tr>
                   </thead>

                 </table>

                  </div>
   </div>
    
    <div id="AddOPL" style="width:1046px;margin-right:20px;margin-bottom:20px;display:none">
			 <div  class="panel-header"  title="作业计划" style="padding-left:20px">
             添加每期应完成作业    
			 </div>
      <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; height:100%;" >
                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                        期数：
                     </td>
                     <td>
                         <input  id="txtQs"  class="textbox03" style="width:450px" type="text"  value="" />
                     </td>
                 </tr>
                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                        本期回复时间：
                     </td>
                     <td>
                        <input  id="ShouldDate" class="easyui-datebox" style="width:456px" type="text"  value="" />
                     </td>
                 </tr>
          
                 <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                        本期作业计划：
                     </td>
                     <td>
                        <textarea id="txtContent" cols="20" rows="10" style="width:450px"></textarea>
                     </td>
                 </tr>

                  <tr>
                     <td style="width:200px"></td>
                     <td style="width:100px">
                     
                     </td>
                     <td>
                        <input id="AddInfo" class="button white" type="button" onclick="AddWorkPlanInfo()" value="添加计划" />
                     </td>
                 </tr>


       </table>
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

                 data: {Wpid:GetQueryString("WpID")},

                 dataType: "json",

                 success: function (data) {
                     $("#dg").datagrid("loadData", data);
                  
                 },
                 error: function ()
                 {
                     $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                 }
             });
         });


         function CreateWorkPlan()
         {
             var C_title = $("#txtTitle").val();
            
             if ( C_title=="")
             {
                 $.messager.alert('标题错误', '作业计划标题不能为空！', 'error');
                 return;
             }

             var C_Cycle = $("#txtCycle").val();
             if(isNaN(C_Cycle))
             {
                 $.messager.alert('周期天数错误', '作业计划周期天数必需为数值！', 'error');
                 return;
             }

             var C_beDate = $("#BeginDate").datebox("getValue");
             var c_endDate = $("#EndDate").datebox("getValue");
             
             $.ajax({

                 type: "POST",

                 url: "../Ashx/Plan/CreateWorkPlanHandler.ashx",

                 data: { Title:C_title,Cycle:C_Cycle,BDate:C_beDate,EDate:c_endDate},

                 dataType: "json",

                 success: function (data) {

                     $.each(data, function (commentIndex, comment) {
                         if (comment['Result'] == 0)
                         {
                             $.messager.alert('添加失败', comment['Message'], 'error');
                         }
                         else
                         {
                             window.location.href = 'AddPlan.aspx?WpID=' + comment['Result'];
                            
                         }

                     });
                 },
                 error: function ()
                 {
                     $.messager.alert('添加失败', '发生未知错误，请重新安装！', 'error');
                 }
             });
         }
         

         function AddWorkPlanInfo()
         {
             var A_Ntimes = $("#txtQs").val();
             if (isNaN(A_Ntimes))
             {
                 $.messager.alert('期数错误', '期数必需为数值！', 'error');
                 return;
             }
             var A_Shouldtime = $("#ShouldDate").datebox("getValue");
             var A_Content = $("#txtContent").val();
             $.ajax({

                 type: "POST",

                 url: "../Ashx/Plan/CreateWorkPlanInfoHandler.ashx",

                 data: { Times: A_Ntimes, ShouldTime: A_Shouldtime, Content: A_Content,Wpid:GetQueryString("WpID") },

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

         function LookInfo(Wp_iid)
         {
             $(function () {

                 $.ajax({

                     type: "POST",

                     url: "../Ashx/Plan/GetWPIContentHandler.ashx",

                     data: { Wpiid: Wp_iid },

                     dataType: "json",

                     success: function (data) {
                         $.each(data, function (commentIndex, comment) {
                             
                             $("#tdShowInfo").html(comment["WPIPlanInfo"]);
                             $("#dlg").dialog("open");

                         });
                     },
                     error: function () {
                         $.messager.alert('读取失败', '读取明细失败，请退出重新登！', 'error');
                     }
                 });
             });
         }
        
         function DelPlan(Wp_iid)
         {
             $(function () {

                 $.ajax({

                     type: "POST",

                     url: "../Ashx/Plan/DelWPIContentHandler.ashx",

                     data: { Wpiid: Wp_iid },

                     dataType: "json",

                     success: function (data) {
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
            <td id="tdShowInfo"></td>
        </tr>

    </table>
    </div>
    

    </form>
</body>
</html>
