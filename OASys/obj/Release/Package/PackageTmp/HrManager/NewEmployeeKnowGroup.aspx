<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployeeKnowGroup.aspx.cs" Inherits="OASys.HrManager.NewEmployeeKnowGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新员工须知</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>


</head>
<body style="overflow:hidden;" scroll="no">
    <form id="form1" runat="server">
    <table id="dg" title="新员工须知" style="width:1030px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/GetBusinesslistHandler.ashx',method:'POST'">
        <thead>
            <tr >
                <th data-options="field:'title',width:200">标题</th>
                <th data-options="field:'usname',width:200">发布人</th>
                <th data-options="field:'date',width:200,align:'center'">发布时间</th>
                <th data-options="field:'remark',width:360,align:'center'">备注</th>
                
                <th data-options="field:'neid',width:70,align:'center',hidden:'true'"  >id</th>
            </tr>
           
        </thead>
        
    </table>
        <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
        <input id="bthAddShow" class="button white" type="button" onclick="document.location='NewEmployeeKnowAdd.aspx?NeID=0'" value=" 添 加" />
        <input id="bthUpdateShow" class="button white" type="button" onclick="document.location = 'NewEmployeeKnowAdd.aspx?NeID=' + $('#dg').datagrid('getSelected').neid" value="修 改" />
        <input id="bthDel" class="button white" type="button" onclick="DelInfo($('#dg').datagrid('getSelected').neid)" value="删 除" />
        
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

        function DelInfo(obj)
        {
            var mess = confirm("确定要删除选中信息？");
            if (mess)
            {
                $(function () {
                    //alert($('#dg').datagrid('getSelected').productname + ".del");
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/DelNewKmployeeKnow.ashx",

                        data: { NeID: obj },

                        dataType: "json",

                        success: function (data) {
                            $("#dg").datagrid("reload");
                            alert("删除成功!");

                        }

                    });

                })

            }

        }
     

    </script>


    </form>
</body>
</html>
