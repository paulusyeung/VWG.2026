<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:WC="wgcontrols">

  <!-- The default style combobox match template -->
  <xsl:template match="WC:Tags.ComboBox" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawComboBoxAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawComboBoxAPI">

    <!-- Params for using the checkbox from other controls -->
    <xsl:param name="prmControlClass" select="'ComboBox-Control'" />
    <xsl:param name="prmContentClass" select="'ComboBox-Content'" />
    <xsl:param name="prmInputClass" select="'ComboBox-Input'" />
    <xsl:param name="prmInputContainerClass">
        <xsl:if test="@Attr.Style='S'"><xsl:value-of select="'ComboBox-InputContainer'"/></xsl:if>
    </xsl:param>
    <xsl:param name="prmDataContainerDropDownListMode" select="'ComboBox-DataContainerDropDownListMode'" />
    <xsl:param name="prmDataContainerDropDownMode" select="'ComboBox-DataContainerDropDownMode'" />
    <xsl:param name="prmDataContainerSimpleMode" select="'ComboBox-DataContainerSimpleMode'" />
    <xsl:param name="prmItemsContainer" select="'ComboBox-ItemsContainer'" />
    <xsl:param name="prmInputHeight" select="[Skin.SimpleComboBoxInputHeight]" />
    <xsl:param name="prmButtonClass" select="'ComboBox-Button'" />
    <xsl:param name="prmButtonContainerClass" select="'ComboBox-ButtonContainer'" />
    <xsl:param name="prmButtonWidth" select="[Skin.DropDownImageWidth]" />
    <xsl:param name="prmItemClass" select="'ComboBox-Item'" />
    <xsl:param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
    <xsl:param name="prmIsAutoComplete" select="@Attr.IsAutoComplete" />

    <!-- Params for using the checkbox from other controls -->
    <xsl:param name="prmControlId" select="@Id" />
    <xsl:param name="prmControlText" select="@Attr.Text" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmControlReadOnly" select="@Attr.ReadOnly='1' or $prmIsEnabled='0'" />
    <xsl:param name="prmStyle" select="@Attr.Style" />
    
    <!--Params for masked combo-->
    <xsl:param name="prmMaskPasteHandler" select="'mobjApp.Common_MaskOnPaste(this);'"/>
    <xsl:param name="prmMaskKeyDownHandler" select="'return mobjApp.Common_MaskKeyDown(this,event);'"/>
    <xsl:param name="prmMaskBlurHandler" select="concat('mobjApp.Common_MaskBlur(&quot;',$prmControlId,'&quot;,this,event,window);')"/>
    <xsl:param name="prmMaskFocusHandler" select="concat('mobjApp.Common_MaskFocus(this,event,&quot;',$prmControlId,'&quot;);')"/>
    <xsl:param name="prmMaskDragEnterHandler" select="'return false;'"/>
    <xsl:param name="prmMaskKeyUpHandler" select="''"/>
    <xsl:param name="prmMaskKeyPressHandler" select="''"/>

    <!-- Set the control class -->
    <xsl:attribute name="class">
      <xsl:text>ComboBox-Container </xsl:text>
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:text>Common-HandCursor </xsl:text>
      </xsl:if>
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:attribute name="onmousewheel">
      <xsl:if test="not($prmStyle='S')">mobjApp.ComboBox_OnContentNavigateWheel('<xsl:value-of select="$prmControlId"/>', '<xsl:value-of select="$prmStyle"/>', window, event,<xsl:value-of select="$prmControlReadOnly"/>);</xsl:if>
      <xsl:if test="$prmStyle='S'">mobjApp.ComboBox_OnListNavigateWheel('<xsl:value-of select="$prmControlId"/>', window, event, <xsl:value-of select="$prmControlReadOnly"/>);</xsl:if>
    </xsl:attribute>

    <!-- Set the control highlight events -->
    <xsl:call-template name="tplSetHighlight" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
    <div class="ComboBox-ControlLayout" style="position:relative;">
      <xsl:attribute name="dir">
        <xsl:call-template name="tplGetRightToLeftValue">
          <xsl:with-param name="prmNoValue" select="'LTR'" />
          <xsl:with-param name="prmYesValue" select="'RTL'" />
          <xsl:with-param name="prmDefaultValue" select="$dir" />
        </xsl:call-template>
      </xsl:attribute>
      <div>
        <xsl:attribute name="style">
          position:absolute;top:0px; <xsl:value-of select="$left"/>:0px;<xsl:choose>
            <xsl:when test="not($prmStyle='S')">
              <xsl:value-of select="$right"/>:<xsl:value-of select="$prmButtonWidth"/>px;bottom:0px;
            </xsl:when>
            <xsl:otherwise><xsl:value-of select="$right"/>:0px;height:<xsl:value-of select="$prmInputHeight"/>px;</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        <xsl:choose>
          <!-- When DropDown Style is 'Simple' / 'DropDown'-->
          <xsl:when test="$prmStyle='S' or $prmStyle='DD'">
            <xsl:call-template name="tplDrawComboBoxInput">
              <xsl:with-param name="prmControlId" select="$prmControlId" />
              <xsl:with-param name="prmControlText" select="$prmControlText" />
              <xsl:with-param name="prmControlReadOnly" select="$prmControlReadOnly" />
              <xsl:with-param name="prmInputClass" select="$prmInputClass" />
              <xsl:with-param name="prmInputContainerClass" select="$prmInputContainerClass" />
              <xsl:with-param name="prmInputHeight" select="$prmInputHeight" />
              <xsl:with-param name="prmIsAutoComplete" select="$prmIsAutoComplete" />
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              <xsl:with-param name="prmContentContainerClass">
                <xsl:choose>
                  <xsl:when test="$prmStyle='S'">
                    <xsl:value-of select="$prmDataContainerSimpleMode" />
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:value-of select="$prmDataContainerDropDownMode" />
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:with-param>
              <xsl:with-param name="prmMaskPasteHandler" select="$prmMaskPasteHandler"/>
              <xsl:with-param name="prmMaskKeyDownHandler" select="$prmMaskKeyDownHandler"/>
              <xsl:with-param name="prmMaskBlurHandler" select="$prmMaskBlurHandler"/>
              <xsl:with-param name="prmMaskFocusHandler" select="$prmMaskFocusHandler"/>
              <xsl:with-param name="prmMaskDragEnterHandler" select="$prmMaskDragEnterHandler"/>
              <xsl:with-param name="prmMaskKeyUpHandler" select="$prmMaskKeyUpHandler"/>
              <xsl:with-param name="prmMaskKeyPressHandler" select="$prmMaskKeyPressHandler"/>  
                
            </xsl:call-template>
          </xsl:when>
          <xsl:otherwise>
            <!-- When DropDown Style is 'DropDownWindow' / 'DropDownList'-->
            <xsl:call-template name="tplDrawComboBoxContent">
              <xsl:with-param name="prmControlId" select="$prmControlId" />
              <xsl:with-param name="prmControlText" select="$prmControlText" />
              <xsl:with-param name="prmControlReadOnly" select="$prmControlReadOnly" />
              <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              <xsl:with-param name="prmDataContainerDropDownListMode" select="$prmDataContainerDropDownListMode" />
              <xsl:with-param name="prmInputHeight" select="$prmInputHeight" />
            </xsl:call-template>
          </xsl:otherwise>
        </xsl:choose>
      </div>

      <xsl:choose>
        <xsl:when test="$prmStyle='S'">
          <div>
            <xsl:attribute name="style">
              left:0px;right:0px;bottom:0px;top:<xsl:value-of select="$prmInputHeight"/>px;position:absolute;
            </xsl:attribute>
            <xsl:call-template name="tplDrawComboBoxListBox" >
              <xsl:with-param name="prmControlId" select="$prmControlId"/>
              <xsl:with-param name="prmControl" select="." />
              <xsl:with-param name="prmItemClass" select="$prmItemClass" />
              <xsl:with-param name="prmItemTableClass" select="$prmItemTableClass" />
              <xsl:with-param name="prmItemHeight" select="@Attr.ItemHeight" />
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              <xsl:with-param name="prmListBoxContainerClass" select="$prmItemsContainer" />
            </xsl:call-template>
            <xsl:call-template name="tplCallMethod">
              <xsl:with-param name="prmMethod" select="concat('mobjApp.ComboBox_OnPopulateSimpleMode(', $prmControlId,',window);')" />
            </xsl:call-template>
          </div>
        </xsl:when>
        <xsl:otherwise>
          <div class="{$prmButtonContainerClass}">
            <xsl:attribute name="style">
              direction:ltr;position:absolute;top:0px; <xsl:value-of select="$right"/>:0px;bottom:0px;width:<xsl:value-of select="$prmButtonWidth"/>px;
            </xsl:attribute>
              <div class="{$prmButtonClass}" style="background-position:center center;background-repeat:no-repeat;width:100%;height:100%;"  onmousedown="if({number($prmControlReadOnly)}==0) mobjApp.ComboBox_ToggleDropDown('{$prmControlId}', window);" tabindex="-1" onfocus="mobjApp.Web_SetFocusByDataId('{$prmControlId}',true);">
                <xsl:text>&#160;</xsl:text>
              </div>
          </div>
        </xsl:otherwise>
      </xsl:choose>
    </div>
  </xsl:template>
  
  
  
  <!-- The default style combobox options match template -->
  <xsl:template match="Tags.Options" >
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawOptionsAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawOptionsAPI">
    <xsl:param name="prmLeftBottomClass" select="'ComboBox-BottomLeft'" />
    <xsl:param name="prmLeftClass" select="'ComboBox-Left'" />
    <xsl:param name="prmLeftTopClass" select="'ComboBox-TopLeft'" />
    <xsl:param name="prmTopClass" select="'ComboBox-Top'" />
    <xsl:param name="prmRightTopClass" select="'ComboBox-TopRight'" />
    <xsl:param name="prmRightClass" select="'ComboBox-Right'" />
    <xsl:param name="prmRightBottomClass" select="'ComboBox-BottomRight'" />
    <xsl:param name="prmBottomClass" select="'ComboBox-Bottom'" />
    <xsl:param name="prmCenterClass" select="'ComboBox-Center'" />

    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftPopupWindowFrameWidth]" />
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightPopupWindowFrameWidth]" />
    <xsl:param name="prmTopFrameHeight" select="[Skin.TopPopupWindowFrameHeight]" />
    <xsl:param name="prmBottomFrameHeight" select="[Skin.BottomPopupWindowFrameHeight]"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varBoxShadowSupport"><xsl:call-template name="tplSupportsCSS3BrowserCapability"><xsl:with-param name="prmCSS3BrowserCapability" select="32"/></xsl:call-template></xsl:variable>

    <div class="ComboBox-PopupWindow">
      <xsl:call-template name="tplDrawFrame">
        <xsl:with-param name="prmLeftBottomClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmLeftBottomClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmLeftClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmLeftClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmLeftTopClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmLeftTopClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmTopClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmTopClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmRightTopClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmRightTopClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmRightClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmRightClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmRightBottomClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmRightBottomClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmBottomClass">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmBottomClass"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmCenterClass" select="$prmCenterClass"/>
        <xsl:with-param name="prmCenterContent" select="." />

        <xsl:with-param name="prmLeftFrameWidth">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmLeftFrameWidth"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmRightFrameWidth">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="$prmRightFrameWidth"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmTopFrameHeight">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmTopFrameHeight"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmBottomFrameHeight">
          <xsl:choose>
            <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmBottomFrameHeight"/></xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </div>
  </xsl:template>


  <!-- The default combobox options match content template -->
  <xsl:template match="Tags.Options" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCenterContentOptionsAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawCenterContentOptionsAPI">
    <xsl:param name="prmItemClass" select="'ComboBox-Item'" />
    <xsl:param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawComboBoxListBox" >
      <xsl:with-param name="prmControlId" select="../@Attr.Id"/>
      <xsl:with-param name="prmControl" select="../." />
      <xsl:with-param name="prmItemClass" select="$prmItemClass" />
      <xsl:with-param name="prmItemTableClass" select="$prmItemTableClass" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmItemHeight" select="../@Attr.ItemHeight" />
    </xsl:call-template>
  </xsl:template>

  <!--Match for applying input's attributes-->
  <xsl:template match="WC:Tags.ComboBox" mode="modApplyAttributes">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmValue" />
    <xsl:param name="prmControlReadOnly" />

    <xsl:call-template name="tplApplyComboBoxAttributesAPI">
      <xsl:with-param name="prmControlId" select="$prmControlId"/>
      <xsl:with-param name="prmValue" select="$prmValue"/>
      <xsl:with-param name="prmControlReadOnly" select="$prmControlReadOnly"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplApplyComboBoxAttributesAPI">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmValue" />
    <xsl:param name="prmControlReadOnly" />
    <xsl:param name="prmKeyUpHandler" select="concat('mobjApp.ComboBox_OnKeyUP(&quot;',$prmControlId,'&quot;,&quot;',@Attr.Style,'&quot;,this,window,event);')"/>
    <xsl:param name="prmKeyPressHandler"/>
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.ComboBox_OnKeyDown(&quot;',$prmControlId,'&quot;,&quot;',@Attr.Style,'&quot;,&quot;',@Attr.AutoCompleteMode,'&quot;,this,window,event);')"/>

    <xsl:if test="not($prmControlReadOnly='1')">
      <xsl:attribute name="onkeyup"><xsl:value-of select="$prmKeyUpHandler"/></xsl:attribute>
      <xsl:attribute name="onkeydown"><xsl:value-of select="$prmKeyDownHandler"/></xsl:attribute>
      <xsl:attribute name="onblur">mobjApp.ComboBox_TextBoxBlur('<xsl:value-of select="@Id"/>',this.value,window);</xsl:attribute>
      <xsl:attribute name="onfocus">mobjApp.ComboBox_OnFocus(this);</xsl:attribute>
    </xsl:if>
    <xsl:attribute name="value"><xsl:call-template name="tplDecodeText"><xsl:with-param name="prmText"  select="$prmValue"/></xsl:call-template></xsl:attribute>
  </xsl:template>
  
  <!-- Draws the combobox input -->
  <xsl:template name="tplDrawComboBoxInput">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmControlText" />
    <xsl:param name="prmControlReadOnly" />
    <xsl:param name="prmInputClass" />
    <xsl:param name="prmInputHeight" />
    <xsl:param name="prmInputContainerClass" />
    <xsl:param name="prmIsAutoComplete" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmContentContainerClass" />

    <xsl:param name="prmMaskPasteHandler" select="'mobjApp.Common_MaskOnPaste(this);'"/>
    <xsl:param name="prmMaskKeyDownHandler" select="'return mobjApp.Common_MaskKeyDown(this,event);'"/>
    <xsl:param name="prmMaskBlurHandler" select="concat('mobjApp.Common_MaskBlur(&quot;',$prmControlId,'&quot;,this,event,window);')"/>
    <xsl:param name="prmMaskFocusHandler" select="concat('mobjApp.Common_MaskFocus(this,event,&quot;',$prmControlId,'&quot;);')"/>
    <xsl:param name="prmMaskDragEnterHandler" select="'return false;'"/>
    <xsl:param name="prmMaskKeyUpHandler" select="''"/>
    <xsl:param name="prmMaskKeyPressHandler" select="''"/>
    <xsl:param name="prmAlignment" select="@Attr.TextAlign" />

    <div style="display:table;width:100%;height:100%;position:relative;">
      <div>
        <xsl:attribute name="style">
          <xsl:text>display:table-cell;width:100%;height:100%;position:relative;</xsl:text>
          <xsl:choose>
            <xsl:when test="not($prmAlignment) or $prmAlignment=''">
              <xsl:text>vertical-align:middle;</xsl:text>
            </xsl:when>
            <xsl:otherwise>
              <xsl:call-template name="tplTextVerticalAlign">
                <xsl:with-param name="prmAlign" select="$prmAlignment"/>
              </xsl:call-template>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        <div class="{$prmContentContainerClass} {$prmInputContainerClass}" >
          <xsl:choose>
            <xsl:when test="@Attr.Style='S'">
              <xsl:attribute name="style">
                <xsl:text>height:</xsl:text>
                <xsl:value-of select="$prmInputHeight"/>px;
              </xsl:attribute>
            </xsl:when>
            <xsl:otherwise>
              <xsl:if test="not($prmAlignment) or $prmAlignment=''">
                <xsl:attribute name="style">
                  <xsl:text>height:100%</xsl:text>
                </xsl:attribute>
              </xsl:if>
            </xsl:otherwise>
          </xsl:choose>
          <input id="TRG_{$prmControlId}" type="text" data-vwgeditable="1">
            <xsl:apply-templates select="." mode="modApplyAttributes">
              <xsl:with-param name="prmControlId" select="$prmControlId"/>
              <xsl:with-param name="prmValue" select="$prmControlText"/>
              <xsl:with-param name="prmControlReadOnly" select="$prmControlReadOnly"/>

              <xsl:with-param name="prmMaskPasteHandler" select="$prmMaskPasteHandler"/>
              <xsl:with-param name="prmMaskKeyDownHandler" select="$prmMaskKeyDownHandler"/>
              <xsl:with-param name="prmMaskBlurHandler" select="$prmMaskBlurHandler"/>
              <xsl:with-param name="prmMaskFocusHandler" select="$prmMaskFocusHandler"/>
              <xsl:with-param name="prmMaskDragEnterHandler" select="$prmMaskDragEnterHandler"/>
              <xsl:with-param name="prmMaskKeyUpHandler" select="$prmMaskKeyUpHandler"/>
              <xsl:with-param name="prmMaskKeyPressHandler" select="$prmMaskKeyPressHandler"/>
            </xsl:apply-templates>
            <xsl:if test="$prmIsAutoComplete='0'">
              <xsl:attribute name="autocomplete">off</xsl:attribute>
            </xsl:if>
          <xsl:attribute name="class">
            <xsl:value-of select="$prmInputClass"/>
            <xsl:if test="$prmIsEnabled='0'"><xsl:value-of select="concat(' ',$prmInputClass,'_Disabled')"/></xsl:if>
          </xsl:attribute>
            <xsl:attribute name="style">
              <xsl:text>border:none;width:100%;height:100%;text-transform:</xsl:text>
              <xsl:choose>
                <xsl:when test="@Attr.CharacterCasing='1'">uppercase;</xsl:when>
                <xsl:when test="@Attr.CharacterCasing='2'">lowercase;</xsl:when>
                <xsl:otherwise>none;</xsl:otherwise>
              </xsl:choose>
              <xsl:if test="$prmAlignment and not($prmAlignment='')">
                <xsl:call-template name="tplTextHorizontalAlign">
                  <xsl:with-param name="prmAlign" select="$prmAlignment"/>
                </xsl:call-template>
              </xsl:if>
              <xsl:call-template name="tplApplyFontStyles"/>
            </xsl:attribute>
            <xsl:if test="$prmControlReadOnly">
              <xsl:call-template name="tplSetDisabled" >
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </xsl:if>
            <xsl:call-template name="tplSetFocusable" >
              <xsl:with-param name="prmHandler"  select="''"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
          </input>
          <xsl:call-template name="tplAddAccessibleNameLabel">
            <xsl:with-param name="prmId">TRG_<xsl:value-of select="$prmControlId" /></xsl:with-param>
          </xsl:call-template>
        </div>
      </div>
    </div>
  </xsl:template>

  <!-- Draws the combobox content -->
  <xsl:template name="tplDrawComboBoxContent">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmControlText" />
    <xsl:param name="prmControlReadOnly" />
    <xsl:param name="prmContentClass" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmDataContainerDropDownListMode" />
    <xsl:param name="prmInputHeight" />
    <xsl:param name="prmAlignment" select="@Attr.TextAlign" />

    <div>
      <xsl:attribute name="style">
        <xsl:text>width:100%;height:100%;position:relative;</xsl:text>
        <xsl:if test="$prmAlignment and not($prmAlignment='')">
          <xsl:text>display:table;</xsl:text>
        </xsl:if>
      </xsl:attribute>
      <div class="{$prmDataContainerDropDownListMode} {$prmContentClass}"
          onmousedown="if({number($prmControlReadOnly)}==0) mobjApp.ComboBox_ToggleDropDown('{$prmControlId}', window);"
          onkeydown="if({number($prmControlReadOnly)}==0) mobjApp.ComboBox_OnKeyDown('{$prmControlId}', '{@Attr.Style}','{@Attr.AutoCompleteMode}', this, window, event);">
        <xsl:call-template name="tplSetFocusable" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:attribute name="style">
          <xsl:text>width:100%;height:100%;</xsl:text>
          <xsl:choose>
            <xsl:when test="not($prmAlignment) or $prmAlignment=''">
              <xsl:text>vertical-align:middle;</xsl:text>
            </xsl:when>
            <xsl:otherwise>
              <xsl:text>display:table-cell;</xsl:text>
              <xsl:call-template name="tplTextVerticalAlign">
                <xsl:with-param name="prmAlign" select="$prmAlignment"/>
              </xsl:call-template>
              <xsl:call-template name="tplTextHorizontalAlign">
                <xsl:with-param name="prmAlign" select="$prmAlignment"/>
              </xsl:call-template>
            </xsl:otherwise>
          </xsl:choose>
          <xsl:call-template name="tplApplyFontStyles"/>
        </xsl:attribute>
        <span class="nobr" id="TRG_{$prmControlId}">
          <xsl:attribute name="style">
            line-height:<xsl:value-of select="$prmInputHeight"/>px;
          </xsl:attribute>
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText"  select="$prmControlText"/>
          </xsl:call-template>
        </span>
      </div>
    </div>
  </xsl:template>

  <!-- Draws the combobox listbox -->
  <xsl:template name="tplDrawComboBoxListBox">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmControl" />
    <xsl:param name="prmItemClass" />
    <xsl:param name="prmItemTableClass" />
    <xsl:param name="prmItemHeight" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmListBoxContainerClass" select="'ComboBox-ItemsContainer'" />

    <xsl:variable name="varShowColor" select="$prmControl/@Attr.ShowColor='1'" />
    <xsl:variable name="varShowImage" select="$prmControl/@Attr.ShowImage='1'" />
    <xsl:variable name="varColorIndex" select="number($varShowImage) * 2 + 1 " />
    <xsl:variable name="varTextIndex" select="(number($varShowImage) + number($varShowColor)) * 2" />
    <xsl:variable name="varRightToLeft" select="$prmControl/@Attr.RightToLeft" />
    <xsl:variable name="varControlReadOnly" select="$prmControl/@Attr.ReadOnly='1' or $prmIsEnabled='0'" />

    <div class="{$prmListBoxContainerClass}" style="width:100%;height:100%;overflow:hidden;">
      <div style="width:100%;height:100%;overflow:hidden;position:relative">
        <xsl:variable name="varRight">
          <xsl:call-template name="tplGetRightToLeftValue">
            <xsl:with-param name="prmRightToLeft" select="$varRightToLeft"/>
            <xsl:with-param name="prmNoValue" select="'right'" />
            <xsl:with-param name="prmYesValue" select="'left'" />
            <xsl:with-param name="prmDefaultValue" select="$right" />
          </xsl:call-template>
        </xsl:variable>
        <xsl:variable name="varDir">
          <xsl:call-template name="tplGetRightToLeftValue">
            <xsl:with-param name="prmRightToLeft" select="$varRightToLeft"/>
            <xsl:with-param name="prmNoValue" select="'LTR'" />
            <xsl:with-param name="prmYesValue" select="'RTL'" />
            <xsl:with-param name="prmDefaultValue" select="$dir" />
          </xsl:call-template>
        </xsl:variable>
        
        <xsl:variable name="varScrollbarSupport">
          <xsl:call-template name="tplSupportsMISCBrowserCapability">
            <xsl:with-param name="prmMISCBrowserCapability" select="512"/>
          </xsl:call-template>
        </xsl:variable>
        
        <table id="VWGVL_{$prmControlId}" class="Common-CellSpacing0 Common-CellPadding0 {$prmItemTableClass}" data-vwgvirtuallistelements="#tbody/*" style="height:100%; width:100%;"  onmousewheel="ComboBox_OnListNavigateWheel('{$prmControlId}', window, event, {$varControlReadOnly})">
          <xsl:attribute name="dir">
            <xsl:value-of select="$varDir"/>
          </xsl:attribute>
          <xsl:attribute name="data-vwgvirtuallist">
            <xsl:if test="$varShowImage">A:@<xsl:value-of select="'Attr.Image'" />:#tbody/*/1/0/@src,</xsl:if>
            <xsl:if test="$varShowColor">S:@<xsl:value-of select="'Attr.Color'" />:#tbody/*/<xsl:value-of select="$varColorIndex" />/0/style,</xsl:if>
            T:@<xsl:value-of select="'Attr.Text'" />:#tbody/*/<xsl:value-of select="$varTextIndex" />/0/0,
              A:@<xsl:value-of select="'Attr.Index'" />:#tbody/*/@data-vwgindex,
              A:@<xsl:value-of select="'Attr.Index'" />:#tbody/*/<xsl:value-of select="$varTextIndex" />/0/@data-vwgindex
          </xsl:attribute>
            <colgroup>
            <xsl:if test="$varShowImage">
              <col style="width:2px"/>
              <col id="ImageBoxColumn"/>
            </xsl:if>
            <xsl:if test="$varShowColor">
              <col style="width:2px"/>
              <col id="ColorBoxColumn"/>
            </xsl:if>
            <col />
            </colgroup>
            <tbody>
              <xsl:call-template name="tplDrawComboBoxListBoxItems">
                <xsl:with-param name="prmIndex" select="number($prmControl/@Attr.Maximum)"/>
                <xsl:with-param name="prmControl"  select="$prmControl"/>
                <xsl:with-param name="prmControlId"  select="$prmControlId"/>
                <xsl:with-param name="prmShowImage" select="$varShowImage"/>
                <xsl:with-param name="prmShowColor" select="$varShowColor"/>
                <xsl:with-param name="prmItemClass" select="$prmItemClass" />
                <xsl:with-param name="prmItemHeight" select="$prmItemHeight" />
            </xsl:call-template>
          </tbody>
		</table>
        <div id="VWGVLSC_{$prmControlId}" data-scrollable="yes" onmousedown="mobjApp.Controls_Focus('{$prmControlId}',true,window);" onscroll="mobjApp.ComboBox_OnScroll(this,'{$prmControlId}',window)">
          <xsl:attribute name="style" >
            <xsl:value-of select="$varRight" />:0px;visibility:hidden;position:absolute;top:0px;height:100%;width:<xsl:choose>
              <!-- Scroller takes the whole content when no scrollbars support -->
              <xsl:when test="$varScrollbarSupport='false'">100%;overflow-y:none</xsl:when>
              <xsl:otherwise>
                <xsl:choose>
                  <xsl:when test="$varBrowserObsoleteIE='1'">35px</xsl:when>
                  <xsl:otherwise>20px</xsl:otherwise>
                </xsl:choose>;overflow-y:auto
              </xsl:otherwise>
            </xsl:choose>;box-sizing:content-box;

			</xsl:attribute>
			<xsl:attribute name="dir">
			<xsl:value-of select="$varDir"/>
			</xsl:attribute>
        <div style="top:0px;height:0px;">
          </div>
        </div>
      </div>
    </div>
  </xsl:template>

  <!-- Draws the combobox listbox items -->
  <xsl:template name="tplDrawComboBoxListBoxItems">
    <xsl:param name="prmIndex"/>
    <xsl:param name="prmControl"/>
    <xsl:param name="prmControlId" />
    <xsl:param name="prmShowColor"/>
    <xsl:param name="prmShowImage"/>
    <xsl:param name="prmItemClass" />
    <xsl:param name="prmItemHeight" />
    
    <tr class="Common-HandCursor {$prmItemClass}" style="height:{$prmItemHeight}px" onclick="mobjApp.ComboBox_OnItemClick('{$prmControlId}', mobjApp.Web_GetAttribute(this,'vwgindex'),'{$prmControl/@Attr.Style}', window, event);" oncontextmenu="mobjApp.Controls_Focus('{$prmControlId}');">
      <!--Registers an item "Enter" event-->
      <xsl:call-template name="tplRegisterComboBoxItemEnterEvent">
        <xsl:with-param name="prmControl" select="$prmControl"/>
        <xsl:with-param name="prmControlId" select="$prmControlId"/>
      </xsl:call-template>
      <xsl:if test="$prmShowImage">
        <td>
          <xsl:call-template name="tplDrawEmptyImage">
            <xsl:with-param name="prmPositionStyle"  select="'absolute'" />
          </xsl:call-template>
        </td>
        <td>
          <img style="display: block;" id="ImageBox" class="ComboBox-Box" alt=""/>
        </td>
      </xsl:if>
      <xsl:if test="$prmShowColor">
        <td>
          <xsl:call-template name="tplDrawEmptyImage">
            <xsl:with-param name="prmPositionStyle"  select="'absolute'" />
          </xsl:call-template>
        </td>
        <td >
          <div id="ColorBox" class="ComboBox-Box">&#160;</div>
        </td>
      </xsl:if>
      <td>
        <div class="LabelBox">
          <xsl:variable name="varAlign">
            <xsl:call-template name="tplGetRightToLeftValue">
              <xsl:with-param name="prmRightToLeft" select="$prmControl/@Attr.RightToLeft"/>
              <xsl:with-param name="prmNoValue" select="'left'" />
              <xsl:with-param name="prmYesValue" select="'right'" />
              <xsl:with-param name="prmDefaultValue" select="$left" />
            </xsl:call-template>
          </xsl:variable>
          <xsl:attribute name="style">
            padding:0px 3px 0px 3px;
            text-align:<xsl:value-of select="$varAlign"/>;
            <xsl:call-template name="tplApplyFontStyles">
              <xsl:with-param name="prmTarget" select="$prmControl"/>
            </xsl:call-template>
          </xsl:attribute>
          <span class="nobr">&#160;</span>
        </div>
      </td>
    </tr>
    <xsl:if test="$prmIndex &gt; 1">
      <xsl:call-template name="tplDrawComboBoxListBoxItems">
        <xsl:with-param name="prmIndex" select="number($prmIndex)-1"/>
        <xsl:with-param name="prmControl"  select="$prmControl"/>
        <xsl:with-param name="prmControlId"  select="$prmControlId"/>
        <xsl:with-param name="prmShowColor" select="$prmShowColor"/>
        <xsl:with-param name="prmShowImage" select="$prmShowImage"/>
        <xsl:with-param name="prmItemClass" select="$prmItemClass" />
        <xsl:with-param name="prmItemHeight" select="$prmItemHeight" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
