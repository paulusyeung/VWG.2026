<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  
  <xsl:template match="*" mode="modDragged">
    <div>
      <xsl:attribute name="style">
        position:relative; max-width:300px; max-height:300px; top:0px; left:0px; overflow:hidden;
        <!--Height/Width will be empty if docking -->
        <xsl:if test="not(@Attr.Height)">height:300px;</xsl:if>
        <xsl:if test="@Attr.Height">height:<xsl:value-of select="@Attr.Height"/>px;</xsl:if>
        <xsl:if test="not(@Attr.Width)">width:300px;</xsl:if>
        <xsl:if test="@Attr.Width">width:<xsl:value-of select="@Attr.Width"/>px;</xsl:if>
        <xsl:apply-templates mode="modApplyStyle" select="." />
      </xsl:attribute>

      <xsl:apply-templates select="." mode="modContent"/>
    </div>    
  </xsl:template>

  <xsl:template match="WG:Tags.DragElement">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:apply-templates select="parent::node()" mode="modDragged" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:apply-templates>
  </xsl:template>

  <xsl:template match="WG:Tags.DraggedOverElement">
    <xsl:apply-templates select="parent::node()" mode="modDragEnter" />
  </xsl:template>
  
</xsl:stylesheet>
