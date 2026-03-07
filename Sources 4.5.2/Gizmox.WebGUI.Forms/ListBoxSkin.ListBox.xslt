<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  
  <!-- The default style ListBox match template -->
  <xsl:template match="WC:Tags.ListBox|WC:Tags.ColorListBox" mode="modContent">
    <xsl:param name="prmIsEnabled" />
   <xsl:call-template name="tplDrawListBoxAPI">
     <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
   </xsl:call-template>
  </xsl:template>
  
  <!--Main API for drawing control-->
  <xsl:template name="tplDrawListBoxAPI">
    <xsl:param name="prmControlClass" select="'ListBox-Control'"/>
    <xsl:param name="prmFontClass" select="'ListBox-FontData'"/>
    <xsl:param name="prmCheckBoxColumnWidth" select="[Skin.CheckBoxCellWidth]"/>
    <xsl:param name="prmRowClass" select="'ListBox-Row'"/>
    <xsl:param name="prmRowSelectedClass" select="'ListBox-Row_Selected'"/>
    <xsl:param name="prmImageBoxClass" select="'ListBox-ImageBox'"/>
    <xsl:param name="prmColorBoxClass" select="'ListBox-ColorBox'"/>
    <xsl:param name="prmContainerClass" select="'ListBox-Container'"/>
    <xsl:param name="prmCheckedRadioButtonImage" select="'[Skin.CheckedRadioButtonImage]'"/>
    <xsl:param name="prmUncheckedRadioButtonImage" select="'[Skin.UncheckedRadioButtonImage]'"/>
    <xsl:param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
    <xsl:param name="prmUncheckedCheckBoxImage" select="'[Skin.UncheckedCheckBoxImage]'"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">
      <xsl:value-of select="concat('Common-Unselectable ',$prmControlClass)"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:call-template name="tplCompleteScrollCapabilities"/>
    <div dir="{$dir}" tabindex="-1" data-vwgfocuselement="1">
      <xsl:call-template name="tplApplyScrollableAttributes"/>
      <xsl:attribute name="class"><xsl:value-of select="concat('Common-Unselectable Common-HandCursor ',$prmContainerClass)"/> Common-Strech</xsl:attribute>
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:attribute name="onclick">mobjApp.ListBox_SetFocus(this,'{@Id}')</xsl:attribute>
        <xsl:attribute name="onkeydown">mobjApp.ListBox_KeyDown('<xsl:value-of select="@Id" />',window,event)</xsl:attribute>
        <xsl:call-template name="tplSetMouseFocusEvents">
          <xsl:with-param name="prmHandler" select="'Web_SetStyle'"/>
        </xsl:call-template>
      </xsl:if>
      <table  class="Common-Strech Common-CellPadding0 Common-CellSpacing0 {$prmFontClass} ListBox-Table" id="VWGE_{@Id}_LBTable" >
        <xsl:attribute name="style">
          <xsl:call-template name="tplApplyFontStyles" />;
        </xsl:attribute>
        <xsl:variable name="varColspan">
          <xsl:choose>
            <xsl:when test="Tags.Option">
              <xsl:choose>
                <xsl:when test="@Attr.ShowImage = '1' and @Attr.ShowColor ='1'">4</xsl:when>
                <xsl:when test="@Attr.ShowImage = '1' or @Attr.ShowColor ='1'">3</xsl:when>
                <xsl:otherwise>2</xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            <xsl:otherwise>1</xsl:otherwise>            
          </xsl:choose>
        </xsl:variable>
        <colgroup>
        <xsl:if test="@Attr.RadioButtons='1' or @Attr.CheckBoxes='1'">
          <col style="width:{$prmCheckBoxColumnWidth}px"></col>
        </xsl:if>
        <xsl:if test="not(@Attr.RadioButtons='1' or @Attr.CheckBoxes='1')">
          <col style="width:1px"/>
        </xsl:if>
        <xsl:if test="Tags.Option">
          <xsl:if test="@Attr.ShowImage = '1'">
            <col class="ListBox-ImageBoxWidth"/>
          </xsl:if>
          <xsl:if test="@Attr.ShowColor = '1'">
            <col class="ListBox-ColorBoxWidth"/>
          </xsl:if>
          <col/>
        </xsl:if>
        </colgroup>
        
        <xsl:choose>
          <xsl:when test="Tags.Option">
            <xsl:for-each select="Tags.Option">
              <tr id="VWGE_{../@Id}_{@Idx}" style="height:{../@Attr.ItemHeight}px;"  onclick="mobjApp.ListBox_Click('{../@Id}','{@Idx}',window,event)">
                <xsl:attribute name="class">
                  <xsl:value-of select="concat($prmRowClass,' ')"/>
                  <xsl:if test="@Attr.Selected='1' and not ($prmIsEnabled='0')"><xsl:value-of select="$prmRowSelectedClass"/></xsl:if>
                </xsl:attribute>
                <td style="border-{$right}:none;">
                  <xsl:choose>
                    <xsl:when test="../@Attr.RadioButtons='1'">
                      <xsl:choose>
                        <xsl:when test="@Attr.Selected='1' and not($prmIsEnabled='0')">
                          <img class="ListBox-Row_IMG Common-VAlignMiddle" data-id="VWGE_SelectIcon" src="{$prmCheckedRadioButtonImage}" alt="Checked"></img>
                        </xsl:when>
                        <xsl:otherwise>
                          <img class="ListBox-Row_IMG Common-VAlignMiddle" data-id="VWGE_SelectIcon" src="{$prmUncheckedRadioButtonImage}" alt="Unchecked"></img>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:when>
                    <xsl:when test="../@Attr.CheckBoxes='1'">
                      <xsl:choose>
                        <xsl:when test="@Attr.Selected='1' and not($prmIsEnabled='0')">
                          <img class="ListBox-Row_IMG Common-VAlignMiddle" data-id="VWGE_SelectIcon" src="{$prmCheckedCheckBoxImage}" alt="Checked"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <img class="ListBox-Row_IMG Common-VAlignMiddle" data-id="VWGE_SelectIcon" src="{$prmUncheckedCheckBoxImage}" alt="Unchecked"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:when>
                    <xsl:otherwise>
                      &#160;
                    </xsl:otherwise>
                  </xsl:choose>
                </td>
                <xsl:if test="../@Attr.ShowImage = '1'">
                  <td >
                    <img style="overflow:hidden;" src="{@Attr.Image}" alt="">
                      <xsl:attribute name="class"><xsl:value-of select="$prmImageBoxClass"/></xsl:attribute>
                    </img>
                  </td>
                </xsl:if>
                <xsl:if test="../@Attr.ShowColor = '1'">
                  <td>
                    <div style="background:{@Attr.Color};overflow:hidden;">
                      <xsl:attribute name="class"><xsl:value-of select="$prmColorBoxClass"/></xsl:attribute>&#160;
                    </div>
                  </td>
                </xsl:if>
                <td class="Common-VAlignMiddle Common-HandCursor" style="border-{$left}:none;"  onfocus="Web_SetStyle(mobjApp.Web_GetElementById('VWGE_{../@Id}_LBTable',window),'focus',window);" onblur="Web_SetStyle(mobjApp.Web_GetElementById('VWGE_{../@Id}_LBTable',window),'',window);">
                  <span class="nobr">
                    <xsl:call-template name="tplDecodeTextAsHtml"/>
                  </span>
                </td>
              </tr>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <tr class="Common-HandCursor">
              <td colspan="{$varColspan}"><xsl:call-template name="tplDrawEmptyImage"/></td>
            </tr>
          </xsl:otherwise>
        </xsl:choose>
        <tr>
          <td colspan="{$varColspan}"></td>
        </tr>
      </table> 
    </div>
  </xsl:template>

  <!-- The default style CheckedListBox match template -->
  <xsl:template match="WC:Tags.CheckedListBox" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCheckedListBoxAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawCheckedListBoxAPI">
    <xsl:param name="prmControlClass" select="'ListBox-Control'"/>
    <xsl:param name="prmFontClass" select="'ListBox-FontData'"/>
    <xsl:param name="prmRowClass" select="'ListBox-Row'"/>
    <xsl:param name="prmRowSelectedClass" select="'ListBox-Row_Selected'"/>
    <xsl:param name="prmContainerClass" select="'ListBox-Container'"/>
    <xsl:param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
    <xsl:param name="prmUncheckedCheckBoxImage" select="'[Skin.UncheckedCheckBoxImage]'"/>
    <xsl:param name="prmIndeterminateCheckBoxImage" select="'[Skin.IndeterminateCheckBoxImage]'"/>
    <xsl:param name="prmCheckBoxColumnWidth" select="[Skin.CheckBoxCellWidth]"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">
      <xsl:value-of select="concat('Common-Unselectable ',$prmControlClass)"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:call-template name="tplCompleteScrollCapabilities"/>
    <div dir="{$dir}" tabindex="-1" data-vwgfocuselement="1">
      <xsl:call-template name="tplApplyScrollableAttributes"/>
      <xsl:attribute name="class"><xsl:value-of select="concat('Common-Unselectable Common-HandCursor ',$prmContainerClass)"/></xsl:attribute>
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:attribute name="onclick">mobjApp.ListBox_SetFocus(this,'{@Id}')</xsl:attribute>
        <xsl:attribute name="onkeydown">mobjApp.ListBox_KeyDown('<xsl:value-of select="@Id" />',window,event)</xsl:attribute>
        <xsl:call-template name="tplSetMouseFocusEvents">
          <xsl:with-param name="prmHandler" select="'Web_SetStyle'"/>
        </xsl:call-template>
      </xsl:if>
      <table class="Common-CellPadding0 Common-CellSpacing0 {$prmFontClass} ListBox-Table" id="VWGE_{@Id}_LBTable" >
        <xsl:attribute name="style">
          <xsl:call-template name="tplApplyFontStyles" />;          
        </xsl:attribute>
        <colgroup>
        <col style="width:{$prmCheckBoxColumnWidth}px" />
        <col/>
        </colgroup>
        <xsl:choose>
          <xsl:when test="Tags.Option">
            <xsl:for-each select="Tags.Option">
              <tr id="VWGE_{../@Id}_{@Idx}" style="height:{../@Attr.ItemHeight}px;">
                <xsl:attribute name="class">
                  <xsl:value-of select="concat($prmRowClass,' ')"/> 
                  <xsl:if test="@Attr.Selected='1' and not ($prmIsEnabled='0')"><xsl:value-of select="$prmRowSelectedClass"/></xsl:if>
                </xsl:attribute>
                <td  style="border-{$right}:none;"  ondblclick="mobjApp.ListBox_OnClickChecked('{../@Id}','{@Idx}',false,window,event)" onclick="mobjApp.ListBox_OnClickChecked('{../@Id}','{@Idx}',true,window,event)">
                  <img class="Common-VAlignMiddle ListBox-Row_IMG"  id="CB_IMG_{../@Id}_{@Idx}" alt="">
                    <xsl:attribute name="src">
                      <xsl:choose>
                        <xsl:when test="@Attr.Checked='1'"><xsl:value-of select="$prmCheckedCheckBoxImage"/></xsl:when>
                        <xsl:when test="@Attr.Checked='2'"><xsl:value-of select="$prmIndeterminateCheckBoxImage" /></xsl:when>
                        <xsl:otherwise><xsl:value-of select="$prmUncheckedCheckBoxImage"/></xsl:otherwise>
                      </xsl:choose>
                    </xsl:attribute>
                  </img>
                </td>
                <td style="border-{$left}:none;"  ondblclick="mobjApp.ListBox_OnClickChecked('{../@Id}','{@Idx}',false,window,event)" onclick="mobjApp.ListBox_OnClickChecked('{../@Id}','{@Idx}',false,window,event)">
                  <span class="nobr">
                    <xsl:call-template name="tplDecodeTextAsHtml"/>
                  </span>
                </td>
              </tr>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <tr class="Common-HandCursor">
              <td><xsl:call-template name="tplDrawEmptyImage"/></td>
              <td></td>
            </tr>
          </xsl:otherwise>
        </xsl:choose>
        <tr>
          <td colspan="2"></td>
        </tr>
      </table>
      <xsl:call-template name="tplRestoreScroll">
        <xsl:with-param name="prmGuid" select="@Attr.Id" />
      </xsl:call-template>
    </div>
  </xsl:template>
</xsl:stylesheet>

