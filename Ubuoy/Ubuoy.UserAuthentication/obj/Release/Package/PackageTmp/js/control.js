function ShowUtils() {
	new Effect.Phase('authorinfo');
	$("showinfo").style.display = "none";
	$("hideinfo").style.display = "";
}

function HideUtils() {
	new Effect.Phase('authorinfo');
	$("showinfo").style.display = "";
	$("hideinfo").style.display = "none";
}


if(typeof sIFR == "function"){
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:"#content h2", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#709c78", sLinkColor:"#709c78", sBgColor:"#eeeeee", sHoverColor:"#d6dadd", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=left&offsetLeft=500px", sWmode: "transparent"}));
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:".post h3", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#9f4d35", sLinkColor:"#ea7d68", sBgColor:"#eeeeee", sHoverColor:"#d46647", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=center&offsetLeft=500px", sWmode: "transparent"}));
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:"#commtext h3", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#ea7d68", sLinkColor:"#ea7d68", sBgColor:"#eeeeee", sHoverColor:"#d46647", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=left&offsetLeft=500px", sWmode: "transparent"}));
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:"#commentform h3", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#ea7d68", sLinkColor:"#ea7d68", sBgColor:"#eeeeee", sHoverColor:"#d46647", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=left&offsetLeft=500px", sWmode: "transparent"}));
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:"#sites-index h3", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#709c78", sLinkColor:"#709c78", sBgColor:"#eeeeee", sHoverColor:"#d6dadd", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=center&offsetLeft=500px", sWmode: "transparent"}));
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:"#about h3", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#709c78", sLinkColor:"#709c78", sBgColor:"#eeeeee", sHoverColor:"#d6dadd", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=center&offsetLeft=500px", sWmode: "transparent"}));
sIFR.replaceElement(named({nWidth:0,nHeight:0,sSelector:"#submit h3", sFlashSrc:"http://www.thehorizontalway.com/wp-content/themes/thehorizontalway/schadow.swf", sColor:"#709c78", sLinkColor:"#709c78", sBgColor:"#eeeeee", sHoverColor:"#d6dadd", nPaddingTop:0, nPaddingBottom:0, sFlashVars:"textalign=center&offsetLeft=500px", sWmode: "transparent"}));
}

function changeBGC(color){
document.bgColor = color;
}