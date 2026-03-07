<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!-- The default style DockManager match template -->
  <xsl:template match="WC:Tags.DockingZone" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawZoneAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.DockingZone" mode="modScrollbars">
    <xsl:param name="prmContainerElementID" select="@Attr.Id" />
    <xsl:param name="prmScrollbars" select="@Attr.Scrollbars" />
    <xsl:param name="prmArrowsBaseClass" select="'Zone-ArrowsClass'" />
    <xsl:param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
    <xsl:param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
    <xsl:param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
    <xsl:param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
    <xsl:param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
    <xsl:param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
    <xsl:param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
    <xsl:param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />

    <xsl:call-template name="tplDrawScrollbars">
      <xsl:with-param name="prmContainerElementID" select="$prmContainerElementID" />
      <xsl:with-param name="prmScrollbars" select="$prmScrollbars" />
      <xsl:with-param name="prmArrowsBaseClass" select="$prmArrowsBaseClass" />
      <xsl:with-param name="prmTopArrowThickness" select="$prmTopArrowThickness" />
      <xsl:with-param name="prmRightArrowThickness" select="$prmRightArrowThickness" />
      <xsl:with-param name="prmBottomArrowThickness" select="$prmBottomArrowThickness" />
      <xsl:with-param name="prmLeftArrowThickness" select="$prmLeftArrowThickness" />
      <xsl:with-param name="prmHorizontalHoverSpeed" select="$prmHorizontalHoverSpeed" />
      <xsl:with-param name="prmHorizontalDownSpeed" select="$prmHorizontalDownSpeed" />
      <xsl:with-param name="prmVerticalHoverSpeed" select="$prmVerticalHoverSpeed" />
      <xsl:with-param name="prmVerticalDownSpeed" select="$prmVerticalDownSpeed" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.DockingZone" mode="modDragEnter">
    <xsl:call-template name="tplDrawZoneIndicators" />
  </xsl:template>

  <xsl:template match="WC:Tags.DockingZone" mode="modAlignedContentContainerElementAttributes">
    <xsl:attribute name="data-vwgDragMoveHandler">mobjApp.Zone_ResetIndicators</xsl:attribute>
  </xsl:template>
  
  <xsl:template match="WC:Tags.DockingZone" mode="modAlignedContent">
    <xsl:variable name="varId" select="@Attr.Id" />
    
    <xsl:variable name="varLeftRelation">
      <xsl:choose>
        <xsl:when test="not($ltr='LTR')">
          2
        </xsl:when>
        <xsl:otherwise>
          3
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <xsl:variable name="varRightRelation">
      <xsl:choose>
        <xsl:when test="not($ltr='LTR')">
          3
        </xsl:when>
        <xsl:otherwise>
          2
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <table data-vwgDragMoveHandler="mobjApp.Zone_ResetIndicators" class="Common-CellSpacing0 Common-CellPadding0" data-vwgZoneIndicatorsContainer="true">
      <colgroup>
        <col class="Zone-LeftColumn" />
        <col class="Zone-MiddleColumn" />
        <col class="Zone-RightColumn" />
      </colgroup>
      <tr class="Zone-TopRowHeight" >
        <td data-vwgDragMoveHandler="mobjApp.Zone_ResetIndicators">
        </td>
        <td>
          <div data-vwgOwnerId="{$varId}" data-vwgRelation="0" data-vwgDragDropHandler="mobjApp.Zone_DockDrop" data-vwgDragMoveHandler="mobjApp.Zone_DockHover" class="Zone-TopIndicator"></div>
        </td>
        <td data-vwgDragMoveHandler="mobjApp.Zone_ResetIndicators">
        </td>
      </tr>
      <tr class="Zone-MiddleRowHeight">
        <td>
          <div data-vwgOwnerId="{$varId}" data-vwgRelation="{$varLeftRelation}" data-vwgDragDropHandler="mobjApp.Zone_DockDrop" data-vwgDragMoveHandler="mobjApp.Zone_DockHover" class="Zone-LeftIndicator"></div>
        </td>
        <td>
          <div data-vwgOwnerId="{$varId}" data-vwgRelation="4" data-vwgDragDropHandler="mobjApp.Zone_DockDrop" data-vwgDragMoveHandler="mobjApp.Zone_DockHover" class="Zone-CenterIndicator"></div>
        </td>
        <td>
          <div data-vwgOwnerId="{$varId}" data-vwgRelation="{$varRightRelation}" data-vwgDragDropHandler="mobjApp.Zone_DockDrop" data-vwgDragMoveHandler="mobjApp.Zone_DockHover" class="Zone-RightIndicator"></div>
        </td>
      </tr>
      <tr class="Zone-BottomRowHeight">
        <td data-vwgDragMoveHandler="mobjApp.Zone_ResetIndicators">
        </td>
        <td>
          <div data-vwgOwnerId="{$varId}" data-vwgRelation="1" data-vwgDragDropHandler="mobjApp.Zone_DockDrop" data-vwgDragMoveHandler="mobjApp.Zone_DockHover" class="Zone-BottomIndicator"></div>
        </td>
        <td data-vwgDragMoveHandler="mobjApp.Zone_ResetIndicators">
        </td>
      </tr>
    </table>
  </xsl:template>

  <xsl:template name="tplDrawZoneIndicators">
    <div data-vwgDragMoveHandler="mobjApp.Zone_ResetIndicators" style="width:100%;height:100%;position:relative;">
      <xsl:call-template name="tplCenterContent">
        <xsl:with-param name="prmIsHorizontalAligned" select="1" />
        <xsl:with-param name="prmIsVerticalAligned" select="1" />
        <xsl:with-param name="prmRectHeight" select="[Skin.TotalHeight]" />
        <xsl:with-param name="prmRectWidth" select="[Skin.TotalWidth]" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawZoneAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawContained">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplCenterContent">
    <xsl:param name="prmIsVerticalAligned" select="0" />
    <xsl:param name="prmIsHorizontalAligned" select="0" />
    <xsl:param name="prmRectWidth" select="0" />
    <xsl:param name="prmRectHeight" select="0" />
    <div>
      <xsl:attribute name="style">width:100%;height:100%;<xsl:if test="$prmIsVerticalAligned='1'">display:table;</xsl:if></xsl:attribute>
      <div>
        <xsl:attribute name="style">width:100%;height:100%;position:relative;<xsl:if test="$prmIsVerticalAligned='1'">display:table-cell;vertical-align:middle;</xsl:if></xsl:attribute>
        <xsl:apply-templates select="." mode="modAlignedContentContainerElementAttributes" />
        <div>
          <xsl:attribute name="style">width:<xsl:value-of select="$prmRectWidth" />px;height:<xsl:value-of select="$prmRectHeight" />px;<xsl:if test="$prmIsHorizontalAligned='1'">margin:auto</xsl:if></xsl:attribute>
          <xsl:apply-templates select="." mode="modAlignedContent" />
        </div>
      </div>
    </div>
  </xsl:template>

</xsl:stylesheet>
