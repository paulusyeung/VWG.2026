<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
	


	<!-- Scrollbars Panel -->
	<xsl:template match="WC:Tags.ScrollablePanel" mode="modContent">
   <xsl:param name="prmIsEnabled" />
		
		<table border="1" class="Common-CellSpacing0 Common-CellPadding0 WGScrollbarsPanel-Table">
			<tr>
				<td style="width:23px" class="WGScrollbarsPanel-ButtonScroller" 
					onmousedown="this.intID=setInterval('VWG_Scrollable_{@Id}.firstChild.scrollLeft+=5;',10)"
					onmouseleave="clearInterval(this.intID)" 
					onmouseup="clearInterval(this.intID)"></td>
				<td><div id="VWG_Scrollable_{@Id}" class="WGScrollbarsPanel-Scroller"><xsl:call-template name="tplDrawContained"><xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" /></xsl:call-template></div></td>
				<td style="width:23px" class="WGScrollbarsPanel-ButtonScroller" 
					onmousedown="this.intID=setInterval('VWG_Scrollable_{@Id}.firstChild.scrollLeft-=5;',10)"
					onmouseleave="clearInterval(this.intID)" 
					onmouseup="clearInterval(this.intID)"></td>
			</tr>
		</table> 
	</xsl:template>
	
	
	
</xsl:stylesheet>

