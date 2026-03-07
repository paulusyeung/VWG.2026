<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and not(@Attr.CustomStyle)]" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />
    
    <xsl:call-template name="tplListViewDrawDetailsAPI" >
      <xsl:with-param name="prmAutoSizeMode" select="'1'"/>
      <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
    
  <!-- Details Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawDetailsAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- List Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='List' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawListAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


  <!-- Small icons Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='SmallIcon' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawSmallIconsAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Large icons Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='LargeIcon' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplListViewDrawLargeIconsAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Drag and drop templates-->
  <xsl:template match="Tags.Row[../@Attr.View='Details']" mode="modDragged">
    <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'"/>
    <xsl:param name="prmIsEnabled" />
    <div>
      <xsl:call-template name="tplSetToolTip" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <span class="nobr">
        <xsl:if test="@Attr.Image">
          <img class="Common-VAlignMiddle Common-Icon16X16" src="{@Attr.Image}" alt=""/>
        </xsl:if>
        <span class="{$prmListViewFontDataClass}" style="vertical-align:middle;">
          <xsl:text>&#160;</xsl:text>
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="SI[@COL='0']/@c" />
          </xsl:call-template>
        </span>
      </span>
    </div>
  </xsl:template>
  
  <!--Rows templates--> 
  <xsl:template name="tplListViewDrawDetailsRows">
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
    <xsl:param name="prmListViewGridLinesClass" />
    
    <xsl:param name="prmCols" />
    <xsl:param name="prmRows" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmIsEnabled" />

    
    <migration-write type="elements">
      <xsl:variable name="prmColsByName" select="1" migration-select="prmCols.attrhash(&quot;Attr.Name&quot;)" />
    </migration-write>
    <xsl:if test="not (@Attr.Scrollbars)">
      <xsl:call-template name="tplCompleteScrollCapabilities">
        <xsl:with-param name="prmScrollMoveHandler">function(){mobjApp.ListView_iScrollSyncScrollers('<xsl:value-of  select="@Attr.Id" />')}</xsl:with-param>
      </xsl:call-template>
    </xsl:if>
    <div dir="{$dir}" id="VWGLVBODY_{@Id}" data-vwgfocuselement="1" tabindex="-1">
      <xsl:attribute name="onresize">mobjApp.Web_SyncScrollSchedule(this,mobjApp.Web_GetElementById('HEADER_<xsl:value-of select="@Id" />',window),1,'<xsl:value-of select="$dir" />');<xsl:if test="$prmGridLines='1' and @Attr.ListViewShowGridLinesOnEmptyRows='1'">mobjApp.ListView_AddEmptyGridLineRows(window,'<xsl:value-of select="@Id" />',<xsl:value-of select="@Attr.ItemHeight" />);</xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplApplyScrollableAttributes">
        <xsl:with-param name="prmCustomScrollingHandler" select="concat('mobjApp.Web_SyncScroll(this,mobjApp.Web_GetElementById(&quot;HEADER_',@Id,'&quot;,window),1,&quot;',$dir,'&quot;)')"/>
      </xsl:call-template>
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
      </xsl:if>
      <xsl:attribute name="style">
        width:100%;height:100%;
        <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
        <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplRestoreScroll" />
      <xsl:if test="$prmGridLines='1' and @Attr.ListViewShowGridLinesOnEmptyRows='1'">
        <xsl:call-template name="tplCallMethod">
          <xsl:with-param name="prmMethod">mobjApp.ListView_AddEmptyGridLineRows(window,'<xsl:value-of select="@Id" />',<xsl:value-of select="@Attr.ItemHeight" />);</xsl:with-param> 
        </xsl:call-template>
      </xsl:if>
      <table style="table-layout:fixed;width:100%;" >
        <xsl:attribute name="class">Common-CellPadding0 Common-CellSpacing0 <xsl:if test="@Attr.GridLines='1'"><xsl:value-of select="$prmListViewGridLinesClass"/></xsl:if></xsl:attribute>
        <xsl:apply-templates select="." mode="modListViewDetailedColumns" >
          <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes" />
          <xsl:with-param name="prmCols" select="$prmCols" />
          <xsl:with-param name="prmColIdBase" select="'COL2'" />
          <xsl:with-param name="prmIsHeader" select="'0'" />
        </xsl:apply-templates>
       
        <xsl:choose>
          <xsl:when test="(count($prmRows) &gt; 0)">
            <xsl:apply-templates select="." mode="modListViewDetailsTableBodyRowRender" >
              <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
              <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
              <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
              <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
              <xsl:with-param name="prmListViewDataRowClass" select="$prmListViewDataRowClass"/>
              <xsl:with-param name="prmListViewDataFullRowClass" select="$prmListViewDataFullRowClass"/>
              <xsl:with-param name="prmListViewDataRow0Class" select="$prmListViewDataRow0Class"/>
              <xsl:with-param name="prmListViewDataRow1Class" select="$prmListViewDataRow1Class"/>
              <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
              <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
              <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>

              <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
              <xsl:with-param name="prmCols" select="$prmCols"/>
              <xsl:with-param name="prmRows" select="$prmRows"/>             
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />            
            </xsl:apply-templates>            
          </xsl:when>
          <xsl:when test="not(@Attr.GridLines='1')">
            <!-- We add an empty row when there are no items so the horizontal scroll will be visible -->
            <tr>
              <!-- for each item in prmCols we render 2 TDs (like where we draw the cols definition -->
              <xsl:for-each select="$prmCols">
                <td><div>&#160;</div></td><td><div>&#160;</div></td>
              </xsl:for-each>
              <!-- If there are checkboxes, render 2 more TDs-->
              <xsl:if test="$prmCheckBoxes='1'">
                <td><div>&#160;</div></td><td><div>&#160;</div></td>
              </xsl:if>
              <!-- There is always 1 col rendered no matter if there are no checkboxes or no prmCols, so this TD is for it-->
              <td><div>&#160;</div></td>
            </tr>
          </xsl:when>
        </xsl:choose>
      </table>
    </div>
  </xsl:template>

  <!-- This match is for body prerender -->
  <xsl:template match="WC:Tags.ListView[not(@Attr.Appearance)]" mode="modListViewDetailsTableBodyRowRender">
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

    <xsl:call-template name="tplListViewDetailsTableBodyRowRenderAPI">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
      <xsl:with-param name="prmListViewDataRowClass" select="$prmListViewDataRowClass"/>
      <xsl:with-param name="prmListViewDataFullRowClass" select="$prmListViewDataFullRowClass"/>
      <xsl:with-param name="prmListViewDataRow0Class" select="$prmListViewDataRow0Class"/>
      <xsl:with-param name="prmListViewDataRow1Class" select="$prmListViewDataRow1Class"/>
      <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
      <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
      <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>

      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmRows" select="$prmRows" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>   
  </xsl:template>

  <xsl:template name="tplListViewDetailsTableBodyRowRenderAPI">
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

    <migration-write migration-reason="Variable to count only LV rows.">
      var intRowIndex = 0; // Counter of current row index.
    </migration-write>
    <xsl:for-each select="$prmRows">
      <xsl:call-template name="tplDrawDetailsRow">
        <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
        <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
        <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
        <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
        <xsl:with-param name="prmListViewDataRowClass" select="$prmListViewDataRowClass"/>
        <xsl:with-param name="prmListViewDataFullRowClass" select="$prmListViewDataFullRowClass"/>
        <xsl:with-param name="prmListViewDataRow0Class" select="$prmListViewDataRow0Class"/>
        <xsl:with-param name="prmListViewDataRow1Class" select="$prmListViewDataRow1Class"/>
        <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
        <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
        <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>

        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmCols" select="$prmCols"/>
        <migration-write type="elements">
          <xsl:with-param name="prmColsByName" select="$prmColsByName" />
          <xsl:with-param name="prmRowIndex" migration-select="intRowIndex" />
        </migration-write>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <migration-write>
        intRowIndex += (this.xname()=="Tags.Row" ? 1: 0); // Increase index if the element is a row.
      </migration-write>
    </xsl:for-each>
  </xsl:template>


  <xsl:template name="tplListViewDrawListRows">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewListItem_SelectedClass" />

    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varHeight" select="@Attr.ItemHeight"/>

    <xsl:for-each select="Tags.Row | Tags.Group">
      <xsl:if test="name()='Tags.Group'">
        <div style="clear:both;" class="{$prmListViewGroupHeaderClass}">
          <xsl:apply-templates select="." mode="modListViewGroupHeader" >
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
          </xsl:apply-templates>
        </div>
      </xsl:if>
      <xsl:if test="not(name()='Tags.Group')">
        <xsl:call-template name="tplListViewDrawListRow">
          <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
          <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
          <xsl:with-param name="prmListViewListItem_SelectedClass" select="$prmListViewListItem_SelectedClass" />
          <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        </xsl:call-template>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="Tags.Row[../@Attr.View='List' and not(../@Attr.CustomStyle)]">
    <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
    <xsl:param name="prmListViewCheckBoxImageClass"  select="'ListView-CheckBoxImage'" />
    <xsl:param name="prmListViewListItem_SelectedClass" select="'ListView-ListItem_Selected'" />
    <xsl:param name="prmCheckBoxes" select="../@Attr.CheckBoxes"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDrawListRow">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
      <xsl:with-param name="prmListViewListItem_SelectedClass" select="$prmListViewListItem_SelectedClass" />
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplListViewDrawListRow">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewListItem_SelectedClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varHeight" select="@Attr.ItemHeight"/>

    <div id="VWG_{@Id}"  tabindex="-1" data-vwgfocuselement="1" style="direction:{$dir};height:{$varHeight}px;">
      <xsl:call-template name="tplSetClientUniqueId" />
      <xsl:call-template name="tplApplyDragAndDrop" />
      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-HideFocus ',$prmListViewFontDataClass,' ListView-ListItem')" />
        <xsl:if test="@Attr.Selected='1'"><xsl:value-of select="concat(' ',$prmListViewListItem_SelectedClass)" /></xsl:if>
      </xsl:attribute>
      <div class="Common-HandCursor" style="white-space:nowrap; direction:{$dir};display:inline;" dir="{$dir}">
        <xsl:call-template name="tplApplyListViewItemClickEvents">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:call-template name="tplSetToolTip" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:if test="$prmCheckBoxes='1'">
          <span>
            <xsl:if test="not($prmIsEnabled='0') and not($prmIsEnabled='0')">
              <xsl:attribute name="onclick">mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)</xsl:attribute>
            </xsl:if>
            <img id="LVI_CB_{@Id}" class="Common-VAlignMiddle {$prmListViewCheckBoxImageClass}" alt="" style="vertical-align:bottom;">
              <xsl:choose>
                <xsl:when test="@Attr.Checked='1'">
                  <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
                </xsl:otherwise>
              </xsl:choose>
            </img>
          </span>
          <span>&#160;</span>
        </xsl:if>
        <img class="Common-VAlignMiddle ListView-ListItemImage Common-Icon16X16" src="{@Attr.Image}" alt="">
          <xsl:if test="not(@Attr.Image)">
            <xsl:attribute name="style">visibility:hidden;</xsl:attribute>
          </xsl:if>
        </img>
        <span id="VWGLE_{@Id}" class="ListView-ListItemLabel">
          <xsl:if test="../@Attr.LabelEdit='1' and @Attr.Selected='1'">
            <xsl:attribute name="data-vwglabeledit">1</xsl:attribute>
          </xsl:if>
          <xsl:attribute name="style">vertical-align:middle;<xsl:value-of select="SI[@COL='0']/@s" /></xsl:attribute>
          <xsl:text>&#160;</xsl:text>
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="SI[@COL='0']/@c" />
          </xsl:call-template>
        </span>
      </div>
    </div>
  </xsl:template>

  <xsl:template name="tplListViewDrawSmallIconsRows">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewListSmallItem_SelectedClass" />
    
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varHeight" select="@Attr.ItemHeight"/>
    
    <xsl:for-each select="Tags.Row | Tags.Group">
      <xsl:if test="name()='Tags.Group'">
        <div style="clear:both;" class="{$prmListViewGroupHeaderClass}">
          <xsl:apply-templates select="." mode="modListViewGroupHeader" >            
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
          </xsl:apply-templates>
        </div>
      </xsl:if>
      <xsl:if test="not(name()='Tags.Group')">
        <xsl:call-template name="tplListViewDrawSmallIconsRow">
          <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
          <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
          <xsl:with-param name="prmListViewListSmallItem_SelectedClass" select="$prmListViewListSmallItem_SelectedClass" />
          <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        </xsl:call-template>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="Tags.Row[../@Attr.View='SmallIcon' and not(../@Attr.CustomStyle)]">
    <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
    <xsl:param name="prmListViewCheckBoxImageClass"  select="'ListView-CheckBoxImage'" />
    <xsl:param name="prmListViewListSmallItem_SelectedClass" select="'ListView-ListSmallItem_Selected'" />
    <xsl:param name="prmCheckBoxes" select="../@Attr.CheckBoxes"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDrawSmallIconsRow">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
      <xsl:with-param name="prmListViewListSmallItem_SelectedClass" select="$prmListViewListSmallItem_SelectedClass" />
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplListViewDrawSmallIconsRow">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewListSmallItem_SelectedClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varHeight" select="@Attr.ItemHeight"/>

    <div id="VWG_{@Id}" tabindex="-1" data-vwgfocuselement="1">
      <xsl:call-template name="tplSetClientUniqueId" />
      <xsl:call-template name="tplApplyDragAndDrop" />
      <xsl:call-template name="tplSetToolTip" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:attribute name="style">
        float:<xsl:value-of select="$left" />;
        direction:<xsl:value-of select="$dir" />;
        height:<xsl:value-of select="$varHeight" />px;
      </xsl:attribute>
      <xsl:attribute name="class">
        <xsl:text>Common-HideFocus Common-HandCursor ListView-ListSmallItem</xsl:text>
        <xsl:if test="@Attr.Selected='1'"><xsl:value-of select="concat(' ',$prmListViewListSmallItem_SelectedClass)"/></xsl:if>
      </xsl:attribute>
      <span class="nobr" dir="{$dir}">
        <xsl:if test="$prmCheckBoxes='1'">
          <!-- CheckBox Icon (Image) -->
          <img id="LVI_CB_{@Id}"  class="Common-VAlignMiddle {$prmListViewCheckBoxImageClass}" alt="" style="vertical-align:middle;">
            <xsl:if test="not($prmIsEnabled='0') and not($prmIsEnabled='0')">
              <xsl:attribute name="onclick">mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)</xsl:attribute>
            </xsl:if>
            <xsl:choose>
              <xsl:when test="@Attr.Checked='1'">
                <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
        </xsl:if>
        <!-- Icon (Image) of the item -->
        <img class="Common-VAlignMiddle ListView-ListSmallItemImage"  src="{@Attr.Image}" alt="">
          <!-- Applying OnClick and OnDblClick JS actions for Icon click -->
          <xsl:call-template name="tplApplyListViewItemClickEvents">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>

          <!-- Applying image size in style or putting default value -->
          <xsl:attribute name="style">
            <xsl:choose>
              <xsl:when test="../@Attr.ImageWidth">
                width:<xsl:value-of select="../@Attr.ImageWidth"/>px;
              </xsl:when>
              <xsl:otherwise>
                width:16px;
              </xsl:otherwise>
            </xsl:choose>
            <xsl:choose>
              <xsl:when test="../@Attr.ImageHeight">
                height:<xsl:value-of select="../@Attr.ImageHeight"/>px;
              </xsl:when>
              <xsl:otherwise>
                height:16px;
              </xsl:otherwise>
            </xsl:choose>
            <xsl:if test="not(@Attr.Image)">visibility:hidden;</xsl:if>
          </xsl:attribute>
        </img>
        <span id="VWGLE_{@Id}" class="ListView-SmallItemLabel {$prmListViewFontDataClass}">
          <xsl:attribute name="style"><xsl:value-of select="SI[@COL='0']/@s" /></xsl:attribute>
          <xsl:if test="../@Attr.LabelEdit='1' and @Attr.Selected='1'">
            <xsl:attribute name="data-vwglabeledit">1</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplApplyListViewItemClickEvents">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="SI[@COL='0']/@c" />
          </xsl:call-template>
          <xsl:if test="not(SI[@COL='0']/@c) or SI[@COL='0']/@c=''">&#160;</xsl:if>
        </span>
      </span>
    </div>
  </xsl:template>

  <xsl:template name="tplListViewDrawLargeIconsRows">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewListLargeItem_SelectedClass" />

    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varHeight" select="@Attr.ItemHeight"/>
    <xsl:if test="not (@Attr.Scrollbars)">
      <xsl:call-template name="tplCompleteScrollCapabilities">
        <xsl:with-param name="prmScrollMoveHandler">function(){mobjApp.ListView_iScrollSyncScrollers('<xsl:value-of  select="@Attr.Id" />')}</xsl:with-param>
      </xsl:call-template>
    </xsl:if>
    <div style="width: 100%; height: 100%;">
      <div style="width: 100%; height: 100%;display:table;">
        <xsl:for-each select="Tags.Row | Tags.Group">
          <xsl:if test="name()='Tags.Group'">
            <div style="clear:both;" class="{$prmListViewGroupHeaderClass}">
              <xsl:apply-templates select="." mode="modListViewGroupHeader" >
                <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
              </xsl:apply-templates>
            </div>
          </xsl:if>
          <xsl:if test="not(name()='Tags.Group')">
            <xsl:call-template name="tplListViewDrawLargeIconsRow">
              <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
              <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
              <xsl:with-param name="prmListViewListLargeItem_SelectedClass" select="$prmListViewListLargeItem_SelectedClass" />
              <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
            </xsl:call-template>
          </xsl:if>
        </xsl:for-each>
      </div>
    </div>
  </xsl:template>

  <xsl:template match="Tags.Row[../@Attr.View='LargeIcon' and not(../@Attr.CustomStyle)]">
    <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
    <xsl:param name="prmListViewCheckBoxImageClass"  select="'ListView-CheckBoxImage'" />
    <xsl:param name="prmListViewListLargeItem_SelectedClass" select="'ListView-ListLargeItem_Selected'" />
    <xsl:param name="prmCheckBoxes" select="../@Attr.CheckBoxes"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplListViewDrawLargeIconsRow">
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
      <xsl:with-param name="prmListViewListLargeItem_SelectedClass" select="$prmListViewListLargeItem_SelectedClass" />
      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplListViewDrawLargeIconsRow">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewListLargeItem_SelectedClass" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varHeight" select="@Attr.ItemHeight"/>

    <div id="VWG_{@Id}" tabindex="-1" data-vwgfocuselement="1">
      <xsl:call-template name="tplSetClientUniqueId" />
      <xsl:attribute name="style">
        float: <xsl:value-of select="$left"/>; display:table-cell; vertical-align:middle;
        <xsl:choose>
          <xsl:when test="../@Attr.LargeImageWidth and number(../@Attr.LargeImageWidth)>100">
            width:<xsl:value-of select="number(../@Attr.LargeImageWidth)+30"/>px;
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>width:100px;</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplSetToolTip" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:call-template name="tplApplyDragAndDrop" />
      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-HideFocus ',$prmListViewFontDataClass,' Common-HandCursor ListView-ListLargeItem')" />
        <xsl:if test="@Attr.Selected='1'"><xsl:value-of select="concat(' ',$prmListViewListLargeItem_SelectedClass)" /></xsl:if>
      </xsl:attribute>
      <table class="Common-CellPadding0 Common-CellSpacing2" style="width:100%;">
        <tr>
          <td>
            <table style="width:100%;" class="Common-AlignCenter Common-CellPadding0 Common-CellSpacing0" dir="{$dir}">
              <tr>
                <!-- TD of CheckBox-->
                <xsl:if test="$prmCheckBoxes='1'">
                  <!-- TD of CheckBox -->
                  <td style="width:14px;" class="Common-VAlignBottom">
                    <xsl:if test="not($prmIsEnabled='0') and not($prmIsEnabled='0')">
                      <xsl:attribute name="onclick">mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)</xsl:attribute>
                    </xsl:if>
                    <img id="LVI_CB_{@Id}"  class="{$prmListViewCheckBoxImageClass}" alt="" style="vertical-align:bottom;">
                      <xsl:choose>
                        <xsl:when test="@Attr.Checked='1'">
                          <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
                        </xsl:otherwise>
                      </xsl:choose>
                    </img>
                  </td>
                </xsl:if>
                <!-- TD of Large Icon (Image) -->
                <td class="Common-AlignCenter">
                  <img class="ListView-ListLargeItemImage" alt="">
                    <xsl:call-template name="tplApplyListViewItemClickEvents">
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:call-template>
                    <xsl:attribute name="style">
                      <xsl:choose>
                        <xsl:when test="../@Attr.LargeImageWidth">
                          width:<xsl:value-of select="../@Attr.LargeImageWidth"/>px;
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:text>width:32px;</xsl:text>
                        </xsl:otherwise>
                      </xsl:choose>
                      <xsl:choose>
                        <xsl:when test="../@Attr.LargeImageHeight">
                          height:<xsl:value-of select="../@Attr.LargeImageHeight"/>px;
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:text>height:32px;</xsl:text>
                        </xsl:otherwise>
                      </xsl:choose>
                      <xsl:if test="not(@Attr.LargeImage)">visibility:hidden;</xsl:if>
                    </xsl:attribute>
                    <xsl:if test="@Attr.LargeImage">
                      <xsl:attribute name="src">
                        <xsl:value-of select="@Attr.LargeImage" />
                      </xsl:attribute>
                    </xsl:if>
                  </img>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <!-- TD of the Label Text -->
          <td class="Common-AlignCenter">
            <xsl:attribute name="style">
              <xsl:if test="$prmCheckBoxes='1'">
                padding-<xsl:value-of select="$left"/>:14px;
              </xsl:if>
            </xsl:attribute>
            <div class="ListView-LargeItemLabelHeight" style="height:{$varHeight}px;">
              <xsl:call-template name="tplApplyListViewItemClickEvents">
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
              <span id="VWGLE_{@Id}" class="ListView-LargeItemLabel {$prmListViewFontDataClass}">
                <xsl:attribute name="style"><xsl:value-of select="SI[@COL='0']/@s" /></xsl:attribute>
                <xsl:if test="../@Attr.LabelEdit='1' and @Attr.Selected='1'">
                  <xsl:attribute name="data-vwglabeledit">1</xsl:attribute>
                </xsl:if>
                <xsl:call-template name="tplDecodeText">
                  <xsl:with-param name="prmText" select="SI[@COL='0']/@c" />
                </xsl:call-template>
                <xsl:if test="not(SI[@COL='0']/@c) or SI[@COL='0']/@c=''">&#160;</xsl:if>
              </span>
            </div>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>

  <!--Details view sub templates-->

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and not(@Attr.CustomStyle) and not(@Attr.Appearance)]" mode="modListViewDetailedColumns">
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
  
  <xsl:template name="tplListViewDetailedColumnsAPI">
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />
    
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmColIdBase" />
    <xsl:param name="prmIsHeader" select="'0'" />

    <colgroup>
    <xsl:if test="$prmCheckBoxes='1'">
      <col style="width:22px" class="ListView-Column"/>
      <col style="width:[Skin.HeaderSeperatorWidth]px"  class="{$prmListViewColumnSeperatorClass}" />
    </xsl:if>
    <xsl:for-each select="$prmCols">
      <col id="{$prmColIdBase}_{@Id}" style="width:{@Attr.Width}px">
        <xsl:attribute name="class">ListView-Column <xsl:if test="@Attr.Sort='1' or @Attr.Sort='0'"><xsl:value-of select="concat(' ',$prmListViewSortedColumnClass)"/></xsl:if></xsl:attribute>
      </col>
      <col style="width:[Skin.HeaderSeperatorWidth]px"  class="{$prmListViewColumnSeperatorClass}"/>
    </xsl:for-each>
    <xsl:if test="$prmIsHeader='1'">
      <col style="width:17px"/>
      <col style="width:30px"/>
    </xsl:if>
    <col />
    </colgroup>
  </xsl:template>

  <xsl:template match="WC:Tags.ListView[@Attr.View='Details' and not(@Attr.CustomStyle) and not(@Attr.Appearance)]" mode="modListViewDetailedHeader">
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

  <xsl:template name="tplListViewDetailedHeaderAPI">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />

    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />


    <xsl:if test="$prmCheckBoxes='1'">
      <td class="{$prmListViewFontDataClass} {$prmListViewHeaderCellClass}">&#160;</td>
      <td class="{$prmListViewHeaderSeperatorClass}">
        <xsl:call-template name="tplDrawEmptyImage">
           <xsl:with-param name="prmImageWidth" select="concat([Skin.HeaderSeperatorWidth], 'px')" />
        </xsl:call-template>
      </td>
    </xsl:if>
    <xsl:for-each select="$prmCols">
