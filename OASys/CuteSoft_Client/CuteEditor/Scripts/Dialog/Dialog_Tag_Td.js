var OxOeef9=["inp_width","inp_height","sel_align","sel_valign","inp_bgColor","inp_borderColor","inp_borderColorLight","inp_borderColorDark","inp_class","inp_id","inp_tooltip","sel_noWrap","sel_CellScope","value","bgColor","backgroundColor","style","id","borderColor","borderColorLight","borderColorDark","className","width","height","align","vAlign","title","noWrap","scope","[[ValidNumber]]","[[ValidID]]","","class","valign","cssText","border-image: none;","onclick"];var inp_width=Window_GetElement(window,OxOeef9[0],true);var inp_height=Window_GetElement(window,OxOeef9[1],true);var sel_align=Window_GetElement(window,OxOeef9[2],true);var sel_valign=Window_GetElement(window,OxOeef9[3],true);var inp_bgColor=Window_GetElement(window,OxOeef9[4],true);var inp_borderColor=Window_GetElement(window,OxOeef9[5],true);var inp_borderColorLight=Window_GetElement(window,OxOeef9[6],true);var inp_borderColorDark=Window_GetElement(window,OxOeef9[7],true);var inp_class=Window_GetElement(window,OxOeef9[8],true);var inp_id=Window_GetElement(window,OxOeef9[9],true);var inp_tooltip=Window_GetElement(window,OxOeef9[10],true);var sel_noWrap=Window_GetElement(window,OxOeef9[11],true);var sel_CellScope=Window_GetElement(window,OxOeef9[12],true);SyncToView=function SyncToView_Td(){inp_bgColor[OxOeef9[13]]=element.getAttribute(OxOeef9[14])||element[OxOeef9[16]][OxOeef9[15]];inp_id[OxOeef9[13]]=element.getAttribute(OxOeef9[17]);inp_bgColor[OxOeef9[16]][OxOeef9[15]]=inp_bgColor[OxOeef9[13]];inp_borderColor[OxOeef9[13]]=element.getAttribute(OxOeef9[18]);inp_borderColor[OxOeef9[16]][OxOeef9[15]]=inp_borderColor[OxOeef9[13]];inp_borderColorLight[OxOeef9[13]]=element.getAttribute(OxOeef9[19]);inp_borderColorLight[OxOeef9[16]][OxOeef9[15]]=inp_borderColorLight[OxOeef9[13]];inp_borderColorDark[OxOeef9[13]]=element.getAttribute(OxOeef9[20]);inp_borderColorDark[OxOeef9[16]][OxOeef9[15]]=inp_borderColorDark[OxOeef9[13]];inp_class[OxOeef9[13]]=element[OxOeef9[21]];inp_width[OxOeef9[13]]=element.getAttribute(OxOeef9[22])||element[OxOeef9[16]][OxOeef9[22]];inp_height[OxOeef9[13]]=element.getAttribute(OxOeef9[23])||element[OxOeef9[16]][OxOeef9[23]];sel_align[OxOeef9[13]]=element.getAttribute(OxOeef9[24]);sel_valign[OxOeef9[13]]=element.getAttribute(OxOeef9[25]);inp_tooltip[OxOeef9[13]]=element.getAttribute(OxOeef9[26]);sel_noWrap[OxOeef9[13]]=element.getAttribute(OxOeef9[27]);sel_CellScope[OxOeef9[13]]=element.getAttribute(OxOeef9[28]);} ;SyncTo=function SyncTo_Td(element){if(inp_bgColor[OxOeef9[13]]){if(element[OxOeef9[16]][OxOeef9[15]]){element[OxOeef9[16]][OxOeef9[15]]=inp_bgColor[OxOeef9[13]];} else {element[OxOeef9[14]]=inp_bgColor[OxOeef9[13]];} ;} else {element.removeAttribute(OxOeef9[14]);} ;element[OxOeef9[18]]=inp_borderColor[OxOeef9[13]];element[OxOeef9[19]]=inp_borderColorLight[OxOeef9[13]];element[OxOeef9[20]]=inp_borderColorDark[OxOeef9[13]];element[OxOeef9[21]]=inp_class[OxOeef9[13]];if(element[OxOeef9[16]][OxOeef9[22]]||element[OxOeef9[16]][OxOeef9[23]]){try{element[OxOeef9[16]][OxOeef9[22]]=inp_width[OxOeef9[13]];element[OxOeef9[16]][OxOeef9[23]]=inp_height[OxOeef9[13]];} catch(er){alert(OxOeef9[29]);} ;} else {try{element[OxOeef9[22]]=inp_width[OxOeef9[13]];element[OxOeef9[23]]=inp_height[OxOeef9[13]];} catch(er){alert(OxOeef9[29]);} ;} ;var Ox376=/[^a-z\d]/i;if(Ox376.test(inp_id.value)){alert(OxOeef9[30]);return ;} ;element[OxOeef9[24]]=sel_align[OxOeef9[13]];element[OxOeef9[17]]=inp_id[OxOeef9[13]];element[OxOeef9[25]]=sel_valign[OxOeef9[13]];element[OxOeef9[27]]=sel_noWrap[OxOeef9[13]];element[OxOeef9[26]]=inp_tooltip[OxOeef9[13]];element[OxOeef9[28]]=sel_CellScope[OxOeef9[13]];if(element[OxOeef9[17]]==OxOeef9[31]){element.removeAttribute(OxOeef9[17]);} ;if(element[OxOeef9[28]]==OxOeef9[31]){element.removeAttribute(OxOeef9[28]);} ;if(element[OxOeef9[27]]==OxOeef9[31]){element.removeAttribute(OxOeef9[27]);} ;if(element[OxOeef9[14]]==OxOeef9[31]){element.removeAttribute(OxOeef9[14]);} ;if(element[OxOeef9[18]]==OxOeef9[31]){element.removeAttribute(OxOeef9[18]);} ;if(element[OxOeef9[19]]==OxOeef9[31]){element.removeAttribute(OxOeef9[19]);} ;if(element[OxOeef9[20]]==OxOeef9[31]){element.removeAttribute(OxOeef9[20]);} ;if(element[OxOeef9[21]]==OxOeef9[31]){element.removeAttribute(OxOeef9[21]);} ;if(element[OxOeef9[21]]==OxOeef9[31]){element.removeAttribute(OxOeef9[32]);} ;if(element[OxOeef9[24]]==OxOeef9[31]){element.removeAttribute(OxOeef9[24]);} ;if(element[OxOeef9[25]]==OxOeef9[31]){element.removeAttribute(OxOeef9[33]);} ;if(element[OxOeef9[26]]==OxOeef9[31]){element.removeAttribute(OxOeef9[26]);} ;if(element[OxOeef9[22]]==OxOeef9[31]){element.removeAttribute(OxOeef9[22]);} ;if(element[OxOeef9[23]]==OxOeef9[31]){element.removeAttribute(OxOeef9[23]);} ;if(element[OxOeef9[16]][OxOeef9[34]]==OxOeef9[35]){element.removeAttribute(OxOeef9[16]);} ;} ;inp_borderColor[OxOeef9[36]]=function inp_borderColor_onclick(){SelectColor(inp_borderColor);} ;inp_bgColor[OxOeef9[36]]=function inp_bgColor_onclick(){SelectColor(inp_bgColor);} ;inp_borderColorLight[OxOeef9[36]]=function inp_borderColorLight_onclick(){SelectColor(inp_borderColorLight);} ;inp_borderColorDark[OxOeef9[36]]=function inp_borderColorDark_onclick(){SelectColor(inp_borderColorDark);} ;