<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressList.aspx.cs" Inherits="OASys.HrManager.AddressList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>通讯录</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
   
    <style type="text/css">
        #txtName {
            width: 170px;
        }
        #txtEmail {
            width: 170px;
        }
        #txtOutDate {
            width: 170px;
        }
        #txtEmptyCause {
            width: 170px;
        }
        #txtInDate {
            width: 170px;
        }
        #txtAddress {
            width: 170px;
        }
        #txtStauts {
            width: 170px;
        }
        #txtPhone {
            width: 170px;
        }
        #txtCompany {
            width: 170px;
        }
        #txtWork {
            width: 439px;
            height: 68px;
        }
        #TextArea1 {
            width: 439px;
            height: 63px;
        }
        #txtWorkContent {
            width: 460px;
            height: 60px;
        }
        #txtDuty {
            width: 460px;
            height: 60px;
        }
        #txtNameUpd {
            width: 170px;
        }
        #txtEmailUpd {
            width: 170px;
        }
        #txtOutDateUpd {
            width: 170px;
        }
        #txtEmptyCauseUpd {
            width: 170px;
        }
        #txtInDateUpd {
            width: 170px;
        }
        #txtAddressUpd {
            width: 170px;
        }
        #txtStautsUpd {
            width: 170px;
        }
        #txtPhoneUpd {
            width: 170px;
        }
        #txtCompanyUpd {
            width: 170px;
        }
        #txtWorkUpd {
            width: 439px;
            height: 68px;
        }
        #TextArea1Upd {
            width: 439px;
            height: 63px;
        }
        #txtWorkContentUpd {
            width: 460px;
            height: 60px;
        }
        #txtDutyUpd {
            width: 460px;
            height: 60px;
        }
         #txtCommUp {
            width: 170px;
        }
          #txtCommDown {
            width: 170px;
        }
           #txtSatUp {
            width: 170px;
        }
            #txtSatDown {
            width: 170px;
        }

    </style>
    <script>
        function Show()
        {
          document.getElementById("hideDiv").style.display = "block";

        }
    </script>



