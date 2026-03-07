<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:WC="wgcontrols"
                xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template name="tplDrawStateButtonContent">
    <xsl:param name="prmControlClass" />
    <xsl:param name="prmLabelClass"/>
    <xsl:param name="prmCheckedImage"/>
    <xsl:param name="prmUnCheckedImage"/>
    <xsl:param name="prmIndeterminateImage"/>
    
    <xsl:param name="prmStateImageAlign" select="@Attr.ContentAlign" />
    <xsl:param name="prmStateImageHeight" />
    <xsl:param name="prmStateImageWidth"  />

    <!-- Params for using the checkbox from other controls -->
    <xsl:param name="prmId" select="@Id" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAssignEvents" select="not($prmIsEnabled='0')" />

    <!-- Params for handlers -->
    <xsl:param name="prmOnClick"/>
    <xsl:param name="prmOnKeyDown"/>
    <xsl:param name="prmOnTouchEnd"/>
    <xsl:param name="prmAfterNavKeyDown"/>
    
    <!-- Set the control class -->
    <xsl:attribute name="class">
      <xsl:text>Common-Unselectable </xsl:text>
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:text>Common-HandCursor </xsl:text>
      </xsl:if>
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <!-- Bind control events if enabled or not canceled by host -->
    <xsl:if test="$prmAssignEvents=1">
      <xsl:attribute name="onclick"><xsl:value-of select="$prmOnClick"/></xsl:attribute>
      <xsl:attribute name="onkeydown"><xsl:value-of select="$prmOnKeyDown"/></xsl:attribute>
      <xsl:attribute name="ontouchend"><xsl:value-of select="$prmOnTouchEnd"/></xsl:attribute>
      <xsl:attribute name="data-vwg_AfterArrowKeyPressEventHandler">
        <xsl:value-of select="$prmAfterNavKeyDown"/>
      </xsl:attribute>
    </xsl:if>

    <!-- Enable focus events to change the control style -->
    <xsl:call-template name="tplSetFocusable">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>

    <!-- Render the Control -->
    <div dir="{$dir}" class="ButtonBase-StateButtonContent">
      <!-- Set the Container style -->
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyPaddings"/>
      </xsl:attribute>

	  <!-- Set the state image value as for the checked attribute  -->
      <xsl:variable name="varStateImage">
        <xsl:choose>
          <xsl:when test="@Attr.Checked=0"><xsl:value-of select="$prmUnCheckedImage"/></xsl:when>
          <xsl:when test="@Attr.Checked=1"><xsl:value-of select="$prmCheckedImage"/></xsl:when>
          <xsl:when test="@Attr.Checked=2"><xsl:value-of select="$prmIndeterminateImage"/></xsl:when>
          <xsl:otherwise><xsl:value-of select="$prmUnCheckedImage"/></xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      
      
      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmTextClass" select="$prmLabelClass"/>
        <xsl:with-param name="prmStateImage" select="$varStateImage"/>
        <xsl:with-param name="prmStateImageAlign" select="$prmStateImageAlign"/>
        <xsl:with-param name="prmStateImageId" select="concat('TRG_',$prmId)"/>
        <xsl:with-param name="prmStateImageHeight" select="$prmStateImageHeight"/>
        <xsl:with-param name="prmStateImageWidth" select="$prmStateImageWidth"/>
      </xsl:call-template>
    </div>
  </xsl:template>
  
  <!-- Applies common button attributes -->
  <xsl:template name="tplApplyButtonAttributes">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmButtonClass" />
    <xsl:param name="prmClickHandler" />
    <xsl:param name="prmKeyDownHandler" />
    <xsl:param name="prmAfterNavKeyDownHandler"/>
    <xsl:param name="prmSupportStateStyle">1</xsl:param>

    <xsl:attribute name="dir"><xsl:value-of select="$dir"/></xsl:attribute>
      
    <!-- If button is disabled -->
    <xsl:if test="$prmIsEnabled='0'">
      <xsl:attribute name="class"><xsl:value-of select="concat('Common-Unselectable ',$prmButtonClass,' ',$prmButtonClass,'_Disabled')"/></xsl:attribute>
    </xsl:if>
    
    <!-- If button is enabled -->
    <xsl:if test="not($prmIsEnabled='0')">
      <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor Common-Unselectable ',$prmButtonClass)"/></xsl:attribute>
      <xsl:if test="$prmKeyDownHandler">
        <xsl:attribute name="onkeydown"><xsl:value-of select="$prmKeyDownHandler" /></xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmClickHandler">
        <xsl:attribute name="onclick"><xsl:value-of select="$prmClickHandler" /></xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmAfterNavKeyDownHandler">
        <xsl:attribute name="data-vwg_AfterArrowKeyPressEventHandler">
          <xsl:value-of select="$prmAfterNavKeyDownHandler" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmSupportStateStyle='1'">
        <xsl:call-template name="tplSetHighlight" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:call-template name="tplSetFocusable" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:if>
    </xsl:if>   
  </xsl:template>
  
</xsl:stylesheet>