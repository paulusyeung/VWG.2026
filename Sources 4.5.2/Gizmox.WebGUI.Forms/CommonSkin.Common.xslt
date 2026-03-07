<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:WG="http://www.gizmox.com/webgui"
	xmlns:Common="http://www.gizmox.com/webgui/common">
	<migration-ignore reason="needs to be implemented better in the migration engine">
  	<!-- set global variables -->
	<xsl:variable name="dir">Context.Direction</xsl:variable>
	<xsl:variable name="varBrowserCapabilities_CSS3">Context.CSS3BrowserCapabilities</xsl:variable>
	<xsl:variable name="varBrowserCapabilities_HTML5">Context.HTML5BrowserCapabilities</xsl:variable>
	<xsl:variable name="varBrowserCapabilities_MISC">Context.MISCBrowserCapabilities</xsl:variable>    
	<xsl:variable name="varAccessibilityMode">Context.AccessibilityMode</xsl:variable>
	<xsl:variable name="rtl"><xsl:if test="$dir='RTL'">LTR</xsl:if><xsl:if test="not($dir='RTL')">RTL</xsl:if></xsl:variable>
	<xsl:variable name="ltr"><xsl:if test="$dir='RTL'">RTL</xsl:if><xsl:if test="not($dir='RTL')">LTR</xsl:if></xsl:variable>
	<xsl:variable name="left"><xsl:if test="$dir='RTL'">right</xsl:if><xsl:if test="not($dir='RTL')">left</xsl:if></xsl:variable>
	<xsl:variable name="right"><xsl:if test="$dir='RTL'">left</xsl:if><xsl:if test="not($dir='RTL')">right</xsl:if></xsl:variable>
	<xsl:variable name="pdir">Context.PositioningDirection</xsl:variable>
	<xsl:variable name="pleft"><xsl:if test="$pdir='RTL'">right</xsl:if><xsl:if test="not($pdir='RTL')">left</xsl:if></xsl:variable>
	<xsl:variable name="pright"><xsl:if test="$pdir='RTL'">left</xsl:if><xsl:if test="not($pdir='RTL')">right</xsl:if></xsl:variable>
  <xsl:variable name="varBrowserObsoleteIE">Context.BrowserObsoleteIE</xsl:variable>
  <xsl:variable name="varBrowserIE">Context.BrowserIE</xsl:variable>
  <xsl:variable name="varFullScreenMode">Context.FullScreenMode</xsl:variable>
  <xsl:variable name="varSupportsMultipleThemes">Context.SupportsMultipleThemes</xsl:variable>
    
  </migration-ignore>
	
	<migration-write>
		<![CDATA[
$.jqtregtemplatevar("varBrowserCapabilities_CSS3", "Context.CSS3BrowserCapabilities");		
$.jqtregtemplatevar("varBrowserCapabilities_HTML5", "Context.HTML5BrowserCapabilities");		
$.jqtregtemplatevar("varBrowserCapabilities_MISC", "Context.MISCBrowserCapabilities");		
$.jqtregtemplatevar("varAccessibilityMode", "Context.AccessibilityMode");		
$.jqtregtemplatevar("dir", "Context.Direction");
$.jqtregtemplatevar("rtl", "Context.Direction" == "RTL" ? "LTR" : "RTL");
$.jqtregtemplatevar("ltr", "Context.Direction" == "RTL" ? "RTL" : "LTR");
$.jqtregtemplatevar("left", "Context.Direction" == "RTL" ? "right" : "left");
$.jqtregtemplatevar("right", "Context.Direction" == "RTL" ? "left" : "right");
$.jqtregtemplatevar("pdir", "Context.PositioningDirection");
$.jqtregtemplatevar("pleft", "Context.PositioningDirection" == "RTL" ? "right" : "left");
$.jqtregtemplatevar("pright", "Context.PositioningDirection" == "RTL" ? "left" : "right");
$.jqtregtemplatevar("varBrowserObsoleteIE", "Context.BrowserObsoleteIE");
$.jqtregtemplatevar("varFullScreenMode", "Context.FullScreenMode");
$.jqtregtemplatevar("varSupportsMultipleThemes", "Context.SupportsMultipleThemes");
		]]>
	</migration-write>


  <xsl:template name="tplSetTextAreaValue">
    <xsl:param name="prmText" select="@Attr.Value"/>
    <xsl:if test="starts-with(@Attr.Value,'&#x0a;')">&#x0a;</xsl:if>
    <xsl:call-template name="tplDecodeText">
      <xsl:with-param name="prmText" select="$prmText"/>
    </xsl:call-template>
  </xsl:template>
  
  <migration-ignore>

  <xsl:template name="tplConvertDecimalToBinaryString">
    <xsl:param name="prmDecimal"/>
    
    <xsl:if test="$prmDecimal &gt; 0">
      <xsl:call-template name="tplConvertDecimalToBinaryString">
        <xsl:with-param name="prmDecimal" select="floor($prmDecimal div 2)"/>
      </xsl:call-template>
      <xsl:value-of select="$prmDecimal mod 2"/>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplCompareBinaryStrings">
    <xsl:param name="prmBinary1"/>
    <xsl:param name="prmBinary2"/>

    <xsl:variable name="varBinary1Length" select="string-length($prmBinary1)"/>
    <xsl:variable name="varBinary2Length" select="string-length($prmBinary2)"/>
    
    <xsl:choose>
      <xsl:when test="$varBinary1Length = 0 or $varBinary2Length = 0">false</xsl:when>
      <xsl:when test="substring($prmBinary1, $varBinary1Length - 1, 1) = 1 and substring($prmBinary2, $varBinary2Length - 1, 1) = 1">true</xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplCompareBinaryStrings">
          <xsl:with-param name="prmBinary1" select="substring($prmBinary1, 1, $varBinary1Length - 1)"/>
          <xsl:with-param name="prmBinary2" select="substring($prmBinary2, 1, $varBinary2Length - 1)"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  </migration-ignore>

  <xsl:template name="tplCompareBitwiseAnd">
    <xsl:param name="prmDecimal1"/>
    <xsl:param name="prmDecimal2"/>

    <xsl:choose>
      <xsl:when test="number($prmDecimal1) &gt;= 0 and  number($prmDecimal2) &gt;= 0">
        <migration-ignore>
          <xsl:call-template name="tplCompareBinaryStrings">
            <xsl:with-param name="prmBinary1">
              <xsl:call-template name="tplConvertDecimalToBinaryString">
                <xsl:with-param name="prmDecimal" select="$prmDecimal1"/>
              </xsl:call-template>
            </xsl:with-param>
            <xsl:with-param name="prmBinary2">
              <xsl:call-template name="tplConvertDecimalToBinaryString">
                <xsl:with-param name="prmDecimal" select="$prmDecimal2"/>
              </xsl:call-template>
            </xsl:with-param>
          </xsl:call-template>
        </migration-ignore>
        <migration-write><![CDATA[objWriter.write((Number(prmDecimal1) & Number(prmDecimal2))>0?"true":"false");]]></migration-write>
      </xsl:when>
      <xsl:otherwise>false</xsl:otherwise>
    </xsl:choose>
