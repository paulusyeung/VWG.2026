<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="*" mode="modDragEnter">
    <div style="width:100%;height:100%;position:relative;border:#316AC5 solid 1px;">
      <div style="position:relative;width:100%;height:100%;background-color:blue;filter:progid:DXImageTransform.Microsoft.Alpha(opacity=5);opacity:0.5;"></div>
    </div>
  </xsl:template>

</xsl:stylesheet>