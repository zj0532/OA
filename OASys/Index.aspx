<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OASys.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>统一办公平台</title>
    
    <link rel="stylesheet" type="text/css" href="css/default/easyui.css" />
	<link rel="stylesheet" type="text/css" href="css/icon.css" />
	<link rel="stylesheet" type="text/css" href="css/comm.css" />
    <link rel="stylesheet" type="text/css" href="css/default.css" />
    <script type="text/javascript" src="script/jquery.min.js"></script>
	<script type="text/javascript" src="script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="script/icon.js"></script>
    
    <script type="text/javascript">

          var _menus = {
              "menus": [
                 
                  <%=Menu%>
              

              ]
          };


          //初始化左侧
          function InitLeftMenu1() {

              $(".easyui-accordion1").empty();
              var menulist = "";

              $.each(_menus.menus, function (i, n) {
                  menulist += '<div title="' + n.menuname + '"  icon="' + n.icon + '" style="overflow:auto;">';
                  menulist += '<ul>';
                  $.each(n.menus, function (j, o) {
                      menulist += '<li><div><a ref="' + o.menuid + '" href="#" rel="' + o.url + '" ><span class="icon ' + o.icon + '" >&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div></li> ';
                  })
                  menulist += '</ul></div>';
              })

              $(".easyui-accordion1").append(menulist);

              $('.easyui-accordion1 li a').click(function () {
                  var tabTitle = $(this).children('.nav').text();

                  var url = $(this).attr("rel");
                  var menuid = $(this).attr("ref");
                  var icon = getIcon(menuid, icon);

                  addTab(tabTitle, url, icon);
                  $('.easyui-accordion1 li div').removeClass("selected");
                  $(this).parent().addClass("selected");
              }).hover(function () {
                  $(this).parent().addClass("hover");
              }, function () {
                  $(this).parent().removeClass("hover");
              });

              //导航菜单绑定初始化
              $(".easyui-accordion1").accordion();
          }


          $(function () {
              var formLogin = $('#formLogin');

              InitLeftMenu1();

          });



        //动态时间
          $(function () {
              setInterval("GetTime()", 1000);
          });

          function Appendzero(obj) {
              if (obj < 10) return "0" + "" + obj;
              else return obj;

          }

          function GetTime() {
              $.ajax({
                  type: 'post',
                  url: 'Ashx/Time/Time.ashx',
                  success: function (msg) {
                      $("#Timer").html(
                      "<nobr>" + msg + "</nobr>");
                  }
              });
              /*var mon, day, now, hour, min, ampm, time, str, tz, end, beg, sec;
               
              mon = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug",  
                      "Sep", "Oct", "Nov", "Dec");  
              
              mon = new Array("01", "02", "03", "04", "05", "06", "07", "08",
                      "09", "10", "11", "12");
                
              day = new Array("Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat");  
              
              day = new Array("周日", "周一", "周二", "周三", "周四", "周五", "周六");
              now = new Date();
              hour = now.getHours();
              min = now.getMinutes();
              sec = now.getSeconds();
              if (hour < 10) {
                  hour = "0" + hour;
              }
              if (min < 10) {
                  min = "0" + min;
              }
              if (sec < 10) {
                  sec = "0" + sec;
              }
              */
              
                
          }
        


    </script>
       
    <style>
      .icon-d{
          background:url(image/tabicons.png) no-repeat; width:16px; height:16px; position:absolute;
          background-position: -100px -18px;
      }  
    </style>

</head>
<body class="easyui-layout" style="overflow: hidden"  scroll="no">
<noscript>
<div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
    <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
