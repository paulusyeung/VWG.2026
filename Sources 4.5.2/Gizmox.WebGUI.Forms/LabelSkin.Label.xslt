<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Label" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawLabelAPI">
      <xsl:with-param name="prmWrapContents">
        <xsl:choose>
          <xsl:when test="$prmAutoSizeOrientation='0'">0</xsl:when>
          <xsl:otherwise>1</xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- The default style Label match template -->
  <xsl:template match="WC:Tags.Label" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLabelAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  <!-- The Main API for drawing the control -->
  <xsl:template name="tplDrawLabelAPI">
    <xsl:param name="prmControlClass" select="'Label-Control'"/>
    <xsl:param name="prmFontData" select ="'Label-FontData'"/>
    <xsl:param name="prmControlDisabledClass" select="'Label-Disabled'"/>
    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varImageAlign" select="@Attr.ImageAlign" />
    <xsl:variable name="varImage" select="@Attr.Image" />

    <!-- Set the control class -->
    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlDisabledClass)"/>
      </xsl:if>
    </xsl:attribute>

    <!-- Render the Label -->
    <div dir="{$dir}">
      <xsl:attribute name="style">
        width:100%;height:100%;
        <xsl:if test="$varImage">
          background-image:url('<xsl:value-of select="$varImage"/>');
          background-repeat:no-repeat;
          background-position:<xsl:if test="contains($varImageAlign,'Top')">top </xsl:if>
          <xsl:if test="contains($varImageAlign,'Bottom')">bottom </xsl:if>
          <xsl:if test="contains($varImageAlign,'Middle')">center </xsl:if>
          <xsl:if test="contains($varImageAlign,'Left')"><xsl:value-of select="$left"/></xsl:if>
          <xsl:if test="contains($varImageAlign,'Right')"><xsl:value-of select="$right"/></xsl:if>
          <xsl:if test="contains($varImageAlign,'Center')">center</xsl:if>;
        </xsl:if>
      </xsl:attribute>

      <xsl:call-template  name="tplDrawAlignedText">
        <xsl:with-param name="prmAlignment" select="@Attr.TextAlign" />
        <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
        <xsl:with-param name="prmInvokeContentText" select="1" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <!-- The default style Label Text match template -->
  <xsl:template match="WC:Tags.Label" mode="modContentText">
    <xsl:param name="prmWrapContents" select="1"/>

    <xsl:call-template name="tplDrawLabelContentAPI">
      <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
      <xsl:with-param name="prmFontDataClass" select="'Label-FontData'"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Label[@Attr.ControlEditMode='1']" mode="modContentText">
    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:call-template name="tplDrawEditingTextInput">
      <xsl:with-param name="prmInputClass" select="'TextBox-Input Label-ContentContainer'" />
    </xsl:call-template>
  </xsl:template>

  <!-- The Main API for drawing the control -->
  <xsl:template name="tplDrawLabelContentAPI">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmContentContainerClass" select="'Label-ContentContainer'"/>
    <xsl:param name="prmFontDataClass"/>
    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:param name="prmApplyFontStyles" select="1"/>

    <!-- Render the Label Content-->
    <div class="{$prmContentContainerClass}">
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyPaddings"/>
      </xsl:attribute>
      <xsl:call-template name="tplDrawLabelContentElement">
        <xsl:with-param name="prmText" select="$prmText" />
        <xsl:with-param name="prmApplyFontStyles" select="$prmApplyFontStyles"/>
        <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
        <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
        <xsl:with-param name="prmFontDataClass" select="$prmFontDataClass"/>
      </xsl:call-template>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawLabelContentElement">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmApplyFontStyles" select="1"/>
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:param name="prmFontDataClass"/>

    <span dir="{$dir}">
      <xsl:call-template name="tplDrawLabelContent">
        <xsl:with-param name="prmText" select="$prmText" />
        <xsl:with-param name="prmApplyFontStyles" select="$prmApplyFontStyles"/>
        <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
        <xsl:with-param name="prmFontDataClass" select="$prmFontDataClass"/>
        <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
      </xsl:call-template>
    </span>
  </xsl:template>

  <xsl:template name="tplDrawLabelContent">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmApplyFontStyles" select="1"/>
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmFontDataClass"/>
    <xsl:param name="prmWrapContents" select="1"/>

    <xsl:attribute name="class">
      Common-Unselectable
      <xsl:if test="$prmContentClass">
        <xsl:value-of select="concat(' ',$prmContentClass)"/>
      </xsl:if>
      <xsl:if test="$prmFontDataClass">
        <xsl:value-of select="concat(' ',$prmFontDataClass)"/>
      </xsl:if>
      <xsl:if test="not($prmWrapContents='1')"> nobr</xsl:if>
    </xsl:attribute>
    <xsl:attribute name="style">
      <xsl:if test="$prmApplyFontStyles='1'">
        <xsl:call-template name="tplApplyFontStyles"/>;
      </xsl:if>
      <xsl:call-template name="tplApplyCursorStyle" />;
    </xsl:attribute>
    <xsl:call-template name="tplDecodeTextAsHtml">
      <xsl:with-param name="prmText" select="$prmText" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
