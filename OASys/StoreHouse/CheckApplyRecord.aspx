<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckApplyRecord.aspx.cs" Inherits="OASys.StoreHouse.CheckApplyRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>领用记录查询</title>
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
    <table id="dg" title="物品申请列表" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/StoreHouse/GetApplyRecodHandler.ashx',method:'POST'">            
           <thead>
            <tr>
                <th data-options="field:'ShopName',width:200">物品名称</th>
                <th data-options="field:'Number',width:100,align:'center'">申请数量</th>
                <th data-options="field:'Unit',width:100,align:'center'">计量单位</th>
                <th data-options="field:'ShopClass',width:100,align:'center'">物品类别</th>
                <th data-options="field:'ApplyDate',width:150,align:'center'">申请时间</th>
                <th data-options="field:'ReturnDate',width:150,align:'center'">设备归还时间</th>
                <th data-options="field:'UsName',width:100,align:'center'">申请人</th>
                <th data-options="field:'ShopStatus',width:110,align:'center'">状态</th>
                <th data-options="field:'AAID',width:100,align:'center',hidden:'true'">AAID</th>
                <th data-options="field:'ShID',width:100,align:'center',hidden:'true'">ShID</th>
            </tr>
           
        </thead>
        
    </table>
    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
      <input id="bthJude" class="button white" type="button" onclick="$('#dlgSearch').dialog('open')" value="查询领用记录" />        
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

        function Search() {
            $.ajax({

                type: "POST",

                url: "../Ashx/StoreHouse/GetSearchPutOutRecodHandler.ashx",

                data: {
                    ShopName: $("#txtName").val(),
                    ShopClass: $("#Select1").val(),
                    UsName:$("#txtUsName").val(),
                    BeginDate: $("#BeginDate").datebox("getValue"),
                    EndDate: $("#EndDate").datebox("getValue")
                },

                dataType: "json",

                success: function (data) {
                    $("#dg").datagrid("loadData", data);
                    $("#txtName").val("");
                    $("#Select1").val(0);
                    $("#txtUsName").val("");
                    $("#BeginDate").datebox("setValue", "");
                    $("#EndDate").datebox("setValue", "");
                    $("#dlgSearch").dialog("close");
                },
                error: function () {
                    alert("读取失败，请与管理员联系！");

                }
            });

        }

        function Exprt()
        {
            $.ajax({

                type: "POST",

                url: "../Ashx/StoreHouse/DownLoadSearchPutOutRecodHandler.ashx",

                data: {
                    ShopName: $("#txtName").val(),
                    ShopClass: $("#Select1").val(),
                    UsName: $("#txtUsName").val(),
                    BeginDate: $("#BeginDate").datebox("getValue"),
                    EndDate: $("#EndDate").datebox("getValue")
                },

                dataType: "json",

                success: function (data) {
                    $.each(data, function (commentIndex, comment) {
                        if (comment['result'] == 0) {
                            alert("导出失败");

                        } else {
                            $("#txtName").val("");
                            $("#Select1").val(0);
                            $("#BeginDate").datebox("setValue", "");
                            $("#EndDate").datebox("setValue", "");
                            UsName: $("#txtUsName").val("");
                            $("#dlgSearch").dialog("close");
                            var obj = '../ExportEecel/' + comment['result'];
                            window.location.href = obj;

                        }


                    });

                },
                error: function () {
                    alert("读取失败，请与管理员联系！");

                }
            });

        }
        
       </script>


 <div id="hideDiv" style="display:none"> 
 <!--物品领用记录查询-->           
    <div id="dlgSearch" class="easyui-dialog" closed="true" title="查询领用记录" style="width:500px;height:260px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:90px">
                 物品名称：
                </td>
                <td >
                 <input id="txtName" class="textbox03"  type="text" style=" width:260px" />
                </td>
            </tr>
            <tr>
                <td >
                物品类别：
                </td>
                <td>
                    <select id="Select1" style="width:265px">
                     <option value="0">查询全部类别</option>
                     <option value="1">耗材</option>
                     <option value="2">设备</option>
                    </select>
                </td>
            </tr>

            <tr>
                <td style="width:90px">
                 领用人：
                </td>
                <td >
                 <input id="txtUsName" class="textbox03"  type="text" style=" width:260px" />
                </td>
            </tr>

             <tr>
                <td >
                查询开始时间：
                </td>
                <td>
                <input id="BeginDate" class="easyui-datebox"   style=" width:265px" />
                </td>
            </tr>
           
             <tr>
                <td >
                查询结束时间：
                </td>
                <td>
               <input id="EndDate" class="easyui-datebox"  style=" width:265px" />
                </td>
            </tr>

            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthOk" class="button white" type="button"  value="查 询" onclick="Search()" />
                <input id="bthExprt" class="button white" type="button"  value="导 出" onclick="Exprt()" />
                <input id="bthCancel" class="button white" type="button" onclick="$('#dlgSearch').dialog('close')" value="取 消" />                    
                </td>
            </tr>

        </table>

    </div> 
</div>
    </form>
</body>
</html>
