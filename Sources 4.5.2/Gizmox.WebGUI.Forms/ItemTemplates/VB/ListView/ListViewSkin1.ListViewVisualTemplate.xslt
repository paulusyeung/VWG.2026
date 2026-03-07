<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and @Attr.Appearance='ListViewVisualTemplate' and @Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDrawDetailsAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- BODY RENDER -->
  <!-- Main body for the items for the appearance -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailsTableBodyRowRender">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewDataRowClass" />
    <xsl:param name="prmListViewDataFullRowClass" />
    <xsl:param name="prmListViewDataRow0Class" />
    <xsl:param name="prmListViewDataRow1Class" />
    <xsl:param name="prmListViewCellClass" />
    <xsl:param name="prmListViewItemCellClass" />
    <xsl:param name="prmListViewDataCellClass" />

    <xsl:param name="prmCols" />
    <xsl:param name="prmRows" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDetailsTableBodyRenderAPI">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
      <xsl:with-param name="prmListViewDataRowClass" select="$prmListViewDataRowClass"/>
      <xsl:with-param name="prmListViewDataFullRowClass" select="$prmListViewDataFullRowClass"/>
      <xsl:with-param name="prmListViewDataRow0Class" select="$prmListViewDataRow0Class"/>
      <xsl:with-param name="prmListViewDataRow1Class" select="$prmListViewDataRow1Class"/>
      <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass"/>
      <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass"/>
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>

      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmRows" select="$prmRows"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <!-- Single row render for the appearance - This will call the specific behavior related to the appearance -->
  <xsl:template match="Tags.Row[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedItemRow">
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


    <xsl:apply-templates select="." mode="modListViewDetailedItemRowVisualTemplate">
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
      <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
      <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
      <xsl:with-param name="prmRow" select="$prmRow"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <migration-write type="elements">
        <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
      </migration-write>
    </xsl:apply-templates>
  </xsl:template>

  <!-- COLUMNS RENDER -->
  <!-- Base column render for regular list -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedColumns">
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmColIdBase" />
    <xsl:param name="prmIsHeader" />

    <xsl:apply-templates select="." mode="modListViewDetailedColumnsVisualTemplate">
      <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
      <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
      <xsl:with-param name="prmIsHeader" select="$prmIsHeader" />
    </xsl:apply-templates>
  </xsl:template>

  <!-- Original column order render for the appearance -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='None' and not(@Attr.VisualTemplateListViewNewColumnOrder) and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedColumnsVisualTemplate">
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmColIdBase" />
    <xsl:param name="prmIsHeader" />

    <xsl:call-template name="tplListViewDetailedColumnsAPI">
      <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
      <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
      <xsl:with-param name="prmIsHeader" select="$prmIsHeader" />
    </xsl:call-template>
  </xsl:template>

  <!-- New column order render for the appearance -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='None' and (string-length(@Attr.VisualTemplateListViewNewColumnOrder) &gt; 0) and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedColumnsVisualTemplate">
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmColIdBase" />
    <xsl:param name="prmIsHeader" />

    <xsl:call-template name="tplListViewVisualTemplateDetailedColumnsAPI">
      <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
      <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
      <xsl:with-param name="prmIsHeader" select="$prmIsHeader" />
    </xsl:call-template>
  </xsl:template>

  <!-- Column render when row template exists -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='ContactList' and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedColumnsVisualTemplate">
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmColIdBase" />

    <xsl:call-template name="tplListViewDetailedColumnsVisualTemplate_ContactList">
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
    </xsl:call-template>
  </xsl:template>

  <!-- HEADER RENDER -->
  <!-- General header matcher -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedHeader">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />

    <xsl:apply-templates select="." mode="modListViewDetailedHeaderVisualTemplate">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
    </xsl:apply-templates>
  </xsl:template>
  
  <!-- This match goes to the main ListView header render -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='None' and not(@Attr.VisualTemplateListViewNewColumnOrder) and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedHeaderVisualTemplate">
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
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
    </xsl:call-template>
  </xsl:template>

  <!-- This match goes to the visual appearnce ListView header render when there is no RowStyle -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='None' and (string-length(@Attr.VisualTemplateListViewNewColumnOrder) &gt; 0) and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedHeaderVisualTemplate">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewVisualTemplateDetailedHeaderAPI">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
    </xsl:call-template>
  </xsl:template>

  <!-- This match goes to the visual appearnce ListView header render when there is RowStyle -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='ContactList' and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedHeaderVisualTemplate">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDetailedHeaderVisualTemplate_ContactList">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
    </xsl:call-template>
  </xsl:template>
  
  <!-- GROUP RENDER -->
  <xsl:template match="Tags.Group[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewGroupHeader">
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />

    <xsl:apply-templates select="." mode="modListViewDetailedGroupRowVisualTemplate">
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
    </xsl:apply-templates>
  </xsl:template>

  
  <xsl:template match="Tags.Group[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.VisualTemplateListViewItemRowTemplate='None' and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedGroupRowVisualTemplate">
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />

    <xsl:call-template name="tplDrawListGroupHeaderAPI" >
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
    </xsl:call-template>
  </xsl:template>


  <xsl:template match="Tags.Group[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.VisualTemplateListViewItemRowTemplate='ContactList' and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedGroupRowVisualTemplate">
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />

    <xsl:call-template name="tplListViewDetailedGroupRowVisualTemplate_ContactList">
      <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
    </xsl:call-template>
  </xsl:template>


  <!-- SINGLE ROW RENDER-->
  <!-- Math will happen when no row template was supplied and the rows are in the original order -->
  <xsl:template match="Tags.Row[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.VisualTemplateListViewItemRowTemplate='None' and not(../@Attr.VisualTemplateListViewNewColumnOrder) and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedItemRowVisualTemplate">
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
      <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
      <xsl:with-param name="prmRow" select="$prmRow"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <migration-write type="elements">
        <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
      </migration-write>
    </xsl:call-template>
  </xsl:template>

  <!-- Math will happen when no row template was supplied and the rows are in a new order -->
  <xsl:template match="Tags.Row[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.VisualTemplateListViewItemRowTemplate='None' and (string-length(../@Attr.VisualTemplateListViewNewColumnOrder) &gt; 0) and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedItemRowVisualTemplate">
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

    <xsl:call-template name="tplListViewVisualTemplateDetailedItemRowAPI">
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
      <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
      <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
      <xsl:with-param name="prmRow" select="$prmRow"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <migration-write type="elements">
        <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
      </migration-write>
    </xsl:call-template>
  </xsl:template>

  <!-- Math will happen when 'CONTACTLIST' row template is requested -->
  <xsl:template match="Tags.Row[../@Attr.Appearance='ListViewVisualTemplate' and ../@Attr.VisualTemplateListViewItemRowTemplate='ContactList' and ../@Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedItemRowVisualTemplate">
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

    <xsl:call-template name="tplListViewDetailedItemRowVisualTemplate_ContactList">
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
      <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
      <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
      <xsl:with-param name="prmHeight" select="$prmHeight"/>
      <xsl:with-param name="prmRow" select="$prmRow"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <migration-write type="elements">
        <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
      </migration-write>
    </xsl:call-template>
  </xsl:template>

  <!-- Match to get the number of columns created when 'CONTACTLIST' row template is requested -->
  <xsl:template match="WC:Tags.ListView[@Attr.Appearance='ListViewVisualTemplate' and @Attr.VisualTemplateListViewItemRowTemplate='ContactList' and @Attr.CustomStyle='$safeitemname$']" mode="modListViewDetailedItemRowColumnsNumberVisualTemplate">
    <xsl:param name="prmCheckBoxes"/>

    <xsl:call-template name="tplListViewDetailedItemRowColumnsNumberVisualTemplate_ContactList">
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>