<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

	<xsl:template match="WC:Tags.StatusBar" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:attribute name="class">
      <xsl:text>StatusBar-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> StatusBar-Control_Disabled</xsl:text>
      </xsl:if>
      <xsl:if test="not(@Attr.Background) and not(@Attr.BackgroundImage)"> StatusBar-BackgroundTopImage</xsl:if></xsl:attribute>
    <table dir="{$dir}">
      <xsl:attribute name="class">Common-CellSpacing0 Common-CellPadding0 StatusBar-Layout<xsl:if test="not(@Attr.Background) and not(@Attr.BackgroundImage)"> StatusBar-BackgroundBottomImage</xsl:if></xsl:attribute>
      <tr >
        <!--Show Panels = True-->
        <xsl:if test="Tags.StatusPanel">
          <!--Call each panel-->
          <xsl:apply-templates select="Tags.StatusPanel">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
          <!--If none of the panels has a Spring style - Add a DT in the end-->
          <xsl:if test="not(Tags.StatusPanel[@Attr.AutoSize='2'])"> <!-- AutoSize = StatusBarPanelAutoSize.Spring -->
            <td><div dir="{$dir}" class="StatusBar-Panel" style="width:100%;"></div></td>
          </xsl:if>
        </xsl:if>

        <!--No Panels-->
        <xsl:if test="not(Tags.StatusPanel)">
          <td class="StatusBar-Panel Common-FontData">
            <xsl:attribute name="style">
              <xsl:call-template name="tplApplyFontStyles" />;
            </xsl:attribute>
            <xsl:call-template name="tplDecodeTextAsHtml"/>&#160;
          </td>
        </xsl:if>
      </tr>
    </table>
  </xsl:template>

  <xsl:template match="Tags.StatusPanel">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:variable name="varClassName" select="'Common-FontData'" />
    <td>
    <xsl:variable name="varStatusPanelWidth">
      <xsl:choose>
        <xsl:when test="@Attr.AutoSize='1'">
          <!-- AutoSize = StatusBarPanelAutoSize.None -->
            <xsl:value-of select="@Attr.Width"/>px
        </xsl:when>
        <xsl:when test="@Attr.AutoSize='3'">
          <!-- AutoSize = StatusBarPanelAutoSize.Contents -->
          1px
        </xsl:when>
      </xsl:choose>
    </xsl:variable>
      <xsl:call-template name="tplSetControl">
        <xsl:with-param name="prmClassName" select="$varClassName" />
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      
      <!--Set the TD size-->
      <xsl:attribute name="style">vertical-align:middle;width:<xsl:value-of select="$varStatusPanelWidth"/>;</xsl:attribute>
      
      <div dir="ltr" class="StatusBar-Panel">
        <xsl:attribute name="style">
          position:relative; top:0px; <xsl:value-of select="$left"/>:0px;
          <!--Set the div size-->
          <xsl:if test="@Attr.AutoSize='1'"> <!-- AutoSize = StatusBarPanelAutoSize.None -->
            width:<xsl:value-of select="@Attr.Width"/>px;
            overflow:hidden;
          </xsl:if>
          <xsl:if test="@Attr.AutoSize='2'"> <!-- AutoSize = StatusBarPanelAutoSize.Spring -->
            width:100%;
            overflow:hidden;
          </xsl:if>
          <xsl:call-template name="tplApplyStyles" >
            <xsl:with-param name="prmBorder" select="0" />
            <xsl:with-param name="prmBackground" select="0"/>
            <xsl:with-param name="prmFont" select="1"/>
            <xsl:with-param name="prmCursor" select="0" />
            <xsl:with-param name="prmVisualEffects" select="1"/>
          </xsl:call-template>;
        </xsl:attribute>
        <xsl:call-template name="tplDrawButtonContent">
          <xsl:with-param name="prmText" select="@Attr.Text"/>
          <xsl:with-param name="prmTextClass" select="'StatusBar-PanelText'"/>
          <xsl:with-param name="prmTextAlign">
            <xsl:choose>
              <xsl:when test="@Attr.HorizontalAlignment='Center'">'CenterMiddle'</xsl:when>
              <xsl:when test="@Attr.HorizontalAlignment='Right'">'RightMiddle'</xsl:when>
              <xsl:otherwise>'LeftMiddle'</xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmLayoutPadding" select="0" />
        </xsl:call-template>
        <div style="position:absolute;overflow:hidden;top:0px;{$right}:0px;height:100%;width:[Skin.SeparatorImageWidth]px;background-image:url([Skin.SeparatorImage]);background-repeat:repeat-y;">&#160;</div>
      </div>
    </td>
  </xsl:template>

</xsl:stylesheet>
