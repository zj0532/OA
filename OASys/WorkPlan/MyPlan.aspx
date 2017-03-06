<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPlan.aspx.cs" Inherits="OASys.WorkPlan.MyPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的作业计划</title>
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
<body onload="Show()">
    <form id="form1" runat="server">

      
      <table id="dg" title="我的作业计划" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../ashx/plan/GetPlanListByUserIDHandler.ashx',method:'POST'">
            <thead>
            <tr>
                <th data-options="field:'title',width:320">标题</th>
                <th data-options="field:'UsName',width:100,align:'center'">创建人</th>
                <th data-options="field:'CreateDate',width:120,align:'center'">提交时间</th>
                <th data-options="field:'BeginDate',width:120,align:'center'">开始时间</th>
                <th data-options="field:'EndDate',width:120,align:'center'">结束时间</th>
                <th data-options="field:'Cycle',width:100,align:'center'">周期(单位:天)</th>
                <th data-options="field:'Isfj',width:100,align:'center'">附件</th>
                <th data-options="field:'WPID',width:150,align:'center',hidden:'true'">WPID</th>
            </tr>  
        </thead>
        
    </table> 

    <div id="hideDiv" style="display:none">

     <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
            <input id="bthAddReport" class="button white" type="button" onclick="GetHref(0)" value="添加作业计划" />  
            <input id="bthSearch" class="button white" type="button" onclick="$('#dlgSearch').dialog('open')" value="搜索作业计划" />          
    </div>
  
     <div id="dlgSearch" class="easyui-dialog" closed="true" title="搜索作业计划" style="width:500px;height:220px;padding:10px; padding-top:30px">
        <table>
            <tr>
                <td style="width:30px">

                </td>
                <td >
                   计划标题：
                </td>
                <td>
                    <input id="txtTitle" class="textbox03" style=" width:300px" type="text" />

                </td>
            </tr>
            <tr>
                <td ></td>
                <td>
                  开始时间：
                </td>
                <td>
                  <input id="BeginDate"  class="easyui-datetimebox" style="width:306px"  />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>结束时间：</td>
                <td>
                     <input id="EndDate"  class="easyui-datetimebox" style="width:306px"  />
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2" style="height:50px;text-align:right;">
                    <input id="bthDlgSearch" class="button white" type="button" value="搜 索" onclick="SearchResult()" />
                    <input id="bthDlgCanel" class="button white" type="button" value="取 消" onclick="$('#dlgSearch').dialog('close')" />

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


         function GetHref(obj)
         {
             window.location.href = "AddPlan.aspx?WpID="+obj;
         }

         function SearchResult()
         {
             $(function () {

                 $.ajax({

                     type: "POST",

                     url: "../Ashx/Plan/SearchPlanByUsIDHandler.ashx",

                     data: { txtTitleValue: $("#txtTitle").val(), BeginDateValue: $('#BeginDate').datetimebox("getValue"), EndDateValue: $('#EndDate').datetimebox("getValue") },

                     dataType: "json",

                     success: function (data) {
                         $("#dg").datagrid("loadData", data);
                         $("#dlgSearch").dialog("close");
                            },
                            error: function () {
                                alert('数据读取失败')

                            }

                        });

              });

         }


    </script>




    </form>
</body>
</html>
