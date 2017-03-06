<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayManager.aspx.cs" Inherits="OASys.HrManager.HolidayManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>请假假期管理</title>
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
<body  onload="Show()" > 
    <form id="form1" runat="server">
    <table id="dg" title="请假假期管理" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/Attendance/GetHolidayListHandler.ashx',method:'POST'">
        <thead>
            <tr>
                <th data-options="field:'itemid',width:120,align:'center'">姓名</th>
                <th data-options="field:'productid',width:100,align:'center'">职务</th>
                <th data-options="field:'listprice',width:100,align:'center'">业务组</th>
                <th data-options="field:'office',width:260,align:'center'">办公地点</th>
                <th data-options="field:'nianjia',width:160,align:'center'">年假时间</th>
                <th data-options="field:'tiaoxiu',width:160,align:'center'">可调休时间</th>
                <th data-options="field:'modify',width:70,align:'center'">修改</th>
                <th data-options="field:'usid',width:70,align:'center',hidden:'true'"  >usid</th>
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
    </script>

    <script>

        function ModifyHoliday(UsID)
        {
            $('#dlgUpdate').dialog('open');
            $.ajax({

                type: "POST",
                async: false,
                url: "../Ashx/Attendance/UserHolidaySettingByUsIDHandler.ashx",

                data: {
                    UserID: UsID,Sigh:'Get',NianJia:'0',TiaoXiu:'0'
                },

                dataType: "json",

                success: function (data) {
                   
                    $.each(data, function (commentIndex, comment) {
                        $("#hidUsID").val(comment["usid"]);
                        $("#txtNameUpd").val(comment["UsName"]);
                        $("#txtNianJiaUpd").val(comment["NianJia"]);
                        $("#txtTiaoXiuUpd").val(comment["TiaoXiu"]);
                        
                    });
                },
                error: function () {
                    alert("读取用户失败");
                }
            });
        }

        function UpdateHolidayScript()
        {
            $.ajax({
                type: "POST",
                async: false,
                url: "../Ashx/Attendance/UserHolidaySettingByUsIDHandler.ashx",

                data: {
                    UserID: $("#hidUsID").val(), Sigh: 'Modify', NianJia:$("#txtNianJiaUpd").val(), TiaoXiu: $("#txtTiaoXiuUpd").val()
                },

                dataType: "json",

                success: function (data) {
                    $("#hidUsID").val("");
                    $("#txtNameUpd").val("");
                    $("#txtNianJiaUpd").val("");
                    $("#txtTiaoXiuUpd").val("");
                    $("#dg").datagrid("reload", data);
                    $('#dlgUpdate').dialog('close');
                },
                error: function () {
                    $.messager.alert("修改失败");
                }
            });

        }


        $(function () {

            $('#bthSearch').click(function () {

                $.ajax({

                    type: "POST",

                    url: "../Ashx/Attendance/GetHolidayListHandler.ashx",

                    data: { Page: 0, KeyStr: $("#txtKeyStr").val() },

                    dataType: "json",

                    success: function (data) {
                        $("#txtKeyStr").val("");
                        $('#dlgSearch').dialog('close');
                        $("#dg").datagrid("loadData", data);

                    }

                });

            });

        });




    </script>
         
   <div id="hideDiv" style="display:none">

    <!--弹出修改框 begin-->
        <div id="dlgUpdate" class="easyui-dialog" closed="true" title="修改假期时间"  style="width:480px;height:230px;padding:10px;" >
       <table>
           <tr>
               <td width="20px">
                   <input id="hidUsID" type="hidden" />
               </td>
               <td>
                  姓名：
               </td>
               <td >
                   <input  id="txtNameUpd" class="textbox03" style="width:300px" readonly="true"  type="text"  />
               </td>
               
           </tr>
          
           <tr>
               <td></td>
               <td>
                  年假时间：
               </td>
               <td>
                   <input  class="textbox03" id="txtNianJiaUpd" style="width:300px" type="text" />小时
               </td>
               </tr>
           <tr>
               <td></td>
               <td>
                   可调休时间：
               </td>
               <td>
                   <input  class="textbox03"  id="txtTiaoXiuUpd" style="width:300px" type="text"  />小时
               </td>
           </tr>

           <tr>
               <td  colspan="3" style="height:80px; text-align:right; padding-right:30px">
                  
                   <input id="bthUpdUser" class="button white" type="button" value="修 改" onclick="UpdateHolidayScript()"  />
                   <input id="bthUpdCanel" class="button white" type="button" value="取 消" onclick="$('#dlgUpdate').dialog('close')" />
               </td>
              
              
           </tr>
       </table>
        
    </div>

    <!--   弹出修改框 end-->
    <!--弹出搜索框 begin-->
    <div id="dlgSearch" class="easyui-dialog" closed="true" title="搜索组员" style="width:500px;height:200px;padding:10px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">

                </td>
                <td >
                    请输入关键字：<span style="color:#cccccc">&nbsp;&nbsp;&nbsp;例如：姓名、手机号、邮箱等信息</span>
                </td>
            </tr>
            <tr>
                <td ></td>
                <td>
                    <input id="txtKeyStr" class="textbox03" style=" width:300px" type="text" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2" style="height:50px;text-align:right;">
                    <input id="bthSearch" class="button white" type="button" value="搜 索" />
                    <input id="bthCanel" class="button white" type="button" value="取 消" onclick="$('#dlgSearch').dialog('close')" />

                </td>
                
            </tr>

        </table>

    </div>
    <!--弹出搜索框 end-->
   </div>  
    </form>
</body>
</html>