<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The default style RadioButton match template -->
  <xsl:template match="WC:Tags.RadioButton[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawRadioButtonAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawRadioButtonInButtonAppereanceAPI">
    <!--Template parameters-->
    <xsl:param name="prmId" select="@Attr.Id" />
    <xsl:param name="prmRadioButtonClass" select="'RadioButton-ButtonControl'"/>
    <xsl:param name="prmCheckedRadioButtonClass" select="'RadioButton-ButtonControlChecked'"/>
    <xsl:param name="prmLeftBottomClass" select="'RadioButton-BottomLeft'" />
    <xsl:param name="prmLeftClass" select="'RadioButton-Left'" />
    <xsl:param name="prmLeftTopClass" select="'RadioButton-TopLeft'" />
    <xsl:param name="prmTopClass" select="'RadioButton-Top'" />
    <xsl:param name="prmRightTopClass" select="'RadioButton-TopRight'" />
    <xsl:param name="prmRightClass" select="'RadioButton-Right'" />
    <xsl:param name="prmRightBottomClass" select="'RadioButton-BottomRight'" />
    <xsl:param name="prmBottomClass" select="'RadioButton-Bottom'" />
    <xsl:param name="prmFontDataClass" select="'RadioButton-FontData'" />
    <xsl:param name="prmCenterClass" select="'RadioButton-Center'" />
    <xsl:param name="prmCenterTransparentClass" select="'RadioButton-CenterTransparent'" />
    <xsl:param name="prmContentClass" select="'RadioButton-Content'" />
    <xsl:param name="prmClickHandler" select="concat('mobjApp.RadioButton_Click(',$prmId,',window);')"/>
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.RadioButton_KeyDown(',$prmId,',window,event);')"/>
    <xsl:param name="prmAfterNavKeyDownHandler" select="'RadioButton_AfterNavigationKeyDown'"/>
    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
    <xsl:param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmSupportStateStyle">1</xsl:param>

    <xsl:variable name="varChecked" select="@Attr.Checked"/>

    <!-- Apply button attributes -->
    <xsl:call-template name="tplApplyButtonAttributes" >
      <xsl:with-param name="prmButtonClass">
        <xsl:if test="$varChecked='1'"><xsl:value-of select="$prmCheckedRadioButtonClass"/></xsl:if>
        <xsl:if test="not($varChecked='1')"><xsl:value-of select="$prmRadioButtonClass"/></xsl:if>
      </xsl:with-param>
      <xsl:with-param name="prmClickHandler" select="$prmClickHandler"/>
      <xsl:with-param name="prmKeyDownHandler" select="$prmKeyDownHandler"/>
      <xsl:with-param name="prmAfterNavKeyDownHandler" select="$prmAfterNavKeyDownHandler"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmSupportStateStyle" select="$prmSupportStateStyle"/>
    </xsl:call-template>

    <!-- Draw radio button frame -->
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

  <!-- The button appereance RadioButton match template -->
  <xsl:template match="WC:Tags.RadioButton[@Attr.Appearance='1']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawRadioButtonInButtonAppereanceAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawRadioButtonInButtonAppereanceCenterContentAPI">
    <!--Template parameters-->
    <xsl:param name="prmFontDataClass" select="'RadioButton-FontData'" />

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

  <xsl:template match="WC:Tags.RadioButton[@Attr.Appearance='1']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawRadioButtonInButtonAppereanceCenterContentAPI"/>
  </xsl:template>

  <!-- Disable background image in button appearance (will be drawn during button drawing)-->
  <xsl:template match="WC:Tags.RadioButton[@Attr.Appearance='1']" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
    </xsl:call-template>
  </xsl:template>

  <!-- Main API for drawing the control -->
  <xsl:template name="tplDrawRadioButtonAPI">
    <xsl:param name="prmControlClass" select="'RadioButton-Control'"/>
    <xsl:param name="prmLabelClass" select="'RadioButton-Label'"/>
    <xsl:param name="prmCheckedRadioImage" select="'[Skin.CheckedRadioImage]'"/>
    <xsl:param name="prmUnCheckedRadioImage" select="'[Skin.UnCheckedRadioImage]'"/>
    <xsl:param name="prmStateImageHeight" select="[Skin.RadioImageHeight]" />
    <xsl:param name="prmStateImageWidth" select="[Skin.RadioImageWidth]" />

    <!-- Params for using the checkbox from other controls -->
    <xsl:param name="prmId" select="@Id" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawStateButtonContent" >
      <xsl:with-param name="prmControlClass" select="$prmControlClass" />
      <xsl:with-param name="prmLabelClass" select="$prmLabelClass" />
      <xsl:with-param name="prmCheckedImage" select="$prmCheckedRadioImage" />
      <xsl:with-param name="prmUnCheckedImage" select="$prmUnCheckedRadioImage" />
      <xsl:with-param name="prmId" select="$prmId" />
      <xsl:with-param name="prmStateImageHeight" select="$prmStateImageHeight" />
      <xsl:with-param name="prmStateImageWidth" select="$prmStateImageWidth" />

      <!-- Params for handlers -->
      <xsl:with-param name="prmOnClick">
        <xsl:value-of select="concat('mobjApp.RadioButton_Click(',$prmId,',window);')"/>
      </xsl:with-param>
      <xsl:with-param name="prmOnKeyDown">
        <xsl:value-of select="concat('mobjApp.RadioButton_KeyDown(',$prmId,',window,event);')"/>
      </xsl:with-param>
      <xsl:with-param name="prmOnTouchEnd">
        <xsl:value-of select="concat('mobjApp.RadioButton_TouchEnd(',$prmId,',window);')"/>
      </xsl:with-param>
      <xsl:with-param name="prmAfterNavKeyDown">
        <xsl:text>RadioButton_AfterNavigationKeyDown</xsl:text>
      </xsl:with-param>
      
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
  
