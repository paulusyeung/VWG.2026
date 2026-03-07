<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The default style checkbox match template -->
  <xsl:template match="WC:Tags.CheckBox[@Attr.VisualTemplate='CheckBoxSwitchVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmLabelClass" select="'CheckBox-Label'" />
    <xsl:param name="prmControlClass" select="'CheckBox-Control'" />
    <xsl:param name="prmRoundedSwitch" select="'[Skin.RoundedSwitch]'" />
    <xsl:param name="prmUseAnimation" select="'[Skin.UseAnimation]'" />
    <xsl:param name="prmSwitchWidthPercentage" select="[Skin.SwitchWidthPercentage]" />

    <xsl:variable name="varId" select="@Attr.Id"/>
    <xsl:variable name="varControlClass" select="'CheckBox-Control'"/>

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:if test="not(@Attr.VisualTemplateCheckBoxShowLabel='0')">
      <div id="CHK_LBL_{@Id}">
        <xsl:attribute name="style">
          <xsl:text>height:100%;position:absolute;display:table;</xsl:text>
          <xsl:choose>
            <xsl:when test="$dir='RTL'">
              <xsl:text>direction:rtl;right:0px;left:</xsl:text>
            </xsl:when>
            <xsl:otherwise>
              <xsl:text>left:0px;right:</xsl:text>
            </xsl:otherwise>
          </xsl:choose>
          <xsl:value-of select="@Attr.VisualTemplateCheckBoxSwitchWidth"/>
          <xsl:choose>
            <xsl:when test="@Attr.VisualTemplateCheckBoxSwitchSizing='1'">
              <xsl:text>px;</xsl:text>
            </xsl:when>
            <xsl:otherwise>
              <xsl:text>%;</xsl:text>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        <div>
          <xsl:attribute name="style">
            <xsl:text>display:table-cell;width:100%;height:100%;position:relative;vertical-align:middle;</xsl:text>
          </xsl:attribute>
          <xsl:apply-templates select="." mode="modContentButtonText">
            <xsl:with-param name="prmText" select="@Attr.Text" />
            <xsl:with-param name="prmTextClass" select="$prmLabelClass" />
          </xsl:apply-templates>
        </div>
      </div>
    </xsl:if>
    <div>
      <xsl:attribute name="style">
        <xsl:text>height:100%;position:absolute;</xsl:text>
        <xsl:choose>
          <xsl:when test="$dir='RTL'">
            <xsl:text>left:0px;</xsl:text>
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>right:0px;</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
        <xsl:choose>
          <xsl:when test="not(@Attr.VisualTemplateCheckBoxShowLabel='0')">
            <xsl:text>width:</xsl:text>
            <xsl:value-of select="@Attr.VisualTemplateCheckBoxSwitchWidth"/>
            <xsl:choose>
              <xsl:when test="@Attr.VisualTemplateCheckBoxSwitchSizing='1'">
                <xsl:text>px;</xsl:text>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>%;</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>width:100%;</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <div class="CheckBox-Wrapper" id="CHK_WRP_{@Id}">
        <xsl:if test="not($prmIsEnabled='0') and (not(@Attr.AutoCheck='0'))">
          <xsl:attribute name="onclick">mobjApp.CheckBoxSwitch_OnClick(window,event,this,'<xsl:value-of select="$varId" />');</xsl:attribute>
        </xsl:if>
        <xsl:attribute name="onresize">mobjApp.CheckBoxSwitch_Init('<xsl:value-of select="$varId"/>',window);</xsl:attribute>
        <div class="CheckBox-StateLabel" id="CHK_SLBL_{@Id}">
          <xsl:attribute name="data-off">
            <xsl:choose>
              <xsl:when test="@Attr.VisualTemplateCheckBoxUnCheckedText">
                <xsl:value-of select="@Attr.VisualTemplateCheckBoxUnCheckedText" />
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>&#160;</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
          <xsl:attribute name="data-on">
            <xsl:choose>
              <xsl:when test="@Attr.VisualTemplateCheckBoxCheckedText">
                <xsl:value-of select="@Attr.VisualTemplateCheckBoxCheckedText" />
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>&#160;</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
          <xsl:attribute name="style">
            <xsl:choose>
              <xsl:when test="@Attr.Checked='1'">
                <xsl:text>margin-left:0;</xsl:text>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>margin-left:-100%</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
        </div>
        <div class="CheckBox-Switch" id="CHK_SWC_{@Id}">
          <xsl:attribute name="style">
            <xsl:choose>
              <xsl:when test="@Attr.Checked='1'">
                <xsl:text>right:0px;</xsl:text>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>left:0px;</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
          <xsl:attribute name="data-RoundedSwitch">
            <xsl:value-of select="$prmRoundedSwitch"/>
          </xsl:attribute>
          <xsl:attribute name="data-UseAnimation">
            <xsl:value-of select="$prmUseAnimation"/>
          </xsl:attribute>
          <xsl:attribute name="data-SwitchWidthPercentage">
            <xsl:value-of select="$prmSwitchWidthPercentage"/>
          </xsl:attribute>            
        </div>
      </div>
    </div>
    <xsl:call-template name="tplCallMethod">
      <xsl:with-param name="prmMethod" select="concat('mobjApp.CheckBoxSwitch_Init(',$varId,',window);')"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>