<td id="VWG_{@Id}" onclick="mobjApp.ListView_HeaderClick(this,{@Id})" class="{$prmListViewFontDataClass} Common-HandCursor {$prmListViewHeaderCellClass} nobr" data-vwgdragable="1" >
        <xsl:attribute name="style">
          <xsl:call-template name="tplApplyOnDrawVisualEffects" />
          text-align:<xsl:value-of select="@Attr.ContentAlign" />;
        </xsl:attribute>
        <xsl:call-template name="tplSetClientUniqueId" />
        <xsl:if test="not($prmIsEnabled='0') and not(../@Attr.HeaderStyle='1')">
          <xsl:call-template name="tplSetHighlight" >
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </xsl:if>
        <xsl:call-template name="tplApplyAfterDrawVisualEffects" />

        <div onmousedown="mobjApp.ListView_OrderColumn('{../@Attr.Id}','{@Attr.Id}',window,event)">
          <span>
            <!--Paint Headers font style-->
            <xsl:attribute name="style">
              <xsl:call-template name="tplApplyFontStyles">
                <xsl:with-param name="prmTarget" select="../."/>
              </xsl:call-template>
              <xsl:choose>
                <xsl:when test="../@Attr.WrapContents='1'">white-space:normal;</xsl:when>
                <xsl:otherwise>white-space:nowrap;</xsl:otherwise>
              </xsl:choose>
            </xsl:attribute>
            <xsl:if test="@Attr.Image">
              <img src="{@Attr.Image}" style="height:16px;width:16px;" class="Common-VAlignMiddle" alt="" />&#160;
            </xsl:if>
            <xsl:call-template name="tplDecodeTextAsHtml"/>&#160;
            <span>
              <xsl:if test="@Attr.Sort='1'">
                <img src="[Skin.Path]HeaderSortAscending.gif.wgx" class="Common-VAlignMiddle" alt="" />
              </xsl:if>
              <xsl:if test="@Attr.Sort='0'">
                <img src="[Skin.Path]HeaderSortDescending.gif.wgx" class="Common-VAlignMiddle" alt="" />
              </xsl:if>
            </span>
          </span>
        </div>
      </td>
      <td class="{$prmListViewHeaderSeperatorClass}" data-colid="{@Id}" onmousedown="mobjApp.ListView_Resize(this,window,event)">
        <xsl:call-template name="tplDrawEmptyImage">
          <xsl:with-param name="prmImageWidth" select="concat([Skin.HeaderSeperatorWidth], 'px')" />
        </xsl:call-template>
      </td>
    </xsl:for-each>
    <td class="{$prmListViewHeaderCellClass}">&#160;</td>
    <td class="{$prmListViewHeaderCellClass}" style="border-left:none">&#160;</td>
    <td class="{$prmListViewHeaderCellClass}" style="border-left:none;">&#160;</td>
  </xsl:template>

  <xsl:template name="tplListViewDrawHeaders">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />    
    <xsl:param name="prmListViewHeaderSeperatorClass" />
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />
    
    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varHeight" select="@Attr.HeaderHeight"/>
    <table  class="Common-CellPadding0 Common-CellSpacing0" style="height:100%;width:100%;table-layout:fixed">
      
      <xsl:apply-templates select="." mode="modListViewDetailedColumns" >
        <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
        <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
        
        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes" />
        <xsl:with-param name="prmCols" select="$prmCols" />
        <xsl:with-param name="prmColIdBase" select="'COL1'" />
        <xsl:with-param name="prmIsHeader" select="'1'" />
      </xsl:apply-templates>
      
      <tr>
        <xsl:apply-templates select="." mode="modListViewDetailedHeader" >
          <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
          <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
          <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
          
          <xsl:with-param name="prmCols" select="$prmCols"/>
          <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
          <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
          <xsl:with-param name="prmHeight" select="$varHeight"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:apply-templates>
      </tr>
    </table>
  </xsl:template>


  <xsl:template name="tplDrawDetailsRow">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />
    <xsl:param name="prmListViewCheckBoxImageClass" />
    <xsl:param name="prmListViewDataRowClass" />
    <xsl:param name="prmListViewDataFullRowClass"/>
    <xsl:param name="prmListViewDataRow0Class" />
    <xsl:param name="prmListViewDataRow1Class" />
    <xsl:param name="prmListViewCellClass" />
    <xsl:param name="prmListViewItemCellClass" />
    <xsl:param name="prmListViewDataCellClass" />
    
    <xsl:param name="prmCheckBoxes"/>
    <xsl:param name="prmCols"/>
	  <migration-write type="elements">
		  <xsl:param name="prmColsByName" migration-select="prmCols.attrhash(&quot;Attr.Name&quot;)" />
		  <xsl:param name="prmRowIndex"  select="count(preceding-sibling::Tags.Row)"/>
	  </migration-write>
    <xsl:param name="prmFlagMatchedElement" select="0"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varRow" select="."/>    
	<!-- Calculate amount of listview rows before this row, module 2, if 0 (or even number) no alternate.-->
	<xsl:variable name="varAlternate" select="(count(preceding-sibling::Tags.Row) mod 2)=0" migration-select="(prmRowIndex % 2) == 0"/>
    <xsl:variable name="varHeight" select="../@Attr.ItemHeight"/>
    <xsl:variable name="varIsFullRowSelect" select="../@Attr.FullRowSelect='1'"/>
    
    <xsl:if test="name()='Tags.ListViewPanel'">
      <tr>
        <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute></xsl:if>
        <td class="ListView-PanelCell" colspan="{count($prmCols)*2 + number($prmCheckBoxes='1')*2+1}">
          <xsl:apply-templates select="$varRow/*" mode="modLayoutItem">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </td>
      </tr>
   </xsl:if>
    
    <xsl:if test="name()='Tags.Group'">
      <tr>
        <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute></xsl:if>
        <td colspan="{count($prmCols)*2 + number($prmCheckBoxes='1')*2+1}" class="{$prmListViewGroupHeaderClass}">
          <xsl:apply-templates select="." mode="modListViewGroupHeader" >
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
          </xsl:apply-templates>
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="name()='Tags.Row'">
      <tr tabindex="-1" data-vwgfocuselement="1" data-swipable="yes">
        <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute></xsl:if>
        <xsl:call-template name="tplSetToolTip">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:attribute name="id">VWG_<xsl:value-of select="@Id"/></xsl:attribute>
        <xsl:attribute name="style">height:<xsl:value-of select="$varHeight" />px;<xsl:call-template name="tplApplyOnDrawVisualEffects" /></xsl:attribute>
        <xsl:call-template name="tplSetClientUniqueId" />
        <xsl:call-template name="tplApplyDragAndDrop" />
        <xsl:attribute name="class">
          <xsl:text>Common-HideFocus </xsl:text>
          <xsl:value-of select="$prmListViewFontDataClass" />
          <xsl:text> Common-HandCursor </xsl:text>
          <xsl:choose>
            <xsl:when test="$varAlternate"><xsl:value-of select="concat(' ',$prmListViewDataRow1Class,' ',$prmListViewDataRow1Class)"  /></xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmListViewDataRow0Class" /></xsl:otherwise>
          </xsl:choose>

          <xsl:choose>
            <xsl:when test="$varIsFullRowSelect">
              <xsl:value-of select="concat(' ',$prmListViewDataFullRowClass,' ')"/>
              <xsl:if test="@Attr.Selected='1'"><xsl:value-of select="concat(' ',$prmListViewDataFullRowClass,'_Selected')" /></xsl:if>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="concat(' ',$prmListViewDataRowClass,' ')"/>
              <xsl:if test="@Attr.Selected='1'"><xsl:value-of select="concat(' ',$prmListViewDataRowClass,'_Selected')" /></xsl:if>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>

        <xsl:call-template name="tplApplyAfterDrawVisualEffects" />


        <xsl:apply-templates select="." mode="modListViewDetailedItemRow" >
          <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
          <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
          <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
          <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
          
          <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
          <xsl:with-param name="prmCols" select="$prmCols"/>
          <migration-write type="elements">
            <xsl:with-param name="prmColsByName" select="$prmColsByName" />          
          </migration-write>
          <xsl:with-param name="prmIsFullRowSelect" select="$varIsFullRowSelect" />
          <xsl:with-param name="prmHeight" select="$varHeight" />
          <xsl:with-param name="prmRow" select="$varRow" />
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:apply-templates>
        
      </tr>
    </xsl:if>
	</xsl:template>

  <xsl:template match="Tags.Row[not(../@Attr.CustomStyle) and not(../@Attr.Appearance)]" mode="modListViewDetailedItemRow">
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

  <xsl:template name="tplListViewDetailedItemRowAPI">
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


    <xsl:if test="$prmCheckBoxes='1'">
      <td>
        <xsl:attribute name="class">Common-AlignCenter <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" /></xsl:attribute>
        <xsl:if test="not($prmIsEnabled='0')">
          <xsl:attribute name="onclick">mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)</xsl:attribute>
        </xsl:if>
        <img id="LVI_CB_{@Id}"  class="{$prmListViewCheckBoxImageClass}" alt="" style="vertical-align:bottom;">
          <xsl:choose>
            <xsl:when test="@Attr.Checked='1'">
              <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
            </xsl:when>
            <xsl:otherwise>
              <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
            </xsl:otherwise>
          </xsl:choose>
        </img>
      </td>
      <td>
        <xsl:attribute name="class"><xsl:value-of select="concat($prmListViewCellClass,' ','ListView-SeperatorCell')" /></xsl:attribute>
        <xsl:text>&#160;</xsl:text>
      </td>
    </xsl:if>

    <xsl:for-each select="./SI" migration-index="intColumnIndex">
      <xsl:variable name="varColIdx" select="./@COL" />
      <xsl:variable name="varValue" select="./@c" />
      <xsl:variable name="varCol" select="$prmCols[@Attr.Name=concat('c',$varColIdx)]" />
      <xsl:variable name="varType" select="$varCol/@Attr.Type"/>
      <xsl:variable name="varIsNotFullRowSelect" select="not($prmIsFullRowSelect) and position() = 1" migration-select="!prmIsFullRowSelect &amp;&amp; intColumnIndex==0" />


      <xsl:choose>
        <xsl:when test="$varType='Control'">
          <td onresize="mobjApp.Layout_ContainerResized(this.firstChild);">
            <xsl:attribute name="class">
              <xsl:value-of select="concat($prmListViewCellClass,' ','ListView-ControlCell')" />
              <xsl:if test="$varIsNotFullRowSelect">
                <xsl:value-of select="concat(' ',$prmListViewItemCellClass)" />
              </xsl:if>
            </xsl:attribute>
            <div data-vwgtype="container" style="width:100%; height:{$prmHeight}px; overflow:hidden;position:relative;">
              <xsl:apply-templates select="$prmRow/*[@Id=$varValue]" migration-select="prmRow.xpath(&quot;*[@Id='&quot; + varValue + &quot;']&quot;)" mode="modLayoutItem" >
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
              </xsl:apply-templates>
            </div>
          </td>
        </xsl:when>
        <xsl:when test="$varType='Icon'">
          <td>
            <xsl:attribute name="class">Common-AlignCenter <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" />
              <xsl:if test="$varIsNotFullRowSelect">
                <xsl:value-of select="concat(' ',$prmListViewItemCellClass)" />
              </xsl:if></xsl:attribute>
            <xsl:call-template name="tplApplyListViewItemClickEvents">
              <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
              <xsl:with-param name="prmCheckOnDoubleClick" select="../../@Attr.CheckOnDoubleClick"/>
              <xsl:with-param name="prmListViewId" select="../../@Id"/>
              <xsl:with-param name="prmListViewItemId" select="../@Id"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
            <xsl:call-template name="tplApplyDetailedCellStyle" >
              <xsl:with-param name="prmRow" select="$prmRow" />
              <xsl:with-param name="prmCell" select="." />
            </xsl:call-template>
            <migration-ignore reason="the '.' will be javascripted to this, so comparison will fail">
              <xsl:if test="$varValue=''">&#160;</xsl:if>
              <xsl:if test="not($varValue='')">
                <img class="Common-Icon16X16" src="{$varValue}" alt=""/>
              </xsl:if>
            </migration-ignore>
            <migration-write>
              if(varValue == ''){
              objWriter.write(" ");
              }
              else{
              objWriter.writeFullTag("img", "class=\"Common-Icon16X16\"  alt=\"\" src=\"", varValue, "\" ");
              }
            </migration-write>
          </td>
        </xsl:when>
        <xsl:otherwise>
          <td>
            <xsl:call-template name="tplApplyListViewItemClickEvents">
              <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
              <xsl:with-param name="prmCheckOnDoubleClick" select="../../@Attr.CheckOnDoubleClick"/>
              <xsl:with-param name="prmListViewId" select="../../@Id"/>
              <xsl:with-param name="prmListViewItemId" select="../@Id"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
            <xsl:attribute name="class">
              <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" />
              <xsl:if test="$varIsNotFullRowSelect">
                <xsl:value-of select="concat(' ',$prmListViewItemCellClass)" />
              </xsl:if>
            </xsl:attribute>
            <xsl:if test="$varIsNotFullRowSelect">
              <xsl:attribute name="onclick">mobjApp.ListView_Click('<xsl:value-of select="../../@Id" />','<xsl:value-of select="../@Id" />',window,event)</xsl:attribute>
              <xsl:attribute name="oncontextmenu">mobjApp.ListView_RightClick('<xsl:value-of select="../../@Id" />','<xsl:value-of select="../@Id" />',window,event)</xsl:attribute>
              <xsl:if test="$prmCheckBoxes='1' and ../../@Attr.CheckOnDoubleClick='1'">
                <xsl:attribute name="ondblclick">mobjApp.ListView_DoubleClick('<xsl:value-of select="../../@Id" />','<xsl:value-of select="../@Id" />',window,event)</xsl:attribute>
              </xsl:if>
            </xsl:if>
            <xsl:call-template name="tplApplyDetailedCellStyle" >
              <xsl:with-param name="prmRow" select="$prmRow" />
              <xsl:with-param name="prmAlign" select="$varCol/@Attr.TextAlign" />
              <xsl:with-param name="prmCell" select="." />
            </xsl:call-template>
            <div style="direction:{$dir};" dir="{$dir}">
              <xsl:if test="$dir='RTL'">
                <xsl:attribute name="class">ListView-FloatRight</xsl:attribute>
              </xsl:if>
              <span class="nobr">
                <xsl:if test="../../C[@TP='Text'][1]/@N=name()">
                  <xsl:attribute name="id">VWGLE_<xsl:value-of select="../@Id" /></xsl:attribute>
                </xsl:if>
                <xsl:if test="../../@Attr.LabelEdit='1' and ../@Attr.Selected='1'">
                  <xsl:attribute name="data-vwglabeledit">1</xsl:attribute>
                </xsl:if>

                <xsl:if test="$varCol/@Attr.Name='c0' and ../@Attr.Image">
                  <xsl:if test="../@Attr.IdentCount">
                    <xsl:call-template name="tplApplyRowIdentCount">
                      <xsl:with-param name="prmCount" select="../@Attr.IdentCount" />
                    </xsl:call-template>
                  </xsl:if>
                  <img class="Common-VAlignMiddle Common-Icon16X16" src="{../@Attr.Image}" alt=""/>&#160;
                </xsl:if>
                <xsl:choose>
                  <xsl:when test="$varValue and not($varValue='')">
                    <xsl:call-template name="tplDecodeTextAsHtml">
                      <xsl:with-param name="prmText" select="$varValue"/>
                    </xsl:call-template>
                  </xsl:when>
                  <xsl:otherwise>&#160;</xsl:otherwise>
                </xsl:choose>
              </span>
            </div>
          </td>
        </xsl:otherwise>
      </xsl:choose>
      <td>
        <xsl:attribute name="class"><xsl:value-of select="concat($prmListViewCellClass,' ','ListView-SeperatorCell')" /></xsl:attribute>
        <xsl:call-template name="tplApplyDetailedCellStyle" >
          <xsl:with-param name="prmRow" select="$prmRow" />
          <xsl:with-param name="prmCell" select="." />
        </xsl:call-template>
        <xsl:text>&#160;</xsl:text>
      </td>
    </xsl:for-each>

    <td >
      <xsl:attribute name="class"><xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" /></xsl:attribute>&#160;</td>
  </xsl:template>
  
  <!--Matching for controls that serve as panel.-->
  <xsl:template match="Tags.ListViewPanel/*" mode="modLayoutItem">
    <xsl:param name="prmIsEnabled" />

    <div data-vwgtype="control">
      <xsl:attribute name="style">
        height:<xsl:value-of select="@H" />px;
        width:100%;
        <xsl:call-template name="tplApplyStyles"/>
        <xsl:if test="@Attr.Visible='0'">
          display:none;  
        </xsl:if>
        position:relative;
      </xsl:attribute>
      <xsl:call-template name="tplSetControl" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:if test="not(@Attr.Visible='0')">
        <xsl:apply-templates select="." mode="modContent" />
      </xsl:if>
    </div>
  </xsl:template>
  


  <xsl:template name="tplApplyDetailedCellStyle">
    <xsl:param name="prmRow" />
    <xsl:param name="prmAlign" />
    <xsl:param name="prmCell" />
    <xsl:variable name="varValue" select="."/>

    <xsl:call-template name="tplApplyDetailedCellStyleByAttributeName" >
      <xsl:with-param name="prmRow" select="$prmRow"/>
      <xsl:with-param name="prmAlign" select="$prmAlign"/>
      <xsl:with-param name="prmCell" select="$prmCell" />
      <xsl:with-param name="prmXmlAttributeName" select="name($varValue)"/>
    </xsl:call-template>    
  </xsl:template>

  <xsl:template name="tplApplyDetailedCellStyleByAttributeName">
    <xsl:param name="prmRow" />
    <xsl:param name="prmAlign" />
    <xsl:param name="prmCell" />
    <xsl:param name="prmXmlAttributeName"/>
    
    <xsl:choose>
      <xsl:when test="$prmRow/@Attr.UseItemStyleForSubItems = '1'">
        <xsl:variable name="varItemStyle">
          <xsl:if test="$prmAlign">text-align:<xsl:value-of select="$prmAlign" />;</xsl:if><xsl:value-of select="$prmRow/SI[@COL='0']/@s" />
        </xsl:variable>
        <xsl:call-template name="tplSetCellStyle">
          <xsl:with-param name="prmStyle" select="$varItemStyle" />
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:variable name="varSubItemStyle">
          <xsl:if test="$prmAlign">text-align:<xsl:value-of select="$prmAlign" />;</xsl:if><xsl:value-of select="$prmCell/@s" />
        </xsl:variable>
        <xsl:call-template name="tplSetCellStyle">
          <xsl:with-param name="prmStyle" select="$varSubItemStyle" />
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
  <xsl:template name="tplSetCellStyle">
    <xsl:param name="prmStyle" />
    <xsl:attribute name="style"><xsl:value-of select="$prmStyle"/></xsl:attribute>
  </xsl:template>

  <xsl:template name="tplApplyRowIdentCount">
    <xsl:param name="prmCount" />
    <img class="Common-VAlignMiddle Common-Icon16X16" style="visibility:hidden;"  alt=""/>
    <xsl:if test="$prmCount > 1">
      <xsl:call-template name="tplApplyRowIdentCount">
        <xsl:with-param name="prmCount" select="$prmCount - 1"/>  
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyListViewItemClickEvents">
    <xsl:param name="prmListViewId" select="../@Id"/>
    <xsl:param name="prmListViewItemId" select="@Id"/>
    <xsl:param name="prmCheckBoxes" select="../@Attr.CheckBoxes"/>
    <xsl:param name="prmCheckOnDoubleClick" select="../@Attr.CheckOnDoubleClick"/>
    <xsl:param name="prmIsEnabled" />
    
    <xsl:if test="not($prmIsEnabled='0')">
      <xsl:attribute name="onclick">mobjApp.ListView_Click('<xsl:value-of select="$prmListViewId" />','<xsl:value-of select="$prmListViewItemId" />',window,event)</xsl:attribute>
      <xsl:attribute name="oncontextmenu">mobjApp.ListView_RightClick('<xsl:value-of select="$prmListViewId" />','<xsl:value-of select="$prmListViewItemId" />',window,event)</xsl:attribute>
      <xsl:if test="$prmCheckBoxes='1' and $prmCheckOnDoubleClick='1'">
        <xsl:attribute name="ondblclick">mobjApp.ListView_DoubleClick('<xsl:value-of select="$prmListViewId" />','<xsl:value-of select="$prmListViewItemId" />',window,event)</xsl:attribute>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Tags.Group[not(../@Attr.CustomStyle) and not(../@Attr.Appearance)]" mode="modListViewGroupHeader">
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />

    <xsl:call-template name="tplDrawListGroupHeaderAPI" >
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawListGroupHeaderAPI">
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />

    <table class="Common-CellPadding0 Common-CellSpacing0 ListView-FontGroupHeader" style="width:100%;">
      <tr>
        <td style="padding-left:5px; padding-right:5px;">
          <span class="nobr">
            <xsl:call-template name="tplDecodeTextAsHtml"/>
          </span>
        </td>
        <td style="width:100%;">
          <div class="{$prmListViewFontGroupHeaderSeperatorClass}">&#160;</div>
        </td>
        <td>
          <img alt="">
            <xsl:choose>
              <xsl:when test="not(@Attr.Expanded='0')">
                <xsl:attribute name="src">[Skin.Path]GroupHeaderExpanded.gif.wgx</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">[Skin.Path]GroupHeaderCollapsed.gif.wgx</xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
        </td>
      </tr>
    </table>
  </xsl:template>

  <!--Listview paging template-->
  <xsl:template name="tplDrawListViewPaging">
    <xsl:param name="prmListViewPagingFirstImageWidthClass" />
    <xsl:param name="prmListViewPagingLastImageWidthClass" />
    <xsl:param name="prmListViewPagingPreviousImageWidthClass" />
    <xsl:param name="prmListViewPagingNextImageWidthClass" />
    <xsl:param name="prmListViewPagingGoToBoxClass" />
    <xsl:param name="prmListViewPagingNumberSeperatorString" />
    <xsl:param name="prmListViewPagingLastButtonStyleClass" />
    <xsl:param name="prmListViewPagingFirstButtonStyleClass" />
    <xsl:param name="prmListViewPagingNextButtonStyleClass" />
    <xsl:param name="prmListViewPagingPrevButtonStyleClass" />
    
    <xsl:call-template name="tplDrawPaging">
      <xsl:with-param name="prmID" select="@Attr.Id"/>
      <xsl:with-param name="prmCurrentPage" select="@Attr.CurrentPage"/>
      <xsl:with-param name="prmTotalPages" select="@Attr.TotalPages"/>
      <xsl:with-param name="prmPagingFirstImageWidth" select="$prmListViewPagingFirstImageWidthClass"/>
      <xsl:with-param name="prmPagingFirstButtonClass" select="$prmListViewPagingFirstButtonStyleClass"/>
      <xsl:with-param name="prmPagingPreviousImageWidth" select="$prmListViewPagingPreviousImageWidthClass"/>
      <xsl:with-param name="prmPagingPrevButtonClass" select="$prmListViewPagingPrevButtonStyleClass"/>
      <xsl:with-param name="prmPagingBoxWidth" select="[Skin.PagingBoxWidth]"/>
      <xsl:with-param name="prmPagingGoToBoxClass" select="$prmListViewPagingGoToBoxClass"/>
      <xsl:with-param name="prmPagingNumberSeperatorString" select="$prmListViewPagingNumberSeperatorString"/>
      <xsl:with-param name="prmPagingNextImageWidth" select="$prmListViewPagingNextImageWidthClass"/>
      <xsl:with-param name="prmPagingNextButtonClass" select="$prmListViewPagingNextButtonStyleClass"/>
      <xsl:with-param name="prmPagingLastImageWidth" select="$prmListViewPagingLastImageWidthClass"/>
      <xsl:with-param name="prmPagingLastButtonClass" select="$prmListViewPagingLastButtonStyleClass"/>
    </xsl:call-template>
    
  </xsl:template>


 
    <xsl:template name="tplListViewDrawDetailsAPI">
      <xsl:param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:param name="prmListViewHeaderCellClass" select="'ListView-HeaderCell'" />
      <xsl:param name="prmListViewHeaderCell_EnterClass" select="'ListView-HeaderCell_Enter'" />
      <xsl:param name="prmListViewHeaderCell_DownClass" select="'ListView-HeaderCell_Down'" />
      <xsl:param name="prmListViewHeaderSeperatorClass" select="'ListView-HeaderSeperator'" />
      <xsl:param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:param name="prmListViewSortedColumnClass" select="'ListView-SortedColumn'" />
      <xsl:param name="prmListViewDataRowClass" select="'ListView-DataRow'" />
      <xsl:param name="prmListViewDataFullRowClass" select="'ListView-DataFullRow'" />
      <xsl:param name="prmListViewDataRow0Class" select="'ListView-DataRow0'" />
      <xsl:param name="prmListViewDataRow1Class" select="'ListView-DataRow1'" />
      <xsl:param name="prmListViewCellClass" select="'ListView-Cell'" />
      <xsl:param name="prmListViewItemCellClass" select="'ListView-ItemCell'" />
      <xsl:param name="prmListViewDataCellClass" select="'ListView-DataCell'" />
      <xsl:param name="prmListViewGridLinesClass" select="'ListView-GridLines'" />
      <xsl:param name="prmListViewColumnSeperatorClass" select="'ListView-ColumnSeperator'" />
      <xsl:param name="prmListViewPagingPanelHeightClass" select="'ListView-PagingPanelHeight'" />
      <xsl:param name="prmListViewPagingPanelStyleClass" select="'ListView-PagingPanelStyle'" />
      <xsl:param name="prmListViewPagingFirstImageWidthClass" select="'ListView-PagingFirstImageWidth'" />
      <xsl:param name="prmListViewPagingLastImageWidthClass" select="'ListView-PagingLastImageWidth'" />
      <xsl:param name="prmListViewPagingPreviousImageWidthClass" select="'ListView-PagingPreviousImageWidth'" />
      <xsl:param name="prmListViewPagingNextImageWidthClass" select="'ListView-PagingNextImageWidth'" />
      <xsl:param name="prmListViewPagingGoToBoxClass" select="'ListView-PagingGoToBox'" />
      <xsl:param name="prmListViewPagingNumberSeperatorString" select="'[Skin.PagingNumberSeperatorFormat]'"/>
      <xsl:param name="prmListViewPagingLastButtonStyleClass" select="'ListView-PagingLastButtonStyle'" />
      <xsl:param name="prmListViewPagingFirstButtonStyleClass" select="'ListView-PagingFirstButtonStyle'" />
      <xsl:param name="prmListViewPagingNextButtonStyleClass" select="'ListView-PagingNextButtonStyle'" />
      <xsl:param name="prmListViewPagingPrevButtonStyleClass" select="'ListView-PagingPrevButtonStyle'" />
      <xsl:param name="prmHeaders" select="not(@Attr.HeaderStyle='0')"/>
      <xsl:param name="prmAutoSizeMode" select="'0'"/>
      <xsl:param name="prmAutoSizeOrientation"/>
      <xsl:param name="prmIsEnabled" />

      <xsl:variable name="varCols" select="Tags.Column"/>
      <xsl:variable name="varRows" select="Tags.Row | Tags.Group | Tags.ListViewPanel"/>
      <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes"/>
      <xsl:variable name="varGridLines" select="@Attr.GridLines"/>
      <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1"/>
      <xsl:variable name="varHeight" select="@Attr.HeaderHeight"/>
      <xsl:variable name="varPagingHeight" select="[Skin.PagingPanelHeight]"/>

      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-Unselectable',' ',$prmListViewControlClass)" />
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$prmListViewControlClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>

      <xsl:if test="$prmHeaders">
        <div dir="{$dir}" id="HEADER_{@Id}">
          <xsl:attribute name="style">
            overflow:hidden;width:100%;height:<xsl:value-of select="$varHeight"/>px;<xsl:if test="$prmAutoSizeMode='0'">position:absolute;</xsl:if>top:0px;
          </xsl:attribute>
          <xsl:call-template name="tplListViewDrawHeaders">
            <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
            <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
            <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
            <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
            <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>

            <xsl:with-param name="prmCols" select="$varCols"/>
            <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes"/>
            <xsl:with-param name="prmGridLines" select="$varGridLines"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </div>
      </xsl:if>
      <div dir="{$dir}">
        <xsl:attribute name="style">
          width:100%;<xsl:if test="$prmAutoSizeMode='0'">position:absolute;</xsl:if>top:<xsl:value-of select="$varHeight*number($prmHeaders)"/>px;bottom:<xsl:value-of select="$varPagingHeight*number($varPaging)"/>px;
        </xsl:attribute>
        <xsl:call-template name="tplListViewDrawDetailsRows">
          <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
          <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
          <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
          <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
          <xsl:with-param name="prmListViewDataRowClass" select="$prmListViewDataRowClass"/>
          <xsl:with-param name="prmListViewDataFullRowClass" select="$prmListViewDataFullRowClass"/>
          <xsl:with-param name="prmListViewDataRow0Class" select="$prmListViewDataRow0Class"/>
          <xsl:with-param name="prmListViewDataRow1Class" select="$prmListViewDataRow1Class"/>
          <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass" />
          <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass" />
          <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>
          <xsl:with-param name="prmListViewGridLinesClass" select="$prmListViewGridLinesClass" />

          <xsl:with-param name="prmCols" select="$varCols"/>
          <xsl:with-param name="prmRows" select="$varRows"/>
          <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes"/>
          <xsl:with-param name="prmGridLines" select="$varGridLines"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </div>
      <xsl:if test="$varPaging">
        <div>
          <xsl:attribute name="style">
            overflow:hidden;width:100%;<xsl:if test="$prmAutoSizeMode='0'">position:absolute;</xsl:if>bottom:0px;
          </xsl:attribute>
          <xsl:attribute name="class">
            <xsl:value-of select="concat($prmListViewPagingPanelStyleClass,' ',$prmListViewPagingPanelHeightClass)" />
          </xsl:attribute>
          <xsl:call-template name="tplDrawListViewPaging">
            <xsl:with-param name="prmListViewPagingFirstImageWidthClass" select="$prmListViewPagingFirstImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingLastImageWidthClass" select="$prmListViewPagingLastImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingPreviousImageWidthClass" select="$prmListViewPagingPreviousImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingNextImageWidthClass" select="$prmListViewPagingNextImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingGoToBoxClass" select="$prmListViewPagingGoToBoxClass"/>
            <xsl:with-param name="prmListViewPagingNumberSeperatorString" select="$prmListViewPagingNumberSeperatorString"/>
            <xsl:with-param name="prmListViewPagingLastButtonStyleClass" select="$prmListViewPagingLastButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingFirstButtonStyleClass" select="$prmListViewPagingFirstButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingNextButtonStyleClass" select="$prmListViewPagingNextButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingPrevButtonStyleClass" select="$prmListViewPagingPrevButtonStyleClass"/>
          </xsl:call-template>
        </div>
      </xsl:if>
    </xsl:template>


    <xsl:template name="tplListViewDrawListAPI">
      <xsl:param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:param name="prmListViewListItem_SelectedClass" select="'ListView-ListItem_Selected'" />
      <xsl:param name="prmListViewPagingPanelHeightClass" select="'ListView-PagingPanelHeight'" />
      <xsl:param name="prmListViewPagingPanelStyleClass" select="'ListView-PagingPanelStyle'" />
      <xsl:param name="prmListViewPagingFirstImageWidthClass" select="'ListView-PagingFirstImageWidth'" />
      <xsl:param name="prmListViewPagingLastImageWidthClass" select="'ListView-PagingLastImageWidth'" />
      <xsl:param name="prmListViewPagingPreviousImageWidthClass" select="'ListView-PagingPreviousImageWidth'" />
      <xsl:param name="prmListViewPagingNextImageWidthClass" select="'ListView-PagingNextImageWidth'" />
      <xsl:param name="prmListViewPagingGoToBoxClass" select="'ListView-PagingGoToBox'" />
      <xsl:param name="prmListViewPagingNumberSeperatorString" select="'[Skin.PagingNumberSeperatorFormat]'"/>
      <xsl:param name="prmListViewPagingLastButtonStyleClass" select="'ListView-PagingLastButtonStyle'" />
      <xsl:param name="prmListViewPagingFirstButtonStyleClass" select="'ListView-PagingFirstButtonStyle'" />
      <xsl:param name="prmListViewPagingNextButtonStyleClass" select="'ListView-PagingNextButtonStyle'" />
      <xsl:param name="prmListViewPagingPrevButtonStyleClass" select="'ListView-PagingPrevButtonStyle'" />
      <xsl:param name="prmIsEnabled" />

      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-Unselectable',' ',$prmListViewControlClass)" />
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$prmListViewControlClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      
      <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes"/>
      <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1"/>
      <xsl:variable name="varPagingHeight" select="[Skin.PagingPanelHeight]"/>

      <div dir="{$dir}" data-vwgfocuselement="1" tabindex="-1" style="direction:{$dir};width:100%;position:absolute;top:0px;bottom:{$varPagingHeight*number($varPaging)}px;">
        <div>
          <xsl:call-template name="tplApplyScrollableAttributes"/>
          <xsl:attribute name="style">
            width:100%;height:100%;
            <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
            <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
          </xsl:attribute>
          <xsl:if test="not($prmIsEnabled='0')">
            <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplListViewDrawListRows">
            <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
            <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
            <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
            <xsl:with-param name="prmListViewListItem_SelectedClass" select="$prmListViewListItem_SelectedClass"/>

            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes"/>
          </xsl:call-template>
        </div>
      </div>
      <xsl:if test="$varPaging">
        <div class="{$prmListViewPagingPanelHeightClass} {$prmListViewPagingPanelStyleClass}" style="overflow:hidden;width:100%;position:absolute;bottom:0px;">
          <xsl:call-template name="tplDrawListViewPaging">
            <xsl:with-param name="prmListViewPagingFirstImageWidthClass" select="$prmListViewPagingFirstImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingLastImageWidthClass" select="$prmListViewPagingLastImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingPreviousImageWidthClass" select="$prmListViewPagingPreviousImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingNextImageWidthClass" select="$prmListViewPagingNextImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingGoToBoxClass" select="$prmListViewPagingGoToBoxClass"/>
            <xsl:with-param name="prmListViewPagingNumberSeperatorString" select="$prmListViewPagingNumberSeperatorString"/>
            <xsl:with-param name="prmListViewPagingLastButtonStyleClass" select="$prmListViewPagingLastButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingFirstButtonStyleClass" select="$prmListViewPagingFirstButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingNextButtonStyleClass" select="$prmListViewPagingNextButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingPrevButtonStyleClass" select="$prmListViewPagingPrevButtonStyleClass"/>
          </xsl:call-template>
        </div>
      </xsl:if>
    </xsl:template>


    <xsl:template name="tplListViewDrawSmallIconsAPI">
      <xsl:param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:param name="prmListViewListSmallItem_SelectedClass" select="'ListView-ListSmallItem_Selected'" />
      <xsl:param name="prmListViewPagingPanelHeightClass" select="'ListView-PagingPanelHeight'" />
      <xsl:param name="prmListViewPagingPanelStyleClass" select="'ListView-PagingPanelStyle'" />
      <xsl:param name="prmListViewPagingFirstImageWidthClass" select="'ListView-PagingFirstImageWidth'" />
      <xsl:param name="prmListViewPagingLastImageWidthClass" select="'ListView-PagingLastImageWidth'" />
      <xsl:param name="prmListViewPagingPreviousImageWidthClass" select="'ListView-PagingPreviousImageWidth'" />
      <xsl:param name="prmListViewPagingNextImageWidthClass" select="'ListView-PagingNextImageWidth'" />
      <xsl:param name="prmListViewPagingGoToBoxClass" select="'ListView-PagingGoToBox'" />
      <xsl:param name="prmListViewPagingNumberSeperatorString" select="'[Skin.PagingNumberSeperatorFormat]'"/>
      <xsl:param name="prmListViewPagingLastButtonStyleClass" select="'ListView-PagingLastButtonStyle'" />
      <xsl:param name="prmListViewPagingFirstButtonStyleClass" select="'ListView-PagingFirstButtonStyle'" />
      <xsl:param name="prmListViewPagingNextButtonStyleClass" select="'ListView-PagingNextButtonStyle'" />
      <xsl:param name="prmListViewPagingPrevButtonStyleClass" select="'ListView-PagingPrevButtonStyle'" />
      <xsl:param name="prmIsEnabled" />

      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-Unselectable',' ',$prmListViewControlClass)" />
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$prmListViewControlClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      
      <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes"/>
      <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1"/>
      <xsl:variable name="varPagingHeight" select="[Skin.PagingPanelHeight]"/>

      <div style="width:100%;position:absolute;top:0px;bottom:{$varPagingHeight*number($varPaging)}px;">
        <div data-vwgfocuselement="1" tabindex="-1">
          <xsl:call-template name="tplApplyScrollableAttributes"/>
          <xsl:attribute name="style">
            width:100%;height:100%;
            <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
            <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
          </xsl:attribute>
          <xsl:if test="not($prmIsEnabled='0')">
            <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplListViewDrawSmallIconsRows">
            <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
            <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
            <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
            <xsl:with-param name="prmListViewListSmallItem_SelectedClass" select="$prmListViewListSmallItem_SelectedClass" />

            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes"/>
          </xsl:call-template>
        </div>
      </div>
      <xsl:if test="$varPaging">
        <div class="{$prmListViewPagingPanelHeightClass} {$prmListViewPagingPanelStyleClass}" style="overflow:hidden;width:100%;position:absolute;bottom:0px;">
          <xsl:call-template name="tplDrawListViewPaging">
            <xsl:with-param name="prmListViewPagingFirstImageWidthClass" select="$prmListViewPagingFirstImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingLastImageWidthClass" select="$prmListViewPagingLastImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingPreviousImageWidthClass" select="$prmListViewPagingPreviousImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingNextImageWidthClass" select="$prmListViewPagingNextImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingGoToBoxClass" select="$prmListViewPagingGoToBoxClass"/>
            <xsl:with-param name="prmListViewPagingNumberSeperatorString" select="$prmListViewPagingNumberSeperatorString"/>
            <xsl:with-param name="prmListViewPagingLastButtonStyleClass" select="$prmListViewPagingLastButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingFirstButtonStyleClass" select="$prmListViewPagingFirstButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingNextButtonStyleClass" select="$prmListViewPagingNextButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingPrevButtonStyleClass" select="$prmListViewPagingPrevButtonStyleClass"/>
          </xsl:call-template>
        </div>
      </xsl:if>
    </xsl:template>


    <xsl:template name="tplListViewDrawLargeIconsAPI">
      <xsl:param name="prmListViewControlClass" select="'ListView-Control'" />
      <xsl:param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:param name="prmListViewListLargeItem_SelectedClass" select="'ListView-ListLargeItem_Selected'" />
      <xsl:param name="prmListViewPagingPanelHeightClass" select="'ListView-PagingPanelHeight'" />
      <xsl:param name="prmListViewPagingPanelStyleClass" select="'ListView-PagingPanelStyle'" />
      <xsl:param name="prmListViewPagingFirstImageWidthClass" select="'ListView-PagingFirstImageWidth'" />
      <xsl:param name="prmListViewPagingLastImageWidthClass" select="'ListView-PagingLastImageWidth'" />
      <xsl:param name="prmListViewPagingPreviousImageWidthClass" select="'ListView-PagingPreviousImageWidth'" />
      <xsl:param name="prmListViewPagingNextImageWidthClass" select="'ListView-PagingNextImageWidth'" />
      <xsl:param name="prmListViewPagingGoToBoxClass" select="'ListView-PagingGoToBox'" />
      <xsl:param name="prmListViewPagingNumberSeperatorString" select="'[Skin.PagingNumberSeperatorFormat]'"/>
      <xsl:param name="prmListViewPagingLastButtonStyleClass" select="'ListView-PagingLastButtonStyle'" />
      <xsl:param name="prmListViewPagingFirstButtonStyleClass" select="'ListView-PagingFirstButtonStyle'" />
      <xsl:param name="prmListViewPagingNextButtonStyleClass" select="'ListView-PagingNextButtonStyle'" />
      <xsl:param name="prmListViewPagingPrevButtonStyleClass" select="'ListView-PagingPrevButtonStyle'" />
      <xsl:param name="prmIsEnabled" />

      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-Unselectable',' ',$prmListViewControlClass)" />
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$prmListViewControlClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      
      <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes"/>
      <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1"/>
      <xsl:variable name="varPagingHeight" select="[Skin.PagingPanelHeight]"/>

      <div style="width:100%;position:absolute;top:0px;bottom:{$varPagingHeight*number($varPaging)}px;">
        <div data-vwgfocuselement="1" tabindex="-1">
          <xsl:call-template name="tplApplyScrollableAttributes"/>
          <xsl:attribute name="style">
            width:100%;height:100%;
            <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
            <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
          </xsl:attribute>
          <xsl:if test="not($prmIsEnabled='0')">
            <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplListViewDrawLargeIconsRows">
            <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
            <xsl:with-param name="prmListViewGroupHeaderClass" select="$prmListViewGroupHeaderClass"/>
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
            <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass"/>
            <xsl:with-param name="prmListViewListLargeItem_SelectedClass" select="$prmListViewListLargeItem_SelectedClass" />

            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes"/>
          </xsl:call-template>
        </div>
      </div>
      <xsl:if test="$varPaging">
        <div class="{$prmListViewPagingPanelHeightClass} {$prmListViewPagingPanelStyleClass}" style="overflow:hidden;width:100%;position:absolute;bottom:0px;">
          <xsl:call-template name="tplDrawListViewPaging">
            <xsl:with-param name="prmListViewPagingFirstImageWidthClass" select="$prmListViewPagingFirstImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingLastImageWidthClass" select="$prmListViewPagingLastImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingPreviousImageWidthClass" select="$prmListViewPagingPreviousImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingNextImageWidthClass" select="$prmListViewPagingNextImageWidthClass"/>
            <xsl:with-param name="prmListViewPagingGoToBoxClass" select="$prmListViewPagingGoToBoxClass"/>
            <xsl:with-param name="prmListViewPagingNumberSeperatorString" select="$prmListViewPagingNumberSeperatorString"/>
            <xsl:with-param name="prmListViewPagingLastButtonStyleClass" select="$prmListViewPagingLastButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingFirstButtonStyleClass" select="$prmListViewPagingFirstButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingNextButtonStyleClass" select="$prmListViewPagingNextButtonStyleClass"/>
            <xsl:with-param name="prmListViewPagingPrevButtonStyleClass" select="$prmListViewPagingPrevButtonStyleClass"/>
          </xsl:call-template>
        </div>
      </xsl:if>
    </xsl:template>

    <!-- IMAGES -->
  <xsl:template name="tplListViewSourceCheckBox1">[Skin.Path]CheckBox1.gif.wgx</xsl:template>

  <xsl:template name="tplListViewSourceCheckBox0">[Skin.Path]CheckBox0.gif.wgx</xsl:template>

  <xsl:template name="tplListViewSourceHeaderSortAscending">[Skin.Path]HeaderSortAscending.gif.wgx</xsl:template>

  <xsl:template name="tplListViewSourceHeaderSortDescending">[Skin.Path]HeaderSortDescending.gif.wgx</xsl:template>  
  
</xsl:stylesheet>
