<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <!-- The default style DateTimePicker match template -->
  <xsl:template match="WC:Tags.DateTimePicker" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawDateTimePickerAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawDateTimePickerAPI">
    <xsl:param name="prmControlClass" select="'DateTimePicker-Control'"/>
    <xsl:param name="prmInputClass" select="'DateTimePicker-InputValue'"/>
    <xsl:param name="prmCheckBoxIconContainerWidth" select="'[Skin.CheckBoxIconContainerWidth]'"/>
    <xsl:param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
    <xsl:param name="prmUnCheckedCheckBoxImage" select="'[Skin.UnCheckedCheckBoxImage]'"/>
    <xsl:param name="prmDropDownIconClass" select="'DateTimePicker-DropDownIcon'"/>
    <xsl:param name="prmDownIconClass" select="'DateTimePicker-UpDownDownIcon'"/>
    <xsl:param name="prmUpIconClass" select="'DateTimePicker-UpDownUpIcon'"/>
    <xsl:param name="prmDropDownIconContainerWidth" select="'[Skin.DropDownIconContainerWidth]'"/>
    <xsl:param name="prmUpDownIconContainerWidth" select="'[Skin.UpDownIconContainerWidth]'"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmButtonContainerClass" select="'DateTimePicker-ButtonContainer'" />
    
    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <table id="TRG_{@Attr.Id}" dir="{$dir}" class="Common-CellPadding0 Common-CellSpacing0 DateTimePicker-Table">
      <!--Check if no focusable elements exists-->
      <xsl:if test="@Attr.CheckBoxes='0' and count(Tags.Token[not(@Attr.ReadOnly='1')])=0">
        <xsl:call-template name="tplSetFocusable">
          <xsl:with-param name="prmHandler" select="''"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:if>
      <tr>
        <td class="Common-VAlignMiddle" style="padding-{$left}:2px;padding-{$right}:3px;">
          <div style="width:100%;height:100%;overflow:hidden;">
            <table class="Common-CellPadding0 Common-CellSpacing0 DateTimePicker-Layout" dir="LTR" >
              <tr>
                <xsl:if test="@Attr.CheckBoxes='1' and $dir='LTR'">
                  <td style="width:{$prmCheckBoxIconContainerWidth}px">
                    <xsl:if test="@Attr.Checked='1'">
                      <div class="Common-VAlignMiddle DateTimePicker-CheckBoxIconSize"  id="VWG{@Attr.Id}_CB" onkeydown="mobjApp.DateTimePicker_CheckBoxKeyDown(window,event,'{@Attr.Id}',this)" data-guichecked="{@Attr.Checked}" onclick="mobjApp.DateTimePicker_CheckChange(window,'{@Id}',this)" onfocus="Web_SetStyle(this,'focus',window)" onblur="Web_SetStyle(this,'',window)">
                        <xsl:attribute name="style">
                          <xsl:call-template name="tplDrawBackground">
                            <xsl:with-param name="prmImage"  select="$prmCheckedCheckBoxImage" />
                            <xsl:with-param name="prmImageAlign" select="'Center'" />
                          </xsl:call-template>
                        </xsl:attribute>
                        <xsl:call-template name="tplSetFocusable">
                          <xsl:with-param name="prmHandler" select="'mobjApp.DateTimePicker_OnCheckBoxFocus'"/>
                          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        </xsl:call-template>
                      </div>
                    </xsl:if>
                    <xsl:if test="not(@Attr.Checked='1')">
                      <div class="Common-VAlignMiddle DateTimePicker-CheckBoxIconSize" id="VWG{@Attr.Id}_CB" onkeydown="mobjApp.DateTimePicker_CheckBoxKeyDown(window,event,'{@Attr.Id}',this)" data-guichecked="{@Attr.Checked}" onclick="mobjApp.DateTimePicker_CheckChange(window,'{@Id}',this)" onfocus="Web_SetStyle(this,'focus',window)" onblur="Web_SetStyle(this,'',window)">
                        <xsl:attribute name="style">
                          <xsl:call-template name="tplDrawBackground">
                            <xsl:with-param name="prmImage"  select="$prmUnCheckedCheckBoxImage" />
                            <xsl:with-param name="prmImageAlign" select="'Center'" />
                          </xsl:call-template>
                        </xsl:attribute>
                        <xsl:call-template name="tplSetFocusable">
                          <xsl:with-param name="prmHandler" select="''"/>
                          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        </xsl:call-template>
                      </div>
                    </xsl:if>
                  </td>
                </xsl:if>
                <xsl:for-each select="Tags.Token|Tags.Literal">
                  <td class="nobr Common-AlignCenter Common-VAlignMiddle">
                    <!--Check if curretn token / literal is read only.-->
                    <xsl:variable name="varIsReadOnly" select="@Attr.ReadOnly='1' or $prmIsEnabled='0' or (../@Attr.CheckBoxes='1' and ../@Attr.Checked='0')"/>

                  <!--The numeric part of the date phrase-->
                  <xsl:if test="name()='Tags.Token'">
                    <input id="VWG{../@Attr.Id}_{position()}" type="text" data-vwgeditable="1" value="{@Attr.Value}">
                      <xsl:attribute name="class">Common-FontData<xsl:if test="$varIsReadOnly"> Common-Unselectable Common-DefaultCursor</xsl:if><xsl:value-of select="concat(' ',$prmInputClass)"/></xsl:attribute>
                      <xsl:attribute name="style">
                        width:<xsl:value-of select="@Attr.Size"/>px;display:block;margin:0px;padding:0px;clear:both;position:static;text-align:center; text-shadow:inherit;
                        <xsl:call-template name="tplApplyFontStyles">
                          <xsl:with-param name="prmTarget" select="../."/>
                        </xsl:call-template>
                      </xsl:attribute>
                      <xsl:attribute name="onfocus">mobjApp.DateTimePicker_OnFocus('<xsl:value-of select="../@Id" />','<xsl:value-of select="position()" />',this,window);</xsl:attribute>
                      <xsl:if test="not(@Attr.ReadOnly='1')">
                        <xsl:attribute name="data-vwgposition"><xsl:value-of select="position()"/></xsl:attribute>
                        <xsl:attribute name="onkeydown">mobjApp.DateTimePicker_OnKeyDown('<xsl:value-of select="../@Id" />',this,window,event);</xsl:attribute>
                        <xsl:attribute name="onblur">mobjApp.DateTimePicker_OnTokenBlur('<xsl:value-of select="../@Id" />','<xsl:value-of select="position()" />',this,window);</xsl:attribute>
                        <xsl:attribute name="onclick">mobjApp.DateTimePicker_OnClick(window,this,'<xsl:value-of select="../@Id" />','<xsl:value-of select="position()" />');</xsl:attribute>
                        <xsl:attribute name="onmouseup">mobjApp.DateTimePicker_OnMouseup(event);</xsl:attribute>

                        <!--Confirm that check box is hidden and that no previous editable tokens drawn-->
                        <xsl:if test="../@Attr.CheckBoxes='0' and count(preceding-sibling::Tags.Token[not(@Attr.ReadOnly='1')])=0">
                            <xsl:call-template name="tplSetFocusable">
                              <xsl:with-param name="prmHandler" select="''"/>
                              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                            </xsl:call-template>
                          </xsl:if>
                        </xsl:if>
                        <xsl:if test="$varIsReadOnly">
                          <xsl:if test="$prmIsEnabled='0' or (../@Attr.CheckBoxes='1' and ../@Attr.Checked='0')">
                            <xsl:attribute name="disabled">disabled</xsl:attribute>
                          </xsl:if>
                        </xsl:if>
                        <xsl:if test="$varIsReadOnly">
                          <xsl:attribute name="readonly">readonly</xsl:attribute>
                          <xsl:attribute name="oncontextmenu">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
                          <xsl:attribute name="onselectstart">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
                        </xsl:if>
                      </input>
                    <xsl:call-template name="tplAddAccessibleNameLabel">
                      <xsl:with-param name="prmId">VWG<xsl:value-of select="../@Attr.Id"/>_<xsl:value-of select="position()"/></xsl:with-param>
                      <xsl:with-param name="prmText">Labels.DateInput</xsl:with-param>
                    </xsl:call-template>
                    </xsl:if>

                    <!--The colon sign between each number(19:15)-->
                  <xsl:if test="name()='Tags.Literal'">
                    <input id="VWG{../@Attr.Id}_{position()}" style="text-align:center;"  class="Common-FontData Common-Unselectable Common-DefaultCursor {$prmInputClass}" type="text" value="{@Attr.Value}">
                      <xsl:attribute name="onfocus">mobjApp.DateTimePicker_OnFocus('<xsl:value-of select="../@Id" />','<xsl:value-of select="position()" />',this,window);</xsl:attribute>
                      <xsl:if test="$prmIsEnabled='0' or (../@Attr.CheckBoxes='1' and ../@Attr.Checked='0')">
                        <xsl:attribute name="disabled">disabled</xsl:attribute>
                      </xsl:if>
                      <xsl:attribute name="readonly">readonly</xsl:attribute>
                        <xsl:attribute name="oncontextmenu">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
                        <xsl:attribute name="onselectstart">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
                        <xsl:attribute name="style">
                          width:<xsl:value-of select="@Attr.Size"/>px;display:block;clear:both;padding:0px;text-align:center;
                          <xsl:call-template name="tplApplyFontStyles">
                            <xsl:with-param name="prmTarget" select="./.."/>
                          </xsl:call-template>
                        </xsl:attribute>
                      </input>
                      <xsl:call-template name="tplAddAccessibleNameLabel">
                        <xsl:with-param name="prmId">VWG<xsl:value-of select="../@Attr.Id"/>_<xsl:value-of select="position()"/></xsl:with-param>
                        <xsl:with-param name="prmText">Labels.DateInput</xsl:with-param>
                      </xsl:call-template>
                  </xsl:if>
                  </td>
                </xsl:for-each>
                <xsl:if test="@Attr.CheckBoxes='1' and $dir='RTL'">
                  <td style="width:{$prmCheckBoxIconContainerWidth}px">
                    <xsl:if test="@Attr.Checked='1'">
                      <div class="Common-VAlignMiddle DateTimePicker-CheckBoxIconSize" id="VWG{@Attr.Id}_CB" onkeydown="mobjApp.DateTimePicker_CheckBoxKeyDown(window,event,'{@Attr.Id}',this)" data-guichecked="{@Attr.Checked}" onclick="mobjApp.DateTimePicker_CheckChange(window,'{@Id}',this)" onfocus="Web_SetStyle(this,'focus',window)" onblur="Web_SetStyle(this,'',window)">
                        <xsl:attribute name="style">
                          display: block;
                          <xsl:call-template name="tplDrawBackground">
                            <xsl:with-param name="prmImage"  select="$prmCheckedCheckBoxImage" />
                            <xsl:with-param name="prmImageAlign" select="'Center'" />
                          </xsl:call-template>
                        </xsl:attribute>
                        <xsl:call-template name="tplSetFocusable">
                          <xsl:with-param name="prmHandler" select="''"/>
                          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        </xsl:call-template>
                      </div>
                    </xsl:if>
                    <xsl:if test="not(@Attr.Checked='1')">
                      <div class="Common-VAlignMiddle DateTimePicker-CheckBoxIconSize" id="VWG{@Attr.Id}_CB" onkeydown="mobjApp.DateTimePicker_CheckBoxKeyDown(window,event,'{@Attr.Id}',this)" data-guichecked="{@Attr.Checked}" onclick="mobjApp.DateTimePicker_CheckChange(window,'{@Id}',this)" onfocus="Web_SetStyle(this,'focus',window)" onblur="Web_SetStyle(this,'',window)">
                        <xsl:attribute name="style">
                          display: block;
                          <xsl:call-template name="tplDrawBackground">
                            <xsl:with-param name="prmImage"  select="$prmUnCheckedCheckBoxImage" />
                            <xsl:with-param name="prmImageAlign" select="'Center'" />
                          </xsl:call-template>
                        </xsl:attribute>
                        <xsl:call-template name="tplSetFocusable">
                          <xsl:with-param name="prmHandler" select="''"/>
                          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                        </xsl:call-template>
                      </div>
                    </xsl:if>
                  </td>
                </xsl:if>
              </tr>
            </table>
          </div>
        </td>
        <td style="width:1px;"></td>
        <xsl:if test="@Attr.ShowUpDown='1' or @Attr.ShowUpDown='2'">
          <td class="Common-AlignCenter {$prmButtonContainerClass}">
            <xsl:call-template name="tplSetHighlight" >
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
            <xsl:attribute name="style">
              <xsl:text>direction:ltr;width:</xsl:text>
              <xsl:value-of select="$prmUpDownIconContainerWidth"/>
              <xsl:text>px;height:100%;</xsl:text>
            </xsl:attribute>
            <table class="Common-Strech Common-CellPadding0 Common-CellSpacing1">
              <colgroup>
                <col style="width:100%"/>
              </colgroup>
              <tr height="50%">
                <td class="{$prmUpIconClass}" style="background-position:top;background-repeat:no-repeat;">
                  <xsl:if test="not($prmIsEnabled='0')">
                    <xsl:call-template name="tplSetMouseEvents">
                      <xsl:with-param name="prmHandler" select="'mobjApp.DateTimePicker_HandleUpButtonMouseEvents'"/>
                    </xsl:call-template>
                  </xsl:if>
                </td>
              </tr>
              <tr height="50%">
                <td class="{$prmDownIconClass}" style="background-position:bottom;background-repeat:no-repeat;">
                  <xsl:if test="not($prmIsEnabled='0')">
                    <xsl:call-template name="tplSetMouseEvents">
                      <xsl:with-param name="prmHandler" select="'mobjApp.DateTimePicker_HandleDownButtonMouseEvents'"/>
                    </xsl:call-template>
                  </xsl:if>
                </td>
              </tr>
            </table>
          </td>
        </xsl:if>
        <xsl:if test="not(@Attr.ShowUpDown)  or @Attr.ShowUpDown='0' or @Attr.ShowUpDown='2'">
          <td class="Common-AlignCenter {$prmButtonContainerClass}">
            <xsl:attribute name="style">
              <xsl:text>width:</xsl:text>
              <xsl:value-of select="$prmDropDownIconContainerWidth"/>
              <xsl:text>px;height:100%;</xsl:text>
            </xsl:attribute>
            <xsl:if test="not($prmIsEnabled='0')">
              <xsl:call-template name="tplSetMouseEvents">
                <xsl:with-param name="prmHandler" select="'mobjApp.DateTimePicker_HandleDropDownIconMouseEvents'"/>
              </xsl:call-template>
            </xsl:if>
            <div style="width:{$prmDropDownIconContainerWidth}px;height:100%;background-position:center;background-repeat:no-repeat;" class="{$prmDropDownIconClass}">
              <xsl:if test="$varBrowserIE='1'">
                <xsl:call-template name="tplDrawEmptyImage" />
              </xsl:if>
            </div>
          </td>
        </xsl:if>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>