</xsl:template>

  <xsl:template name="tplSupportsCSS3BrowserCapability">
    <xsl:param name="prmCSS3BrowserCapability"/>
    <xsl:call-template name="tplCompareBitwiseAnd">
      <xsl:with-param name="prmDecimal1" select="$varBrowserCapabilities_CSS3"/>
      <xsl:with-param name="prmDecimal2" select="$prmCSS3BrowserCapability"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplSupportsHTML5BrowserCapability">
    <xsl:param name="prmHTML5BrowserCapability"/>
    <xsl:call-template name="tplCompareBitwiseAnd">
      <xsl:with-param name="prmDecimal1" select="$varBrowserCapabilities_HTML5"/>
      <xsl:with-param name="prmDecimal2" select="$prmHTML5BrowserCapability"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplSupportsMISCBrowserCapability">
    <xsl:param name="prmMISCBrowserCapability"/>
    <xsl:call-template name="tplCompareBitwiseAnd">
      <xsl:with-param name="prmDecimal1" select="$varBrowserCapabilities_MISC"/>
      <xsl:with-param name="prmDecimal2" select="$prmMISCBrowserCapability"/>
    </xsl:call-template>
  </xsl:template>
  
    <xsl:template name="tplCellTextAlign">
      <xsl:call-template name="tplCellAlign">
        <xsl:with-param name="prmAlign" select="@Attr.TextAlign" />
      </xsl:call-template>
	</xsl:template>
  
  <xsl:template name="tplCellImageAlign">
    <xsl:call-template name="tplCellAlign">
      <xsl:with-param name="prmAlign" select="@Attr.ImageAlign" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplCellAlign">
    <xsl:param name="prmAlign" />
      text-align:<xsl:if test="contains($prmAlign,'Left')"><xsl:value-of select="$left"/></xsl:if> <xsl:if test="contains($prmAlign,'Right')"><xsl:value-of select="$right"/></xsl:if><xsl:if test="contains($prmAlign,'Center')">center</xsl:if>;
      vertical-align:<xsl:if test="contains($prmAlign,'Top')">top</xsl:if><xsl:if test="contains($prmAlign,'Bottom')">bottom</xsl:if><xsl:if test="contains($prmAlign,'Middle')">middle</xsl:if>
	</xsl:template>

    <xsl:template name="tplCallMethod">
    <xsl:param name="prmMethod"/>
    <img src="[Skin.Path]Empty.gif.wgx" style="position:absolute;width:1px;height:1px;top:0px;left:0px;" onload="{$prmMethod}; if(this.parentNode) this.parentNode.removeChild(this);" alt=""/>
  </xsl:template>

  <xsl:template name="tplApplyScrollableAttributes">
    <xsl:param name="prmGuid" select="@Id"/>
    <xsl:param name="prmCustomScrollingHandler"/>

    <xsl:variable name="varScrollingHandler">mobjApp.Controls_StoreScroll(window,'<xsl:value-of select="$prmGuid"/>',this);</xsl:variable>
    
    <xsl:variable name="varScrollbarSupport">
      <xsl:call-template name="tplSupportsMISCBrowserCapability">
        <xsl:with-param name="prmMISCBrowserCapability" select="512"/>
      </xsl:call-template>
    </xsl:variable>

    <xsl:if test="$varScrollbarSupport='true'">
      <xsl:attribute name="data-vwgscrollable">1</xsl:attribute>
      <xsl:attribute name="data-scrollable">yes</xsl:attribute>
      <xsl:attribute name="onscroll"><xsl:value-of select="concat($varScrollingHandler,$prmCustomScrollingHandler)"/>;</xsl:attribute>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplCompleteScrollCapabilities">
    <xsl:param name="prmBounce" select="'true'"/>
    <xsl:param name="prmScrollbars" select="'3'"/>
    <xsl:param name="prmScrollMoveHandler" select="'null'"/>
    <xsl:param name="prmScrollEndHandler" select="'null'"/>

    <xsl:variable name="varScrollbarSupport">
      <xsl:call-template name="tplSupportsMISCBrowserCapability">
        <xsl:with-param name="prmMISCBrowserCapability" select="512"/>
      </xsl:call-template>
    </xsl:variable>

    <xsl:if test="$varScrollbarSupport='false'">
      <xsl:variable name="varScrollbars">
        <xsl:choose>
          <xsl:when test="$prmScrollbars and number($prmScrollbars) = $prmScrollbars">
            <xsl:value-of select="$prmScrollbars"/>
          </xsl:when>
          <xsl:when test="$prmScrollbars and number($prmScrollbars) != $prmScrollbars">
            <xsl:choose>
              <xsl:when test="$prmScrollbars = 'V'">2</xsl:when>
              <xsl:when test="$prmScrollbars = 'H'">1</xsl:when>
              <xsl:otherwise>3</xsl:otherwise>
            </xsl:choose>
          </xsl:when>
          <xsl:otherwise>3</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod" select="concat('mobjApp.Common_CompleteScrollCapabilities(this.nextSibling,',$prmBounce,',',$varScrollbars,',',$prmScrollMoveHandler,',',$prmScrollEndHandler,');')"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
  <xsl:template name="tplRestoreScroll">
    <xsl:param name="prmGuid" select="@Attr.Id"/>
    <xsl:param name="prmBeforeRestoreHandler" select="'null'"/>
    <xsl:param name="prmAfterRestoreHandler" select="'null'"/>

    <xsl:variable name="varScrollbarSupport">
      <xsl:call-template name="tplSupportsMISCBrowserCapability">
        <xsl:with-param name="prmMISCBrowserCapability" select="512"/>
      </xsl:call-template>
    </xsl:variable>

    <xsl:if test="$varScrollbarSupport='true'">
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod" select="concat('mobjApp.Controls_RestoreScroll(window,',$prmGuid,',',$prmBeforeRestoreHandler,',',$prmAfterRestoreHandler,',this.parentNode);')"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyDragAndDrop">
    <xsl:if test="@Attr.AllowDrag">
      <xsl:attribute name="data-vwgAllowDrag">
        <xsl:value-of select="@Attr.AllowDrag"/>
      </xsl:attribute>
    </xsl:if>
    
    <xsl:if test="@Attr.ExcludedDragTargets">
      <xsl:attribute name="vwgExcludedDragTargets">
        <xsl:value-of select="@Attr.ExcludedDragTargets"/>
      </xsl:attribute>
    </xsl:if>
    
    <xsl:if test="@Attr.DragTargetsComponent">
      <xsl:attribute name="data-vwgDragTargetsComponent">
        <xsl:value-of select="@Attr.DragTargetsComponent"/>
      </xsl:attribute>
    </xsl:if>
    
    <xsl:if test="@Attr.DragTargets">
      <xsl:attribute name="data-vwgdragtargets">
        <xsl:value-of select="@Attr.DragTargets"/>
      </xsl:attribute>
      <xsl:if test="@Attr.AllowDragTargetsToPropegateChild">
        <xsl:attribute name="data-vwgallowdragtargetspropegate">
          <xsl:value-of select="@Attr.AllowDragTargetsToPropegateChild"/>            
        </xsl:attribute>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawBackground">
    <xsl:param name="prmImage" />
    <xsl:param name="prmImageAlign" />
      background-image:url('<xsl:value-of select="$prmImage"/>');
      background-repeat:no-repeat;
      background-position:<xsl:if test="contains($prmImageAlign,'Top')">top </xsl:if>
      <xsl:if test="contains($prmImageAlign,'Bottom')">bottom </xsl:if>
      <xsl:if test="contains($prmImageAlign,'Middle')">center </xsl:if>
      <xsl:if test="contains($prmImageAlign,'Left')"><xsl:value-of select="$pleft"/></xsl:if>
      <xsl:if test="contains($prmImageAlign,'Right')"><xsl:value-of select="$pright"/></xsl:if>
      <xsl:if test="contains($prmImageAlign,'Center')">center</xsl:if>;
  </xsl:template>

 


 <!--
    /// <template name="tplDecodeTextAsHtml">
    /// <summary>
    /// Decode an encoded text an returns html.
    /// </summary>
    /// <param name="prmText">The text to decode.</param>
    /// <remarks>
    /// The template decodes a text value that was encoded to prevent data loss when using
    /// attributes. This allows to use attributes for text values without loosing information
    /// due to xml attribute normalization.
    /// </remarks>
    /// </template>
  -->
  <xsl:template name="tplDecodeTextAsHtml">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:call-template name="tplDecodeText">
      <xsl:with-param name="prmText" select="$prmText" />
      <xsl:with-param name="prmToHtml" select="1" />
    </xsl:call-template>
  </xsl:template>

    <!--
    /// <template name="tplDecodeText">
    /// <summary>
    /// Decode an encoded text.
    /// </summary>
    /// <param name="prmText">The text to decode.</param>
    /// <remarks>
    /// The template decodes a text value that was encoded to prevent data loss when using
    /// attributes. This allows to use attributes for text values without loosing information
    /// due to xml attribute normalization.
    /// </remarks>
    /// </template>
  -->
  <xsl:template name="tplDecodeText">
    <xsl:param name="prmText"  select="@Attr.Text"/>
    <xsl:param name="prmToHtml" select="0" />
	<migration-ignore>
    <xsl:param name="prmIsControl" select="0" />
	</migration-ignore>

	  <migration-write>
