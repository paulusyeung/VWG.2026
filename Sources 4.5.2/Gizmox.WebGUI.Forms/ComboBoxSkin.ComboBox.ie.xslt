<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  
  <!--Registers an item "Enter" event-->
  <xsl:template name="tplRegisterComboBoxItemEnterEvent">
    <xsl:param name="prmControl"/>
    <xsl:param name="prmControlId" />
    <xsl:attribute name="onmouseenter">mobjApp.ComboBox_OnItemHover('<xsl:value-of select="$prmControlId"/>', '<xsl:value-of select="$prmControl/@Attr.Style"/>', mobjApp.Web_GetAttribute(this,'vwgindex'), window, event)</xsl:attribute>
  </xsl:template>
  
</xsl:stylesheet>