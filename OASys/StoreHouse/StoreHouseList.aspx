<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreHouseList.aspx.cs" Inherits="OASys.StoreHouse.StoreHouseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>仓储管理</title>
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
  
    <table id="dg" title="库存列表" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/StoreHouse/GetStoreHouseListHandler.ashx',method:'POST'">
             
           <thead>
            <tr>
                <th data-options="field:'ShopName',width:400">物品名称</th>
                <th data-options="field:'Number',width:150,align:'center'">数量</th>
                <th data-options="field:'Unit',width:150,align:'center'">计量单位</th>
                <th data-options="field:'ShopClass',width:150,align:'center'">物品类别</th>
                <th data-options="field:'ShopStatus',width:160,align:'center'">状态</th>
                <th data-options="field:'ShID',width:150,align:'center',hidden:'true'">ShID</th>
            </tr>
           
        </thead>
        
    </table>
    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
         <input id="bthAddArticle" class="button white" type="button" onclick="$('#dlg').dialog('open')" value="添加新种类" />
         <input id="bthCheckIn" class="button white" type="button" onclick="IsSelectStore()" value="物品入库" />
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

         function AddStore()
         {
             var obj = $("#Select1").val();
             if (obj == 0) {
                 $.messager.alert('类别错误', '请选择物品类别！', 'error');
             }
             else
             {
                 if ($("#txtName").val() == "")
                 {
                     $.messager.alert('物品名称错误', '物品名称不能为空！', 'error');
                     return;
                 }

                 if ($("#txtUnit").val() == "") {
                     $.messager.alert('计量单位错误', '计量单位不能为空！', 'error');
                     return;
                 }

                 $(function () {
                     $.ajax({

                         type: "POST",

                         url: "../Ashx/StoreHouse/AddStoreHouseHandler.ashx",

                         data: {
                             ShName: $("#txtName").val(),
                             ShUnit: $("#txtUnit").val(),
                             ShClass: $("#Select1").val(),
                             ShBus: $("#txtBus").val(),
                             Remark: $("#txtRemark").html()
                         },

                         dataType: "json",

                         success: function (data) {
                             $("#dg").datagrid("reload");
                             ShName: $("#txtName").val("");
                             ShUnit: $("#txtUnit").val("");
                             ShClass: $("#Select1").val("");
                             ShBus: $("#txtBus").val("");
                             Remark: $("#txtRemark").html("");

                             $("#dlg").dialog("close");
                         },
                         error: function () {
                             alert("添加失败，请与管理员联系！");

                         }
                     });
                 })
             }


         }

         


         function SearchStore()
         {           
             $(function () {
                 $.ajax({

                     type: "POST",

                     url: "../Ashx/StoreHouse/SearchStoreHouseByNameHandler.ashx",

                     data: {
                         ShName: $("#txtSearchName").val()
                     },

                     dataType: "json",

                     success: function (data) {
                         $("#dg").datagrid("loadData",data);
                         $("#txtSearchName").val("");
                         $("#dlgSearch").dialog("close");
                     },
                     error: function () {
                         alert("添加失败，请与管理员联系！");

                     }
                 });
             })
         }


         function IsSelectStore()
         {
             if ($('#dg').datagrid('getSelected') == null) {
                 alert("请先选择入库的物品!");
             }
             else {
                 $("#txtCheckName").val($('#dg').datagrid('getSelected').ShopName);
                 $("#txtCheckUnit").val($('#dg').datagrid('getSelected').Unit);
                 $("#hidShid").val($('#dg').datagrid('getSelected').ShID);
                 $('#dlgCheckIn').dialog('open'); 
             }
         }

         function CheckInStore()
         {

             $(function () {
                 $.ajax({

                     type: "POST",

                     url: "../Ashx/StoreHouse/CheckInStoreHandler.ashx",

                     data: {
                         ShID: $("#hidShid").val(),
                         Number: $("#txtCheckNumber").val()
                     },

                     dataType: "json",

                     success: function (data) {
                         $("#dg").datagrid("reload");
                         $("#txtCheckNumber").val("");
                         $("#dlgCheckIn").dialog("close");
                     },
                     error: function () {
                         alert("入库失败，请与管理员联系！");

                     }
                 });
             })

         }

      </script>

   <div id="hideDiv" style="display:none">
     <!-- 添加物品 -->
     <div id="dlg" class="easyui-dialog" closed="true" title="添加新物品" style="width:500px;height:300px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                物品名称：
                </td>
                <td >
                    <input id="txtName" class="textbox03"  style=" width:280px" type="text" value="" />
                    <input id="hidShid" type="hidden" />     
                </td>
            </tr>
            <tr>
                <td >
                计量单位：
                </td>
                <td>
                <input id="txtUnit" class="textbox03" type="text" style=" width:280px" />
                </td>
            </tr>

            <tr>
                <td >
                物品类别：
                </td>
                <td>
                    <select id="Select1" style="width:285px">
                        <option value="0">请选择类型</option>
                        <option value="1">耗材</option>
                        <option value="2">设备</option>
                    </select>
                </td>
            </tr>
             <tr>
                <td >
                品牌：
                </td>
                <td>
                <input id="txtBus" class="textbox03"  type="text" style=" width:280px" />
                </td>
            </tr>

             <tr>
                <td > 
                备注：
                </td>
                <td>
                <textarea id="txtRemark" class="textbox03" cols="20" rows="3" style=" width:280px"></textarea>
                </td>
            </tr>
            
            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthSumbit" class="button white" type="button"  value="保 存" onclick="AddStore()" />
                <input id="bthCanel" class="button white" type="button" onclick="$('#dlg').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div>  


        <!--查询物品 -->
     <div id="dlgSearch" class="easyui-dialog" closed="true" title="添加新物品" style="width:500px;height:200px;padding:50px; padding-top:50px">
        <table>
            <tr>
                <td style="width:60px">
                物品名称：
                </td>
                <td >
                    <input id="txtSearchName" class="textbox03"  style=" width:280px" type="text" value="" />     
                </td>
            </tr>
                       
            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthSearch" class="button white" type="button"  value="查 询" onclick="SearchStore()" />
                <input id="bthCanelSearch" class="button white" type="button" onclick="$('#dlgSearch').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div>  


 <!--物品入库 -->
     <div id="dlgCheckIn" class="easyui-dialog" closed="true" title="物品入库" style="width:500px;height:200px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                物品名称：
                </td>
                <td >
                    <input id="txtCheckName" class="textbox03" readonly="true" style=" width:280px" type="text" value="" />     
                </td>
            </tr>
            <tr>
                <td >
                计量单位：
                </td>
                <td>
                <input id="txtCheckUnit" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>

            
             <tr>
                <td >
                入库数量：
                </td>
                <td>
                <input id="txtCheckNumber" class="textbox03"  type="text" style=" width:280px" />
                </td>
            </tr>
           
            
            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthOK" class="button white" type="button"  value="入 库" onclick="CheckInStore()" />
                <input id="bthNo" class="button white" type="button" onclick="$('#dlgCheckIn').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div>  

   </div>
    </form>
</body>
</html>
