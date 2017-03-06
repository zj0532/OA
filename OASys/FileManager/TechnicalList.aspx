<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicalList.aspx.cs" Inherits="OASys.FileManager.TechnicalList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>技术资料文档</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    

</head>
<body>
    <form id="form1" runat="server">

     <table id="dg" title="<%=TechnicalName %>文档列表 <div style='float:right'><a href='Technical.aspx' class='a1'>返回列表</a></div>" style="width:1046px;height:460px"
           data-options="rownumbers:true,singleSelect:true,pagination:true,url:'../Ashx/File/GetFileListByFceIDHandler.ashx?FceID=<%=TechnicalID %>',method:'POST'">
        <thead>
            <tr>
                <th data-options="field:'FileName',width:580">文档名称</th>
                <th data-options="field:'UsName',width:100,align:'center'">上传人</th>
                <th data-options="field:'FileDate',width:200,align:'center'">日期</th>
                <th data-options="field:'DownLoad',width:100,align:'center'">下载</th>
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

             

              function Download(FlID)
              {
                  $(function () {

                      $.ajax({

                          type: "POST",

                          url: "../Ashx/File/DownLoadFileByFileIDHandler.ashx",

                          data: { FiID: FlID },

                          dataType: "json",

                          success: function (data) {
                              $.each(data, function (commentIndex, comment) {
                                  window.location.href = "../ExportFile/" + comment["result"];

                              });

                          }

                      });
                  });
              }
        </script>


    </form>
</body>
</html>
