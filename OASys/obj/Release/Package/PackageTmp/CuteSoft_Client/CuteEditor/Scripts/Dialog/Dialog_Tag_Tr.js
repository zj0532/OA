var OxO360f=["inp_width","inp_height","sel_align","sel_valign","inp_bgColor","inp_borderColor","inp_borderColorLight","inp_borderColorDark","inp_class","inp_id","inp_tooltip","value","bgColor","backgroundColor","style","id","borderColor","borderColorLight","borderColorDark","className","width","height","align","vAlign","title","[[ValidNumber]]","[[ValidID]]","","class","valign","cssText","border-image: none;","onclick"];var inp_width=Window_GetElement(window,OxO360f[0],true);var inp_height=Window_GetElement(window,OxO360f[1],true);var sel_align=Window_GetElement(window,OxO360f[2],true);var sel_valign=Window_GetElement(window,OxO360f[3],true);var inp_bgColor=Window_GetElement(window,OxO360f[4],true);var inp_borderColor=Window_GetElement(window,OxO360f[5],true);var inp_borderColorLight=Window_GetElement(window,OxO360f[6],true);var inp_borderColorDark=Window_GetElement(window,OxO360f[7],true);var inp_class=Window_GetElement(window,OxO360f[8],true);var inp_id=Window_GetElement(window,OxO360f[9],true);var inp_tooltip=Window_GetElement(window,OxO360f[10],true);SyncToView=function SyncToView_Tr(){inp_bgColor[OxO360f[11]]=element.getAttribute(OxO360f[12])||element[OxO360f[14]][OxO360f[13]];inp_id[OxO360f[11]]=element.getAttribute(OxO360f[15]);inp_bgColor[OxO360f[14]][OxO360f[13]]=inp_bgColor[OxO360f[11]];inp_borderColor[OxO360f[11]]=element.getAttribute(OxO360f[16]);inp_borderColor[OxO360f[14]][OxO360f[13]]=inp_borderColor[OxO360f[11]];inp_borderColorLight[OxO360f[11]]=element.getAttribute(OxO360f[17]);inp_borderColorLight[OxO360f[14]][OxO360f[13]]=inp_borderColorLight[OxO360f[11]];inp_borderColorDark[OxO360f[11]]=element.getAttribute(OxO360f[18]);inp_borderColorDark[OxO360f[14]][OxO360f[13]]=inp_borderColorDark[OxO360f[11]];inp_class[OxO360f[11]]=element[OxO360f[19]];inp_width[OxO360f[11]]=element.getAttribute(OxO360f[20])||element[OxO360f[14]][OxO360f[20]];inp_height[OxO360f[11]]=element.getAttribute(OxO360f[21])||element[OxO360f[14]][OxO360f[21]];sel_align[OxO360f[11]]=element.getAttribute(OxO360f[22]);sel_valign[OxO360f[11]]=element.getAttribute(OxO360f[23]);inp_tooltip[OxO360f[11]]=element.getAttribute(OxO360f[24]);} ;SyncTo=function SyncTo_Tr(element){if(inp_bgColor[OxO360f[11]]){if(element[OxO360f[14]][OxO360f[13]]){element[OxO360f[14]][OxO360f[13]]=inp_bgColor[OxO360f[11]];} else {element[OxO360f[12]]=inp_bgColor[OxO360f[11]];} ;} else {element.removeAttribute(OxO360f[12]);} ;element[OxO360f[16]]=inp_borderColor[OxO360f[11]];element[OxO360f[17]]=inp_borderColorLight[OxO360f[11]];element[OxO360f[18]]=inp_borderColorDark[OxO360f[11]];element[OxO360f[19]]=inp_class[OxO360f[11]];if(element[OxO360f[14]][OxO360f[20]]||element[OxO360f[14]][OxO360f[21]]){try{element[OxO360f[14]][OxO360f[20]]=inp_width[OxO360f[11]];element[OxO360f[14]][OxO360f[21]]=inp_height[OxO360f[11]];} catch(er){alert(OxO360f[25]);} ;} else {try{element[OxO360f[20]]=inp_width[OxO360f[11]];element[OxO360f[21]]=inp_height[OxO360f[11]];} catch(er){alert(OxO360f[25]);} ;} ;var Ox376=/[^a-z\d]/i;if(Ox376.test(inp_id.value)){alert(OxO360f[26]);return ;} ;element[OxO360f[22]]=sel_align[OxO360f[11]];element[OxO360f[15]]=inp_id[OxO360f[11]];element[OxO360f[23]]=sel_valign[OxO360f[11]];element[OxO360f[24]]=inp_tooltip[OxO360f[11]];if(element[OxO360f[15]]==OxO360f[27]){element.removeAttribute(OxO360f[15]);} ;if(element[OxO360f[12]]==OxO360f[27]){element.removeAttribute(OxO360f[12]);} ;if(element[OxO360f[16]]==OxO360f[27]){element.removeAttribute(OxO360f[16]);} ;if(element[OxO360f[17]]==OxO360f[27]){element.removeAttribute(OxO360f[17]);} ;if(element[OxO360f[18]]==OxO360f[27]){element.removeAttribute(OxO360f[18]);} ;if(element[OxO360f[19]]==OxO360f[27]){element.removeAttribute(OxO360f[19]);} ;if(element[OxO360f[19]]==OxO360f[27]){element.removeAttribute(OxO360f[28]);} ;if(element[OxO360f[22]]==OxO360f[27]){element.removeAttribute(OxO360f[22]);} ;if(element[OxO360f[23]]==OxO360f[27]){element.removeAttribute(OxO360f[29]);} ;if(element[OxO360f[24]]==OxO360f[27]){element.removeAttribute(OxO360f[24]);} ;if(element[OxO360f[20]]==OxO360f[27]){element.removeAttribute(OxO360f[20]);} ;if(element[OxO360f[21]]==OxO360f[27]){element.removeAttribute(OxO360f[21]);} ;if(element[OxO360f[14]][OxO360f[30]]==OxO360f[31]){element.removeAttribute(OxO360f[14]);} ;} ;inp_borderColor[OxO360f[32]]=function inp_borderColor_onclick(){SelectColor(inp_borderColor);} ;inp_bgColor[OxO360f[32]]=function inp_bgColor_onclick(){SelectColor(inp_bgColor);} ;inp_borderColorLight[OxO360f[32]]=function inp_borderColorLight_onclick(){SelectColor(inp_borderColorLight);} ;inp_borderColorDark[OxO360f[32]]=function inp_borderColorDark_onclick(){SelectColor(inp_borderColorDark);} ;