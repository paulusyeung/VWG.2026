<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
  xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewCell[@Attr.Type='7']">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawVirtualDataGridViewHeaderCell">
      <xsl:with-param name="prmGridId" select="../@Attr.Id"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVirtualDataGridViewHeaderCell">
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmMemberId" />

    <div id="VWG_{$prmGridId}_{@Attr.MemberID}" data-vwgdragable="1">
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

  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawVirtualDataGridViewAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVirtualDataGridViewAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.DataGridView_KeyDown(',@Attr.Id,',window,event);')" />
    <xsl:variable name="varColumns" select="WG:Tags.DataGridViewColumn" />
    <xsl:variable name="varBlocks" select="WG:Tags.DataGridViewBlock" />
    <xsl:variable name="varRows" select="$varBlocks/WG:Tags.DataGridViewRow" />
    <xsl:variable name="varNonFrozenColumns" select="$varColumns[not(@Attr.Frozen='1')]" migration-select="xpath$([])" />
    <xsl:variable name="varFrozenColumns" select="$varColumns[@Attr.Frozen='1']" migration-select="xpath$([])" />
    <xsl:variable name="varNonFrozenRows" select="$varRows[not(@Attr.Frozen='1')]"/>
    <xsl:variable name="varFrozenRows" select="$varRows[@Attr.Frozen='1']"/>
    <xsl:variable name="varColumnHeadersHeight" select="@Attr.ColumnHeaders" />
    <xsl:variable name="varShowColumnHeaders" select="not($varColumnHeadersHeight='0')" />
    <xsl:variable name="varRowHeadersWidth" select="@Attr.RowHeaders" />
    <xsl:variable name="varShowRowHeaders" select="not($varRowHeadersWidth='0')" />
    <xsl:variable name="varColumnsWidth" select="sum($varNonFrozenColumns/@Attr.Width)" migration-select="0" />
    <xsl:variable name="varRowsHeight" select="sum($varNonFrozenRows/@Attr.Height) + sum($varNonFrozenRows[@Attr.IsExpanded='1']/@Attr.ChildGridHeight)" migration-select="0" />
    <xsl:variable name="varFrozenColumnsWidth" select="sum($varFrozenColumns/@Attr.Width)" migration-select="0" />
    <xsl:variable name="varFrozenRowsHeight" select="sum($varFrozenRows/@Attr.Height) + sum($varFrozenRows[@Attr.IsExpanded='1']/@Attr.ChildGridHeight)" migration-select="0" />
    <xsl:variable name="varFrozenHorizontalBlockHeight" select="number($varColumnHeadersHeight)+number($varFrozenRowsHeight)" migration-select="0"/>
    <xsl:variable name="varFrozenVerticalBlockWidth" select="number($varRowHeadersWidth+$varFrozenColumnsWidth)" migration-select="0" />
    <xsl:variable name="varBlocksHeight" select="sum($varBlocks/@Attr.Height)" />
    <xsl:variable name="varGridId" select="@Attr.Id" />
    <xsl:variable name="varVirtualBlockSize" select="@Attr.VirtualBlockSize" />
    <xsl:variable name="varIsHierarchic" select="@Attr.IsHierarchic" />
    <xsl:variable name="varExpansionIndicator" select="@Attr.ExpansionIndicator" />
    <xsl:variable name="varShouldDrawExpansionColumn" select="$varIsHierarchic='1' and not($varExpansionIndicator='2')" />
    <xsl:attribute name="class">Common-DefaultCursor DataGridView-Control</xsl:attribute>
    <xsl:attribute name="class">
      <xsl:text>Common-DefaultCursor DataGridView-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> DataGridView-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>

    <migration-write>
      <![CDATA[
varNonFrozenRows.xeach(function()
{
  varRowsHeight += $.xpath("number", this.attr("Attr.Height"));
  
  if(this.attr("Attr.IsExpanded") == "1")
  {
    varRowsHeight += $.xpath("number", this.attr("Attr.ChildGridHeight"));
  }
});

varFrozenRows.xeach(function()
{
  varFrozenRowsHeight += $.xpath("number", this.attr("Attr.Height"));

  if(this.attr("Attr.IsExpanded") == "1")
  {
    varFrozenRowsHeight += $.xpath("number", this.attr("Attr.ChildGridHeight"));
  }
});

varFrozenHorizontalBlockHeight += $.xpath("number", varColumnHeadersHeight) + varFrozenRowsHeight;

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

varFrozenVerticalBlockWidth = (Number(varRowHeadersWidth) + Number(varFrozenColumnsWidth));
]]>
    </migration-write>

    <xsl:variable name="varColumnsWidthWithExpansionColumn" >
      <xsl:choose>
        <xsl:when test="$varShouldDrawExpansionColumn"><xsl:value-of select="$varColumnsWidth+number([Skin.ExpandCollapseColumnWidth])" /></xsl:when>
        <xsl:otherwise><xsl:value-of select="$varColumnsWidth" /></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <div class="Common-FontData Common-Unselectable" style="width:100%;height:100%;positoin:relative;" dir="{$dir}" tabindex="-1" data-vwgfocuselement="1">
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:attribute name="onkeydown"><xsl:value-of select="$prmKeyDownHandler"/></xsl:attribute>
        <xsl:call-template name="tplResgisterLostFocusEvent"><xsl:with-param name="prmHandler">mobjApp.DataGridView_OnBlur('<xsl:value-of select="$varGridId"/>',event,window);</xsl:with-param></xsl:call-template>
      </xsl:if>
      <!-- Get caption height -->
      <xsl:variable name="varCaptionHeight">
        <xsl:choose>
          <xsl:when test="@Attr.IsCaptionVisible='1'"><xsl:value-of select="@Attr.CaptionHeight" /></xsl:when>
          <xsl:otherwise>0</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <!--Draw caption-->
      <xsl:if test="@Attr.IsCaptionVisible='1'">
        <xsl:call-template name="tplDrawDataGridViewCaption"/>
      </xsl:if>
      <!--Check if grouping area is visible-->
        <xsl:variable name="varIsGroupingDropAreaVisible" select="@Attr.ShowGroupingDropArea"/>
        <xsl:variable name="varDropAreaHeight" select="@Attr.DropAreaHeight" />
        <xsl:variable name="varGroupingAreaHeight">
            <xsl:if test="$varIsGroupingDropAreaVisible='1'">
                <xsl:choose>
                    <xsl:when test="number($varDropAreaHeight) &gt; 0"><xsl:value-of select="$varDropAreaHeight"/></xsl:when>
                    <xsl:otherwise>[Skin.DropAreaHeight]</xsl:otherwise>
                </xsl:choose>
            </xsl:if>
            <xsl:if test="not($varIsGroupingDropAreaVisible) or $varIsGroupingDropAreaVisible='0'">0</xsl:if>
        </xsl:variable>     
      
      <!--Draw grouping drop area if exists-->      
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

      <!--Draw headers row-->
      <xsl:if test="$varFrozenHorizontalBlockHeight &gt; 0">
        <div style="position:absolute;height:{$varFrozenHorizontalBlockHeight}px;top:{number($varGroupingAreaHeight) + number($varCaptionHeight) + $varExtendedColumnsTotalHeight}px;left:0px;right:0px;">
          <xsl:if test="$varShowRowHeaders or ($varFrozenColumnsWidth &gt; 0) or ($varFrozenRowsHeight &gt; 0)">
            <div style="position:absolute;width:{number($varFrozenColumnsWidth) + number($varRowHeadersWidth)}px;{$left}:0px;height:100%;top:0px;">
              <!--Draw headers corner-->
              <xsl:if test="$varShowRowHeaders and $varShowColumnHeaders and @Attr.ColumnsCount &gt; 0">
                 <div style="position:absolute;top:0px;{$left}:0px;width:{$varRowHeadersWidth}px;height:{$varColumnHeadersHeight}px;" >
                    <xsl:variable name="varHeaderCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']" />
                    <xsl:choose>
                      <xsl:when test="@Attr.ColumnChooser='1'">
                        <xsl:attribute name="class">
                          DataGridView-RowHeader
                        </xsl:attribute>

                        <xsl:call-template name="tplDrawColumnChooser" >
                          <xsl:with-param name="prmGridId" select="$varGridId" />
                          <xsl:with-param name="prmMemberId" select="$varHeaderCell/@Attr.MemberID" />
                        </xsl:call-template>
                      </xsl:when>
                      <xsl:when test="$varHeaderCell">
                        <xsl:attribute name="class">DataGridView-TopHeader</xsl:attribute>
                      <xsl:attribute name="onclick">mobjApp.DataGridView_SelectAllGridRows('<xsl:value-of select="$varGridId"/>',window,event);</xsl:attribute>
                        <xsl:apply-templates select="$varHeaderCell" />
                      </xsl:when>
                      <xsl:otherwise>
                        &#160;
                      </xsl:otherwise>
                    </xsl:choose>
                  </div>
              </xsl:if>
            
			  <!--Draw forzen column headers-->
              <xsl:if test="$varFrozenColumnsWidth &gt; 0">
                <div style="position:absolute;top:0px;{$left}:{$varRowHeadersWidth}px;height:{$varColumnHeadersHeight}px;width:{$varFrozenColumnsWidth}px;">
                  <xsl:for-each select="$varFrozenColumns">
                    <xsl:apply-templates select=".">
                      <xsl:with-param name="prmGridId" select="$varGridId"/>
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:apply-templates>
                  </xsl:for-each>
                </div>
              </xsl:if>

              <!--Draw frozen row headers-->
              <xsl:if test="$varFrozenRowsHeight &gt; 0">
                <div class="VirtualDataGridView-RowHeaders DataGridView-Cells" style="position:absolute;top:{$varColumnHeadersHeight}px;{$left}:0px;width:{$varRowHeadersWidth}px;height:{$varFrozenRowsHeight}px;">
                  <xsl:for-each select="$varFrozenRows">

                    <migration-ignore>
                      <xsl:variable name="varBlockPosition" select="ceiling(number(position()) div number($varVirtualBlockSize))"/>
                      <xsl:variable name="varRowsInPreviousBlocks" select="$varBlocks[position() &lt; number($varBlockPosition)]/WG:Tags.DataGridViewRow"/>
                    </migration-ignore>

                    <xsl:variable name="varPreviousFrozenRowsHeightInSameBlock" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.Frozen='1']/@Attr.Height)"/>
                    <xsl:variable name="varPreviousFrozenRowsChildHeightInSameBlock" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.Frozen='1' and @Attr.IsExpanded='1']/@Attr.ChildGridHeight)"/>
                    <xsl:variable name="varPreviousRowsHeightInPreviousBlocks">
                      <migration-ignore>
                        <xsl:value-of select="sum($varRowsInPreviousBlocks/@Attr.Height)"/>
                      </migration-ignore>
                    </xsl:variable>
                    <xsl:variable name="varPreviousRowsChildHeightInPreviousBlocks">
                      <migration-ignore>
                        <xsl:value-of select="sum($varRowsInPreviousBlocks[@Attr.IsExpanded='1']/@Attr.ChildGridHeight)"/>
                      </migration-ignore>
                    </xsl:variable>

                    <migration-write>
                      <![CDATA[
                        varPreviousRowsHeightInPreviousBlocks = this.parent().xsum("preceding-sibling::WG:DGVB/WG:DR[@FZ = '1']/@H");
                        varPreviousRowsChildHeightInPreviousBlocks = this.parent().xsum("preceding-sibling::WG:DGVB/WG:DR[@FZ = '1' and @Attr.IsExpanded='1']/@Attr.ChildGridHeight");
                        ]]>
                    </migration-write>

                    <xsl:variable name="varTop" select="$varPreviousFrozenRowsHeightInSameBlock+$varPreviousFrozenRowsChildHeightInSameBlock+$varPreviousRowsHeightInPreviousBlocks+$varPreviousRowsChildHeightInPreviousBlocks"/>
                    <div id="VWGROW1_{$varGridId}_{@Attr.MemberID}" style="position:absolute;width:100%;height:{@Attr.Height}px;{$left}:0px;top:{$varTop}px;">
                      <xsl:call-template name="tplDrawRowHeaderVirtual" >
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

              <!--Draw cells for forzen rows and frozen columns-->
              <xsl:if test="($varFrozenRowsHeight &gt; 0) and ($varFrozenColumnsWidth &gt; 0)">
                <div class="DataGridView-Cells" style="position:absolute;top:{$varColumnHeadersHeight}px;{$left}:{$varRowHeadersWidth}px;width:{$varFrozenColumnsWidth}px;height:{$varFrozenRowsHeight}px;">
                  <xsl:for-each select="$varFrozenRows">
                    <xsl:variable name="varBlockPosition" select="ceiling(number(position()) div number($varVirtualBlockSize))" migration-select="this.parent().xcount(&quot;preceding-sibling::WG:DGVB&quot;)"/>
                    <xsl:variable name="varPreviousBlocks" select="$varBlocks[position() &lt; number($varBlockPosition)]" migration-select="varBlocks.filter(function (){return this.xcount(&quot;preceding-sibling::WG:DGVB&quot;) &lt; $.xpath(&quot;number&quot;, varBlockPosition);})" />
                    <xsl:variable name="varRowTop1" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.Frozen='1']/@Attr.Height)+sum($varPreviousBlocks/WG:Tags.DataGridViewRow/@Attr.Height)"/>
                    <div style="position:absolute;width:{$varFrozenColumnsWidth}px;height:{@Attr.Height}px;top:{$varRowTop1}px;{$left}:0px;">
                      <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]">
                        <xsl:variable name="varPosition" select="position()" migration-select="$.xpath('position', this)-this.xcount(&quot;preceding-sibling::WG:DL[@TP = '7']&quot;)" />
                        <xsl:if test="$varColumns[position()=$varPosition]/@Attr.Frozen='1'" migration-test="varColumns.xposition(varPosition).attr('Attr.Frozen') == '1'">
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
          </xsl:if>

          <!--Draw frozen rows-->

          <div id="VWGDGVFROZENCOLUMNS_{$varGridId}">
            <xsl:attribute name="style">              
              position:absolute;height:100%;<xsl:value-of select="$right" />:0px;<xsl:value-of select="$left" />:<xsl:value-of select="$varFrozenColumnsWidth + $varRowHeadersWidth" />px;top:0px;overflow:hidden;            
            </xsl:attribute>            
            <div style="position:relative;width:{$varColumnsWidthWithExpansionColumn}px;">
              <!--Draw columns header-->
              <xsl:if test="$varShowColumnHeaders">
                <div style="position:relative;top:0px;height:{$varColumnHeadersHeight}px;width:100%;{$left}:0px;overflow:hidden;">
                  <xsl:if test="$varShouldDrawExpansionColumn">
                    <div class="DataGridView-ColumnHeader DataGridView-ExpandCollapseColumn" style="float:{$left};height:{$varColumnHeadersHeight}px;"></div>
                  </xsl:if>

                  <xsl:for-each select="$varNonFrozenColumns">
                    <xsl:apply-templates select=".">
                      <xsl:with-param name="prmGridId" select="$varGridId"/>
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:apply-templates>
                  </xsl:for-each>
                </div>
              </xsl:if>

              <!--Draw cells for frozen rows and none frozen columns-->
              <xsl:if test="$varFrozenRowsHeight &gt; 0">
                <div style="position:relative;height:{$varFrozenRowsHeight}px;width:100%;">
                  <xsl:for-each select="$varFrozenRows">
                    <migration-ignore>
                      <xsl:variable name="varBlockPosition" select="ceiling(number(position()) div number($varVirtualBlockSize))"/>
                      <xsl:variable name="varRowsInPreviousBlocks" select="$varBlocks[position() &lt; number($varBlockPosition)]/WG:Tags.DataGridViewRow"/>
                    </migration-ignore>

                    <xsl:variable name="varPreviousFrozenRowsHeightInSameBlock" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.Frozen='1']/@Attr.Height)"/>
                    <xsl:variable name="varPreviousFrozenRowsChildHeightInSameBlock" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.Frozen='1' and @Attr.IsExpanded='1']/@Attr.ChildGridHeight)"/>
                    <xsl:variable name="varPreviousRowsHeightInPreviousBlocks">
                      <migration-ignore>
                        <xsl:value-of select="sum($varRowsInPreviousBlocks/@Attr.Height)"/>
                      </migration-ignore>
                    </xsl:variable>
                    <xsl:variable name="varPreviousRowsChildHeightInPreviousBlocks">
                      <migration-ignore>
                        <xsl:value-of select="sum($varRowsInPreviousBlocks[@Attr.IsExpanded='1']/@Attr.ChildGridHeight)"/>
                      </migration-ignore>
                    </xsl:variable>

                    <migration-write>
                      <![CDATA[
                        varPreviousRowsHeightInPreviousBlocks = this.parent().xsum("preceding-sibling::WG:DGVB/WG:DR[@FZ = '1']/@H");
                        varPreviousRowsChildHeightInPreviousBlocks = this.parent().xsum("preceding-sibling::WG:DGVB/WG:DR[@FZ = '1' and @Attr.IsExpanded='1']/@Attr.ChildGridHeight");
                        ]]>
                    </migration-write>
                    <xsl:variable name="varRowTop2" select="$varPreviousFrozenRowsHeightInSameBlock+$varPreviousFrozenRowsChildHeightInSameBlock+$varPreviousRowsHeightInPreviousBlocks+$varPreviousRowsChildHeightInPreviousBlocks"/>

                    <xsl:if test="$varShouldDrawExpansionColumn">
                      <xsl:call-template name="tplDrawExpandCollapse">
                        <xsl:with-param name="prmIsExpanded" select="@Attr.IsExpanded" />
                        <xsl:with-param name="prmExpansionIndicator" select="$varExpansionIndicator" />
                        <xsl:with-param name="prmTop" select="$varRowTop2" />
                        <xsl:with-param name="prmGridId" select="$varGridId" />
                        <xsl:with-param name="prmExpandCollapseOnClick" select="'mobjApp.DataGridView_ExpandCollapseClick'"/>
                      </xsl:call-template>
                    </xsl:if>
                    
                    <div>
                      <xsl:attribute name="style">position:absolute;width:<xsl:value-of select="$varColumnsWidth"/>px;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$varRowTop2"/>px;<xsl:if test="$varShouldDrawExpansionColumn"><xsl:value-of select="$left" />:[Skin.ExpandCollapseColumnWidth]px;</xsl:if>;</xsl:attribute>
                      <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]">
                        <xsl:variable name="varPosition" select="position()" migration-select="$.xpath('position', this)-this.xcount(&quot;preceding-sibling::WG:DL[@TP = '7']&quot;)" />
                        <xsl:if test="not($varColumns[position()=$varPosition]/@Attr.Frozen='1')" migration-test="varColumns.xposition(varPosition).attr('Attr.Frozen') != '1'">
                          <xsl:apply-templates select=".">
                            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                          </xsl:apply-templates>
                        </xsl:if>
                      </xsl:for-each>
                    </div>
                    
                    <xsl:if test="$varIsHierarchic='1' and @Attr.IsExpanded='1'">
                      <xsl:call-template name="tplDrawChildGrid">
                        <xsl:with-param name="prmChildGridHeight"  select="@Attr.ChildGridHeight" />
                        <xsl:with-param name="prmTop"  select="number($varRowTop2)+number(@Attr.Height)" />
                        <xsl:with-param name="prmWidth" select="$varColumnsWidthWithExpansionColumn" />
                        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                      </xsl:call-template>
                    </xsl:if>

                  </xsl:for-each>
                </div>
              </xsl:if>
            </div>
          </div>
          <!-- In case if user is allowed to order column, draw the additional draggable div to make the columns dragging to the first position possible -->
          <xsl:if test="@Attr.AllowUserToOrderColumns and $varRowHeadersWidth = 0">
            <div style="position:absolute;{$left}:{$varRowHeadersWidth};top:0px;width:2px;height:100%;" data-vwgdragable="1" id="VWG_DGFDHC_{$varGridId}">
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="'100%'" />
                <xsl:with-param name="prmImageWidth"  select="'100%'" />
              </xsl:call-template>
            </div>
          </xsl:if>
        </div>
      </xsl:if>
      
      <xsl:variable name="varShowPaging" select="@Attr.TotalPages &gt; 1" /> 
      
      <!--Draw body row-->
      <div>
        <xsl:attribute name="style">
          position:absolute;left:0px;right:0px;top:<xsl:value-of select="number($varGroupingAreaHeight) + number($varCaptionHeight) + number($varFrozenHorizontalBlockHeight) + $varExtendedColumnsTotalHeight"/>px;bottom:<xsl:choose>            
            <xsl:when test="$varShowPaging">[Skin.PagingPanelHeight]</xsl:when>            
            <xsl:otherwise>0</xsl:otherwise>          
          </xsl:choose>px;        
        </xsl:attribute>          
        <div style="height:100%;width:100%;">
            <div data-vwgscrollable="VWGVLSC_{$varGridId}" style="position:absolute;height:100%;width:100%;overflow:hidden;">
              <div style="position:relative;height:100%;width:100%;overflow:hidden" onmousewheel="mobjApp.DataGridView_OnBlocksContainerMouseWheel(event,this.parentNode.nextSibling);">
                <div id="VWGBlocksContainer_{$varGridId}" style="position:absolute;z-index:2;width:{$varColumnsWidthWithExpansionColumn+$varFrozenColumnsWidth+$varRowHeadersWidth}px;height:100%;top:0px;overflow:hidden;{$left}:0px;">
                  <xsl:apply-templates select="WG:Tags.DataGridViewBlock" >
                    <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                  </xsl:apply-templates>
                </div>
              </div>
            </div>
            <xsl:variable name="varScrollbars" select="@Attr.Scrollbars" />
          <xsl:call-template name="tplCompleteScrollCapabilities">            
            <xsl:with-param name="prmScrollbars" select="$varScrollbars" />
            <xsl:with-param name="prmScrollMoveHandler" select="'mobjApp.DataGridView_iScrollSyncScrollers'"/>
          </xsl:call-template>
          <div id="VWGVLSC_{$varGridId}" class="VirtualDataGridView-VirtualScroller" onresize="mobjApp.DataGridView_InitializeBlocksContainer(this.previousSibling.firstChild.firstChild,this);mobjApp.DataGridView_SyncVirtualScrollers(window,this,this.previousSibling.firstChild.firstChild,'{$varGridId}','{$dir}');">
            <xsl:call-template name="tplApplyScrollableAttributes">
              <xsl:with-param name="prmCustomScrollingHandler" select="concat('mobjApp.DataGridView_SyncVirtualScrollers(window,this,this.previousSibling.firstChild.firstChild,&quot;',$varGridId,'&quot;,&quot;',$dir,'&quot;)')"/>
            </xsl:call-template>
            <xsl:attribute name="style">
                height:100%;width:100%;top:0px;<xsl:value-of select="$left"/>:0px;z-index:1;position:relative;
                <xsl:choose>
                  <!-- Scrollbars None -->
                  <xsl:when test="$varScrollbars and $varScrollbars='0'">overflow:hidden;</xsl:when>
                  <!-- Scrollbars Horizontal -->
                  <xsl:when test="$varScrollbars and $varScrollbars='1'">overflow-x:auto;overflow-y:hidden;</xsl:when>
                  <!-- Scrollbars Vertical -->
                  <xsl:when test="$varScrollbars and $varScrollbars='2'">overflow-x:hidden;overflow-y:auto;</xsl:when>
                  <!-- Scrollbars Both -->
                  <xsl:otherwise>overflow:auto;</xsl:otherwise>
                </xsl:choose>
              </xsl:attribute>
              <div style="position:absolute;width:{$varColumnsWidthWithExpansionColumn+$varFrozenColumnsWidth+$varRowHeadersWidth}px;height:{$varBlocksHeight}px;top:0px;{$left}:0px;">&#160;</div>
              <xsl:call-template name="tplRestoreScroll">
                <xsl:with-param name="prmGuid" select="@Attr.Id" />
                <xsl:with-param name="prmBeforeRestoreHandler" select="'mobjApp.DataGridView_BeforeRestoreScrollHandler'"/>
                <xsl:with-param name="prmAfterRestoreHandler" select="'mobjApp.DataGridView_AfterRestoreScrollHandler'"/>
              </xsl:call-template>
            </div>
          </div>
        </div>            
	    <!--Paging-->      
      <xsl:if test="$varShowPaging">        
        <div class="DataGridView-PagingPanelStyle" style="height:[Skin.PagingPanelHeight]px;position:absolute;bottom:0px;left:0px;right:0px;">          
          <xsl:call-template name="tplDrawDataGridViewPaging"/>        
        </div>      
      </xsl:if>    
    </div>  
  </xsl:template>
  
  <!--Block rendering-->
  <xsl:template match="WG:Tags.DataGridViewBlock">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:variable name="varColumns" select="../WG:Tags.DataGridViewColumn"/>
    <xsl:variable name="varRows" select="WG:Tags.DataGridViewRow" />
    <xsl:variable name="varNonFrozenColumns" select="$varColumns[not(@Attr.Frozen='1')]" />
    <xsl:variable name="varFrozenColumns" select="$varColumns[@Attr.Frozen='1']" />
    <xsl:variable name="varNonFrozenRows" select="$varRows[not(@Attr.Frozen='1')]" />
    <xsl:variable name="varFrozenRows" select="$varRows[@Attr.Frozen='1']" />
    <xsl:variable name="varColumnHeadersHeight" select="../@Attr.ColumnHeaders" />
    <xsl:variable name="varShowColumnHeaders" select="not($varColumnHeadersHeight='0')" />
    <xsl:variable name="varRowHeadersWidth" select="../@Attr.RowHeaders" />
    <xsl:variable name="varShowRowHeaders" select="not($varRowHeadersWidth='0')" />
    <xsl:variable name="varIsHierarchic" select="../@Attr.IsHierarchic" />
    <xsl:variable name="varExpansionIndicator" select="../@Attr.ExpansionIndicator" />
    <xsl:variable name="varShouldDrawExpansionColumn" select="$varIsHierarchic='1' and not($varExpansionIndicator='2')" />
    <xsl:variable name="varColumnsWidth">
      <xsl:choose>
        <xsl:when test="$varShouldDrawExpansionColumn"><xsl:value-of select="sum($varNonFrozenColumns/@Attr.Width)+number([Skin.ExpandCollapseColumnWidth])" /></xsl:when>
        <xsl:otherwise><xsl:value-of select="sum($varNonFrozenColumns/@Attr.Width)" /></xsl:otherwise>
      </xsl:choose> 
    </xsl:variable>    
    <xsl:variable name="varRowsHeight" select="sum($varNonFrozenRows/@Attr.Height) + sum(WG:Tags.DataGridViewRow[@Attr.IsExpanded='1' and not(@Attr.Frozen='1')]/@Attr.ChildGridHeight)" migration-select="0" />    
    <xsl:variable name="varFrozenColumnsWidth" select="sum($varFrozenColumns/@Attr.Width)" />
    <xsl:variable name="varFrozenRowsHeight" select="sum($varFrozenRows/@Attr.Height) + sum(WG:Tags.DataGridViewRow[@Attr.IsExpanded='1' and @Attr.Frozen='1']/@Attr.ChildGridHeight)" migration-select="0" />
    <xsl:variable name="varFrozenVerticalBlockWidth" select="number($varRowHeadersWidth+$varFrozenColumnsWidth)" />
    <xsl:variable name="varGridId" select="../@Attr.Id" />

    <migration-write>
      <![CDATA[
varNonFrozenRows.xeach(function()
{
  varRowsHeight += $.xpath("number", this.attr("Attr.Height"));
  
  if(this.attr("Attr.IsExpanded") == "1")
  {
    varRowsHeight += $.xpath("number", this.attr("Attr.ChildGridHeight"));
  }
});

varFrozenRows.xeach(function()
{
  varFrozenRowsHeight += $.xpath("number", this.attr("Attr.Height"));

  if(this.attr("Attr.IsExpanded") == "1")
  {
    varFrozenRowsHeight += $.xpath("number", this.attr("Attr.ChildGridHeight"));
  }
});

      ]]>
    </migration-write>

    <div id="VWG_{$varGridId}_{@Attr.MemberID}" data-vwg_IsDrawn="{@Attr.Visible}" data-vwg_IsLoaded="{@Attr.Loaded}" style="display:block;width:100%;height:{@Attr.Height}px;background:white">
      <xsl:if test="@Attr.Visible='1'">
        <div style="display:block;width:100%;height:100%;position:relative;">
          <!--Draw grid body-->
          <div style="width:{$varColumnsWidth}px;height:100%;position:absolute;{$right}:0px;">
            <xsl:choose>
              <xsl:when test="(count($varNonFrozenColumns) &gt; 0) and (count($varNonFrozenRows) &gt; 0)">
                <xsl:apply-templates select="$varNonFrozenRows" >
                  <xsl:with-param name="prmColumns" select="$varColumns"/>
                  <xsl:with-param name="prmNonFrozenColumns"  select="$varNonFrozenColumns"/>
                  <xsl:with-param name="prmFrozenColumns" select="$varFrozenColumns" />
                  <xsl:with-param name="prmGridId" select="$varGridId" />
                  <xsl:with-param name="prmSelectionMode" select="../@Attr.SelectionMode" />
                  <xsl:with-param name="prmEnabled" select="not($prmIsEnabled='0')" />
                  <xsl:with-param name="prmIsHierarchic" select="$varIsHierarchic" />
                  <xsl:with-param name="prmExpansionIndicator" select="$varExpansionIndicator" />
                </xsl:apply-templates>
              </xsl:when>
              <xsl:otherwise>&#160;</xsl:otherwise>
            </xsl:choose>
          </div>
          <div id="VWGDGVFROZENROWS_{$varGridId}_{@Attr.MemberID}" style="position:absolute;{$left}:0px;width:{$varFrozenVerticalBlockWidth}px;">
            <!--Draw rows header-->
            <xsl:if test="$varShowRowHeaders">
              <div class="VirtualDataGridView-RowHeaders DataGridView-Cells" style="height:{$varRowsHeight}px;width:{$varRowHeadersWidth}px;position:relative;float:{$left};">
                <xsl:for-each select="$varNonFrozenRows">
                  <xsl:variable name="varTop" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[not(@Attr.Frozen='1')]/@Attr.Height)+sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.IsExpanded='1' and not(@Attr.Frozen='1')]/@Attr.ChildGridHeight)" />
                  <div id="VWGROW1_{$varGridId}_{@Attr.MemberID}" style="position:absolute;width:100%;height:{@Attr.Height}px;{$left}:0px;top:{$varTop}px;">
                    <xsl:call-template name="tplDrawRowHeaderVirtual" >
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
            <!--Draw cells for none forzen rows and frozen columns-->
            <xsl:if test="$varFrozenColumnsWidth &gt; 0">
              <div style="height:{$varRowsHeight}px;width:{$varFrozenColumnsWidth}px;position:relative;float:{$left};" class="DataGridView-Cells">
                <xsl:for-each select="$varNonFrozenRows">
                  <xsl:variable name="varRowTop3" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[not(@Attr.Frozen='1')]/@Attr.Height)"/>
                  <div style="position:absolute;width:{$varFrozenColumnsWidth}px;height:{@Attr.Height}px;top:{$varRowTop3}px;{$left}:0px;">
                    <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7')]">
                      <xsl:variable name="varPosition" select="position()" migration-select="$.xpath('position', this)-this.xcount(&quot;preceding-sibling::WG:DL[@TP = '7']&quot;)" />
                      <xsl:if test="$varColumns[position()=$varPosition]/@Attr.Frozen='1'"  migration-test="varColumns.xposition(varPosition).attr('Attr.Frozen') == '1'">
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
      </xsl:if>
    </div>
  </xsl:template>

  <!--Row matching-->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../../@Attr.Id" />
    <xsl:param name="prmSelectionMode" select="../../@Attr.SelectionMode" />
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')" />
    <xsl:param name="prmIsHierarchic" select="'0'" />
    <xsl:param name="prmExpansionIndicator" select="'4'" />

    <xsl:call-template name="tplDrawVirtualDataGridViewRow">
      <xsl:with-param name="prmColumns" select="$prmColumns" />
      <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
      <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
      <xsl:with-param name="prmGridId" select="$prmGridId" />
      <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode" />
      <xsl:with-param name="prmEnabled" select="$prmEnabled" />
      <xsl:with-param name="prmIsHierarchic" select="$prmIsHierarchic" />
      <xsl:with-param name="prmExpansionIndicator" select="$prmExpansionIndicator" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVirtualDataGridViewRow">
    <xsl:param name="prmColumns" select="../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../../@Attr.Id" />
    <xsl:param name="prmSelectionMode" select="../../@Attr.SelectionMode" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')" />
    <xsl:param name="prmIsHierarchic" select="'0'" />
    <xsl:param name="prmExpansionIndicator" select="'4'" />
    <xsl:variable name="varShouldDrawExpansionColumn" select="$prmIsHierarchic='1' and not($prmExpansionIndicator='2')" />
    <xsl:variable name="varWidth" select="sum($prmNonFrozenColumns/@Attr.Width)" />
    <xsl:variable name="varTop" select="sum(preceding-sibling::WG:Tags.DataGridViewRow[not(@Attr.Frozen='1')]/@Attr.Height)+sum(preceding-sibling::WG:Tags.DataGridViewRow[@Attr.IsExpanded='1' and not(@Attr.Frozen='1')]/@Attr.ChildGridHeight)"/>

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
        <xsl:with-param name="prmExpandCollapseOnClick" select="'mobjApp.DataGridView_ExpandCollapseClick'"/>
      </xsl:call-template>
    </xsl:if>
    
    <div id="VWGROW2_{$prmGridId}_{@Attr.MemberID}">
      <xsl:attribute name="style">position:absolute;width:<xsl:value-of select="$varWidth"/>px;height:<xsl:value-of select="@Attr.Height"/>px;top:<xsl:value-of select="$varTop"/>px;<xsl:if test="$varShouldDrawExpansionColumn"><xsl:value-of select="$left" />: [Skin.ExpandCollapseColumnWidth]px;</xsl:if><xsl:call-template name="tplApplyStyles"><xsl:with-param name="prmBorder" select="1" /><xsl:with-param name="prmBackground" select="0" /><xsl:with-param name="prmFont" select="0" /><xsl:with-param name="prmCursor" select="0" /></xsl:call-template></xsl:attribute>
      <xsl:for-each select="WG:Tags.DataGridViewCell[not(@Attr.Type='7') and not(@Attr.Frozen='1')]">
        <xsl:variable name="varPosition" select="position()" migration-select="$.xpath('position', this)-this.xcount(&quot;preceding-sibling::WG:DL[@TP = '7']&quot;)" />
        <xsl:if test="$prmColumns[position()=$varPosition][not(@Attr.Frozen='1')]" migration-test="prmColumns.xposition( varPosition).attr(&quot;Attr.Frozen&quot;)!='1'">
          <xsl:apply-templates select=".">
            <xsl:with-param name="prmColumns" select="$prmColumns"/>
            <xsl:with-param name="prmGridId" select="$prmGridId" />
            <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
            <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
            <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
            <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
          </xsl:apply-templates>
        </xsl:if>
      </xsl:for-each>
    </div>

    <xsl:if test="$prmIsHierarchic='1' and @Attr.IsExpanded='1'">
      <xsl:call-template name="tplDrawChildGrid">
        <xsl:with-param name="prmChildGridHeight"  select="@Attr.ChildGridHeight" />
        <xsl:with-param name="prmTop"  select="number($varTop)+number(@Attr.Height)" />
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <!-- A datagridview cell that contained in a datagridview row. -->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[not(@Attr.Type='7')]">
    <xsl:param name="prmColumns" select="../../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../../../@Attr.Id"/>
    <xsl:param name="prmSelectionMode" select="../../../@Attr.SelectionMode"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')"/>

    <xsl:call-template name="tplDrawVirtualRowDataGridViewCell">
      <xsl:with-param name="prmColumns" select="$prmColumns" />
      <xsl:with-param name="prmNonFrozenColumns"  select="$prmNonFrozenColumns"/>
      <xsl:with-param name="prmFrozenColumns" select="$prmFrozenColumns" />
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
      <xsl:with-param name="prmSelectionMode" select="$prmSelectionMode"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmEnabled" select="$prmEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVirtualRowDataGridViewCell">
    <xsl:param name="prmColumns" select="../../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmNonFrozenColumns"  select="$prmColumns[not(@Attr.Frozen='1')]"/>
    <xsl:param name="prmFrozenColumns" select="$prmColumns[@Attr.Frozen='1']" />
    <xsl:param name="prmGridId" select="../../../@Attr.Id"/>
    <xsl:param name="prmSelectionMode" select="../../../@Attr.SelectionMode"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmEnabled" select="not($prmIsEnabled='0')"/>
    <xsl:param name="prmSelectOnRightClick" select="../../../@Attr.SelectOnRightClick"/>

    <xsl:variable name="varCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:variable name="varContainingColumn" select="$prmColumns[position()=$varCellPosition]" />
    <xsl:variable name="varContainedInFrozenColumn" select="$varContainingColumn/@Attr.Frozen" />
    <xsl:variable name="varWidth" select="$varContainingColumn/@Attr.Width" />
    <xsl:variable name="varSelected" select="(($prmSelectionMode='1' or $prmSelectionMode='8') and @Attr.Selected='1') or (($prmSelectionMode='2' or $prmSelectionMode='8') and ../@Attr.Selected='1')" />
    <xsl:variable name="varActive" select="@Attr.Active='1'" />
    <xsl:variable name="varLeft">
      <xsl:if test="$varContainedInFrozenColumn">
        <xsl:value-of select="sum($prmColumns[(position() &lt; $varCellPosition) and (@Attr.Frozen='1')]/@Attr.Width)" migration-select="varContainingColumn.attr(&quot;Attr.Left&quot;)" />
      </xsl:if>
      <xsl:if test="not($varContainedInFrozenColumn)">
        <xsl:value-of select="sum($prmColumns[(position() &lt; $varCellPosition) and not(@Attr.Frozen)]/@Attr.Width)" migration-select="varContainingColumn.attr(&quot;Attr.Left&quot;)" />
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varPanel" select="WC:Tags.Panel"/>

    <div id="VWG_{$prmGridId}_{@Attr.MemberID}">
      <xsl:attribute name="class">
        <xsl:if test="$varSelected and not($varActive)">DataGridView-Cell_Selected</xsl:if>
        <xsl:if test="not($varSelected) or $varActive">DataGridView-Cell</xsl:if>
      </xsl:attribute>
      <xsl:choose>
        <xsl:when test="$varPanel">
          <xsl:call-template name="tplDrawDataGridViewCellPanel">
            <xsl:with-param name="prmColumns" select="$prmColumns"/>
            <xsl:with-param name="prmPanel" select="$varPanel"/>
            <xsl:with-param name="prmContainedInFrozenColumn" select="$varContainedInFrozenColumn"/>
            <xsl:with-param name="prmLeft" select="$varLeft"/>
            <xsl:with-param name="prmCellBorderStyle" select="../../../@Attr.CellBorderStyle" />
            <xsl:with-param name="prmGridLines" select="'[Skin.GridLines]'"/>
        </xsl:call-template>
      </xsl:when>
        <xsl:otherwise>
          <xsl:apply-templates mode="modTraceableEvents" select="." />
          <xsl:apply-templates mode="modEventCaptures" select="." />
          <xsl:attribute name="style">
            z-index:0;position:absolute;<xsl:value-of select="$left"/>:<xsl:value-of select="$varLeft"/>px;top:0px;width:<xsl:value-of select="$varWidth"/>px;height:100%;
            <xsl:call-template name="tplApplyDataGridViewCellStyleVirtual">
              <xsl:with-param name="prmColumns" select="$prmColumns"/>
              <xsl:with-param name="prmCellPosition" select="$varCellPosition"/>
            </xsl:call-template>
          </xsl:attribute>
          <xsl:if test="$prmEnabled">
            <xsl:call-template name="tplDataGridViewCellEventsVirtual">
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
        </xsl:otherwise>
      </xsl:choose>
    </div>
  </xsl:template>

  <!--A match for a datagridview column-->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewColumn">
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:call-template name="tplDrawVirtualDataGridViewColumn">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVirtualDataGridViewColumn">
    <xsl:param name="prmGridId" select="../@Attr.Id"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varMemberID" select="@Attr.MemberID" />
    <xsl:variable name="varName" select="@Attr.Name" />
    <xsl:variable name="varResizable" select="not(@Attr.Resize='0') and not($prmIsEnabled='0')" />
    <xsl:variable name="varContainedCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']"/>
    <xsl:variable name="varContainedCellBackColor">
      <xsl:if test="$varContainedCell and $varContainedCell/@Attr.Background and not($varContainedCell/@Attr.Background='')"><xsl:value-of select="$varContainedCell/@Attr.Background"/></xsl:if>
    </xsl:variable>

    <div id="VWG_{$prmGridId}_{$varMemberID}" style="float:{$left};height:100%;width:{@Attr.Width}px;" class="Common-HandCursor DataGridView-ColumnHeader" data-vwgdragable="1">
      <xsl:attribute name="data-vwggroupingcolumnname"><xsl:value-of select="$varName"/></xsl:attribute>
      <div class="DataGridView-ColumnHeaderSplitter">
        <xsl:attribute name="style">padding-<xsl:value-of select="$right"/>:3px;height:100%;<xsl:if test="not($varResizable)">cursor:pointer;</xsl:if><xsl:if test="$varContainedCellBackColor">background-color:<xsl:value-of select="$varContainedCellBackColor"/>;</xsl:if></xsl:attribute>
        <xsl:attribute name="ondblclick">mobjApp.DataGridView_ColumnDividerDoubleClick(this,'<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="$varMemberID"/>',event,window);</xsl:attribute>

        <xsl:if test="$varResizable">
          <xsl:attribute name="onmousedown">mobjApp.DataGridView_ColumnDividerMouseDown(this,'<xsl:value-of select="$prmGridId"/>','<xsl:value-of select="$varMemberID"/>',true,window,event);</xsl:attribute>
        </xsl:if>
        <div style="overflow:hidden;width:100%;height:100%;" class="Common-HandCursor" onmousedown="mobjApp.DataGridView_OnColumnHeaderMouseDown('{$prmGridId}','{$varMemberID}',window,event)">
          <div class="Common-HandCursor"  style="height:100%;width:100%;overflow:hidden;position:relative;">
            <xsl:apply-templates select="$varContainedCell" >
              <xsl:with-param name="prmGridId" select="$prmGridId" />
            </xsl:apply-templates>
          </div>
        </div>
      </div>
    </div>
  </xsl:template>

  <!-- A datagridview cell that contained in a datagridview column. -->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewColumn/WG:Tags.DataGridViewCell[@Attr.Type='7']">
    <xsl:param name="prmGridId" select="../../@Attr.Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:call-template name="tplDrawColumnDataGridViewCell">
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmSortAscendingImage" select="'[Skin.SortAscendingIndicatorImage]'"/>
      <xsl:with-param name="prmSortDescendingImage" select="'[Skin.SortDescendingIndicatorImage]'"/>
    </xsl:call-template>
  </xsl:template>

  <!-- A datagridview cell that contained in a datagridview row. -->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Type='7']">
    <xsl:param name="prmGridId" select="../../../@Attr.Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:call-template name="tplDrawVirtualRowDataGridViewHeaderCell">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmGridId" select="$prmGridId"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVirtualRowDataGridViewHeaderCell">
    <xsl:param name="prmGridId" select="../../../@Id"/>
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
  <xsl:template name="tplDrawRowHeaderVirtual">
    <xsl:param name="prmGridId" select="../../@Attr.Id" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varMemberID" select="@Attr.MemberID" />
    <xsl:variable name="varHeaderCell" select="WG:Tags.DataGridViewCell[@Attr.Type='7']" />
    <xsl:variable name="varGridEnabled" select="not($prmIsEnabled='0')"/>
    <xsl:variable name="varSelectionMode" select="../../@Attr.SelectionMode"/>
    <xsl:variable name="varFilterRow" select="@Attr.FilterRow"/>
    <xsl:variable name="varRowHeaderEditModeImage" select="'[Skin.RowHeaderEditModeImage]'"/>
    <xsl:variable name="varRowHeaderSelectedModeImage" select="'[Skin.RowHeaderSelectedModeImage]'"/>
    <xsl:variable name="varRowHeaderNewRowModeImage" select="'[Skin.RowHeaderNewRowModeImage]'"/>
    <xsl:variable name="varRowHeaderErrorProviderImage" select="'[Skin.RowHeaderErrorProviderImage]'"/>
    <xsl:variable name="varErrorMessage" select="@Attr.ErrorMessage"/>
    
    <xsl:attribute name="class">DataGridView-RowHeader<xsl:if test="@Attr.Selected='1'"> DataGridView-RowHeader_Selected</xsl:if></xsl:attribute>
    <div id="VWG_{$prmGridId}_{$varMemberID}" style="height:100%;">
      <xsl:if test="($varSelectionMode='2' or $varSelectionMode='8') and $varGridEnabled">
        <xsl:attribute name="onclick">mobjApp.DataGridView_RowHeaderClick(this,window,event,null,null,null,true);</xsl:attribute>
        <xsl:attribute name="oncontextmenu">mobjApp.DataGridView_RowHeaderClick(this,window,event,null,null,null,true);</xsl:attribute>
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
        <xsl:call-template name="tplDrawFilterRowHeader">
          <xsl:with-param name="prmGridId" select="$prmGridId"/>
        </xsl:call-template>
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
                        <xsl:when test="not(../../@Attr.ShowEditingIcon='0') and WG:Tags.DataGridViewCell[not(@Attr.Type='7') and @Attr.Active='1']" migration-test="this.parent().parent().attr(&quot;Attr.ShowEditingIcon&quot;, &quot;!=&quot;, &quot;0&quot;) &amp;&amp; {this}.xpath(&quot;WG:Tags.DataGridViewCell[not(@Attr.Type='7') and @Attr.Active = '1']&quot;).length &gt; 0">
                          <img src="{$varRowHeaderEditModeImage}" alt=""/>
                        </xsl:when>
                        <xsl:when test="../../@Attr.CurrentCell=WG:Tags.DataGridViewCell[not(@Attr.Type='7')]/@Attr.MemberID" migration-test="{this}.xpath(&quot;WG:Tags.DataGridViewCell[not(@Attr.Type='7') and @Attr.MemberID='&quot;+{this}.parent().parent().attr(&quot;Attr.CurrentCell&quot;)+&quot;']&quot;).length &gt; 0">
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
                        <img src="{$varRowHeaderErrorProviderImage}" alt="" />
                      </xsl:if>
                    </td>
                    <xsl:if test="$varHeaderCell">
                      <td>
                        <xsl:apply-templates select="$varHeaderCell"/>
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

  <!--Apply cell wrap mode -->
  <xsl:template name="tplApplyDataGridViewCellWrapModeVirtual">
    <xsl:if test="@Attr.WrapContents='1'">word-wrap:break-word;</xsl:if>
  </xsl:template>

  <!--Apply cell fore color -->
  <xsl:template name="tplApplyDataGridViewCellForeColorVirtual">
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
        <xsl:if test="$varForeColor">color:<xsl:value-of select="$varForeColor"/>;</xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Apply cell background color -->
  <xsl:template name="tplApplyDataGridViewCellBackgroundColorVirtual">
    <xsl:variable name="varSelected" select="@Attr.Selected='1' or ../@Attr.Selected='1'" />
    <xsl:variable name="varBackgroundColor" select="@Attr.Background" />
    <xsl:variable name="varSelectionBackColor" select="@Attr.SelectionBackColor" />

    <xsl:choose>
      <xsl:when test="$varSelected and not(@Attr.Active='1')">
        <xsl:if test="$varSelectionBackColor">background-color:<xsl:value-of select="$varSelectionBackColor"/>;</xsl:if>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="$varBackgroundColor">background-color:<xsl:value-of select="$varBackgroundColor"/>;</xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Apply cell style -->
  <xsl:template name="tplApplyDataGridViewCellStyleVirtual">
    <xsl:param name="prmColumns" select="../../../WG:Tags.DataGridViewColumn" />
    <xsl:param name="prmCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    
    <xsl:variable name="varBackgroundImageLayout" select="@Attr.BackgroundImageLayout" />
    <xsl:variable name="varMarginAll" select="@Attr.MarginAll" />
    <xsl:variable name="varMarginLeft" select="@Attr.MarginLeft" />
    <xsl:variable name="varMarginRight" select="@Attr.MarginRight" />
    <xsl:variable name="varMarginTop" select="@Attr.MarginTop" />
    <xsl:variable name="varMarginBottom" select="@Attr.MarginBottom" />

    <xsl:call-template name="tplApplyCellBorderStyle">
      <xsl:with-param name="prmColumns" select="$prmColumns" />
      <xsl:with-param name="prmCellPosition" select="$prmCellPosition" />
      <xsl:with-param name="prmCellBorderStyle" select="../../../@Attr.CellBorderStyle" />
      <xsl:with-param name="prmGridLines" select="'[Skin.GridLines]'"/>
    </xsl:call-template>

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
    <xsl:call-template name="tplApplyDataGridViewCellBackgroundColorVirtual"/>
    <xsl:call-template name="tplApplyDataGridViewCellPaddingVirtual"/>
    <xsl:call-template name="tplApplyDataGridViewCellForeColorVirtual"/>
    <xsl:call-template name="tplApplyDataGridViewCellWrapModeVirtual"/>
  </xsl:template>

  <!--Apply cell padding -->
  <xsl:template name="tplApplyDataGridViewCellPaddingVirtual">
    <xsl:if test="@Attr.PaddingAll or @Attr.PaddingLeft or @Attr.PaddingRight or @Attr.PaddingTop or @Attr.PaddingBottom">
      <xsl:call-template name="tplApplyPaddings"/>
    </xsl:if>
  </xsl:template>

  <!--Set cell events-->
  <xsl:template name="tplDataGridViewCellEventsVirtual">
    <xsl:param name="prmSelectOnRightClick"/>

    <xsl:attribute name="onclick">mobjApp.DataGridView_CellClick(this,window,event);</xsl:attribute>
    <xsl:if test="$prmSelectOnRightClick"><xsl:attribute name="oncontextmenu">mobjApp.DataGridView_CellClick(this,window,event);</xsl:attribute></xsl:if>
  </xsl:template>

  <!--Traceable events matching-->

  <!--Active TextBox-->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Type='1' and @Attr.Active='1']" mode="modTraceableEvents">
    <xsl:attribute name="data-vwg_AfterCreateEventHandler">DataGridView_AfterCreateTextBoxEvents</xsl:attribute>
  </xsl:template>

  <!--CheckBox-->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Type='2']" mode="modTraceableEvents">
    <xsl:attribute name="data-vwg_BeforeCreateEventHandler">DataGridView_BeforeCreateCheckBoxEvents</xsl:attribute>
  </xsl:template>

  <!--ComboBox-->
  <xsl:template match="WC:Tags.DataGridView[(not(@Attr.CustomStyle) or @Attr.CustomStyle='V') and (@Attr.Virtual='1')]/WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Type='6']" mode="modTraceableEvents">
    <xsl:attribute name="data-vwg_AfterCreateEventHandler">DataGridView_AfterCreateComboBoxEvents</xsl:attribute>
  </xsl:template>

</xsl:stylesheet>
