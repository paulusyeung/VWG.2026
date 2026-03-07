<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"	xmlns:WC="wgcontrols">

  <!-- The default style single-line TextBox match template -->
  <xsl:template match="WC:Tags.TextBox[not(@Attr.Multiline) and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawSingleLineTextBoxAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- The Main API for drawing the single-line TextBox control -->
  <xsl:template name="tplDrawSingleLineTextBoxAPI">
    <xsl:param name="prmAttachTextBoxSelectionEvents" select="1" />
    <xsl:param name="prmControlClass" select="'TextBox-Control'"/>
    <xsl:param name="prmTextClass" select="'TextBox-Text'"/>
    <xsl:param name="prmSingleLineClass" select="'TextBox-SingleLine'"/>
    <xsl:param name="prmId" select="@Attr.Id" />
    <xsl:param name="prmIsAutoComplete" select="@Attr.IsAutoComplete" />
    <xsl:param name="prmValue" select="@Attr.Value"/>
    <xsl:param name="prmInputType">
      <xsl:choose>
        <xsl:when test="@Attr.Password='1'">password</xsl:when>
        <xsl:otherwise>text</xsl:otherwise>
      </xsl:choose>
    </xsl:param>
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.TextBox_KeyDown(&quot;',$prmId,'&quot;,window,event,this);')"/>
    <xsl:param name="prmKeyPressHandler" select="concat('mobjApp.TextBox_KeyPress(&quot;',$prmId,'&quot;,&quot;',@Attr.CharacterValidationMask,'&quot;,&quot;',@Attr.CharacterValidationExpression,'&quot;,window,this,event);')"/>
    <xsl:param name="prmBlurHandler" select="concat('mobjApp.TextBox_Blur(&quot;',$prmId,'&quot;,this,window);')"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmKeyUpHandler" >
      <xsl:choose>
        <xsl:when test="@Attr.TextBoxRealTimeKeyboardEvents='1'">
          <xsl:value-of select="concat('mobjApp.TextBox_KeyUp(&quot;',$prmId,'&quot;,window,event,this);')" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="''" />
        </xsl:otherwise>
      </xsl:choose>
   </xsl:param>
    
    <xsl:param name="prmFocusHandler" select="''"/>
    <xsl:param name="prmPasteHandler" select="concat('mobjApp.TextBox_OnPaste(this,&quot;',$prmId,'&quot;, false);')"/>

    <xsl:param name="prmMaskPasteHandler" select="'mobjApp.Common_MaskOnPaste(this);'"/>
    <xsl:param name="prmMaskKeyDownHandler" select="concat('mobjApp.Common_MaskKeyDown(this,event,&quot;',$prmId,'&quot;,window);')"/>
    <xsl:param name="prmMaskBlurHandler" select="concat('mobjApp.Common_MaskBlur(&quot;',$prmId,'&quot;,this,event,window);')"/>
    <xsl:param name="prmMaskFocusHandler" select="concat('mobjApp.Common_MaskFocus(this,event,&quot;',$prmId,'&quot;);')"/>
    <xsl:param name="prmMaskDragEnterHandler" select="'return false;'"/>
    <xsl:param name="prmMaskKeyUpHandler">
      <xsl:choose>
        <xsl:when test="@Attr.TextBoxRealTimeKeyboardEvents='1'">
          <xsl:value-of select="concat('mobjApp.TextBox_KeyUp(&quot;',$prmId,'&quot;,window,event,this);')" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="''" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:param> 
    <xsl:param name="prmMaskKeyPressHandler" select="$prmKeyPressHandler"/>
    <xsl:param name="prmAccessibleName" select="''" />
    
    <xsl:attribute name="class">
      <xsl:value-of select="concat('TextBox-TableContainer ',$prmControlClass)"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:call-template name="tplApplyTransperentLayout" >
      <xsl:with-param name="prmIsStyle" select="0" />
    </xsl:call-template>
    <input tabindex="-1" id="TRG_{$prmId}" data-vwgeditable="1" data-vwgfocuselement="1">
      <xsl:if test="@Attr.MaxLength &gt; 0">
        <xsl:attribute name="maxlength">
          <xsl:value-of select="@Attr.MaxLength" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmIsAutoComplete='0'">
        <xsl:attribute name="autocomplete">off</xsl:attribute>
      </xsl:if>
      <xsl:attribute name="class">
        <xsl:value-of select="concat('TextBox-Input ', $prmSingleLineClass,' ', $prmTextClass)"/>
        <xsl:if test="$prmIsEnabled='0'"> TextBox-Input_Disabled</xsl:if>
      </xsl:attribute>
      <xsl:attribute name="dir">
        <xsl:call-template name="tplGetRightToLeftValue">
          <xsl:with-param name="prmNoValue" select="'LTR'" />
          <xsl:with-param name="prmYesValue" select="'RTL'" />
          <xsl:with-param name="prmDefaultValue" select="$dir" />
        </xsl:call-template>
      </xsl:attribute>
      <xsl:call-template name="tplSetDisabled" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:attribute name="style">
        <xsl:call-template name="tplTextBoxStyle">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:attribute>
      <xsl:if test="@Attr.ReadOnly='1'"><xsl:attribute name="readonly">readonly</xsl:attribute></xsl:if>
      <xsl:choose>
        <xsl:when test="@Attr.Mask">
          <xsl:call-template name="tplApplyMaskCapabilities">
            <xsl:with-param name="prmId" select="$prmId" />
            <xsl:with-param name="prmValue" select="$prmValue"/>
            <xsl:with-param name="prmOnPasteHandler" select="$prmMaskPasteHandler"/>
            <xsl:with-param name="prmOnKeyDownHandler" select="$prmMaskKeyDownHandler"/>
            <xsl:with-param name="prmOnBlurHandler"  select="$prmMaskBlurHandler"/>
            <xsl:with-param name="prmOnFocusHandler" select="$prmMaskFocusHandler"/>
            <xsl:with-param name="prmOnKeyUpHandler" select="$prmMaskKeyUpHandler"/>
            <xsl:with-param name="prmOnKeyPressHandler" select="$prmMaskKeyPressHandler"/>
          </xsl:call-template>
        </xsl:when>
        <xsl:otherwise>
          <xsl:attribute name="value">
            <xsl:call-template name="tplDecodeText">
              <xsl:with-param name="prmText" select="$prmValue"/>
            </xsl:call-template>
          </xsl:attribute>
          <xsl:if test="$prmKeyDownHandler!=''">
            <xsl:attribute name="onkeydown">
              <xsl:value-of select="$prmKeyDownHandler"/>
            </xsl:attribute>
          </xsl:if>
          <xsl:if test="$prmBlurHandler!=''">
            <xsl:call-template name="tplResgisterLostFocusEvent">
              <xsl:with-param name="prmHandler">
                <xsl:value-of select="$prmBlurHandler"/>
              </xsl:with-param>
            </xsl:call-template>
          </xsl:if>
          <xsl:if test="$prmKeyPressHandler!=''">
            <xsl:attribute name="onkeypress">
              <xsl:value-of select="$prmKeyPressHandler"/>
            </xsl:attribute>
          </xsl:if>
          <xsl:if test="$prmPasteHandler!=''">
            <xsl:attribute name="onpaste">
              <xsl:value-of select="$prmPasteHandler"/>
            </xsl:attribute>
          </xsl:if>
          <xsl:attribute name="type">
            <xsl:value-of select="$prmInputType"/>
          </xsl:attribute>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:if test="$prmKeyUpHandler!=''">
        <xsl:attribute name="onkeyup">
          <xsl:value-of select="$prmKeyUpHandler"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmFocusHandler!=''">
        <xsl:attribute name="onfocus">
          <xsl:value-of select="$prmFocusHandler"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates select="." mode="modCustomAttributes">
        <xsl:with-param name="prmId" select="$prmId" />
      </xsl:apply-templates>
      <xsl:if test="$prmAttachTextBoxSelectionEvents='1'">
        <xsl:call-template name="tplAttachTextBoxSelectionEvents">
          <xsl:with-param name="prmId" select="$prmId" />
        </xsl:call-template>
      </xsl:if>
    </input>
    <xsl:choose>
      <xsl:when test="$prmAccessibleName=''">
        <xsl:call-template name="tplAddAccessibleNameLabel">
          <xsl:with-param name="prmId">TRG_<xsl:value-of select="$prmId"/></xsl:with-param>
        </xsl:call-template>        
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplAddAccessibleNameLabel">
          <xsl:with-param name="prmId">TRG_<xsl:value-of select="$prmId"/></xsl:with-param>
          <xsl:with-param name="prmText"><xsl:value-of select="$prmAccessibleName"/></xsl:with-param>
        </xsl:call-template>        
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!-- The default style Multiline TextBox match template -->
  <xsl:template match="WC:Tags.TextBox[@Attr.Multiline and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawMultilineTextBoxAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <!-- The Main API for drawing the Multiline TextBox control -->
  <xsl:template name="tplDrawMultilineTextBoxAPI">
    <xsl:param name="prmId" select="@Id" />
    <xsl:param name="prmAttachTextBoxSelectionEvents" select="1" />
    <xsl:param name="prmSupportTextAreaNullableValue" select="1" />
    <xsl:param name="prmControlClass" select="'TextBox-Control'"/>
    <xsl:param name="prmTextClass" select="'TextBox-Text'" />
    <xsl:param name="prmMultiLineClass" select="'TextBox-MultiLine'"/>
    <xsl:param name="prmWordWrap" select="@Attr.WordWrap"/>
    <xsl:param name="prmText" select="@Attr.Value"/>
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.TextBox_KeyDown(&quot;',$prmId,'&quot;,window,event,this);')"/>
    <xsl:param name="prmKeyPressWithoutMaxLengthHandler" select="concat('mobjApp.TextBox_KeyPress(&quot;',$prmId,'&quot;,&quot;',@Attr.CharacterValidationMask,'&quot;,&quot;',@Attr.CharacterValidationExpression,'&quot;,window,this,event);')"/>
    <xsl:param name="prmKeyPressWithMaxLengthHandler" select="concat('mobjApp.TextBox_KeyPressMultiLine(&quot;',$prmId,'&quot;,this,event,window);')"/>
    <xsl:param name="prmBlurHandler" select="concat('mobjApp.TextBox_Blur(&quot;',$prmId,'&quot;,this,window);')"/>
    <xsl:param name="prmPasteHandler" select="concat('mobjApp.TextBox_OnPaste(this,&quot;',$prmId,'&quot;, true);')"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmKeyUpHandler" >
      <xsl:choose>
        <xsl:when test="@Attr.TextBoxRealTimeKeyboardEvents='1'">
          <xsl:value-of select="concat('mobjApp.TextBox_KeyUp(&quot;',$prmId,'&quot;,window,event,this);')" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="''" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:param>
    <xsl:param name="prmFocusHandler" select="''"/>
    <xsl:param name="prmAccessibleName" select="''" />

    <!-- Set the Class attribute -->
    <xsl:attribute name="class">
      <xsl:value-of select="concat('TextBox-TableContainer ',$prmControlClass)"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <!-- Render transparency -->
    <xsl:call-template name="tplApplyTransperentLayout" >
      <xsl:with-param name="prmIsStyle" select="0" />
    </xsl:call-template>

    <!-- Render the Multiline TextBox control -->

    <textarea id="TRG_{$prmId}" tabindex="-1" data-vwgentersupported="1" data-vwgeditable="1" data-vwgfocuselement="1">
      <xsl:attribute name="class">
        <xsl:value-of select="concat('TextBox-Input ', $prmMultiLineClass,' ', $prmTextClass)"/>
        <xsl:if test="$prmIsEnabled='0'"> TextBox-Input_Disabled</xsl:if>
      </xsl:attribute>
      <xsl:attribute name="dir">
        <xsl:call-template name="tplGetRightToLeftValue">
          <xsl:with-param name="prmNoValue" select="'LTR'" />
          <xsl:with-param name="prmYesValue" select="'RTL'" />
          <xsl:with-param name="prmDefaultValue" select="$dir" />
        </xsl:call-template>
      </xsl:attribute>
      <xsl:if test="$prmBlurHandler!=''">
        <xsl:call-template name="tplResgisterLostFocusEvent">
          <xsl:with-param name="prmHandler">
            <xsl:value-of select="$prmBlurHandler"/>
          </xsl:with-param>
        </xsl:call-template>
      </xsl:if>
      <xsl:if test="$prmKeyDownHandler!=''">
        <xsl:attribute name="onkeydown">
          <xsl:value-of select="$prmKeyDownHandler"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmKeyUpHandler!=''">
        <xsl:attribute name="onkeyup">
          <xsl:value-of select="$prmKeyUpHandler"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmFocusHandler!=''">
        <xsl:attribute name="onfocus">
          <xsl:value-of select="$prmFocusHandler"/>
        </xsl:attribute>
      </xsl:if>
        <xsl:if test="$prmPasteHandler!=''">
          <xsl:attribute name="onpaste">
            <xsl:value-of select="$prmPasteHandler"/>
          </xsl:attribute>
        <xsl:if test="$prmKeyPressWithMaxLengthHandler!=''">
          <xsl:attribute name="onkeypress">
            <xsl:value-of select="$prmKeyPressWithMaxLengthHandler"/>
          </xsl:attribute>
        </xsl:if>
      </xsl:if>
      <xsl:if test="not(@Attr.MaxLength)">
        <xsl:if test="$prmKeyPressWithoutMaxLengthHandler!=''">
          <xsl:attribute name="onkeypress">
            <xsl:value-of select="$prmKeyPressWithoutMaxLengthHandler"/>
          </xsl:attribute>
        </xsl:if>
      </xsl:if>
      <xsl:if test="$prmWordWrap='0'">
        <xsl:attribute name="Wrap">soft</xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmAttachTextBoxSelectionEvents='1'">
        <xsl:call-template name="tplAttachTextBoxSelectionEvents">
          <xsl:with-param name="prmId" select="$prmId" />
              </xsl:call-template>
            </xsl:if>
            <xsl:call-template name="tplSetDisabled" >
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
            <xsl:attribute name="style"><xsl:call-template name="tplTextBoxStyle">
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template></xsl:attribute>
            <xsl:if test="@Attr.ReadOnly='1'"><xsl:attribute name="readonly">readonly</xsl:attribute></xsl:if>

            <xsl:apply-templates select="." mode="modCustomAttributes">
              <xsl:with-param name="prmId" select="$prmId" />
            </xsl:apply-templates>

            <xsl:choose>
              <xsl:when test="$prmSupportTextAreaNullableValue='1'">
                <xsl:call-template name="tplSetTextAreaNullableValue">
            <xsl:with-param name="prmText" select="$prmText"/>
          </xsl:call-template>
        </xsl:when>
        <xsl:otherwise>
          <xsl:call-template name="tplSetTextAreaValue">
            <xsl:with-param name="prmText" select="$prmText"/>
          </xsl:call-template>
        </xsl:otherwise>
      </xsl:choose>
    </textarea>
    <xsl:choose>
      <xsl:when test="$prmAccessibleName=''">
        <xsl:call-template name="tplAddAccessibleNameLabel">
          <xsl:with-param name="prmId">TRG_<xsl:value-of select="$prmId"/></xsl:with-param>
        </xsl:call-template>        
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplAddAccessibleNameLabel">
          <xsl:with-param name="prmId">TRG_<xsl:value-of select="$prmId"/></xsl:with-param>
          <xsl:with-param name="prmText"><xsl:value-of select="$prmAccessibleName"/></xsl:with-param>
        </xsl:call-template>        
      </xsl:otherwise>
    </xsl:choose>
    <xsl:if test="$prmSupportTextAreaNullableValue='1'">
      <xsl:call-template name="tplUpdateTextAreaNullableValue">
        <xsl:with-param name="prmText" select="$prmText"/>
      </xsl:call-template>
    </xsl:if>

  </xsl:template>

  <xsl:template name="tplTextBoxStyle">
    <xsl:param name="prmIsEnabled" />
    <xsl:if test="(@Attr.ReadOnly='1' and not(@Attr.Background)) or $prmIsEnabled='0'">
      <xsl:if test="@Attr.GrayedReadOnlyTextBox='1'">background:#EEEEEE;</xsl:if>
    </xsl:if>
    text-transform:
    <xsl:choose>
      <xsl:when test="@Attr.CharacterCasing='1'">uppercase;</xsl:when>
      <xsl:when test="@Attr.CharacterCasing='2'">lowercase;</xsl:when>
      <xsl:otherwise>none;</xsl:otherwise>
    </xsl:choose>
    <xsl:variable name="varForeColor" select="@Attr.Fore"/>
    <xsl:call-template name="tplApplyFontStyles">
      <xsl:with-param name="prmForeColor">
        <xsl:choose>
          <xsl:when test="@Attr.ReadOnly='1' and not($varForeColor) and not(@Attr.GrayedReadOnlyTextBox='1')">gray</xsl:when>
          <xsl:otherwise><xsl:value-of select="$varForeColor"/></xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
    </xsl:call-template>
    <xsl:call-template name="tplApplyTransperentLayout" >
      <xsl:with-param name="prmIsStyle" select="1" />
    </xsl:call-template>

    <xsl:choose>
      <!--Horizontal-->
      <xsl:when test="@Attr.Scrollbars='1'">overflow-x:scroll; overflow-y:hidden;</xsl:when>
      <!--Vertical-->
      <xsl:when test="@Attr.Scrollbars='2'">overflow-x:hidden; overflow-y:scroll;</xsl:when>
      <!--Both-->
      <xsl:when test="@Attr.Scrollbars='3'">overflow:scroll; overflow-x:scroll; overflow-y:scroll;</xsl:when>

      <!--None-->
      <xsl:otherwise>overflow-x:hidden; overflow-y:hidden;</xsl:otherwise>
    </xsl:choose>

    <xsl:call-template name="tplTextHorizontalAlign">
      <xsl:with-param name="prmAlign" select="@Attr.TextAlign"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplAttachTextBoxSelectionEvents">
    <xsl:param name="prmId" select="@Attr.Id" />
    
    <xsl:attribute name="onselect">mobjApp.Events_TextSelectionChanged('<xsl:value-of select="$prmId"/>',this);</xsl:attribute>
  </xsl:template>
  
</xsl:stylesheet>
