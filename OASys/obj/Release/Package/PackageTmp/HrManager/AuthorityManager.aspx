<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorityManager.aspx.cs" Inherits="OASys.HrManager.AuthorityManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>权限管理</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script>
        var jishuqi = 0;
        function request(paras) {
            var url = location.href;
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            var paraObj = {}
            for (i = 0; j = paraString[i]; i++) {
                paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
            }
            var returnValue = paraObj[paras.toLowerCase()];
            if (typeof (returnValue) == "undefined") {
                return "";
            } else {
                return returnValue;
            }
        }


    </script>
</head>
<body >
    <form id="form1" runat="server">
    <%--<div style="width:230px;margin-right:20px;margin-bottom:20px;height:460px;float:left; overflow-y:scroll;">
			 <div  class="panel-header"  title="项目组员工信息" style="padding-left:20px">
              项目组组员信息
            
			 </div>
             <table style="padding-right:10px; padding-left:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;height:90%">
             <tr>
                 <td >
                     <asp:TreeView ID="treUserInfo" runat="server"></asp:TreeView>
                 

                 </td>

             </tr>
             </table>

    </div>--%>

        <div style="width:1030px; margin-right:20px;margin-bottom:20px;height:480px;">
			 <div  class="panel-header"  title="页面权限配置" style="padding-left:20px">
              页面权限配置
            
			 </div>
             <table style="padding-right:10px; padding-left:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;height:90%">
             <tr>
                 <td style="vertical-align:top">
                    
                         
                     <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                     <HeaderTemplate>
                     <table>
                     </HeaderTemplate>
                     <ItemTemplate>
                     <tr>
                         <td style="height:20px">

                         </td>
                     </tr>
                     <tr >
                     <td style="border:1px dotted #ccc; ">
                      导航菜单： <%#Eval("PsName") %>   
                     </td>
                     </tr>
                     <tr>
                     <asp:Repeater ID="Repeater2" runat="server">
                      <ItemTemplate>
                          <td style="border:1px dotted #ccc;width:180px">
                           <%#Eval("PsName") %>： &nbsp;&nbsp;&nbsp;&nbsp;<input id="<%#Eval("PsName")+"读" %>" class="check" value="<%#Eval("PsID")+"-1" %>" type="checkbox"  />读&nbsp;&nbsp; <input id="<%#Eval("PsName")+"写" %>" class="check" value="<%#Eval("PsID")+"-2" %>" type="checkbox" />写
                          </td>
                         <script>
                             jishuqi++;
                             if (jishuqi % 5 == 0)
                                 document.write("</tr><tr>");
                         </script>
                      </ItemTemplate>
                     </asp:Repeater>
                     </tr>

                     </ItemTemplate>
                      <FooterTemplate>
                      </table>

                      </FooterTemplate>
                     </asp:Repeater>
                     
                 </td>

             </tr>
             </table>

    </div>

        <div style="width: 99%; height: auto; position: absolute; left: 0; bottom: -40px; padding:5px; text-align:right ">
            <input id="bthSelectAll" class="button white" type="button" onclick="SelectAll(true)"  value="全 选" />
            <input id="bthSelectNo" class="button white" type="button"  onclick="SelectAll(false)" value="全 消" />
            <input id="bthZuYuan" class="button white" type="button" onclick="ZuYuan()" value="组 员" />
            <input id="bthZhuGuan" class="button white" type="button" onclick="ZhuGuan()" value="主 管" />
            <input id="bthAddShow" class="button white" type="button" onclick="GetSelectValue()"  value="确 定" />
            <input id="bthUpdateShow" class="button white" type="button" onclick="window.location.href = 'AddressList.aspx'" value="返 回" />
        
        </div>

        <script>
            function GetSelectValue()
            {
                var obj = "";
                $("input[type='checkbox']:checked").each(
                    function () {
                        obj = $(this).val() + "," + obj;

                 });

               
                var uid = request("Usid");
               
                $(function () {

                    $.ajax({

                        type: "POST",

                        url: "../Ashx/Authority/ModifyAuthorityHandler.ashx",

                        data: { UsID:uid, AuthList:obj },

                        dataType: "json",

                        success: function (data) {
                            alert("操作完成");
                           
                        },
                        error:function(){
                            alert("操作失败");
                        }

                    });
                });






            }


            function SelectAll(obj)
            {
                $(".check").attr("checked", obj); 
            }
            function ZuYuan()
            {
              $("#通讯录读").attr("checked", true);
            
              $("#我的考勤读").attr("checked", true);
              
              $("#新员工须知读").attr("checked", true);

            }

            function ZhuGuan() {
                $("#通讯录读").attr("checked", true);
               
                $("#我的考勤读").attr("checked", true);
                $("#我的考勤写").attr("checked", true);
                $("#考勤查询读").attr("checked", true);
                $("#考勤查询写").attr("checked", true);
                $("#请假审批读").attr("checked", true);
                $("#请假审批写").attr("checked", true);
                $("#请假历史记录读").attr("checked", true);
                $("#请假历史记录写").attr("checked", true);
                $("#加班审核读").attr("checked", true);
                $("#加班审核写").attr("checked", true);
                $("#加班历史记录读").attr("checked", true);
                $("#加班历史记录写").attr("checked", true);
                $("#新员工须知读").attr("checked", true);
                $("#新员工须知写").attr("checked", true);
            }



            $(function () {

                $.ajax({

                    type: "POST",

                    url: "../Ashx/Authority/GetAuthorityByUsIDHandler.ashx",

                    data: { UsID: request("Usid")},

                    dataType: "json",

                    success: function (data) {

                        $.each(data, function (commentIndex, comment) {
                           
                            $("#" + comment["Name"]).attr("checked", true);
                        });

                    }

                });

            });


        </script>


    </form>
</body>
</html>
