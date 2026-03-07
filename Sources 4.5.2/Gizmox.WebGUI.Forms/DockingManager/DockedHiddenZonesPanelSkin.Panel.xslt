<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='DockedHiddenZonesPanelSkin']" mode="modContent">

    <xsl:variable name="varPaddingRight">
      <xsl:choose>
        <xsl:when test="@Attr.PaddingRight">
          <xsl:value-of select="@Attr.PaddingRight"/>
        </xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varPaddingLeft">
      <xsl:choose>
        <xsl:when test="@Attr.PaddingLeft">
          <xsl:value-of select="@Attr.PaddingLeft"/>
        </xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:choose>
      <xsl:when test="not($varPaddingLeft='0') or not($varPaddingRight='0')">
        <div style="width:100%;height:100%;padding-{$right}:{$varPaddingRight}px;padding-{$left}:{$varPaddingLeft}px;">
          <xsl:call-template name="tplDrawInnerHiddenPanel">
          </xsl:call-template>
        </div>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplDrawInnerHiddenPanel" />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="tplDrawHiddenPanelAPI">
    <xsl:param name="prmManagerId"/>
    <xsl:param name="prmDocking"/>
    <xsl:param name="prmPanelId"/>
    <xsl:param name="prmIsVertical"/>
    <xsl:param name="prmShowScrollers"/>
    
    <xsl:call-template name="tplCompleteScrollCapabilities"/>
    <div dir="{$dir}" id="HPIC_{$prmManagerId}{$prmDocking}" onresize="mobjApp.DockedHiddenZonesPanel_UpdateScrollers('{$prmManagerId}','{$prmPanelId}','{$prmDocking}', event, window)" >
      <xsl:attribute name="vwgHasScrollers"><xsl:value-of select="$prmShowScrollers"/></xsl:attribute>
      <xsl:attribute name="class">
        DockedHiddenZonesPanelSkin-ItemsWrapperBase 
        <xsl:choose>
          <xsl:when test="$prmIsVertical='1'">DockedHiddenZonesPanelSkin-ItemsWrapperVertical DockedHiddenZonesPanelSkin-ItemsWrapperVerticalBase</xsl:when>
          <xsl:otherwise>DockedHiddenZonesPanelSkin-ItemsWrapperHorizontal DockedHiddenZonesPanelSkin-ItemsWrapperHorizontalBase</xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:attribute name="style">
        <xsl:if test="$prmShowScrollers='1'">
          <xsl:choose>
            <xsl:when test="$prmIsVertical='1'">top:[Skin.ScrollerThickness]px;bottom:[Skin.ScrollerThickness]px;left:0px;right:0px;</xsl:when><xsl:otherwise>top:0px;bottom:0px;left:[Skin.ScrollerThickness]px;right:[Skin.ScrollerThickness]px;</xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:attribute>
      
      <xsl:call-template name="tplApplyScrollableAttributes" />
      <xsl:call-template name="tplRestoreScroll" />
      
      <xsl:call-template name="tplDrawHiddenZonePanelItems">
        <xsl:with-param name="prmDocking" select="$prmDocking" />
        <xsl:with-param name="prmManagerId" select="$prmManagerId" />
        <xsl:with-param name="prmPanelId" select="$prmPanelId" />
        <xsl:with-param name="prmIsVertical" select="$prmIsVertical" />
      </xsl:call-template>
    </div>
  </xsl:template>
  
  <xsl:template name="tplDrawInnerHiddenPanel">

    <xsl:variable name="varDockedManagerId" select="ancestor::WC:Tags.DockManager[1]/@Attr.Id" />
    <xsl:variable name="varDocking" select="@Attr.Docking" />
    <xsl:variable name="varId" select="@Attr.Id" />

    <xsl:variable name="varShowScrollers" select="@vwgShowScrollers" />

    <xsl:variable name="varDrawScrollers">
      <xsl:choose>
        <xsl:when test="not($varShowScrollers) or $varShowScrollers='1'">0</xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varIsVertical">
      <xsl:choose>
        <xsl:when test="$varDocking='T' or $varDocking='B'">0</xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varBackwardScroll">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">top</xsl:when>
        <xsl:otherwise><xsl:value-of select="$left"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varForwardScroll">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">bottom</xsl:when>
        <xsl:otherwise><xsl:value-of select="$right"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varAbsoluteDock">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'"><xsl:value-of select="$left"/></xsl:when>
        <xsl:otherwise>top</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varForwardDock">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">bottom</xsl:when>
        <xsl:otherwise><xsl:value-of select="$right"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varBackwardDock">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">top</xsl:when>
        <xsl:otherwise><xsl:value-of select="$left"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varFillerDimention">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">width</xsl:when>
        <xsl:otherwise>height</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varScrollerThicknessDimention">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">height</xsl:when>
        <xsl:otherwise>width</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varItemsContainerOrientation">
      <xsl:choose>
        <xsl:when test="$varIsVertical='1'">Vertical</xsl:when>
        <xsl:otherwise>Horizontal</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varScrollerThickness">[Skin.ScrollerThickness]</xsl:variable>

    <!--This div is because of the DockPadding that we assign to the panels-->
    <div style="position:relative;height:100%;width:100%;">

      <!-- Backwards scroller -->
      <div vwgPanelId="HPIC_{$varDockedManagerId}{$varDocking}" vgwScrollSide="{$varBackwardScroll}">
        <xsl:attribute name="style">
          position:absolute;<xsl:value-of select="$varFillerDimention" />:100%;<xsl:value-of select="$varScrollerThicknessDimention" />:<xsl:value-of select="$varScrollerThickness" />px;<xsl:value-of select="$varAbsoluteDock" />:0px;<xsl:value-of select="$varBackwardDock" />:0px;<xsl:if test="$varDrawScrollers='0'">display:none;</xsl:if>z-index:1;
        </xsl:attribute>
        <xsl:attribute name="class">
          <xsl:choose>
            <xsl:when test="$varIsVertical='1'">DockedHiddenZonesPanelSkin-ScrollerTop</xsl:when>
            <xsl:when test="$dir='RTL'">DockedHiddenZonesPanelSkin-ScrollerRight</xsl:when>
            <xsl:otherwise>DockedHiddenZonesPanelSkin-ScrollerLeft</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        <xsl:call-template name="tplSetMouseEvents">
          <xsl:with-param name="prmHandler">mobjApp.DockedHiddenZonesPanel_Scroll</xsl:with-param>
        </xsl:call-template>
      </div>

      <!-- Draw the logical panel itself -->
      <xsl:call-template name="tplDrawHiddenPanelAPI">
        <xsl:with-param name="prmManagerId" select="$varDockedManagerId" />
        <xsl:with-param name="prmDocking" select="$varDocking" />
        <xsl:with-param name="prmPanelId" select="$varId" />
        <xsl:with-param name="prmIsVertical" select="$varIsVertical"/>
        <xsl:with-param name="prmShowScrollers" select="$varDrawScrollers"/>
      </xsl:call-template>

      <!-- Forward scroller -->
      <div vwgPanelId="HPIC_{$varDockedManagerId}{$varDocking}" vgwScrollSide="{$varForwardScroll}" >
        <xsl:attribute name="style">
          position:absolute;<xsl:value-of select="$varFillerDimention" />:100%;<xsl:value-of select="$varScrollerThicknessDimention" />:<xsl:value-of select="$varScrollerThickness" />px;<xsl:value-of select="$varAbsoluteDock" />:0px;<xsl:value-of select="$varForwardDock" />:0px;<xsl:if test="$varDrawScrollers='0'">display:none;</xsl:if>z-index:1;
        </xsl:attribute>
        <xsl:attribute name="class">
          <xsl:choose>
            <xsl:when test="$varIsVertical='1'">DockedHiddenZonesPanelSkin-Scrollerbottom</xsl:when>
            <xsl:when test="$dir='RTL'">DockedHiddenZonesPanelSkin-ScrollerLeft</xsl:when>
            <xsl:otherwise>DockedHiddenZonesPanelSkin-ScrollerRight</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        <xsl:call-template name="tplSetMouseEvents">
          <xsl:with-param name="prmHandler">mobjApp.DockedHiddenZonesPanel_Scroll</xsl:with-param>
        </xsl:call-template>
      </div>
    </div>

    <!-- If show scrollers was not defined, invoke a JS function that tells the scrollers to draw or not -->
    <xsl:if test="not($varShowScrollers)">
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod">
          mobjApp.DockedHiddenZonesPanel_UpdateScrollers('<xsl:value-of select="$varDockedManagerId" />','<xsl:value-of select="$varId" />','<xsl:value-of select="$varDocking" />', event, window)
        </xsl:with-param>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawHiddenZonePanelItems">
    <xsl:param name="prmPanelId" />
    <xsl:param name="prmManagerId" />
    <xsl:param name="prmDocking" />
    <xsl:param name="prmIsVertical" />

    <xsl:for-each select="Tags.DockingZoneHeader">
      <xsl:variable name="varZoneId" select="@Attr.DockingZoneId" />
      <xsl:variable name="varParameters">'<xsl:value-of select="$prmPanelId" />','<xsl:value-of select="$varZoneId" />', window</xsl:variable>
      <xsl:variable name="varImage" select="@Attr.Image"/>
      <xsl:variable name="varText"><xsl:call-template name="tplDecodeText"><xsl:with-param name="prmText" select="@Attr.Text"/></xsl:call-template></xsl:variable>
      <xsl:variable name="varItemDimention" select="@Attr.Length" />
      
      <xsl:variable name="varItemStyle">
        <xsl:choose><!--0 - not vertical-->
          <xsl:when test="$prmIsVertical='0'">height:100%;</xsl:when>
          <xsl:otherwise>width:<xsl:value-of select="$varItemDimention" />px;height:<xsl:value-of select="$varItemDimention" />px;line-height:<xsl:value-of select="$varItemDimention" />px;</xsl:otherwise> 
        </xsl:choose>
      </xsl:variable>
      
      <xsl:variable name="varMarginDimention">
        <xsl:choose>
          <xsl:when test="$prmIsVertical='0'"><xsl:value-of select="$right"/></xsl:when>
          <xsl:otherwise>bottom</xsl:otherwise> 
        </xsl:choose>
      </xsl:variable>
      
      <xsl:variable name="varVerticalItemContentHeight">
        <xsl:value-of select="number([Skin.PanelThickness])-number([Skin.HiddenZoneItemStyleVerticalPadding])"/>
      </xsl:variable>
      
      <div>
        <xsl:attribute name="class">DockedHiddenZonesPanelSkin_ItemContainer 
        <xsl:choose>
          <xsl:when test="$prmIsVertical='0'">DockedHiddenZonesPanelSkin_ItemContainerHorizontal</xsl:when>
          <xsl:otherwise>DockedHiddenZonesPanelSkin_ItemContainerVertical</xsl:otherwise> 
        </xsl:choose></xsl:attribute>
        <xsl:attribute name="style">margin-<xsl:value-of select="$varMarginDimention"/>:2px;<xsl:value-of select="$varItemStyle"/></xsl:attribute>
        <div>
          <xsl:attribute name="id">HZPH_<xsl:value-of select="$varZoneId"/></xsl:attribute>
          <xsl:attribute name="class">nobr DockingZoneHiddenPanel-HiddenZoneItem_FontData DockingZoneHiddenPanel-HiddenZoneItem</xsl:attribute>
          <xsl:attribute name="style">height:[Skin.PanelThickness]px;line-height:<xsl:value-of select="$varVerticalItemContentHeight"/>px;</xsl:attribute>
          <xsl:attribute name="onmouseover">mobjApp.DockedHiddenZonesPanel_OnMouseOver(<xsl:value-of select="$varParameters" />)</xsl:attribute>
          <xsl:attribute name="onclick">mobjApp.DockedHiddenZonesPanel_OnClick(<xsl:value-of select="$varParameters" />)</xsl:attribute>
          <xsl:attribute name="onmouseout">mobjApp.DockedHiddenZonesPanel_OnMouseOut(this)</xsl:attribute>
          <xsl:attribute name="title"><xsl:value-of select="$varText"/></xsl:attribute>
          
          <xsl:if test="$varImage">
            <img src="{$varImage}" style="width:[Skin.HiddenZoneItemImageWidth]px;height:[Skin.HiddenZoneItemImageHeight]px;vertical-align:top;" alt="{@Attr.Text}" />
          </xsl:if>
          <span><xsl:value-of select="$varText"/></span>
        </div>
      </div>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
