<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols"
	xmlns:WG="http://www.gizmox.com/webgui">
  
  <xsl:template match="WC:Tags.PropertyGrid" mode="modContent">    
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">PropertyGrid-BaseControl</xsl:attribute>
    
    <xsl:call-template name="tplDrawContained" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.PropertyGridView[not(@Attr.Style)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">
      <xsl:text>PropertyGrid-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> PropertyGrid-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>
    <xsl:variable name ="varLableWidth">
      <xsl:if test="(@Attr.LablesColumnWidth)">
        <xsl:value-of select="@Attr.LablesColumnWidth" />
      </xsl:if>
      <xsl:if test="not(@Attr.LablesColumnWidth)">100</xsl:if>
    </xsl:variable>
    <div style="position:absolute;width:100%;height:100%;overflow:hidden;" tabindex="-1" data-vwgfocuselement="1" onkeydown="mobjApp.PropertyGrid_KeyDown('{@Attr.Id}',window,event);" >
      <xsl:call-template name="tplCompleteScrollCapabilities"/>
      <div class="PropertyGrid-Container">
        <xsl:call-template name="tplApplyScrollableAttributes" />
        <xsl:call-template name="tplRestoreScroll" />
        <table dir="{$dir}" style="table-layout:fixed;width:100%" class="Common-CellPadding0 Common-CellSpacing0 PropertyGrid-Table" >
          <colgroup>
          <col class="PropertyGrid-Outline" style="width:15px" />
          <col data-id="vwgLabelsCol">
            <xsl:attribute name="style">
              width:<xsl:value-of select="$varLableWidth" />px
            </xsl:attribute>
          </col>
          <col style="width:2px"/>
          <col style="width:30px"/>
          <col/>
          <col style="width:15px"/>
          </colgroup>
          <!-- Fix IE bug with col span - add empty row -->
          <xsl:if test="$varBrowserIE">
            <tr>
              <td style="width:15px;height:0px;"/>
              <td style="width:{$varLableWidth}px;height:0px;"/>
              <td style="width:2px;height:0px;"/>
              <td style="width:30px;height:0px;"/>
              <td style="height:0px;"/>
              <td style="width:15px;height:0px;"/>
            </tr>
          </xsl:if>
          <xsl:apply-templates select="WG:Tags.PropertyGridEntry" mode="modContent">
            <xsl:with-param name="prmGridView" select="." />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </table>
      </div>
    </div>
  </xsl:template>

  <xsl:template match="WG:Tags.PropertyGridEntry">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <xsl:apply-templates select=".">
      <xsl:with-param name="prmGridView" select="$prmGridView" />
    </xsl:apply-templates>
  </xsl:template>

  <xsl:template name="tplDrawCategoryGridEntry">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <xsl:param name="prmFlagMatchedElement" select="0"/>
    <xsl:param name="prmIsEnabled" />

 <tr id="VWG_{$prmGridView/@Id}_{@Attr.MemberID}" class="PropertyGrid-CategoryRow">
      <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute></xsl:if>
      <td class="Common-AlignCenter Common-HandCursor">
        <xsl:if test="not($prmIsEnabled='0')">
          <xsl:attribute name="onclick">mobjApp.PropertyGrid_Toggle('<xsl:value-of select="$prmGridView/@Id" />','<xsl:value-of select="@Attr.MemberID" />',this.firstChild,window,event);</xsl:attribute>
        </xsl:if>
        <img class="PropertyGrid-CategoryPlusButtonSize" src="[Skin.Path]PGLightPlus{number(@Attr.Expanded='1')}.gif.wgx" alt="" />
      </td>
      <td class="Common-DefaultCursor Common-FontData PropertyGrid-Category" colspan="4">
        <xsl:value-of select="@Attr.Text" />
      </td>
      <td class="Common-DefaultCursor Common-FontData PropertyGrid-Category"></td>
    </tr>
  </xsl:template>

  <xsl:template name="tplDrawValueGridEntry">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <xsl:param name="prmHasLabelPlus" select="@Attr.HasNodes='1' and @Attr.Depth>0" />
    <xsl:param name="prmFlagMatchedElement" select="0"/>
    <xsl:param name="prmIsEnabled"/>

    <!-- Get property grid entry visibility -->
    <xsl:variable name ="varIsEntryVisible">
      <xsl:call-template name ="tplGetPropertyGridEntryVisibility">
        <xsl:with-param name ="prmCheckedEntry" select ="."/>
      </xsl:call-template>
    </xsl:variable>    

    <tr id="VWG_{$prmGridView/@Id}_{@Attr.MemberID}" data-HorizentalOppositeAlignment="1">
      <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="data-vwg_matchedelement">1</xsl:attribute></xsl:if>
      <xsl:if test ="$varIsEntryVisible = '0'">
        <xsl:attribute name="style">display:none;</xsl:attribute>
      </xsl:if>
      <td>
        <xsl:if test="@Attr.HasNodes='1' and @Attr.Depth='0' and not($prmIsEnabled='0')">
          <xsl:attribute name="onclick">mobjApp.PropertyGrid_Toggle('<xsl:value-of select="$prmGridView/@Id" />','<xsl:value-of select="@Attr.MemberID" />',this.firstChild,window,event);</xsl:attribute>
          <xsl:attribute name="class">Common-AlignCenter Common-HandCursor</xsl:attribute>
          <img class="PropertyGrid-PlusButtonSize"  src="[Skin.Path]PGLightPlus{number(@Attr.Expanded='1')}.gif.wgx" alt="" />
        </xsl:if>
      </td>
      <td style="padding-{$left}:{(number(@Attr.Depth)-number($prmHasLabelPlus))*13+3}px;vertical-algin:top;">
        <xsl:attribute name="class">nobr Common-DefaultCursor Common-FontData Common-Unselectable PropertyGrid-Label <xsl:choose><xsl:when test="@Attr.ReadOnly='0' and not(@Attr.Type)">PropertyGrid-LabelDisabled</xsl:when><xsl:otherwise><xsl:choose><xsl:when test="@Attr.Active='1'">PropertyGrid-ActiveLabel</xsl:when><xsl:otherwise>PropertyGrid-Label</xsl:otherwise></xsl:choose></xsl:otherwise></xsl:choose></xsl:attribute>
        <xsl:if test="not($prmIsEnabled='0')">
          <xsl:attribute name="onmousedown">mobjApp.PropertyGrid_EntryMouseDown('<xsl:value-of select="$prmGridView/@Id" />_<xsl:value-of select="@Attr.MemberID" />','<xsl:value-of select="$prmGridView/@Id"/>',window,event,false);</xsl:attribute>
        </xsl:if>
        <xsl:if test="$prmHasLabelPlus">
          <img class="PropertyGrid-LabelPlus PropertyGrid-PlusButtonSize" src="[Skin.Path]PGLightPlus{number(@Attr.Expanded='1')}.gif.wgx" alt="">
            <xsl:if test="not($prmIsEnabled='0')">
              <xsl:attribute name="onclick">mobjApp.PropertyGrid_Toggle('<xsl:value-of select="$prmGridView/@Id" />','<xsl:value-of select="@Attr.MemberID" />',this,window,event);</xsl:attribute>
            </xsl:if>
          </img>
        </xsl:if>
        <div style="position:relative;width:100%;height:100%;overflow:hidden;">
          <input id="TRG_readonly_prop_{@Attr.MemberID}" data-id="vwgLabel" type="text" class="Common-DefaultCursor Common-FontData Common-Unselectable PropertyGrid-LabelInput PropertyGrid-Label" readonly="readOnly">
            <xsl:attribute name="value"><xsl:value-of select="@Attr.Text" /></xsl:attribute>
          </input>
          <xsl:call-template name="tplAddAccessibleNameLabel">
            <xsl:with-param name="prmId">TRG_readonly_prop_<xsl:value-of select="@Attr.MemberID"/></xsl:with-param>
            <xsl:with-param name="prmText"><xsl:value-of select="@Attr.Text"/></xsl:with-param>
          </xsl:call-template>

          <div class="PropertyGrid-LabelInputBlock"  style="position:absolute;left:0px;top:0px;width:100%;height:100%;overflow:hidden;">&#160;</div>
        </div>
      </td>
      <td class="PropertyGrid-Splitter">
        <xsl:if test="not($prmIsEnabled='0')">
          <xsl:attribute name="onmousedown">mobjApp.PropertyGrid_SplitterResize('<xsl:value-of select="$prmGridView/@Id"/>',this,window,event);</xsl:attribute>
        </xsl:if>
        &#160;
      </td>
      <xsl:call-template name="tplPropertyGridPallete" />
      <td style="padding-{$left}:3px;">
        <xsl:if test="@Attr.Active='1'">
          <xsl:attribute name="colspan"><xsl:value-of select="1+number(not(@Attr.Color or @Attr.Image))+number(not(@Attr.Type))"/></xsl:attribute>
        </xsl:if>
        <xsl:if test="not(@Attr.Active='1')">
          <xsl:attribute name="colspan"><xsl:value-of select="2+number(not(@Attr.Color or @Attr.Image))"/></xsl:attribute>
          <xsl:if test="not($prmIsEnabled='0')">
            <xsl:attribute name="onmousedown">mobjApp.PropertyGrid_EntryMouseDown('<xsl:value-of select="$prmGridView/@Id"/>_<xsl:value-of select="@Attr.MemberID"/>','<xsl:value-of select="$prmGridView/@Id"/>',window,event,true);</xsl:attribute>
          </xsl:if>
        </xsl:if>
        <xsl:attribute name="class">nobr <xsl:if test="@Attr.Active='1'">PropertyGrid-ActiveValue</xsl:if><xsl:if test="not(@Attr.Active='1')">PropertyGrid-Value</xsl:if></xsl:attribute>
        <input id="TRG_editable_prop_{@Attr.MemberID}" data-id="vwgText" type="text" data-vwgeditable="1" tabindex="-1">
          <xsl:attribute name="class">Common-FontData <xsl:choose><xsl:when test="@Attr.ReadOnly='0' and not(@Attr.Type)">PropertyGrid-ValueDisabled</xsl:when><xsl:otherwise><xsl:choose><xsl:when test="@Attr.Active='1'">PropertyGrid-ActiveValue</xsl:when><xsl:otherwise>PropertyGrid-Value</xsl:otherwise></xsl:choose></xsl:otherwise></xsl:choose>
          </xsl:attribute>
          <xsl:attribute name="value">
            <xsl:call-template name="tplDecodeText">
              <xsl:with-param name="prmText" select="@Attr.Value"/>
            </xsl:call-template>
          </xsl:attribute>
          <xsl:if test="@Attr.Active='1'">
            <xsl:attribute name="onkeydown">mobjApp.PropertyGrid_InputKeyDown('<xsl:value-of select="$prmGridView/@Id"/>_<xsl:value-of select="@Attr.MemberID"/>','<xsl:value-of select="$prmGridView/@Id"/>',this,window,event);</xsl:attribute>
            <xsl:if test="not(@Attr.ReadOnly='0') and not(@Attr.Type)">
              <xsl:call-template name="tplResgisterLostFocusEvent"><xsl:with-param name="prmHandler">mobjApp.PropertyGrid_OnEntryBlur('<xsl:value-of select="$prmGridView/@Id"/>','<xsl:value-of select="@Attr.MemberID"/>',this,window);</xsl:with-param></xsl:call-template>
            </xsl:if>
          </xsl:if>
          <xsl:if test="@Attr.ReadOnly='0'"><xsl:attribute name="readonly">readonly</xsl:attribute></xsl:if>
        </input>
        <xsl:call-template name="tplAddAccessibleNameLabel">
          <xsl:with-param name="prmId">TRG_editable_prop_<xsl:value-of select="@Attr.MemberID"/></xsl:with-param>
          <xsl:with-param name="prmText"><xsl:value-of select="@Attr.Text"/></xsl:with-param>
        </xsl:call-template>
      </td>
      <xsl:if test="@Attr.Active='1' and @Attr.Type">
        <td onclick="mobjApp.PropertyGrid_NavigateEditor(window,event,'{$prmGridView/@Id}_{@Attr.MemberID}');" class="PropertyGrid-ValueExtension Common-AlignCenter">
          <img style="display:block;height:13px;width:15px;"  src="[Skin.Path]PGButton{@Attr.Type}.gif.wgx" alt="" />
        </td>
      </xsl:if>
    </tr>
  </xsl:template>
  

  <!--Property grid category entries -->
  <xsl:template match="WG:Tags.PropertyGridEntry[@Attr.Type='C']" mode="modContent">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawCategoryGridEntry">
      <xsl:with-param name="prmGridView" select="$prmGridView"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Property grid entries: not category type entries -->
  <xsl:template match="WG:Tags.PropertyGridEntry[not(@Attr.Type='C')]" mode="modContent">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <xsl:param name="prmHasLabelPlus" select="@Attr.HasNodes='1' and @Attr.Depth>0" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawValueGridEntry">
      <xsl:with-param name="prmGridView" select="$prmGridView" />
      <xsl:with-param name="prmHasLabelPlus" select="$prmHasLabelPlus" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplPropertyGridPallete">
    <xsl:if test="@Attr.Image">
      <td class="PropertyGrid-IconCell">&#160;</td>
    </xsl:if>
    <xsl:if test="@Attr.Color">
      <td class="PropertyGrid-ValueExtension" style="padding-{$right}:4px;">
        <div class="PropertyGrid-IconCell" style="background:{@Attr.Color};">&#160;</div>
      </td>
    </xsl:if>
  </xsl:template>
  
  <!-- 
  Entry Visibility recursive calculation. Returns the visibility of checked node 
  or calls itself to get visibility in according to owner entry node
  Returns '1' - the entry is visible, otherwise returns '0'
  -->
  <xsl:template name="tplGetPropertyGridEntryVisibility">
    <xsl:param name="prmCheckedEntry"/>

    <!-- get state of the checked entry - collapsed / expanded -->
    <xsl:variable name="varIsCheckedEntryCollapsed" select="$prmCheckedEntry/@Attr.Expanded='0' or not($prmCheckedEntry/@Attr.Expanded)"/>
    <!-- check that the node checked is not node the check was started for, because in that case, visibility depends on it's parent node -->
    <xsl:variable name="varIsSelfNode" select="$prmCheckedEntry/@Attr.MemberID = @Attr.MemberID"/>
    <xsl:variable name="varParentEntry" select="../WG:Tags.PropertyGridEntry[@Attr.MemberID = $prmCheckedEntry/@Attr.OwnerEntryID]" migration-select="{this}.xpath(&quot;../WG:Tags.PropertyGridEntry[@Attr.MemberID = '&quot; + prmCheckedEntry.attr(&quot;Attr.OwnerEntryID&quot;) + &quot;']&quot;)" />
    <xsl:choose>
      <!--
      We able to resolve visbility immediately if:
      1. The category node is top level and always had visibility attribute set
      2. The node itself (context node) is Expandable node - 'has nodes', not self checked and collapsed - means checked entry is invisible
      3. The node is owner node of the checked context node - and context node's visibility depends on this node
      Else:
      1. We in non-categorized mode, some nodes will be without parent and with sub-entries(HN=1) - should be visible
      -->
      <xsl:when test ="$prmCheckedEntry/@Attr.Type='C' and $varIsCheckedEntryCollapsed">
        <xsl:text>0</xsl:text>
      </xsl:when>

      <xsl:when test ="$prmCheckedEntry/@Attr.Type='C' and not($varIsCheckedEntryCollapsed)">
        <xsl:text>1</xsl:text>
      </xsl:when>
      
      <xsl:when test ="($prmCheckedEntry/@Attr.HasNodes ='1' and not($varIsSelfNode) and $varIsCheckedEntryCollapsed)">
        <xsl:text>0</xsl:text>
      </xsl:when>

      <!-- the entry has no parent entry, means the checked entry is visible -->
      <xsl:when test="not($varParentEntry)">
        <xsl:text>1</xsl:text>
      </xsl:when>

      <xsl:otherwise>         
        <!--Call itself with parent entry to check -->
        <xsl:call-template name="tplGetPropertyGridEntryVisibility">
          <xsl:with-param name="prmCheckedEntry" select="$varParentEntry"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>
