var OxO3f7d=["SetStyle","length","","GetStyle","GetText",":",";","cssText","tblBorderStyle","sel_style","sel_border","sel_part","bordercolor","bordercolor_Preview","inp_color","inp_color_Preview","inp_shade","inp_shade_Preview","inp_MarginLeft","inp_MarginRight","inp_MarginTop","inp_MarginBottom","inp_PaddingLeft","inp_PaddingRight","inp_PaddingTop","inp_PaddingBottom","inp_width","sel_width_unit","inp_height","sel_height_unit","inp_id","inp_class","sel_align","sel_textalign","sel_float","inp_tooltip","value","borderColor","style"," ","backgroundColor","color","id","className","width","height","inp_","sel_","_unit","selectedIndex","options","align","styleFloat","cssFloat","textAlign","title","borderWidth","borderLeftWidth","borderTopWidth","borderRightWidth","borderBottomWidth","borderLeftStyle","borderTopStyle","borderRightStyle","borderBottomStyle","none","border","-","red","paddingLeft","paddingRight","paddingTop","paddingBottom","marginLeft","marginRight","marginTop","marginBottom","[[ValidID]]","class","onclick"];function pause(Ox4a3){var Oxa8= new Date();var Ox4a4=Oxa8.getTime()+Ox4a3;while(true){Oxa8= new Date();if(Oxa8.getTime()>Ox4a4){return ;} ;} ;} ;function StyleClass(Ox201){var Ox4a6=[];var Ox4a7={};if(Ox201){Ox4ac();} ;this[OxO3f7d[0]]=function SetStyle(name,Ox4f,Ox4a9){name=name.toLowerCase();for(var i=0;i<Ox4a6[OxO3f7d[1]];i++){if(Ox4a6[i]==name){break ;} ;} ;Ox4a6[i]=name;Ox4a7[name]=Ox4f?(Ox4f+(Ox4a9||OxO3f7d[2])):OxO3f7d[2];} ;this[OxO3f7d[3]]=function GetStyle(name){name=name.toLowerCase();return Ox4a7[name]||OxO3f7d[2];} ;this[OxO3f7d[4]]=function Ox4ab(){var Ox201=OxO3f7d[2];for(var i=0;i<Ox4a6[OxO3f7d[1]];i++){var Ox27=Ox4a6[i];var p=Ox4a7[Ox27];if(p){Ox201+=Ox27+OxO3f7d[5]+p+OxO3f7d[6];} ;} ;return Ox201;} ;function Ox4ac(){var arr=Ox201.split(OxO3f7d[6]);for(var i=0;i<arr[OxO3f7d[1]];i++){var p=arr[i].split(OxO3f7d[5]);var Ox27=p[0].replace(/^\s+/g,OxO3f7d[2]).replace(/\s+$/g,OxO3f7d[2]).toLowerCase();Ox4a6[Ox4a6[OxO3f7d[1]]]=Ox27;Ox4a7[Ox27]=p[1];} ;} ;} ;function GetStyle(Ox137,name){return  new StyleClass(Ox137.cssText).GetStyle(name);} ;function SetStyle(Ox137,name,Ox4f,Ox4ad){var Ox4ae= new StyleClass(Ox137.cssText);Ox4ae.SetStyle(name,Ox4f,Ox4ad);Ox137[OxO3f7d[7]]=Ox4ae.GetText();} ;function ParseFloatToString(Ox24){if(!Ox24){return OxO3f7d[2];} ;var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO3f7d[2];} ;return Ox8+OxO3f7d[2];} ;var tblBorderStyle=Window_GetElement(window,OxO3f7d[8],true);var sel_style=Window_GetElement(window,OxO3f7d[9],true);var sel_border=Window_GetElement(window,OxO3f7d[10],true);var sel_part=Window_GetElement(window,OxO3f7d[11],true);var bordercolor=Window_GetElement(window,OxO3f7d[12],true);var bordercolor_Preview=Window_GetElement(window,OxO3f7d[13],true);var inp_color=Window_GetElement(window,OxO3f7d[14],true);var inp_color_Preview=Window_GetElement(window,OxO3f7d[15],true);var inp_shade=Window_GetElement(window,OxO3f7d[16],true);var inp_shade_Preview=Window_GetElement(window,OxO3f7d[17],true);var inp_MarginLeft=Window_GetElement(window,OxO3f7d[18],true);var inp_MarginRight=Window_GetElement(window,OxO3f7d[19],true);var inp_MarginTop=Window_GetElement(window,OxO3f7d[20],true);var inp_MarginBottom=Window_GetElement(window,OxO3f7d[21],true);var inp_PaddingLeft=Window_GetElement(window,OxO3f7d[22],true);var inp_PaddingRight=Window_GetElement(window,OxO3f7d[23],true);var inp_PaddingTop=Window_GetElement(window,OxO3f7d[24],true);var inp_PaddingBottom=Window_GetElement(window,OxO3f7d[25],true);var inp_width=Window_GetElement(window,OxO3f7d[26],true);var sel_width_unit=Window_GetElement(window,OxO3f7d[27],true);var inp_height=Window_GetElement(window,OxO3f7d[28],true);var sel_height_unit=Window_GetElement(window,OxO3f7d[29],true);var inp_id=Window_GetElement(window,OxO3f7d[30],true);var inp_class=Window_GetElement(window,OxO3f7d[31],true);var sel_align=Window_GetElement(window,OxO3f7d[32],true);var sel_textalign=Window_GetElement(window,OxO3f7d[33],true);var sel_float=Window_GetElement(window,OxO3f7d[34],true);var inp_tooltip=Window_GetElement(window,OxO3f7d[35],true);UpdateState=function UpdateState_Div(){} ;function doBorderStyle(Ox120){sel_style[OxO3f7d[36]]=Ox120;} ;function doPart(Ox120){sel_part[OxO3f7d[36]]=Ox120;} ;function doWidth(Ox120){sel_border[OxO3f7d[36]]=Ox120;} ;SyncToView=function SyncToView_Div(){if(Browser_IsWinIE()){bordercolor[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[37]];} else {var arr=revertColor(element[OxO3f7d[38]].borderColor).split(OxO3f7d[39]);bordercolor[OxO3f7d[36]]=arr[0];} ;bordercolor[OxO3f7d[38]][OxO3f7d[40]]=bordercolor[OxO3f7d[36]];bordercolor_Preview[OxO3f7d[38]][OxO3f7d[40]]=bordercolor[OxO3f7d[36]];inp_color[OxO3f7d[36]]=revertColor(element[OxO3f7d[38]].color);inp_color[OxO3f7d[38]][OxO3f7d[40]]=element[OxO3f7d[38]][OxO3f7d[41]];inp_color_Preview[OxO3f7d[38]][OxO3f7d[40]]=element[OxO3f7d[38]][OxO3f7d[41]];inp_shade[OxO3f7d[36]]=revertColor(element[OxO3f7d[38]].backgroundColor);inp_shade[OxO3f7d[38]][OxO3f7d[40]]=element[OxO3f7d[38]][OxO3f7d[40]];inp_shade_Preview[OxO3f7d[38]][OxO3f7d[40]]=element[OxO3f7d[38]][OxO3f7d[40]];inp_id[OxO3f7d[36]]=element[OxO3f7d[42]];if(ParseFloatToString(element[OxO3f7d[38]].marginLeft)){inp_MarginLeft[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].marginLeft);} ;if(ParseFloatToString(element[OxO3f7d[38]].marginRight)){inp_MarginRight[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].marginRight);} ;if(ParseFloatToString(element[OxO3f7d[38]].marginTop)){inp_MarginTop[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].marginTop);} ;if(ParseFloatToString(element[OxO3f7d[38]].marginBottom)){inp_MarginBottom[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].marginBottom);} ;if(ParseFloatToString(element[OxO3f7d[38]].paddingLeft)){inp_PaddingLeft[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].paddingLeft);} ;if(ParseFloatToString(element[OxO3f7d[38]].paddingRight)){inp_PaddingRight[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].paddingRight);} ;if(ParseFloatToString(element[OxO3f7d[38]].paddingTop)){inp_PaddingTop[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].paddingTop);} ;if(ParseFloatToString(element[OxO3f7d[38]].paddingBottom)){inp_PaddingBottom[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]].paddingBottom);} ;inp_class[OxO3f7d[36]]=element[OxO3f7d[43]];var arr=[OxO3f7d[44],OxO3f7d[45]];for(var Ox1fc=0;Ox1fc<arr[OxO3f7d[1]];Ox1fc++){var Ox27=arr[Ox1fc];var Ox43=Window_GetElement(window,OxO3f7d[46]+Ox27,true);var Ox120=Window_GetElement(window,OxO3f7d[47]+Ox27+OxO3f7d[48],true);Ox120[OxO3f7d[49]]=0;if(ParseFloatToString(element[OxO3f7d[38]][Ox27])){Ox43[OxO3f7d[36]]=ParseFloatToString(element[OxO3f7d[38]][Ox27]);for(var i=0;i<Ox120[OxO3f7d[50]][OxO3f7d[1]];i++){var Ox142=Ox120[OxO3f7d[50]][i][OxO3f7d[36]];if(Ox142&&element[OxO3f7d[38]][Ox27].indexOf(Ox142)!=-1){Ox120[OxO3f7d[49]]=i;break ;} ;} ;} ;} ;sel_align[OxO3f7d[36]]=element[OxO3f7d[51]];if(Browser_IsWinIE()){sel_float[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[52]];} else {sel_float[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[53]];} ;sel_textalign[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[54]];inp_tooltip[OxO3f7d[36]]=element[OxO3f7d[55]];try{sel_border[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[56]];if(element[OxO3f7d[38]][OxO3f7d[57]]==element[OxO3f7d[38]][OxO3f7d[58]]&&element[OxO3f7d[38]][OxO3f7d[57]]==element[OxO3f7d[38]][OxO3f7d[59]]&&element[OxO3f7d[38]][OxO3f7d[57]]==element[OxO3f7d[38]][OxO3f7d[60]]){sel_border[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[57]];} ;if(element[OxO3f7d[38]][OxO3f7d[61]]==element[OxO3f7d[38]][OxO3f7d[62]]&&element[OxO3f7d[38]][OxO3f7d[61]]==element[OxO3f7d[38]][OxO3f7d[63]]&&element[OxO3f7d[38]][OxO3f7d[61]]==element[OxO3f7d[38]][OxO3f7d[64]]){sel_style[OxO3f7d[36]]=element[OxO3f7d[38]][OxO3f7d[61]];} ;} catch(x){} ;} ;SyncTo=function SyncTo_Div(element){var Ox4c6=sel_part[OxO3f7d[36]];if(Ox4c6==OxO3f7d[65]){element[OxO3f7d[38]][OxO3f7d[66]]=OxO3f7d[65];} else {var Ox4c7=Ox4c6?OxO3f7d[67]+Ox4c6:Ox4c6;var Oxdc=OxO3f7d[68];var Ox137=sel_style[OxO3f7d[36]]||OxO3f7d[2];var Ox4c8=sel_border[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[66]]=OxO3f7d[65];if(Ox4c8||Ox137){SetStyle(element.style,OxO3f7d[66]+Ox4c7,Ox4c8+OxO3f7d[39]+Ox137+OxO3f7d[39]+Oxdc);} else {SetStyle(element.style,OxO3f7d[66]+Ox4c7,OxO3f7d[2]);} ;SetStyle(element.style,OxO3f7d[66]+Ox4c7,Ox4c8+OxO3f7d[39]+Ox137+OxO3f7d[39]+Oxdc);} ;try{element[OxO3f7d[38]][OxO3f7d[41]]=inp_color[OxO3f7d[36]]||OxO3f7d[2];} catch(x){element[OxO3f7d[38]][OxO3f7d[41]]=OxO3f7d[2];} ;try{element[OxO3f7d[38]][OxO3f7d[40]]=inp_shade[OxO3f7d[36]]||OxO3f7d[2];} catch(x){element[OxO3f7d[38]][OxO3f7d[40]]=OxO3f7d[2];} ;try{element[OxO3f7d[38]][OxO3f7d[37]]=bordercolor[OxO3f7d[36]]||OxO3f7d[2];} catch(x){element[OxO3f7d[38]][OxO3f7d[37]]=OxO3f7d[2];} ;element[OxO3f7d[38]][OxO3f7d[69]]=inp_PaddingLeft[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[70]]=inp_PaddingRight[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[71]]=inp_PaddingTop[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[72]]=inp_PaddingBottom[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[73]]=inp_MarginLeft[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[74]]=inp_MarginRight[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[75]]=inp_MarginTop[OxO3f7d[36]];element[OxO3f7d[38]][OxO3f7d[76]]=inp_MarginBottom[OxO3f7d[36]];element[OxO3f7d[43]]=inp_class[OxO3f7d[36]];var arr=[OxO3f7d[44],OxO3f7d[45]];for(var Ox1fc=0;Ox1fc<arr[OxO3f7d[1]];Ox1fc++){var Ox27=arr[Ox1fc];var Ox43=Window_GetElement(window,OxO3f7d[46]+Ox27,true);var Ox4c9=Window_GetElement(window,OxO3f7d[47]+Ox27+OxO3f7d[48],true);if(ParseFloatToString(Ox43.value)){element[OxO3f7d[38]][Ox27]=ParseFloatToString(Ox43.value)+Ox4c9[OxO3f7d[36]];} else {element[OxO3f7d[38]][Ox27]=OxO3f7d[2];} ;} ;var Ox376=/[^a-z\d]/i;if(Ox376.test(inp_id.value)){alert(OxO3f7d[77]);return ;} ;element[OxO3f7d[51]]=sel_align[OxO3f7d[36]];element[OxO3f7d[42]]=inp_id[OxO3f7d[36]];if(Browser_IsWinIE()){element[OxO3f7d[38]][OxO3f7d[52]]=sel_float[OxO3f7d[36]];} else {element[OxO3f7d[38]][OxO3f7d[53]]=sel_float[OxO3f7d[36]];} ;element[OxO3f7d[38]][OxO3f7d[54]]=sel_textalign[OxO3f7d[36]];element[OxO3f7d[55]]=inp_tooltip[OxO3f7d[36]];if(element[OxO3f7d[55]]==OxO3f7d[2]){element.removeAttribute(OxO3f7d[55]);} ;if(element[OxO3f7d[43]]==OxO3f7d[2]){element.removeAttribute(OxO3f7d[43]);} ;if(element[OxO3f7d[43]]==OxO3f7d[2]){element.removeAttribute(OxO3f7d[78]);} ;if(element[OxO3f7d[51]]==OxO3f7d[2]){element.removeAttribute(OxO3f7d[51]);} ;if(element[OxO3f7d[42]]==OxO3f7d[2]){element.removeAttribute(OxO3f7d[42]);} ;} ;bordercolor[OxO3f7d[79]]=bordercolor_Preview[OxO3f7d[79]]=function bordercolor_onclick(){SelectColor(bordercolor,bordercolor_Preview);} ;inp_color[OxO3f7d[79]]=inp_color_Preview[OxO3f7d[79]]=function inp_color_onclick(){SelectColor(inp_color,inp_color_Preview);} ;inp_shade[OxO3f7d[79]]=inp_shade_Preview[OxO3f7d[79]]=function inp_shade_onclick(){SelectColor(inp_shade,inp_shade_Preview);} ;