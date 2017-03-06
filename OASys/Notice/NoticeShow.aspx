<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeShow.aspx.cs" Inherits="OASys.Notice.NoticeShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>通知公告详细信息</title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div style="width:1046px;margin:auto;">
			 <div  class="panel-header"  title="项目组成员个人信息" style="padding-left:20px">
              通知公告详细信息
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="NoticeList.aspx">返回列表</a></div> 
			 </div>
             <table style="border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; min-height:456px" cellspacing="0" cellpadding="0">
               <tr >
                     <td style="width:30px"></td>
                     <td style="text-align:center; border-bottom:dashed 1px #ccc;padding-top:10px">
                        <span id="spTitle" style="font-weight:bold;font-size:18px;" runat="server">
                            </span><br /><br />
                        提交人：<span id="spUsName" runat="server"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;提交时间：<span id="spDate" runat="server"></span>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;有效期开始时间：<span id="spBeginDate" runat="server"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;有效期开始时间：<span id="spEndDate" runat="server"></span>
                     </td>
                     <td style="width:30px"></td>
                 </tr>  
              <tr>
                  <td></td>
                  <td style="min-height:300px;vertical-align:top;padding:20px 40px; line-height:30px;border-bottom:dashed 1px #ccc;">
                   <span id="spContent" runat="server"></span>
                  </td>
                  <td></td>
              </tr>
                 <tr>
                     <td></td>
                     <td style="text-align:right;line-height:50px">
                      附件：<span id="spFile" runat="server"></span>
                     </td>
                     <td></td>
                 </tr>
             </table>
      </div>

        <script>

            function GetFile(FileID) {
                $(function () {

                    $.ajax({

                        type: "POST",

                        url: "../Ashx/Notice/DownLoadFileByNoIDHandler.ashx",

                        data: { NoID: FileID },

                        dataType: "json",

                        success: function (data) {
                            $.each(data, function (commentIndex, comment) {
                                window.location.href = "../ExportFile/" + comment["result"];
                            });
                        }

                    });
                })

            }




        </script>


    </form>
</body>
</html>
