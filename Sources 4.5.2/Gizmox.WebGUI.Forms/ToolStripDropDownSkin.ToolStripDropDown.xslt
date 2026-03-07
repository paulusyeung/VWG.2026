<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  
  <xsl:template name="tplDrawToolStripDropDownFormAPI">
    <xsl:param name="prmToolStripDropDown" select="'ToolStripDropDown-DropDown'" />
    <xsl:param name="prmLeftBottomClass" select="'ToolStripDropDown-DropDownBottomLeft'"/>
    <xsl:param name="prmLeftClass" select="'ToolStripDropDown-DropDownLeft'"/>
    <xsl:param name="prmLeftTopClass" select="'ToolStripDropDown-DropDownTopLeft'"/>
    <xsl:param name="prmTopClass" select="'ToolStripDropDown-DropDownTop'"/>
    <xsl:param name="prmRightTopClass" select="'ToolStripDropDown-DropDownTopRight'"/>
    <xsl:param name="prmRightClass" select="'ToolStripDropDown-DropDownRight'"/>
    <xsl:param name="prmRightBottomClass" select="'ToolStripDropDown-DropDownBottomRight'"/>
    <xsl:param name="prmBottomClass" select="'ToolStripDropDown-DropDownBottom'"/>
    <xsl:param name="prmCenterClass" select="'ToolStripDropDown-DropDownCenter'"/>
    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftDropDownFrameWidth]"/>
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightDropDownFrameWidth]" />
    <xsl:param name="prmTopFrameHeight"  select="[Skin.TopDropDownFrameHeight]"/>
    <xsl:param name="prmBottomFrameHeight"  select="[Skin.BottomDropDownFrameHeight]"/>
    <xsl:param name="prmIsEnabled" />
    
    <xsl:variable name="varFormHeightOffset" select="[Skin.DropDownOffsetHeight]"/>
    <xsl:variable name="varFormWidthOffset" select="[Skin.DropDownOffsetWidth]"/>
    <xsl:variable name="varBoxShadowSupport"><xsl:call-template name="tplSupportsCSS3BrowserCapability"><xsl:with-param name="prmCSS3BrowserCapability" select="32"/></xsl:call-template></xsl:variable>
    <div class="{$prmToolStripDropDown}" style="height:{number(@Attr.Height)+$varFormHeightOffset}px;width:{number(@Attr.Width)+$varFormWidthOffset}px;">
         <xsl:call-template name="tplDrawFrame">
             <xsl:with-param name="prmLeftBottomClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmLeftBottomClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmLeftClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmLeftClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmLeftTopClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmLeftTopClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmTopClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmTopClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmRightTopClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmRightTopClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmRightClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmRightClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmRightBottomClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmRightBottomClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmBottomClass">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmBottomClass"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmCenterClass" select="$prmCenterClass"/>
             <xsl:with-param name="prmCenterContent" select="." />

             <xsl:with-param name="prmLeftFrameWidth">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmLeftFrameWidth"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmRightFrameWidth">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmRightFrameWidth"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmTopFrameHeight">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                     <xsl:otherwise>
                         <xsl:value-of select="$prmTopFrameHeight"/>
                     </xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmBottomFrameHeight">
                 <xsl:choose>
                     <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                     <xsl:otherwise><xsl:value-of select="$prmBottomFrameHeight"/></xsl:otherwise>
                 </xsl:choose>
             </xsl:with-param>
             <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
         </xsl:call-template>
    </div>
  </xsl:template>

  <!--Match for a form which is displayed whithin a popup window-->
  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.CustomStyle='ToolStripDropDown']">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled" />
    
    <xsl:call-template name="tplDrawToolStripDropDownFormAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawToolStripDropDownFormCenterContentAPI">
    <div>
      <xsl:attribute name="style">
        <xsl:text>height:100%;width:100%;</xsl:text>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
          <xsl:with-param name="prmVisualEffects" select="0" />
        </xsl:call-template>
      </xsl:attribute>
      <xsl:call-template name="tplDrawContained"/>
    </div>
  </xsl:template>

  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.CustomStyle='ToolStripDropDown']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawToolStripDropDownFormCenterContentAPI"/>
  </xsl:template>
  
</xsl:stylesheet>
