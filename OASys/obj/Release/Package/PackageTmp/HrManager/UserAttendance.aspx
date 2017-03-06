<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAttendance.aspx.cs" Inherits="OASys.HrManager.UserAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的考勤</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            /*JQuery 限制文本框只能输入数字*/
            //$(".NumText").keyup(function () {
            //    $(this).val($(this).val().replace(/\D|^0/g, ''));
            //}).bind("paste", function () {  //CTR+V事件处理    
            //    $(this).val($(this).val().replace(/\D|^0/g, ''));
            //}).css("ime-mode", "disabled"); //CSS设置输入法不可用    

            /*JQuery 限制文本框只能输入数字和小数点*/
            $(".NumDecText").keyup(function () {
                $(this).val($(this).val().replace(/[^0-9.]/g, ''));
            }).bind("paste", function () {  //CTR+V事件处理    
                $(this).val($(this).val().replace(/[^0-9.]/g, ''));
            }).css("ime-mode", "disabled"); //CSS设置输入法不可用    
        });

        function Show()
        {
            document.getElementById("DivHide").style.display = "block";

        }

    </script>
</head>
<body style="overflow:hidden;" scroll="no" onload="Show()">
    <form id="form1" runat="server">
      
    <table id="dg" title="我的考勤记录" style="width:1030px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/UserAttendanceHandler.ashx',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'usname',width:100,align:'center'">姓名</th>
                <th data-options="field:'postCause',width:100,align:'center'">打卡类别</th>
                <th data-options="field:'postdate',width:180,align:'center'">打卡时间</th>
                <th data-options="field:'postip',width:120,align:'center'">登陆IP</th>
                <th data-options="field:'Remark',width:364,align:'center'">备注</th>
                
                <th data-options="field:'stauts',width:100,align:'center'">请假审核</th>
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

        function qingjia()
        {
            attendance($("#txtQJTitle").val(),
                $("#txtQJBegin").datetimebox("getValue"),
                $("#txtQJEnd").datetimebox("getValue"),
                $("#txtQJCount").val(),
                $("#txtQJClass").val(),
                $("#txtGZJJ").val(),
                $("#txtJJR").val(),
                0,
                $("#txtQJBegin").datetimebox("getValue") + " 到 " + $("#txtQJEnd").datetimebox("getValue") + " 请假 " + $("#txtQJCount").val() + "天"
                );
            $("#dlg").dialog("close");
            $("#txtQJBegin").datetimebox("setValue", "");;
            $("#txtQJEnd").datetimebox("setValue","");
            $("#txtQJCount").val("");
            $("#txtQJClass").val("");
            $("#txtGZJJ").val("");
            $("#txtJJR").val("");
        }

        function jiaban() {
           
            attendance($("#txtJBTitle").val(),
                $("#txtJBBegin").datetimebox("getValue"),
                $("#txtJBEnd").datetimebox("getValue"),
                $("#txtJBCount").val(),
                "加班",
                $("#txtGBSY").val(),
                $("#txtJZR").val(),
                1,
                $("#txtJBBegin").datetimebox("getValue") + " 到 " + $("#txtJBEnd").datetimebox("getValue") + "加班" + $("#txtJBCount").val() + "小时"
                );
            $("#dlgJB").dialog("close");
            $("#txtJBTitle").val("");
            $("#txtJBBegin").datetimebox("setValue", "");;
            $("#txtJBEnd").datetimebox("setValue", "");;
            $("#txtJBCount").val("");
            $("#txtGBSY").val("");
            $("#txtJZR").val("");
        }



        function attendance(cid,beDate,enDate,hday,hClass,wContent,wPeson,stau,rek)
        {
        $(function () {

                $.ajax({

                    type: "POST",

                    url: "../Ashx/Attendance/GetUserAttendanceHandler.ashx",

                    data: {
                        Cid: cid, Usid: 39, BeginDate: beDate, EndDate: enDate, Holiday: hday,
                        HolidayClass:hClass,WorkContent:wContent,WorkPeson:wPeson,stauts:stau,remark:rek },

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("reload");
                        alert("操作成功！");
                    },
                    error:function(){
                        alert("操作失败，请重新打卡！");
                    
                    }

                });

         });
        }

        
    </script>

    <div id="DivHide" style="display:none">

    <div style="height: auto;  left: 0; bottom: 0; padding-top:5px; text-align:left ">
        <input id="bthSB" class="button white" type="button"  value="上班打卡" onclick="attendance('上班','', '', 0, '', '', '','' ,'')" />
        <input id="bthXB" class="button white" type="button"  value="下班打卡" onclick="attendance('下班', '', '', 0, '', '', '','' ,'')" />
        <input id="bthQJ" class="button white" type="button" onclick="$('#dlg').dialog('open')" value="请假申请" />
        <input id="bthJB" class="button white" type="button" onclick="$('#dlgJB').dialog('open')" value="加班申请" />
        
    </div>

    <%--请假div begin--%>
    <div id="dlg" class="easyui-dialog" closed="true" title="请假申请" style="width:500px;height:360px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                标题：
                </td>
                <td >
                    <input id="txtQJTitle" class="textbox03" readonly="true" style=" width:280px" type="text" value="请假" />     
                </td>
            </tr>
            <tr>
                <td >
                请假类别：
                </td>
                <td>
                <input id="txtQJClass" class="textbox03" type="text" style=" width:280px" />
                </td>
            </tr>

            <tr>
                <td >
                开始期限：
                </td>
                <td>
                <input id="txtQJBegin" class="easyui-datetimebox"  type="text" style=" width:285px" />
                </td>
            </tr>
             <tr>
                <td >
                结束期限：
                </td>
                <td>
                <input id="txtQJEnd" class="easyui-datetimebox"  type="text" style=" width:285px" />
                </td>
            </tr>

             <tr>
                <td >
                总计：
                </td>
                <td>
                <input id="txtQJCount" class="textbox03 NumDecText"  type="text" style=" width:150px" />天
                </td>
            </tr>

            <tr>
                <td >
                工作交接：
                </td>
                <td>
                <textarea id="txtGZJJ" class="textbox03" cols="20" rows="2" style=" width:280px"></textarea>
                </td>
            </tr>

             <tr>
                <td >
                交接人：
                </td>
                <td>
                <textarea id="txtJJR" class="textbox03" cols="20" rows="2" style=" width:280px"></textarea>
                </td>
            </tr>
            
            <tr>
                <td >
              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthSumbit" class="button white" type="button"  value="保 存" onclick="qingjia()" />
                <input id="bthCanel" class="button white" type="button" onclick="$('#dlg').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div>  
    <%--请假div end--%>


         <%--加班div begin--%>
    <div id="dlgJB" class="easyui-dialog" closed="true" title="加班申请" style="width:500px;height:360px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                标题：
                </td>
                <td >
                    <input id="txtJBTitle" class="textbox03" readonly="true" style=" width:280px" type="text" value="加班" />     
                </td>
            </tr>

            <tr>
                <td >
                开始期限：
                </td>
                <td>
                <input id="txtJBBegin" class="easyui-datetimebox"  type="text" style=" width:285px" />
                </td>
            </tr>
             <tr>
                <td >
                结束期限：
                </td>
                <td>
                <input id="txtJBEnd" class="easyui-datetimebox"  type="text" style=" width:285px" />
                </td>
            </tr>

             <tr>
                <td >
                总计：
                </td>
                <td>
                <input id="txtJBCount" class="textbox03 NumDecText"  type="text" style=" width:150px" />小时
                </td>
            </tr>

            <tr>
                <td >
                 加班事由：
                </td>
                <td>
                <textarea id="txtGBSY" class="textbox03" cols="20" rows="2" style=" width:280px"></textarea>
                </td>
            </tr>

             <tr>
                <td >
                加班见证：
                </td>
                <td>
                <textarea id="txtJZR" class="textbox03" cols="20" rows="2" style=" width:280px"></textarea>
                </td>
            </tr>
            
            <tr>
                <td >
              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthSave" class="button white" type="button"  value="保 存" onclick="jiaban()" />
                <input id="bthCanelc" class="button white" type="button" onclick="$('#dlgJB').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div>  
    <%--加班div end--%>
 </div>
    </form>
</body>
</html>