</head>
<body  onload="Show()" > 
    <form id="form1" runat="server">
    <table id="dg" title="项目组通讯录" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/User/UserHandler.ashx',method:'POST'">
        <thead>
            <tr>
                <th data-options="field:'itemid',width:120,align:'center'">姓名</th>
                <th data-options="field:'productid',width:100,align:'center'">职务</th>
                <th data-options="field:'listprice',width:100,align:'center'">业务组</th>
                <th data-options="field:'unitcost',width:260,align:'center'">联系电话</th>
                <th data-options="field:'email',width:200,align:'center'">邮箱</th>
                <th data-options="field:'status',width:120,align:'center'">状态</th>
                <th data-options="field:'content',width:70,align:'center'">详细</th>
                <th data-options="field:'usid',width:70,align:'center',hidden:'true'">usid</th>
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
        function test(obj) {
            if (obj == "bthDel") {
                
                if ($('#dg').datagrid('getSelected') == null) {
                    alert("请先选择需要配置权限的账号!");
                }
                else {

                    if (confirm("确定要删除该员工吗？")) {
                        $(function () {
                            //alert($('#dg').datagrid('getSelected').productname + ".del");
                            $.ajax({

                                type: "POST",

                                url: "../Ashx/AdduserHandler.ashx",

                                data: { PageID: 3, UserID: $('#dg').datagrid('getSelected').usid },

                                dataType: "json",

                                success: function (data) {
                                    $("#dg").datagrid("reload");
                                    alert("删除成功!");

                                }
                           
                            });
                        })
                        }

                }
               
            }
            else {
                //$(function () { alert($('#dg').datagrid('getSelected').itemid + ".aut") })
                if ($('#dg').datagrid('getSelected') == null)
                {
                    alert("请先选择需要配置权限的账号!");
                }
                else
                {
                    document.location.href = "AuthorityManager.aspx?UsID=" + $('#dg').datagrid('getSelected').usid; //权限跳转页
                }
               
               
            }
        }
       

        $(function () {

            $('#bthSearch').click(function () {

                $.ajax({

                    type: "POST",

                    url: "../Ashx/User/UserHandler.ashx",

                    data: {Page:0, KeyStr: $("#txtKeyStr").val() },

                    dataType: "json",

                    success: function (data) {
                        $("#txtKeyStr").val("");
                        $('#dlgSearch').dialog('close');
                        $("#dg").datagrid("loadData", data);
                        
                    }

                });

            });

        });


      



        function AddUserScript(){
            $.ajax({

                type: "POST",
                async: false,
                url: "../Ashx/User/AddUserHandler.ashx",
                
                data: {
                    UserID: 0, UserName: $("#txtName").val(), Phone: $("#txtPhone").val(), Email: $("#txtEmail").val(),
                    JobID: document.getElementById("<%=dplJob.ClientID%>").value, BusinessID: document.getElementById("<%=dplBusiness.ClientID%>").value,
                    Stauts: $("#txtStauts").val(), ServerStyleID: document.getElementById("<%=dplServerStyle.ClientID%>").value,
                    Comany: $("#txtCompany").val(), Office: $("#txtAddress").val(),
                    EmptyDate: $("#txtInDate").val(), EmptyCause: $("#txtEmptyCause").val(),EmptyOutDate: $("#txtOutDate").val(),
                    WorkContent: $("#txtWorkContent").val(), QY: document.getElementById("<%=dplQY.ClientID%>").value, Duty: $("#txtDuty").val(), PageID: 0,
                    CommUp: $("#txtCommUp").val(), CommDown: $("#txtCommDown").val(), SatUp: $("#txtSatUp").val(), SatDown: $("#txtSatDown").val()
                },

                dataType: "json",

                success: function (data) {
                    $.each(data, function (commentIndex, comment) {
                        var obj=comment["result"];
                        if ( obj=="1")
                        {
                            $("#txtName").val("") ;
                            $("#txtPhone").val("") ;
                            $("#txtEmail").val ("");
                            $("#txtStauts").val("") ;
                            $("#txtAddress").val("") ;
                            $("#txtCompany").val("");
                            $("#txtEmptyCause").val("");
                            $("#txtWorkContent").val("");
                            $("#txtDuty").val("");
                            $("#dlg").dialog("close");
                            $("#dg").datagrid("reload");
                            alert("操作成功");
                        }
                        else
                        {
                            alert("添加失败，请检查数据库连接！");
                        }

                    });
                }

            });
        }


        function UpdateUserScript() {
            $.ajax({

                type: "POST",
                async: false,
                url: "../Ashx/User/AddUserHandler.ashx",

                data: {
                    UserID: $("#hidUsID").val(), UserName: $("#txtNameUpd").val(), Phone: $("#txtPhoneUpd").val(), Email: $("#txtEmailUpd").val(),
                    JobID: document.getElementById("<%=dplJobUpd.ClientID%>").value, BusinessID: document.getElementById("<%=dplBusinessUpd.ClientID%>").value,
                    Stauts: $("#txtStautsUpd").val(), ServerStyleID: document.getElementById("<%=dplServerStyleUpd.ClientID%>").value,
                    Comany: $("#txtCompanyUpd").val(), Office: $("#txtAddressUpd").val(),
                    EmptyDate: $("#txtInDateUpd").val(), EmptyCause: $("#txtEmptyCauseUpd").val(),
                    EmptyOutDate: $("#txtOutDateUpd").val(),
                    WorkContent: $("#txtWorkContentUpd").val(), QY: document.getElementById("<%=dplQYUpd.ClientID%>").value, Duty: $("#txtDutyUpd").val(), PageID: 1,
                    CommUp: $("#txtCommUpUpd").val(), CommDown: $("#txtCommDownUpd").val(),
                    SatUp: $("#txtSatUpUpd").val(), SatDown: $("#txtSatDownUpd").val()
                },

                dataType: "json",

                success: function (data) {
                    $.each(data, function (commentIndex, comment) {
                        var obj = comment["result"];
                        if (obj == "1") {
                            $("#txtNameUpd").val("");
                            $("#txtPhoneUpd").val("");
                            $("#txtEmailUpd").val("");
                            $("#txtStautsUpd").val("");
                            $("#txtAddressUpd").val("");
                            $("#txtCompanyUpd").val("");
                            $("#txtEmptyCauseUpd").val("");
                            $("#txtWorkContentUpd").val("");
                            $("#txtInDateUpd").val("");
                            $("#txtDutyUpd").val("");
                            $("#txtCommUpUpd").val("");
                            $("#txtCommDownUpd").val("");
                            $("#txtSatUpUpd").val("");
                            $("#txtSatDownUpd").val();
                            $("#dlgUpdate").dialog("close");
                            $("#dg").datagrid("reload");
                            alert("操作成功");
                        }
                        else {
                            alert("更新失败，请检查数据库连接！");
                        }

                    });
                }

            });
        }



        function GetUserModelScript() {
            if ($('#dg').datagrid('getSelected') == null) {
                alert("请先选择需要配置权限的账号!");
            }
            else {
                $('#dlgUpdate').dialog('open');

                $.ajax({

                    type: "POST",
                    async: false,
                    url: "../Ashx/User/AddUserHandler.ashx",

                    data: {
                        UserID: $('#dg').datagrid('getSelected').usid, PageID: 2
                    },

                    dataType: "json",

                    success: function (data) {
                        $.each(data, function (commentIndex, comment) {

                            $("#txtNameUpd").val(comment["usname"]);
                            $("#hidUsID").val(comment["usid"]);
                            $("#txtPhoneUpd").val(comment["phone"]);
                            $("#txtEmailUpd").val(comment["email"]);
                            $("#txtStautsUpd").val(comment["stauts"]);
                            $("#txtAddressUpd").val(comment["office"]);
                            $("#txtCompanyUpd").val(comment["becomany"]);
                            $("#txtInDateUpd").val(comment["entrydate"]);
                            $("#txtEmptyCauseUpd").val(comment["entrycause"]);
                            $("#txtOutDateUpd").val(comment["dimissiondate"]);
                            $("#txtWorkContentUpd").val(comment["emptyone"]);
                            $("#txtDutyUpd").val(comment["emptytwo"]);
                            $("#txtCommUpUpd").val(comment["CommUp"]);
                            $("#txtCommDownUpd").val(comment["CommDown"]);
                            $("#txtSatUpUpd").val(comment["SatUp"]);
                            $("#txtSatDownUpd").val(comment["SatDown"]);
                            document.getElementById("<%=dplJobUpd.ClientID%>").value = comment["jobid"];
                            document.getElementById("<%=dplBusinessUpd.ClientID%>").value = comment["businessid"];
                            document.getElementById("<%=dplServerStyleUpd.ClientID%>").value = comment["serverstyleid"];

                    });
                }

            });

            }

        }

        
    </script>
         
   <div id="hideDiv" style="display:none">
   
    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
            <input id="bthAddShow" class="button white" type="button" onclick="$('#dlg').dialog('open'); " value=" 添 加" />
            <input id="bthUpdateShow" class="button white" type="button" onclick="GetUserModelScript()" value="修 改" />
            <input id="bthDel" class="button white" type="button" style="display:none" onclick="test(this.id)" value="删 除" />
            <input id="bthAuthorityShow" class="button white" type="button" onclick="test(this.id)" value="权 限" />
            <asp:Button ID="ExportExl" CssClass="button white" runat="server" Text="导 出" OnClick="ExportExl_Click" />
           
        </div>
  
    <!--弹出添加框 begin-->
    <div id="dlg" class="easyui-dialog" closed="true" title="添加新组员"  style="width:650px;height:500px;padding:10px;" >
       <table>
           <tr>
               <td width="20px">

               </td>
               <td>
                  姓名：
               </td>
               <td >
                   <input  id="txtName" class="textbox03"   type="text"  />
               </td>
               <td width="20px"></td>
               <td>
                   服务形式：
               </td>
               <td>
                   <asp:DropDownList ID="dplServerStyle" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   电话：
               </td>
               <td>
                   <input  class="textbox03" id="txtPhone" type="text" />
               </td>
               <td></td>
               <td>
                   所属公司：
               </td>
               <td>
                   <input  class="textbox03" id="txtCompany" type="text" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   邮箱：
               </td>
               <td>
                   <input  class="textbox03" id="txtEmail" type="text" />
               </td>
               <td></td>
               <td>
                   办公地址：
               </td>
               <td>
                   <input  class="textbox03" id="txtAddress" type="text" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   职务：
               </td>
               <td>
                   <asp:DropDownList ID="dplJob" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
               <td></td>
               <td>
                   入职时间：
               </td>
               <td>
                <input  class="textbox03" id="txtInDate" type="text"  />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                  业务：
               </td>
               <td>
                  <asp:DropDownList ID="dplBusiness" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
               <td></td>
               <td>
                   入职原因：
               </td>
               <td>
                   <input  class="textbox03" id="txtEmptyCause" type="text" />
               </td>
           </tr>
           <tr>
               <td></td>
               <td>
                   状态：
               </td>
               <td>
                   <input  class="textbox03" id="txtStauts" type="text" />
               </td>
               <td></td>
               <td>
                   离职时间：
               </td>
               <td>
                   <input  class="textbox03" id="txtOutDate" type="text"  />
               </td>
           </tr>
            <tr>
                <td></td>
               <td>
                所在区域
               </td>
               <td>
                <asp:DropDownList ID="dplQY" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
                <td></td>
                <td>

                </td>
                <td>

                </td>
           </tr>

           <tr>
                <td></td>
               <td>
                日常上班：
               </td>
               <td>
               <input  class="textbox03" id="txtCommUp" type="text" />
               </td>
                <td></td>
                <td>
                 日常下班：
                </td>
                <td>
                <input  class="textbox03" id="txtCommDown" type="text" />
                </td>
           </tr>

           <tr>
                <td></td>
               <td>
                周六上班：
               </td>
               <td>
               <input  class="textbox03" id="txtSatUp" type="text" />
               </td>
                <td></td>
                <td>
                 周六下班：
                </td>
                <td>
                <input  class="textbox03" id="txtSatDown" type="text" />
                </td>
           </tr>


           <tr>
               <td>

               </td>
               <td>
                   工作内容：
               </td>
               <td  colspan="4">
                   <textarea id="txtWorkContent" class="textbox03" name="S1" style="width:459px"></textarea>
               </td>
           </tr>
          

            <tr>
               <td>

               </td>
               <td>
                   岗位职责：
               </td>
               <td  colspan="4">
                   <textarea id="txtDuty" class="textbox03" name="S2" style="width:460px"></textarea>
               </td>
           </tr>

           <tr>
               <td  colspan="6" style="height:80px; text-align:right; padding-right:30px">
                  
                   <input id="bthAddUser" class="button white" type="button" value="保 存" onclick="AddUserScript()"  />
                   <input id="bthAddCanel" class="button white" type="button" value="取 消" onclick="$('#dlg').dialog('close')" />
               </td>
              
              
           </tr>
       </table>
        
    </div>
    <!--弹出添加框 end-->

   <!--弹出修改框 begin-->
        <div id="dlgUpdate" class="easyui-dialog" closed="true" title="修改组员信息"  style="width:650px;height:500px;padding:10px;" >
       <table>
           <tr>
               <td width="20px">
                   <input id="hidUsID" type="hidden" />
               </td>
               <td>
                  姓名：
               </td>
               <td >
                   <input  id="txtNameUpd" class="textbox03"   type="text"  />
               </td>
               <td width="20px"></td>
               <td>
                   服务形式：
               </td>
               <td>
                   
                   <asp:DropDownList ID="dplServerStyleUpd" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   电话：
               </td>
               <td>
                   <input  class="textbox03" id="txtPhoneUpd" type="text" />
               </td>
               <td></td>
               <td>
                   所属公司：
               </td>
               <td>
                   <input  class="textbox03" id="txtCompanyUpd" type="text" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   邮箱：
               </td>
               <td>
                   <input  class="textbox03" id="txtEmailUpd" type="text" />
               </td>
               <td></td>
               <td>
                   办公地址：
               </td>
               <td>
                   <input  class="textbox03" id="txtAddressUpd" type="text" />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                   职务：
               </td>
               <td>
                   <asp:DropDownList ID="dplJobUpd" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
               <td></td>
               <td>
                   入职时间：
               </td>
               <td>
                <input  class="textbox03"  id="txtInDateUpd" type="text"  />
               </td>
           </tr>
           <tr>
               <td ></td>
               <td>
                  业务：
               </td>
               <td>
                  <asp:DropDownList ID="dplBusinessUpd" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
               <td></td>
               <td>
                   入职原因：
               </td>
               <td>
                   <input  class="textbox03" id="txtEmptyCauseUpd" type="text" />
               </td>
           </tr>
           <tr>
               <td></td>
               <td>
                   状态：
               </td>
               <td>
                   <input  class="textbox03" id="txtStautsUpd" type="text" />
               </td>
               <td></td>
               <td>
                   离职时间：
               </td>
               <td>
                   <input  class="textbox03"  id="txtOutDateUpd" type="text"  />
               </td>
           </tr>





            <tr>
                <td></td>
               <td>
                所在区域
               </td>
               <td>
                <asp:DropDownList ID="dplQYUpd" CssClass="textbox03" runat="server" Width="175px"></asp:DropDownList>
               </td>
                <td></td>
                <td>

                </td>
                <td>

                </td>
           </tr>


           <tr>
                <td></td>
               <td>
                日常上班：
               </td>
               <td>
               <input  class="textbox03" id="txtCommUpUpd" type="text" style="width:170px" />
               </td>
                <td></td>
                <td>
                 日常下班：
                </td>
                <td>
                <input  class="textbox03" id="txtCommDownUpd" type="text" style="width:170px" />
                </td>
           </tr>

           <tr>
                <td></td>
               <td>
                周六上班：
               </td>
               <td>
               <input  class="textbox03" id="txtSatUpUpd" type="text" style="width:170px" />
               </td>
                <td></td>
                <td>
                 周六下班：
                </td>
                <td>
                <input  class="textbox03" id="txtSatDownUpd" type="text" style="width:170px" />
                </td>
           </tr>

           <tr>
               <td>

               </td>
               <td>
                   工作内容：
               </td>
               <td  colspan="4">
                   <textarea id="txtWorkContentUpd" class="textbox03" name="S1" style="width:459px"></textarea>
               </td>
           </tr>

            <tr>
               <td>

               </td>
               <td>
                   岗位职责：
               </td>
               <td  colspan="4">
                   <textarea id="txtDutyUpd" class="textbox03" name="S2" style="width:460px"></textarea>
               </td>
           </tr>

           <tr>
               <td  colspan="6" style="height:80px; text-align:right; padding-right:30px">
                  
                   <input id="bthUpdUser" class="button white" type="button" value="修 改" onclick="UpdateUserScript()"  />
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
                    请输入关键字：<span style="color:#cccccc">&nbsp;&nbsp;&nbsp;例如：姓名、手机号、邮箱或办公地点等信息</span>
                </td>
            </tr>
            <tr>
                <td ></td>
                <td>
                    <input id="txtKeyStr" class="textbox03" style=" width:330px" type="text" />
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
