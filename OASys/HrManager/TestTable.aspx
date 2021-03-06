﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTable.aspx.cs" Inherits="OASys.HrManager.TestTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="../css/icon.css">
    <link rel="stylesheet" type="text/css" href="../css/comm.css">
    <link rel="stylesheet" type="text/css" href="../css/demo.css">
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="dg" title="项目组通讯录" style="width:1030px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/UserHandler.ashx',method:'get'">
        <thead>
            <tr >
                <th data-options="field:'itemid',width:120">姓名</th>
                <th data-options="field:'productid',width:100">职务</th>
                <th data-options="field:'listprice',width:160,align:'center'">业务组</th>
                <th data-options="field:'unitcost',width:200,align:'center'">联系电话</th>
                <th data-options="field:'attr1',width:200">办公地点</th>
                <th data-options="field:'status',width:120">状态</th>
                <th data-options="field:'content',width:70,align:'center'">详细</th>
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

    <div style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
        <input id="bthAdd" class="button white" type="button" onclick="$('#dlg').dialog('open')" value=" 添 加" />
        <input id="bthUpdate" class="button white" type="button" onclick="$('#dlg').dialog('open')" value="修 改" />
        <input id="bthDel" class="button white" type="button" onclick="test(this.id)" value="删 除" />
        <input id="bthAuthority" class="button white" type="button" onclick="test(this.id)" value="权 限" />
    </div>
    <script>
        function test(obj) {
            if (obj == "bthDel") {
                $(function () { alert($('#dg').datagrid('getSelected').itemid + ".del") })
            }
            else {
                //$(function () { alert($('#dg').datagrid('getSelected').itemid + ".aut") })
                document.location.href = "adduser.aspx?userid=" + obj;

            }
        }


        






        $(function () {

            $('#bthSearch').click(function () {

                $.ajax({

                    type: "GET",

                    url: "../Ashx/UserHandler.ashx",

                    data: { Page: 0, KeyStr: $("#txtKeyStr").val() },

                    dataType: "json",

                    success: function (data) {
                        $('#dlgSearch').dialog('close');
                        $("#dg").datagrid("loadData", data);
                    }

                });

            });

        });





    </script>
    
    
    <!--弹出添加框 begin-->
    <div id="dlg" class="easyui-dialog" closed="true" title="添加新组员"  style="width:800px;height:280px;padding:10px;" >
       <table>
           <tr>
               <td width="20px">

               </td>
               <td>
                  姓名：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
               <td width="20px"></td>
               <td>
                   服务形式：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   电话：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
               <td></td>
               <td>
                   所属公司：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   邮箱：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
               <td></td>
               <td>
                   办公地址：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   职务 ：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
               <td></td>
               <td>
                   入职时间：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                  业务 ：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
               <td></td>
               <td>
                   入职原因：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
           </tr>
           <tr>
               <td></td>
               <td>
                   状态：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
               <td></td>
               <td>
                   离职时间：
               </td>
               <td>
                   <input class="textbox03" id="Text1" type="text" style="width:275px" />
               </td>
           </tr>
           <tr>
               <td  colspan="6" style="height:30px; text-align:right; padding-top:30px">
                   <input id="Button1" class="button white" type="button" value="保 存" />
                   <input id="Button1" class="button white" type="button" value="取 消" onclick="$('#dlg').dialog('close')" />
               </td>
              
           </tr>
       </table>
    </div>
    <!--弹出添加框 end-->
        
    <!--弹出添加框 begin-->
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
                    <input id="Button2" class="button white" type="button" value="取 消" onclick="$('#dlgSearch').dialog('close')" />

                </td>
                
            </tr>

        </table>

    </div>




    </form>
</body>
</html>
