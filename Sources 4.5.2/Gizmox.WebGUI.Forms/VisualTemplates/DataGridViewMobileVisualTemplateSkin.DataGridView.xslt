<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
	xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and @Attr.VisualTemplate='DataGridViewVisualTemplateForMobile']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template  name="tplDrawDataGridViewVisualTemplateAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


  <xsl:template name="tplDrawDataGridViewVisualTemplateAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.DataGridView_KeyDown(',@Attr.Id,',window,event);')" />
    <xsl:variable name="varColumns" select="WG:Tags.DataGridViewColumn" />
    <xsl:variable name="varRows" select="WG:Tags.DataGridViewRow" />
    <xsl:variable name="varNonFrozenColumns" select="$varColumns[not(@Attr.Frozen='1')]" migration-select="xpath$([])" />
    <xsl:variable name="varFrozenColumns" select="$varColumns[@Attr.Frozen='1']" migration-select="xpath$([])" />
    <xsl:variable name="varNonFrozenRows" select="$varRows[not(@Attr.Frozen='1')]" migration-select="xpath$([])" />
    <xsl:variable name="varFrozenRows" select="$varRows[@Attr.Frozen='1']" migration-select="xpath$([])" />
    <xsl:variable name="varColumnHeadersHeight" select="@Attr.ColumnHeaders" />
    <xsl:variable name="varShowColumnHeaders" select="not($varColumnHeadersHeight='0')" />
    <xsl:variable name="varRowHeadersWidth" select="0" />
    <xsl:variable name="varShowRowHeaders" select="not($varRowHeadersWidth='0')" />
    <xsl:variable name="varFilterRow" select="$varRows[@Attr.FilterRow='1']" />

    <xsl:variable name="varIsHierarchic" select="@Attr.IsHierarchic" />
    <xsl:variable name="varExpansionIndicator" select="@Attr.ExpansionIndicator" />
    <xsl:variable name="varShouldDrawExpansionColumn" select="$varIsHierarchic='1' and not($varExpansionIndicator='2')" />
    <xsl:variable name="varExpansionColumnWidth">
      <xsl:choose>
        <xsl:when test="@Attr.DataGridViewHierarchyLevel &gt; 0 and not($varShouldDrawExpansionColumn)">[Skin.ExpandCollapseColumnWidth]</xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varNumberOfDisplayedColumns" select="@Attr.VisualTemplateDataGridViewNumberOfDisplayedColumns" />
    <xsl:variable name="varNewColumnsOrder" select="@Attr.VisualTemplateListViewNewColumnOrder" />
    <xsl:variable name="varFilterOperators" select="@Attr.VisualTemplateDataGridViewDataPagesFilterOptions" />

    <xsl:variable name="varColumnsWidth" migration-select="0" >
      <xsl:choose>
        <xsl:when test="$varShouldDrawExpansionColumn">
          <xsl:value-of select="sum($varNonFrozenColumns/@Attr.Width)+number([Skin.ExpandCollapseColumnWidth])" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="sum($varNonFrozenColumns/@Attr.Width)" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varRowsHeight" select="sum($varNonFrozenRows/@Attr.Height) + sum($varNonFrozenRows[@Attr.IsExpanded='1']/@Attr.ChildGridHeight)" migration-select="0" />
    <xsl:variable name="varFrozenColumnsWidth" select="0" migration-select="0" />
    <xsl:variable name="varFrozenRowsHeight" select="0" />
    <xsl:variable name="varFrozenHorizontalBlockHeight" >
      <xsl:choose>
        <xsl:when test="@Attr.DataGridViewHierarchyLevel &lt; 1">
          <xsl:value-of select="number($varColumnHeadersHeight)" migration-select="0" />
        </xsl:when>
        <xsl:otherwise>
          0
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varFrozenVerticalBlockWidth" select="number($varRowHeadersWidth+$varFrozenColumnsWidth)" migration-select="0" />
    <xsl:variable name="varGridId" select="@Attr.Id" />
    <xsl:variable name="varGridLines" select="'[Skin.GridLines]'"/>

    <xsl:attribute name="class">
      <xsl:text>Common-DefaultCursor DataGridView-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> DataGridView-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>


    <migration-write>
      <![CDATA[

varColumns.xeach(function(){

	if(this.attr("Attr.Frozen") == "1")
  {
    varFrozenColumns.push(this);
	  this.attr("Attr.Left", varFrozenColumnsWidth);
    varFrozenColumnsWidth+=$.xpath("number", this.attr("Attr.Width"));
  }
  else
  {
    varNonFrozenColumns.push(this);
	  this.attr("Attr.Left", varColumnsWidth);
    varColumnsWidth+=$.xpath("number", this.attr("Attr.Width"));
  }
});

if(varIsHierarchic && varIsHierarchic == "1")
{
  varColumnsWidth += [Skin.ExpandCollapseColumnWidth];
}

varRows.xeach(function(){

	if(this.attr("Attr.Frozen") == "1")
  {
    varFrozenRows.push(this);
	  this.attr("Attr.Top", varFrozenRowsHeight);
    varFrozenRowsHeight+=$.xpath("number", this.attr("Attr.Height"));
    
    if(this.attr("Attr.IsExpanded") == "1")
    {
      varFrozenRowsHeight+=$.xpath("number", this.attr("Attr.ChildGridHeight"));      
    }
  }
  else
  {
    varNonFrozenRows.push(this);
	  this.attr("Attr.Top", varRowsHeight);
    varRowsHeight+=$.xpath("number", this.attr("Attr.Height"));
    
    if(this.attr("Attr.IsExpanded") == "1")
    {
      varRowsHeight+=$.xpath("number", this.attr("Attr.ChildGridHeight"));      
    }
  }
});

varFrozenHorizontalBlockHeight = this.attr("Attr.DataGridViewHierarchyLevel") < 1 ? (Number(varColumnHeadersHeight) + Number(0)) : 0;
varFrozenVerticalBlockWidth = (Number(varRowHeadersWidth) + Number(varFrozenColumnsWidth));
]]>
    </migration-write>

    <div class="Common-FontData Common-Unselectable" style="width:100%;height:100%;position:relative;" dir="{$dir}" tabindex="-1" data-vwgfocuselement="1">
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:attribute name="onkeydown">
          <xsl:value-of select="$prmKeyDownHandler"/>
        </xsl:attribute>
        <xsl:call-template name="tplResgisterLostFocusEvent">
          <xsl:with-param name="prmHandler">
            mobjApp.DataGridView_OnBlur('<xsl:value-of select="$varGridId"/>',event,window);
          </xsl:with-param>
        </xsl:call-template>
      </xsl:if>

      <!-- Get caption height -->
      <xsl:variable name="varCaptionHeight">
        <xsl:choose>
          <xsl:when test="@Attr.IsCaptionVisible='1'">
            <xsl:value-of select="@Attr.VisualTemplateDataGridViewCaptionHeight" />
          </xsl:when>
          <xsl:otherwise>0</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <!--Draw caption-->
      <xsl:if test="@Attr.IsCaptionVisible='1'">
        <xsl:call-template name="tplDrawDataGridViewCaption"/>
      </xsl:if>

      <xsl:variable name="varIsGroupingDropAreaVisible" select="0"/>
      <xsl:variable name="varDropAreaHeight" select="@Attr.DropAreaHeight" />
      <xsl:variable name="varGroupingAreaHeight">
        <xsl:if test="$varIsGroupingDropAreaVisible='1'">
          <xsl:choose>
            <xsl:when test="number($varDropAreaHeight) &gt; 0">
              <xsl:value-of select="$varDropAreaHeight"/>
            </xsl:when>
            <xsl:otherwise>[Skin.DropAreaHeight]</xsl:otherwise>
          </xsl:choose>
        </xsl:if>
        <xsl:if test="not($varIsGroupingDropAreaVisible) or $varIsGroupingDropAreaVisible='0'">0</xsl:if>
      </xsl:variable>

      <xsl:if test="$varIsGroupingDropAreaVisible='1'">
        <!--Draw grouping drop area-->
        <xsl:call-template name="tplDrawDataGridViewGroupingDropArea">
          <xsl:with-param name="prmDropAreaHeight" select="$varGroupingAreaHeight" />
          <xsl:with-param name="prmDropAreaTop" select="$varCaptionHeight" />
        </xsl:call-template>
      </xsl:if>

      <xsl:variable name="varRowsData" select="Tags.ExtendedColumnHeaderRows/Tags.Row" />

      <xsl:variable name="varExtendedColumnsTotalHeight">
        <xsl:choose>
          <xsl:when test="Tags.ExtendedColumnHeaderCollection">
            <xsl:value-of select="sum($varRowsData/@Attr.Height)"/>
          </xsl:when>
          <xsl:otherwise>0</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <xsl:call-template name="tplDrawExtendedColumnHeaders">
        <xsl:with-param name="prmShouldDrawExpansionColumn" select="$varShouldDrawExpansionColumn" />
        <xsl:with-param name="prmExtendedColumnsTotalHeight" select="$varExtendedColumnsTotalHeight" />
        <xsl:with-param name="prmCaptionHeight" select="$varCaptionHeight" />
        <xsl:with-param name="prmGroupingAreaHeight" select="$varGroupingAreaHeight" />
        <xsl:with-param name="prmColumns" select="$varColumns" />
        <xsl:with-param name="prmFrozenVerticalBlockWidth" select="$varFrozenVerticalBlockWidth" />
        <xsl:with-param name="prmFrozenIndex" select="count($varFrozenColumns)" />
        <xsl:with-param name="prmRowsData" select="$varRowsData" />
        <xsl:with-param name="prmFrozenColumnsWidth" select="$varFrozenColumnsWidth" />
        <xsl:with-param name="prmRowHeadersWidth" select="$varRowHeadersWidth" />
        <xsl:with-param name="prmShowRowHeaders" select="$varShowRowHeaders" />
      </xsl:call-template>

      <!--Frozen Block-->
      <xsl:if test="$varFrozenHorizontalBlockHeight &gt; 0">
        <div style="position:absolute;height:{$varFrozenHorizontalBlockHeight}px;top:{number($varCaptionHeight) + $varExtendedColumnsTotalHeight}px;left:0px;right:0px;">
          <xsl:if test="$varShowRowHeaders or $varShowColumnHeaders or ($varFrozenColumnsWidth &gt; 0) or ($varFrozenRowsHeight &gt; 0)">
            <!-- Frozen Columns for Frozen rows section -->
            <!--<div style="position:absolute;width:{number($varFrozenColumnsWidth) + number($varRowHeadersWidth)}px;{$left}:0px;height:100%;top:0px;">

              --><!--Column headers corner--><!--
              <xsl:if test="$varShowRowHeaders and $varShowColumnHeaders and @Attr.ColumnsCount &gt; 0">
                <div style="position:absolute;top:0px;{$left}:0px;width:{$varRowHeadersWidth}px;height:{$varColumnHeadersHeight}px;">
                  <xsl:variable name="varHeaderCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']" />
                  <xsl:choose>
                    <xsl:when test="@Attr.ColumnChooser='1'">
                      <xsl:attribute name="class">DataGridView-RowHeader</xsl:attribute>
                      <xsl:call-template name="tplDrawColumnChooser" >
                        <xsl:with-param name="prmGridId" select="$varGridId" />
                        <xsl:with-param name="prmMemberId" select="$varHeaderCell/@Attr.MemberID" />
                      </xsl:call-template>
                    </xsl:when>
                    <xsl:when test="$varHeaderCell">
                      <xsl:attribute name="class">DataGridView-TopHeader</xsl:attribute>
                      <xsl:attribute name="onclick">
                        mobjApp.DataGridView_SelectAllGridRows('<xsl:value-of select="$varGridId"/>',window,event);
                      </xsl:attribute>
                      <xsl:apply-templates select="$varHeaderCell" />
                    </xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                </div>
              </xsl:if>--><!--

              --><!--Draw forzen column headers--><!--
              --><!--
              <xsl:if test="$varFrozenColumnsWidth &gt; 0">
                <div style="position:absolute;top:0px;{$left}:{$varRowHeadersWidth}px;height:{$varColumnHeadersHeight}px;width:{$varFrozenColumnsWidth}px;">
                  <xsl:for-each select="$varFrozenColumns">
                    <xsl:apply-templates select=".">
                      <xsl:with-param name="prmGridId" select="$varGridId"/>
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:apply-templates>
                  </xsl:for-each>
                </div>
              </xsl:if>--><!--

              --><!--Draw frozen row headers--><!--
              --><!--
              <xsl:if test="$varFrozenRowsHeight &gt; 0">
                <div class="DataGridView-Cells" style="position:absolute;top:{$varColumnHeadersHeight}px;{$left}:0px;width:{$varRowHeadersWidth}px;height:{$varFrozenRowsHeight}px;">
                  <xsl:for-each select="$varFrozenRows">
                    <xsl:variable name="varPrecedingRows" select="preceding-sibling::WG:Tags.DataGridViewRow" />
                    <xsl:variable name="varTop" select="sum($varPrecedingRows[@Attr.Frozen='1']/@Attr.Height)+sum($varPrecedingRows[@Attr.IsExpanded='1' and @Attr.Frozen='1']/@Attr.ChildGridHeight)" migration-select="{this}.attr(&quot;Attr.Top&quot;)" />
                    <div id="VWGROW1_{$varGridId}_{@Attr.MemberID}" style="position:absolute;width:100%;height:{@Attr.Height}px;{$left}:0px;top:{$varTop}px;">
                      <xsl:call-template name="tplDrawRowHeader" >
                        <xsl:with-param name="prmGridId" select="$varGridId" />
                        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                      </xsl:call-template>
                    </div>
                    <xsl:if test="@Attr.IsExpanded='1'">
                      <xsl:call-template name="tplDrawExpandedChildGridHeader">
                        <xsl:with-param name="prmChildGridHeight"  select="@Attr.ChildGridHeight" />
                        <xsl:with-param name="prmTop"  select="number($varTop)+number(@Attr.Height)" />
                      </xsl:call-template>
                    </xsl:if>
                  </xsl:for-each>
                </div>
              </xsl:if>--><!--

              --><!--Draw cells for forzen rows and frozen columns--><!--
              --><!--
              <xsl:if test="($varFrozenRowsHeight &gt; 0) and ($varFrozenColumnsWidth &gt; 0)">
                <div class="DataGridView-Cells" style="position:absolute;top:{$varColumnHeadersHeight}px;{$left}:{$varRowHeadersWidth}px;width:{$varFrozenColumnsWidth}px;height:{$varFrozenRowsHeight}px;">
                  <xsl:for-each select="$varFrozenRows">
                    <xsl:variable name="varRowTop1" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.Frozen='1']/@Attr.Height)" migration-select="{this}.attr(&quot;Attr.Top&quot;)" />
                    <div>
                      <xsl:attribute name="style">position:absolute;width:<xsl:value-of select="$varFrozenColumnsWidth"/>px;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$varRowTop1"/>px;<xsl:value-of select="$left"/>:0px;<xsl:if test="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]/WC:Tags.Panel">z-index:1;</xsl:if></xsl:attribute>
                      <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" migration-index="intCellPosition">
                        <xsl:variable name="varPosition" select="position()" migration-select="intCellPosition+1" />
                        <xsl:if test="$varColumns[position()=$varPosition]/@Attr.Frozen='1'" migration-test="varColumns.xposition(varPosition).attr('Attr.Frozen') == '1'">
                          <xsl:apply-templates select=".">
                            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                          </xsl:apply-templates>
                        </xsl:if>
                      </xsl:for-each>
                    </div>
                  </xsl:for-each>
                </div>
              </xsl:if>--><!--
            </div>-->
            <!-- Regular Columns for Frozen rows section -->
            <div id="VWGDGVFROZENCOLUMNS_{$varGridId}">
              <xsl:attribute name="style">
                position:absolute;height:100%;<xsl:value-of select="$right" />:0px;<xsl:value-of select="$left" />:<xsl:value-of select="$varFrozenColumnsWidth + $varRowHeadersWidth" />px;top:0px;overflow:hidden;
              </xsl:attribute>
              <div style="width:{$varColumnsWidth}px;">
                <!--Draw columns header-->
                <xsl:if test="$varShowColumnHeaders">
                  <div style="position:relative;top:0px;height:{$varColumnHeadersHeight}px;width:100%;overflow:hidden;">

                    <xsl:if test="$varShouldDrawExpansionColumn">
                      <div class="DataGridView-ColumnHeader DataGridView-ExpandCollapseColumn" style="float:{$left};height:100%;"></div>
                    </xsl:if>

                    <xsl:call-template name="tplDataGridViewVisualTemplateColumnsByNewColumnsOrder">
                      <xsl:with-param name="prmNewOrderColumnsList" select="$varNewColumnsOrder"/>
                      <xsl:with-param name="prmNumberOfDisplayedColumns" select="$varNumberOfDisplayedColumns" />

                      <xsl:with-param name="prmColumns" select="$varColumns"/>
                      <xsl:with-param name="prmGridId" select="$varGridId"/>
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:call-template>
                    <!--<xsl:for-each select="$varColumns">
                      <xsl:apply-templates select=".">
                        <xsl:with-param name="prmGridId" select="$varGridId"/>
                        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        <xsl:with-param name="prmNumberOfDisplayedColumns" select="$varNumberOfDisplayedColumns" />
                      </xsl:apply-templates>
                    </xsl:for-each>-->
                  </div>
                </xsl:if>

                <!--Draw cells for frozen rows and none frozen columns-->
                <!--
                <xsl:if test="$varFrozenRowsHeight &gt; 0">
                  <div style="position:relative;height:{$varFrozenRowsHeight}px;width:100%;">
                    <xsl:for-each select="$varFrozenRows">
                      <xsl:variable name="varPrecedingRows" select="preceding-sibling::WG:Tags.DataGridViewRow" />
                      <xsl:variable name="varRowTop2" select="sum($varPrecedingRows[@Attr.Frozen='1']/@Attr.Height)+sum($varPrecedingRows[@Attr.IsExpanded='1' and @Attr.Frozen='1']/@Attr.ChildGridHeight)" migration-select="{this}.attr(&quot;Attr.Top&quot;)" />

                      <xsl:if test="$varShouldDrawExpansionColumn">
                        <xsl:call-template name="tplDrawExpandCollapse">
                          <xsl:with-param name="prmIsExpanded" select="@Attr.IsExpanded" />
                          <xsl:with-param name="prmExpansionIndicator" select="$varExpansionIndicator" />
                          <xsl:with-param name="prmTop" select="$varRowTop2" />
                          <xsl:with-param name="prmGridId" select="$varGridId" />
                        </xsl:call-template>
                      </xsl:if>

                      <div>
                        <xsl:attribute name="style">position:absolute;width:<xsl:value-of select="$varColumnsWidth"/>px;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$varRowTop2"/>px;<xsl:if test="$varShouldDrawExpansionColumn"><xsl:value-of select="$left"/>:[Skin.ExpandCollapseColumnWidth]px;</xsl:if>;<xsl:if test="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]/WC:Tags.Panel">z-index:1;</xsl:if></xsl:attribute>
                        <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" migration-index="intCellIndex">
                          <xsl:variable name="varPosition" select="position()" migration-select="intCellIndex+1" />
                          <xsl:if test="not($varColumns[position()=$varPosition]/@Attr.Frozen='1')" migration-test="varColumns.xposition( varPosition).attr(&quot;Attr.Frozen&quot;)!='1'">
                            <xsl:apply-templates select=".">
                              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                            </xsl:apply-templates>
                          </xsl:if>
                        </xsl:for-each>
                      </div>

                      <xsl:if test="$varIsHierarchic='1' and @Attr.IsExpanded='1'">
                        <xsl:call-template name="tplDrawChildGrid">
                          <xsl:with-param name="prmChildGridHeight"  select="@Attr.ChildGridHeight" />
                          <xsl:with-param name="prmTop" select="number($varRowTop2)+number(@Attr.Height)" />
                          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        </xsl:call-template>
                      </xsl:if>
                    </xsl:for-each>
                  </div>
                </xsl:if>-->
              </div>
            </div>
          </xsl:if>

          <!-- In case if user is allowed to order column, draw the additional draggable div to make the columns dragging to the first position possible -->
          <xsl:if test="@Attr.AllowUserToOrderColumns and $varRowHeadersWidth = 0 ">
            <div style="position:absolute;{$left}:{$varRowHeadersWidth}px;top:0px;width:2px;height:100%;" data-vwgdragable="1" id="VWG_DGFDHC_{$varGridId}">
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="'100%'" />
                <xsl:with-param name="prmImageWidth"  select="'100%'" />
              </xsl:call-template>
            </div>
          </xsl:if>
        </div>

      </xsl:if>

      <xsl:variable name="varShowPaging" select="@Attr.TotalPages &gt; 1" />

      <!--Body-->
      <div>
        <xsl:attribute name="style">
          position:absolute;left:0px;right:0px;top:<xsl:value-of select="number($varGroupingAreaHeight) + number($varCaptionHeight) + number($varFrozenHorizontalBlockHeight) + $varExtendedColumnsTotalHeight"/>px;bottom:<xsl:choose>
            <xsl:when test="$varShowPaging">
              <xsl:value-of select="[Skin.PagingPanelHeight] + [Skin.BottomMenuHeight]" />
            </xsl:when>
            <xsl:otherwise>0</xsl:otherwise>
          </xsl:choose>px;
        </xsl:attribute>
        <!-- Frozen columns for regular rows -->
        <!--<div style="position:absolute;width:{number($varFrozenColumnsWidth) + number($varRowHeadersWidth)}px;{$left}:0px;height:100%;top:0px;">
          <div style="position:relative;overflow:hidden;height:100%;width:100%;">
            <div id="VWGDGVFROZENROWS_{$varGridId}" style="position:absolute;overflow:hidden;height:100%;width:{$varFrozenVerticalBlockWidth}px;">

              --><!--Draw rows header--><!--
              <xsl:if test="$varShowRowHeaders">
                <div style="height:{$varRowsHeight}px;width:{$varRowHeadersWidth}px;position:relative;float:{$left};" class="DataGridView-Cells">
                  <xsl:for-each select="$varRows">
                    <xsl:variable name="varPrecedingRows" select="preceding-sibling::WG:Tags.DataGridViewRow" />
                    <xsl:variable name="varTop" select="sum($varPrecedingRows[not(@Attr.Frozen='1')]/@Attr.Height)+sum($varPrecedingRows[@Attr.IsExpanded='1' and not(@Attr.Frozen='1')]/@Attr.ChildGridHeight)" migration-select="{this}.attr(&quot;Attr.Top&quot;)" />
                    <div id="VWGROW1_{$varGridId}_{@Attr.MemberID}" style="position:absolute;width:100%;height:{@Attr.Height}px;{$left}:0px;top:{$varTop}px;">
                      <xsl:call-template name="tplDrawRowHeader" >
                        <xsl:with-param name="prmGridId" select="$varGridId" />
                        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                      </xsl:call-template>
                    </div>
                    <xsl:if test="@Attr.IsExpanded='1'">
                      <xsl:call-template name="tplDrawExpandedChildGridHeader">
                        <xsl:with-param name="prmChildGridHeight"  select="@Attr.ChildGridHeight" />
                        <xsl:with-param name="prmTop"  select="number($varTop)+number(@Attr.Height)" />
                      </xsl:call-template>
                    </xsl:if>
                  </xsl:for-each>
                </div>
              </xsl:if>

              --><!--Draw cells for none forzen rows and frozen columns--><!--
              <xsl:if test="$varFrozenColumnsWidth &gt; 0">
                <div style="height:{$varRowsHeight}px;width:{$varFrozenColumnsWidth}px;position:relative;float:{$left};" class="DataGridView-Cells">
                  <xsl:for-each select="$varNonFrozenRows">
                    <xsl:variable name="varRowTop3" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[not(@Attr.Frozen='1')]/@Attr.Height)" migration-select="{this}.attr(&quot;Attr.Top&quot;)" />
                    <div>
                      <xsl:attribute name="style">
                        position:absolute;width:<xsl:value-of select="$varFrozenColumnsWidth"/>px;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$varRowTop3"/>px;<xsl:value-of select="$left"/>:0px;<xsl:if test="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]/WC:Tags.Panel">z-index:1;</xsl:if>
                      </xsl:attribute>
                      <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" migration-index="intCellIndex">
                        <xsl:variable name="varPosition" select="position()" migration-select="intCellIndex + 1" />
                        <xsl:if test="$varColumns[position()=$varPosition]/@Attr.Frozen='1'" migration-test="varColumns.xposition( varPosition).attr(&quot;Attr.Frozen&quot;)=='1'">
                          <xsl:apply-templates select=".">
                            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                          </xsl:apply-templates>
                        </xsl:if>
                      </xsl:for-each>
                    </div>
                  </xsl:for-each>
                </div>
              </xsl:if>
            </div>
          </div>
        </div>-->
        
        <div style="position:absolute;width:{$varExpansionColumnWidth}px;{$left}:0px;height:100%;top:0px;">
          <div style="position:relative;overflow:hidden;height:100%;width:100%;">
            <div id="VWGDGVFROZENROWS_{$varGridId}" style="position:absolute;overflow:hidden;height:100%;width:{$varExpansionColumnWidth}px;">
              <div style="height:{$varRowsHeight}px;width:{$varExpansionColumnWidth}px;position:relative;float:{$left};" class="DataGridView-Cells">
                <xsl:attribute name="style">
                  height:<xsl:value-of select="$varRowsHeight"/>px;width:<xsl:value-of select="$varExpansionColumnWidth"/>px;position:relative;float:<xsl:value-of select="$left"/>;
                  <xsl:value-of select="$varGridLines"/>;border-left:none;border-top:none;border-bottom:none;
                </xsl:attribute>
                </div>
            </div>
          </div>
        </div>

        <xsl:variable name="varScrollbars" select="@Attr.Scrollbars" />

        <xsl:call-template name="tplCompleteScrollCapabilities">
          <xsl:with-param name="prmScrollbars" select="$varScrollbars" />
          <xsl:with-param name="prmScrollMoveHandler" select="'mobjApp.DataGridView_iScrollSyncScrollers'"/>
        </xsl:call-template>
        <div id="VWGDGVBODY_{$varGridId}" onresize="mobjApp.DataGridView_SyncScrollers(window,this,'{$varGridId}','{$dir}');">
          <xsl:call-template name="tplApplyScrollableAttributes">
            <xsl:with-param name="prmCustomScrollingHandler" select="concat('mobjApp.DataGridView_SyncScrollers(window,this,&quot;',$varGridId,'&quot;,&quot;',$dir,'&quot;)')"/>
          </xsl:call-template>

          <xsl:attribute name="style">
            position:absolute;bottom:0px;<xsl:value-of select="$right" />:0px;<xsl:value-of select="$left" />:<xsl:value-of select="$varExpansionColumnWidth" />px;top:0px;<xsl:choose>
              <!-- Scrollbars None -->
              <xsl:when test="$varScrollbars and $varScrollbars = '0'">overflow:hidden;</xsl:when>
              <!-- Scrollbars Horizontal -->
              <xsl:when test="$varScrollbars and $varScrollbars = '1'">overflow-x:auto;overflow-y:hidden;</xsl:when>
              <!-- Scrollbars Vertical -->
              <xsl:when test="$varScrollbars and $varScrollbars = '2'">overflow-x:hidden;overflow-y:auto;</xsl:when>
              <!-- Scrollbars Both -->
              <xsl:otherwise>overflow:auto;</xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
          <div style="position:absolute;width:{$varColumnsWidth}px;height:{$varRowsHeight}px;top:0px;">
            <xsl:choose>
              <xsl:when test="(count($varNonFrozenColumns) &gt; 0) and (count($varNonFrozenRows) &gt; 0)">
                <div style="width:100%;position:absolute;{$left}:0px;top:0px;">
                  <xsl:apply-templates select="$varNonFrozenRows" >
                    <xsl:with-param name="prmColumns" select="$varColumns"/>
                    <xsl:with-param name="prmNonFrozenColumns"  select="$varNonFrozenColumns"/>
                    <xsl:with-param name="prmWidth" select="sum($varNonFrozenColumns/@Attr.Width)" />
                    <xsl:with-param name="prmFrozenColumns" select="$varFrozenColumns" />
                    <xsl:with-param name="prmGridId" select="$varGridId" />
                    <xsl:with-param name="prmSelectionMode" select="@Attr.SelectionMode" />
                    <xsl:with-param name="prmEnabled" select="not($prmIsEnabled='0')" />
                    <xsl:with-param name="prmIsHierarchic" select="$varIsHierarchic" />
                    <xsl:with-param name="prmExpansionIndicator" select="$varExpansionIndicator" />
                  </xsl:apply-templates>
                </div>
              </xsl:when>
              <xsl:otherwise>
                <div>&#160;</div>
              </xsl:otherwise>
            </xsl:choose>
          </div>
          <xsl:call-template name="tplRestoreScroll">
            <xsl:with-param name="prmGuid" select="@Attr.Id" />
          </xsl:call-template>
        </div>
      </div>

      <!--Paging-->
      <xsl:if test="$varShowPaging">
        <div class="DataGridView-PagingPanelStyle" style="height:[Skin.PagingPanelHeight]px;position:absolute;bottom:[Skin.BottomMenuHeight]px;left:0px;right:0px;">
          <xsl:call-template name="tplDrawDataGridViewPaging"/>
        </div>       
      </xsl:if>

      <xsl:if test="@Attr.DataGridViewHierarchyLevel &lt; 1">
        <div class="DataGridView-BottomMenu" style="height:[Skin.BottomMenuHeight]px;position:absolute;bottom:0px;left:0px;right:0px;">
          <xsl:call-template name="tplDrawDataGridViewBottomMenu">
            <xsl:with-param name="prmGridId" select="@Attr.Id"/>
          </xsl:call-template>
        </div>
      </xsl:if>
    </div>

    <xsl:if test="@Attr.DataGridViewHierarchyLevel &lt; 1">
    
    <div id="VWGDGVVIEWCONTAINER_{$varGridId}">
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="@VWGDGVVIEWCONTAINER='VWGDGVVIEWCONTAINER_'">DataGridView-ViewContainer</xsl:when>
          <xsl:otherwise><xsl:value-of select="'DataGridView-ViewContainer DataGridView-ViewContainer_Hidden'" /></xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplDrawDataGridViewViewPage">
        <xsl:with-param name="prmColumns" select="$varColumns" />
        <xsl:with-param name="prmNewColumnsOrder" select="$varNewColumnsOrder" />
      </xsl:call-template>
    </div>
    
    <div id="VWGDGVDISPLAYORDERCONTAINER_{$varGridId}">
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="@VWGDGVDISPLAYORDERCONTAINER='VWGDGVDISPLAYORDERCONTAINER_'">DataGridView-ViewContainer</xsl:when>
          <xsl:otherwise><xsl:value-of select="'DataGridView-ViewContainer DataGridView-ViewContainer_Hidden'" /></xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplDrawDataGridViewDisplayOrderPage">
        <xsl:with-param name="prmColumns" select="$varColumns" />
        <xsl:with-param name="prmNewColumnsOrder" select="$varNewColumnsOrder" />
      </xsl:call-template>
    </div>
    
    <div id="VWGDGVGROUPINGCONTAINER_{$varGridId}">
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="@VWGDGVGROUPINGCONTAINER='VWGDGVGROUPINGCONTAINER_'">DataGridView-ViewContainer</xsl:when>
          <xsl:otherwise><xsl:value-of select="'DataGridView-ViewContainer DataGridView-ViewContainer_Hidden'" /></xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplDrawDataGridViewGroupingPage">
      </xsl:call-template>
    </div>
    
    <div id="VWGDGVADDGROUPCONTAINER_{$varGridId}">
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="@VWGDGVADDGROUPCONTAINER='VWGDGVADDGROUPCONTAINER_'">DataGridView-ViewContainer</xsl:when>
          <xsl:otherwise><xsl:value-of select="'DataGridView-ViewContainer DataGridView-ViewContainer_Hidden'" /></xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplDrawDataGridViewAddGroupPage">
        <xsl:with-param name="prmColumns" select="$varColumns" />
        <xsl:with-param name="prmNewColumnsOrder" select="$varNewColumnsOrder" />
      </xsl:call-template>
    </div>
    
    <div id="VWGDGVSORTCONTAINER_{$varGridId}">
      <xsl:attribute name="class">
        <xsl:choose>
        <xsl:when test="@VWGVTCURRENTCONTAINER='VWGDGVSORTCONTAINER_'">DataGridView-SortContainer</xsl:when>
        <xsl:otherwise><xsl:value-of select="'DataGridView-SortContainer DataGridView-SortContainer_Hidden'"/></xsl:otherwise>
      </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplDrawDataGridViewSortingPage">
        <xsl:with-param name="prmColumns" select="$varColumns" />
      </xsl:call-template>
    </div>

    <div id="VWGDGVFILTERCONTAINER_{$varGridId}">
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="@VWGVTCURRENTCONTAINER='VWGDGVFILTERCONTAINER_'">DataGridView-FilterContainer</xsl:when>
          <xsl:otherwise><xsl:value-of select="'DataGridView-FilterContainer DataGridView-FilterContainer_Hidden'" /></xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:call-template name="tplDrawDataGridViewFilterPage">
        <xsl:with-param name="prmColumns" select="$varColumns" />
        <xsl:with-param name="prmFilterRow" select="$varFilterRow" />
      </xsl:call-template>
    </div>

    <xsl:if test="$varFilterOperators">
      <div id="VWGDGVFILTEROPERATORSCONTAINER_{$varGridId}">
        <xsl:attribute name="class">
          <xsl:choose>
            <xsl:when test="@VWGVTCURRENTCONTAINER='VWGDGVFILTEROPERATORSCONTAINER_'">DataGridView-FilterContainer</xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="'DataGridView-FilterContainer DataGridView-FilterContainer_Hidden'" />
            </xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        <xsl:call-template name="tplDrawDataGridViewFilterOperatorsPage">
          <xsl:with-param name="prmColumns" select="$varColumns" />
          <xsl:with-param name="prmFilterOperators" select="$varFilterOperators" />
        </xsl:call-template>
      </div>
    </xsl:if>
    
    </xsl:if>
    
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewViewPage">
    
    <xsl:param name="prmColumns"/>
    <xsl:param name="prmNewColumnsOrder"/>
    
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>
    <xsl:variable name="varTitleHeight" select="number($varRowsHeight) - 16"/>
    <xsl:variable name="varDataGridView" select="ancestor-or-self::WC:Tags.DataGridView" />
    <xsl:variable name="varGroupedColumns" select="$varDataGridView/WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView']/descendant::Tags.TreeNode" />
    
    <xsl:variable name="varQuickDetailsColumns">
      <xsl:for-each select="$prmColumns" migration-index="intColumnIndex">
        <xsl:if test="contains(concat($prmNewColumnsOrder, '|'), concat(position(), '|'))" migration-test="(prmNewColumnsOrder + '|').indexOf((intColumnIndex + 1)  + '|') != -1">
          <xsl:if test="position() &gt; 1" migration-test="intColumnIndex &gt; 0">, </xsl:if>
          <xsl:value-of select="WG:Tags.DataGridViewCell[@Attr.Type='7']/@Attr.Value" />
        </xsl:if>
      </xsl:for-each>
    </xsl:variable>

    <xsl:variable name="varGroupedColumnsString">
      <xsl:for-each select="$varGroupedColumns" migration-index="intColumnIndex">
        <xsl:if test="position() &gt; 1" migration-test="intColumnIndex &gt; 0">, </xsl:if>
        <xsl:value-of select="@Attr.Name" />
      </xsl:for-each>
    </xsl:variable>
    
    <xsl:call-template name="tplDrawDataGridViewViewCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>    
    </xsl:call-template>
    
    <div class="Common-FontData DataGridView-ViewColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px;">Display Layout</div>
      <div id="VWG_LLB_{$varGridId}" style="float:{$right};" class="DataGridView-ViewListLayoutButton_Disabled">
        <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ToggleDisplayLayout('<xsl:value-of select="$varGridId" />','ListLayoutButton',window,event);</xsl:attribute>
      </div>
      <div id="VWG_TLB_{$varGridId}" style="float:{$right};" class="DataGridView-ViewTableLayoutButton">
        <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ToggleDisplayLayout('<xsl:value-of select="$varGridId" />','TableLayoutButton',window,event);</xsl:attribute>
      </div>
    </div>
    
    <div class="Common-FontData Common-HandCursor DataGridView-ViewColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVDISPLAYORDERCONTAINER_',window,event);</xsl:attribute>
      <div style="line-height:{$varRowsHeight}px; display:inline-block;">
        <div class="DataGridView-ViewColumnText" style="line-height:{$varTitleHeight}px;display:block;">Display Order</div>
        <div class="DataGridView-ViewColumnText DataGridView-ViewSubTitle" style="line-height:16px;display:block;">
          <xsl:value-of select="$varQuickDetailsColumns" />
        </div>
      </div>
      <div style="float:{$right};" class="DataGridView-ViewColumnNext"></div>
    </div>
    
    <div class="Common-FontData Common-HandCursor DataGridView-ViewColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVGROUPINGCONTAINER_',window,event);</xsl:attribute>
      <div style="line-height:{$varRowsHeight}px; display:inline-block;">
        <div class="DataGridView-ViewColumnText" style="line-height:{$varTitleHeight}px;display:block;">Grouping</div>
        <div class="DataGridView-ViewColumnText DataGridView-ViewSubTitle" style="line-height:16px;display:block;">
          <xsl:value-of select="$varGroupedColumnsString" />
        </div>
      </div>
      <div style="float:{$right};" class="DataGridView-ViewColumnNext"></div>
      <div class="DataGridView-ViewColumnData" style="line-height:{$varRowsHeight}px;float:{$right};">
        <xsl:choose>
          <xsl:when test="count($varGroupedColumns)=0">Off</xsl:when>
          <xsl:otherwise>On</xsl:otherwise>
        </xsl:choose>
      </div> 
    </div>
    
  </xsl:template>
  
  <xsl:template name="tplDrawDataGridViewDisplayOrderPage">
    <xsl:param name="prmColumns"/>
    <xsl:param name="prmNewColumnsOrder"/>
    
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>
      
    <xsl:call-template name="tplDrawDataGridViewCommonCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>
      <xsl:with-param name="prmCaptionText" select="'Display Order'"/>
      <xsl:with-param name="prmShowBackButton" select="1"/>
      <xsl:with-param name="prmPreviousButtonText" select="'&lt;View'"/>
      <xsl:with-param name="prmPreviousButtonOnClickFunction">
        mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVDISPLAYORDERCONTAINER_' ,window,event);
        mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVVIEWCONTAINER_',window,event);
      </xsl:with-param>
    </xsl:call-template>
    
    <div class="Common-FontData DataGridView-ViewCategoryTitleColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px;">Quick Details</div>
    </div>
    
    <xsl:for-each select="$prmColumns" migration-index="intColumnIndex">
      <xsl:if test="contains(concat($prmNewColumnsOrder, '|'), concat(position(), '|'))" migration-test="(prmNewColumnsOrder + '|').indexOf((intColumnIndex + 1)  + '|') != -1">
        <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
        <xsl:variable name="varMemberID" select="$varContainedCell/@Attr.MemberID" />      
        <div id="VWG_V_{$varGridId}_{$varMemberID}" class="Common-FontData DataGridView-DisplayOrderColumnRow" style="height:{$varRowsHeight}px">
          <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$varContainedCell/@Attr.Value" />
            </xsl:call-template>
          </div>
        </div>
      </xsl:if>
    </xsl:for-each>
    
    <div class="Common-FontData DataGridView-ViewCategoryTitleColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px;">More Details</div>
    </div>
    
    <xsl:for-each select="$prmColumns" migration-index="intColumnIndex">
      <xsl:if test="not(contains(concat($prmNewColumnsOrder, '|'), concat(position(), '|')))" migration-test="(prmNewColumnsOrder + '|').indexOf((intColumnIndex + 1)  + '|') == -1">
        <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
        <xsl:variable name="varMemberID" select="$varContainedCell/@Attr.MemberID" />      
        <div id="VWG_V_{$varGridId}_{$varMemberID}" class="Common-FontData DataGridView-DisplayOrderColumnRow" style="height:{$varRowsHeight}px">
          <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$varContainedCell/@Attr.Value" />
            </xsl:call-template>
          </div>
        </div>
      </xsl:if>
    </xsl:for-each>
    
  </xsl:template>
  
  <xsl:template name="tplDrawDataGridViewAddGroupPage">
    <xsl:param name="prmColumns"/>
    <xsl:param name="prmNewColumnsOrder"/>
    
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>
    <xsl:variable name="varDataGridView" select="ancestor-or-self::WC:Tags.DataGridView" />
    <xsl:variable name="varGroupedColumns" select="$varDataGridView/WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView']/descendant::Tags.TreeNode" />
      
    <xsl:call-template name="tplDrawDataGridViewCommonCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>
      <xsl:with-param name="prmCaptionText" select="'Add Group'"/>
      <xsl:with-param name="prmShowBackButton" select="1"/>
      <xsl:with-param name="prmPreviousButtonText" select="'Cancel'"/>
      <xsl:with-param name="prmPreviousButtonOnClickFunction">
        mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVADDGROUPCONTAINER_' ,window,event);
        mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVGROUPINGCONTAINER_',window,event);
      </xsl:with-param>
    </xsl:call-template>

    <xsl:for-each select="$prmColumns" migration-index="intColumnIndex">
      <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
      <xsl:variable name="varIsColumnFromNewColumnsOrder" select="contains(concat($prmNewColumnsOrder, '|'), concat(position(), '|'))" migration-select="(prmNewColumnsOrder + '|').indexOf((intColumnIndex + 1)  + '|') != -1"/>
      <xsl:variable name="varIsNotGroupedColumn" select="not($varGroupedColumns[@Attr.Name=$varContainedCell/@Attr.Value])"/>

      <xsl:variable name="varAlreadyGroupedColumn" select="$varGroupedColumns[@Attr.Name=$varContainedCell/@Attr.Value]"/>

      <xsl:if test="$varIsColumnFromNewColumnsOrder and $varIsNotGroupedColumn">
        <xsl:variable name="varMemberID" select="$varContainedCell/@Attr.MemberID" />
        <div id="VWG_AG_{$varGridId}_{$varMemberID}" class="Common-FontData Common-HandCursor DataGridView-GroupColumnRow" style="height:{$varRowsHeight}px">
          <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_AddGroup('<xsl:value-of select="$varGridId" />','<xsl:value-of select="@Attr.MemberID" />',window,event);</xsl:attribute>
          <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$varContainedCell/@Attr.Value" />
            </xsl:call-template>
          </div>
        </div>
      </xsl:if>
    </xsl:for-each>
    
  </xsl:template>
  
  <xsl:template name="tplDrawDataGridViewGroupingPage">
    
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>
    <xsl:variable name="varDataGridView" select="ancestor-or-self::WC:Tags.DataGridView" />
    <xsl:variable name="varGroupedColumns" select="$varDataGridView/WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView']/descendant::Tags.TreeNode" />

    <xsl:call-template name="tplDrawDataGridViewCommonCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>
      <xsl:with-param name="prmCaptionText" select="'Grouping'"/>
      <xsl:with-param name="prmShowBackButton" select="1"/>
      <xsl:with-param name="prmPreviousButtonText" select="'&lt;View'"/>
      <xsl:with-param name="prmPreviousButtonOnClickFunction">
        mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVGROUPINGCONTAINER_' ,window,event);
        mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVVIEWCONTAINER_',window,event);
      </xsl:with-param>
    </xsl:call-template>
    
    <div class="Common-FontData DataGridView-ViewColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px;">View by Groups</div>
      <div id="VWG_VBG_{$varGridId}" style="float:{$right};">
        <xsl:attribute name="class">DataGridView-ViewByGroupsButton<xsl:if test="count($varGroupedColumns)=0">_Disabled</xsl:if></xsl:attribute>
        <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ToggleViewByGroups('<xsl:value-of select="$varGridId" />','DataGridView-GroupOrderContainer',window,event);</xsl:attribute>
      </div>
    </div>
    
    <div id="VWGDGVGROUPORDERCONTAINER_{$varGridId}">
      <xsl:attribute name="class">DataGridView-GroupOrderContainer
        <xsl:if test="count($varGroupedColumns)=0">DataGridView-GroupOrderContainer_Hidden</xsl:if>
      </xsl:attribute>
      <div class="Common-FontData DataGridView-ViewCategoryTitleColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
        <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px;">Group order</div>
      </div>

      <xsl:for-each select="$varGroupedColumns" migration-index="intColumnIndex">
        <div class="Common-FontData DataGridView-GroupColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
          <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="@Attr.Name" migration-select="{this}.attr(&quot;Attr.Name&quot;)" />
            </xsl:call-template>
          </div>
        </div>
      </xsl:for-each>
      
      <div class="Common-FontData Common-HandCursor DataGridView-AddGroupColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
        <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$varGridId" />','DataGridView-ViewContainer', 'VWGDGVADDGROUPCONTAINER_',window,event);</xsl:attribute>
        <div id="VWG_AGB_{$varGridId}" style="float:{$left};" class="DataGridView-AddGroupButton"></div>
        <div class="DataGridView-ViewColumnText" style="line-height:{$varRowsHeight}px;">Add Group</div>
      </div>
    </div>
    
  </xsl:template>
    

  <xsl:template name="tplDrawDataGridViewSortingPage">
    <xsl:param name="prmColumns"/>
      
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>

    <xsl:call-template name="tplDrawDataGridViewSortCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>    
    </xsl:call-template>

    <xsl:variable name="varCurrentColumnWithOrder" select="$prmColumns/descendant::WG:Tags.DataGridViewCell[@Attr.SortOrder]" />
    <xsl:variable name="varCurrentSortOrder" select="$varCurrentColumnWithOrder/@Attr.SortOrder"/>

    <div class="DataGridView-SortColumnRow" style="width:100%;height:{$varRowsHeight}px;line-height:{$varRowsHeight}px">
      <div>
        <xsl:attribute name="class">
          <xsl:choose>
            <xsl:when test="$varCurrentSortOrder='0'">
              <xsl:value-of select="concat('DataGridView-GenericButton ', 'DataGridView-GenericButton_Selected')"/>
            </xsl:when>
            <xsl:otherwise>DataGridView-GenericButton</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        Ascending
      </div>
      <div class="">
        <xsl:attribute name="class">
          <xsl:choose>
            <xsl:when test="$varCurrentSortOrder='1'">
              <xsl:value-of select="concat('DataGridView-GenericButton ', 'DataGridView-GenericButton_Selected')"/>
            </xsl:when>
            <xsl:otherwise>DataGridView-GenericButton</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>Descending
      </div>
    </div>

    <xsl:for-each select="$prmColumns">
      <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
      <xsl:variable name="varMemberID" select="$varContainedCell/@Attr.MemberID" />      
      <div id="VWG_{$varGridId}_{$varMemberID}" class="DataGridView-SortColumnRow" style="height:{$varRowsHeight}px">
        <div class="DataGridView-SortColumnText" style="line-height:{$varRowsHeight}px">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="$varContainedCell/@Attr.Value" />
          </xsl:call-template>
        </div>
        <div style="{$right}:0px;">
          <xsl:attribute name="Class"><xsl:if test="$varContainedCell/@Attr.SortOrder">DataGridView-SortColumnCheck</xsl:if></xsl:attribute>
        </div>
      </div>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewFilterPage">
    <xsl:param name="prmColumns"/>
    <xsl:param name="prmFilterRow"/>
    <xsl:param name="prmClearAllFiltersButtonClass" select="'DataGridView-ClearAllFiltersButton'"/>    
    <xsl:param name="prmClearAllFiltersToolTip" select="'[Skin.ClearAllFiltersToolTip]'"/>
    
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>

    <xsl:call-template name="tplDrawDataGridViewFilterCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>
      <xsl:with-param name="prmCaptionText" select="'Filter'" />
    </xsl:call-template>
  
      
   <xsl:for-each select="$prmColumns" migration-index="intColumnIndex">
      <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
      <xsl:variable name="varMemberID" select="$varContainedCell/@Attr.MemberID" />
      <!--NOTE: Here, the index is increased by 2, because there is one row missing in the prmColumns that exists in the filterrow columns-->
      <xsl:variable name="varRowIndex" select="position()" migration-select="intColumnIndex+2" />
      <xsl:variable name="varFilterRowColumn" select="$prmFilterRow/WG:Tags.DataGridViewCell[position()=$varRowIndex]" migration-select="prmFilterRow.xpath(&quot;WG:Tags.DataGridViewCell&quot;).xposition(varRowIndex)" />
      <div id="VWG_F_{$varGridId}_{$varMemberID}" class="Common-FontData Common-HandCursor DataGridView-FilterColumnRow" style="height:{$varRowsHeight}px;">        
        <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseOne('<xsl:value-of select="$varGridId"/>','<xsl:value-of select="$varFilterRowColumn/@Attr.MemberID"/>','DataGridView-FilterContainer' ,'VWGDGVFILTEROPERATORSCONTAINER_', window, event);</xsl:attribute>        
        <div class="DataGridView-FilterColumnText" style="line-height:{$varRowsHeight}px;">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="$varContainedCell/@Attr.Value" />
          </xsl:call-template>
        </div>
        <div style="float:{$right};" class="DataGridView-FilterColumnNext"></div>
        <div class="DataGridView-FilterColumnData" style="line-height:{$varRowsHeight}px;float:{$right};">
          <xsl:call-template name="tplDataGridViewCurrentColumnFilterName">   
            <xsl:with-param name="prmFilterRowColumn" select="$varFilterRowColumn" />          
          </xsl:call-template>
        </div>        
      </div>
    </xsl:for-each>
    
    <div class="Common-FontData Common-Unselectable Common-AlignCenter Common-HandCursor Common-VAlignMiddle DataGridView-FilterColumnRow" style="height:{$varRowsHeight}px;width:100%;line-height:{$varRowsHeight}px;" dir="{$dir}" onclick="mobjApp.DataGridView_ClearFilters('{$varGridId}', window, event);">              
        <div class="DataGridView-FilterColumnText">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="'Clear all filters'" />
          </xsl:call-template>
        </div>
        <div title="{$prmClearAllFiltersToolTip}" class="{$prmClearAllFiltersButtonClass}">
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
    </div>
    
    <div id="VWGDGVVTCOLUMNCONTAINER_{$varGridId}" class="DataGridView-FilterContainer DataGridView-FilterContainer_Hidden"></div>
  </xsl:template>
  
  
  <xsl:template name="tplDataGridViewCurrentColumnFilterName">
    <xsl:param name="prmFilterRowColumn"/>
    
    <xsl:variable name="varSelectedFilterValue" select="$prmFilterRowColumn/descendant::WC:Tags.ComboBox[string-length(@Attr.Text) > 0]" />
    
    <xsl:choose>
      <xsl:when test="$varSelectedFilterValue">
        <xsl:call-template name="tplDecodeTextAsHtml">
          <xsl:with-param name="prmText" select="$varSelectedFilterValue/@Attr.Text" />
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplDecodeTextAsHtml">
          <xsl:with-param name="prmText" select="'No filter'" />
        </xsl:call-template>
      </xsl:otherwise>
      </xsl:choose>
  </xsl:template>
  
  
  <xsl:template name="tplDrawDataGridViewFilterOperatorsPage">
    <xsl:param name="prmColumns"/>
    <xsl:param name="prmFilterOperators"/>
    
    <xsl:variable name="varGridId" select="@Attr.Id"/> 
    <xsl:variable name="varRowsHeight" select="@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>
    <xsl:variable name="varMemberId" select="@VTCURRENTMEMBERID"/>

    <xsl:call-template name="tplDrawDataGridViewFilterCaption" >
      <xsl:with-param name="prmGridId" select="$varGridId"/>
      <xsl:with-param name="prmCaptionText" select="'Filter operators'" />
    </xsl:call-template>


    <xsl:call-template name="tplDataGridViewVisualTemplateFilterOperatorItems">
      <xsl:with-param name="prmFilterOperatorItems" select="$prmFilterOperators" />
      <xsl:with-param name="prmGridId" select="$varGridId"/>
      <xsl:with-param name="prmMemberId" select="$varMemberId"/>
      <xsl:with-param name="prmRowsHeight" select="$varRowsHeight"/>
    </xsl:call-template>
      
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewFilterOperatorsRow">
    <xsl:param name="prmOperatorText"/>
    <xsl:param name="prmOperatorImage"/>
    <xsl:param name="prmOperatorIndex"/>
    <xsl:param name="prmGridId"/>
    <xsl:param name="prmMemberId"/>
    <xsl:param name="prmRowsHeight"/>
    

    <div id="VWG_FO_{$prmGridId}_{$prmMemberId}" class="DataGridView-FilterColumnRow" style="height:{$prmRowsHeight}px;">
      <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseThree('<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="$prmMemberId"/>','<xsl:value-of select="$prmOperatorIndex"/>','DataGridView-FilterContainer' ,'VWGDGVVTCOLUMNCONTAINER_','VWGDGVFILTEROPERATORSCONTAINER_', window, event);</xsl:attribute>
      <div class="DataGridView-FilterColumnText" style="line-height:{$prmRowsHeight}px;">
        <xsl:call-template name="tplDecodeTextAsHtml">
          <xsl:with-param name="prmText" select="$prmOperatorText" />
        </xsl:call-template>
      </div>
      <div class="DataGridView-FilterColumnNext DataGridView-FilterColumnNextOperatorImage">
        <xsl:attribute name="style">background-image:url(<xsl:value-of select="$prmOperatorImage"/>);float:<xsl:value-of select="$right"/>;"</xsl:attribute>
      </div>      
    </div>
  </xsl:template>

  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile') and (@VTFUNCTION='on')]/WG:Tags.DataGridViewRow[@Attr.FilterRow='1']/WG:Tags.DataGridViewCell[@Attr.Type='8']">
    <xsl:variable name="varRowId" select="@Attr.MemberID" />
    <xsl:variable name="varColumnId" select="concat('C', substring-after($varRowId,'D'))" />
    <xsl:variable name="varDataGridView" select="ancestor-or-self::WC:Tags.DataGridView" />
    <xsl:variable name="varColumn" select="$varDataGridView/descendant-or-self::WG:Tags.DataGridViewColumn[@Attr.MemberID=$varColumnId]" migration-select="varDataGridView.xpath(&quot;descendant-or-self::node()[@Attr.MemberID =\&quot;&quot; + varColumnId + &quot;\&quot;]&quot;)"/>
    <xsl:variable name="varFilterCaption" select="$varColumn/@Attr.Name"/>
    <xsl:variable name="varCaptionHeight" select="$varDataGridView/@Attr.VisualTemplateDataGridViewCaptionHeight" />
    <xsl:variable name="varFilterComboBox" select="descendant::WC:Tags.ComboBox" />
    <xsl:variable name="varFilterComboBoxOptions" select="$varFilterComboBox/Tags.Options" />
    <xsl:variable name="varFilterSelectedIndex" select="$varFilterComboBox/@Attr.Value" />
    <xsl:variable name="varGridId" select="$varDataGridView/@Id"/>
    <xsl:variable name="varRowsHeight" select="$varDataGridView/@Attr.VisualTemplateDataGridViewDataPagesRowHeight"/>
    <div>
      <div style="height:{$varCaptionHeight}px">
        <div class="Common-FontData Common-Unselectable DataGridView-Caption" style="width:100%;height:100%;line-height:{$varCaptionHeight}px" dir="{$dir}" >
          <div class="DataGridView-GenericButton" style="float:{$left}">
            <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$varGridId" />','DataGridView-FilterContainer', 'VWGDGVVTCOLUMNCONTAINER_' ,window,event);</xsl:attribute>Filters</div>
          <div class="Common-AlignCenter Common-VAlignMiddle DataGridView-CaptionText">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$varFilterCaption" />
            </xsl:call-template>
          </div>
        </div>
      </div>

      <xsl:for-each select="$varFilterComboBoxOptions/Tags.Option">
        <xsl:variable name="varIndex" select="@Attr.Index" />
        <div id="VWG_FO_{$varGridId}_{$varRowId}" class="DataGridView-FilterColumnRow" style="height:{$varRowsHeight}px;">
          <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_SetFilterValue('<xsl:value-of select="$varFilterComboBox/@Id"/>','<xsl:value-of select="$varIndex"/>','DataGridView-FilterContainer' ,'VWGDGVVTCOLUMNCONTAINER_', window, event);</xsl:attribute>
          <div class="DataGridView-FilterColumnText" style="line-height:{$varRowsHeight}px;">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="@Attr.Text" />
            </xsl:call-template>
          </div>
          <div style="float:{$right};" class="DataGridView-FilterColumnCheck">
            <xsl:attribute name="style">float:<xsl:value-of select="$right"/>;<xsl:if test="not($varIndex=$varFilterSelectedIndex)">display:none;</xsl:if></xsl:attribute>
          </div>        
        </div>
      </xsl:for-each>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewBottomMenu">
    <xsl:param name="prmGridId" />
    
    <xsl:variable name="varBottomMenuButtonWidth" select="[Skin.BottomMenuButtonWidth] div 2" />
    <div class="DataGridView-BottomMenuButton DataGridView-ViewBottomMenuButton" style="left:0px;">
      <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$prmGridId" />','DataGridView-ViewContainer', 'VWGDGVVIEWCONTAINER_',window,event);</xsl:attribute>
    </div>
    <div class="DataGridView-BottomMenuButton DataGridView-SortBottomMenuButton" style="left:50%;margin-left:-{$varBottomMenuButtonWidth}px;">
      <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$prmGridId" />','DataGridView-SortContainer', 'VWGDGVSORTCONTAINER_',window,event);</xsl:attribute>
    </div>
    <div class="DataGridView-BottomMenuButton DataGridView-FilterBottomMenuButton" style="right:0px;">
      <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_ShowContainer('<xsl:value-of select="$prmGridId" />','DataGridView-FilterContainer', 'VWGDGVFILTERCONTAINER_',window,event);</xsl:attribute></div>
  </xsl:template>

  <xsl:template name="tplDrawChildGrid">
    <xsl:param name="prmChildGridHeight" />
    <xsl:param name="prmTop" />
    <xsl:param name="prmWidth" select="'100%'" />
    <xsl:param name="prmIsEnabled" />

    <div data-vwgtype="container">
      <xsl:attribute name="style">
        position:absolute;width:<xsl:value-of select="$prmWidth"/>;height:<xsl:value-of select="$prmChildGridHeight"/>px;top:<xsl:value-of select="$prmTop"/>px;<xsl:value-of select="$left"/>:0px;
      </xsl:attribute>
      <xsl:apply-templates select="./*" mode="modChildGrid" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawExpandedChildGridHeader">
    <xsl:param name="prmTop" />
    <xsl:param name="prmChildGridHeight" />
    <div class="DataGridView-ExpandButtonRowHeader" style="position:absolute;width:100%;height:{$prmChildGridHeight}px;{$left}:0px;top:{$prmTop}px;">&#160;</div>
  </xsl:template>

  <xsl:template name="tplDrawColumnChooser">
    <xsl:param name="prmGridId" />
    <xsl:param name="prmMemberId" />
    <div id="VWG_{$prmGridId}_{$prmMemberId}" style="text-align:center;height:100%;width:100%;" data-vwgdragable="1">
      <div class="DataGridView-ColumnChooser" style="margin:0 auto;height:100%;width:50%;">
        <xsl:attribute name="onclick">
          mobjApp.DataGridView_OpenColumnChooser('<xsl:value-of select="$prmGridId" />',window,event);
        </xsl:attribute>
        <xsl:attribute name="title">
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="'Labels.GridColumnChooser'"/>
          </xsl:call-template>
        </xsl:attribute>
      </div>
    </div>
  </xsl:template>

  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile')]/WG:Tags.DataGridViewCell[@Attr.Type='7']">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawDataGridViewHeaderCell">
      <xsl:with-param name="prmGridId" select="../@Attr.Id"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


  <xsl:template name="tplDrawDataGridViewHeaderCell">
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmMemberId" />

    <div data-vwgdragable="1">
      <xsl:attribute name="style">
        height:100%;width:100%;overflow:hidden;
        <xsl:call-template name="tplApplyPaddings"/>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="1" />
          <xsl:with-param name="prmCursor" select="0" />
        </xsl:call-template>
      </xsl:attribute>
      <!--<xsl:call-template name="tplSetToolTip">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>-->

      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmText" select="@Attr.Value"/>
        <xsl:with-param name="prmTextClass" select="'Common-FontData Common-Unselectable DataGridView-RowHeaderText'"/>
        <xsl:with-param name="prmTextAlign" select="@Attr.TextAlign" />
        <xsl:with-param name="prmImageAlign" select="'CenterMiddle'" />
        <xsl:with-param name="prmTextImageRelation" select="8" />
        <xsl:with-param name="prmLayoutPadding" select="0" />
      </xsl:call-template>
    </div>
  </xsl:template>


  <xsl:template name="tplDrawExtendedColumnHeaders">
    <xsl:param name="prmShouldDrawExpansionColumn" />
    <xsl:param name="prmExtendedColumnsTotalHeight" />
    <xsl:param name="prmCaptionHeight" />
    <xsl:param name="prmGroupingAreaHeight" />
    <xsl:param name="prmColumns" />
    <xsl:param name="prmFrozenVerticalBlockWidth" />
    <xsl:param name="prmFrozenIndex" />
    <xsl:param name="prmRowsData" />
    <xsl:param name="prmFrozenColumnsWidth" />
    <xsl:param name="prmRowHeadersWidth" />
    <xsl:param name="prmShowRowHeaders" />

    <!--********************************************************************** Extended Column Headers ***************************************************************-->

    <xsl:variable name="varExpansionColumnWidth">
      <xsl:choose>
        <xsl:when test="$prmShouldDrawExpansionColumn">[Skin.ExpandCollapseColumnWidth]</xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:if test="not($prmExtendedColumnsTotalHeight=0)">
      <div style="left:0px;right:0px;position:absolute;top:{$prmCaptionHeight + $prmGroupingAreaHeight}px;height:{$prmExtendedColumnsTotalHeight}px;">
        <xsl:variable name="varPanels" select="Tags.ExtendedColumnHeaderCollection/WC:Tags.UserControl[not(@Attr.ExtendedPanelType)]" />

        <!--Non-Frozen-->
        <div id="XCH_{@Attr.Id}" class="DataGridView-ExtendedColumnsNonFrozen" style="{$right}:0px;{$left}:{$prmFrozenVerticalBlockWidth}px;height:100%;position:absolute;top:0px;overflow:hidden;" >
          <div style="position:absolute;top:0px;{$left}:0px;height:100%;width:100%;">
            <!--Extended Expantion column-->
            <xsl:if test="$prmShouldDrawExpansionColumn">
              <div style="position:absolute;{$left}:0px;top:0px;height:100%;" class="DataGridView-ExpandCollapseColumn">
                <xsl:for-each select="Tags.ExtendedColumnHeaderCollection/WC:Tags.UserControl[@Attr.ExtendedPanelType='2']" >
                  <xsl:call-template name="tplDrawExtendedHeaderControl">
                    <xsl:with-param name="prmCell" select="." />
                    <xsl:with-param name="prmColumns" select="$prmColumns" />
                    <xsl:with-param name="prmRowsData" select="$prmRowsData" />
                  </xsl:call-template>
                </xsl:for-each>
              </div>
            </xsl:if>
            <div style="{$left}:{$varExpansionColumnWidth}px;position:absolute;top:0px;height:100%;">
              <xsl:for-each select="$varPanels[@Attr.ColumnIndex &gt; ($prmFrozenIndex - 1)]">
                <xsl:call-template name="tplDrawExtendedHeaderControl">
                  <xsl:with-param name="prmCell" select="." />
                  <xsl:with-param name="prmColumns" select="$prmColumns" />
                  <xsl:with-param name="prmOffsetDelta" select="$prmFrozenColumnsWidth" />
                  <xsl:with-param name="prmRowsData" select="$prmRowsData" />
                </xsl:call-template>
              </xsl:for-each>
            </div>
          </div>
        </div>

        <!--Frozen-->
        <div class="DataGridView-ExtendedColumnsFrozen" style="position:absolute;{$left}:{$prmRowHeadersWidth}px;top:0px;width:{$prmFrozenColumnsWidth}px;height:100%;">
          <xsl:for-each select="$varPanels[@Attr.ColumnIndex &lt;= ($prmFrozenIndex - 1)]" >
            <xsl:call-template name="tplDrawExtendedHeaderControl">
              <xsl:with-param name="prmCell" select="." />
              <xsl:with-param name="prmColumns" select="$prmColumns" />
              <xsl:with-param name="prmRowsData" select="$prmRowsData" />
            </xsl:call-template>
          </xsl:for-each>
        </div>

        <!--Extended Corner-->
        <xsl:if test="$prmShowRowHeaders">
          <div class="DataGridView-ExtendedColumnsCorner" style="position:absolute;{$left}:0px;top:0px;width:{$prmRowHeadersWidth}px;height:100%;">
            <xsl:for-each select="Tags.ExtendedColumnHeaderCollection/WC:Tags.UserControl[@Attr.ExtendedPanelType='1']" >
              <xsl:call-template name="tplDrawExtendedHeaderControl">
                <xsl:with-param name="prmCell" select="." />
                <xsl:with-param name="prmColumns" select="$prmColumns" />
                <xsl:with-param name="prmRowsData" select="$prmRowsData" />
              </xsl:call-template>
            </xsl:for-each>
          </div>
        </xsl:if>
      </div>
    </xsl:if>

    <!--********************************************************************** Extended Column Headers - END ***************************************************************-->
  </xsl:template>


  <xsl:template name="tplDrawExtendedHeaderControl">
    <xsl:param name="prmCell" />
    <xsl:param name="prmColumns" />
    <xsl:param name="prmOffsetDelta" select="0" />
    <xsl:param name="prmRowsData" />

    <xsl:variable name="varRow" select="number(@Attr.RowIndex) + 1" />

    <xsl:variable name="varRowSpan">
      <xsl:choose>
        <xsl:when test="@Attr.Rowspan">
          <xsl:value-of select="number(@Attr.Rowspan)"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="number(1)" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varPositionTop" select="sum($prmRowsData[position() &lt; $varRow]/@Attr.Height)" migration-select="0"/>
    <xsl:variable name="varHeight" select="sum($prmRowsData[position() &gt;= $varRow and position() &lt; ($varRow + $varRowSpan)]/@Attr.Height)" migration-select="0"/>

    <xsl:variable name="varCol">
      <xsl:choose>
        <xsl:when test="@Attr.ColumnIndex">
          <xsl:value-of select="number(@Attr.ColumnIndex) + 1"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="number(1)"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varColSpan">
      <xsl:choose>
        <xsl:when test="@Attr.Colspan">
          <xsl:value-of select="number(@Attr.Colspan)"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="number(1)" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varPositionLeft" migration-select="0">
      <xsl:choose>
        <xsl:when test="@Attr.ColumnIndex">
          <xsl:value-of select="sum($prmColumns[position() &lt; $varCol]/@Attr.Width) - $prmOffsetDelta"/>px
        </xsl:when>
        <xsl:otherwise>0px</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varWidth" migration-select="0">
      <xsl:choose>
        <xsl:when test="@Attr.ColumnIndex">
          <xsl:value-of select="sum($prmColumns[position() &gt;= $varCol and position() &lt; ($varCol + $varColSpan)]/@Attr.Width)"/>px
        </xsl:when>
        <xsl:otherwise>100%</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <migration-write>
      <![CDATA[
            if(this.hasAttr('Attr.ColumnIndex'))
            {
                varPositionLeft = -parseInt(prmOffsetDelta);
                for(var i = 1; i < varCol ; ++i)
                {
                    varPositionLeft += parseInt(prmColumns.xposition(i).attr("Attr.Width"));
                }
                varPositionLeft += 'px';
                for(var i = varCol; i < (parseInt(varCol) + parseInt(varColSpan)) ; ++i)
                {
                    varWidth += parseInt(prmColumns.xposition(i).attr("Attr.Width"));
                }
                varWidth += 'px';
            }
            else
            {
                varPositionLeft = '0px';
                varWidth = '100%';
            }
            
            for(var i = 1; i < varRow ; ++i)
            {
                varPositionTop += parseInt(prmRowsData.xposition(i).attr("Attr.Height"));
            }
            for(var i = varRow; i < (varRow + parseInt(varRowSpan)) ; ++i)
            {
                varHeight += parseInt(prmRowsData.xposition(i).attr("Attr.Height"));
            }
          ]]>
    </migration-write>
    <div style="position:absolute;height:{$varHeight}px;width:{$varWidth};{$left}:{$varPositionLeft};top:{$varPositionTop}px;">
      <xsl:apply-templates select="."  />
    </div>
  </xsl:template>


  <!--Draw grouping drop area-->
  <xsl:template name="tplDrawDataGridViewGroupingDropArea">
    <xsl:param name="prmDropAreaHeight" />
    <xsl:param name="prmDropAreaTop" />
    <xsl:param name="prmEmptyDropAreaMessage" select="'[Skin.GroupingDropAreaEmptyMessage]'"/>
    <xsl:param name="prmEmptyDropAreaMessageAlign" select="'[Skin.GroupingDropAreaEmptyMessageAlign]'"/>
    <xsl:variable name="varId" select="@Attr.Id" />
    <xsl:variable name="varGroupingAreaBackColor" select="@Attr.GroupingAreaBackColor"/>
    <xsl:variable name="varGroupingAreaBorder" select="@Attr.GroupingAreaBorder"/>
    <xsl:variable name="varGroupingAreaBackgroundImage" select="@Attr.GroupingAreaBackgroundImage"/>
    <xsl:variable name="varGroupingAreaBackgroundImagePositionAttribute" select="@Attr.GroupingAreaBackgroundImagePosition"/>
    <xsl:variable name="varGroupingAreaBackgroundImagePosition">
      <xsl:choose>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='0'">center bottom</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='1'">left bottom</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='2'">right bottom</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='4'">left center</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='5'">right center</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='6'">center top</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='7'">left top</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImagePositionAttribute='8'">right top</xsl:when>
        <xsl:otherwise>center center</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varGroupingAreaBackgroundImageRepeatAttribute" select="@Attr.GroupingAreaBackgroundImageRepeat"/>
    <xsl:variable name="varGroupingAreaBackgroundImageRepeat">
      <xsl:choose>
        <xsl:when test="$varGroupingAreaBackgroundImageRepeatAttribute='0'">no-repeat</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImageRepeatAttribute='2'">repeat-x</xsl:when>
        <xsl:when test="$varGroupingAreaBackgroundImageRepeatAttribute='3'">repeat-y</xsl:when>
        <xsl:otherwise>repeat</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <!--<div class="DataGridView-GroupingDropArea" id="VWGDGVTV_{$varId}">
      <xsl:attribute name="style">
        position:absolute;top:<xsl:value-of select="$prmDropAreaTop" />px;height:<xsl:value-of select="$prmDropAreaHeight" />px;left:0px;right:0px; overflow: hidden;
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmFont" select="0"/>
          <xsl:with-param name="prmCursor" select="0"/>
          <xsl:with-param name="prmBorder" select="0"/>
          <xsl:with-param name="prmBorderValue" select="$varGroupingAreaBorder"/>
          <xsl:with-param name="prmBackgroundValue" select="$varGroupingAreaBackColor"/>
          <xsl:with-param name="prmBackgroundImageValue" select="$varGroupingAreaBackgroundImage"/>
          <xsl:with-param name="prmBackgroundImageRepeatValue" select="$varGroupingAreaBackgroundImageRepeat"/>
          <xsl:with-param name="prmBackgroundImagePositionValue" select="$varGroupingAreaBackgroundImagePosition"/>
        </xsl:call-template>
      </xsl:attribute>
      <xsl:if test="WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView']">
        <div style="width:100%;height:100%;">
          <xsl:apply-templates select="WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView']" mode="modContent"/>
        </div>
      </xsl:if>
      <xsl:if test="not(WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView'])">
        <table class="Common-CellSpacing0 Common-CellPadding0 Common-FontData Common-Unselectable" style="width:100%;height:100%;table-layout:fixed;" dir="{$dir}">
          <colgroup>
            <col style="width:100%"/>
          </colgroup>
          <tr>
            <td id="VWGNODECONTAINER_{$varId}" class="Common-VAlignMiddle DataGridView-GroupingDropAreaEmptyMessage">
              <xsl:attribute name="style">
                <xsl:call-template name="tplTextHorizontalAlign">
                  <xsl:with-param name="prmAlign" select="$prmEmptyDropAreaMessageAlign"/>
                </xsl:call-template>
              </xsl:attribute>
              <xsl:value-of select="$prmEmptyDropAreaMessage"/>
            </td>
          </tr>
        </table>
      </xsl:if>
    </div>-->
  </xsl:template>

  <!--Caption template-->
  <xsl:template name="tplDrawDataGridViewCaption">
    <xsl:variable name="varIsCaptionVisible" select="@Attr.IsCaptionVisible" />
    <xsl:if test="$varIsCaptionVisible='1'">
      <xsl:variable name="varCaptionHeight" select="@Attr.VisualTemplateDataGridViewCaptionHeight"/>
      <div style="position:absolute;top:0px;left:0px;right:0px;height:{$varCaptionHeight}px">
        <div class="Common-FontData Common-Unselectable DataGridView-Caption" style="width:100%;height:100%;line-height:{$varCaptionHeight}px" dir="{$dir}" >
          <div class="DataGridView-CaptionMenuButton DataGridView-OptionsCaption"></div>
          <div class="DataGridView-CaptionMenuButton DataGridView-NewRowCaption"></div>
          <div class="Common-AlignCenter Common-VAlignMiddle DataGridView-CaptionText">
            <xsl:call-template name="tplDecodeTextAsHtml"/>
          </div>
        </div>
      </div>
    </xsl:if>
  </xsl:template>

  <!--DataGridView Common Caption template-->
  <xsl:template name="tplDrawDataGridViewCommonCaption">
    <xsl:param name="prmGridId" />
    <xsl:param name="prmCaptionText" select="''" />
    <xsl:param name="prmShowBackButton" select="0" />
    <xsl:param name="prmPreviousButtonText" select="'Back'" />
    <xsl:param name="prmPreviousButtonOnClickFunction" />
    <xsl:param name="prmShowNextButton" select="0" />
    <xsl:param name="prmNextButtonText" select="'Next'" />
    <xsl:param name="prmNextButtonOnClickFunction" />
    
    <xsl:variable name="varCaptionHeight" select="@Attr.VisualTemplateDataGridViewCaptionHeight"/>

    <div style="height:{$varCaptionHeight}px">
      <div class="Common-FontData Common-Unselectable DataGridView-Caption" style="width:100%;height:100%;line-height:{$varCaptionHeight}px" dir="{$dir}" >
        <xsl:if test="$prmShowBackButton=1">
          <div class="DataGridView-GenericButton" style="float:{$left}">
            <xsl:attribute name="onclick"><xsl:value-of select="$prmPreviousButtonOnClickFunction"/></xsl:attribute>
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$prmPreviousButtonText" />
            </xsl:call-template>
          </div>
        </xsl:if>
        <xsl:if test="$prmShowNextButton=1">
          <div class="DataGridView-GenericButton" style="float:{$right}">
            <xsl:attribute name="onclick"><xsl:value-of select="$prmNextButtonOnClickFunction"/></xsl:attribute>
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$prmNextButtonText" />
            </xsl:call-template>  
          </div>
        </xsl:if>
        <div class="Common-AlignCenter Common-VAlignMiddle DataGridView-CaptionText">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="$prmCaptionText" />
          </xsl:call-template>
        </div>
      </div>
    </div>
  </xsl:template>
  
  <!--ViewCaption template-->
  <xsl:template name="tplDrawDataGridViewViewCaption">
    <xsl:param name="prmGridId" />
    
    <xsl:variable name="varCaptionHeight" select="@Attr.VisualTemplateDataGridViewCaptionHeight"/>

    <div style="height:{$varCaptionHeight}px">
      <div class="Common-FontData Common-Unselectable DataGridView-Caption" style="width:100%;height:100%;line-height:{$varCaptionHeight}px" dir="{$dir}" >
        <div class="DataGridView-GenericButton" style="float:{$right}">
          <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$prmGridId" />','DataGridView-ViewContainer', 'VWGDGVVIEWCONTAINER_' ,window,event);</xsl:attribute>Done</div>
        <div class="Common-AlignCenter Common-VAlignMiddle DataGridView-CaptionText">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="'View'" />
          </xsl:call-template>
        </div>
      </div>
    </div>
  </xsl:template>
  
  <!--SortCaption template-->
  <xsl:template name="tplDrawDataGridViewSortCaption">
    <xsl:param name="prmGridId" />
    
    <xsl:variable name="varCaptionHeight" select="@Attr.VisualTemplateDataGridViewCaptionHeight"/>

    <div style="height:{$varCaptionHeight}px">
      <div class="Common-FontData Common-Unselectable DataGridView-Caption" style="width:100%;height:100%;line-height:{$varCaptionHeight}px" dir="{$dir}" >
        <div class="DataGridView-GenericButton" style="float:{$right}">
          <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$prmGridId" />','DataGridView-SortContainer', 'VWGDGVSORTCONTAINER_' ,window,event);</xsl:attribute>Done</div>
        <div class="Common-AlignCenter Common-VAlignMiddle DataGridView-CaptionText">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="'Sort'" />
          </xsl:call-template>
        </div>
      </div>
    </div>
  </xsl:template>
  
  <!--FilterCaption template-->
  <xsl:template name="tplDrawDataGridViewFilterCaption">
    <xsl:param name="prmGridId" />
    <xsl:param name="prmCaptionText" select="'Filter'" />
    
    <xsl:variable name="varCaptionHeight" select="@Attr.VisualTemplateDataGridViewCaptionHeight"/>

    <div style="height:{$varCaptionHeight}px">
      <div class="Common-FontData Common-Unselectable DataGridView-Caption" style="width:100%;height:100%;line-height:{$varCaptionHeight}px" dir="{$dir}" >
        <div class="DataGridView-GenericButton" style="float:{$right}">
          <xsl:attribute name="onclick">mobjApp.DataGridViewVisualTemplate_HideContainer('<xsl:value-of select="$prmGridId" />','DataGridView-FilterContainer', 'VWGDGVFILTERCONTAINER_' ,window,event);</xsl:attribute>Done</div>
        <div class="Common-AlignCenter Common-VAlignMiddle DataGridView-CaptionText">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="$prmCaptionText" />
          </xsl:call-template>
        </div>
      </div>
    </div>
  </xsl:template>


  <!--Row matching-->
  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile')]/WG:Tags.DataGridViewRow">
    <xsl:param name="prmColumns" select="../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../@Attr.Id" />
    <xsl:param name="prmSelectionMode" select="../@Attr.SelectionMode" />
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')" />
    <xsl:param name="prmWidth" select="sum($prmNonFrozenColumns/@Attr.Width)" />
    <xsl:param name="prmIsHierarchic" select="'0'" />
    <xsl:param name="prmExpansionIndicator" select="'4'" />

    <xsl:call-template name="tplDrawDataGridViewRow">
      <xsl:with-param name="prmColumns" select="$prmColumns" />
      <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
      <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
      <xsl:with-param name="prmGridId" select="$prmGridId" />
      <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode" />
      <xsl:with-param name="prmEnabled" select="$prmEnabled" />
      <xsl:with-param name="prmWidth" select="$prmWidth" />
      <xsl:with-param name="prmIsHierarchic" select="$prmIsHierarchic" />
      <xsl:with-param name="prmExpansionIndicator" select="$prmExpansionIndicator" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawExpandCollapse">
    <xsl:param name="prmIsExpanded" />
    <xsl:param name="prmExpansionIndicator"/>
    <xsl:param name="prmTop" />
    <xsl:param name="prmGridId" />
    <xsl:param name="prmExpandCollapseOnClick" select="'mobjApp.DataGridView_ExpandCollapseClick'"/>

    <!--varExpansionIndicatorType: 0 - Draw collapse button, 1 - Draw expand button, 2 - draw empty-->
    <xsl:variable name="varExpansionIndicatorType">
      <xsl:choose>
        <!--Always draw empty expansion indicator for new rows and filter row-->
        <xsl:when test="@Attr.IsNew or @Attr.FilterRow or $prmExpansionIndicator='5'">2</xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <!--If the indicator is: Always-->
            <xsl:when test="$prmExpansionIndicator='1'">
              <xsl:choose>
                <xsl:when test="$prmIsExpanded='1'">0</xsl:when>
                <xsl:otherwise>1</xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            <!--If CheckOnExpand (4 or '') or CheckOnDisplay(3)-->
            <xsl:when test="$prmExpansionIndicator='4' or $prmExpansionIndicator='3' or $prmExpansionIndicator='' or not($prmExpansionIndicator)">
              <xsl:choose>
                <xsl:when test="@Attr.NumberOfChildRows">
                  <xsl:choose>
                    <!--Check if child grid has any rows-->
                    <xsl:when test="number(@Attr.NumberOfChildRows) &gt; 0">
                      <xsl:choose>
                        <xsl:when test="$prmIsExpanded='1'">0</xsl:when>
                        <xsl:otherwise>1</xsl:otherwise>
                      </xsl:choose>
                    </xsl:when>
                    <xsl:otherwise>2</xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="$prmIsExpanded='1'">0</xsl:when>
                <xsl:otherwise>1</xsl:otherwise>
              </xsl:choose>
            </xsl:when>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <div class="DataGridView-ExpandCollapseColumn">
      <xsl:attribute name="style">
        position:absolute;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$prmTop"/>px;<xsl:value-of select="$left"/>:0px;
      </xsl:attribute>
      <xsl:if test="$varExpansionIndicatorType=0 or $varExpansionIndicatorType=1">
        <xsl:attribute name="onclick">
          <xsl:value-of select="$prmExpandCollapseOnClick"/>(this,'<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="@Attr.MemberID"/>',window);
        </xsl:attribute>
      </xsl:if>
      <div>
        <xsl:attribute name="style">
          width:100%;height:100%;position:relative;<xsl:call-template name="tplApplyCellBorderStyle"/>;
        </xsl:attribute>
        <xsl:attribute name="class">
          <xsl:choose>
            <xsl:when test="$varExpansionIndicatorType='0'">DataGridView-CollapseButton</xsl:when>
            <xsl:when test="$varExpansionIndicatorType='1'">DataGridView-ExpandButton</xsl:when>
            <xsl:when test="$varExpansionIndicatorType='2'">DataGridView-EmptyExpandCollapse</xsl:when>
          </xsl:choose>
        </xsl:attribute>
      </div>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewRow">
    <xsl:param name="prmColumns" select="../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../@Attr.Id" />
    <xsl:param name="prmSelectionMode" select="../@Attr.SelectionMode" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')" />
    <xsl:param name="prmWidth" select="sum($prmNonFrozenColumns/@Attr.Width)" />
    <xsl:param name="prmIsHierarchic" select="'0'" />
    <xsl:param name="prmExpansionIndicator" select="'4'" />

    <xsl:param name="prmNewOrderColumnsList" select="../@Attr.VisualTemplateListViewNewColumnOrder"/>
    <xsl:param name="prmNumberOfDisplayedColumns" select="../@Attr.VisualTemplateDataGridViewNumberOfDisplayedColumns" />

    <xsl:variable name="varShouldDrawExpansionColumn" select="$prmIsHierarchic='1' and not($prmExpansionIndicator='2')" />
    <xsl:variable name="varPrecedingRows" select="preceding-sibling::WG:Tags.DataGridViewRow" />
    <xsl:variable name="varTop" select="sum($varPrecedingRows[not(@Attr.Frozen='1')]/@Attr.Height)+sum($varPrecedingRows[@Attr.IsExpanded='1' and not(@Attr.Frozen='1')]/@Attr.ChildGridHeight)" migration-select="{this}.attr(&quot;Attr.Top&quot;)" />

    <xsl:if test="$varShouldDrawExpansionColumn">
      <xsl:call-template name="tplDrawExpandCollapse">
        <xsl:with-param name="prmIsExpanded" select="@Attr.IsExpanded" />
        <xsl:with-param name="prmExpansionIndicator">
          <xsl:choose>
            <xsl:when test="@Attr.ExpansionIndicator='0' or @Attr.ExpansionIndicator=''">
              <xsl:value-of select="$prmExpansionIndicator"/>
            </xsl:when>
            <xsl:when test="@Attr.ExpansionIndicator='1'">
              <xsl:value-of select="'1'"/>
            </xsl:when>
            <xsl:when test="@Attr.ExpansionIndicator='2'">
              <xsl:value-of select="'5'"/>
            </xsl:when>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmTop" select="$varTop" />
        <xsl:with-param name="prmGridId" select="$prmGridId" />
      </xsl:call-template>
    </xsl:if>

    <div id="VWGROW2_{$prmGridId}_{@Attr.MemberID}">
      <xsl:attribute name="style">
        position:absolute;width:<xsl:value-of select="$prmWidth"/>px;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$varTop"/>px;<xsl:if test="$varShouldDrawExpansionColumn">
          <xsl:value-of select="$left"/>:[Skin.ExpandCollapseColumnWidth]px;
        </xsl:if><xsl:if test="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]/WC:Tags.Panel">z-index:1;</xsl:if><xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="1" />
          <xsl:with-param name="prmBackground" select="0" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
        </xsl:call-template>
      </xsl:attribute>

      <xsl:call-template name="tplDataGridViewVisualTemplateRowsByNewColumnsOrder">
        <xsl:with-param name="prmNewOrderColumnsList" select="$prmNewOrderColumnsList" />
        <xsl:with-param name="prmNumberOfDisplayedColumns" select="$prmNumberOfDisplayedColumns" />

        <xsl:with-param name="prmCells" select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]"/>
        <xsl:with-param name="prmColumns" select="$prmColumns"/>
        <xsl:with-param name="prmGridId" select="$prmGridId" />
        <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
        <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
        <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
        <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
      </xsl:call-template>
      <!--<xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" migration-index="intCellIndex">
        <xsl:variable name="varPosition" select="position()" migration-select="intCellIndex+1" />
        <xsl:if test="$prmColumns[position()=$varPosition][not(@Attr.Frozen='1')]" migration-test="prmColumns.xposition( varPosition).attr(&quot;Attr.Frozen&quot;)!='1'">
          <xsl:apply-templates select=".">
            <xsl:with-param name="prmColumns" select="$prmColumns"/>
            <xsl:with-param name="prmGridId" select="$prmGridId" />
            <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
            <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
            <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
            <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
            <xsl:with-param name="prmCellPosition" select="$varPosition" />
          </xsl:apply-templates>
        </xsl:if>
      </xsl:for-each>-->
    </div>
    <xsl:if test="$prmIsHierarchic='1' and @Attr.IsExpanded='1'">
      <xsl:call-template name="tplDrawChildGrid">
        <xsl:with-param name="prmChildGridHeight"  select="@Attr.ChildGridHeight" />
        <xsl:with-param name="prmTop"  select="$varTop + @Attr.Height" />
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template match="WG:Tags.DataGridViewRow/WC:Tags.DataGridView" mode="modChildGrid">
    <xsl:param name="prmIsEnabled" />
    <div>
      <xsl:attribute name="style">
        width:100%;height:100%;position:absolute;top:0px;<xsl:value-of select="$left"/>:0px;<xsl:apply-templates mode="modApplyStyle" select="." />
      </xsl:attribute>
      <xsl:call-template name="tplSetControl" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:apply-templates select="." mode="modContent" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </div>
  </xsl:template>

  <!-- A datagridview cell that contained in a datagridview row. -->
  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile') and not(@VTFUNCTION)]/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[not(@Attr.Type='7')]">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../../@Attr.Id"/>
    <xsl:param name="prmSelectionMode" select="../../@Attr.SelectionMode"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')"/>
    <xsl:param name="prmCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:param name="prmWidth" />
    <xsl:param name="prmLeft" />

    <xsl:call-template name="tplDrawDataGridViewCell">
      <xsl:with-param name="prmColumns" select="$prmColumns" />
      <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
      <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
      <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
      <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmCellPosition" select="$prmCellPosition" />
      <xsl:with-param name="prmWidth" select="$prmWidth"/>
      <xsl:with-param name="prmLeft" select="$prmLeft"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewCellPanel">
    <xsl:param name="prmColumns"/>
    <xsl:param name="prmPanel"/>
    <xsl:param name="prmContainedInFrozenColumn"/>
    <xsl:param name="prmLeft"/>
    <xsl:param name="prmCellBorderStyle" />
    <xsl:param name="prmGridLines" select="'[Skin.GridLines]'"/>

    <xsl:variable name="varPanelRowspan" select="$prmPanel/@Attr.Rowspan"/>
    <xsl:variable name="varPanelColspan" select="$prmPanel/@Attr.Colspan"/>
    <xsl:variable name="varColumnPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])" />
    <xsl:variable name="varRows" select="../../WG:Tags.DataGridViewRow" />
    <xsl:variable name="varContainingRow" select="parent::node()" />
    <migration-write>
      <![CDATA[
var varPrecedingRows = varContainingRow.xpath("preceding-sibling::WG:Tags.DataGridViewRow");
]]>
    </migration-write>
    <xsl:variable name="varRowPosition" select="count($varContainingRow/preceding-sibling::WG:Tags.DataGridViewRow)" migration-select="$.xpath(&quot;count&quot;, varPrecedingRows)"/>
    <xsl:variable name="varContainedInFrozenRow" select="$varContainingRow/@Attr.Frozen" />
    <migration-write>
      <![CDATA[
var varSpannedRows = varRows.filter(function() { var intPosition = $.inArray(this[0],varRows) + 1; return intPosition > varRowPosition && intPosition < (varRowPosition + $.xpath("number", varPanelRowspan) + 1) && !this.attr("FZ", "==", "1"); });
var varFrozenSpannedRows = varRows.filter(function() { var intPosition = $.inArray(this[0],varRows) + 1; return intPosition > varRowPosition && intPosition < (varRowPosition + $.xpath("number", varPanelRowspan) + 1) && this.attr("FZ", "==", "1"); });
var varSpannedColumns = prmColumns.filter(function() { var intPosition = $.inArray(this[0],prmColumns) + 1; return intPosition > varColumnPosition  && intPosition < (varColumnPosition + $.xpath("number", varPanelColspan) + 1) && !this.attr("FZ", "==", "1"); });
var varFrozenSpannedColumns = prmColumns.filter(function() { var intPosition = $.inArray(this[0],prmColumns) + 1; return intPosition > varColumnPosition  && intPosition < (varColumnPosition + $.xpath("number", varPanelColspan) + 1) && this.attr("FZ", "==", "1"); });
]]>
    </migration-write>
    <xsl:variable name="varPanelHeight">
      <xsl:if test="$varContainedInFrozenRow">
        <xsl:value-of select="sum($varRows[position() &gt; $varRowPosition and position() &lt; ($varRowPosition+number($varPanelRowspan)+1) and (@Attr.Frozen='1')]/@Attr.Height)" migration-select="$.xpath(&quot;sum&quot;, varFrozenSpannedRows.attrs(&quot;Attr.Height&quot;))"/>
      </xsl:if>
      <xsl:if test="not($varContainedInFrozenRow)">
        <xsl:value-of select="sum($varRows[position() &gt; $varRowPosition and position() &lt; ($varRowPosition+number($varPanelRowspan)+1) and not(@Attr.Frozen)]/@Attr.Height)" migration-select="$.xpath(&quot;sum&quot;, varSpannedRows.attrs(&quot;Attr.Height&quot;))"/>
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varPanelWidth">
      <xsl:if test="$prmContainedInFrozenColumn">
        <xsl:value-of select="sum($prmColumns[position() &gt; $varColumnPosition and position() &lt; ($varColumnPosition+number($varPanelColspan)+1) and (@Attr.Frozen='1')]/@Attr.Width)" migration-select="$.xpath(&quot;sum&quot;, varFrozenSpannedColumns.attrs(&quot;Attr.Width&quot;))"/>
      </xsl:if>
      <xsl:if test="not($prmContainedInFrozenColumn)">
        <xsl:value-of select="sum($prmColumns[position() &gt; $varColumnPosition and position() &lt; ($varColumnPosition+number($varPanelColspan)+1) and not(@Attr.Frozen)]/@Attr.Width)" migration-select="$.xpath(&quot;sum&quot;, varSpannedColumns.attrs(&quot;Attr.Width&quot;))"/>
      </xsl:if>
    </xsl:variable>

    <xsl:attribute name="onresize">mobjApp.Layout_ContainerResized(this);</xsl:attribute>
    <xsl:attribute name="data-vwgtype">container</xsl:attribute>
    <xsl:attribute name="style">
      position:absolute;z-index:1;<xsl:value-of select="$left"/>:<xsl:value-of select="$prmLeft"/>px;top:0px;width:<xsl:value-of select="$varPanelWidth"/>px;height:<xsl:value-of select="$varPanelHeight"/>px;
      <xsl:call-template name="tplApplyDataGridViewCellStyle">
        <xsl:with-param name="prmColumns" select="$prmColumns"/>
        <xsl:with-param name="prmCellBorderStyle" select="$prmCellBorderStyle"/>
        <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
      </xsl:call-template>
    </xsl:attribute>

    <xsl:apply-templates select="$prmPanel"/>
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewCell">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../../@Attr.Id"/>
    <xsl:param name="prmSelectionMode" select="../../@Attr.SelectionMode"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')"/>
    <xsl:param name="prmCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:param name="prmSelectOnRightClick" select="../../@Attr.SelectOnRightClick"/>
    <xsl:param name="prmWidth" />
    <xsl:param name="prmLeft" />

    <xsl:variable name="varContainingColumn" select="$prmColumns[position()=$prmCellPosition]" migration-select="prmColumns.xposition( prmCellPosition)" />
    <xsl:variable name="varContainedInFrozenColumn" select="$varContainingColumn/@Attr.Frozen" />
    <xsl:variable name="varWidth" select="$prmWidth" />
    <xsl:variable name="varSelected" select="(($prmSelectionMode='1' or $prmSelectionMode='8') and @Attr.Selected='1') or (($prmSelectionMode='2' or $prmSelectionMode='8') and ../@Attr.Selected='1')" />
    <xsl:variable name="varActive" select="@Attr.Active='1'" />
    <xsl:variable name="varLeft" select="$prmLeft" />
    <!--<xsl:if test="$varContainedInFrozenColumn">
        <xsl:value-of select="sum($prmColumns[(position() &lt; $prmCellPosition) and (@Attr.Frozen='1')]/@Attr.Width)" migration-select="varContainingColumn.attr(&quot;Attr.Left&quot;)" />
      </xsl:if>
      <xsl:if test="not($varContainedInFrozenColumn)">
        <xsl:value-of select="sum($prmColumns[(position() &lt; $prmCellPosition) and not(@Attr.Frozen)]/@Attr.Width)" migration-select="varContainingColumn.attr(&quot;Attr.Left&quot;)" />
      </xsl:if>-->
    <!--</xsl:variable>-->

    <div id="VWG_{$prmGridId}_{@Attr.MemberID}">
      <xsl:variable name="varPanel" select="WC:Tags.Panel"/>
      <xsl:attribute name="class">
        <xsl:if test="$varSelected and not($varActive)">DataGridView-Cell_Selected</xsl:if>
        <xsl:if test="not($varSelected) or $varActive">DataGridView-Cell</xsl:if>
      </xsl:attribute>
      <xsl:if test="$varPanel">
        <xsl:call-template name="tplDrawDataGridViewCellPanel">
          <xsl:with-param name="prmColumns" select="$prmColumns"/>
          <xsl:with-param name="prmPanel" select="$varPanel"/>
          <xsl:with-param name="prmContainedInFrozenColumn" select="$varContainedInFrozenColumn"/>
          <xsl:with-param name="prmLeft" select="$varLeft"/>
          <xsl:with-param name="prmCellBorderStyle" select="../../@Attr.CellBorderStyle" />
        </xsl:call-template>
      </xsl:if>
      <xsl:if test="not($varPanel)">
        <xsl:apply-templates mode="modTraceableEvents" select="." />
        <xsl:apply-templates mode="modEventCaptures" select="." />
        <xsl:attribute name="style">
          position:absolute;z-index:0;<xsl:value-of select="$left"/>:<xsl:value-of select="$varLeft"/>px;top:0px;width:<xsl:value-of select="$varWidth"/>px;height:100%;
          <xsl:call-template name="tplApplyDataGridViewCellStyle">
            <xsl:with-param name="prmColumns" select="$prmColumns"/>
            <xsl:with-param name="prmCellPosition" select="$prmCellPosition"/>
          </xsl:call-template>
        </xsl:attribute>
        <xsl:if test="$prmEnabled">
          <xsl:call-template name="tplDataGridViewCellEvents">
            <xsl:with-param name="prmSelectOnRightClick" select="$prmSelectOnRightClick"/>
          </xsl:call-template>
          <xsl:call-template name="tplSetToolTip">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </xsl:if>
        <div style="position:relative;width:100%;height:100%;">
          <xsl:apply-templates mode="modCellContent" select="." >
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </div>
      </xsl:if>
    </div>
  </xsl:template>

  <!--A match for a datagridview column-->
  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile')]/WG:Tags.DataGridViewColumn">
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:if test="../@Attr.DataGridViewHierarchyLevel &lt; 1">
      <xsl:call-template name="tplDrawDataGridViewColumn">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawDataGridViewColumn">
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varMemberID" select="@Attr.MemberID" />
    <xsl:variable name="varName" select="@Attr.Name" />
    <xsl:variable name="varResizable" select="not(@Attr.Resize='0') and not($prmIsEnabled='0')" />
    <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
    <xsl:variable name="varContainedCellBackColor">
      <xsl:if test="$varContainedCell and $varContainedCell/@Attr.Background and not($varContainedCell/@Attr.Background='')">
        <xsl:value-of select="$varContainedCell/@Attr.Background"/>
      </xsl:if>
    </xsl:variable>

    <!--id="VWG_{$prmGridId}_{$varMemberID}"--> 
    <div id="VWG_CH_{$prmGridId}_{$varMemberID}" style="float:{$left};height:100%;width:{@Attr.Width}px;" class="Common-HandCursor DataGridView-ColumnHeader" data-vwgdragable="1">
      <xsl:attribute name="data-vwggroupingcolumnname">
        <xsl:value-of select="$varName"/>
      </xsl:attribute>
      <div class="DataGridView-ColumnHeaderSplitter">
        <xsl:attribute name="style">
          padding-<xsl:value-of select="$right"/>:3px;height:100%;<xsl:if test="not($varResizable)">cursor:pointer;</xsl:if><xsl:if test="$varContainedCellBackColor">
            background-color:<xsl:value-of select="$varContainedCellBackColor"/>;
          </xsl:if>
        </xsl:attribute>
        <xsl:attribute name="ondblclick">
          mobjApp.DataGridView_ColumnDividerDoubleClick(this,'<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="$varMemberID"/>',event,window);
        </xsl:attribute>

        <xsl:if test="$varResizable">
          <xsl:attribute name="onmousedown">
            mobjApp.DataGridView_ColumnDividerMouseDown(this,'<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="$varMemberID"/>',true,window,event);
          </xsl:attribute>
        </xsl:if>
        <div style="overflow:hidden;width:100%;height:100%;" class="Common-HandCursor" onmousedown="mobjApp.DataGridView_OnColumnHeaderMouseDown('{$prmGridId}','{$varMemberID}',window,event)">
          <div class="Common-HandCursor"  style="height:100%;width:100%;overflow:hidden;position:relative;">
            <xsl:apply-templates select="$varContainedCell" >
              <xsl:with-param name="prmGridId" select="$prmGridId" />
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:apply-templates>
          </div>
        </div>
      </div>
    </div>
  </xsl:template>

  <!-- A datagridview cell that contained in a datagridview column. -->
  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile')]/WG:Tags.DataGridViewColumn/WG:Tags.DataGridViewCell[@Attr.Type='7']">
    <xsl:param name="prmGridId" select="../../@Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:call-template name="tplDrawColumnDataGridViewCell">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawColumnDataGridViewCell">
    <xsl:param name="prmGridId" select="../../@Id"/>
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmSortAscendingImage" select="'[Skin.SortAscendingIndicatorImage]'"/>
    <xsl:param name="prmSortDescendingImage" select="'[Skin.SortDescendingIndicatorImage]'"/>
    <xsl:param name="prmIsEnabled" />

    <div id="VWG_{$prmGridId}_{@Attr.MemberID}">

      <xsl:variable name="varFilterCombo" select="WC:Tags.ComboBox[@Attr.CustomStyle='DataGridViewHeaderFilterComboBoxSkin']"/>
      <xsl:if test="$varFilterCombo">
        <xsl:variable name="varColumn" select="parent::node()" />
        <xsl:variable name="varColumnWidth" select="$varColumn/@Attr.Width"/>
        <xsl:variable name="varColumnHeight" select="../../@Attr.ColumnHeaders"/>
        <xsl:variable name="varFilterNormalImageWidth" select="'[Skin.HeaderFilterComboBoxImageWidth]'"/>
        <xsl:variable name="varPanelWidth">
          <xsl:choose>
            <xsl:when test="number($varColumnWidth)-number($varFilterNormalImageWidth)-3>0">
              <xsl:value-of select="number($varColumnWidth)-number($varFilterNormalImageWidth)-3"/>
            </xsl:when>
            <xsl:otherwise>0</xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        <xsl:attribute name="style">
          width:100%;height:<xsl:value-of select="$varColumnHeight"/>px;
        </xsl:attribute>
        <xsl:apply-templates select="$varFilterCombo"/>
        <div>
          <xsl:attribute name="style">
            position:absolute;height:<xsl:value-of select="$varColumnHeight"/>px;width:<xsl:value-of select="$varPanelWidth"/>px;<xsl:value-of select="$left"/>:<xsl:value-of select="$varFilterNormalImageWidth"/>px;
          </xsl:attribute>
          <div>
            <xsl:call-template name="tplDrawColumnDataGridViewCellContent">
              <xsl:with-param name="prmColumns" select="$prmColumns"/>
              <xsl:with-param name="prmSortAscendingImage" select="$prmSortAscendingImage"/>
              <xsl:with-param name="prmSortDescendingImage" select="$prmSortDescendingImage"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
            </xsl:call-template>
          </div>
        </div>
      </xsl:if>
      <xsl:if test="not($varFilterCombo)">
        <xsl:call-template name="tplDrawColumnDataGridViewCellContent">
          <xsl:with-param name="prmColumns" select="$prmColumns"/>
          <xsl:with-param name="prmSortAscendingImage" select="$prmSortAscendingImage"/>
          <xsl:with-param name="prmSortDescendingImage" select="$prmSortDescendingImage"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        </xsl:call-template>
      </xsl:if>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawColumnDataGridViewCellContent">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmSortAscendingImage" select="'[Skin.SortAscendingIndicatorImage]'"/>
    <xsl:param name="prmSortDescendingImage" select="'[Skin.SortDescendingIndicatorImage]'"/>
    <xsl:param name="prmIsEnabled"/>

    <xsl:variable name="varSortOrder" select="@Attr.SortOrder" />

    <xsl:variable name="varPanel" select="WC:Tags.Panel"/>
    <xsl:if test="$varPanel">
      <xsl:attribute name="onresize">mobjApp.Layout_ContainerResized(this);</xsl:attribute>
      <xsl:attribute name="data-vwgtype">container</xsl:attribute>
      <xsl:attribute name="style">
        <xsl:text>position:absolute;z-index:1;width:100%;height:100%;</xsl:text>
        <xsl:call-template name="tplApplyDataGridViewCellStyle">
          <xsl:with-param name="prmColumns" select="$prmColumns"/>
          <xsl:with-param name="prmBorder" select="0"/>
        </xsl:call-template>
      </xsl:attribute>
      <xsl:apply-templates select="$varPanel"/>
    </xsl:if>
    <xsl:if test="not($varPanel)">
      <xsl:attribute name="style">
        height:<xsl:value-of select="../../@Attr.ColumnHeaders"/>px;width:100%;overflow:hidden;
        <xsl:call-template name="tplApplyPaddings"/>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
        </xsl:call-template>
      </xsl:attribute>
      <xsl:call-template name="tplSetToolTip">
        <xsl:with-param name="prmIsEnable" select="$prmIsEnabled"/>
      </xsl:call-template>
      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmText" select="@Attr.Value"/>
        <xsl:with-param name="prmTextClass" select="'Common-Unselectable'"/>
        <xsl:with-param name="prmImage">
          <xsl:if test="$varSortOrder='0'">
            <xsl:value-of select="$prmSortAscendingImage"/>
          </xsl:if>
          <xsl:if test="$varSortOrder='1'">
            <xsl:value-of select="$prmSortDescendingImage"/>
          </xsl:if>
        </xsl:with-param>
        <xsl:with-param name="prmTextAlign" select="@Attr.TextAlign" />
        <xsl:with-param name="prmImageAlign" select="'CenterMiddle'" />
        <xsl:with-param name="prmTextImageRelation" select="8" />
        <xsl:with-param name="prmLayoutPadding" select="0" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <!-- A datagridview cell that contained in a datagridview row. -->
  <xsl:template match="WC:Tags.DataGridView[not(@Attr.CustomStyle) and not(@Attr.Virtual='1') and (@Attr.VisualTemplate='DataGridViewVisualTemplateForMobile')]/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Type='7']">
    <xsl:param name="prmGridId" select="../../@Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:call-template name="tplDrawRowDataGridViewCell">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawRowDataGridViewCell">
    <xsl:param name="prmGridId" select="../../@Id"/>
    <xsl:param name="prmIsEnabled" />

    <div>
      <xsl:attribute name="style">
        width:100%;overflow:hidden;
        <xsl:call-template name="tplApplyPaddings"/>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="1" />
          <xsl:with-param name="prmCursor" select="0" />
        </xsl:call-template>
      </xsl:attribute>
      <xsl:call-template name="tplSetToolTip">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>

      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmText" select="@Attr.Value"/>
        <xsl:with-param name="prmTextClass" select="'Common-FontData Common-Unselectable DataGridView-RowHeaderText'"/>
        <xsl:with-param name="prmTextAlign" select="@Attr.TextAlign" />
        <xsl:with-param name="prmImageAlign" select="'CenterMiddle'" />
        <xsl:with-param name="prmTextImageRelation" select="8" />
        <xsl:with-param name="prmLayoutPadding" select="0" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <!--Row header drawing-->
  <xsl:template name="tplDrawRowHeader">
    <xsl:param name="prmGridId" select="../@Id" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varMemberID" select="@Attr.MemberID" />
    <xsl:variable name="varHeaderCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']" />
    <xsl:variable name="varGridEnabled" select="not($prmIsEnabled='0')"/>
    <xsl:variable name="varFilterRow" select="@Attr.FilterRow"/>
    <xsl:variable name="varRowHeaderEditModeImage" select="'[Skin.RowHeaderEditModeImage]'"/>
    <xsl:variable name="varRowHeaderSelectedModeImage" select="'[Skin.RowHeaderSelectedModeImage]'"/>
    <xsl:variable name="varRowHeaderNewRowModeImage" select="'[Skin.RowHeaderNewRowModeImage]'"/>
    <xsl:variable name="varRowHeaderErrorProviderImage" select="'[Skin.RowHeaderErrorProviderImage]'"/>
    <xsl:variable name="varErrorMessage" select="@Attr.ErrorMessage"/>

    <xsl:attribute name="class">
      DataGridView-RowHeader<xsl:if test="@Attr.Selected='1'"> DataGridView-RowHeader_Selected</xsl:if>
    </xsl:attribute>
    <div id="VWG_{$prmGridId}_{$varMemberID}" style="height:100%;">
      <xsl:if test="(../@Attr.SelectionMode='2' or ../@Attr.SelectionMode='8') and $varGridEnabled">
        <xsl:attribute name="onclick">mobjApp.DataGridView_RowHeaderClick(this,window,event,true);</xsl:attribute>
        <xsl:attribute name="oncontextmenu">mobjApp.DataGridView_RowHeaderClick(this,window,event,true);</xsl:attribute>
      </xsl:if>
      <xsl:choose>
        <xsl:when test="$varErrorMessage">
          <xsl:call-template name="tplSetToolTip">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            <xsl:with-param name="prmToolTip" select="$varErrorMessage" />
          </xsl:call-template>
        </xsl:when>
        <xsl:otherwise>
          <xsl:call-template name="tplSetToolTip">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:if test="$varFilterRow">
        <xsl:call-template name="tplDrawFilterRowHeader"/>
      </xsl:if>
      <xsl:if test="not($varFilterRow)">
        <div id="VWG_{$prmGridId}_{$varHeaderCell/@Attr.MemberID}" class="DataGridView-RowHeaderIconFirstContainer" dir="ltr">
          <div class="DataGridView-RowHeaderIconSecondContainer">
            <div class="DataGridView-RowHeaderIconThirdContainer">
              <table class="Common-CellSpacing0 Common-CellPadding0 Common-FontData Common-Unselectable"  dir="{$dir}" style="position:relative;width:100%;height:100%;overflow:hidden;table-layout:fixed;" >
                <colgroup>
                  <col style="width:30px"/>
                  <xsl:if test="$varHeaderCell">
                    <col />
                  </xsl:if>
                </colgroup>
                <tbody>
                  <tr>
                    <td id="DGVRH_{$prmGridId}_{$varMemberID}">
                      <xsl:choose>
                        <xsl:when test="not(../@Attr.ShowEditingIcon='0') and  WG:Tags.DataGridViewCell[not(@Attr.Type='7') and @Attr.Active='1']" migration-test="this.parent().attr(&quot;Attr.ShowEditingIcon&quot;, &quot;!=&quot;, &quot;0&quot;) &amp;&amp; {this}.xpath(&quot;WG:Tags.DataGridViewCell[not(@Attr.Type='7') and @Attr.Active = '1']&quot;).length &gt; 0">
                          <img src="{$varRowHeaderEditModeImage}" alt=""/>
                        </xsl:when>
                        <xsl:when test="../@Attr.CurrentCell=WG:Tags.DataGridViewCell[not(@Attr.Type='7')]/@Attr.MemberID" migration-test="{this}.xpath(&quot;WG:Tags.DataGridViewCell[not(@Attr.Type='7') and @Attr.MemberID='&quot;+{this}.parent().attr(&quot;Attr.CurrentCell&quot;)+&quot;']&quot;).length &gt; 0">
                          <img src="{$varRowHeaderSelectedModeImage}" alt=""/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:if test="not(@Attr.IsNew='1')">&#160;</xsl:if>
                        </xsl:otherwise>
                      </xsl:choose>
                      <xsl:if test="@Attr.IsNew='1'">
                        <img src="{$varRowHeaderNewRowModeImage}" alt=""/>
                      </xsl:if>
                      <xsl:if test="$varErrorMessage">
                        <img src="{$varRowHeaderErrorProviderImage}" alt=""/>
                      </xsl:if>
                    </td>
                    <xsl:if test="$varHeaderCell">
                      <td>
                        <xsl:apply-templates select="$varHeaderCell">
                          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        </xsl:apply-templates>
                      </td>
                    </xsl:if>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <xsl:call-template name="tplDrawEmptyImage">
            <xsl:with-param name="prmImageHeight" select="'100%'" />
            <xsl:with-param name="prmImageWidth"  select="'100%'" />
            <xsl:with-param name="prmPositionStyle"  select="'absolute'" />
            <xsl:with-param name="prmImageTop" select="'0px'"/>
            <xsl:with-param name="prmImageLeft" select="'0px'"/>
          </xsl:call-template>
        </div>
      </xsl:if>
      <xsl:if test="$varGridEnabled and not(@Attr.Resize='0')">
        <div class="Common-Content" style="bottom:0px;{$left}:0px;position:absolute;height:3px;width:100%;background-color:transparent;cursor:n-resize;font:0pt Tahoma;">
          <xsl:attribute name="onmousedown">
            mobjApp.DataGridView_ColumnDividerMouseDown(this,'<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="$varMemberID"/>',false,window,event)
          </xsl:attribute>
          &#160;
        </div>
      </xsl:if>
    </div>
  </xsl:template>

  <!-- Draw filter row header-->
  <xsl:template name="tplDrawFilterRowHeader">
    <xsl:param name="prmClearAllFiltersButtonClass" select="'DataGridView-ClearAllFiltersButton'"/>
    <xsl:param name="prmClearAllFiltersButtonMargin" select="[Skin.ClearAllFiltersButtonMargin]"/>
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmClearAllFiltersToolTip" select="'[Skin.ClearAllFiltersToolTip]'"/>

    <table style="width: 100%; height: 100%; position: absolute;" class="Common-CellSpacing0 Common-CellPadding0">
      <tr>
        <td class="Common-VAlignMiddle">
          <div title="{$prmClearAllFiltersToolTip}" class="Common-HandCursor {$prmClearAllFiltersButtonClass}" style="float: {$right}; margin-{$right}: {$prmClearAllFiltersButtonMargin}px;" onclick="mobjApp.DataGridView_ClearFilters('{$prmGridId}', window, event);">
            <xsl:call-template name="tplDrawEmptyImage"/>
          </div>
        </td>
      </tr>
    </table>
  </xsl:template>

  <!--Apply cell wrap mode -->
  <xsl:template name="tplApplyDataGridViewCellWrapMode">
    <xsl:if test="@Attr.WrapContents='1'">word-break:break-all;</xsl:if>
  </xsl:template>

  <!--Apply cell fore color -->
  <xsl:template name="tplApplyDataGridViewCellForeColor">
    <xsl:variable name="varSelected" select="@Attr.Selected='1' or ../@Attr.Selected='1'" />
    <xsl:variable name="varForeColor" select="@Attr.Fore" />
    <xsl:variable name="varSelectionForeColor" select="@Attr.SelectionForeColor" />

    <xsl:choose>
      <xsl:when test="$varSelected and not(@Attr.Active='1')">
        <xsl:if test="$varSelectionForeColor">
          color:<xsl:value-of select="$varSelectionForeColor"/>;
        </xsl:if>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="$varForeColor">
          color:<xsl:value-of select="$varForeColor"/>;
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Apply cell background color -->
  <xsl:template name="tplApplyDataGridViewCellBackgroundColor">
    <xsl:variable name="varSelected" select="@Attr.Selected='1' or ../@Attr.Selected='1'" />
    <xsl:variable name="varBackgroundColor" select="@Attr.Background" />
    <xsl:variable name="varSelectionBackColor" select="@Attr.SelectionBackColor" />

    <xsl:choose>
      <xsl:when test="$varSelected and not(@Attr.Active='1')">
        <xsl:if test="$varSelectionBackColor">
          background-color:<xsl:value-of select="$varSelectionBackColor"/>;
        </xsl:if>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="$varBackgroundColor">
          background-color:<xsl:value-of select="$varBackgroundColor"/>;
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Apply cell style -->
  <xsl:template name="tplApplyDataGridViewCellStyle">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:param name="prmCellBorderStyle" select="../../@Attr.CellBorderStyle" />
    <xsl:param name="prmBorder" select="1"/>

    <xsl:variable name="varBackgroundImageLayout" select="@Attr.BackgroundImageLayout" />
    <xsl:variable name="varMarginAll" select="@Attr.MarginAll" />
    <xsl:variable name="varMarginLeft" select="@Attr.MarginLeft" />
    <xsl:variable name="varMarginRight" select="@Attr.MarginRight" />
    <xsl:variable name="varMarginTop" select="@Attr.MarginTop" />
    <xsl:variable name="varMarginBottom" select="@Attr.MarginBottom" />

    <xsl:if test="$prmBorder=1">
      <xsl:call-template name="tplApplyCellBorderStyle">
        <xsl:with-param name="prmColumns" select="$prmColumns" />
        <xsl:with-param name="prmCellPosition" select="$prmCellPosition" />
        <xsl:with-param name="prmCellBorderStyle" select="$prmCellBorderStyle" />
      </xsl:call-template>
    </xsl:if>

    <xsl:if test="not($varBackgroundImageLayout='3' or $varBackgroundImageLayout='4')">
      <xsl:if test="@Attr.BackgroundImage">
        background-image:url(<xsl:value-of select="@Attr.BackgroundImage"/>);
      </xsl:if>
      <xsl:if test="$varBackgroundImageLayout='2'">background-repeat:no-repeat;background-position:center center;</xsl:if>
      <xsl:if test="$varBackgroundImageLayout='0'">
        background-repeat:no-repeat;background-position:top <xsl:value-of select="$left"/>;
      </xsl:if>
    </xsl:if>
    <xsl:if test="$varMarginAll">
      margin:<xsl:value-of select="$varMarginAll"/>px;
    </xsl:if>
    <xsl:if test="$varMarginLeft">
      margin-<xsl:value-of select="$left"/>:<xsl:value-of select="$varMarginLeft"/>px;
    </xsl:if>
    <xsl:if test="$varMarginRight">
      margin-<xsl:value-of select="$right"/>:<xsl:value-of select="$varMarginRight"/>px;
    </xsl:if>
    <xsl:if test="$varMarginTop">
      margin-top:<xsl:value-of select="$varMarginTop"/>px;
    </xsl:if>
    <xsl:if test="$varMarginBottom">
      margin-bottom:<xsl:value-of select="$varMarginBottom"/>px;
    </xsl:if>
    <xsl:call-template name="tplApplyCursorStyle"/>
    <xsl:call-template name="tplApplyDataGridViewCellBackgroundColor"/>
    <xsl:call-template name="tplApplyDataGridViewCellPadding"/>
    <xsl:call-template name="tplApplyDataGridViewCellForeColor"/>
    <xsl:call-template name="tplApplyDataGridViewCellWrapMode"/>
  </xsl:template>

  <!--Apply cell padding -->
  <xsl:template name="tplApplyDataGridViewCellPadding">
    <xsl:if test="@Attr.PaddingAll or @Attr.PaddingLeft or @Attr.PaddingRight or @Attr.PaddingTop or @Attr.PaddingBottom">
      <xsl:call-template name="tplApplyPaddings"/>
    </xsl:if>
  </xsl:template>

  <!--Apply cell tooltip -->
  <xsl:template name="tplApplyDataGridViewCellTooltip">
    <xsl:attribute name="title">
      <xsl:call-template name="tplDecodeText">
        <xsl:with-param name="prmText" select="@Attr.ToolTip"/>
      </xsl:call-template>
    </xsl:attribute>
  </xsl:template>

  <!--Set cell events-->
  <xsl:template name="tplDataGridViewCellEvents">
    <xsl:param name="prmSelectOnRightClick"/>

    <xsl:attribute name="onclick">mobjApp.DataGridView_CellClick(this,window,event);</xsl:attribute>
    <xsl:if test="$prmSelectOnRightClick">
      <xsl:attribute name="oncontextmenu">mobjApp.DataGridView_CellClick(this,window,event);</xsl:attribute>
    </xsl:if>
  </xsl:template>

  <!--Datagrid cell border style-->
  <xsl:template name="tplApplyCellBorderStyle">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:param name="prmCellBorderStyle" select="../../@Attr.CellBorderStyle" />
    <xsl:param name="prmGridLines" select="'[Skin.GridLines]'"/>

    <xsl:variable name="varBorderStyle" select="../@Attr.BorderStyle" />

    <xsl:choose>
      <xsl:when test="$varBorderStyle">
        <xsl:variable name="varBorderColor" select="../@Attr.BorderColor" />
        <xsl:variable name="varBorderWidth" select="../@Attr.BorderWidth" />
        <xsl:variable name="varIsLeftMost" select="$prmCellPosition=1"/>
        <xsl:variable name="varIsRightMost" select="$prmCellPosition=count($prmColumns)"/>
        <xsl:choose>
          <!-- 4 = None -->
          <xsl:when test="$prmCellBorderStyle='4'">
            <xsl:call-template name="tplDrawBorder">
              <xsl:with-param name="prmStylePropertyName" select="'border-style'"/>
              <xsl:with-param name="prmColorPropertyName" select="'border-color'"/>
              <xsl:with-param name="prmWidthPropertyName" select="'border-width'"/>
              <xsl:with-param name="prmStylePropertyValue" select="$varBorderStyle"/>
              <xsl:with-param name="prmColorPropertyValue" select="$varBorderColor"/>
              <xsl:with-param name="prmWidthPropertyValue" select="$varBorderWidth"/>
            </xsl:call-template>
            <xsl:if test="not($varIsLeftMost)">border-left:none;</xsl:if>
            <xsl:if test="not($varIsRightMost)">border-right:none;</xsl:if>
          </xsl:when>
          <!-- 11 = Dotted -->
          <xsl:when test="$prmCellBorderStyle='11'">
            <xsl:call-template name="tplDrawBorder">
              <xsl:with-param name="prmStylePropertyName" select="'border-style'"/>
              <xsl:with-param name="prmColorPropertyName" select="'border-color'"/>
              <xsl:with-param name="prmWidthPropertyName" select="'border-width'"/>
              <xsl:with-param name="prmStylePropertyValue" select="$varBorderStyle"/>
              <xsl:with-param name="prmColorPropertyValue" select="$varBorderColor"/>
              <xsl:with-param name="prmWidthPropertyValue" select="$varBorderWidth"/>
            </xsl:call-template>
            <xsl:if test="not($varIsRightMost)">
              <xsl:call-template name="tplDrawBorder">
                <xsl:with-param name="prmStylePropertyName" select="'border-right-style'"/>
                <xsl:with-param name="prmColorPropertyName" select="'border-right-color'"/>
                <xsl:with-param name="prmWidthPropertyName" select="'border-right-width'"/>
                <xsl:with-param name="prmStylePropertyValue" select="'dotted'"/>
                <xsl:with-param name="prmColorPropertyValue" select="'#D0D7E5'"/>
                <xsl:with-param name="prmWidthPropertyValue" select="'1'"/>
              </xsl:call-template>
            </xsl:if>
            <xsl:if test="not($varIsLeftMost)">border-left:none;</xsl:if>
          </xsl:when>
          <!-- otherwise -->
          <xsl:otherwise>
            <xsl:value-of select="$prmGridLines"/>
            <xsl:text>;</xsl:text>
            <xsl:call-template name="tplDrawBorder">
              <xsl:with-param name="prmStylePropertyName" select="'border-top-style'"/>
              <xsl:with-param name="prmColorPropertyName" select="'border-top-color'"/>
              <xsl:with-param name="prmWidthPropertyName" select="'border-top-width'"/>
              <xsl:with-param name="prmStylePropertyValue" select="$varBorderStyle"/>
              <xsl:with-param name="prmColorPropertyValue" select="$varBorderColor"/>
              <xsl:with-param name="prmWidthPropertyValue" select="$varBorderWidth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawBorder">
              <xsl:with-param name="prmStylePropertyName" select="'border-bottom-style'"/>
              <xsl:with-param name="prmColorPropertyName" select="'border-bottom-color'"/>
              <xsl:with-param name="prmWidthPropertyName" select="'border-bottom-width'"/>
              <xsl:with-param name="prmStylePropertyValue" select="$varBorderStyle"/>
              <xsl:with-param name="prmColorPropertyValue" select="$varBorderColor"/>
              <xsl:with-param name="prmWidthPropertyValue" select="$varBorderWidth"/>
            </xsl:call-template>
            <xsl:choose>
              <xsl:when test="$varIsLeftMost">
                <xsl:call-template name="tplDrawBorder">
                  <xsl:with-param name="prmStylePropertyName" select="concat('border-',$left,'-style')"/>
                  <xsl:with-param name="prmColorPropertyName" select="concat('border-',$left,'-color')"/>
                  <xsl:with-param name="prmWidthPropertyName" select="concat('border-',$left,'-width')"/>
                  <xsl:with-param name="prmStylePropertyValue" select="$varBorderStyle"/>
                  <xsl:with-param name="prmColorPropertyValue" select="$varBorderColor"/>
                  <xsl:with-param name="prmWidthPropertyValue" select="$varBorderWidth"/>
                </xsl:call-template>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>border-left:none;</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
            <xsl:if test="$varIsRightMost">
              <xsl:call-template name="tplDrawBorder">
                <xsl:with-param name="prmStylePropertyName" select="concat('border-',$right,'-style')"/>
                <xsl:with-param name="prmColorPropertyName" select="concat('border-',$right,'-color')"/>
                <xsl:with-param name="prmWidthPropertyName" select="concat('border-',$right,'-width')"/>
                <xsl:with-param name="prmStylePropertyValue" select="$varBorderStyle"/>
                <xsl:with-param name="prmColorPropertyValue" select="$varBorderColor"/>
                <xsl:with-param name="prmWidthPropertyValue" select="$varBorderWidth"/>
              </xsl:call-template>
            </xsl:if>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:when>
      <xsl:otherwise>
        <xsl:choose>
          <!--4=None-->
          <xsl:when test="$prmCellBorderStyle='4'"></xsl:when>
          <!--11=Dotted-->
          <xsl:when test="$prmCellBorderStyle='11'">border-style:dotted;border-left:none;border-top:none;border-width: medium 1px 1px medium;border-color:#D0D7E5 #D0D7E5 #D0D7E5 #D0D7E5;</xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$prmGridLines"/>;border-left:none;border-top:none;
          </xsl:otherwise>
        </xsl:choose>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="tplDrawBorder">
    <xsl:param name="prmStylePropertyName"/>
    <xsl:param name="prmColorPropertyName"/>
    <xsl:param name="prmWidthPropertyName"/>
    <xsl:param name="prmStylePropertyValue"/>
    <xsl:param name="prmColorPropertyValue"/>
    <xsl:param name="prmWidthPropertyValue"/>
    <xsl:value-of select="$prmStylePropertyName"/>:<xsl:value-of select="$prmStylePropertyValue"/>;<xsl:value-of select="$prmColorPropertyName"/>:<xsl:value-of select="$prmColorPropertyValue"/>;<xsl:value-of select="$prmWidthPropertyName"/>:<xsl:value-of select="$prmWidthPropertyValue"/>px;
  </xsl:template>

  <!--Datagrid paging template-->
  <xsl:template name="tplDrawDataGridViewPaging">
    <xsl:call-template name="tplDrawPaging">
      <xsl:with-param name="prmID" select="@Attr.Id"/>
      <xsl:with-param name="prmCurrentPage" select="@Attr.CurrentPage"/>
      <xsl:with-param name="prmTotalPages" select="@Attr.TotalPages"/>
      <xsl:with-param name="prmPagingFirstImageWidth" select="'DataGridView-PagingFirstImageWidth'"/>
      <xsl:with-param name="prmPagingFirstButtonClass" select="'DataGridView-PagingFirstButtonStyle'"/>
      <xsl:with-param name="prmPagingPreviousImageWidth" select="'DataGridView-PagingPreviousImageWidth'"/>
      <xsl:with-param name="prmPagingPrevButtonClass" select="'DataGridView-PagingPrevButtonStyle'"/>
      <xsl:with-param name="prmPagingBoxWidth" select="[Skin.PagingBoxWidth]"/>
      <xsl:with-param name="prmPagingGoToBoxClass" select="'DataGridView-PagingGotoBox'"/>
      <xsl:with-param name="prmPagingNumberSeperatorString" select="'[Skin.PagingNumberSeperatorFormat]'"/>
      <xsl:with-param name="prmPagingNextImageWidth" select="'DataGridView-PagingNextImageWidth'"/>
      <xsl:with-param name="prmPagingNextButtonClass" select="'DataGridView-PagingNextButtonStyle'"/>
      <xsl:with-param name="prmPagingLastImageWidth" select="'DataGridView-PagingLastImageWidth'"/>
      <xsl:with-param name="prmPagingLastButtonClass" select="'DataGridView-PagingLastButtonStyle'"/>
    </xsl:call-template>
  </xsl:template>

  <!--Traceable events matching-->

  <!--Active TextBox-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='1' and @Attr.Active='1']" mode="modTraceableEvents">
    <xsl:attribute name="data-vwg_AfterCreateEventHandler">DataGridView_AfterCreateTextBoxEvents</xsl:attribute>
  </xsl:template>

  <!--CheckBox-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='2']" mode="modTraceableEvents">
    <xsl:attribute name="data-vwg_BeforeCreateEventHandler">DataGridView_BeforeCreateCheckBoxEvents</xsl:attribute>
  </xsl:template>

  <!--ComboBox-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='6']" mode="modTraceableEvents">
    <xsl:attribute name="data-vwg_AfterCreateEventHandler">DataGridView_AfterCreateComboBoxEvents</xsl:attribute>
  </xsl:template>

  <!--Events capture matching-->
  <xsl:template match="WG:Tags.DataGridViewCell" mode="modEventCaptures">
    <xsl:choose>
      <xsl:when test="@Attr.Type='1' and not(@Attr.Active='1')"></xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplApplyEventCaptures"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>



  <!-- Handling the column drawing -->
  <xsl:template name="tplDataGridViewVisualTemplateColumnsByNewColumnsOrder">
    <xsl:param name="prmNewOrderColumnsList"/>
    <xsl:param name="prmNumberOfDisplayedColumns" />
    <xsl:param name="prmCurrentNumberOfDisplayedColumn" select="1" />

    <xsl:param name="prmColumns" />
    <xsl:param name="prmGridId" />
    <xsl:param name="prmIsEnabled" />



    <xsl:if test="$prmNumberOfDisplayedColumns - $prmCurrentNumberOfDisplayedColumn >= 0">
      <xsl:variable name="varNextItemIndex">
        <xsl:choose>
          <xsl:when test="string-length($prmNewOrderColumnsList) > 0">
            <xsl:value-of select="substring-before(concat($prmNewOrderColumnsList, '|'), '|')"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$prmCurrentNumberOfDisplayedColumn"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="varColumn" select="$prmColumns[position()=$varNextItemIndex]" />

      <xsl:apply-templates select="$varColumn">
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>

      <xsl:call-template name="tplDataGridViewVisualTemplateColumnsByNewColumnsOrder">
        <xsl:with-param name="prmNewOrderColumnsList" select="substring-after($prmNewOrderColumnsList, '|')"/>
        <xsl:with-param name="prmNumberOfDisplayedColumns" select="$prmNumberOfDisplayedColumns" />
        <xsl:with-param name="prmCurrentNumberOfDisplayedColumn" select="$prmCurrentNumberOfDisplayedColumn + 1" />

        <xsl:with-param name="prmColumns" select="$prmColumns"/>
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDataGridViewVisualTemplateRowsByNewColumnsOrder">
    <xsl:param name="prmNewOrderColumnsList"/>
    <xsl:param name="prmNumberOfDisplayedColumns" />
    <xsl:param name="prmCurrentNumberOfDisplayedColumn" select="1" />

    <xsl:param name="prmCells" />
    <xsl:param name="prmColumns" />
    <xsl:param name="prmGridId" />
    <xsl:param name="prmSelectionMode" />
    <xsl:param name="prmEnabled" />
    <xsl:param name="prmNonFrozenColumns" />
    <xsl:param name="prmFrozenColumns" />
    <xsl:param name="prmLeft" select="0"/>

    <xsl:if test="$prmNumberOfDisplayedColumns - $prmCurrentNumberOfDisplayedColumn >= 0">
      <xsl:variable name="varNextItemIndex">
        <xsl:choose>
          <xsl:when test="string-length($prmNewOrderColumnsList) > 0">
            <xsl:value-of select="substring-before(concat($prmNewOrderColumnsList, '|'), '|')"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$prmCurrentNumberOfDisplayedColumn"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="varCell" select="$prmCells[position()=$varNextItemIndex]" />
      <xsl:variable name="varColumn" select="$prmColumns[position()=$varNextItemIndex]" />

      <xsl:variable name="varPosition" select="position()" />

      <xsl:apply-templates select="$varCell">
        <xsl:with-param name="prmColumns" select="$prmColumns"/>
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
        <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
        <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
        <xsl:with-param name="prmNonFrozenColumns" select="$prmNonFrozenColumns"/>
        <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns"/>
        <xsl:with-param name="prmCellPosition" select="$prmCurrentNumberOfDisplayedColumn"/>
        <xsl:with-param name="prmWidth" select="$varColumn/@Attr.Width"/>
        <xsl:with-param name="prmLeft" select="$prmLeft"/>
      </xsl:apply-templates>

      <xsl:call-template name="tplDataGridViewVisualTemplateRowsByNewColumnsOrder">
        <xsl:with-param name="prmNewOrderColumnsList" select="substring-after($prmNewOrderColumnsList, '|')"/>
        <xsl:with-param name="prmNumberOfDisplayedColumns" select="$prmNumberOfDisplayedColumns" />
        <xsl:with-param name="prmCurrentNumberOfDisplayedColumn" select="$prmCurrentNumberOfDisplayedColumn + 1" />

        <xsl:with-param name="prmCells" select="$prmCells"/>
        <xsl:with-param name="prmColumns" select="$prmColumns"/>
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
        <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
        <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
        <xsl:with-param name="prmNonFrozenColumns" select="$prmNonFrozenColumns"/>
        <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns"/>
        <xsl:with-param name="prmLeft" select="$prmLeft + $varColumn/@Attr.Width"/>
      </xsl:call-template>
    </xsl:if>

  </xsl:template>
  
  <!-- Handeling the filter drawing -->
  <xsl:template name="tplDataGridViewVisualTemplateFilterOperatorItems">
    <xsl:param name="prmFilterOperatorItems"/>
    <xsl:param name="prmOperatorIndex" select="0"/>
    <xsl:param name="prmGridId"/>
    <xsl:param name="prmMemberId" />
    <xsl:param name="prmRowsHeight" />


    <xsl:if test="string-length($prmFilterOperatorItems) > 0">
      <xsl:variable name="varOperatorText">        
            <xsl:value-of select="substring-before(concat($prmFilterOperatorItems, '|'), '|')"/>
      </xsl:variable>
      <xsl:variable name="varOperatorImage">
        <xsl:value-of select="substring-before(concat(substring-after($prmFilterOperatorItems, '|'), '|'), '|')"/>
      </xsl:variable>

      <xsl:call-template name="tplDrawDataGridViewFilterOperatorsRow">
        <xsl:with-param name="prmOperatorText" select="$varOperatorText" />
        <xsl:with-param name="prmOperatorImage" select="$varOperatorImage" />
        <xsl:with-param name="prmOperatorIndex" select="$prmOperatorIndex"/>
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
        <xsl:with-param name="prmMemberId" select="$prmMemberId"/>
        <xsl:with-param name="prmRowsHeight" select="$prmRowsHeight"/>
      </xsl:call-template>

      <xsl:call-template name="tplDataGridViewVisualTemplateFilterOperatorItems">
        <xsl:with-param name="prmFilterOperatorItems" select="substring-after(substring-after($prmFilterOperatorItems, '|'), '|')"/>
        <xsl:with-param name="prmOperatorIndex" select="$prmOperatorIndex+1"/>
        <xsl:with-param name="prmGridId" select="$prmGridId"/>
        <xsl:with-param name="prmMemberId" select="$prmMemberId"/>
        <xsl:with-param name="prmRowsHeight" select="$prmRowsHeight"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
