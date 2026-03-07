<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">
  <!-- Details Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawDetailsAPI" >
      <xsl:with-param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:with-param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:with-param name="prmListViewHeaderCellClass" select="'ListView-HeaderCell'" />
      <xsl:with-param name="prmListViewHeaderCell_EnterClass" select="'ListView-HeaderCell_Enter'" />
      <xsl:with-param name="prmListViewHeaderCell_DownClass" select="'ListView-HeaderCell_Down'" />
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="'ListView-HeaderSeperator'" />
      <xsl:with-param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:with-param name="prmListViewSortedColumnClass" select="'ListView-SortedColumn'" />
      <xsl:with-param name="prmListViewDataRowClass" select="'ListView-DataRow'" />
      <xsl:with-param name="prmListViewDataFullRowClass" select="'ListView-DataFullRow'"/>
      <xsl:with-param name="prmListViewDataRow0Class" select="'ListView-DataRow0'" />
      <xsl:with-param name="prmListViewDataRow1Class" select="'ListView-DataRow1'" />
      <xsl:with-param name="prmListViewCellClass" select="'ListView-Cell'" />
      <xsl:with-param name="prmListViewItemCellClass" select="'ListView-ItemCell'" />
      <xsl:with-param name="prmListViewDataCellClass" select="'ListView-DataCell'" />
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
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- List Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='List' and @Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawListAPI">
      <xsl:with-param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:with-param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:with-param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:with-param name="prmListViewListItem_SelectedClass" select="'ListView-ListItem_Selected'" />
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
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


  <!-- Small icons Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='SmallIcon' and @Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawSmallIconsAPI">
      <xsl:with-param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:with-param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:with-param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:with-param name="prmListViewListSmallItem_SelectedClass" select="'ListView-ListSmallItem_Selected'" />
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
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Large icons Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='LargeIcon' and @Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawLargeIconsAPI">
      <xsl:with-param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:with-param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:with-param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:with-param name="prmListViewListLargeItem_SelectedClass" select="'ListView-ListLargeItem_Selected'" />
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
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modListViewDetailedColumns">
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmColIdBase" />

    <xsl:call-template name="tplListViewDetailedColumnsAPI">
      <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
      <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modListViewDetailedHeader">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDetailedHeaderAPI">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="Tags.Group[../@Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modListViewGroupHeader">
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />

    <xsl:call-template name="tplDrawListGroupHeaderAPI" >
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="Tags.Row[../@Attr.CustomStyle='FileManagerFoldersListViewSkin']" mode="modListViewDetailedItemRow">
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewCellClass" />
    <xsl:param name="prmListViewItemCellClass" />
    <xsl:param name="prmListViewDataCellClass" />
    <xsl:param name="prmCheckBoxes"/>
    <xsl:param name="prmCols"/>
    <xsl:param name="prmIsFullRowSelect" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmRow" />
    <xsl:param name="prmIsEnabled" />
    <migration-write type="elements">
      <xsl:param name="prmColsByName" />      
    </migration-write>

    <xsl:call-template name="tplListViewDetailedItemRowAPI">
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
      <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
      <xsl:with-param name="prmListViewItemCellClass"  select="$prmListViewItemCellClass" />
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
      <xsl:with-param name="prmRow" select="$prmRow"/>
      <migration-write type="elements">
        <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
      </migration-write>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


</xsl:stylesheet>
