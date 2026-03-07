<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template name="tplDrawHostedControl">
    <xsl:param name="prmIsEnabled" />
    <div>
      <xsl:attribute name="style">overflow:hidden;width:100%;height:100%;display:table-cell;vertical-align:middle;</xsl:attribute>
      <xsl:call-template name="tplSetControl" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <div>
        <xsl:attribute name="style">
          width:100%;height:100%;
          <xsl:apply-templates mode="modApplyStyle" select="." />
        </xsl:attribute>
        <xsl:apply-templates select="." mode="modContent" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:apply-templates>
      </div>
    </div>
  </xsl:template>
  
  <xsl:template name="tplDrawToolStripControlHostAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:for-each select="WC:*">
      <div style="height:100%;width:100%;display:table;">
        <xsl:call-template name="tplDrawHostedControl">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </div>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStrip/WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]/WC:*">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawHostedControl">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.StatusStrip/WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]/WC:*">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawHostedControl">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.MenuStrip/WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]/WC:*">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawHostedControl">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStrip/WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripControlHostAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.StatusStrip/WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripControlHostAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

    <xsl:template match="WC:Tags.MenuStrip/WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]" mode="modContent">
      <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripControlHostAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripControlHostAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='5' and not(@Attr.CustomStyle)]" mode="modDropDownMenu">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripControlHostAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
