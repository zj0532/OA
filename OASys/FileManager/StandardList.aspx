<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StandardList.aspx.cs" Inherits="OASys.FileManager.StandardList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>制度规范列表</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    

</head>
<body>
    <form id="form1" runat="server">
      <table id="dg" title="<%=PageStaute%>规范制度<div style='float:right'><a href='Standard.aspx' class='a1'>返回列表</a></div>" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/File/GetFileListByFceIDHrefHandler.ashx?FceID=<%=FceID %>',method:'POST'">
             
           <thead>
            <tr>
                <th data-options="field:'FileName',width:545">标题</th>
                <th data-options="field:'UsName',width:150,align:'center'">提交人</th>
                <th data-options="field:'FileDate',width:150,align:'center'">提交时间</th>
             
                <th data-options="field:'FileClass',width:150,align:'center'">类别</th>
                <th data-options="field:'FileID',width:150,align:'center',hidden:'true'">FLID</th>
            </tr>
           
        </thead>
        
    </table>
    <div id="DivButton" style="width: 97%; height: auto; position: absolute; left: 0; bottom: 0; padding:5px; text-align:right ">
            <input id="bthAddReport" class="button white" type="button" onclick="GetHref(0)" value="添加制度规范" />
            <input id="bthUpdReport" class="button white" type="button" onclick="GetHref(1)" value="修改制度规范" />
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

        

         function GetHref(obj) {
             if (obj == 0) {
                 window.location.href = "AddStandard.aspx?Fid=0";
             }
             else {
                 if ($('#dg').datagrid('getSelected') == null) {
                     alert("请先选择需要修改的资料!");
                 }
                 else {
                     document.location.href = "AddStandard.aspx?Fid=" + $('#dg').datagrid('getSelected').FileID; //权限跳转页
                 }
             }
         }

      </script>
    </form>
</body>
</html>