</div></noscript>

    <div region="north" split="true" border="false" style="overflow: hidden; height: 30px;
        background: url(images/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%;
        line-height: 20px;color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float:right; padding-right:20px; padding-top:5px" class="head">登录名：<a href="#" onclick="addTab('通讯录', 'HrManager/UserInfo.aspx?UsID=<%= Session["UsID"].ToString () %>', 'icon-nav')" style="text-decoration:none" title="点击进入个人信息"><%= Session["UsName"].ToString () %></a> &nbsp;&nbsp;&nbsp;&nbsp; <span id="Timer"></span>   &nbsp;&nbsp; <a style="color:white" href="Login.aspx">退出</a>&nbsp;&nbsp;</span>
        <span style="padding-left:10px; font-size: 16px; "><img src="image/blocks.gif" width="20" height="20" align="absmiddle" />联通项目组统一办公平台</span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2; ">
        <div class="footer">版权所有</div>
    </div>
    <div region="west" split="true" title="导航菜单" style="width:180px;" id="west">
        <div class="easyui-accordion1" fit="true" border="false">
		<!--  导航内容 -->
	
		</div>

    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow:hidden;" onscroll="no">
        <div id="tabs" class="easyui-tabs"  fit="true" border="false" onscroll="no">
			<div title="我的桌面"  style="overflow:hidden; padding:20px 20px 20px 40px" id="home">
            
            <%--桌面通知公告 begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%;float:left; ">
			 <div  class="panel-header"  title="通知公告">
             通知公告
             <div style="width:50px; float:right"><a class="a1" title="显示更多信息" href="#" onclick="addTab('通知列表', 'Notice/NoticeList.aspx', 'icon-nav')">More...</a></div> 
			 </div>
              <table style="padding-top:10px; padding-left:10px;">
                  <tr>
                      <td style="padding-left:10px;width:220px">
                      标题
                      </td>
                      <td style="width:25%;text-align:center">
                       作者
                      </td>
                      <td style="width:25%;text-align:center">
                       提交时间
                      </td>
                  </tr>

                  <asp:Repeater ID="RepNoticeList" runat="server">
                  <ItemTemplate>
                   <tr >
                       <td style="padding-left:10px">
                       <a style="cursor:pointer" title="<%#Eval("Title").ToString() %>" onclick="addTab('通知列表', 'Notice/NoticeShow.aspx?Ntid=<%#Eval("Noid") %>', 'icon-nav')"><%#Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(1,18)+"...":Eval("Title").ToString() %></a>
                       </td>
                       <td style="width:25%;text-align:center">
                       <%# new BLL.UserInfoBLL().GetModel(Convert .ToInt32(Eval("UsID").ToString ())).UsName %>
                       </td>
                       <td style="width:25%;text-align:center">
                        <%#Convert.ToDateTime( Eval("Date")).ToString("yyyy-MM-dd") %>
                       </td>
                   </tr>
                   </ItemTemplate>
                   </asp:Repeater>

              </table>

             </div>
             <%--桌面通知公告 end--%>

             <%--桌面作业计划 begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%;float:left; margin-left:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="作业计划">
                作业计划  
                <div style="width:50px; float:right"><a class="a1" title="显示更多信息" href="#" onclick="addTab('我的作业计划', 'WorkPlan/MyPlan.aspx', 'icon-nav')">More...</a></div> 
			 </div>
              <table style="padding-left:10px; padding-top:10px">
                  <tr>
                      <td style="padding-left:10px;width:220px">
                       计划名称
                      </td>
                      <td style="width:25%; text-align:center">
                       计划开始时间
                      </td>
                      <td style="width:25%; text-align:center">
                       计划结束时间
                      </td>
                  </tr>
                
                  <asp:Repeater ID="WorkPlanRep" runat="server">
                  <ItemTemplate>
                  <tr>
                      <td style="padding-left:10px">
                      <%--<a href='WorkPlan/PlanShow.aspx?wpid=<%#Eval("wpid") %>' target="_blank" class="a1" title="点击进入详细信息"><%#Eval("WPTitle").ToString().Length>10?Eval("WPTitle").ToString().Substring(1,10)+"...":Eval("WPTitle").ToString() %></a>--%>
                      <a style="cursor:pointer" title="<%#Eval("WPTitle").ToString() %>" onclick="addTab('我的作业计划', 'WorkPlan/PlanShow.aspx?wpid=<%#Eval("wpid") %>', 'icon-nav')"><%#Eval("WPTitle").ToString().Length>18?Eval("WPTitle").ToString().Substring(1,18)+"...":Eval("WPTitle").ToString() %></a>
                      </td>
                      <td style="width:25%; text-align:center">
                       <%#Convert.ToDateTime( Eval("BeginDate")).ToString("yyyy-MM-dd") %>
                      </td>
                      <td style="width:25%; text-align:center">
                       <%#Convert.ToDateTime( Eval("EndDate")).ToString("yyyy-MM-dd") %>
                      </td>
                  </tr>
                  </ItemTemplate>
                  </asp:Repeater>

              </table>

             </div>
             <%--桌面作业计划 end--%>
            
             <%--桌面考勤 begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%; float:left;margin-bottom:20px">
			 <div  class="panel-header"  title="我的考勤">
             我的考勤
             <div style="width:50px; float:right"><a class="a1" title="显示更多信息" href="#" onclick="addTab('我的考勤', 'HrManager/UserAttendance.aspx', 'icon-nav')">More...</a></div>    
			 </div>
              <table style="padding-left:10px; padding-top:10px">
                  <tr>
                      <td style="padding-left:10px;text-align:center">
                       任务名称
                      </td>
                      <td style="width:60%; text-align:center">
                       登陆IP地址
                      </td>
                      <td style="text-align:center">
                       任务时间
                      </td>
                  </tr>
                  <asp:Repeater ID="RepAttendance" runat="server">
                      <ItemTemplate>
                       <tr>
                           <td style="padding-left:10px;text-align:center">
                               <%#Eval("PostCause") %>
                           </td>
                           <td style="text-align:center">
                               <%#Eval("Postip") %>
                           </td>
                           <td>
                                <%#Convert.ToDateTime(Eval("Postdate")).ToString("yyyy-MM-dd HH:mm:ss") %>
                           </td>

                       </tr>
                      </ItemTemplate>
                  </asp:Repeater>

                   

              </table>

             </div>
             <%--桌面考勤 end--%>
           

             <%--值班表begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%;float:left; margin-left:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="值班表">
             值班表
             <div style="width:50px; float:right"><a class="a1" title="显示更多信息" href="#" onclick="addTab('值班表', 'WorkPlan/DutyTable.aspx', 'icon-nav')">More...</a></div>    
			 </div>
              <table style="padding-left:10px; padding-top:10px;width:100%">
                  <tr>
                      <td style="padding-left:10px;width:220px">
                       标题
                      </td>
                      <td style="width:25%;text-align:center">
                       作者
                      </td>
                      <td style="width:25%;text-align:center">
                       上传时间
                      </td>
                  </tr>

                   <asp:Repeater ID="RepDutyTable" runat="server">
                   <ItemTemplate>
                     <tr >
                       <td style="padding-left:10px">
                       <a href='#'  title='点击下载：<%#Eval("kwTitle") %>' onclick="GetFile('<%#Eval("kwid") %>')" > <%#Eval("kwTitle").ToString().Length>18?Eval("kwTitle").ToString().Substring(0,18)+"...":Eval("kwTitle").ToString() %></a>
                       </td>
                       <td style="text-align:center">
                        <%# new BLL.UserInfoBLL().GetModel(Convert .ToInt32(Eval("UsID").ToString ())).UsName %>
                       </td>
                       <td style="text-align:center">
                        <%#Convert .ToDateTime( Eval("date")).ToString("yyyy-MM-dd") %>
                       </td>
                    </tr>
                    </ItemTemplate>
                    </asp:Repeater>
              </table>

             </div>
             <%--桌面待办事项 end--%>
            

			</div>
		</div>
    </div> 
   
	<div id="mm" class="easyui-menu" style="width:150px;">
		<div id="mm-tabclose">关闭</div>
		<div id="mm-tabcloseall">全部关闭</div>
		<div id="mm-tabcloseother">除此之外全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-tabcloseright">当前页右侧全部关闭</div>
		<div id="mm-tabcloseleft">当前页左侧全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-exit">退出</div>
	</div>

    <script>
        function addTab(title, href, icon) {
            var tt = $('#tabs');
            if (tt.tabs('exists', title)) {//如果tab已经存在,则选中并刷新该tab          
                tt.tabs('select', title);

            } else {
                var content = "";
                if (href) {
                    content = '<iframe  frameborder="0"  src="' + href + '" style="width:100%;height:99%;overflow:auto;"></iframe>';
                } else {
                    content = '未实现';
                }
                tt.tabs('add', {
                    title: title,
                    closable: true,
                    content: content,
                    iconCls: 'icon-d'
                });
            }
        }

        function GetFile(FileID) {
            $(function () {

                $.ajax({

                    type: "POST",

                    url: "Ashx/Table/DownLoadFileByKwIDHandler.ashx",

                    data: { kwid: FileID },

                    dataType: "json",

                    success: function (data) {
                        $.each(data, function (commentIndex, comment) {
                            window.location.href = "ExportFile/" + comment["result"];
                        });
                    },
                    error: function ()
                    { alert("shibai");}
                    

                });
            })

        }



    </script>
   
</body>
</html>
