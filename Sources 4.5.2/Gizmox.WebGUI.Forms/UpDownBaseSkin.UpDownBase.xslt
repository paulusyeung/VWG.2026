<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols"
	xmlns:Common="http://www.gizmox.com/webgui/common">

  <xsl:template name="tplDrawUpDownAPI">
    <xsl:param name="prmEventsHandler" />
    <xsl:param name="prmMouseEventsHandler" />
    <xsl:param name="prmControlClass" select="'UpDownBase-Control'"/>
    <xsl:param name="prmInputClass" select="'UpDownBase-Input'"/>
    <xsl:param name="prmDownCellClass" select="'UpDownBase-DownCell'"/>
    <xsl:param name="prmUpCellClass" select="'UpDownBase-UpCell'"/>
    <xsl:param name="prmImageCellWidth" select="'[Skin.ImageCellWidth]'"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmButtonsContainerClass" select="'UpDownBase-ButtonsContainer'" />

    <xsl:variable name="varShowButtons" select="not(@Attr.HideButtons='1')"/>

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <div>
      <xsl:attribute name="style">
        <xsl:text>width:100%;height:100%;</xsl:text>
        <xsl:call-template name="tplApplyStyles" >
          <xsl:with-param name="prmBorder" select="1" />
          <xsl:with-param name="prmBackground" select="1"/>
          <xsl:with-param name="prmFont" select="0"/>
          <xsl:with-param name="prmCursor" select="0" />
          <xsl:with-param name="prmVisualEffects" select="0"/>
        </xsl:call-template>
      </xsl:attribute>
      <xsl:attribute name="dir">
        <xsl:choose>
          <xsl:when test="@Attr.UpDownAlign='Left'">rtl</xsl:when>
          <xsl:otherwise>ltr</xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:if test="$varShowButtons">
        <div class="{$prmButtonsContainerClass}" style="direction:ltr;height:100%;width:{$prmImageCellWidth}px;float:{@Attr.UpDownAlign};">
          <xsl:call-template name="tplSetHighlight" >
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:attribute name="style">height:100%;width:<xsl:value-of select="$prmImageCellWidth"/>px;float:<xsl:choose><xsl:when test="@Attr.UpDownAlign='Left'">left</xsl:when><xsl:otherwise>right</xsl:otherwise></xsl:choose>;</xsl:attribute>
          <div id="UDB_U_{@Id}" class="{$prmUpCellClass}" style="height:50%;display:block;">
            <xsl:if test="not($prmIsEnabled='0')">
              <xsl:attribute name="onmousedown">if(mobjApp.Web_IsLeftClick(event)) { this.className='<xsl:value-of select="$prmUpCellClass"/>_Down';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mousedown',window); }</xsl:attribute>
              <xsl:attribute name="onmouseenter">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmUpCellClass"/>_Enter';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseenter',window);</xsl:attribute>
              <xsl:attribute name="onmouseover">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmUpCellClass"/>_Enter';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseover',window);</xsl:attribute>
              <xsl:attribute name="onmouseleave">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmUpCellClass"/>';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseleave',window);</xsl:attribute>
              <xsl:attribute name="onmouseout">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmUpCellClass"/>';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseout',window);</xsl:attribute>
              <xsl:attribute name="onmouseup">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmUpCellClass"/>_Enter';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseup',window);</xsl:attribute>
              <xsl:attribute name="onclick"><xsl:value-of select="$prmMouseEventsHandler"/>(this,'click',window);</xsl:attribute>
            </xsl:if>
          </div>
          <div id="UDB_D_{@Id}" class="{$prmDownCellClass}" style="height:50%;">
            <xsl:if test="not($prmIsEnabled='0')">
              <xsl:attribute name="onmousedown">if(mobjApp.Web_IsLeftClick(event)) { this.className='<xsl:value-of select="$prmDownCellClass"/>_Down';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mousedown',window); }</xsl:attribute>
              <xsl:attribute name="onmouseenter">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmDownCellClass"/>_Enter';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseenter',window);</xsl:attribute>
              <xsl:attribute name="onmouseover">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmDownCellClass"/>_Enter';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseover',window);</xsl:attribute>
              <xsl:attribute name="onmouseleave">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmDownCellClass"/>';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseleave',window);</xsl:attribute>
              <xsl:attribute name="onmouseout">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmDownCellClass"/>';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseout',window);</xsl:attribute>
              <xsl:attribute name="onmouseup">this.className=Controls_GetTheme('<xsl:value-of select="@Attr.Id"/>') + ' <xsl:value-of select="$prmDownCellClass"/>_Enter';<xsl:value-of select="$prmMouseEventsHandler"/>(this,'mouseup',window);</xsl:attribute>
              <xsl:attribute name="onclick"><xsl:value-of select="$prmMouseEventsHandler"/>(this,'click',window);</xsl:attribute>
            </xsl:if>
          </div>
        </div>
      </xsl:if>
      <div>
        <xsl:attribute name="style">overflow:hidden;height:100%;</xsl:attribute>
        <input dir="ltr" id="UDB_Input_{@Id}" tabindex="-1"  data-vwgeditable="1" onblur="{$prmEventsHandler}('{@Id}','blur',window,event)" type="text" data-vwgfocuselement="1">
          <xsl:attribute name="class">
            <xsl:value-of select="concat('Common-FontData ',$prmInputClass)"/>
            <xsl:if test="$prmIsEnabled='0' or @Attr.ReadOnly='1'">
              <xsl:value-of select="concat(' ',$prmInputClass,'_Disabled')"/>
            </xsl:if>
          </xsl:attribute>
          <xsl:if test="@Attr.ReadOnly='1'"><xsl:attribute name="readonly">readonly</xsl:attribute></xsl:if>
          <xsl:attribute name="value">
            <xsl:call-template name="tplDecodeText"/>
          </xsl:attribute>
          <xsl:call-template name="tplSetDisabled" >
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:attribute name="style">
            width:100%;height:100%;border-style:none;padding-left:4px;padding-right:4px;background-color:transparent;text-shadow:inherit;
            <xsl:call-template name="tplApplyFontStyles"/>
            <xsl:call-template name="tplTextHorizontalAlign">
              <xsl:with-param name="prmAlign" select="@Attr.TextAlign"/>
              <xsl:with-param name="prmUseDefaultIfEmptyAlign" select="1"/>
            </xsl:call-template>
          </xsl:attribute>
          <xsl:if test="not(@Attr.InterceptArrowKeys)">
            <xsl:attribute name="onkeydown"><xsl:value-of select="$prmEventsHandler"/>('<xsl:value-of select="@Id" />','keydown',window,event);</xsl:attribute>
            <xsl:attribute name="onkeyup"><xsl:value-of select="$prmEventsHandler"/>('<xsl:value-of select="@Id" />','keyup',window,event);</xsl:attribute>
            <xsl:attribute name="onkeypress"><xsl:value-of select="$prmEventsHandler"/>('<xsl:value-of select="@Id" />','keypress',window,event);</xsl:attribute>
          </xsl:if>
        </input>
        <xsl:call-template name="tplAddAccessibleNameLabel">
          <xsl:with-param name="prmId">UDB_Input_<xsl:value-of select="@Id"/></xsl:with-param>
        </xsl:call-template>
      </div>
    </div>
  </xsl:template>

</xsl:stylesheet>
