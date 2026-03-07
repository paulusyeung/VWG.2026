<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='CompassSkin']" mode="modContent">
      <div style="position:relative; width:285px; height: 329px;">         

        <xsl:call-template name="tplDrawPanelAPI">
          <xsl:with-param name="prmControlClass" select="'Panel-Control'"/>
        </xsl:call-template>
        <div class="Compass-Arrow" id="VWG_ARROW">          
        </div>          
      </div>
  </xsl:template>
</xsl:stylesheet>
