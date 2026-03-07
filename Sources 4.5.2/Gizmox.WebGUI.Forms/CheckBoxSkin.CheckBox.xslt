<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The default style checkbox match template -->
  <xsl:template match="WC:Tags.CheckBox[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCheckBoxAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <!-- Main API for drawing the control -->
  <xsl:template name="tplDrawCheckBoxAPI">
    <xsl:param name="prmControlClass" select="'CheckBox-Control'" />
    <xsl:param name="prmLabelClass" select="'CheckBox-Label'" />
    <xsl:param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
    <xsl:param name="prmUnCheckedCheckBoxImage" select="'[Skin.UnCheckedCheckBoxImage]'"/>
    <xsl:param name="prmIndeterminateCheckBoxImage" select="'[Skin.IndeterminateCheckBoxImage]'"/>
    <xsl:param name="prmStateImageHeight" select="[Skin.CheckBoxImageHeight]" />
    <xsl:param name="prmStateImageWidth" select="[Skin.CheckBoxImageWidth]" />
    <xsl:param name="prmAppearance" select="@Attr.Appearance" />

    <!-- Params for using the checkbox from other controls -->
    <xsl:param name="prmId" select="@Id" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAssignEvents" select="not($prmIsEnabled='0')" />

    <xsl:attribute name="data-vwgappearance"><xsl:value-of select="$prmAppearance"/></xsl:attribute>

    <xsl:call-template name="tplDrawStateButtonContent" >
      <xsl:with-param name="prmControlClass" select="$prmControlClass" />
      <xsl:with-param name="prmLabelClass" select="$prmLabelClass" />
      <xsl:with-param name="prmCheckedImage" select="$prmCheckedCheckBoxImage" />
      <xsl:with-param name="prmUnCheckedImage" select="$prmUnCheckedCheckBoxImage" />
      <xsl:with-param name="prmIndeterminateImage" select="$prmIndeterminateCheckBoxImage" />
      <xsl:with-param name="prmId" select="$prmId" />
      <xsl:with-param name="prmAssignEvents" select="$prmAssignEvents" />
      <xsl:with-param name="prmStateImageHeight" select="$prmStateImageHeight" />
      <xsl:with-param name="prmStateImageWidth" select="$prmStateImageWidth" />

      <!-- Params for handlers -->
      <xsl:with-param name="prmOnClick"><xsl:value-of select="concat('mobjApp.CheckBox_Click(&quot;',$prmId,'&quot;,window,event);')"/></xsl:with-param>
      <xsl:with-param name="prmOnKeyDown"><xsl:value-of select="concat('mobjApp.CheckBox_KeyDown(&quot;',$prmId,'&quot;,window,event);')"/></xsl:with-param>

      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template name="tplDrawCheckBoxInButtonAppereanceAPI">
    <!--Template parameters-->
    <xsl:param name="prmId" select="@Attr.Id" />
    <xsl:param name="prmCheckBoxClass" select="'CheckBox-ButtonControl'"/>
    <xsl:param name="prmCheckedCheckBoxClass" select="'CheckBox-ButtonControlChecked'"/>
    <xsl:param name="prmLeftBottomClass" select="'CheckBox-BottomLeft'" />
    <xsl:param name="prmLeftClass" select="'CheckBox-Left'" />
    <xsl:param name="prmLeftTopClass" select="'CheckBox-TopLeft'" />
    <xsl:param name="prmTopClass" select="'CheckBox-Top'" />
    <xsl:param name="prmRightTopClass" select="'CheckBox-TopRight'" />
    <xsl:param name="prmRightClass" select="'CheckBox-Right'" />
    <xsl:param name="prmRightBottomClass" select="'CheckBox-BottomRight'" />
    <xsl:param name="prmBottomClass" select="'CheckBox-Bottom'" />
    <xsl:param name="prmFontDataClass" select="'CheckBox-FontData'" />
    <xsl:param name="prmCenterClass" select="'CheckBox-Center'" />
    <xsl:param name="prmCenterTransparentClass" select="'CheckBox-CenterTransparent'" />
    <xsl:param name="prmContentClass" select="'CheckBox-Content'" />
    <xsl:param name="prmClickHandler" select="concat('mobjApp.CheckBox_Click(&quot;',$prmId,'&quot;,window,event);')"/>
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.CheckBox_KeyDown(&quot;',$prmId,'&quot;,window,event);')"/>
    <xsl:param name="prmSupportStateStyle">1</xsl:param>

    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
    <xsl:param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAppearance" select="@Attr.Appearance" />

    <xsl:variable name="varCheckedState" select="@Attr.Checked"/>
    
    <xsl:attribute name="data-vwgappearance"><xsl:value-of select="$prmAppearance"/></xsl:attribute>   
    
    <!-- Apply button attributes -->
    <xsl:call-template name="tplApplyButtonAttributes" >
      <xsl:with-param name="prmButtonClass">
        <xsl:choose>
          <xsl:when test="$varCheckedState='1' or $varCheckedState='2'"><xsl:value-of select="$prmCheckedCheckBoxClass"/></xsl:when>
          <xsl:otherwise><xsl:value-of select="$prmCheckBoxClass"/></xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmClickHandler" select="$prmClickHandler"/>
      <xsl:with-param name="prmKeyDownHandler" select="$prmKeyDownHandler"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmSupportStateStyle" select="$prmSupportStateStyle"/>
    </xsl:call-template>

    <!-- Draw Check button frame -->
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmLeftBottomClass" select="$prmLeftBottomClass"/>
      <xsl:with-param name="prmLeftClass" select="$prmLeftClass"/>
      <xsl:with-param name="prmLeftTopClass" select="$prmLeftTopClass"/>
      <xsl:with-param name="prmTopClass" select="$prmTopClass"/>
      <xsl:with-param name="prmRightTopClass" select="$prmRightTopClass"/>
      <xsl:with-param name="prmRightClass" select="$prmRightClass"/>
      <xsl:with-param name="prmRightBottomClass" select="$prmRightBottomClass"/>
      <xsl:with-param name="prmBottomClass" select="$prmBottomClass"/>
      <xsl:with-param name="prmCenterClass" select="concat($prmFontDataClass,' ',$prmCenterClass)"/>
      <xsl:with-param name="prmContentClass" select="$prmContentClass" />
      <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth"/>
      <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth" />
      <xsl:with-param name="prmTopFrameHeight"  select="$prmTopFrameHeight"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="$prmBottomFrameHeight"/>
      <xsl:with-param name="prmLeftContentOffset" select="0" />
      <xsl:with-param name="prmRightContentOffset" select="0" />
      <xsl:with-param name="prmTopContentOffset" select="0" />
      <xsl:with-param name="prmBottomContentOffset" select="0" />
      <xsl:with-param name="prmCenterContent" select="."/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- The button appereance CheckBox match template -->
  <xsl:template match="WC:Tags.CheckBox[@Attr.Appearance='1']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCheckBoxInButtonAppereanceAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawCheckBoxInButtonAppereanceCenterContentAPI">
    <!--Template parameters-->
    <xsl:param name="prmFontDataClass" select="'CheckBox-FontData'" />

    <div class="Common-Strech">
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyStyles" >
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
        </xsl:call-template>
        <xsl:call-template name="tplApplyPaddings"/>
        overflow:hidden;
      </xsl:attribute>

      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmTextClass" select="$prmFontDataClass"/>
      </xsl:call-template>
    </div>
  </xsl:template>

  <xsl:template match="WC:Tags.CheckBox[@Attr.Appearance='1']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawCheckBoxInButtonAppereanceCenterContentAPI"/>
  </xsl:template>

  <!-- Disable background image in button appearance (will be drawn during button drawing)-->
  <xsl:template match="WC:Tags.CheckBox[@Attr.Appearance='1']" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
