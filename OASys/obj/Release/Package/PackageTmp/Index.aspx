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
              //{
              //    "menuid": "1", "icon": "icon-sys", "menuname": "人力资源",
              //    "menus": [{ "menuid": "11", "menuname": "通讯录", "icon": "icon-nav", "url": "HrManager/AddressList.aspx" },
              //            { "menuid": "12", "menuname": "我的考勤", "icon": "icon-nav", "url": "HrManager/AddUser.aspx" },
                          
              //            { "menuid": "16", "menuname": "新员工须知", "icon": "icon-nav", "url": "HrManager/NewKmpKnow.aspx" }
              //    ]
              //}, {
              //    "menuid": "8", "icon": "icon-sys", "menuname": "作业计划",
              //    "menus": [{ "menuid": "21", "menuname": "计划列表", "icon": "icon-nav", "url": "demo.html" },
                            
              //            { "menuid": "23", "menuname": "值班表", "icon": "icon-nav", "url": "demo1.html" }
              //    ]
              //}, {
              //    "menuid": "56", "icon": "icon-sys", "menuname": "文档管理",
              //    "menus": [{ "menuid": "31", "menuname": "周报管理", "icon": "icon-nav", "url": "demo1.html" },
              //              { "menuid": "32", "menuname": "技术资料", "icon": "icon-nav", "url": "demo1.html" },
              //              { "menuid": "33", "menuname": "会议纪要", "icon": "icon-nav", "url": "demo1.html" },
              //            { "menuid": "34", "menuname": "其它信息", "icon": "icon-nav", "url": "demo2.html" }
              //    ]
              //}, {
              //    "menuid": "28", "icon": "icon-sys", "menuname": "通知公告",
              //    "menus": [{ "menuid": "41", "menuname": "通知列表", "icon": "icon-nav", "url": "demo.html" },
                          
              //            { "menuid": "43", "menuname": "添加通知", "icon": "icon-nav", "url": "demo2.html" }
              //    ]
              //}, {
              //    "menuid": "39", "icon": "icon-sys", "menuname": "资产耗材",
              //    "menus": [{ "menuid": "51", "menuname": "仓储列表", "icon": "icon-nav", "url": "demo.html" },
              //              { "menuid": "52", "menuname": "商品入库", "icon": "icon-nav", "url": "demo1.html" },
              //              { "menuid": "53", "menuname": "商品领用", "icon": "icon-nav", "url": "demo1.html" },
                          
              //            { "menuid": "54", "menuname": "商品报废", "icon": "icon-nav", "url": "demo2.html" }
              //    ]
              //}, {
              //    "menuid": "61", "icon": "icon-sys", "menuname": "管理设置",
              //    "menus": [{ "menuid": "62", "menuname": "个人管理", "icon": "icon-nav", "url": "demo.html" },
              //              { "menuid": "63", "menuname": "组织架构", "icon": "icon-nav", "url": "demo1.html" },
              //              { "menuid": "64", "menuname": "页面配置", "icon": "icon-nav", "url": "demo1.html" },

              //            { "menuid": "65", "menuname": "日志管理", "icon": "icon-nav", "url": "demo2.html" }
              //    ]
              //}

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

          function GetTime() {
              var mon, day, now, hour, min, ampm, time, str, tz, end, beg, sec;
              /*  
              mon = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug",  
                      "Sep", "Oct", "Nov", "Dec");  
              */
              mon = new Array("一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月",
                      "九月", "十月", "十一月", "十二月");
              /*  
              day = new Array("Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat");  
              */
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
              $("#Timer").html(
                      "<nobr>" + day[now.getDay()] + "  " + mon[now.getMonth()] + " "
                              + now.getDate() + "  " + now.getFullYear() + " " + hour
                              + ":" + min + ":" + sec + "</nobr>");

          }



    </script>
       


</head>
<body class="easyui-layout" style="overflow: hidden"  scroll="no">
<noscript>
<div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
    <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
</div></noscript>

    <div region="north" split="true" border="false" style="overflow: hidden; height: 30px;
        background: url(images/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%;
        line-height: 20px;color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float:right; padding-right:20px; padding-top:5px" class="head">登录名：<a href="#" style="text-decoration:none" title="点击进入个人信息"><%= Session["UsName"].ToString () %></a> &nbsp;&nbsp;&nbsp;&nbsp; <span id="Timer"></span>   &nbsp;&nbsp; <a style="color:white" href="Login.aspx">退出</a>&nbsp;&nbsp;</span>
        <span style="padding-left:10px; font-size: 16px; "><img src="image/blocks.gif" width="20" height="20" align="absmiddle" />联通海尔项目组统一办公平台</span>
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
                
			 </div>
              <table style="padding-top:10px; padding-left:10px;">
                  <tr>
                      <td style="padding-left:10px">
                       端午节放假通知
                      </td>
                      <td style="width:60%">

                      </td>
                      <td>
                       2014-05-28
                      </td>
                  </tr>
                   <tr >
                       <td style="padding-left:10px">
                       桌面业务值班表
                       </td>
                       <td>

                       </td>
                       <td>
                        2014-05-28
                       </td>

                   </tr>
                    <tr >
                       <td style="padding-left:10px">
                       项目组出游通知
                       </td>
                       <td>

                       </td>
                       <td>
                           2014-05-27
                       </td>

                   </tr>

              </table>

             </div>
             <%--桌面通知公告 end--%>

             <%--桌面作业计划 begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%;float:left; margin-left:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="作业计划">
             作业计划
                
			 </div>
              <table style="padding-left:10px; padding-top:10px">
                  <tr>
                      <td style="padding-left:10px">
                       计划名称
                      </td>
                      <td style="width:50%">

                      </td>
                      <td>
                       计划开始时间
                      </td>
                  </tr>
                   <tr >
                       <td style="padding-left:10px">
                       日常巡查
                       </td>
                       <td>

                       </td>
                       <td>
                           2014-05-06 08:36:00
                       </td>

                   </tr>
                    <tr >
                       <td style="padding-left:10px">
                       服务器日常维护
                       </td>
                       <td>

                       </td>
                       <td>
                           2014-05-06 18:12:00
                       </td>

                   </tr>





              </table>

             </div>
             <%--桌面作业计划 end--%>
            
             <%--桌面考勤 begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%; float:left;margin-bottom:20px">
			 <div  class="panel-header"  title="我的考勤">
             我的考勤
                
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
           

             <%--桌面待办事项 begin--%>
             <div style="border-bottom:1px solid #ccc; border-left:1px solid #ccc;border-right:1px solid #ccc; width:48%; height:48%;float:left; margin-left:20px;margin-bottom:20px">
			 <div  class="panel-header"  title="待办事项">
             待办事项
                
			 </div>
              <table style="padding-left:10px; padding-top:10px">
                  <tr>
                      <td style="padding-left:10px">
                      
                      </td>
                      <td style="width:50%">

                      </td>
                      <td>
                       
                      </td>
                  </tr>
                  <tr >
                       <td style="padding-left:10px">
                       
                       </td>
                       <td>

                       </td>
                       <td>
                           
                       </td>

                   </tr>
                   <tr >
                       <td style="padding-left:10px">
                       
                       </td>
                       <td>

                       </td>
                       <td>
                           
                       </td>

                   </tr>

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

</body>
</html>
