﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAndMeet.aspx.cs" Inherits="OASys.FileManager.AddAndMeet" %>

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
</head>
<body style="overflow:hidden;" scroll="no">
    <form id="form1" runat="server">
     
          <div style="width:1046px; margin:auto;height:500px ">
			 <div  class="panel-header"  title="工作纪要" style="padding-left:20px; ">
              添加工作纪要
             <div style="width:50px; float:right"><a class="a1" title="返回列表" href="MeetSummary.aspx">返回列表</a></div> 
			 </div>
              <table style="padding-right:10px; padding-left:18px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%; ">
                   <tr style="height:100px">


                   </tr>
                   <tr>
                      <td style="width:80px"></td>
                      <td style="width:80px">
                      会议标题  
                      </td>
                      <td>  
                           <input id="txtTitle"   runat="server" class="textbox03" style=" width:100%" type="text" /> 
                      </td>
                     <td style="width:80px"></td>
                  </tr>
                  <tr>
                     <td style="width:80px"></td>
                      <td style="width:80px">
                      会议时间：  
                      </td>
                      <td>
                         <input id="txtDate"   runat="server" class="easyui-datetimebox" style=" width:500px"  /> 
                      </td>
                     <td style="width:80px"></td>
                  </tr>
                   <tr >
                      <td style="width:80px"></td>
                      <td style="width:80px">
                      会议地点：  
                      </td>
                      <td >
                          <input id="txtAddress"   runat="server" class="textbox03" style=" width:100%" type="text" /> 
                      </td>
                      <td style="width:80px"></td>
                  </tr>

                   <tr >
                     <td style="width:80px"></td>
                      <td style="width:80px">
                      会议主持：  
                      </td>
                      <td >
                           
                          <input id="txtCompere" runat="server"  class="textbox03" style=" width:100%" type="text" /> 
                      </td>
                     <td style="width:80px"></td>
                  </tr>
                  <tr >
                     <td style="width:80px"></td>
                      <td style="width:80px">
                      参会人员：  
                      </td>
                      <td >
                          <input id="txtJoiner" runat="server"  class="textbox03" style=" width:100%" type="text" /> 
                      </td>
                    <td style="width:80px"></td>
                  </tr>

                  <tr >
                     <td style="width:80px"></td>
                      <td style="width:80px">
                      选择文档：  
                      </td>
                      <td >
                        <asp:FileUpload ID="FileUpLoad1" runat="server" Width="500px" />   
                      </td> 
                      <td style="width:80px"></td>
                  </tr>

                  <tr > 
                      <td style="width:80px"></td>
                      <td style="width:80px">
                      提交文档：  
                      </td>
                      <td>            
                         <asp:Button ID="bthAddFile" runat="server" CssClass="button white" Text="提 交" OnClick="bthAddFile_Click"  />
                         <input id="bthCanel" class="button white" type="button"  value="取 消" />
                      </td>
                     
                      <td style="width:80px"></td>
                  </tr>

                  <tr>
                     <td colspan="6" style="height:170px"></td>
                  </tr>
              </table>

             </div>
          <script type="text/javascript">
              function getFullPath() {

                  if ((window.navigator.userAgent.indexOf('MSIE') >= 0) && (navigator.userAgent.indexOf('Opera') < 0)) {
                      var isIE = (document.all) ? true : false;
                      var isIE6 = isIE && (navigator.userAgent.indexOf('MSIE 6.0') != -1);
                      var isIE7 = isIE && (navigator.userAgent.indexOf('MSIE 7.0') != -1);
                      var isIE8 = isIE && (navigator.userAgent.indexOf('MSIE 8.0') != -1);

                      var file = document.getElementById("FileUp");
                      if (isIE7 || isIE8) {
                          file.select();
                          var fullpath = document.selection.createRange().text;
                          document.getElementById("hid_hidpicpath").value = fullpath;     //隐藏域
                          document.selection.empty();
                      }
                      else {//机器上没安装ie6，还未测试ie6能直接获得完整路径不? GAGAHJT 2010
                          var file = document.getElementById("FileUp");
                          document.getElementById("hid_hidpicpath").value = file.value;    //隐藏域
                      }
                  }
                  else if (navigator.userAgent.indexOf('Firefox') != -1) {
                      try {
                          netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                      }
                      catch (e) {
                          document.getElementById("FileUpload1").value = "";
                          var tip = "如果您用的是火狐浏览器请设置如下：/n/n在地址栏输入： about:config /n然后找到" +
                          "signed.applets.codebase_principal_support" +
                          "双击进行修他后面的键值，将值修改为true关闭即可，否则您不能上传！";
                          alert(tip);
                          return;
                      }
                      var fname = document.getElementById("FileUp").value;
                      var file = Components.classes["@mozilla.org/file/local;1"].createInstance(Components.interfaces.nsILocalFile);
                      try {
                          file.initWithPath(fname.replace("////g", "\\\\"));
                      }
                      catch (e) {
                          if (e.result != Components.results.NS_ERROR_FILE_UNRECOGNIZED_PATH) throw e;
                          alert(' 无法加载文件 ');
                          return;
                      }
                      document.getElementById("hid_hidpicpath").value = fname;     //隐藏域
                  }
                  else if (navigator.userAgent.indexOf('Opera') >= 0) {
                      //未测试。。。。。。。。
                  }
              }
   </script>




    </form>
</body>
</html>
