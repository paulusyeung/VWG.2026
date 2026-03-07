<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.MainMenu" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmControlClass" select="'MainMenu-Control'"/>

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:attribute name="data-FocusHandler">MainMenu</xsl:attribute>

    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmFrameClass" select="'MainMenu-Frame'"/>
      <xsl:with-param name="prmLeftClass" select="'MainMenu-FrameLeft'"/>
      <xsl:with-param name="prmRightClass" select="'MainMenu-FrameRight'"/>
      <xsl:with-param name="prmCenterClass" select="'MainMenu-FrameCenter'"/>
      <xsl:with-param name="prmCenterContent" select="." />

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="0"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="0"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.MainMenu" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:if test="count(Tags.Item)=0">&#160;</xsl:if>
    <xsl:if test="count(Tags.Item)>0">
      <xsl:for-each select="Tags.Item">
        <xsl:if test="position()>1">
          <div style="float:{$left}" class="MainMenu-Seperator"><xsl:call-template name="tplDrawEmptyImage"/></div>
        </xsl:if>
        <div class="Common-HandCursor MainMenu-MenuItem" style="float:{$left}">
          <xsl:attribute name="id">VWG_<xsl:value-of select="@Attr.Id" /></xsl:attribute>
          <xsl:call-template name="tplSetClientUniqueId" />
          <xsl:if test="not($prmIsEnabled='0') and not($prmIsEnabled='0')">            
            <xsl:call-template name="tplSetMouseEvents">
              <xsl:with-param name="prmHandler" select="'mobjApp.MainMenu_HandleEvent'"/>
            </xsl:call-template>         
            <div class="Common-BorderBox MainMenu-Left" style="width:[Skin.LeftMenuItemWidth]px;">&#160;</div>
            <div class="Common-BorderBox MainMenu-Center"><xsl:if test="@Attr.Text and not(@Attr.Text='')"><xsl:call-template name="tplDecodeTextAsHtml"/></xsl:if><xsl:if test="not(@Attr.Text) or @Attr.Text=''">&#160;</xsl:if></div>
            <div class="Common-BorderBox MainMenu-Right" style="width:[Skin.RightMenuItemWidth]px;">&#160;</div>
          </xsl:if>
          <xsl:if test="$prmIsEnabled='0' or $prmIsEnabled='0'">
            <div class="Common-BorderBox MainMenu-Left_Disable" style="width:[Skin.LeftMenuItemWidth]px;">&#160;</div>
            <div class="Common-BorderBox MainMenu-Center_Disable"><xsl:if test="@Attr.Text and not(@Attr.Text='')"><xsl:call-template name="tplDecodeTextAsHtml"/></xsl:if><xsl:if test="not(@Attr.Text) or @Attr.Text=''">&#160;</xsl:if></div>
            <div class="Common-BorderBox MainMenu-Right_Disable" style="width:[Skin.RightMenuItemWidth]px;">&#160;</div>
          </xsl:if>
        </div>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
