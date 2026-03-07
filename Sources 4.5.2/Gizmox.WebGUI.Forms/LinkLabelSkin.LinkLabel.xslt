<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.LinkLabel" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawLinkLabelAPI">
      <xsl:with-param name="prmWrapContents">
        <xsl:choose>
          <xsl:when test="$prmAutoSizeOrientation='0'">0</xsl:when>
          <xsl:otherwise>1</xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- The default style LinkLabel match template -->
  <xsl:template match="WC:Tags.LinkLabel" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLinkLabelAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <!-- The default style LinkLabel content match template -->
  <xsl:template match="WC:Tags.LinkLabel" mode="modContentText">
    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawLinkLabelContentAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing the control-->
  <xsl:template name="tplDrawLinkLabelContentAPI">
    <xsl:param name="prmFocusClass" select="'LinkLabel-ContentContainer'"/>
    <xsl:param name="prmWrapContents" select="1"/>

    <!-- Params for using the LinkLabel from other controls -->
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAssignHref" select="not($prmIsEnabled='0')"/>
    <xsl:param name="prmFocusable" select="1"/>

    <xsl:choose>
      <!-- ________ If ClientMode is true and URL exists ________ -->
      <xsl:when test="@Attr.Value and not(@Attr.Value='')">
        <xsl:choose>
          <!-- ________ If receives focus ________ -->
          <xsl:when test="$prmFocusable=1">
            <div class="{$prmFocusClass}">
              <xsl:call-template name="tplDrawClientContent">
                <xsl:with-param name="prmAssignHref" select="$prmAssignHref"/>
                <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </div>
          </xsl:when>
          <!-- ________ If does not receive focus ________ -->
          <xsl:otherwise>
            <xsl:call-template name="tplDrawClientContent">
              <xsl:with-param name="prmAssignHref" select="$prmAssignHref"/>
              <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:when>
      <!-- ________________ If Server Mode __________________________ -->
      <xsl:otherwise>
        <!-- ________ If receives focus ________ -->
        <xsl:call-template name="tplDrawLabelContentAPI" >
          <xsl:with-param name="prmContentClass" select="'Common-HandCursor'"/>
          <xsl:with-param name="prmContentContainerClass" select="$prmFocusClass"/>
          <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!-- Draw LinkLabel Content in client mode - 'a' element-->
  <xsl:template name="tplDrawClientContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAssignHref" select="not($prmIsEnabled='0')"/>
    <xsl:param name="prmWrapContents" select="1"/>
    
    <a class="'Common-FontData Common-HandCursor'">
      <xsl:attribute name="onmousedown">mobjApp.Web_EventCancelBubble(event,true,false)</xsl:attribute>
      <xsl:if test="$prmAssignHref=1">
        <xsl:attribute name="href">
          <xsl:value-of select="@Attr.Value"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyFontStyles" />;
        <xsl:call-template name="tplApplyCursorStyle" />;
        <xsl:if test="$prmWrapContents='0'">white-space:nowrap;</xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplDecodeTextAsHtml"/>
    </a>
  </xsl:template>

  <!--Main API for drawing the control-->
  <xsl:template name="tplDrawLinkLabelAPI">
    <xsl:param name="prmControlClass" select="'LinkLabel-Control'"/>
    <xsl:param name="prmControlDisabledClass" select="'LinkLabel-Disabled'"/>
    <xsl:param name="prmWrapContents" select="1"/>

    <!-- Params for using the LinkLabel from other controls -->
    <xsl:param name="prmId" select="@Attr.Id"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAssignEvents" select="not($prmIsEnabled='0')" />

    <!-- Enable focus events to change the control style -->
    <xsl:call-template name="tplSetFocusable" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>

    <!-- Bind control events if enabled or not canceled by host -->
    <xsl:if test="$prmAssignEvents=1">
      <xsl:attribute name="onkeydown">
        <xsl:value-of select="concat('mobjApp.LinkLabel_KeyDown(&quot;',$prmId,'&quot;,window,event);')"/>
      </xsl:attribute>
    </xsl:if>

    <!-- Render the LinkLabel -->
    <xsl:call-template name="tplDrawLabelAPI" >
      <xsl:with-param name="prmControlClass" select="$prmControlClass"/>
      <xsl:with-param name="prmControlDisabledClass" select="$prmControlDisabledClass"/>
      <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
