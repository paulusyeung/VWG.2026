<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.MasterPageContent[@Attr.CustomStyle='MasterPageContentSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <div style="width:100%; height:100%; position:relative;">
      <!-- Call tplSetControl for emulation form, to recieve critical events.  -->
      <xsl:call-template name="tplSetControl" />
    </div>
  </xsl:template>
</xsl:stylesheet>
