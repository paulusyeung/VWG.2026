<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:WC="wgcontrols">
  
  <xsl:template match="WC:Tags.ToolBarControl[not(@Attr.Style)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmFrameClass" select="'ToolBar-Frame'"/>
      <xsl:with-param name="prmLeftBottomClass" select="'ToolBar-BottomLeft'"/>
      <xsl:with-param name="prmLeftClass" select="'ToolBar-Left'"/>
      <xsl:with-param name="prmLeftTopClass" select="'ToolBar-TopLeft'"/>
      <xsl:with-param name="prmTopClass" select="'ToolBar-Top'"/>
      <xsl:with-param name="prmRightTopClass" select="'ToolBar-TopRight'"/>
      <xsl:with-param name="prmRightClass" select="'ToolBar-Right'"/>
      <xsl:with-param name="prmRightBottomClass" select="'ToolBar-BottomRight'"/>
      <xsl:with-param name="prmBottomClass" select="'ToolBar-Bottom'"/>
      <xsl:with-param name="prmCenterClass" select="'ToolBar-Center'"/>

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>

      <xsl:with-param name="prmCenterContent" select="."/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolBarControl" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:if test="@Attr.Background">
      <div style="position:relative;width:100%;height:100%;background-color:{@Attr.Background}">
        <xsl:call-template name="tplDrawContained">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </div>
    </xsl:if>
    <xsl:if test="not(@Attr.Background)">
      <xsl:call-template name="tplDrawContained">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolBarControl" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
