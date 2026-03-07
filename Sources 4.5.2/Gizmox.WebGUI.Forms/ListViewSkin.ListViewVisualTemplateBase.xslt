<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template name="tplListViewDetailsTableBodyRenderAPI">
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

    <xsl:variable name="varNewColumnsOrder" select="@Attr.VisualTemplateListViewNewColumnOrder" />
    <xsl:variable name="varSortedCols" select="$prmCols[@Attr.Sort='1' or @Attr.Sort='0']"/>

    <xsl:variable name="varGroupByColumn">
      <xsl:if test="string-length(@Attr.VisualTemplateListViewGrouping) &gt; 0 and not(@Attr.VisualTemplateListViewGrouping='None') and not(@Attr.VisualTemplateListViewGrouping='Original')">
        <xsl:choose>
          <xsl:when test="count($varSortedCols) >= 1">
            <xsl:value-of select="$varSortedCols[1]/@Attr.Name" migration-select="varSortedCols.xposition(1).attr(&quot;Attr.Name&quot;)"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:choose>
              <xsl:when test="$varNewColumnsOrder">
                <xsl:value-of select="concat('c',substring-before(concat($varNewColumnsOrder, '|'), '|'))" />
              </xsl:when>
              <xsl:otherwise>
                <xsl:if test="count($prmCols) &gt; 1">
                  <xsl:value-of select="$prmCols[1]/@Attr.Name" migration-select="prmCols.xposition(1).attr(&quot;Attr.Name&quot;)"/>
                </xsl:if>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:if>
    </xsl:variable>

    <!-- counting the number of | in the columns order to know the number of columns -->
    <xsl:variable name="varNumberOfOrderedColumns" select="string-length(translate($varNewColumnsOrder, '1234567890', '')) + 1" migration-select="(varNewColumnsOrder.split(&quot;|&quot;).length)"/>
    <xsl:variable name="varColSpanForGroups">
      <xsl:choose>
        <xsl:when test="not(@Attr.VisualTemplateListViewItemRowTemplate='None')">
          <xsl:apply-templates select="." mode="modListViewDetailedItemRowColumnsNumberVisualTemplate" >
            <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes" />          
          </xsl:apply-templates>
        </xsl:when>
        <xsl:when test="$varNumberOfOrderedColumns &gt; 0">
          <xsl:value-of select="$varNumberOfOrderedColumns*2+number($prmCheckBoxes='1')*2+1"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="count($prmCols)*2+number($prmCheckBoxes='1')*2+1"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>


    <migration-write migration-reason="Variable to count only LV rows.">
      var intRowIndex = 0; // Counter of current row index.
    </migration-write>
    <xsl:for-each select="$prmRows">
      <xsl:call-template name="tplListViewVisualTemplateRow">
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
        <xsl:with-param name="prmGroupByColumn" select="$varGroupByColumn"/>
        <xsl:with-param name="prmColSpanForGroups" select="$varColSpanForGroups" />
      </xsl:call-template>
      <migration-write>
        intRowIndex += (this.xname()=="Tags.Row" ? 1: 0); // Increase index if the element is a row.
      </migration-write>
    </xsl:for-each>
  </xsl:template>



  <xsl:template name="tplListViewVisualTemplateRow">
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
    <xsl:param name="prmGroupByColumn" />
    <xsl:param name="prmColSpanForGroups" />

    <xsl:variable name="varRow" select="."/>
    <!-- Calculate amount of listview rows before this row, module 2, if 0 (or even number) no alternate.-->
    <xsl:variable name="varAlternate" select="(count(preceding-sibling::Tags.Row) mod 2)=0" migration-select="(prmRowIndex % 2) == 0"/>
    <xsl:variable name="varHeight" select="../@Attr.ItemHeight"/>
    <xsl:variable name="varIsFullRowSelect" select="../@Attr.FullRowSelect='1'"/>


    <xsl:if test="name()='Tags.Group' and (not(../@Attr.VisualTemplateListViewGrouping) or ../@Attr.VisualTemplateListViewGrouping='Original')">
      <tr>
        <xsl:if test="$prmFlagMatchedElement=1">
          <xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute>
        </xsl:if>
        <td colspan="{$prmColSpanForGroups}" class="{$prmListViewGroupHeaderClass}">
          <xsl:apply-templates select="." mode="modListViewGroupHeader" >
            <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
          </xsl:apply-templates>
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="name()='Tags.Row'">
      <!-- Checking for preceding node to get the letter for the grouping -->
      <xsl:if test="$prmGroupByColumn and ../@Attr.VisualTemplateListViewGrouping='AlphabetGrouping'">
        <xsl:variable name="varPrecedingGroupNodeText" select="preceding-sibling::Tags.Row[1]/@*[name()=$prmGroupByColumn]/." migration-select="this.xpath(&quot;preceding-sibling::R[1]/@&quot; + prmGroupByColumn)" />
        <xsl:variable name="varCurrentGroupNodeText" select="@*[name()=$prmGroupByColumn]/." migration-select="this.xpath(&quot;@&quot; + prmGroupByColumn)" />
        <xsl:variable name="varPrecedingGroupingNodeFirstLetter" select="translate(substring($varPrecedingGroupNodeText,1,1),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ')" migration-select="(varPrecedingGroupNodeText[0] != undefined) ? varPrecedingGroupNodeText[0].nodeValue.substring(0,1).toUpperCase() : null"/>
        <xsl:variable name="varCurrentGroupingNodeFirstLetter" select="translate(substring($varCurrentGroupNodeText,1,1),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ')" migration-select="(varCurrentGroupNodeText[0] != undefined) ? varCurrentGroupNodeText[0].nodeValue.substring(0,1).toUpperCase() : null"/>
        <xsl:if test="position() = 1 or not($varPrecedingGroupingNodeFirstLetter = $varCurrentGroupingNodeFirstLetter)">
          <tr>
            <xsl:if test="$prmFlagMatchedElement=1">
              <xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute>
            </xsl:if>
            <td colspan="{$prmColSpanForGroups}" class="{$prmListViewGroupHeaderClass}">
              <xsl:call-template name="tplListViewDetailedCustomGroupHeader">
                <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="$prmListViewFontGroupHeaderSeperatorClass"/>
                <xsl:with-param name="prmGroupText" select="$varCurrentGroupingNodeFirstLetter" />
              </xsl:call-template>
            </td>
          </tr>
        </xsl:if>
      </xsl:if>

      <tr tabindex="-1" data-vwgfocuselement="1" data-swipable="yes">
        <xsl:if test="$prmFlagMatchedElement=1">
          <xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute>
        </xsl:if>
        <xsl:call-template name="tplSetToolTip">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:attribute name="id">VWG_<xsl:value-of select="@Id"/></xsl:attribute>
        <xsl:attribute name="style">
          height:<xsl:value-of select="$varHeight" />px;<xsl:call-template name="tplApplyOnDrawVisualEffects" />
        </xsl:attribute>
        <xsl:call-template name="tplSetClientUniqueId" />
        <xsl:call-template name="tplApplyDragAndDrop" />
        <xsl:attribute name="class">
          <xsl:text>Common-HideFocus </xsl:text>
          <xsl:value-of select="$prmListViewFontDataClass" />
          <xsl:text> Common-HandCursor </xsl:text>
          <xsl:choose>
            <xsl:when test="$varAlternate">
              <xsl:value-of select="concat(' ',$prmListViewDataRow0Class,' ',$prmListViewDataRow1Class)"  />
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="$prmListViewDataRow0Class" />
            </xsl:otherwise>
          </xsl:choose>

          <xsl:choose>
            <xsl:when test="$varIsFullRowSelect">
              <xsl:value-of select="concat(' ',$prmListViewDataFullRowClass,' ')"/>
              <xsl:if test="@Attr.Selected='1'">
                <xsl:value-of select="concat(' ',$prmListViewDataFullRowClass,'_Selected')" />
              </xsl:if>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="concat(' ',$prmListViewDataRowClass,' ')"/>
              <xsl:if test="@Attr.Selected='1'">
                <xsl:value-of select="concat(' ',$prmListViewDataRowClass,'_Selected')" />
              </xsl:if>
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


  <xsl:template name="tplListViewVisualTemplateDetailedColumnsAPI">
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />

    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
    <xsl:param name="prmColIdBase" />
    <xsl:param name="prmIsHeader" select="'0'" />


    <xsl:if test="$prmCheckBoxes='1'">
      <col style="width:22px" class="ListView-Column"/>
      <col style="width:[Skin.HeaderSeperatorWidth]px"  class="{$prmListViewColumnSeperatorClass}" />
    </xsl:if>

    <xsl:call-template name="tplListViewVisualTemplateSplitColumnsByNewColumnsOrder">
      <xsl:with-param name="prmNewOrderColumnsList" select="@Attr.VisualTemplateListViewNewColumnOrder"/>
      <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
      <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
    </xsl:call-template>

    <xsl:if test="$prmIsHeader='1'">
      <col style="width:17px"/>
      <col style="width:30px"/>
    </xsl:if>
    <col />
  </xsl:template>

  <xsl:template name="tplListViewDetailedColumnsVisualTemplate_ContactList">
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

  <xsl:template name="tplListViewDetailedHeaderVisualTemplate_ContactList">
  </xsl:template>

  <xsl:template name="tplListViewDetailedItemRowColumnsNumberVisualTemplate_ContactList">
    <xsl:param name="prmCheckBoxes" />

    <xsl:value-of select="1+number($prmCheckBoxes='1')*2"/>
  </xsl:template>

  <xsl:template name="tplListViewVisualTemplateDetailedHeaderAPI">
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

    <xsl:call-template name="tplListViewVisualTemplateSplitHeaderByNewColumnsOrder">
      <xsl:with-param name="prmNewOrderColumnsList" select="@Attr.VisualTemplateListViewNewColumnOrder"/>
      <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
      <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
      <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>

      <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
      <xsl:with-param name="prmCols" select="$prmCols"/>
      <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>

    </xsl:call-template>

    <td class="{$prmListViewHeaderCellClass}">&#160;</td>
    <td class="{$prmListViewHeaderCellClass}" style="border-left:none">&#160;</td>
    <td class="{$prmListViewHeaderCellClass}" style="border-left:none;">&#160;</td>
  </xsl:template>

  <xsl:template match="Tags.Column" mode="modListViewVisualTemplateDetailedHeaderSingle">
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />

    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />

    <td id="VWG_{@Id}" onclick="mobjApp.ListView_HeaderClick(this,{@Id})" class="{$prmListViewFontDataClass} Common-HandCursor {$prmListViewHeaderCellClass} nobr" style="text-align:{@Attr.ContentAlign};" data-vwgdragable="1" >
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyOnDrawVisualEffects" />
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
              <img class="Common-VAlignMiddle" alt="" >
                <xsl:attribute name="src">
                  <xsl:call-template name="tplListViewSourceHeaderSortAscending" />
                </xsl:attribute>
              </img>
            </xsl:if>
            <xsl:if test="@Attr.Sort='0'">
              <img class="Common-VAlignMiddle" alt="">
                <xsl:attribute name="src">
                  <xsl:call-template name="tplListViewSourceHeaderSortDescending" />
                </xsl:attribute>
              </img>
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
  </xsl:template>



  <xsl:template name="tplListViewDetailedGroupRowVisualTemplate_ContactList">
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
      </tr>
    </table>
  </xsl:template>

  <xsl:template name="tplListViewDetailedCustomGroupHeader">
    <xsl:param name="prmListViewGroupHeaderClass" />
    <xsl:param name="prmListViewFontGroupHeaderSeperatorClass" />
    <xsl:param name="prmGroupText" />

    <table class="Common-CellPadding0 Common-CellSpacing0 ListView-FontGroupHeader" style="width:100%;">
      <tr>
        <td style="padding-left:5px; padding-right:5px;">
          <xsl:attribute name="class">ListViewVisualTemplateGroup</xsl:attribute>
          <span class="nobr">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="$prmGroupText" />
            </xsl:call-template>
          </span>
        </td>
        <td style="width:100%;">
          <div class="{$prmListViewFontGroupHeaderSeperatorClass}">&#160;</div>
        </td>
      </tr>
    </table>
  </xsl:template>




  <xsl:template name="tplListViewVisualTemplateDetailedItemRowAPI">
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
        <xsl:attribute name="class">
          Common-AlignCenter <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" />
        </xsl:attribute>
        <xsl:if test="not($prmIsEnabled='0')">
          <xsl:attribute name="onclick">
            mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)
          </xsl:attribute>
        </xsl:if>
        <img id="LVI_CB_{@Id}"  class="{$prmListViewCheckBoxImageClass}" alt="">
          <xsl:choose>
            <xsl:when test="@Attr.Checked='1'">
              <xsl:attribute name="src">
                <xsl:call-template name="tplListViewSourceCheckBox1"></xsl:call-template>
              </xsl:attribute>
            </xsl:when>
            <xsl:otherwise>
              <xsl:attribute name="src">
                <xsl:call-template name="tplListViewSourceCheckBox0"></xsl:call-template>
              </xsl:attribute>
            </xsl:otherwise>
          </xsl:choose>
        </img>
      </td>
      <td>
        <xsl:attribute name="class">
          <xsl:value-of select="concat($prmListViewCellClass,' ','ListView-SeperatorCell')" />
        </xsl:attribute>
        <xsl:text>&#160;</xsl:text>
      </td>
    </xsl:if>

    <xsl:call-template name="tplListViewVisualTemplateSplitRowsByNewColumnsOrder">
      <xsl:with-param name="prmNewOrderColumnsList" select="../@Attr.VisualTemplateListViewNewColumnOrder" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="$prmListViewCheckBoxImageClass" />
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

    <td>
      <xsl:attribute name="class">
        <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" />
      </xsl:attribute>&#160;
    </td>
  </xsl:template>





  <xsl:template name="tplListViewVisualTemplateDrawSingleCell">
    <xsl:param name="prmColumnNumber" />
    <xsl:param name="prmListViewCellClass" />
    <xsl:param name="prmListViewItemCellClass" />
    <xsl:param name="prmListViewDataCellClass" />

    <xsl:param name="prmCheckBoxes"/>
    <xsl:param name="prmCols"/>
    <xsl:param name="prmIsFullRowSelect" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmRow" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmIsFirstColumn" />
    <migration-write type="elements">
      <xsl:param name="prmColsByName" />
    </migration-write>

    <xsl:variable name="varColumnName" select="concat('c',$prmColumnNumber)"  />
    <!--migration-select="$.xpath(&quot;string&quot;, this)" />-->
    <xsl:variable name="varValue" select="$prmRow/@*[name()=$varColumnName]/." migration-select="$.xpath(&quot;string&quot;, prmRow.xpath(&quot;@&quot; + varColumnName))" />
    <xsl:variable name="varCol" select="$prmCols[@Attr.Name=$varColumnName]" migration-select="prmColsByName[varColumnName]" />
    <xsl:variable name="varType" select="$varCol/@Attr.Type"/>
    <xsl:variable name="varIsNotFullRowSelect" select="not($prmIsFullRowSelect) and $prmIsFirstColumn = 1" migration-select="!prmIsFullRowSelect &amp;&amp; prmIsFirstColumn==1" />


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
          <xsl:attribute name="class">
            Common-AlignCenter <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" />
            <xsl:if test="$varIsNotFullRowSelect">
              <xsl:value-of select="concat(' ',$prmListViewItemCellClass)" />
            </xsl:if>
          </xsl:attribute>
          <xsl:call-template name="tplApplyListViewItemClickEvents">
            <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
            <xsl:with-param name="prmCheckOnDoubleClick" select="../@Attr.CheckOnDoubleClick"/>
            <xsl:with-param name="prmListViewId" select="../@Id"/>
            <xsl:with-param name="prmListViewItemId" select="$prmRow/@Id"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:call-template name="tplApplyDetailedCellStyleByAttributeName" >
            <xsl:with-param name="prmRow" select="$prmRow" />
            <xsl:with-param name="prmXmlAttributeName" select="$varColumnName" />
          </xsl:call-template>
          <migration-ignore reason="the '.' will be javascripted to this, so comparison will fail">
            <xsl:if test=".=''">&#160;</xsl:if>
            <xsl:if test="not(.='')">
              <img class="Common-Icon16X16" src="{.}" alt=""/>
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
            <xsl:with-param name="prmCheckOnDoubleClick" select="../@Attr.CheckOnDoubleClick"/>
            <xsl:with-param name="prmListViewId" select="../@Id"/>
            <xsl:with-param name="prmListViewItemId" select="$prmRow/@Id"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:attribute name="class">
            <xsl:value-of select="concat($prmListViewCellClass,' ',$prmListViewDataCellClass)" />
            <xsl:if test="$varIsNotFullRowSelect">
              <xsl:value-of select="concat(' ',$prmListViewItemCellClass)" />
            </xsl:if>
          </xsl:attribute>
          <xsl:if test="$varIsNotFullRowSelect">
            <xsl:attribute name="onclick">mobjApp.ListView_Click('<xsl:value-of select="../@Id" />','<xsl:value-of select="$prmRow/@Id" />',window,event)</xsl:attribute>
            <xsl:attribute name="oncontextmenu">mobjApp.ListView_RightClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="$prmRow/@Id" />',window,event)</xsl:attribute>
            <xsl:if test="$prmCheckBoxes='1' and ../@Attr.CheckOnDoubleClick='1'"><xsl:attribute name="ondblclick">mobjApp.ListView_DoubleClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="$prmRow/@Id" />',window,event)</xsl:attribute></xsl:if>
          </xsl:if>
          <xsl:call-template name="tplApplyDetailedCellStyleByAttributeName" >
            <xsl:with-param name="prmRow" select="$prmRow" />
            <xsl:with-param name="prmAlign" select="$varCol/@Attr.TextAlign" />
            <xsl:with-param name="prmXmlAttributeName" select="$varColumnName" />
          </xsl:call-template>
          <div style="direction:{$dir};" dir="{$dir}">
            <xsl:if test="$dir='RTL'">
              <xsl:attribute name="class">ListView-FloatRight</xsl:attribute>
            </xsl:if>
            <span class="nobr">
              <xsl:if test="../C[@TP='Text'][1]/@N=name()">
                <xsl:attribute name="id">
                  VWGLE_<xsl:value-of select="../@Id" />
                </xsl:attribute>
              </xsl:if>
              <xsl:if test="$prmRow/@Attr.LabelEdit='1' and $prmRow/@Attr.Selected='1'">
                <xsl:attribute name="data-vwglabeledit">1</xsl:attribute>
              </xsl:if>

              <xsl:if test="$varColumnName='c0' and $prmRow/@Attr.Image">
                <xsl:if test="$prmRow/@Attr.IdentCount">
                  <xsl:call-template name="tplApplyRowIdentCount">
                    <xsl:with-param name="prmCount" select="$prmRow/@Attr.IdentCount" />
                  </xsl:call-template>
                </xsl:if>
                <img class="Common-VAlignMiddle Common-Icon16X16" src="{$prmRow/@Attr.Image}" alt=""/>&#160;
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
      <xsl:attribute name="class">
        <xsl:value-of select="concat($prmListViewCellClass,' ','ListView-SeperatorCell')" />
      </xsl:attribute>
      <xsl:call-template name="tplApplyDetailedCellStyleByAttributeName" >
        <xsl:with-param name="prmRow" select="$prmRow" />
        <xsl:with-param name="prmXmlAttributeName" select="$varColumnName" />
      </xsl:call-template>
      <xsl:text>&#160;</xsl:text>
    </td>

  </xsl:template>



  <xsl:template name="tplListViewDetailedItemRowVisualTemplate_ContactList">
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
        <img id="LVI_CB_{@Id}"  class="{$prmListViewCheckBoxImageClass}" alt="">
          <xsl:choose>
            <xsl:when test="@Attr.Checked='1'">
              <xsl:attribute name="src"><xsl:call-template name="tplListViewSourceCheckBox1"></xsl:call-template></xsl:attribute>
            </xsl:when>
            <xsl:otherwise>
              <xsl:attribute name="src"><xsl:call-template name="tplListViewSourceCheckBox0"></xsl:call-template></xsl:attribute>
            </xsl:otherwise>
          </xsl:choose>
        </img>
      </td>      
    </xsl:if>

    <td>
      <xsl:attribute name="class">
        <xsl:value-of select="concat($prmListViewCellClass,' ','ListView-ControlCell',' ','ListViewVisualTemplateContactRowHeight')" />
        <xsl:if test="not($prmIsFullRowSelect)">
          <xsl:value-of select="concat(' ',$prmListViewItemCellClass)" />
        </xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplApplyDetailedCellStyleByAttributeName" >
        <xsl:with-param name="prmRow" select="$prmRow" />
        <xsl:with-param name="prmXmlAttributeName" select="'c0'" />
      </xsl:call-template>
      <xsl:call-template name="tplApplyListViewItemClickEvents">
        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmCheckOnDoubleClick" select="../@Attr.CheckOnDoubleClick"/>
        <xsl:with-param name="prmListViewId" select="../@Id"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        <xsl:with-param name="prmListViewItemId" select="@Id"/>
      </xsl:call-template>
      <div>       
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

        <xsl:variable name="varNameOfColumA">
          <xsl:call-template name="tplListViewVisualTemplateGetColumnNameAtNewColumnsOrder">
            <xsl:with-param name="prmPosition" select="0"/>
          </xsl:call-template>
        </xsl:variable>
        <xsl:variable name="varNameOfColumB">
          <xsl:call-template name="tplListViewVisualTemplateGetColumnNameAtNewColumnsOrder">
            <xsl:with-param name="prmPosition" select="1"/>
          </xsl:call-template>
        </xsl:variable>
        <xsl:variable name="varNameOfColumC">
          <xsl:call-template name="tplListViewVisualTemplateGetColumnNameAtNewColumnsOrder">
            <xsl:with-param name="prmPosition" select="2"/>
          </xsl:call-template>
        </xsl:variable>

        <div class="ListViewVisualTemplateContactFirstName">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" >
              <xsl:call-template name="tplGetColumnValueFromRowParam">
                <xsl:with-param name="prmColumnName" select="$varNameOfColumA"/>
              </xsl:call-template>
            </xsl:with-param>
          </xsl:call-template>
        </div>
        <div class="ListViewVisualTemplateContactLastName">
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" >
              <xsl:call-template name="tplGetColumnValueFromRowParam">
                <xsl:with-param name="prmColumnName" select="$varNameOfColumB"/>
              </xsl:call-template>
            </xsl:with-param>
          </xsl:call-template>
        </div>
      </div>
    </td>
  </xsl:template>


  <xsl:template name="tplGetColumnValueFromRowParam">
    <xsl:param name="prmColumnName" />
    <xsl:if test="$prmColumnName">
      <xsl:value-of select="@*[name()=$prmColumnName]/." migration-select="this.xpath(&quot;@&quot; + prmColumnName)"/>
    </xsl:if>
  </xsl:template>


  <!-- Will return the column name at a specific position -->
  <xsl:template name="tplListViewVisualTemplateGetColumnNameAtNewColumnsOrder">
    <xsl:param name="prmNewOrderColumnsList" select="../@Attr.VisualTemplateListViewNewColumnOrder"/>
    <xsl:param name="prmPosition"/>

    <xsl:if test="string-length($prmNewOrderColumnsList) > 0">
      <xsl:variable name="varNextItem" select="substring-before(concat($prmNewOrderColumnsList, '|'), '|')"/>

      <xsl:choose>
        <xsl:when test="$prmPosition = 0">
          <xsl:value-of select="concat('c',$varNextItem)"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:call-template name="tplListViewVisualTemplateGetColumnNameAtNewColumnsOrder">
            <xsl:with-param name="prmNewOrderColumnsList" select="substring-after($prmNewOrderColumnsList, '|')"/>
            <xsl:with-param name="prmPosition" select="$prmPosition - 1"/>
          </xsl:call-template>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>

  </xsl:template>


  <xsl:template name="tplListViewVisualTemplateSplitRowsByNewColumnsOrder">
    <xsl:param name="prmNewOrderColumnsList"/>
    <xsl:param name="prmListViewCellClass" />
    <xsl:param name="prmListViewItemCellClass" />
    <xsl:param name="prmListViewDataCellClass" />

    <xsl:param name="prmCheckBoxes"/>
    <xsl:param name="prmCols"/>
    <xsl:param name="prmIsFullRowSelect" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmRow" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmIsFirstColumn" select="1"/>
    <migration-write type="elements">
      <xsl:param name="prmColsByName" />
    </migration-write>


    <xsl:if test="string-length($prmNewOrderColumnsList) > 0">
      <xsl:variable name="varNextItem" select="substring-before(concat($prmNewOrderColumnsList, '|'), '|')"/>

      <xsl:call-template name="tplListViewVisualTemplateDrawSingleCell">
        <xsl:with-param name="prmColumnNumber" select="$varNextItem"/>
        <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass"/>
        <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass"/>
        <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>

        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmCols" select="$prmCols"/>
        <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
        <xsl:with-param name="prmHeight" select="$prmHeight"/>
        <xsl:with-param name="prmRow" select="$prmRow"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        <xsl:with-param name="prmIsFirstColumn" select="$prmIsFirstColumn"/>
        <migration-write type="elements">
          <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
        </migration-write>
      </xsl:call-template>




      <xsl:call-template name="tplListViewVisualTemplateSplitRowsByNewColumnsOrder">
        <xsl:with-param name="prmNewOrderColumnsList" select="substring-after($prmNewOrderColumnsList, '|')"/>
        <xsl:with-param name="prmListViewCellClass" select="$prmListViewCellClass"/>
        <xsl:with-param name="prmListViewItemCellClass" select="$prmListViewItemCellClass"/>
        <xsl:with-param name="prmListViewDataCellClass" select="$prmListViewDataCellClass"/>

        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmCols" select="$prmCols"/>
        <xsl:with-param name="prmIsFullRowSelect" select="$prmIsFullRowSelect"/>
        <xsl:with-param name="prmHeight" select="$prmHeight"/>
        <xsl:with-param name="prmRow" select="$prmRow"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        <xsl:with-param name="prmIsFirstColumn" select="0"/>
        <migration-write type="elements">
          <xsl:with-param name="prmColsByName" select="$prmColsByName"/>
        </migration-write>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>


  <xsl:template name="tplListViewVisualTemplateSplitHeaderByNewColumnsOrder">
    <xsl:param name="prmNewOrderColumnsList"/>
    <xsl:param name="prmListViewFontDataClass" />
    <xsl:param name="prmListViewHeaderCellClass" />
    <xsl:param name="prmListViewHeaderSeperatorClass" />

    <xsl:param name="prmCheckBoxes"/>
    <xsl:param name="prmCols"/>
    <xsl:param name="prmGridLines" />
    <xsl:param name="prmIsEnabled" />

    <xsl:if test="string-length($prmNewOrderColumnsList) > 0">
      <xsl:variable name="varNextItem" select="substring-before(concat($prmNewOrderColumnsList, '|'), '|')"/>

      <xsl:variable name="varColumnName" select="concat('c',$varNextItem)" />
      <xsl:variable name="varCol" select="$prmCols[@Attr.Name=$varColumnName]" />

      <xsl:apply-templates select="$varCol" mode="modListViewVisualTemplateDetailedHeaderSingle" >
        <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
        <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
        <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>
        <xsl:with-param name="prmCols" select="$prmCols"/>
        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmGridLines" select="$prmGridLines"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>


      <xsl:call-template name="tplListViewVisualTemplateSplitHeaderByNewColumnsOrder">
        <xsl:with-param name="prmNewOrderColumnsList" select="substring-after($prmNewOrderColumnsList, '|')"/>
        <xsl:with-param name="prmListViewFontDataClass" select="$prmListViewFontDataClass"/>
        <xsl:with-param name="prmListViewHeaderCellClass" select="$prmListViewHeaderCellClass"/>
        <xsl:with-param name="prmListViewHeaderSeperatorClass" select="$prmListViewHeaderSeperatorClass"/>

        <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes"/>
        <xsl:with-param name="prmCols" select="$prmCols"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        <xsl:with-param name="prmIsFirstColumn" select="0"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplListViewVisualTemplateSplitColumnsByNewColumnsOrder">
    <xsl:param name="prmNewOrderColumnsList" />
    <xsl:param name="prmListViewColumnSeperatorClass" />
    <xsl:param name="prmListViewSortedColumnClass" />

    <xsl:param name="prmCols"/>
    <xsl:param name="prmColIdBase" />


    <xsl:if test="string-length($prmNewOrderColumnsList) > 0">
      <xsl:variable name="varNextItem" select="substring-before(concat($prmNewOrderColumnsList, '|'), '|')"/>

      <xsl:variable name="varColumnName" select="concat('c',$varNextItem)" />
      <xsl:variable name="varCol" select="$prmCols[@Attr.Name=$varColumnName]" />

      <col id="{$prmColIdBase}_{$varCol/@Id}" style="width:{$varCol/@Attr.Width}px">
        <xsl:attribute name="class">
          ListView-Column <xsl:if test="$varCol/@Attr.Sort='1' or $varCol/@Attr.Sort='0'">
            <xsl:value-of select="concat(' ',$prmListViewSortedColumnClass)"/>
          </xsl:if>
        </xsl:attribute>
      </col>
      <col style="width:[Skin.HeaderSeperatorWidth]px"  class="{$prmListViewColumnSeperatorClass}"/>


      <xsl:call-template name="tplListViewVisualTemplateSplitColumnsByNewColumnsOrder">
        <xsl:with-param name="prmNewOrderColumnsList" select="substring-after($prmNewOrderColumnsList, '|')"/>
        <xsl:with-param name="prmListViewColumnSeperatorClass" select="$prmListViewColumnSeperatorClass"/>
        <xsl:with-param name="prmListViewSortedColumnClass" select="$prmListViewSortedColumnClass"/>
        <xsl:with-param name="prmCols" select="$prmCols"/>
        <xsl:with-param name="prmColIdBase" select="$prmColIdBase"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>