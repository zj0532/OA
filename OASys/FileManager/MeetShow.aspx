<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetShow.aspx.cs" Inherits="OASys.FileManager.MeetShow" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会议记录</title>
     <link rel="stylesheet" type="text/css" href="../css/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../css/icon.css" />
    <link rel="stylesheet" type="text/css" href="../css/comm.css" />
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <script type="text/javascript" src="../script/jquery.min.js"></script>
    <script type="text/javascript" src="../script/jquery.easyui.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;">
			 <div  class="panel-header"  title="会议纪要" style="height:20px">
                 <div style="float:right;text-align:right; width:50px;"><a class="a1" title="返回列表" href="MeetSummary.aspx" style="vertical-align:text-bottom">返回列表</a></div>
              
			 </div>
        
             <table style="padding-right:10px; padding-left:10px;border-bottom:1px solid #ccc;border-left:1px solid #ccc;border-right:1px solid #ccc; width:100%;">
                  <tr >
                      <td >
                      
                      </td>

                  </tr>

                  <tr >
                      <td style="padding-left:10px;border-bottom:dashed 1px #ccc; text-align:center;height:30px; ">
                      <b >
                          <span id="labTitle" runat="server" style="font-size:18px"></span></b> 
                      </td>

                  </tr>
                  <tr >
                      <td style="padding-left:10px;text-align:center;height:30px; line-height:23px;border-bottom:dashed 1px #ccc;">
                      会议时间：<asp:Label ID="labDate" runat="server" Text=""></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 会议地点：<asp:Label ID="labAddress" runat="server" Text=""></asp:Label>
                         
                      <br /> 主持人：<asp:Label ID="labCompere" runat="server" Text=""></asp:Label>
                          
                      <br /> 参会人员：<asp:Label ID="labJoiner" runat="server" Text=""></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 记录员:<asp:Label ID="labUsName" runat="server" Text=""></asp:Label>
                      </td>

                  </tr>
                   
                    
                  <tr>
                      <td style="padding:10px; border-bottom:dashed 1px #cccccc">
                       <span style="font-size:14px;color:#808080">会议内容：</span><br /><br />
                       <asp:Label ID="labContent" runat="server" Text=""></asp:Label>

                      </td>
                  </tr>
                 <asp:Repeater ID="repList" runat="server">
                 <ItemTemplate>
                      <tr>
                      <td style="padding:10px; border-bottom:dashed 1px #cccccc">
                       <span style="font-size:14px;color:#808080">任务反馈：</span><br /><br />
                        <%#Eval("SuContent") %>
                          <br /><br />

                      <div style="float:right;text-align:right; width:300px;">反馈时间：<%#Convert .ToDateTime( Eval("Date")).ToString("yyyy-MM-dd HH:mm:ss") %>反馈人：  <%#Eval("UsName") %></div>
                      </td>
                      </tr>  
                 </ItemTemplate> 
                 </asp:Repeater>

              
               
                 <tr>
                     <td>
                          <CE:Editor ID="Editor1" runat="server" Width="100%" AutoConfigure="Simple">
                          </CE:Editor>


                     </td>
                 </tr>
                 <tr>
                     <td>

                     </td>
                 </tr>
                 

                  <tr>
                   <td style="height:20px">
                       <asp:Button ID="bthAdd" class="button white" runat="server" Text="提 交" OnClick="bthAdd_Click" />
                       <asp:Button ID="bthCanel" class="button white"  runat="server" Text="返 回" OnClick="bthCanel_Click" />
                   </td>
               </tr>
               <tr>
                  <td>

                 </td>
              </tr>

              </table>

             </div>
             

    </form>
</body>
</html>
