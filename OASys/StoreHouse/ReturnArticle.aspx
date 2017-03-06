<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnArticle.aspx.cs" Inherits="OASys.StoreHouse.ReturnArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>设备归还</title>
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
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/StoreHouse/GetUserReturnListHandler.ashx',method:'POST'">            
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
         <input id="bthReturn" class="button white" type="button" onclick="IsSelect(1)" value="归还设备" />  
         <input id="bthKeepOn" class="button white" type="button" onclick="IsSelect(2)" value="延期归还" />
              
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

        function IsSelect(ReturnSign) {
            if ($('#dg').datagrid('getSelected') == null) {
                alert("请先选择已领用的设备条目!");
            }
            else {
                if (ReturnSign == 1) {
                    $("#txtName").val($('#dg').datagrid('getSelected').ShopName);
                    $("#hidAAid").val($('#dg').datagrid('getSelected').AAID);
                    $("#txtDate").val($('#dg').datagrid('getSelected').ReturnDate);
                    $('#dlgReturn').dialog('open');
                }
                else
                {
                    $("#txtName2").val($('#dg').datagrid('getSelected').ShopName);
                    $("#hidKeepAAid").val($('#dg').datagrid('getSelected').AAID);
                    $("#txtDate2").val($('#dg').datagrid('getSelected').ReturnDate);                  
                    $('#dlgKeepOn').dialog('open');
                }

                
            }
        }

        function ReturnArticle()
        {
            $(function () {
                $.ajax({

                    type: "POST",

                    url: "../Ashx/StoreHouse/ReturnStoreHandler.ashx",

                    data: {
                        AAid: $("#hidAAid").val()                     
                    },

                    dataType: "json",

                    success: function (data) {
                        $("#dg").datagrid("reload");
                        $("#dlgReturn").dialog("close");
                    },
                    error: function () {
                        alert("读取失败，请与管理员联系！");

                    }
                });
            })


        }

        function KeepOn()
        {
                $(function () {
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/StoreHouse/KeepStoreHandler.ashx",

                        data: {
                            AAKeepid: $("#hidKeepAAid").val(),
                            KeepOnDate:$("#txtKeepDate").datebox("getValue"),
                            KeepOnRemark:$("#txtKeepRemark").val()
                        },

                        dataType: "json",

                        success: function (data) {
                            $("#dg").datagrid("reload");
                            $("#dlgKeepOn").dialog("close");
                        },
                        error: function () {
                            alert("读取失败，请与管理员联系！");

                        }
                    });
                })

        }


    </script>
        <!--归还弹窗-->
       <div id="dlgReturn" class="easyui-dialog" closed="true" title="设备归还" style="width:500px;height:200px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                 归还设备：
                </td>
                <td >
                 <input id="txtName" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>
            <tr>
                <td >
                应还日期：
                </td>
                <td>
                <input id="txtDate" class="textbox03" readonly="true" type="text" style=" width:280px" />
                <input id="hidAAid" type="hidden" />
                </td>
            </tr>

            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthOK" class="button white" type="button"  value="归 还" onclick="ReturnArticle()" />
                <input id="bthNo" class="button white" type="button" onclick="$('#dlgReturn').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div>   
        
 <!--延期弹窗-->
       <div id="dlgKeepOn" class="easyui-dialog" closed="true" title="设备归还" style="width:500px;height:260px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                 应还设备：
                </td>
                <td >
                 <input id="txtName2" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>
            <tr>
                <td >
                应还日期：
                </td>
                <td>
                <input id="txtDate2" class="textbox03" readonly="true" type="text" style=" width:280px" />
                </td>
            </tr>
            <tr>
                <td >
                延期日期：
                </td>
                <td>
                <input id="txtKeepDate" class="easyui-datebox"  type="text" style=" width:285px" />
                <input id="hidKeepAAid" type="hidden" />
                </td>
            </tr>

             <tr>
                <td >
                延期原因：
                </td>
                <td>
                <input id="txtKeepRemark" class="textbox03"  type="text" style=" width:280px" />
                </td>
            </tr>

            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthKeepOK" class="button white" type="button"  value="延 期" onclick="KeepOn()" />
                <input id="bthKeepNo" class="button white" type="button" onclick="$('#dlgKeepOn').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div> 





    </form>
</body>
</html>
