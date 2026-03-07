<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

   <xsl:template match="WC:Tags.DateTimePicker[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
     <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawDateTimePickerAPI">
      <xsl:with-param name="prmControlClass" select="'DateTimePicker-Control'"/>
      <xsl:with-param name="prmInputClass" select="'DateTimePicker-InputValue'"/>
      <xsl:with-param name="prmCheckBoxIconContainerWidth" select="'[Skin.CheckBoxIconContainerWidth]'"/>
      <xsl:with-param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
      <xsl:with-param name="prmUnCheckedCheckBoxImage" select="'[Skin.UnCheckedCheckBoxImage]'"/>
      <xsl:with-param name="prmDropDownIconClass" select="'DateTimePicker-DropDownIcon'"/>
      <xsl:with-param name="prmDownIconClass" select="'DateTimePicker-UpDownDownIcon'"/>
      <xsl:with-param name="prmUpIconClass" select="'DateTimePicker-UpDownUpIcon'"/>
      <xsl:with-param name="prmDropDownIconContainerWidth" select="'[Skin.DropDownIconContainerWidth]'"/>
      <xsl:with-param name="prmUpDownIconContainerWidth" select="'[Skin.UpDownIconContainerWidth]'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmButtonContainerClass" select="'DateTimePicker-ButtonContainer'" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
