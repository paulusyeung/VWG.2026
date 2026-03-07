<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='AccelerationPanelSkin']" mode="modContent">
    <xsl:call-template name="tplDrawPanelAPI">
      <xsl:with-param name="prmControlClass" select="'Panel-Control'"/>
    </xsl:call-template>
      <div class="AccelerationPanel-Control" id="VGA_ACCELERATION_PANEL">
          <div class="AccelerationPanel-Ball" id="VGA_ACCELERATION_BALL">
              
          </div>
      </div>
  </xsl:template>
</xsl:stylesheet>
