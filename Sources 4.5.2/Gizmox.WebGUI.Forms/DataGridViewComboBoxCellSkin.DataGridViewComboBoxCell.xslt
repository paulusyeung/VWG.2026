<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
	xmlns:WG="http://www.gizmox.com/webgui">

  <!--ComboBox-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='6']" mode="modCellContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varDataGridView" select="ancestor::WC:Tags.DataGridView[1]"/>
    <xsl:variable name="varGridId" select="$varDataGridView/@Attr.Id"/>
    <xsl:variable name="varId" select="concat($varGridId,'_',@Attr.MemberID)" />
    <xsl:variable name="varColumns" select="$varDataGridView/WG:Tags.DataGridViewColumn" />
    <xsl:variable name="varIsDataGridViewReadOnly" select="$varDataGridView/@Attr.ReadOnly" />
    <xsl:variable name="varIsRowReadOnly" select="../@Attr.ReadOnly" />
    <xsl:variable name="varValue" select="@Attr.Value"/>
    <xsl:variable name="varCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:variable name="varIsColumnReadOnly" select="$varColumns[position()=$varCellPosition]/@Attr.ReadOnly='1'" migration-select="varColumns.xposition(varCellPosition).attr(&quot;Attr.ReadOnly&quot;)=='1'" />
    <xsl:variable name="varControlInActive">
      <xsl:choose>
        <xsl:when test="(($varIsDataGridViewReadOnly='1' or $varIsColumnReadOnly='1' or $varIsRowReadOnly='1') and not(@Attr.ReadOnly='0')) or @Attr.ReadOnly='1'">1</xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:choose>
      <xsl:when test="@Attr.CustomDropDown='1'">
        <xsl:call-template name="tplDrawComboBoxAPI" >
          <!-- Params for using the ComboBox from other controls -->
          <xsl:with-param name="prmControlId" select="$varId" />
          <xsl:with-param name="prmControlClass" select="'ComboBox-Control'" />
          <xsl:with-param name="prmControlText" select="@Attr.FormattedText"  />
          <xsl:with-param name="prmControlReadOnly" select="$varControlInActive" />
          <xsl:with-param name="prmContentClass" select="'DataGridView-ComboboxInput'" />
          <xsl:with-param name="prmInputClass" select="'ComboBox-Input'" />
          <xsl:with-param name="prmInputContainerClass">
            <xsl:if test="@Attr.Style='S'">
              <xsl:value-of select="'ComboBox-InputContainer'"/>
            </xsl:if>
          </xsl:with-param>
          <xsl:with-param name="prmDataContainerDropDownMode" select="'ComboBox-DataContainerDropDownMode'" />
          <xsl:with-param name="prmDataContainerDropDownListMode" select="'ComboBox-DataContainerDropDownListMode'" />
          <xsl:with-param name="prmDataContainerSimpleMode" select="'ComboBox-DataContainerSimpleMode'" />
          <xsl:with-param name="prmItemsContainer" select="'ComboBox-ItemsContainer'" />
          <xsl:with-param name="prmInputHeight" select="[Skin.SimpleComboBoxInputHeight]" />
          <xsl:with-param name="prmButtonClass" select="'ComboBox-Button'" />
          <xsl:with-param name="prmButtonContainerClass" select="'ComboBox-ButtonContainer'" />
          <xsl:with-param name="prmButtonWidth" select="[Skin.DropDownImageWidth]" />
          <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
          <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <!--Try fetching options localy-->
        <xsl:if test="Tags.Options">
          <xsl:call-template name="tplDrawComboBoxAPI" >
            <xsl:with-param name="prmControlId" select="$varId" />
            <xsl:with-param name="prmControlClass" select="'ComboBox-Control'" />
            <xsl:with-param name="prmControlText" select="@Attr.FormattedText" />
            <xsl:with-param name="prmControlReadOnly" select="$varControlInActive" />
            <xsl:with-param name="prmContentClass" select="'DataGridView-ComboboxInput'" />
            <xsl:with-param name="prmInputClass" select="'ComboBox-Input'" />
            <xsl:with-param name="prmInputContainerClass">
              <xsl:if test="@Attr.Style='S'">
                <xsl:value-of select="'ComboBox-InputContainer'"/>
              </xsl:if>
            </xsl:with-param>
            <xsl:with-param name="prmInputHeight" select="[Skin.SimpleComboBoxInputHeight]" />
            <xsl:with-param name="prmButtonClass" select="'ComboBox-Button'" />
            <xsl:with-param name="prmButtonContainerClass" select="'ComboBox-ButtonContainer'" />
            <xsl:with-param name="prmButtonWidth" select="[Skin.DropDownImageWidth]" />
            <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
            <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </xsl:if>

        <!--Try fetching options from containing column-->
        <xsl:if test="not(Tags.Options)">
          <xsl:variable name="varOptionsColumnId" select="substring-after(@Attr.OptionsComponent,'_')"/>
          <xsl:variable name="varOptions" select="$varDataGridView/WG:Tags.DataGridViewColumn[@Attr.MemberID=$varOptionsColumnId]/Tags.Options" migration-select="varDataGridView.xpath(&quot;WG:Tags.DataGridViewColumn[@Attr.MemberID='&quot;+varOptionsColumnId+&quot;']/Tags.Options&quot;)" />

          <xsl:call-template name="tplDrawComboBoxAPI" >
            <xsl:with-param name="prmControlId" select="$varId" />
            <xsl:with-param name="prmControlClass" select="'ComboBox-Control'" />
            <xsl:with-param name="prmControlText" select="@Attr.FormattedText" />
            <xsl:with-param name="prmControlReadOnly" select="$varControlInActive" />
            <xsl:with-param name="prmContentClass" select="'DataGridView-ComboboxInput'" />
            <xsl:with-param name="prmInputClass" select="'ComboBox-Input'" />
            <xsl:with-param name="prmInputContainerClass">
              <xsl:if test="@Attr.Style='S'">
                <xsl:value-of select="'ComboBox-InputContainer'"/>
              </xsl:if>
            </xsl:with-param>
            <xsl:with-param name="prmInputHeight" select="[Skin.SimpleComboBoxInputHeight]" />
            <xsl:with-param name="prmButtonClass" select="'ComboBox-Button'" />
            <xsl:with-param name="prmButtonContainerClass" select="'ComboBox-ButtonContainer'" />
            <xsl:with-param name="prmButtonWidth" select="[Skin.DropDownImageWidth]" />
            <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
            <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>

  </xsl:template>


  <!--Match for applying input's attributes-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='6']" mode="modApplyAttributes">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmValue" />
    <xsl:param name="prmControlReadOnly" />

    <xsl:call-template name="tplApplyComboBoxAttributesAPI">
      <xsl:with-param name="prmControlId" select="$prmControlId"/>
      <xsl:with-param name="prmValue" select="$prmValue"/>
      <xsl:with-param name="prmControlReadOnly" select="$prmControlReadOnly"/>
    </xsl:call-template>
  </xsl:template>

  <!--ComboBox popup items match (the items renders under a data grid view cell node) -->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='6']/Tags.Options">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawOptionsAPI" >
      <xsl:with-param name="prmLeftBottomClass" select="'ComboBox-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'ComboBox-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'ComboBox-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'ComboBox-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'ComboBox-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'ComboBox-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'ComboBox-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'ComboBox-Bottom'" />
      <xsl:with-param name="prmCenterClass" select="'ComboBox-Center'" />
      
      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftPopupWindowFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightPopupWindowFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopPopupWindowFrameHeight]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomPopupWindowFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--ComboBox popup items match (the items renders under a combobox column node) -->
  <xsl:template match="WG:Tags.DataGridViewColumn[@Attr.Type='6']/Tags.Options">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawOptionsAPI" >
      <xsl:with-param name="prmLeftBottomClass" select="'ComboBox-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'ComboBox-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'ComboBox-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'ComboBox-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'ComboBox-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'ComboBox-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'ComboBox-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'ComboBox-Bottom'" />
      <xsl:with-param name="prmCenterClass" select="'ComboBox-Center'" />
      
      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftPopupWindowFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightPopupWindowFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopPopupWindowFrameHeight]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomPopupWindowFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--ComboBox content popup items match (the items renders under a data grid view cell node) -->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='6']/Tags.Options" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCenterContentOptionsAPI" >
      <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
      <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--ComboBox content popup items match (the items renders under a combobox column node) -->
  <xsl:template match="WG:Tags.DataGridViewColumn[@Attr.Type='6']/Tags.Options" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCenterContentOptionsAPI" >
      <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
