<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportantShow.aspx.cs" Inherits="OASys.FileManager.ImportantShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>
    <script>
        $(document).bind("contextmenu", function (e) {
            return false;
        });
        function key() {
            if (event.shiftKey) {
                window.close();
            }
            //禁止Shift
            if (event.altKey) {
                window.close();
            }
            //禁止Alt
            if (event.ctrlKey) {
                window.close();
            }
            //禁止Ctrl
            return false;
        }
        document.onkeydown = key;


    </script>

    <script type="text/javascript">

        var omitformtags = ["input", "textarea", "select"]

        omitformtags = omitformtags.join("|")

        function disableselect(e) {
            if (omitformtags.indexOf(e.target.tagName.toLowerCase()) == -1)
                return false
        }

        function reEnable() {
            return true
        }

        if (typeof document.onselectstart != "undefined")
            document.onselectstart = new Function("return false")
        else {
            document.onmousedown = disableselect
            document.onmouseup = reEnable
        }
</script> 



    <noscript>
        <iframe src="404.HTML"></iframe>
    </noscript> 
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:1046px; margin:auto;height:500px ">
			 <div  class="panel-header"  title="工作纪要" style="padding-left:20px; ">
              核心资料
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="Important.aspx">返回列表</a></div> 
			 </div>
             <table style="padding-right:10px; padding-left:18px; padding-top:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; ">
             
                 <tr>
                 <td style=" text-align:center;">
                  <span style="font-size:18px;" id="spTitle" runat="server"></span>
                 </td>

             </tr>
             <tr>
                 <td style=" text-align:center;">
                  发布人：<asp:Label ID="labUsName" runat="server" Text=""></asp:Label>
                  &nbsp;&nbsp;&nbsp;发布时间：<asp:Label ID="labDate" runat="server" Text=""></asp:Label>
             </td>
             </tr>
             <tr>
                <td style="vertical-align:top; min-height:400px">

                <div>
                <asp:Label ID="labContent" runat="server" Text=""></asp:Label>
                </div>
              </td>
              </tr>
              </table>
    </div>
    </form>
</body>
</html>
