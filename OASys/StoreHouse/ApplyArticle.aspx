<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyArticle.aspx.cs" Inherits="OASys.StoreHouse.ApplyArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>申请物品</title>
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
    <form id="form1" runat="server" >
    
         <table id="dg" title="物品申请列表" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/StoreHouse/GetUserApplyByUsIDHandler.ashx',method:'POST'">            
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
            </tr>
           
        </thead>
        
    </table>
    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
         <input id="bthApply1" class="button white" type="button" onclick="ApplyStore(1)" value="申请耗材" />
         <input id="bthApply2" class="button white" type="button" onclick="ApplyStore(2)" value="申请设备" />
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

        function ApplyStore(obj)
        {

            if (obj == 1)
            {
                $("#Select1").empty();
                $("#Select1").get(0).options.add(new Option("请选择需要申请的耗材",0));
                $(function () {
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/StoreHouse/GetShopNameByClassIDHandler.ashx",

                        data: {
                            ClassID: 1
                        },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                $("#Select1").get(0).options.add(new Option(comment.Text, comment.Value));

                           });
                        },
                        error: function () {
                            alert("读取失败，请与管理员联系！");

                        }
                    });
                })

                $("#dlgApply1").dialog("open");


            }
            else
            {

                $("#Select2").empty();
                $("#Select2").get(0).options.add(new Option("请选择需要申请的设备", 0));
                $(function () {
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/StoreHouse/GetShopNameByClassIDHandler.ashx",

                        data: {
                            ClassID: 2
                        },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                $("#Select2").get(0).options.add(new Option(comment.Text, comment.Value));

                            });
                        },
                        error: function () {
                            alert("读取失败，请与管理员联系！");

                        }
                    });
                })


                $("#dlgApply2").dialog("open");
            }

        }

        function GetUnit()
        {
            if ($("#Select1").val() != 0)
            {
                $(function () {
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/StoreHouse/GetUnitByShopIDHandler.ashx",

                        data: {
                            ShopID: $("#Select1").val()
                        },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                $("#txtUnit").val(comment.Unit);
                            });
                        },
                        error: function () {
                            alert("读取失败，请与管理员联系！");
                        }
                    });
                })
            }
        }

        function SubmitApply(ApplyID)
        {
            if (ApplyID == 1)
            {
                $(function () {
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/StoreHouse/AddApplyHandler.ashx",

                        data: {
                            ShopID: $("#Select1").val(),
                            Number: $("#txtNumber").val(),
                            ReturnDate: "2100-01-01",
                            Remark: $("#txtRemark1").val()
                        },

                        dataType: "json",

                        success: function (data) {
                            $("#dg").datagrid("reload");
                            $("#txtNumber").val("");
                            $("#txtRemark1").val("");
                            $("#dlgApply1").dialog("close");
                        },
                        error: function () {
                            alert("申请失败，请与管理员联系！");
                        }
                    });
                })

            }
            else
            {
                $(function () {
                    $.ajax({

                        type: "POST",

                        url: "../Ashx/StoreHouse/AddApplyHandler.ashx",

                        data: {
                            ShopID: $("#Select2").val(),
                            Number: $("#txtNumber2").val(),
                            ReturnDate: $("#returnDate").datebox("getValue"),
                            Remark: $("#txtRemark2").val()
                        },

                        dataType: "json",

                        success: function (data) {
                            $("#dg").datagrid("reload");
                            $("#returnDate").val("");
                            $("#txtRemark2").val("");
                            $("#txtNumber2").val(1),
                            $("#dlgApply2").dialog("close");
                        },
                        error: function () {

                            alert("申请失败，请与管理员联系！");
                        }
                    });
                })


            }


        }
    </script>

<div id="hideDiv" style="display:none">
    <div id="dlgApply1" class="easyui-dialog" closed="true" title="申请耗材" style="width:500px;height:260px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                 选择耗材：
                </td>
                <td >
                    <select id="Select1" style="width:285px" onchange="GetUnit()">
                        
                    </select>    
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
                <input id="txtNumber" class="textbox03"  type="text" style=" width:280px" />
                </td>
            </tr>
           
             <tr>
                <td >
                 备注：
                </td>
                <td>
                <input id="txtRemark1" class="textbox03"  type="text" style="width:280px" />
                </td>
            </tr>

            
            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthApply1OK" class="button white" type="button"  value="申 请" onclick="SubmitApply(1)" />
                <input id="bthApply1No" class="button white" type="button" onclick="$('#dlgApply1').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div> 

    
 <div id="dlgApply2" class="easyui-dialog" closed="true" title="申请设备" style="width:500px;height:240px;padding:50px; padding-top:30px">
        <table>
            <tr>
                <td style="width:60px">
                 选择设备：
                </td>
                <td >
                   <select id="Select2" style="width:285px" >
                        
                   </select>     
                </td>
            </tr>
             <tr>
                <td >
                申请数量：
                </td>
                <td>
                <input id="txtNumber2" class="textbox03"  type="text" style=" width:280px" value="1" />
                </td>
            </tr>

            <tr>
                <td >
                 归还时间：
                </td>
                <td>
                <input id="returnDate" class="easyui-datebox"  type="text" style=" width:285px" />
                </td>
            </tr>
            <tr>
                <td >
                 备注：
                </td>
                <td>
                <input id="txtRemark2" class="textbox03"  type="text" style="width:280px" />
                </td>
            </tr>

            <tr>
                <td >              
                </td>
                <td style="text-align:right;height:30px; vertical-align:bottom">
                <input id="bthOK" class="button white" type="button"  value="申 请" onclick="SubmitApply(2)" />
                <input id="bthNo" class="button white" type="button" onclick="$('#dlgApply2').dialog('close')" value="取 消" />

                </td>
            </tr>

        </table>

    </div> 
</div>


    </form>
</body>
</html>
