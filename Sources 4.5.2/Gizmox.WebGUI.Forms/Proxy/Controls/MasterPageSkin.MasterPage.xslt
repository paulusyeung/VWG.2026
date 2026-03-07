<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.MasterPage[@Attr.CustomStyle='MasterPageSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <div>
      <xsl:attribute name="style">
        width:100%;height:100%;<xsl:apply-templates mode="modApplyStyle" select="." />
      </xsl:attribute>
      <xsl:call-template name="tplSetControl" />
      <xsl:call-template name="tplDrawContained"/>
    </div>
  </xsl:template>  
</xsl:stylesheet>
