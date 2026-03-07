<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template name="tplDrawToolStripMenuItemAPI">
    <xsl:param name="prmMenuItemClass" select="'ToolStripMenuItem-Item'"/>
    <xsl:param name="prmMenuItemImageClass" select="'ToolStripMenuItem-ItemImage'"/>
    <xsl:param name="prmMenuItemArrowImageClass" select="'ToolStripMenuItem-ItemArrow'"/>
    <xsl:param name="prmMenuItemDisabledArrowImageClass" select="'ToolStripMenuItem-ItemArrowDisabled'"/>
    <xsl:param name="prmMenuItemCheckedImageClass" select="'ToolStripMenuItem-ItemChecked'"/>
    <xsl:param name="prmMenuItemDisabledCheckedImageClass" select="'ToolStripMenuItem-ItemCheckedDisabled'"/>
    <xsl:param name="prmMenuItemIndeterminateImageClass" select="'ToolStripMenuItem-ItemIndeterminate'"/>
    <xsl:param name="prmMenuItemDisabledIndeterminateImageClass" select="'ToolStripMenuItem-ItemIndeterminateDisabled'"/>
    <xsl:param name="prmMenuItemArrowImageWidth" select="'[Skin.MenuItemArrowImageWidth]'"/>
    <xsl:param name="prmMenuItemImageWidth" />
    <xsl:param name="prmTextImageGapSize" select="[Skin.TextImageGapSize]"/>
    <xsl:param name="prmShowDropDown" select="'1'"/>
    <xsl:param name="prmApplyID" select="'1'"/>
    <xsl:param name="prmHandleSize" select="0"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmTextShortcutGapSize" select="[Skin.TextShortcutGapSize]"/>
    <xsl:param name="prmTextArrowGapSize" select="[Skin.TextArrowGapSize]"/>
    <xsl:param name="prmMenuItemDisabledTextClass" select="'ToolStripMenuItem-ItemDisabledText'"/>
    <xsl:param name="prmArrowEdgeGapSize" select="[Skin.ArrowEdgeGapSize]"/>
    
    <xsl:variable name="varHasShortcut" select="@Attr.Shortcut and not(@Attr.Shortcut='')" />
    <xsl:variable name="varEnabled" select="not($prmIsEnabled='0')"/>
    <xsl:variable name="varDataID" select="concat(@Attr.OwnerID,'_',@Attr.MemberID)"/>
    <xsl:variable name="varHasNodes" select="@Attr.HasNodes"/>
    <xsl:variable name="varImage" select="@Attr.Image"/>
    <xsl:variable name="varCheckImageClass">
      <xsl:choose>
        <xsl:when test="@Attr.Checked='1'">
          <xsl:if test="$varEnabled"><xsl:value-of select="$prmMenuItemCheckedImageClass"/></xsl:if>
          <xsl:if test="not($varEnabled)"><xsl:value-of select="$prmMenuItemDisabledCheckedImageClass"/></xsl:if>
        </xsl:when>
        <xsl:when test="@Attr.Checked='2'">
          <xsl:if test="$varEnabled"><xsl:value-of select="$prmMenuItemIndeterminateImageClass"/></xsl:if>
          <xsl:if test="not($varEnabled)"><xsl:value-of select="$prmMenuItemDisabledIndeterminateImageClass"/></xsl:if>
        </xsl:when>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varArrowImageClass">
      <xsl:if test="$varEnabled"><xsl:value-of select="$prmMenuItemArrowImageClass"/></xsl:if>
      <xsl:if test="not($varEnabled)"><xsl:value-of select="$prmMenuItemDisabledArrowImageClass"/></xsl:if>
    </xsl:variable>
    <xsl:variable name="varHasImage" select="($varCheckImageClass and not($varCheckImageClass='')) or ($varImage  and not($varImage='')) or ($prmMenuItemImageClass  and not($prmMenuItemImageClass=''))"/>
    <xsl:variable name="varOwnerStrip" select="ancestor::WC:Tags.ToolStrip | ancestor::WC:Tags.MenuStrip | ancestor::WG:Tags.Form[@Attr.CustomStyle='ToolStripDropDown']"/>
    <xsl:variable name="varImageHeight">
      <xsl:choose>
        <xsl:when test="$varOwnerStrip and not (@Attr.ImageScaling='0') and $varOwnerStrip/@Attr.ImageHeight"><xsl:value-of select="$varOwnerStrip/@Attr.ImageHeight"/></xsl:when>
        <xsl:when test="not (@Attr.ImageScaling='0')">16</xsl:when>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varImageWidth">
      <xsl:choose>
        <xsl:when test="$varOwnerStrip and not (@Attr.ImageScaling='0') and $varOwnerStrip/@Attr.ImageWidth"><xsl:value-of select="$varOwnerStrip/@Attr.ImageWidth"/></xsl:when>
        <xsl:when test="not (@Attr.ImageScaling='0')">16</xsl:when>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMenuItemImageMaxWidth" select="$varOwnerStrip/@Attr.MenuItemImageMaxWidth" />
    <xsl:variable name ="varImageExtraWidth" select="[Skin.MenuItemImageExtraWidth]" />
    <xsl:variable name="varMenuItemImageWidth">
      <xsl:choose>
        <xsl:when test="$prmMenuItemImageWidth">
          <xsl:value-of select="$prmMenuItemImageWidth" />
        </xsl:when>
        <xsl:when test="not($varMenuItemImageMaxWidth='0')">
          <xsl:value-of select="number($varMenuItemImageMaxWidth) + number($varImageExtraWidth)"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="'[Skin.MenuItemImageWidth]'"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varMenuItemWidth">
      <!--Width of MenuItem is always the width of the dropdown, 100%-->
      100%
    </xsl:variable>
    <xsl:variable name="varMenuItemHeight">
      <xsl:choose>
        <xsl:when test="$prmHandleSize=1"><xsl:value-of select="@Attr.Height" />px</xsl:when>
        <xsl:otherwise>100%</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <div style="display:block;position:static;width:{$varMenuItemWidth};height:{$varMenuItemHeight};">
      <xsl:if test="not($varHasNodes='1')">
        <xsl:attribute name="data-vwg_AfterCreateEventHandler">ToolStripMenuItem_AfterCreateEvents</xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmApplyID='1'">
        <xsl:attribute name="id">VWG_<xsl:value-of select="$varDataID"/></xsl:attribute>
      </xsl:if>
      
      <xsl:choose>
        <!--This is a menu item that is inside a DropDown-->
        <xsl:when test="$prmShowDropDown='1'">
          <div class="Common-DefaultCursor Common-FontData {$prmMenuItemClass}" dir="{$dir}">
            <xsl:attribute name="style">width:100%;height:100%;position:relative;
            <xsl:call-template name="tplApplyStyles" >
              <xsl:with-param name="prmBorder" select="0" />
              <xsl:with-param name="prmBackground" select="1" />
              <xsl:with-param name="prmFont" select="1" />
              <xsl:with-param name="prmCursor" select="0" />
              <xsl:with-param name="prmBorderRadius" select="0" />
              <xsl:with-param name="prmVisualEffects" select="1" />
            </xsl:call-template></xsl:attribute>
            <xsl:if test="$varEnabled">
              <xsl:apply-templates select="." mode="modApplyMouseEvents">
                <xsl:with-param name="prmDataID" select="$varDataID"/>
                <xsl:with-param name="prmHasNodes" select="$varHasNodes"/>
              </xsl:apply-templates>
            </xsl:if>

            <xsl:variable name="varTextContentLeft">
              <xsl:choose>
                <xsl:when test="$varHasImage"><xsl:value-of select="number($varMenuItemImageWidth) + number($prmTextImageGapSize)"/></xsl:when>
                <xsl:otherwise>0</xsl:otherwise>
              </xsl:choose>
            </xsl:variable>

            <xsl:variable name="varTextContentRightBase">
              <xsl:value-of select="number($prmTextArrowGapSize) + number($prmMenuItemArrowImageWidth) + number($prmArrowEdgeGapSize)"/>
            </xsl:variable>

            <xsl:variable name="varTextContentRight">
              <xsl:choose>
                <xsl:when test="$varHasShortcut"><xsl:value-of select="number($prmTextShortcutGapSize) + number(@Attr.ShortcutWidth) + $varTextContentRightBase"/></xsl:when>
                <xsl:otherwise><xsl:value-of select="$varTextContentRightBase"/></xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
            
            <xsl:if test="$varHasImage">
              <!-- *************** Image Section ************ -->
              <div>
                <xsl:attribute name="class">ToolStripMenuItem-Section <xsl:value-of select="$prmMenuItemImageClass"/></xsl:attribute>
                <xsl:attribute name="style"><xsl:value-of select="$left"/>:0px;width:<xsl:value-of select="$varMenuItemImageWidth"/>px;</xsl:attribute>
                <!-- Checking if the current item is menu item or contained item (if contained, the image section goes inside the content area, like winforms -->
                <xsl:if test="(@Attr.Type='7')">
                  <div>
                    <xsl:if test="$varCheckImageClass">
                      <xsl:attribute name="class">
                        <xsl:value-of select="$varCheckImageClass"/>
                      </xsl:attribute>
                    </xsl:if>
                    <xsl:attribute name="style">position:relative;overflow:hidden;width:100%;height:100%;<xsl:if test="$varImage">background-image:none;</xsl:if></xsl:attribute>
                    <xsl:if test="$varImage">
                      <table style="width:100%; height:100%;">
                        <tr>
                          <td title="{@Attr.Text}">
                            <xsl:attribute name="style">
                              <xsl:call-template name="tplDrawBackground">
                                <xsl:with-param name="prmImage" select="$varImage" />
                                <xsl:with-param name="prmImageAlign" select="@Attr.ImageAlign" />
                              </xsl:call-template>                              
                              <xsl:choose>
                                <xsl:when test="@Attr.ImageScaling='0'">
                                  width:100%; height:100%;
                                </xsl:when>
                                <xsl:otherwise>
                                  <!--SizeToFit ImageScalingSize of parent-->
                                  width: <xsl:value-of select="$varImageWidth" />px; height: <xsl:value-of select="$varImageHeight" />px;
                                  background-size:  <xsl:value-of select="$varImageWidth" />px; height: <xsl:value-of select="$varImageHeight" />px;
                                </xsl:otherwise>
                              </xsl:choose>
                            </xsl:attribute>
                          </td>
                        </tr>
                      </table>
                    </xsl:if>
                    <xsl:if test="not($varImage)">
                      <xsl:call-template name="tplDrawEmptyImage"/>
                    </xsl:if>
                  </div>
                </xsl:if>
              </div>
            </xsl:if>
            <!-- *************** Text Section ************ -->
            <div>
              <xsl:attribute name="class">ToolStripMenuItem-Section</xsl:attribute>
              <xsl:attribute name="style"><xsl:value-of select="$left"/>:<xsl:value-of select="$varTextContentLeft"/>px;<xsl:value-of select="$right"/>:<xsl:value-of select="$varTextContentRight"/>px;</xsl:attribute>
              
              <xsl:apply-templates select="." mode="modDropDownMenu" >
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:apply-templates>
            </div>
            <xsl:if test="$varHasShortcut">
              <!-- *************** Shortcut Section ************ -->
              <div>
                <xsl:attribute name="class">ToolStripMenuItem-Section</xsl:attribute>
                <xsl:attribute name="style"><xsl:value-of select="$right"/>:<xsl:value-of select="$varTextContentRightBase"/>px;width:<xsl:value-of select="@Attr.ShortcutWidth"/>px;</xsl:attribute>
                
                <xsl:apply-templates select="." mode="modDropDownMenuShortcut">
                  <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                </xsl:apply-templates>
              </div>
            </xsl:if>
            <!-- *************** Arrow Section ************ -->
            <div>
              <xsl:attribute name="class">ToolStripMenuItem-Section</xsl:attribute>
              <xsl:attribute name="style"><xsl:value-of select="$right"/>:<xsl:value-of select="$prmArrowEdgeGapSize" />px;width:<xsl:value-of select="$prmMenuItemArrowImageWidth"/>px;</xsl:attribute>
              <xsl:choose>
                <xsl:when test="$varHasNodes='1'">
                  <div class="{$varArrowImageClass}" style="position:relative;width:100%;height:100%;overflow:hidden;">
                    <xsl:call-template name="tplDrawEmptyImage"/>
                  </div>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:call-template name="tplDrawEmptyImage"/>
                </xsl:otherwise>
              </xsl:choose>
            </div>
          </div>
        </xsl:when>
        <xsl:otherwise>
          <!--This is a menu item that is inside the MenuStrip-->
          <div class="Common-Strech Common-DefaultCursor Common-FontData {$prmMenuItemClass}" dir="{$dir}">
            <xsl:attribute name="style">
              <xsl:text>position:relative;</xsl:text>
              <xsl:call-template name="tplApplyStyles" >
                <xsl:with-param name="prmBorder" select="0" />
                <xsl:with-param name="prmBackground" select="1" />
                <xsl:with-param name="prmFont" select="1" />
                <xsl:with-param name="prmCursor" select="0" />
                <xsl:with-param name="prmBorderRadius" select="0" />
                <xsl:with-param name="prmVisualEffects" select="0" />
              </xsl:call-template>
            </xsl:attribute>
            <xsl:if test="$varEnabled">
              <xsl:apply-templates select="." mode="modApplyMouseEvents">
                <xsl:with-param name="prmDataID" select="$varDataID"/>
                <xsl:with-param name="prmHasNodes" select="$varHasNodes"/>
              </xsl:apply-templates>
            </xsl:if>
            <xsl:call-template name="tplDrawButtonContent">
              <xsl:with-param name="prmTextClass">
                <xsl:if test="$prmIsEnabled='0'">
                  <xsl:value-of select="$prmMenuItemDisabledTextClass"/>
                </xsl:if>
              </xsl:with-param>
              <xsl:with-param name="prmImageClass" select="$varCheckImageClass" />
              <xsl:with-param name="prmImageWidth" select="$varImageWidth" />
              <xsl:with-param name="prmImageHeight" select="$varImageHeight" />
            </xsl:call-template>
          </div>
        </xsl:otherwise>
      </xsl:choose>
      </div>
  </xsl:template>

  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='ToolStripDropDownContentPanel']/WC:Tags.ToolStripItem">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled" />
    
    <xsl:call-template name="tplDrawToolStripMenuItemAPI">
      <xsl:with-param name="prmHandleSize" select="1" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.MenuStrip/WC:Tags.ToolStripItem[@Attr.Type='7' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripMenuItemAPI">
      <xsl:with-param name="prmMenuItemImageClass" select="''"/>
      <xsl:with-param name="prmShowDropDown" select="'0'"/>
      <xsl:with-param name="prmApplyID" select="'0'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmHandleSize" select="0" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawToolStripMenuItemContentAPI">
    <xsl:param name="prmMenuItemDisabledTextClass" select="'ToolStripMenuItem-ItemDisabledText'"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmAlign" select="'MiddleLeft'"/>
    <xsl:param name="prmText" select="@Attr.Text"/>

    <xsl:call-template name="tplDrawAlignedText">
      <xsl:with-param name="prmAlignment" select="$prmAlign" />
      <xsl:with-param name="prmText">
        <xsl:call-template name="tplDecodeTextAsHtml">
          <xsl:with-param name="prmText" select="$prmText"/>
        </xsl:call-template>
      </xsl:with-param>
      <xsl:with-param name="prmTextClass"><xsl:if test="$prmIsEnabled='0'"><xsl:value-of select="$prmMenuItemDisabledTextClass"/></xsl:if>  </xsl:with-param>
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='7' and not(@Attr.CustomStyle)]" mode="modDropDownMenu">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:call-template name="tplDrawToolStripMenuItemContentAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='7' and not(@Attr.CustomStyle)]" mode="modDropDownMenuShortcut">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripMenuItemContentAPI">
      <xsl:with-param name="prmAlign" select="'MiddleRight'"/>
      <xsl:with-param name="prmText" select="@Attr.Shortcut"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


  <xsl:template name="tplDrawToolStripMenuItemApplyMouseEventsAPI">
    <xsl:param name="prmDataID"/>
    <xsl:param name="prmHasNodes"/>

    <xsl:call-template name="tplSetMouseEvents">
      <xsl:with-param name="prmHandler" select="'mobjApp.ToolStripMenuItem_HandleMenuItemMouseEvents'"/>
    </xsl:call-template>

    <xsl:if test="not($prmHasNodes='1')">
      <xsl:attribute name="onclick">
        mobjApp.ToolStripMenuItem_OnClick(event,window,'<xsl:value-of select="$prmDataID"/>');
      </xsl:attribute>
    </xsl:if>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='7' and not(@Attr.CustomStyle)]" mode="modApplyMouseEvents">
    <xsl:param name="prmDataID"/>
    <xsl:param name="prmHasNodes"/>
    <xsl:call-template name="tplDrawToolStripMenuItemApplyMouseEventsAPI">
      <xsl:with-param name="prmDataID" select="$prmDataID"/>
      <xsl:with-param name="prmHasNodes" select="$prmHasNodes"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
