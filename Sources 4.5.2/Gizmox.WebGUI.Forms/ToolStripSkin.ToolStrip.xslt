<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ToolStrip[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawToolStripAPI">
    <xsl:param name="prmLeftBottomClass" select="'ToolStrip-BottomLeft'"/>
    <xsl:param name="prmLeftClass" select="'ToolStrip-Left'"/>
    <xsl:param name="prmLeftTopClass" select="'ToolStrip-TopLeft'"/>
    <xsl:param name="prmTopClass" select="'ToolStrip-Top'"/>
    <xsl:param name="prmRightTopClass" select="'ToolStrip-TopRight'"/>
    <xsl:param name="prmRightClass" select="'ToolStrip-Right'"/>
    <xsl:param name="prmRightBottomClass" select="'ToolStrip-BottomRight'"/>
    <xsl:param name="prmBottomClass" select="'ToolStrip-Bottom'"/>
    <xsl:param name="prmCenterClass" select="'ToolStrip-Center'"/>
    <xsl:param name="prmContentClass" select="'ToolStrip-Content'"/>
    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
    <xsl:param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmFrameClass" select="'ToolStrip-Frame'"/>
      <xsl:with-param name="prmLeftBottomClass" select="$prmLeftBottomClass"/>
      <xsl:with-param name="prmLeftClass" select="$prmLeftClass"/>
      <xsl:with-param name="prmLeftTopClass" select="$prmLeftTopClass"/>
      <xsl:with-param name="prmTopClass" select="$prmTopClass"/>
      <xsl:with-param name="prmRightTopClass" select="$prmRightTopClass"/>
      <xsl:with-param name="prmRightClass" select="$prmRightClass"/>
      <xsl:with-param name="prmRightBottomClass" select="$prmRightBottomClass"/>
      <xsl:with-param name="prmBottomClass" select="$prmBottomClass"/>
      <xsl:with-param name="prmCenterClass" select="$prmCenterClass"/>
      <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
      <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth"/>
      <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth" />
      <xsl:with-param name="prmTopFrameHeight"  select="$prmTopFrameHeight"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="$prmBottomFrameHeight"/>

      <xsl:with-param name="prmCenterContent" select="."/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStrip[not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawToolStripCenterFrameAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawToolStripCenterFrameAPI">
    <xsl:param name="prmVerticalDropDownButtonClass" select="'TooStrip-VerticalDropDownButton'"/>
    <xsl:param name="prmHorizontalDropDownButtonClass" select="'TooStrip-HorizontalDropDownButton'"/>
    <xsl:param name="prmHorizontalGripClass" select="'TooStrip-HorizontalGrip'"/>
    <xsl:param name="prmVerticalGripClass" select="'TooStrip-VerticalGrip'"/>
    <xsl:param name="prmAllowWrapContents" select="not(@Attr.WrapContents='0')"/>
    <xsl:param name="prmHorizontalGripWidth"  select="[Skin.HorizontalGripWidth]"/>
    <xsl:param name="prmVerticalGripHeight"  select="[Skin.VerticalGripHeight]"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varShowGrip" select="@Attr.ShowGrip"/>
    <xsl:variable name="varStripID" select="@Attr.Id"/>
    <xsl:variable name="varIsVerticalOrientedStrip" select="@Attr.Orientation='1'"/>
    <xsl:variable name="varDropDownClass">
      <xsl:if test="$varIsVerticalOrientedStrip"><xsl:value-of select="$prmVerticalDropDownButtonClass"/></xsl:if>
      <xsl:if test="not($varIsVerticalOrientedStrip)"><xsl:value-of select="$prmHorizontalDropDownButtonClass"/></xsl:if>
    </xsl:variable>
    <xsl:variable name="varGripClass">
      <xsl:if test="$varIsVerticalOrientedStrip"><xsl:value-of select="$prmVerticalGripClass"/></xsl:if>
      <xsl:if test="not($varIsVerticalOrientedStrip)"><xsl:value-of select="$prmHorizontalGripClass"/></xsl:if>
    </xsl:variable>

    <div>
      <xsl:attribute name="style">
        position:static;width:100%;height:100%;overflow:hidden;
        <xsl:if test="not($varShowGrip='0')">
          <xsl:if test="not($varIsVerticalOrientedStrip)">padding-<xsl:value-of select="$left"/>:<xsl:value-of select="$prmHorizontalGripWidth"/>px;</xsl:if>
          <xsl:if test="$varIsVerticalOrientedStrip">padding-top:<xsl:value-of select="$prmVerticalGripHeight"/>px;</xsl:if>
        </xsl:if>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
          <xsl:with-param name="prmVisualEffects" select="0" />
        </xsl:call-template>
        <xsl:call-template name="tplApplyPaddings"/>
      </xsl:attribute>
      <xsl:if test="not($prmAllowWrapContents=0)">
        <xsl:attribute name="onresize">mobjApp.ToolStrip_OnResize(window,this,'<xsl:value-of select="$varStripID"/>');</xsl:attribute>
      </xsl:if>
      <xsl:if test="not($varShowGrip='0')">
        <div class="{$varGripClass}" style="position:absolute;{$left}:0px;top:0px;"><xsl:call-template name="tplDrawEmptyImage"/></div>
      </xsl:if>
      <div style="position:static;width:100%;height:100%;overflow:hidden;" id="VWGTSIC_{$varStripID}">
        <xsl:for-each select="WC:Tags.ToolStripItem[not(@Attr.Visible='0')]">
          <xsl:apply-templates select=".">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </xsl:for-each>
      </div>
      <xsl:if test="not($prmAllowWrapContents=0)">
        <div id="VWGTSD_{@Attr.Id}" class="{$varDropDownClass}" onclick="mobjApp.ToolStrip_ShowDropDown(window,'{$varStripID}',this);">
          <xsl:attribute name="style">
            position:absolute;display:none;
            <xsl:if test="$varIsVerticalOrientedStrip">width:100%;bottom:0px;</xsl:if>
            <xsl:if test="not($varIsVerticalOrientedStrip)">height:100%;<xsl:value-of select="$right"/>:0px;top:0px;</xsl:if>
          </xsl:attribute>
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
        <xsl:call-template name="tplCallMethod">
          <xsl:with-param name="prmMethod" select="concat('mobjApp.ToolStrip_OnResize(window,this.parentNode,',$varStripID,');')"/>
        </xsl:call-template>
      </xsl:if>
    </div>
  </xsl:template>

  <xsl:template name="tplApplyToolStripStyles">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
    </xsl:call-template>      
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStrip[not(@Attr.CustomStyle)]" mode="modApplyStyle">
    <xsl:call-template name="tplApplyToolStripStyles" />
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem">
    <xsl:param name="prmIsEnabled"/>

    <xsl:variable name="varIsEnabled">
      <xsl:call-template name="tplIsEnabled">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:variable>
    
    <xsl:variable name="varHorizontalAlignment">
      <xsl:choose>
        <xsl:when test="@Attr.HorizontalAlignment='1'"><xsl:value-of select="$right"/></xsl:when>
        <xsl:otherwise><xsl:value-of select="$left"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <xsl:variable name="varContainingStrip" select="ancestor::WC:Tags.ToolStrip | ancestor::WC:Tags.StatusStrip  | ancestor::WC:Tags.MenuStrip"/>
    <xsl:variable name="varIsVerticalOrientedStrip" select="$varContainingStrip/@Attr.Orientation='1'" />
    <xsl:variable name="varIsHorizontalOrientedStrip" select="$varContainingStrip/@Attr.Orientation='0'" />
    <xsl:variable name="varIsAutoSize" select="not(@Attr.AutoSize='0')" />
    <xsl:variable name="varHeight">
      <xsl:choose>
        <xsl:when test="not($varIsAutoSize) or $varIsVerticalOrientedStrip"><xsl:value-of select="@Attr.Height"/>px</xsl:when>
        <xsl:otherwise>100%</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varWidth">
      <xsl:choose>
        <xsl:when test="not($varIsAutoSize) or $varIsHorizontalOrientedStrip"><xsl:value-of select="@Attr.Width"/>px</xsl:when>
        <xsl:otherwise>100%</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varIsFloat" select="$varIsHorizontalOrientedStrip" />

    <xsl:variable name="varItemID"><xsl:value-of select="@Attr.OwnerID"/>_<xsl:value-of select="@Attr.MemberID"/></xsl:variable>
    
    <div id="VWG_{$varItemID}" data-vwg_HideOnWrap="{@Attr.HideOnWrap}">
      <xsl:choose>
        <xsl:when test="@Attr.Title">
          <xsl:attribute name="title">
            <xsl:value-of select="@Attr.Title" />
          </xsl:attribute>
        </xsl:when>
      </xsl:choose>
      <xsl:call-template name="tplSetClientUniqueId" />
      <xsl:attribute name="style"><xsl:call-template name="tplApplyOnDrawVisualEffects"/>overflow:hidden;position:relative;height:<xsl:value-of select="$varHeight"/>;width:<xsl:value-of select="$varWidth"/>;<xsl:if test="$varIsFloat">float:<xsl:value-of select="$varHorizontalAlignment"/>;</xsl:if></xsl:attribute>

      <xsl:call-template name="tplApplyAfterDrawVisualEffects">
        <xsl:with-param name="prmGuid">'<xsl:value-of select="$varItemID"/>'</xsl:with-param>
      </xsl:call-template>

      <xsl:apply-templates select="." mode="modAlignedContent">
        <xsl:with-param name="prmIsMiddleAligment" select="$varIsHorizontalOrientedStrip" />
        <xsl:with-param name="prmIsCenterAligment" select="$varIsVerticalOrientedStrip" />
        <xsl:with-param name="prmWidth" select="$varWidth" />
        <xsl:with-param name="prmHeight" select="$varHeight" />
        <xsl:with-param name="prmIsEnabled" select="$varIsEnabled"/>
      </xsl:apply-templates>
    </div>
  </xsl:template>


  <xsl:template match="WC:Tags.ToolStripItem" mode="modAlignedContent">
    <xsl:param name="prmIsMiddleAligment" />
    <xsl:param name="prmIsCenterAligment" />
    <xsl:param name="prmWidth" />
    <xsl:param name="prmHeight" />
    <xsl:param name="prmIsEnabled" />

    <div style="display:table;width:100%;height:100%;border-spacing:0px;">
      <div class="ToolStrip-ButtonWrap">
        <xsl:attribute name="style">
          display:table-cell;width: 100%;height:100%;<xsl:if test="$prmIsMiddleAligment">vertical-align:middle;</xsl:if>
        </xsl:attribute>
        <div>
          <xsl:attribute name="style">
            position:relative;overflow:hidden;width:<xsl:value-of select="$prmWidth" />;height:<xsl:value-of select="$prmHeight" />;
            <xsl:if test="$prmIsCenterAligment">margin-right:auto;margin-left:auto;</xsl:if>
            <xsl:apply-templates mode="modApplyStyle" select="." />
          </xsl:attribute>
          <xsl:apply-templates mode="modContent" select="." >
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </div>
      </div>
    </div>

  </xsl:template>
</xsl:stylesheet>