<![CDATA[
if(prmToHtml == "1")
{
	objWriter.write($.xpath("decodeTextAsHtml",prmText));
}
else
{
	objWriter.write($.xpath("decodeText",prmText));
}
]]>
	  </migration-write>

	  <migration-ignore>
    <xsl:if test="$prmIsControl=1">
      <xsl:if test="$prmToHtml=1">
        <xsl:choose>
          <xsl:when test="starts-with($prmText, 'n')"><br/></xsl:when>
          <xsl:when test="starts-with($prmText, 'b')">&#160;</xsl:when>
          <xsl:when test="starts-with($prmText, 't')">&#160;&#160;&#160;&#160;</xsl:when>
          <xsl:when test="starts-with($prmText, '\')">\</xsl:when>
        </xsl:choose>
      </xsl:if>
      <xsl:if test="$prmToHtml=0">
        <xsl:choose>
          <xsl:when test="starts-with($prmText, 'n')"><xsl:text>&#13;</xsl:text></xsl:when>
          <xsl:when test="starts-with($prmText, 'b')"><xsl:text>&#32;</xsl:text></xsl:when>
          <xsl:when test="starts-with($prmText, 't')">&#9;</xsl:when>
          <xsl:when test="starts-with($prmText, '\')">\</xsl:when>
        </xsl:choose>
      </xsl:if>
      <xsl:call-template name="tplDecodeText">
        <xsl:with-param name="prmText" select="substring($prmText,2)" />
        <xsl:with-param name="prmIsLoop" select="0" />
        <xsl:with-param name="prmToHtml" select="$prmToHtml" />
      </xsl:call-template>
    </xsl:if>

    <xsl:if test="$prmIsControl=0">
      <xsl:choose>
        <xsl:when test="contains($prmText, '\')">
          <xsl:value-of select="substring-before($prmText, '\')"/>
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="substring-after($prmText,'\')" />
            <xsl:with-param name="prmIsControl" select="1" />
            <xsl:with-param name="prmToHtml" select="$prmToHtml" />
          </xsl:call-template>
        </xsl:when>
        <xsl:otherwise><xsl:value-of select="$prmText"/></xsl:otherwise>
      </xsl:choose>
    </xsl:if>
	  </migration-ignore>
  </xsl:template>
  
  <!--
    /// <template name="tplSetHighlight">
    /// <summary>
    /// Sets rollover and mouse down effects by toggling CSS class.
    /// </summary>
    /// <remarks>
    /// The template uses the html class attribute and extracts the last 
    /// class defined.The extracted class is used to toggle classes by adding the 
    /// status suffix ([class name]_Enter, [class name]_Down, [class name]_Up).
    /// </remarks>
    /// </template>
  -->
  <xsl:template name="tplSetHighlight">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmHandler" select="'Web_SetStyle'"/>

    <xsl:if test="not($prmIsEnabled='0')">
      <xsl:call-template name="tplSetMouseEvents">
        <xsl:with-param name="prmHandler" select="$prmHandler"/>
      </xsl:call-template>
      <xsl:call-template name="tplSetTouchEvents">
        <xsl:with-param name="prmHandler" select="$prmHandler"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplSetTouchEvents">
    <xsl:param name="prmHandler"/>
    <xsl:attribute name="ontouchstart"><xsl:value-of select="$prmHandler" />(this,'mousedown',window,event);</xsl:attribute>
    <xsl:attribute name="ontouchend"><xsl:value-of select="$prmHandler" />(this,'mouseleave',window,event);</xsl:attribute>
  </xsl:template>

  <!--
    /// <template name="tplSetFocusable">
    /// <summary>
    /// Sets a component focusable by attaching the focus/blur events and adding tabindex capabilities.
    /// </summary>
    /// <remarks>
    /// The template uses the html class attribute and extracts the last 
    /// class defined.The extracted class is used to toggle classes by adding the 
    /// status suffix ([class name]_Focus).
    /// </remarks>
    /// </template>
  -->
  <xsl:template name="tplSetFocusable">
    <xsl:param name="prmHandler" select="'Web_SetStyle'"/>
    <xsl:param name="prmIsEnabled" />
    
    <xsl:if test="not($prmIsEnabled='0')">
      <xsl:attribute name="tabindex">-1</xsl:attribute>
      <xsl:attribute name="data-vwgfocuselement">1</xsl:attribute>
      
      <!--Check if handler is not empty-->
      <xsl:if test="$prmHandler and not($prmHandler='')">
        <xsl:call-template name="tplSetMouseFocusEvents">
          <xsl:with-param name="prmHandler" select="$prmHandler"/>
        </xsl:call-template>
      </xsl:if>
    </xsl:if>
  </xsl:template>
  
  <!--
    /// <template name="tplApplyEventCaptures">
    /// <summary>
    /// Sets the required event captures to prevent bubbling of captured events.
    /// </summary>
    /// <remarks>
    /// The template uses the Attr.Captures attribute
    /// </remarks>
    /// </template>
  -->
  <xsl:template name="tplApplyEventCaptures">
    <xsl:variable name="varCaptures" select="number(@Attr.Captures)" />
    
    <!-- If there are captures -->
    <xsl:if test="$varCaptures > 0">
      
      <!-- If there are key captures -->
      <xsl:if test="($varCaptures mod 2) = 1">
        <xsl:attribute name="onkeydown">mobjApp.Web_HandleKeyCaptures(event, <xsl:value-of select="$varCaptures"/>, window);</xsl:attribute>
      </xsl:if>
      
      <!-- If there are mouse captures -->
      <xsl:if test="(floor($varCaptures div 2) mod 2) = 1">
        <xsl:attribute name="onmousedown">mobjApp.Web_HandleMouseCaptures(event, <xsl:value-of select="$varCaptures"/>, window);</xsl:attribute>    
      </xsl:if>
      
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplWriteFormBody">
    <xsl:param name="prmClassName"  />
    <xsl:param name="prmSetControlAttributes" select="1"/>
      <xsl:param name="prmStyle" select="'width:100%;height:100%;position:relative;'" /> 
    <xsl:param name="prmIsEnabled" />
    <div>
      <xsl:attribute name="tabIndex">
        <xsl:value-of select="-1"/>
      </xsl:attribute>
      <xsl:if test="$varFullScreenMode='1'"><xsl:attribute name="data-vwgguid"><xsl:value-of select="@Attr.Id"/></xsl:attribute></xsl:if>
      <xsl:attribute name="style"><xsl:value-of select="$prmStyle"/><xsl:call-template name="tplApplyMinMaxSizeStyle"/><xsl:call-template name="tplApplyStyles"/></xsl:attribute>      
      <xsl:call-template name="tplApplyMinMaxSizeAttributes"/>
      <xsl:call-template name="tplApplyMinMaxResizeHandler"/>
      <xsl:if test="$prmSetControlAttributes=1">
        <xsl:call-template name="tplSetControl" >
          <xsl:with-param name="prmClassName" select="$prmClassName" />
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        </xsl:call-template>
      </xsl:if>
        <xsl:call-template name="tplDrawContained">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        </xsl:call-template>
        <xsl:if test="$varFullScreenMode='1'">
            <xsl:call-template name="tplApplyAfterEntranceVisualEffects" />
        </xsl:if>
      <!--apply selection on forms-->
      <xsl:call-template name="tplApplyUICapabilities">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <!--
    /// <template name="tplSetToolTip">
    /// <summary>
    /// Adds title attribute to the html element if the control is enabled.
    /// </summary>
    /// <remarks>
    /// Title attribute value is taken from the Attr.ToolTip attribute.
    /// </remarks>
    /// </template>
  -->
  <xsl:template name="tplSetToolTip">
    <xsl:param name="prmToolTip"/>
    <xsl:param name="prmTarget" select="."/>    
    <xsl:param name="prmIsEnabled" />
    
    <xsl:if test="$prmIsEnabled='1' or not($prmIsEnabled)">
      <xsl:variable name="varToolTip">
        <xsl:choose>
          <xsl:when test="$prmToolTip"><xsl:value-of select="$prmToolTip"/></xsl:when>
          <xsl:when test="$prmTarget/@Attr.ToolTip"><xsl:value-of select="$prmTarget/@Attr.ToolTip"/></xsl:when>
        </xsl:choose>
      </xsl:variable>
      
      <xsl:if test="$varToolTip">
        <xsl:attribute name="title">
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="$varToolTip"/>
          </xsl:call-template>
        </xsl:attribute>
      </xsl:if>
    </xsl:if>
  </xsl:template>
  
  <xsl:template name="tplApplyMaskCapabilities">
    <xsl:param name="prmId" select="@Attr.Id" />
    <xsl:param name="prmValue" />
      <xsl:param name="prmOnPasteHandler" select="'mobjApp.Common_MaskOnPaste(this);'"/>
      <xsl:param name="prmOnKeyDownHandler" select="'return mobjApp.Common_MaskKeyDown(this,event);'"/>
      <xsl:param name="prmOnBlurHandler" select="concat('mobjApp.Common_MaskBlur(&quot;',$prmId,'&quot;,this,event,window);')"/>
      <xsl:param name="prmOnFocusHandler" select="concat('mobjApp.Common_MaskFocus(this,event,&quot;',$prmId,'&quot;);')"/>
      <xsl:param name="prmOnDragEnterHandler" select="'return false;'"/>
      <xsl:param name="prmOnKeyUpHandler" select="''"/>
      <xsl:param name="prmOnKeyPressHandler" select="''"/>
      
    <xsl:attribute name="onpaste"><xsl:value-of select="$prmOnPasteHandler"/></xsl:attribute>
    <xsl:attribute name="onkeydown"><xsl:value-of select="$prmOnKeyDownHandler"/></xsl:attribute>
    <xsl:call-template name="tplResgisterLostFocusEvent"><xsl:with-param name="prmHandler"><xsl:value-of select="$prmOnBlurHandler"/></xsl:with-param></xsl:call-template>
    <xsl:attribute name="onfocus"><xsl:value-of select="$prmOnFocusHandler"/></xsl:attribute>
    <xsl:attribute name="onkeyup"><xsl:value-of select="$prmOnKeyUpHandler"/></xsl:attribute>
    <xsl:attribute name="onkeypress"><xsl:value-of select="$prmOnKeyPressHandler"/></xsl:attribute>
    <xsl:attribute name="data-PromptChar"><xsl:value-of select="@Attr.PromptChar"/></xsl:attribute>
    <xsl:attribute name="data-Mask"><xsl:value-of select="@Attr.Mask"/></xsl:attribute>
    <xsl:attribute name="ondragenter"><xsl:value-of select="$prmOnDragEnterHandler"/></xsl:attribute>
    <xsl:attribute name="value"><xsl:call-template name="tplDecodeText"><xsl:with-param name="prmText" select="$prmValue"/></xsl:call-template></xsl:attribute>
  </xsl:template>
  
  <xsl:template name="tplGetRightToLeftValue">
    <xsl:param name="prmRightToLeft" select="@Attr.RightToLeft"/>
    <xsl:param name="prmNoValue" />
    <xsl:param name="prmYesValue" />
    <xsl:param name="prmDefaultValue" />

    <xsl:choose>
      <xsl:when test="$prmRightToLeft='1'">
        <xsl:value-of select="$prmYesValue"/>
      </xsl:when>
      <xsl:when test="$prmRightToLeft='0'">
        <xsl:value-of select="$prmNoValue"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$prmDefaultValue"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--
    /// <template name="tplSetDisabled">
    /// <summary>
    /// Sets the disabled attribute to disabled components
    /// </summary>
    /// </template>
  -->
  <xsl:template name="tplSetDisabled">
    <xsl:param name="prmIsEnabled" />
        
    <xsl:if test="$prmIsEnabled='0'">
      <xsl:attribute name="disabled">disabled</xsl:attribute>
    </xsl:if>
  </xsl:template>
  
  <!--
    /// <template name="tplSetMouseFocusEvents">
    /// <summary>
    /// Sets focus / blur handlers
    /// </summary>
    /// </template>
  -->
  <xsl:template name="tplSetMouseFocusEvents">
    <xsl:param name="prmHandler"/>

    <xsl:choose>
      <xsl:when test="$varBrowserIE='1'">
        <xsl:attribute name="onfocusin"><xsl:value-of select="$prmHandler" />(this,'focus',window)</xsl:attribute>
        <xsl:attribute name="onfocusout"><xsl:value-of select="$prmHandler" />(this,'blur',window)</xsl:attribute>        
      </xsl:when>
      <xsl:otherwise>
        <xsl:attribute name="onfocus"><xsl:value-of select="$prmHandler" />(this,'focus',window)</xsl:attribute>
        <xsl:attribute name="onblur"><xsl:value-of select="$prmHandler" />(this,'blur',window)</xsl:attribute>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

	<xsl:template name="tplSetMouseEvents">
		<xsl:param name="prmHandler"/>
    
    <xsl:attribute name="onmousedown"><xsl:value-of select="$prmHandler" />(this,'mousedown',window,event)</xsl:attribute>
		<xsl:attribute name="onmouseup"><xsl:value-of select="$prmHandler" />(this,'mouseup',window,event)</xsl:attribute>
    
    <xsl:choose>
      <xsl:when test="$varBrowserIE='1'">
        <xsl:attribute name="onmouseenter"><xsl:value-of select="$prmHandler" />(this,'mouseenter',window,event)</xsl:attribute>
		    <xsl:attribute name="onmouseleave"><xsl:value-of select="$prmHandler" />(this,'mouseleave',window,event)</xsl:attribute>      
      </xsl:when>
      <xsl:otherwise>
        <xsl:attribute name="onmouseover">mobjApp.Common_OnMouseOver('<xsl:value-of select="$prmHandler" />',this,window,event)</xsl:attribute>
		    <xsl:attribute name="onmouseout">mobjApp.Common_OnMouseOut('<xsl:value-of select="$prmHandler" />',this,window,event)</xsl:attribute>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
	<xsl:template match="*" mode="modContent">&#160;</xsl:template>

	<xsl:template match="WC:Include">
		<xsl:apply-templates select="document(@File)/child::*"/>
	</xsl:template>
  
	<xsl:template name="tplSetControl">
    <xsl:param name="prmClassName"  />
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:variable name="varExtendedToolTip" select="@Attr.ExtendedToolTip"/>
    <xsl:variable name="varTemplateName" select="@Attr.ExtendedToolTipTemplateName"/>

	<xsl:attribute name="id">VWG_<xsl:value-of select="@Attr.Id" /></xsl:attribute>	
    <xsl:call-template name="tplSetClientUniqueId" />
    
    <!-- setting the classes needed for transition -->
    <xsl:if test="($prmClassName and not($prmClassName=''))">
      <xsl:attribute name="class">
        <xsl:value-of select="$prmClassName"/>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$prmClassName,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
    </xsl:if>
    
    <xsl:if test="@Attr.Swipable='1'"><xsl:attribute name="data-swipable">yes</xsl:attribute></xsl:if>
      <xsl:if test="not($varExtendedToolTip) or not($varTemplateName)">
        <xsl:call-template name="tplSetToolTip" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:if>    
    <xsl:call-template name="tplApplyDragAndDrop" />
    <xsl:call-template name="tplApplyEventCaptures" />
    <xsl:apply-templates mode="modTraceableEvents" select="." />    
	</xsl:template>

  <xsl:template match="*" mode="modTraceableEvents">
    <!-- do nothing -->
  </xsl:template>

  <xsl:template name="tplResgisterLostFocusEvent">
    <xsl:param name="prmHandler"/>
    <xsl:attribute name="onblur"><xsl:value-of select="$prmHandler"/></xsl:attribute>
  </xsl:template>


  <xsl:template name="tplIsEnabled">
    <xsl:param name="prmCheckedNode" select="." />
    <xsl:param name="prmIsEnabled" />
      
    <xsl:choose>
      <xsl:when test="@Attr.Enabled='0' or $prmIsEnabled='0'">0</xsl:when>
      <xsl:when test="not($prmIsEnabled)">
        <xsl:variable name="varFirstParentWithEnabledFalse" select="$prmCheckedNode/ancestor::*[@Attr.Enabled='0'][1]" />        
        <xsl:choose>
          <xsl:when test="$varFirstParentWithEnabledFalse">
            <xsl:variable name="varFormOfCurrentChild" select="$prmCheckedNode/ancestor::WG:Tags.Form[1]" />
            <xsl:variable name="varFormOfDisabledParent" select="$varFirstParentWithEnabledFalse/ancestor-or-self::WG:Tags.Form[1]" />
            <xsl:choose>
              <xsl:when test="$varFormOfCurrentChild/@Attr.Id = $varFormOfDisabledParent/@Attr.Id">0</xsl:when>
              <xsl:otherwise>1</xsl:otherwise>
            </xsl:choose>
          </xsl:when>
          <xsl:otherwise>1</xsl:otherwise>
        </xsl:choose>
      </xsl:when>
      <xsl:otherwise>1</xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="tplWriteThemeClass">
    <xsl:if test="$varSupportsMultipleThemes='1'">      
      <xsl:call-template name="tplWriteTheme"></xsl:call-template>
      <xsl:value-of select="concat(' ','')"/>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplWriteThemeUrl">
    <xsl:if test="$varSupportsMultipleThemes='1' and not(@Attr.SkipMultiTheme='Url')">
      <xsl:text>../</xsl:text>
      <xsl:call-template name="tplWriteTheme"></xsl:call-template>
      <xsl:text>/</xsl:text>
    </xsl:if>
  </xsl:template>
  
  <xsl:template name="tplWriteTheme">
    <xsl:choose>
      <xsl:when test="@Attr.Theme and not(@Attr.Theme='')"><xsl:value-of select="@Attr.Theme"/></xsl:when>
      <xsl:otherwise>
        <xsl:variable name="varFirstParentWithTheme" select="./ancestor::*[@Attr.Theme and not(@Attr.Theme='')][1]" />
        <xsl:choose>
          <xsl:when test="$varFirstParentWithTheme"><xsl:value-of select="$varFirstParentWithTheme/@Attr.Theme"/></xsl:when>
        </xsl:choose>
      </xsl:otherwise>
    </xsl:choose>            
  </xsl:template>

  <!--
    /// <template name="tplSetClientUniqueId">
    /// <summary>
    /// Sets the ClientUniqeId (if exist) attribute to components
    /// </summary>
    /// </template>
  -->
  <xsl:template name="tplSetClientUniqueId">
    <xsl:if test="@Attr.ClientUniqeId">
      <xsl:attribute name="data-cuid">
        <xsl:value-of select="@Attr.ClientUniqeId"/>
      </xsl:attribute>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyUICapabilities" >
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmDataID" select="@Attr.Id"/>
    <xsl:param name="prmSelectable" select="@Attr.Selectable=1"/>
    <xsl:param name="prmResizable" select="@Attr.Resizable=1"/>
    <xsl:param name="prmDraggable" select="@Attr.Draggable=1"/>
    <xsl:param name="prmDroppable" select="@Attr.Droppable=1"/>

    <xsl:if test="$prmIsEnabled='1' or not($prmIsEnabled)">
      <xsl:if test="$prmDataID and not($prmDataID='')">
        <xsl:if test="$prmSelectable or $prmResizable or $prmDraggable or $prmDroppable">
          <xsl:variable name="varDataID">'<xsl:value-of select="$prmDataID"/>'</xsl:variable>
          <xsl:variable name="varResizableParams"><xsl:text>'</xsl:text><xsl:value-of select="@Attr.ResizableParams"/><xsl:text>'</xsl:text></xsl:variable>
          <xsl:variable name="varDraggableParams"><xsl:text>'</xsl:text><xsl:value-of select="@Attr.DraggableParams"/><xsl:text>'</xsl:text></xsl:variable>
          <xsl:call-template name="tplCallMethod">
            <xsl:with-param name="prmMethod" select="concat('mobjApp.Common_ApplyUICapabilities(window,',$varDataID,',',$prmSelectable,',',$prmResizable,',',$prmDraggable,',',$prmDroppable,',',$varResizableParams,',',$varDraggableParams,');')"/>
          </xsl:call-template>
        </xsl:if>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplySelectedIndicator">
    <xsl:if test="@Attr.SelectedIndicator=1">
      <div class="Common-PositionAbsolute Common-SelectedIndicatorSE"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorSW"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorNE"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorNW"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorN"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorE"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorS"></div>
      <div class="Common-PositionAbsolute Common-SelectedIndicatorW"></div>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawAlignedText">
    <xsl:param name="prmAlignment" />
    <xsl:param name="prmText" />
    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:param name="prmTextClass" />
    <xsl:param name="prmInvokeContentText" select="0" />
    
    <div style="display:table;width:100%;height:100%;">
      <div>
        <xsl:if test="$prmTextClass"><xsl:attribute name="class"><xsl:value-of select="$prmTextClass"/></xsl:attribute></xsl:if>
        <xsl:attribute name="style">
          display:table-cell;width: 100%;height:100%;
          <xsl:call-template name="tplTextHorizontalAlign">
            <xsl:with-param name="prmAlign" select="$prmAlignment"/>
          </xsl:call-template>
          <xsl:call-template name="tplTextVerticalAlign">
            <xsl:with-param name="prmAlign" select="$prmAlignment"/>
          </xsl:call-template>
          <xsl:if test="$prmWrapContents=1 and not($prmInvokeContentText=1)">white-space:nowrap;</xsl:if>
        </xsl:attribute>
        <xsl:choose>
          <xsl:when test="not($prmInvokeContentText=1)">
            <xsl:value-of select="$prmText"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:apply-templates mode="modContentText" select="." >
              <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
            </xsl:apply-templates>
          </xsl:otherwise>
        </xsl:choose>
      </div>
    </div>
  </xsl:template>

  <!--
    /// <template name="tplTextHorizontalAlign">
    /// <summary>
    /// Sets the text horizontal align.
    /// </summary>
    /// </template>
  -->
  <xsl:template name="tplTextHorizontalAlign">
    <xsl:param name="prmAlign"/>
    <xsl:param name="prmUseDefaultIfEmptyAlign" select="0"/>
    <xsl:text>text-align:</xsl:text>
    <xsl:choose>
      <xsl:when test="contains($prmAlign,'Left')"><xsl:value-of select="$left"/>;</xsl:when>
      <xsl:when test="contains($prmAlign,'Right')"><xsl:value-of select="$right"/>;</xsl:when>
      <xsl:when test="contains($prmAlign,'Center')">center;</xsl:when>
      <xsl:otherwise><xsl:if test="$prmUseDefaultIfEmptyAlign='1'">center;</xsl:if></xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--
    /// <template name="tplTextVerticalAlign">
    /// <summary>
    /// Sets the text vertical align.
    /// </summary>
    /// </template>
  -->
  <xsl:template name="tplTextVerticalAlign">
    <xsl:param name="prmAlign"/>
    <xsl:param name="prmUseDefaultIfEmptyAlign" select="0"/>
    <xsl:text>vertical-align:</xsl:text>
    <xsl:choose>
      <xsl:when test="contains($prmAlign,'Top')">top;</xsl:when>
      <xsl:when test="contains($prmAlign,'Bottom')">bottom;</xsl:when>
      <xsl:when test="contains($prmAlign,'Middle')">middle;</xsl:when>
      <xsl:otherwise><xsl:if test="$prmUseDefaultIfEmptyAlign='1'">middle;</xsl:if></xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="tplAddAccessibleNameLabel">
    <xsl:param name="prmId" />
    <xsl:param name="prmText" select="@Attr.AccessibleName" />

    <xsl:if test="$varAccessibilityMode='1' and $prmText and $prmText!=''">
      <label class="Common-Hidden" for="{$prmId}"><xsl:value-of select="$prmText"/></label>
    </xsl:if>
  </xsl:template>

  
</xsl:stylesheet>
