<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style ListView match template -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.CustomStyle='ContactsListViewSkin']" mode="modContent">
    <xsl:call-template name="tplListViewDrawDetailsAPI">
      <xsl:with-param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:with-param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:with-param name="prmListViewHeaderCellClass" select="'ListView-HeaderCell'" />
      <xsl:with-param name="prmListViewHeaderCell_EnterClass" select="'ListView-HeaderCell_Enter'" />
      <xsl:with-param name="prmListViewHeaderCell_DownClass" select="'ListView-HeaderCell_Down'" />
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="'ListView-HeaderSeperator'" />
      <xsl:with-param name="prmListViewFontGroupHeaderLabelClass" select="'ListView-FontGroupHeaderLabel'" />
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:with-param name="prmListViewSortedColumnClass" select="'ListView-SortedColumn'" />
      <xsl:with-param name="prmListViewDataRowClass" select="'ListView-DataRow'" />
      <xsl:with-param name="prmListViewDataRow0Class" select="'ListView-DataRow0'" />
      <xsl:with-param name="prmListViewDataRow1Class" select="'ListView-DataRow1'" />
      <xsl:with-param name="prmListViewDataCell_SelectedClass" select="'ListView-DataCell_Selected'" />
      <xsl:with-param name="prmListViewGridLinesClass" select="'ListView-GridLines'" />
      <xsl:with-param name="prmListViewColumnSeperatorClass" select="'ListView-ColumnSeperator'" />
      <xsl:with-param name="prmListViewPagingPanelHeightClass" select="'ListView-PagingPanelHeight'" />
      <xsl:with-param name="prmListViewPagingPanelStyleClass" select="'ListView-PagingPanelStyle'" />
      <xsl:with-param name="prmListViewPagingFirstImageWidthClass" select="'ListView-PagingFirstImageWidth'" />
      <xsl:with-param name="prmListViewPagingLastImageWidthClass" select="'ListView-PagingLastImageWidth'" />
      <xsl:with-param name="prmListViewPagingPreviousImageWidthClass" select="'ListView-PagingPreviousImageWidth'" />
      <xsl:with-param name="prmListViewPagingNextImageWidthClass" select="'ListView-PagingNextImageWidth'" />
      <xsl:with-param name="prmListViewPagingStatusBoxClass" select="'ListView-PagingStatusBox'" />
      <xsl:with-param name="prmListViewPagingLastButtonStyleClass" select="'ListView-PagingLastButtonStyle'" />
      <xsl:with-param name="prmListViewPagingFirstButtonStyleClass" select="'ListView-PagingFirstButtonStyle'" />
      <xsl:with-param name="prmListViewPagingNextButtonStyleClass" select="'ListView-PagingNextButtonStyle'" />
      <xsl:with-param name="prmListViewPagingPrevButtonStyleClass" select="'ListView-PagingPrevButtonStyle'" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.CustomStyle='ContactsListViewSkin']" mode="modListViewDetailedColumns">
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmColIdBase" />

    <xsl:if test="$prmCheckBoxes='1'">
      <col width="22px" class="ListView-Column"/>
    </xsl:if>
    <col id="{$prmColIdBase}_{@Id}" width="100%">
      <xsl:attribute name="class">
        ListView-Column
      </xsl:attribute>
    </col>
  </xsl:template>

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.CustomStyle='ContactsListViewSkin']" mode="modListViewDetailedHeader">
    
  </xsl:template>

  <xsl:template match="Tags.Row[../@Attr.View='Details' and ../@Attr.CustomStyle='ContactsListViewSkin']" mode="modListViewDetailedItemRow">
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewDataCell_SelectedClass" />
    
    <xsl:param name="prmCheckBoxes"/>
    <xsl:param name="prmCols"/>
    <xsl:param name="prmIsFullRowSelect" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmRow" />
    <td>
      <xsl:call-template name="tplApplyListViewItemClickEvents">
        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmCheckOnDoubleClick" select="../@Attr.CheckOnDoubleClick"/>
        <xsl:with-param name="prmListViewId" select="../@Id"/>
        <xsl:with-param name="prmListViewItemId" select="@Id"/>
      </xsl:call-template>
      <xsl:choose>
        <xsl:when test="@Attr.Selected='1' and $prmIsFullRowSelect">
          <xsl:attribute name="class">ListView-Cell ListView-DataCell {$prmListViewDataCell_SelectedClass}</xsl:attribute>
        </xsl:when>
        <xsl:otherwise>
          <xsl:attribute name="class">ListView-Cell ListView-DataCell</xsl:attribute>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:call-template name="tplApplyDetailedCellStyle" >
        <xsl:with-param name="prmRow" select="." />
      </xsl:call-template>

      <div class="ListView-MailWrapper">
        <xsl:attribute name="style">          
          <xsl:if test="@Attr.IdentCount">
            <xsl:choose>
              <xsl:when test="contains(../@Attr.TextAlign,'Left') or not(../@Attr.TextAlign)">
                padding-<xsl:value-of select="$left"/>:
              </xsl:when>
              <xsl:when test="contains(../@Attr.TextAlign,'Right')">
                padding-<xsl:value-of select="$right"/>:
              </xsl:when>
            </xsl:choose><xsl:value-of select="@Attr.IdentCount * 20" />px;
          </xsl:if>
        </xsl:attribute>
        
        <div class="ListView-MailListingHeader">
          <div class="ListView-MailFrom">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="@c0"/>
            </xsl:call-template>
          </div>
          <div class="ListView-MailDate">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="@c1"/>
            </xsl:call-template>
          </div>
        </div>
        <div>
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="@c2"/>
          </xsl:call-template>
        </div>
        <div class="ListView-MailExcerpt">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="@c3"/>
          </xsl:call-template>
        </div>
      </div>

    </td>

  </xsl:template>
</xsl:stylesheet>
