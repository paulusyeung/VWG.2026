<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  <xsl:template match="WC:Tags.MenuItem" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varHasNodes" select="@Attr.HasNodes"/>
    <xsl:variable name="varMenuItemLabelWidth"><xsl:value-of select="../@Attr.MenuItemLabelWidth"/></xsl:variable>
    <xsl:variable name="varMenuItemShortCutWidth"><xsl:value-of select="../@Attr.MenuItemShortCutWidth"/></xsl:variable>
    <xsl:variable name="varFixedMenuItemLabelWidth">
      <xsl:choose>
        <xsl:when test="$varHasNodes='1' and $varMenuItemShortCutWidth and not($varMenuItemShortCutWidth='')"><xsl:value-of select="number($varMenuItemLabelWidth)+number($varMenuItemShortCutWidth)"/></xsl:when>
        <xsl:otherwise><xsl:value-of select="$varMenuItemLabelWidth"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMenuItemIconsColumnWidth">[Skin.MenuItemIconsColumnWidth]</xsl:variable>

    <xsl:if test="not(@Attr.IsSeperator='1')">
      <xsl:attribute name="class">
        <xsl:text>Common-HandCursor MenuItem-Control</xsl:text>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:text> MenuItem-Control_Disabled</xsl:text>
        </xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplSetMouseEvents">
        <xsl:with-param name="prmHandler" select="'mobjApp.MenuItem_HandleMouseEvents'"/>
      </xsl:call-template>
      
      <xsl:call-template name="tplDrawFrame">
        <xsl:with-param name="prmLeftClass" select="'MenuItem-Left'"/>
        <xsl:with-param name="prmCenterClass" select="'MenuItem-Center'"/>
        <xsl:with-param name="prmRightClass" select="'MenuItem-Right'"/>
        <xsl:with-param name="prmLeftFrameWidth" select="[Skin.MenuItemHighlightLeftWidth]"/>
        <xsl:with-param name="prmRightFrameWidth" select="[Skin.MenuItemHighlightRightWidth]" />        
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>

      <div  class="MenuItem-CellContainer" style="float:{$left};" dir="{$dir}">
        <xsl:if test="$varMenuItemIconsColumnWidth &gt; 0">
          <div class="MenuItem-Cell MenuItem-Icon" style="float:{$left};width:{$varMenuItemIconsColumnWidth}px;overflow:hidden">
            <xsl:if test="@Attr.Checked = '1' or @Attr.RadioCheck = '1'">
              <xsl:if test="@Attr.Checked = '1'">
                <xsl:if test="$prmIsEnabled='0'"><img src="[Skin.CheckedImageDisable]" alt="" /></xsl:if>
                <xsl:if test="not($prmIsEnabled='0')"><img src="[Skin.CheckedImage]" alt="" /></xsl:if>
              </xsl:if>
              <xsl:if test="@Attr.RadioCheck = '1'">
                <xsl:if test="$prmIsEnabled='0'"><img src="[Skin.RadioCheckedImageDisable]" alt="" /></xsl:if>
                <xsl:if test="not($prmIsEnabled='0')"><img src="[Skin.RadioCheckedImage]" alt="" /></xsl:if>
              </xsl:if>
            </xsl:if>
            <xsl:if test="not(@Attr.Checked = '1') and not(@Attr.RadioCheck = '1')">
              <xsl:if test="@Attr.Icon"><img src="{@Attr.Icon}" alt=""/></xsl:if>
              <xsl:if test="not(@Attr.Icon)"><xsl:call-template name="tplDrawEmptyImage"/></xsl:if>
            </xsl:if>         
          </div>
        </xsl:if>
        <xsl:if test="@Attr.Text">          
          <div style="float:{$left};width:{$varFixedMenuItemLabelWidth}px;">
            <!-- If MenuItem is disabled -->
            <xsl:if test="not($prmIsEnabled='0')">
            <xsl:attribute name="class">MenuItem-Cell MenuItem-Label </xsl:attribute>
          </xsl:if>
            <xsl:if test="$prmIsEnabled='0'">
            <xsl:attribute name="class">MenuItem-Cell MenuItem-Label_Disabled </xsl:attribute>
          </xsl:if>
            <span class="nobr" dir="{$dir}">
              <xsl:attribute name="style">
                <xsl:call-template name="tplApplyCursorStyle" />;
              </xsl:attribute>
              <xsl:call-template name="tplDecodeTextAsHtml"/>
            </span>
          </div>
        </xsl:if>
        <xsl:if test="not($varHasNodes='1')">
          <xsl:if test="@Attr.Shortcut">
            <div style="float:{$left};width:{$varMenuItemShortCutWidth}px;">
              <xsl:if test="not($prmIsEnabled='0')">
                <xsl:attribute name="class">MenuItem-Cell MenuItem-Shortcut </xsl:attribute>
              </xsl:if>
              <xsl:if test="$prmIsEnabled='0'">
                <xsl:attribute name="class">MenuItem-Cell MenuItem-Shortcut_Disable </xsl:attribute>
              </xsl:if>
              <span class="nobr" dir="{$dir}">
                <xsl:value-of select="@Attr.Shortcut"/> 
              </span>
            </div>
          </xsl:if>
        </xsl:if>
        <xsl:if test="$varHasNodes='1'">
          <div class="MenuItem-Cell MenuItem-Arrow" style="float:{$left};width:{../@Attr.MenuItemArrowWidth}px;">                    
            <xsl:if test="$prmIsEnabled='0'">
              <img src="[Skin.ArrowImageDisabled]" alt="" />
            </xsl:if>
            <xsl:if test="not($prmIsEnabled='0')">
              <img src="[Skin.ArrowImage]" alt="" />
            </xsl:if>
          </div>
        </xsl:if>
        &#160;
      </div>
    </xsl:if>
    <xsl:if test="@Attr.IsSeperator='1'">      
      <xsl:attribute name="class">Common-HandCursor MenuItem-Control</xsl:attribute>
        <div  class="MenuItem-SeperatorIconColumn" style="Top:0px; {$left}:0;" >&#160;</div>
        <div  class="MenuItem-Seperator" style="Top:0px; {$left}:[Skin.MenuItemIconsColumnWidth]px;">&#160;</div>      
    </xsl:if>
   
  </xsl:template>     
</xsl:stylesheet>
