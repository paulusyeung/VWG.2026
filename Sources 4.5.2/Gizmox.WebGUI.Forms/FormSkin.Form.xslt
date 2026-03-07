<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!-- Top level standard form -->
  <xsl:template match="WG:Tags.Form[not(@Inline='1') and not(@Attr.CustomStyle)]" migration-match="WG:Tags.Form[not(@Attr.Type='PopupWindow') and not(@Inline='1') and not(@Attr.CustomStyle)]">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>    
    <xsl:choose>
      <xsl:when test="$varFullScreenMode='1' and @Attr.Type" >
        <xsl:call-template name="tplWriteFormBody">
          <xsl:with-param name="prmClassName">Form-FullScreen Form-Window Form-DialogWindow <xsl:choose><xsl:when test="not($prmIsEnabled='0')">Form-Control</xsl:when><xsl:otherwise>Form-ControlDisabled</xsl:otherwise></xsl:choose></xsl:with-param>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          <xsl:with-param name="prmStyle"><xsl:call-template name="tplApplyBeforeEntranceVisualEffects"/></xsl:with-param>              
        </xsl:call-template>
      </xsl:when>
        <xsl:otherwise>
          <xsl:call-template name="tplWriteFormBodyWithClass">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:call-template>
        </xsl:otherwise>
      </xsl:choose>    
  </xsl:template>

  <!-- override to prevent styling -->
  <xsl:template match="WC:Tags.Form" mode="modApplyStyle"/>

  <xsl:template name="tplDrawFormControl" >
    <xsl:param name="prmControlClass" select="'Form-Control'"/>
    <xsl:param name="prmControlDisabledClass" select="'Form-ControlDisabled'"/>
    <xsl:param name="prmIsEnabled" />

    <!-- Set the control class -->
    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlDisabledClass)"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:call-template name="tplWriteFormContainer">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <!-- None top level form -->
  <xsl:template match="WC:Tags.Form" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawFormControl">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>
  
  <!-- Disable styles that are not relevant fora  none top level form -->
  <xsl:template match="WC:Tags.Form" mode="modApplyStyle">
    <xsl:choose>
      <xsl:when test="@Attr.FormBorderStyle=0">
        <xsl:call-template name="tplApplyStyles"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="1" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmBorderValue" select="'border:none;'" />
          <xsl:with-param name="prmBackgroundValue" select="'transparent'" />
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!-- Writes a non-top level form body with in the frame center -->
  <xsl:template match="WC:Tags.Form" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplWriteFormBodyWithClass">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      <xsl:with-param name="prmSetControlAttributes" select="0"/>
    </xsl:call-template>
  </xsl:template>

  <!--Match for a form content in popup mode-->
  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplWriteFormBodyWithClass">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <!--Match for a form which is displayed whithin a popup window-->
  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and not(@Attr.CustomStyle)]">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varFormHeightOffset" select="[Skin.PopupWindowOffsetHeight]"/>
    <xsl:variable name="varFormWidthOffset" select="[Skin.PopupWindowOffsetWidth]"/>
    <xsl:variable name="varBoxShadowSupport"><xsl:call-template name="tplSupportsCSS3BrowserCapability"><xsl:with-param name="prmCSS3BrowserCapability" select="32"/></xsl:call-template></xsl:variable>
    <div class="Form-PopupWindow" style="height:{number(@Attr.Height)+$varFormHeightOffset}px;width:{number(@Attr.Width)+$varFormWidthOffset}px;">                  
       <xsl:call-template name="tplDrawFrame">
          <xsl:with-param name="prmLeftBottomClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-BottomLeft'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmLeftClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-Left'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmLeftTopClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-TopLeft'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmTopClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-Top'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmRightTopClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-TopRight'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmRightClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-Right'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmRightBottomClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-BottomRight'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmBottomClass">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
              <xsl:otherwise><xsl:value-of select="'Form-Bottom'"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmCenterClass" select="'Form-Center'"/>
          <xsl:with-param name="prmCenterContent" select="." />
         
          <xsl:with-param name="prmIsActiveFrame" select="1" />
         
          <xsl:with-param name="prmLeftFrameWidth">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
              <xsl:otherwise><xsl:value-of select="[Skin.LeftPopupWindowFrameWidth]"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmRightFrameWidth">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
              <xsl:otherwise><xsl:value-of select="[Skin.RightPopupWindowFrameWidth]"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmTopFrameHeight">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
              <xsl:otherwise><xsl:value-of select="[Skin.TopPopupWindowFrameHeight]"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmBottomFrameHeight">
            <xsl:choose>
              <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
              <xsl:otherwise><xsl:value-of select="[Skin.BottomPopupWindowFrameHeight]"/></xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
        </xsl:call-template>
     </div>
  </xsl:template>

  <!--Match for Top-level form's control box  -->
  <xsl:template match="WG:Tags.Form" mode="modControlBox">
    <xsl:call-template name="tplDrawFormControlBox"/>
  </xsl:template>

  <!--Match for NOT Top-level form's control box  -->
  <xsl:template match="WC:Tags.Form" mode="modControlBox">
    <xsl:call-template name="tplDrawFormControlBox">
      <xsl:with-param name="prmDisableButtons" select="1"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WG:Tags.FormControlBox" name="tplDrawFormControlBox">
    <xsl:param name="prmDisableButtons"/>

    <xsl:choose>
      <xsl:when test="not(@Attr.ControlBox='0')">
        <!--Attribute value variables-->
      <xsl:variable name="varShowMaximizeBox" select="@Attr.Maximize='1'"/>
      <xsl:variable name="varShowMinimizeBox" select="@Attr.Minimize='1'"/>
      <xsl:variable name="varFormBorderStyle" select="@Attr.FormBorderStyle"/>
      <xsl:variable name="varWindowState" select="@Attr.WindowState"/>
      <xsl:variable name="varShowCloseBox" select="not(@Attr.Close='0')"/>

      <!--Classes variables-->
      <xsl:variable name="varMinimizeBoxClass">
        <xsl:choose>
          <xsl:when test="$varWindowState='1'">Form-RestoreButton</xsl:when>
          <xsl:otherwise>Form-MinimizeButton</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="varMinimizeBoxDisabledClass">
        <xsl:choose>
          <xsl:when test="$varWindowState='1'">Form-RestoreButton Form-RestoreButton_Disabled</xsl:when>
          <xsl:otherwise>Form-MinimizeButton Form-MinimizeButton_Disabled</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="varMaximizeBoxClass">
        <xsl:choose>
          <xsl:when test="$varWindowState='2'">Form-RestoreButton</xsl:when>
          <xsl:otherwise>Form-MaximizeButton</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="varMaximizeBoxDisabledClass">
        <xsl:choose>
          <xsl:when test="$varWindowState='2'">Form-RestoreButton Form-RestoreButton_Disabled</xsl:when>
          <xsl:otherwise>Form-MaximizeButton Form-MaximizeButton_Disabled</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <!--Tooltip variables-->
      <xsl:variable name="varMinimizeBoxTitle">
        <xsl:choose>
          <xsl:when test="$varWindowState='1'">Labels.WindowRestoreUp</xsl:when>
          <xsl:otherwise>Labels.WindowMinimize</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="varMaximizeBoxTitle">
        <xsl:choose>
          <xsl:when test="$varWindowState='2'">Labels.WindowRestoreDown</xsl:when>
        <xsl:otherwise>Labels.WindowMaximize</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>


    <table id="VWGE_WinHeader{@Attr.Id}" class="Common-CellPadding0 Common-CellSpacing0 Form-HeaderPart Form-HeaderButtons" dir="{$dir}" style="{$right}:0px;table-layout:auto;" onmousedown="Popups_HidePopups(); Web_EventCancelBubble(event);">
      <tr>
        <xsl:if test="($varShowMaximizeBox or $varShowMinimizeBox) and ($varFormBorderStyle &lt; 5 and not($varFormBorderStyle=0))">
          <td>
            <div id="VWGE_WinMinimize{@Attr.Id}" style="overflow:hidden">
                  <xsl:if test="$varShowMinimizeBox">
                    <xsl:if test="not($prmDisableButtons)">
                      <xsl:attribute name="onclick">mobjApp.Forms_MinimizeInlineWindow(<xsl:value-of select="@Attr.Id"/>,window,true)</xsl:attribute>
                    </xsl:if>
                    <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMinimizeBoxClass)"/></xsl:attribute>
                    <xsl:attribute name="title"><xsl:value-of select="$varMinimizeBoxTitle"/></xsl:attribute>
                    <xsl:call-template name="tplSetHighlight" />
                  </xsl:if>
                  <xsl:if test="not($varShowMinimizeBox)">
                    <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMinimizeBoxDisabledClass)"/></xsl:attribute>
                  </xsl:if>
                  <xsl:call-template name="tplDrawEmptyImage">
                    <xsl:with-param name="prmImageWidth" select="'100&#37;'"/>
                    <xsl:with-param name="prmImageHeight" select="'100&#37;'"/>
                  </xsl:call-template>
                </div>
              </td>
              <td>
                <div id="VWGE_WinMaximize{@Attr.Id}" style="overflow:hidden">
                  <xsl:if test="$varShowMaximizeBox">
                    <xsl:if test="not($prmDisableButtons)">
                      <xsl:attribute name="onclick">mobjApp.Forms_MaximizeInlineWindow(<xsl:value-of select="@Attr.Id"/>,event,window,true,true)</xsl:attribute>
                    </xsl:if>
                      <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMaximizeBoxClass)"/></xsl:attribute>
                      <xsl:attribute name="title"><xsl:value-of select="$varMaximizeBoxTitle"/></xsl:attribute>
                    <xsl:call-template name="tplSetHighlight" />
                  </xsl:if>
                    <xsl:if test="not($varShowMaximizeBox)">
                      <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMaximizeBoxDisabledClass)"/></xsl:attribute>
                    </xsl:if>
                  <xsl:call-template name="tplDrawEmptyImage">
                    <xsl:with-param name="prmImageWidth" select="'100&#37;'"/>
                    <xsl:with-param name="prmImageHeight" select="'100&#37;'"/>
                  </xsl:call-template>
                </div>
              </td>
            </xsl:if>
            <td>
              <div id="VWGE_WinClose{@Attr.Id}" class="Common-HandCursor Form-CloseButton" style="overflow:hidden" title="Labels.WindowClose">
                <xsl:attribute name="class">
                  <xsl:choose>
                    <xsl:when test="$varShowCloseBox">Common-HandCursor Form-CloseButton</xsl:when>
                    <xsl:otherwise>Common-DefaultCursor Form-CloseButton_Disabled</xsl:otherwise>
                  </xsl:choose>
                </xsl:attribute>
                <xsl:if test="not($prmDisableButtons) and $varShowCloseBox">
                  <xsl:attribute name="onclick">mobjApp.Forms_CloseInlineWindow(<xsl:value-of select="@Attr.Id"/>,event,window);</xsl:attribute>
                  <xsl:call-template name="tplSetHighlight" />
                </xsl:if>
                <xsl:call-template name="tplDrawEmptyImage">
                  <xsl:with-param name="prmImageWidth" select="'100&#37;'"/>
                  <xsl:with-param name="prmImageHeight" select="'100&#37;'"/>
                </xsl:call-template>
              </div>
            </td>
          </tr>
          <tr>
            <xsl:choose>
              <xsl:when test="($varShowMaximizeBox or $varShowMinimizeBox) and ($varFormBorderStyle &lt; 5 and not($varFormBorderStyle=0))">
                <td colspan="3" class="Form-BoxesBarFooter"></td>
              </xsl:when>
              <xsl:otherwise>
                <td class="Form-BoxesBarFooter"></td>
              </xsl:otherwise>
            </xsl:choose>
          </tr>
        </table>
      </xsl:when>
      <xsl:otherwise>
        <div id="VWGE_WinHeader{@Attr.Id}" style="display:none;">&#160;</div>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!-- Top level inline modaless form -->
  <xsl:template match="WG:Tags.Form[(not(@Attr.Type='MainWindow') and @Inline='1') or @Attr.Mashup='1']">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled" />
     
    <xsl:call-template name="tplWriteFormContainer" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <!-- Writes the form body with in the frame center -->
  <xsl:template match="WG:Tags.Form" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplWriteFormBodyWithClass">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WG:Tags.Form" mode="modFrameHeaderContent">
    <xsl:call-template name="tplFrameHeaderContent"/>
  </xsl:template>

  <xsl:template match="WC:Tags.Form" mode="modFrameHeaderContent">
    <xsl:call-template name="tplFrameHeaderContent"/>
  </xsl:template>

  <!-- Writes the form header with in the frame header -->
  <xsl:template name="tplFrameHeaderContent">
    <xsl:param name="prmDraggable" select="name()='WG:Tags.Form'"/>
    <xsl:param name="prmDragHandler">mobjApp.Forms_DragInlineWindow(<xsl:value-of select="@Attr.Id"/>,true,this,window,event);Forms_BringWindowToTop(<xsl:value-of select="@Attr.Id"/>);</xsl:param>

    <xsl:variable name="varResizable" select="@Attr.Resize='1'"/>
    <xsl:variable name="varLeftFrameWidth" select="[Skin.LeftDialogWindowFrameWidth]"/>
    <xsl:variable name="varRightFrameWidth" select="[Skin.RightDialogWindowFrameWidth]" />
    <xsl:variable name="varDialogFrame" select="@Attr.FormBorderStyle &lt; 5 and not(@Attr.FormBorderStyle=0)"/>
    <xsl:variable name="varToolFrame" select="@Attr.FormBorderStyle &gt; 4"/>
    <xsl:variable name="varFormHeaderClass">
      <xsl:choose>
        <xsl:when test="$varDialogFrame">Form-Header Form-DialogHeader</xsl:when>
        <xsl:when test="$varToolFrame">Form-Header Form-ToolHeader</xsl:when>
        <xsl:otherwise>Form-Header</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <div id="VWGE_WinHeaderContainer{@Attr.Id}" style="position:static;width:100%;height:100%;">
      <xsl:attribute name="data-vwgdrag">m</xsl:attribute>
      <xsl:choose>
        <xsl:when test="$prmDraggable">
          <xsl:attribute name="class">Common-MoveCursor Common-Unselectable</xsl:attribute>
          <xsl:attribute name="onmousedown"><xsl:value-of select="$prmDragHandler"/></xsl:attribute>
        </xsl:when>
        <xsl:otherwise>
          <xsl:attribute name="class">Common-Unselectable</xsl:attribute>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:call-template name="tplDrawEmptyImage">
        <xsl:with-param name="prmImageWidth" select="'100&#37;'"/>
        <xsl:with-param name="prmImageHeight" select="'100&#37;'"/>
        <xsl:with-param name="prmPositionStyle" select="'absolute'"/>
      </xsl:call-template>

      <xsl:if test="not($varResizable) and $varLeftFrameWidth &gt; 0">
        <div style="position:absolute;width:{$varLeftFrameWidth}px;height:100%;left:{-1*number($varLeftFrameWidth)};top:0px;">&#160;</div>
      </xsl:if>
      <div class="{$varFormHeaderClass}" >

        <!-- Writes the form header caption -->
        <div class="Common-FontData Form-HeaderPart Form-HeaderCaption" dir="{$dir}"  style="{$left}:0px;">
          <xsl:if test="@Attr.Icon">
            <img id="VWGE_WinHeaderIcon{@Attr.Id}" src="{@Attr.Icon}" class="Form-Icon" alt=""/>
            <xsl:text>&#160;</xsl:text>
          </xsl:if>
          <span class="nobr" id ="VWGE_WinTX{@Id}">
            <xsl:call-template name="tplDecodeTextAsHtml"/>
          </span>
        </div>
          <xsl:apply-templates mode="modControlBox" select="." />
      </div>
      <xsl:if test="not($varResizable) and $varRightFrameWidth &gt; 0">
        <div style="position:absolute;width:{$varRightFrameWidth}px;height:100%;right:{-1*number($varRightFrameWidth)};top:0px;">&#160;</div>
      </xsl:if>
    </div>
  </xsl:template>

  <!--Call the tplWriteFormBody template inorder to write form body with a proper class name-->
  <xsl:template name="tplWriteFormBodyWithClass">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmSetControlAttributes" select="1"/>
    
    <xsl:call-template name="tplWriteFormBody" >
      <xsl:with-param name="prmClassName">
        <xsl:if test="@Attr.Style='0'">Common-DefaultCursor Form-DialogBody</xsl:if>
        <xsl:if test="@Attr.Style='1'">Common-DefaultCursor Form-WindowBody</xsl:if>
      </xsl:with-param>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      <xsl:with-param name="prmSetControlAttributes" select="$prmSetControlAttributes"/>
    </xsl:call-template>
  </xsl:template>

  <!-- Creates the form container -->
  <xsl:template name="tplWriteFormContainer">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:variable name="varResizable" select="@Attr.Resize='1'"/>
    <xsl:variable name="varTopLevel" select="name()='WG:Tags.Form'"/>
    <xsl:variable name="varFormBorderStyle" select="@Attr.FormBorderStyle"/>
    <xsl:variable name="varDialogFrame" select="$varFormBorderStyle &lt; 5 and not($varFormBorderStyle=0)"/>
    <xsl:variable name="varToolFrame" select="$varFormBorderStyle &gt; 4"/>
    <xsl:variable name="varNoFrame" select="$varFormBorderStyle=0"/>    

    <!-- Calculate the form height and width offset -->
    <xsl:variable name="varDialogHeightOffset" select="[Skin.TopDialogWindowFrameHeight]+[Skin.BottomDialogWindowFrameHeight]"/>
    <xsl:variable name="varDialogWidthOffset" select="[Skin.LeftDialogWindowFrameWidth]+[Skin.RightDialogWindowFrameWidth]"/>
    <xsl:variable name="varToolHeightOffset" select="[Skin.TopToolWindowFrameHeight]+[Skin.BottomToolWindowFrameHeight]"/>
    <xsl:variable name="varToolWidthOffset" select="[Skin.LeftToolWindowFrameWidth]+[Skin.RightToolWindowFrameWidth]"/>
    <xsl:variable name="varFormHeightOffset" select="0 + number($varDialogFrame)*$varDialogHeightOffset + number($varToolFrame)*$varToolHeightOffset"/>
    <xsl:variable name="varFormWidthOffset" select="0 + number($varDialogFrame)*$varDialogWidthOffset + number($varToolFrame)*$varToolWidthOffset"/>

    <!-- Calculate the handler attribute -->
    <xsl:variable name="varResizeHandlerAttribute">
      <xsl:if test="$varResizable">
        <xsl:value-of select="concat('Forms_DragInlineWindow(' , @Id , ',' , $varResizable , ',this,window,event);')"/>
      </xsl:if>
    </xsl:variable>    

    <xsl:choose>
      <xsl:when test="$varFullScreenMode='1' and @Attr.Type" >
        <xsl:call-template name="tplWriteFormBody">
          <xsl:with-param name="prmClassName">Form-FullScreen Form-Window Form-DialogWindow <xsl:choose><xsl:when test="not($prmIsEnabled='0')">Form-Control</xsl:when><xsl:otherwise>Form-ControlDisabled</xsl:otherwise></xsl:choose></xsl:with-param>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          <xsl:with-param name="prmStyle"><xsl:call-template name="tplApplyBeforeEntranceVisualEffects"/></xsl:with-param>              
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="$varFormBorderStyle">
          <div id="WRP_{@Id}"
               data-vwgdragable="1" data-vwgresizable="1" data-vwginlinewindow="1"
               data-vwgguid="{@Id}" data-vwgmdiparent="{@Attr.MdiParent}"
               onmousedown="Forms_BringWindowToTop({@Id});">
            <xsl:attribute name="style">
          position:absolute;float:left;
          <xsl:choose>
            <xsl:when test="$varTopLevel">
              left:<xsl:value-of select="@L"/>px;top:<xsl:value-of select="@T"/>px;
              height:<xsl:value-of select="number(@H)+$varFormHeightOffset"/>px;
              width:<xsl:value-of select="number(@W)+$varFormWidthOffset"/>px;
            </xsl:when>
            <xsl:otherwise>height:100%;width:100%;</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
            <xsl:call-template name ="tplApplyDragAndDrop"/>
            <!-- FormBorderStyle = Sizable, FixedDialog, Fixed3D, FixedSingle-->
            <xsl:if test="$varDialogFrame">
              <xsl:attribute name="class">Form-Window Form-DialogWindow</xsl:attribute>
              <xsl:call-template name="tplDrawFrame">
                <xsl:with-param name="prmLeftBottomClass" select="'Form-BottomLeft'"/>
                <xsl:with-param name="prmLeftClass" select="'Form-Left'"/>
                <xsl:with-param name="prmLeftTopClass" select="'Form-TopLeft'"/>
                <xsl:with-param name="prmTopClass" select="'Form-Top'"/>
                <xsl:with-param name="prmRightTopClass" select="'Form-TopRight'"/>
                <xsl:with-param name="prmRightClass" select="'Form-Right'"/>
                <xsl:with-param name="prmRightBottomClass" select="'Form-BottomRight'"/>
                <xsl:with-param name="prmBottomClass" select="'Form-Bottom'"/>
                <xsl:with-param name="prmCenterClass" select="'Form-Center'"/>
                <xsl:with-param name="prmRightOverlayClass" select="'Form-RightOverlay'"/>
                <xsl:with-param name="prmLeftOverlayClass" select="'Form-LeftOverlay'"/>
                <xsl:with-param name="prmCenterContent" select="." />
                <xsl:with-param name="prmHeaderContent" select="." />
                <xsl:with-param name="prmResizeHandler" select="$varResizeHandlerAttribute"/>

                <xsl:with-param name="prmIsActiveFrame" select="1" />

                <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftDialogWindowFrameWidth]"/>
                <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightDialogWindowFrameWidth]" />
                <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopDialogWindowFrameHeight]"/>
                <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomDialogWindowFrameHeight]"/>
              </xsl:call-template>
            </xsl:if>

            <!-- FormBorderStyle = FixedToolWindow, SizableToolWindow-->
            <xsl:if test="$varToolFrame">
              <xsl:attribute name="class">Form-Window Form-ToolWindow</xsl:attribute>
              <xsl:call-template name="tplDrawFrame">
                <xsl:with-param name="prmLeftBottomClass" select="'Form-BottomLeft'"/>
                <xsl:with-param name="prmLeftClass" select="'Form-Left'"/>
                <xsl:with-param name="prmLeftTopClass" select="'Form-TopLeft'"/>
                <xsl:with-param name="prmTopClass" select="'Form-Top'"/>
                <xsl:with-param name="prmRightTopClass" select="'Form-TopRight'"/>
                <xsl:with-param name="prmRightClass" select="'Form-Right'"/>
                <xsl:with-param name="prmRightBottomClass" select="'Form-BottomRight'"/>
                <xsl:with-param name="prmBottomClass" select="'Form-Bottom'"/>
                <xsl:with-param name="prmCenterClass" select="'Form-Center'"/>
                <xsl:with-param name="prmCenterContent" select="." />
                <xsl:with-param name="prmHeaderContent" select="." />
                <xsl:with-param name="prmResizeHandler" select="$varResizeHandlerAttribute"/>

                <xsl:with-param name="prmIsActiveFrame" select="1" />

                <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftToolWindowFrameWidth]"/>
                <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightToolWindowFrameWidth]" />
                <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopToolWindowFrameHeight]"/>
                <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomToolWindowFrameHeight]"/>
              </xsl:call-template>
            </xsl:if>

            <!-- FormBorderStyle = None-->
            <xsl:if test="$varNoFrame">
              <xsl:attribute name="class">Form-Window Form-CenterNoFrame</xsl:attribute>
              <xsl:apply-templates select="." mode="modFrameCenterContent" >
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:apply-templates>
            </xsl:if>
          </div>
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="WG:Tags.Form[@vwg_content='1']">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>

    <xsl:call-template name="tplWriteFormBodyWithClass">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WG:Tags.Form" mode="modScrollbars">
    <xsl:call-template name="tplFormScrollBars" />
  </xsl:template>
  
  <xsl:template match="WC:Tags.Form" mode="modScrollbars">
    <xsl:call-template name="tplFormScrollBars" />
  </xsl:template>

  <xsl:template name="tplFormScrollBars">
    <xsl:param name="prmContainerElementID" select="@Attr.Id" />
    <xsl:param name="prmScrollbars" select="@Attr.Scrollbars" />
    <xsl:param name="prmArrowsBaseClass" select="'Form-ArrowsClass'" />
    <xsl:param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
    <xsl:param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
    <xsl:param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
    <xsl:param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
    <xsl:param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
    <xsl:param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
    <xsl:param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
    <xsl:param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />

    <xsl:call-template name="tplDrawScrollbars">
      <xsl:with-param name="prmContainerElementID" select="$prmContainerElementID" />
      <xsl:with-param name="prmScrollbars" select="$prmScrollbars" />
      <xsl:with-param name="prmArrowsBaseClass" select="$prmArrowsBaseClass" />
      <xsl:with-param name="prmTopArrowThickness" select="$prmTopArrowThickness" />
      <xsl:with-param name="prmRightArrowThickness" select="$prmRightArrowThickness" />
      <xsl:with-param name="prmBottomArrowThickness" select="$prmBottomArrowThickness" />
      <xsl:with-param name="prmLeftArrowThickness" select="$prmLeftArrowThickness" />
      <xsl:with-param name="prmHorizontalHoverSpeed" select="$prmHorizontalHoverSpeed" />
      <xsl:with-param name="prmHorizontalDownSpeed" select="$prmHorizontalDownSpeed" />
      <xsl:with-param name="prmVerticalHoverSpeed" select="$prmVerticalHoverSpeed" />
      <xsl:with-param name="prmVerticalDownSpeed" select="$prmVerticalDownSpeed" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>