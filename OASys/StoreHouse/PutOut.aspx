<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PutOut.aspx.cs" Inherits="OASys.StoreHouse.PutOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>领用出库登记</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
     <table id="dg" title="物品申请列表" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/StoreHouse/GetUserPutOutListHandler.ashx',method:'POST'">            
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
         <input id="bthJude" class="button white" type="button" onclick="IsSelect()" value="领用登记" />        
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

        function IsSelect(){
            if ($('#dg').datagrid('getSelected') == null) {
                alert("请先选择需要物品出库的申请!");
            }
            else {
                $("#txtName").val($('#dg').datagrid('getSelected').ShopName);
                $("#txtUnit").val($('#dg').datagrid('getSelected').Unit);
                $("#txtNumber").val($('#dg').datagrid('getSelected').Number);
                $("#hidAAid").val($('#dg').datagrid('getSelected').AAID);
                $("#txtClass").val($('#dg').datagrid('getSelected').ShopClass);
                $('#dlg').dialog('open')
            }
        }


        function SubmitJude() {
            var obj = "";
            if ($("#txtClass").val() == "设备") {
                obj = 5
            }
            else {
                obj = 4;
            }

            $(function () {
                $.ajax({

                    type: "POST",

                    url: "../Ashx/StoreHouse/PutOutStoreHandler.ashx",

                    data: {
                        AAid: $("#hidAAid").val(),
                        Asid: obj,
                        Remark:""
                    },

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("reload");
                       
                        $("#dlg").dialog("close");
                    },
                    error: function () {
                        alert("读取失败，请与管理员联系！");
                    }
                });
            })
        }
     </script>
            
      <div id="dlg" class="easyui-dialog" closed="true" title="领用登记" style="width:500px;height:260px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                 申请物品：
                </td>
                <td >
                 <input id="txtName" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>
            <tr>
                <td >
                计量单位：
                </td>
                <td>
                <input id="txtUnit" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>
            
            <tr>
                <td >
                申请数量：
                </td>
                <td>
                <input id="txtNumber" class="textbox03" readonly="true" type="text" style=" width:280px" />
                <input id="hidAAid" type="hidden" />
                </td>
            </tr>
           
             <tr>
                <td >
                 物品类别：
                </td>
                <td>
                    <input id="txtClass" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>

            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthApply1OK" class="button white" type="button"  value="已领用" onclick="SubmitJude()" />
                <input id="bthApply1No" class="button white" type="button" onclick="$('#dlg').dialog('close')" value="取 消" />
                </td>
               
                
            </tr>
        </table>

    </div>   
        

    </form>
</body>
</html>
