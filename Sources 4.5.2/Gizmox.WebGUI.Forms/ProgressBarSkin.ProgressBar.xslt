<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:WC="wgcontrols">
  <xsl:template match="WC:Tags.ProgressBar" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:call-template name="tplDrawScrollbarAPI">
      <xsl:with-param name="prmControlClass" select="'ProgressBar-Control'" />
      <xsl:with-param name="prmBarClass" select="'ProgressBar-Bar'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawScrollbarAPI">
    <xsl:param name="prmControlClass" select="'ProgressBar-Control'" />
    <xsl:param name="prmBarClass" select="'ProgressBar-Bar'"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">
      <xsl:value-of select="concat('Common-Unselectable',' ',$prmControlClass)" />
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:attribute name="dir">
      <xsl:value-of select="$dir"/>
    </xsl:attribute>
    
    <img style="position:absolute;left:0px;top:0px;height:100%;width:[Skin.ProgressBarImageLeftWidth]px" src="[Skin.ProgressBarImageLeft]" alt=""/>
    <div style="position:absolute;left:[Skin.ProgressBarImageLeftWidth]px;right:[Skin.ProgressBarImageLeftRight]px;height:100%;text-align:{$left};">
      <xsl:if test="@Precent &gt; 0">
        <div class="{$prmBarClass}">
          <xsl:attribute name="style">
            position:absolute;top:0px;<xsl:value-of select="$left" />:0px;height:100%;overflow:hidden;
            width:<xsl:value-of select="@Precent"/>%;
            <xsl:if test="@Precent &gt; 0 and [Skin.ProgressMinimumStartWidth] &gt; 0">
              min-width:[Skin.ProgressMinimumStartWidth]px;
            </xsl:if>
          </xsl:attribute>
        </div>
      </xsl:if>
    </div>
    <img style="position:absolute;right:0px;top:0px;height:100%;width:[Skin.ProgressBarImageLeftRight]px" src="[Skin.ProgressBarImageRight]" alt=""/>
  </xsl:template>
  
</xsl:stylesheet>

