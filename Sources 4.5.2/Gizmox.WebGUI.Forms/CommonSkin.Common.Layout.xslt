<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!-- Apply styles to the current container -->
  <xsl:template name="tplApplyStyles">

    <!-- Conditional parmaters -->
    <xsl:param name="prmBorder" select="1" />
    <xsl:param name="prmBackground" select="1" />
    <xsl:param name="prmFont" select="1" />
    <xsl:param name="prmForeColor" select="$prmFont" />
    <xsl:param name="prmCursor" select="1" />
    <xsl:param name="prmBorderRadius" select="1" />
    <xsl:param name="prmVisualEffects" select="1" />
    <!-- Optional parameters-->
    <xsl:param name="prmBorderValue" />
    <xsl:param name="prmBackgroundValue" />
    <xsl:param name="prmBackgroundImageValue" />
    <xsl:param name="prmBackgroundImageRepeatValue" />
    <xsl:param name="prmBackgroundImagePositionValue" />

    <xsl:if test="$prmBorder='1'">
      <xsl:choose>
        <xsl:when test="$prmBorderValue and not($prmBorderValue='')"><xsl:value-of select="$prmBorderValue"/>;</xsl:when>
        <xsl:otherwise>
          <xsl:if test="@Attr.Border"><xsl:value-of select="@Attr.Border"/>;</xsl:if>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
    <xsl:if test="$prmBackground='1'">
      <xsl:choose>
        <xsl:when test="$prmBackgroundValue or $prmBackgroundImageValue or $prmBackgroundImageRepeatValue or $prmBackgroundImagePositionValue">
          <xsl:if test="$prmBackgroundValue and not($prmBackgroundValue='')">background-color: <xsl:value-of select="$prmBackgroundValue"/>;</xsl:if>
          <xsl:if test="$prmBackgroundImageValue and not($prmBackgroundImageValue='')">background-image: url('<xsl:value-of select="$prmBackgroundImageValue"/>');</xsl:if>
          <xsl:if test="$prmBackgroundImagePositionValue and not($prmBackgroundImagePositionValue='')">background-position: <xsl:value-of select="$prmBackgroundImagePositionValue"/>;</xsl:if>
          <xsl:if test="$prmBackgroundImageRepeatValue and not($prmBackgroundImageRepeatValue='')">background-repeat: <xsl:value-of select="$prmBackgroundImageRepeatValue"/>;</xsl:if>
        </xsl:when>
        <xsl:otherwise>
          <xsl:variable name="varBackgroundImageLayout" select="@Attr.BackgroundImageLayout"/>
          <xsl:variable name="varBackgroundImage" select="@Attr.BackgroundImage"/>
          <xsl:variable name="varBackground" select="@Attr.Background"/>

          <xsl:if test="$varBackgroundImage">
            background-image:url('<xsl:value-of select="$varBackgroundImage"/>');
            <xsl:choose>
              <xsl:when test="$varBackgroundImageLayout='0'">background-repeat:no-repeat;background-position:top <xsl:value-of select="$pleft"/>;</xsl:when>
              <xsl:when test="$varBackgroundImageLayout='1'">background-repeat:repeat;background-position:top <xsl:value-of select="$pleft"/>;</xsl:when>
              <xsl:when test="$varBackgroundImageLayout='2'">background-repeat:no-repeat;background-position:center center;</xsl:when>
              <xsl:when test="$varBackgroundImageLayout='3'">background-repeat:no-repeat;background-position:top <xsl:value-of select="$pleft"/>;background-size:100% 100%;</xsl:when>
              <xsl:when test="$varBackgroundImageLayout='4'">background-repeat:no-repeat;background-position:center center;background-size:contain;</xsl:when>
            </xsl:choose>
          </xsl:if>
          <xsl:if test="$varBackground">background-color:<xsl:value-of select="$varBackground"/>;</xsl:if>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>

    <xsl:if test="$prmFont='1'">
      <xsl:call-template name="tplApplyOnlyFontStyles"/>
    </xsl:if>
    <xsl:if test="$prmForeColor='1'">
      <xsl:call-template name="tplApplyForeColorStyles"/>
    </xsl:if>
    <xsl:if test="$prmCursor='1'">
      <xsl:call-template name="tplApplyCursorStyle"/>
    </xsl:if>

    <xsl:if test="$prmVisualEffects='1'">
      <xsl:call-template name="tplApplyOnDrawVisualEffects" />
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyOnDrawVisualEffects">
    <!--This templete should be called inside a 'style' attribute-->
    <xsl:value-of select="@Attr.OnDrawVisualEffects"/>;
  </xsl:template>

  <xsl:template name="tplApplyAfterDrawVisualEffects">
    <!--This templete should be called inside an element attribute-->
    <xsl:param name="prmGuid" select="@Attr.Id"/>
    <xsl:if test="string-length(@Attr.AfterDrawVisualEffects)!=0">
      <xsl:variable name="varVisualEffectsAfterDraw">
        '<xsl:value-of select="@Attr.AfterDrawVisualEffects"/>'
      </xsl:variable>
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod" select="concat('mobjApp.VisualEffects_ApplyVisualEffectsAfterDraw(window,',$prmGuid,',',$varVisualEffectsAfterDraw,');')"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyBeforeEntranceVisualEffects">
    <!--This templete should be called inside a 'style' attribute-->
    <xsl:value-of select="@Attr.BeforeEntranceEffect"/>;
  </xsl:template>

  <xsl:template name="tplApplyAfterEntranceVisualEffects">
    <!--This templete should be called inside an element attribute-->
    <xsl:param name="prmGuid" select="@Attr.Id"/>
    <xsl:variable name="varAfterEntranceEffect">
      <xsl:value-of select="@Attr.AfterEntranceEffect"/>
    </xsl:variable>
    <xsl:if test="string-length($varAfterEntranceEffect)!=0">
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod">
          mobjApp.VisualEffects_ApplyVisualEffectsAfterDraw(window, '<xsl:value-of select="$prmGuid" />', '<xsl:value-of select="$varAfterEntranceEffect"/>', null, null, 'Attr.BeforeEntranceEffect', 'Attr.AfterEntranceEffect')
        </xsl:with-param>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <!-- Apply margins to the current container -->
  <xsl:template name="tplApplyMargins">
    <xsl:if test="@Attr.MarginAll">
      margin:<xsl:value-of select="@Attr.MarginAll"/>px;
    </xsl:if>
    <xsl:if test="@Attr.MarginLeft">
      margin-<xsl:value-of select="$pleft"/>:<xsl:value-of select="@Attr.MarginLeft"/>px;
    </xsl:if>
    <xsl:if test="@Attr.MarginRight">
      margin-<xsl:value-of select="$pright"/>:<xsl:value-of select="@Attr.MarginRight"/>px;
    </xsl:if>
    <xsl:if test="@Attr.MarginTop">
      margin-top:<xsl:value-of select="@Attr.MarginTop"/>px;
    </xsl:if>
    <xsl:if test="@Attr.MarginBottom">
      margin-bottom:<xsl:value-of select="@Attr.MarginBottom"/>px;
    </xsl:if>
  </xsl:template>

  <!-- Apply padding to the current container -->
  <xsl:template name="tplApplyPaddings">
    <xsl:if test="@Attr.PaddingAll">padding:<xsl:value-of select="@Attr.PaddingAll"/>px;</xsl:if>
    <xsl:if test="@Attr.PaddingLeft">padding-<xsl:value-of select="$pleft"/>:<xsl:value-of select="@Attr.PaddingLeft"/>px;</xsl:if>
    <xsl:if test="@Attr.PaddingRight">padding-<xsl:value-of select="$pright"/>:<xsl:value-of select="@Attr.PaddingRight"/>px;</xsl:if>
    <xsl:if test="@Attr.PaddingTop">padding-top:<xsl:value-of select="@Attr.PaddingTop"/>px;</xsl:if>
    <xsl:if test="@Attr.PaddingBottom">padding-bottom:<xsl:value-of select="@Attr.PaddingBottom"/>px;</xsl:if>
  </xsl:template>

  <!-- Apply font to the current container -->
  <xsl:template name="tplApplyFontStyles">
    <xsl:param name="prmTarget" select="."/>
    <xsl:param name="prmFont" select="$prmTarget/@Attr.Font"/>
    <xsl:param name="prmForeColor" select="$prmTarget/@Attr.Fore"/>

    <xsl:call-template name="tplApplyOnlyFontStyles">
      <xsl:with-param name="prmTarget" select="$prmTarget"/>
      <xsl:with-param name="prmFont" select="$prmFont"/>
    </xsl:call-template>
    <xsl:call-template name="tplApplyForeColorStyles">
      <xsl:with-param name="prmTarget" select="$prmTarget"/>
      <xsl:with-param name="prmForeColor" select="$prmForeColor"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplApplyOnlyFontStyles">
    <xsl:param name="prmTarget" select="."/>
    <xsl:param name="prmFont" select="$prmTarget/@Attr.Font"/>
    
    <xsl:if test="$prmFont">font:<xsl:value-of select="$prmFont"/>;</xsl:if>    
  </xsl:template>
  
   <xsl:template name="tplApplyForeColorStyles">
    <xsl:param name="prmTarget" select="."/>    
    <xsl:param name="prmForeColor" select="$prmTarget/@Attr.Fore"/>
    
    <xsl:if test="$prmForeColor">color:<xsl:value-of select="$prmForeColor"/>;</xsl:if>
  </xsl:template>

  <!-- Apply cursor style to the current container -->
  <xsl:template name="tplApplyCursorStyle">
    <xsl:if test="@Attr.Cursor">
      cursor:<xsl:value-of select="@Attr.Cursor"/>;
    </xsl:if>
  </xsl:template>

  <!-- Draws a button content layout -->
  <xsl:template name="tplDrawButtonContent">

    <!-- Text related parameters -->
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmTextClass" />
    <xsl:param name="prmTextAlign" select="@Attr.TextAlign" />
    <xsl:param name="prmTextImageRelation" >
      <xsl:if test="@Attr.TextImageRelation"><xsl:value-of select="@Attr.TextImageRelation"/></xsl:if>
      <xsl:if test="not(@Attr.TextImageRelation)">4</xsl:if>
    </xsl:param>
    <xsl:param name="prmApplyFontStyle" select="1" />
    <xsl:param name="prmApplyForeColorStyle" select="1" />

    <!-- Image related parameters -->
    <xsl:param name="prmImage" select="@Attr.Image" />
    <xsl:param name="prmImageClass" />
    <xsl:param name="prmImageAlign" select="@Attr.ImageAlign" />
    <xsl:param name="prmImageHeight" select="@Attr.ImageHeight" />
    <xsl:param name="prmImageWidth" select="@Attr.ImageWidth" />

    <!-- State related parameters -->
    <xsl:param name="prmStateImage" />
    <xsl:param name="prmStateClass" />
    <xsl:param name="prmStateImageAlign" />
    <xsl:param name="prmStateImageId" />
    <xsl:param name="prmStateImageHeight" select="16" />
    <xsl:param name="prmStateImageWidth" select="16" />

    <!-- Dropdown related parameters -->
    <xsl:param name="prmDropDown" select="0" />
    <xsl:param name="prmDropDownWidth" select="1"/>
    <xsl:param name="prmDropDownImage"  />
    <xsl:param name="prmDropDownClass" />
    <xsl:param name="prmDropDownClickHandler" select="''" />

    <!-- Layout related parameters -->
    <xsl:param name="prmLayoutPadding" select="[Skin.ButtonImageTextGap]" />
    <!-- Calculate layout flags -->
    <xsl:variable name="varHasText" select="($prmText and not($prmText='')) or @Attr.ControlEditMode='1'" /><!--If ControlEditMode is on then we can say that we have text because the user can enter text..-->
    <xsl:variable name="varHasImage" select="$prmImage and not($prmImage='')"/>
    <xsl:variable name="varHasImageAndText" select="$varHasImage and $varHasText"/>

    <!-- Calculate the table layout -->
    <xsl:variable name="varColspan" select="1 + number($varHasImageAndText and ($prmTextImageRelation=4 or $prmTextImageRelation=8)) + number($prmDropDown)" />
    <xsl:variable name="varRowspan" select="1 + number($varHasImageAndText and ($prmTextImageRelation=1 or $prmTextImageRelation=2))" />

    <!-- Calculate the image style -->
    <xsl:variable name="varImageStyle">
      <xsl:if test="$prmImageHeight">height:<xsl:value-of select="$prmImageHeight"/>px;</xsl:if>
      <xsl:if test="$prmImageWidth">width:<xsl:value-of select="$prmImageWidth"/>px;</xsl:if>
    </xsl:variable>

    <xsl:variable name="varStateImageExistsAndAlignedLeft" select="$prmStateImage and contains($prmStateImageAlign,'Left')" />
    <xsl:variable name="varHasImageAndTextImageRelationIs1or4" select="$varHasImage and ($prmTextImageRelation=1 or $prmTextImageRelation=4)" />
    <xsl:variable name="varHasImageAndTextImageRelationIs2or4or8or0orHasText" select="($varHasText and ($prmTextImageRelation=2 or $prmTextImageRelation=8 or $prmTextImageRelation=4)) or $prmTextImageRelation = 0 or ($varHasText and not($varHasImage) and $prmTextImageRelation=1)" />
    <xsl:variable name="varHasImageAndImageRelationIs8" select="$varHasImage and $prmTextImageRelation=8" />
    <xsl:variable name="varStateImageExistsAndAlignedRight" select="$prmStateImage and contains($prmStateImageAlign,'Right')" />
    <xsl:variable name="varIsDropDown" select="$prmDropDown='1'" />
    <xsl:variable name="varPrmStateImageTopCenter" select="$prmStateImage and $prmStateImageAlign='TopCenter'" />
    <xsl:variable name="varTextImageRelation1or2" select="$varHasImageAndText and ($prmTextImageRelation=2 or $prmTextImageRelation=1)" />
    <xsl:variable name="varStateImageAlignBottomCenter" select="$prmStateImage and $prmStateImageAlign='BottomCenter'" />
      <xsl:if test="$varStateImageExistsAndAlignedLeft or $varHasImageAndTextImageRelationIs1or4 or $varHasImageAndTextImageRelationIs2or4or8or0orHasText or $varHasImageAndImageRelationIs8 or $varStateImageExistsAndAlignedRight or $prmDropDown or $varPrmStateImageTopCenter or $varTextImageRelation1or2 or $varStateImageAlignBottomCenter">
    <table class="Common-CellSpacing0 Common-CellPadding0 Common-ButtonTable">

      <!-- If the state image is in the middle -->
      <xsl:if test="$prmStateImageAlign='MiddleCenter'">
        <xsl:attribute name="id"><xsl:value-of select="$prmStateImageId"/></xsl:attribute>
        <xsl:attribute name="style">
          <xsl:call-template name="tplDrawBackground">
            <xsl:with-param name="prmImage"  select="$prmStateImage" />
            <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
          </xsl:call-template>
        </xsl:attribute>
      </xsl:if>

      <colgroup>
        <!-- set the cols to ensure proper auto sizing of the table-->
        <xsl:if test="$varStateImageExistsAndAlignedLeft"><col style="width:{$prmStateImageWidth+$prmLayoutPadding}px" /></xsl:if>
        <xsl:if test="$varHasImage and $prmTextImageRelation=4"><col style="width:1px;" /></xsl:if>
        <xsl:if test="$varHasImageAndTextImageRelationIs2or4or8or0orHasText or $varIsDropDown"><col /></xsl:if>
        <xsl:if test="$varHasImageAndImageRelationIs8"><col style="width:1px;" /></xsl:if>
        <xsl:if test="$varStateImageExistsAndAlignedRight"><col style="width:{$prmStateImageWidth+$prmLayoutPadding}px" /></xsl:if>
        <xsl:if test="$prmDropDown"><col style="width:{$prmDropDownWidth}px" /></xsl:if>
      </colgroup>

      <!-- If the state image is in top center draw dedicated row  -->
      <xsl:if test="$varPrmStateImageTopCenter">
        <tr>
          <td id="{$prmStateImageId}" class="{$prmStateClass}" colspan="{$varColspan}">
            <xsl:attribute name="style">
              <xsl:call-template name="tplDrawBackground">
                <xsl:with-param name="prmImage"  select="$prmStateImage" />
                <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
              </xsl:call-template> height:<xsl:value-of select="$prmStateImageHeight+$prmLayoutPadding" />px;
            </xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage">
              <xsl:with-param name="prmImageHeight" select="concat($prmStateImageHeight, 'px')" />
              <xsl:with-param name="prmImageWidth"  select="concat($prmStateImageWidth, 'px')" />
              <xsl:with-param name="prmDisplayStyle" select="'block'"/>
            </xsl:call-template>
          </td>
        </tr>
      </xsl:if>

      <xsl:if test="$varStateImageExistsAndAlignedLeft or $varHasImageAndTextImageRelationIs1or4 or $varHasImageAndTextImageRelationIs2or4or8or0orHasText or $varHasImageAndImageRelationIs8 or $varStateImageExistsAndAlignedRight or $varIsDropDown">
        <tr>
          <!-- If the image above text or text above image we need an extra row  -->
          <xsl:if test="$varStateImageExistsAndAlignedLeft">
            <td id="{$prmStateImageId}" class="{$prmStateClass}" rowspan="{$varRowspan}">
              <xsl:attribute name="style">
                <xsl:call-template name="tplDrawBackground">
                  <xsl:with-param name="prmImage"  select="$prmStateImage" />
                  <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
                </xsl:call-template>
              </xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="concat($prmStateImageHeight, 'px')" />
                <xsl:with-param name="prmImageWidth"  select="concat($prmStateImageWidth, 'px')" />
                <xsl:with-param name="prmDisplayStyle" select="'block'"/>
              </xsl:call-template>
            </td>
          </xsl:if>

          <!-- If there is an image and it is before text or above text -->
          <xsl:if test="$varHasImageAndTextImageRelationIs1or4">
            <td class="{$prmImageClass}">
              <xsl:attribute name="style">
                <xsl:if test="$prmTextImageRelation=1">
                  height:1px;
                  padding-bottom:<xsl:value-of select="$prmLayoutPadding"/>px;font-size:1px;
                </xsl:if>
                <xsl:if test="$prmTextImageRelation=4">
                  padding-<xsl:value-of select="$right"/>:<xsl:value-of select="$prmLayoutPadding"/>px;
                </xsl:if>
                <xsl:call-template name="tplCellAlign">
                  <xsl:with-param name="prmAlign" select="$prmImageAlign"/>
                </xsl:call-template>
              </xsl:attribute>
              <img src="{$prmImage}" style="{$varImageStyle};" alt="{$prmText}" />
            </td>
          </xsl:if>

          <!-- If image after text / image before text / text above image / overlay -->
          <xsl:if test="$varHasImageAndTextImageRelationIs2or4or8or0orHasText">
            <td>
              <xsl:attribute name="style">
                <!-- If there is an image to overlay -->
                <xsl:if test="$prmTextImageRelation=0 and $varHasImage">
                  <xsl:call-template name="tplDrawBackground">
                    <xsl:with-param name="prmImage"  select="$prmImage" />
                    <xsl:with-param name="prmImageAlign" select="$prmImageAlign" />
                  </xsl:call-template>
                </xsl:if>
                <xsl:call-template name="tplCellAlign">
                  <xsl:with-param name="prmAlign" select="$prmTextAlign"/>
                </xsl:call-template>
              </xsl:attribute>
              <xsl:if test="$varHasText">
                <xsl:apply-templates select="." mode="modContentButtonText">
                  <xsl:with-param name="prmText" select="$prmText" />
                  <xsl:with-param name="prmTextClass" select="$prmTextClass" />
                  <xsl:with-param name="prmApplyFontStyle" select="$prmApplyFontStyle" />
                  <xsl:with-param name="prmApplyForeColorStyle" select="$prmApplyForeColorStyle" />
                </xsl:apply-templates>
              </xsl:if>
              <xsl:if test="not($varHasText)">
                <xsl:call-template name="tplDrawEmptyImage">
                  <xsl:with-param name="prmDisplayStyle" select="'block'"/>
                </xsl:call-template>
              </xsl:if>
            </td>
          </xsl:if>

          <!-- If text before image and valid image -->
          <xsl:if test="$varHasImageAndImageRelationIs8">
            <td class="{$prmImageClass}">
              <xsl:attribute name="style">
                padding-<xsl:value-of select="$left" />:<xsl:value-of select="$prmLayoutPadding" />px;font-size:1px;
                <xsl:call-template name="tplCellAlign">
                  <xsl:with-param name="prmAlign" select="$prmImageAlign"/>
                </xsl:call-template>
              </xsl:attribute>
              <img src="{$prmImage}" style="{$varImageStyle};" alt="{$prmText}" />
            </td>
          </xsl:if>

          <xsl:if test="$varStateImageExistsAndAlignedRight">
            <td  id="{$prmStateImageId}"  class="{$prmStateClass}"  rowspan="{$varRowspan}">
              <xsl:attribute name="style">
                <xsl:call-template name="tplDrawBackground">
                  <xsl:with-param name="prmImage"  select="$prmStateImage" />
                  <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
                </xsl:call-template>
              </xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="concat($prmStateImageHeight, 'px')" />
                <xsl:with-param name="prmImageWidth"  select="concat($prmStateImageWidth, 'px')" />
                <xsl:with-param name="prmDisplayStyle" select="'block'"/>
              </xsl:call-template>
            </td>
          </xsl:if>

          <xsl:if test="$varIsDropDown">
            <td class="Common-AlignCenter Common-VAlignMiddle Button-DropDownImageContainer {$prmDropDownClass}" rowspan="{$varRowspan}">
              <xsl:if test="not($prmDropDownClickHandler='')">
                <xsl:attribute name="onclick">
                  <xsl:value-of select="$prmDropDownClickHandler" />
                </xsl:attribute>
              </xsl:if>
              <xsl:if test="$prmDropDownImage">
                <img src="{$prmDropDownImage}" style="display:block;" alt=""/>
              </xsl:if>
              <xsl:if test="not($prmDropDownImage)">
                <xsl:call-template name="tplDrawEmptyImage">
                  <xsl:with-param name="prmImageWidth"  select="$prmDropDownWidth" />
                </xsl:call-template>
              </xsl:if>
            </td>
          </xsl:if>
        </tr>
      </xsl:if>

      <!-- If the image above text or text above image we need an extra row  -->
      <xsl:if test="$varTextImageRelation1or2">
        <tr>
          <xsl:if test="$varHasImage and $prmTextImageRelation=2">
            <td class="{$prmImageClass}" style="height:1px;padding-top:{$prmLayoutPadding}px;font-size:1px;">
              <xsl:attribute name="style">
                <xsl:call-template name="tplCellAlign">
                  <xsl:with-param name="prmAlign" select="$prmImageAlign"/>
                </xsl:call-template>
              </xsl:attribute>
              <img src="{$prmImage}" style="{$varImageStyle};" alt="{$prmText}"/>
            </td>
          </xsl:if>
          <xsl:if test="$prmTextImageRelation=1">
            <td >
              <xsl:attribute name="style">
                <xsl:call-template name="tplCellAlign">
                  <xsl:with-param name="prmAlign" select="$prmTextAlign"/>
                </xsl:call-template>
              </xsl:attribute>
              <xsl:apply-templates select="." mode="modContentButtonText">
                  <xsl:with-param name="prmText" select="$prmText" />
                  <xsl:with-param name="prmTextClass" select="$prmTextClass" />
                  <xsl:with-param name="prmApplyFontStyle" select="$prmApplyFontStyle" />
                  <xsl:with-param name="prmApplyForeColorStyle" select="$prmApplyForeColorStyle" />
                </xsl:apply-templates>
            </td>
          </xsl:if>
        </tr>
      </xsl:if>

      <!-- If the state image is in bottom center draw dedicated row  -->
      <xsl:if test="$varStateImageAlignBottomCenter">
        <tr>
          <td id="{$prmStateImageId}" class="{$prmStateClass}" colspan="{$varColspan}">
            <xsl:attribute name="style">
              <xsl:call-template name="tplDrawBackground">
                <xsl:with-param name="prmImage"  select="$prmStateImage" />
                <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
              </xsl:call-template> height:<xsl:value-of select="$prmStateImageHeight+$prmLayoutPadding" />px;
            </xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage">
              <xsl:with-param name="prmImageHeight" select="concat($prmStateImageHeight, 'px')" />
              <xsl:with-param name="prmImageWidth"  select="concat($prmStateImageWidth, 'px')" />
              <xsl:with-param name="prmDisplayStyle" select="'block'"/>
            </xsl:call-template>
          </td>
        </tr>
      </xsl:if>

    </table>
    </xsl:if>
  </xsl:template>
  <xsl:template mode="modContentButtonText" match="*[@Attr.ControlEditMode='1']">
    <xsl:param name="prmText" />
    <xsl:param name="prmTextClass" />
    <xsl:param name="prmApplyFontStyle" select="1"/>
    <xsl:param name="prmApplyForeColorStyle" select="1"/>
    
    <xsl:call-template name="tplDrawEditingTextInput">
      <xsl:with-param name="prmInputClass">
        TextBox-Input <xsl:value-of select="$prmTextClass" />
      </xsl:with-param>
    </xsl:call-template>
    
  </xsl:template>

  <xsl:template mode="modContentButtonText" match="*">
    <xsl:param name="prmText" />
    <xsl:param name="prmTextClass" />
    <xsl:param name="prmApplyFontStyle" select="1"/>
    <xsl:param name="prmApplyForeColorStyle" select="1"/>
    
    <span class="{$prmTextClass}">
      <xsl:attribute name="style">
          <xsl:if test="$prmApplyFontStyle=1"><xsl:call-template name="tplApplyOnlyFontStyles" /></xsl:if>
          <xsl:if test="$prmApplyForeColorStyle=1"><xsl:call-template name="tplApplyForeColorStyles" /></xsl:if>
        <xsl:text>display:block;</xsl:text>
      </xsl:attribute>
      <xsl:call-template name="tplDecodeTextAsHtml">
        <xsl:with-param name="prmText" select="$prmText"/>
      </xsl:call-template>
    </span>
  </xsl:template>
  
  <!-- Apply style to a given control -->
  <xsl:template match="*" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" />
  </xsl:template>

  <!-- Draws an error image which blinks and has a title -->
  <xsl:template name="tplDrawErrorIcon">
    <div>
      <xsl:attribute name="title">
        <xsl:call-template name="tplDecodeText">
          <xsl:with-param name="prmText" select="@Attr.ErrorMessage"/>
        </xsl:call-template>
      </xsl:attribute>
      <xsl:attribute name="style">
        position:absolute;top:0px;width:0px;height:100%;
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Right')">
          <xsl:value-of select="$right"/>:-1px;
        </xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Left')">
          <xsl:value-of select="$left"/>:-1px;
        </xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Top')">top:0px;</xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Middle')">top:50%;</xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Bottom')">bottom:0px;</xsl:if>
      </xsl:attribute>
      <img onload="mobjApp.Web_ErrorProviderBlink('{@Id}',this,400,4)" alt="" >
        <xsl:attribute name="style">
          position:absolute;width:16px;height:16px;
          <xsl:if test="contains(@Attr.ErrorIconAlignment,'Right')">
            <xsl:value-of select="$right"/>:-20px;
          </xsl:if>
          <xsl:if test="contains(@Attr.ErrorIconAlignment,'Left')">
            <xsl:value-of select="$left"/>:-20px;
          </xsl:if>
          <xsl:if test="contains(@Attr.ErrorIconAlignment,'Top')">top:0px;</xsl:if>
          <xsl:if test="contains(@Attr.ErrorIconAlignment,'Middle')">top:-8px;</xsl:if>
          <xsl:if test="contains(@Attr.ErrorIconAlignment,'Bottom')">bottom:0px;</xsl:if>
        </xsl:attribute>
        <xsl:attribute name="src">
          <xsl:if test="@Attr.ErrorIcon and not(@Attr.ErrorIcon='')">
            <xsl:value-of select="@Attr.ErrorIcon"/>
          </xsl:if>
          <xsl:if test="not(@Attr.ErrorIcon and not(@Attr.ErrorIcon=''))">[Skin.CommonPath]ErrorProvider.gif.wgx</xsl:if>
        </xsl:attribute>
      </img>
    </div>
  </xsl:template>

  <!-- Draws and empty image by default as 1px X 1px -->
  <xsl:template name="tplDrawEmptyImage">
    <xsl:param name="prmImageHeight" select="'1px'"/>
    <xsl:param name="prmImageWidth"  select="'1px'"/>
    <xsl:param name="prmPositionStyle" select="'static'"/>
    <xsl:param name="prmDisplayStyle"/>
    <xsl:param name="prmImageTop"/>
    <xsl:param name="prmImageLeft"/>
    <img src="[Skin.Path]Empty.gif.wgx" alt="">
      <xsl:attribute name="style">position:<xsl:value-of select="$prmPositionStyle"/>;width:<xsl:value-of select="$prmImageWidth"/>;height:<xsl:value-of select="$prmImageHeight"/>;<xsl:if test="$prmImageTop">top:<xsl:value-of select="$prmImageTop"/>;</xsl:if><xsl:if test="$prmImageLeft">left:<xsl:value-of select="$prmImageLeft"/>;</xsl:if><xsl:if test="$prmDisplayStyle">display:<xsl:value-of select="$prmDisplayStyle"/></xsl:if>
      </xsl:attribute>
    </img>
  </xsl:template>


  <xsl:template match="*" mode="modScrollbars">
    <xsl:param name="prmContainerElementID" select="@Attr.Id" />
    <xsl:param name="prmScrollerType" select="@Attr.ScrollerType" />
    <xsl:param name="prmScrollbars" select="@Attr.Scrollbars" />
    <xsl:param name="prmArrowsBaseClass" select="'Common-ArrowsClass'" />
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
      <xsl:with-param name="prmScrollerType" select="$prmScrollerType" />
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

  <!-- Draws Scrollbars -->
  <xsl:template name="tplDrawScrollbars">
    <xsl:param name="prmContainerElementID" select="@Attr.Id" />
    <xsl:param name="prmScrollerType" select="@Attr.ScrollerType" />
    <xsl:param name="prmScrollbars" select="@Attr.Scrollbars" />

    <!--Arrows parameters-->
    <xsl:param name="prmArrowsBaseClass" select="'Common-ArrowsClass'" />
    <xsl:param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
    <xsl:param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
    <xsl:param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
    <xsl:param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
    <xsl:param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
    <xsl:param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
    <xsl:param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
    <xsl:param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />
    <xsl:call-template name="tplCallMethod">
      <xsl:with-param name="prmMethod">
        <xsl:choose>
          <xsl:when test="$prmScrollerType='1'">
            mobjApp.Common_InitializeArrowScrollBars('VWG_<xsl:value-of select="$prmContainerElementID" />', '<xsl:value-of select="$prmScrollbars" />', '<xsl:value-of select="$prmArrowsBaseClass"/>', <xsl:value-of select="$prmTopArrowThickness"/>, <xsl:value-of select="$prmRightArrowThickness"/>, <xsl:value-of select="$prmBottomArrowThickness"/>, <xsl:value-of select="$prmLeftArrowThickness"/>, <xsl:value-of select="$prmHorizontalHoverSpeed"/>, <xsl:value-of select="$prmHorizontalDownSpeed"/>, <xsl:value-of select="$prmVerticalHoverSpeed"/>, <xsl:value-of select="$prmVerticalDownSpeed"/>, window);
          </xsl:when>
          <xsl:otherwise>
            mobjApp.Common_InitializeDefaultScrollBars('VWG_<xsl:value-of select="$prmContainerElementID" />','<xsl:value-of select="$prmScrollbars" />', window);
          </xsl:otherwise>
        </xsl:choose>mobjApp.Controls_RestoreScroll(window,'<xsl:value-of select="$prmContainerElementID" />',null,null,this.parentNode);
      </xsl:with-param>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawPaging">
    <xsl:param name="prmID" select="@Attr.Id"/>
    <xsl:param name="prmCurrentPage" select="@Attr.CurrentPage"/>
    <xsl:param name="prmTotalPages" select="@Attr.TotalPages"/>
    <xsl:param name="prmPagingFirstImageWidth"/>
    <xsl:param name="prmPagingFirstButtonClass"/>
    <xsl:param name="prmPagingPreviousImageWidth"/>
    <xsl:param name="prmPagingPrevButtonClass"/>
    <xsl:param name="prmPagingBoxWidth"/>
    <xsl:param name="prmPagingGoToBoxClass"/>
    <xsl:param name="prmPagingNumberSeperatorString"/>
    <xsl:param name="prmPagingNextImageWidth"/>
    <xsl:param name="prmPagingNextButtonClass"/>
    <xsl:param name="prmPagingLastImageWidth"/>
    <xsl:param name="prmPagingLastButtonClass"/>

    <table style="height:100%;" class="Common-AlignCenter Common-CellSpacing0 Common-CellPadding0 Common-PagingPanel Common-FontData" dir="{$dir}">
      <tr>
        <td></td>
        <td>
          <xsl:attribute name="class"><xsl:value-of select="$prmPagingFirstImageWidth"/><xsl:if test="$prmCurrentPage=1"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a>
            <xsl:if test="not($prmCurrentPage=1)">
              <xsl:attribute name="onclick">mobjApp.List_NavigateHome('<xsl:value-of select="$prmID"/>');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingFirstButtonClass}">&#160;</div>
          </a>
        </td>
        <td>
          <xsl:attribute name="class">
            <xsl:value-of select="$prmPagingPreviousImageWidth"/><xsl:if test="$prmCurrentPage=1"> Common-Disabled</xsl:if>
           </xsl:attribute>
          <a>
            <xsl:if test="not($prmCurrentPage=1)">
              <xsl:attribute name="onclick">mobjApp.List_NavigateBack('<xsl:value-of select="$prmID"/>');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingPrevButtonClass}">&#160;</div>
          </a>
        </td>
        <td dir="ltr" style="position:relative;height:100%;width:{$prmPagingBoxWidth}px;">
          <div style="height:100%;text-align:center;">
            <table style="direction:{$ltr}">
              <colgroup>
                <col style="width:40%" />
                <col style="width:20%" />
                <col style="width:40%" />
              </colgroup>
              <tr>
                <td style="position:relative;">
                  <input data-vwgeditable="1" value="{$prmCurrentPage}" id="TRG_paging_{$prmID}" class="Common-FontData Common-Content {$prmPagingGoToBoxClass}" style="height:100%;width:100%;direction:{$rtl};">
                    <xsl:attribute name="onkeydown">mobjApp.List_NavigatePage('<xsl:value-of select="$prmID"/>',<xsl:value-of select="$prmTotalPages"/>, this,event);</xsl:attribute>
                  </input>
                  <xsl:call-template name="tplAddAccessibleNameLabel">
                    <xsl:with-param name="prmId">TRG_paging_<xsl:value-of select="$prmID" /></xsl:with-param>
                    <xsl:with-param name="prmText">Labels.CurrentPage</xsl:with-param>
                  </xsl:call-template>
                </td>
                <td class="Common-VAlignMiddle"><xsl:value-of select="$prmPagingNumberSeperatorString"/></td>
                <td style="text-align:{$left}" class="Common-VAlignMiddle"><xsl:value-of select="$prmTotalPages"/></td>
              </tr>
            </table>

          </div>
        </td>
        <td>
          <xsl:attribute name="class">
            <xsl:value-of select="$prmPagingNextImageWidth"/><xsl:if test="$prmCurrentPage=$prmTotalPages"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a>
            <xsl:if test="$prmCurrentPage &lt; $prmTotalPages">
              <xsl:attribute name="onclick">mobjApp.List_NavigateNext('<xsl:value-of select="$prmID"/>');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingNextButtonClass}">&#160;</div>
          </a>
        </td>
        <td>
          <xsl:attribute name="class">
            <xsl:value-of select="$prmPagingLastImageWidth"/><xsl:if test="$prmCurrentPage=$prmTotalPages"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a>
            <xsl:if test="$prmCurrentPage &lt; $prmTotalPages">
              <xsl:attribute name="onclick">mobjApp.List_NavigateEnd('<xsl:value-of select="$prmID"/>');</xsl:attribute>
            </xsl:if>
            <div  class="{$prmPagingLastButtonClass}">&#160;</div>
          </a>
        </td>
        <td></td>
      </tr>
    </table>
  </xsl:template>

  <xsl:template name="tplApplyMinMaxSizeAttributes">
    <xsl:variable name="varMinimumWidth" select="@Attr.MinimumWidth" />
    <xsl:variable name="varMinimumHeight" select="@Attr.MinimumHeight" />
    <xsl:variable name="varMaximumWidth" select="@Attr.MaximumWidth" />
    <xsl:variable name="varMaximumHeight" select="@Attr.MaximumHeight" />

    <xsl:if test="$varMinimumWidth and number($varMinimumWidth)>0"><xsl:attribute name="vwgminimumwidth"><xsl:value-of select="$varMinimumWidth"/></xsl:attribute></xsl:if>
    <xsl:if test="$varMinimumHeight and number($varMinimumHeight)>0"><xsl:attribute name="vwgminimumheight"><xsl:value-of select="$varMinimumHeight"/></xsl:attribute></xsl:if>
    <xsl:if test="$varMaximumWidth and number($varMaximumWidth)>0"><xsl:attribute name="vwgmaximumwidth"><xsl:value-of select="$varMaximumWidth"/></xsl:attribute></xsl:if>
    <xsl:if test="$varMaximumHeight and number($varMaximumHeight)>0"><xsl:attribute name="vwgmaximumheight"><xsl:value-of select="$varMaximumHeight"/></xsl:attribute></xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyMinMaxSizeStyle">
    <xsl:variable name="varMinimumWidth" select="@Attr.MinimumWidth" />
    <xsl:variable name="varMinimumHeight" select="@Attr.MinimumHeight" />
    <xsl:variable name="varMaximumWidth" select="@Attr.MaximumWidth" />
    <xsl:variable name="varMaximumHeight" select="@Attr.MaximumHeight" />

    <xsl:if test="$varMinimumWidth and number($varMinimumWidth)>0">min-width:<xsl:value-of select="$varMinimumWidth"/>px;</xsl:if>
    <xsl:if test="$varMinimumHeight and number($varMinimumHeight)>0">min-height:<xsl:value-of select="$varMinimumHeight"/>px;</xsl:if>
    <xsl:if test="$varMaximumWidth and number($varMaximumWidth)>0">max-width:<xsl:value-of select="$varMaximumWidth"/>px;</xsl:if>
    <xsl:if test="$varMaximumHeight and number($varMaximumHeight)>0">max-height:<xsl:value-of select="$varMaximumHeight"/>px;</xsl:if>
  </xsl:template>

  <!-- Draws a 9ner frame which can be styled -->
  <xsl:template name="tplDrawFrame">

    <!-- Frame classes -->
    <xsl:param name="prmFrameClass"/>
    <xsl:param name="prmLeftBottomClass"/>
    <xsl:param name="prmLeftClass"/>
    <xsl:param name="prmLeftTopClass"/>
    <xsl:param name="prmTopClass"/>
    <xsl:param name="prmRightTopClass"/>
    <xsl:param name="prmRightClass"/>
    <xsl:param name="prmRightBottomClass"/>
    <xsl:param name="prmBottomClass"/>
    <xsl:param name="prmCenterClass"/>
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmHeaderClass"/>

    <!-- Frame overlay classes -->
    <xsl:param name="prmLeftOverlayClass"/>
    <xsl:param name="prmRightOverlayClass"/>

    <!-- Frame sizes -->
    <xsl:param name="prmLeftFrameWidth" select="0" />
    <xsl:param name="prmRightFrameWidth" select="0" />
    <xsl:param name="prmTopFrameHeight" select="0" />
    <xsl:param name="prmBottomFrameHeight" select="0" />

    <xsl:param name="prmLeftContentOffset" select="$prmLeftFrameWidth" />
    <xsl:param name="prmRightContentOffset" select="$prmRightFrameWidth" />
    <xsl:param name="prmTopContentOffset" select="$prmTopFrameHeight" />
    <xsl:param name="prmBottomContentOffset" select="$prmBottomFrameHeight" />

    <!-- Frame content  -->
    <xsl:param name="prmCenterContent" />
    <xsl:param name="prmHeaderContent" />

    <!-- Frame events  -->
    <xsl:param name="prmResizeHandler" />

    <xsl:param name="prmIsAutoSize" select="0"/>
    <xsl:param name="prmIsActiveFrame" select="0" />
    <xsl:param name="prmIsJoinContentFrame" select="0" />
    <xsl:param name="prmIsEnabled" />

    <!-- Frame variables  -->
    <xsl:variable name="varHasFrame" select="$prmLeftFrameWidth > 0 or $prmRightFrameWidth > 0 or $prmTopFrameHeight > 0 or $prmBottomFrameHeight > 0" />

    <!-- Top Row  -->
    <xsl:if test="$prmTopFrameHeight > 0">
      <xsl:if test="$prmLeftFrameWidth > 0">
        <div style="position:absolute;left:0px;top:0px;width:{$prmLeftFrameWidth}px;height:{$prmTopFrameHeight}px;">
          <xsl:attribute name="class"><xsl:value-of select="$prmLeftTopClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-LeftUpResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
          <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
            <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
            <xsl:attribute name="data-vwgdrag">rtl</xsl:attribute>
          </xsl:if>
            <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
      </xsl:if>
      <div style="position:absolute;left:{$prmLeftFrameWidth}px;top:0px;right:{$prmRightFrameWidth}px;height:{$prmTopFrameHeight}px;">
        <xsl:attribute name="class"><xsl:value-of select="$prmTopClass"/></xsl:attribute>
        <xsl:if test="$prmHeaderContent">
          <div class="{$prmHeaderClass} Common-FrameHeader" style="height:100%;width:100%;">
            <xsl:apply-templates select="$prmHeaderContent" mode="modFrameHeaderContent">
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:apply-templates>
          </div>
        </xsl:if>
        <xsl:if test="not($prmHeaderContent)"><xsl:call-template name="tplDrawEmptyImage"/></xsl:if>
      </div>
      <xsl:if test="$prmRightFrameWidth > 0">
        <div style="position:absolute;right:0px;top:0px;width:{$prmRightFrameWidth}px;height:{$prmTopFrameHeight}px;">
          <xsl:attribute name="class"><xsl:value-of select="$prmRightTopClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-RightUpResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
          <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
            <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
            <xsl:attribute name="data-vwgdrag">rtr</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
      </xsl:if>
    </xsl:if>
    
    <!-- Middle Row  -->
    <xsl:if test="$prmLeftFrameWidth > 0">
      <div style="position:absolute;left:0px;top:{$prmTopFrameHeight}px;bottom:{$prmBottomFrameHeight}px;width:{$prmLeftFrameWidth}px;">
        <xsl:attribute name="class"><xsl:value-of select="$prmLeftClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-HorizontalResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
        <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
          <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
          <xsl:attribute name="data-vwgdrag">rl</xsl:attribute>
        </xsl:if>
        <xsl:call-template name="tplDrawEmptyImage"/>
      </div>
    </xsl:if>       
    <div style="position:absolute;left:{$prmLeftFrameWidth}px;right:{$prmRightFrameWidth}px;top:{$prmTopFrameHeight}px;bottom:{$prmBottomFrameHeight}px;overflow:hidden;">
      <xsl:attribute name="class"><xsl:value-of select="$prmCenterClass"/><xsl:if test="not($varHasFrame)"> Common-FrameCenter</xsl:if></xsl:attribute>
      <xsl:if test="$prmCenterContent">
        <xsl:call-template name="tplDrawFrameContent">
          <xsl:with-param name="prmCenterContent" select="$prmCenterContent"/>
          <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:if>
      <xsl:if test="not($prmCenterContent)"><xsl:call-template name="tplDrawEmptyImage"/></xsl:if>
    </div>
    <xsl:if test="$prmRightFrameWidth > 0">
      <div style="position:absolute;right:0px;top:{$prmTopFrameHeight}px;bottom:{$prmBottomFrameHeight}px;width:{$prmRightFrameWidth}px;">
        <xsl:attribute name="class"><xsl:value-of select="$prmRightClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-HorizontalResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
        <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
          <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
          <xsl:attribute name="data-vwgdrag">rr</xsl:attribute>
        </xsl:if>
        <xsl:call-template name="tplDrawEmptyImage"/>
      </div>
    </xsl:if>
    
    <!-- Bottom Row  -->
    <xsl:if test="$prmBottomFrameHeight > 0">
      <xsl:if test="$prmLeftFrameWidth > 0">
        <div style="position:absolute;left:0px;bottom:0px;width:{$prmLeftFrameWidth}px;height:{$prmBottomFrameHeight}px;">
          <xsl:attribute name="class"><xsl:value-of select="$prmLeftBottomClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-RightUpResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
          <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
            <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
            <xsl:attribute name="data-vwgdrag">rbl</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
      </xsl:if>
      <div style="position:absolute;left:{$prmLeftFrameWidth}px;bottom:0px;right:{$prmRightFrameWidth}px;height:{$prmBottomFrameHeight}px;">
        <xsl:attribute name="class"><xsl:value-of select="$prmBottomClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-VerticalResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
        <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
          <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
          <xsl:attribute name="data-vwgdrag">rb</xsl:attribute>
        </xsl:if>
        <xsl:call-template name="tplDrawEmptyImage"/>
      </div>
      <xsl:if test="$prmRightFrameWidth > 0">
        <div style="position:absolute;right:0px;bottom:0px;width:{$prmRightFrameWidth}px;height:{$prmBottomFrameHeight}px;">
          <xsl:attribute name="class"><xsl:value-of select="$prmRightBottomClass"/><xsl:if test="$prmResizeHandler and not($prmResizeHandler='')"> Common-LeftUpResize Common-FrameResizeHandle</xsl:if></xsl:attribute>
          <xsl:if test="$prmResizeHandler and not($prmResizeHandler='')">
            <xsl:attribute name="onmousedown"><xsl:value-of select="$prmResizeHandler"/></xsl:attribute>
            <xsl:attribute name="data-vwgdrag">rbr</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>    
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <!-- Docking Layout -->
  <xsl:template match="*[(@D and not(@D=''))]" mode="modDocking">
    <xsl:param name="prmLeft"	select="0"/>
    <xsl:param name="prmRight" select="0"/>
    <xsl:param name="prmTop" select="0"/>
    <xsl:param name="prmBottom"	select="0"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varNext" select="following-sibling::*[not(@Attr.AutoDrawn=0) and (@D and not(@D=''))][position()=1]" />
    <xsl:variable name="varWidth"	select="number(not(@Attr.Visible) or @Attr.Visible='1')*@W" />
    <xsl:variable name="varHeight" select="number(not(@Attr.Visible) or @Attr.Visible='1')*@H" />

    <xsl:variable name="varParent" select="parent::*" />

    <xsl:variable name="varParentPaddingAll" select="$varParent/@Attr.PaddingAll" />
    <xsl:variable name="varLeft">
      <xsl:choose>
        <xsl:when test="not($prmLeft=0)">
          <xsl:value-of select="$prmLeft"/>
        </xsl:when>
        <xsl:when test="$varParentPaddingAll and not($varParentPaddingAll='')">
          <xsl:value-of select="$varParentPaddingAll"/>
        </xsl:when>
        <xsl:when test="$dir='LTR' and $varParent/@Attr.PaddingLeft and not($varParent/@Attr.PaddingLeft='')">
          <xsl:value-of select="$varParent/@Attr.PaddingLeft"/>
        </xsl:when>
        <xsl:when test="$dir='RTL' and $varParent/@Attr.PaddingRight and not($varParent/@Attr.PaddingRight='')">
          <xsl:value-of select="$varParent/@Attr.PaddingRight"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="$prmLeft"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varRight">
      <xsl:choose>
        <xsl:when test="not($prmRight=0)">
          <xsl:value-of select="$prmRight"/>
        </xsl:when>
        <xsl:when test="$varParentPaddingAll and not($varParentPaddingAll='')">
          <xsl:value-of select="$varParentPaddingAll"/>
        </xsl:when>
        <xsl:when test="$dir='LTR' and $varParent/@Attr.PaddingRight and not($varParent/@Attr.PaddingRight='')">
          <xsl:value-of select="$varParent/@Attr.PaddingRight"/>
        </xsl:when>
        <xsl:when test="$dir='RTL' and $varParent/@Attr.PaddingLeft and not($varParent/@Attr.PaddingLeft='')">
          <xsl:value-of select="$varParent/@Attr.PaddingLeft"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="$prmRight"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varTop">
      <xsl:choose>
        <xsl:when test="not($prmTop=0)">
          <xsl:value-of select="$prmTop"/>
        </xsl:when>
        <xsl:when test="$varParentPaddingAll and not($varParentPaddingAll='')">
          <xsl:value-of select="$varParentPaddingAll"/>
        </xsl:when>
        <xsl:when test="$varParent/@Attr.PaddingTop and not($varParent/@Attr.PaddingTop='')">
          <xsl:value-of select="$varParent/@Attr.PaddingTop"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="$prmTop"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varBottom">
      <xsl:choose>
        <xsl:when test="not($prmBottom=0)">
          <xsl:value-of select="$prmBottom"/>
        </xsl:when>
        <xsl:when test="$varParentPaddingAll and not($varParentPaddingAll='')">
          <xsl:value-of select="$varParentPaddingAll"/>
        </xsl:when>
        <xsl:when test="$varParent/@Attr.PaddingBottom and not($varParent/@Attr.PaddingBottom='')">
          <xsl:value-of select="$varParent/@Attr.PaddingBottom"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="$prmBottom"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <!--Draw current item through layout item mode.-->
    <xsl:apply-templates select="." mode="modLayoutItem">
      <xsl:with-param name="prmLeft"		select="$varLeft"/>
      <xsl:with-param name="prmRight"		select="$varRight"/>
      <xsl:with-param name="prmTop"		select="$varTop"/>
      <xsl:with-param name="prmBottom"	select="$varBottom"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:apply-templates>

    <xsl:if test="$varNext">
      <xsl:variable name="varVerticalMarginOffset">
        <xsl:choose>
          <xsl:when test="@D='B' or @D='T'">
            <xsl:choose>
              <xsl:when test="@Attr.MarginAll">
                <xsl:value-of select="2 * @Attr.MarginAll"/>
              </xsl:when>
              <xsl:when test="@Attr.MarginBottom and @Attr.MarginTop">
                <xsl:value-of select="@Attr.MarginBottom + @Attr.MarginTop"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:value-of select="0"/>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="0"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
        <xsl:variable name="varHorizontalMarginOffset">
          <xsl:choose>
            <xsl:when test="@D='L' or @D='R'">
              <xsl:choose>
                <xsl:when test="@Attr.MarginAll">
                  <xsl:value-of select="2 * @Attr.MarginAll"/>
                </xsl:when>
                <xsl:when test="@Attr.MarginLeft and @Attr.MarginRight">
                  <xsl:value-of select="@Attr.MarginLeft + @Attr.MarginRight"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="0"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="0"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        <xsl:choose>
        <xsl:when test="@D='B'">
          <xsl:apply-templates select="$varNext" mode="modDocking">
            <xsl:with-param name="prmLeft"		select="$varLeft"/>
            <xsl:with-param name="prmRight"		select="$varRight"/>
            <xsl:with-param name="prmTop"		select="$varTop"/>
            <xsl:with-param name="prmBottom"	select="$varBottom + $varHeight + $varVerticalMarginOffset"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </xsl:when>
        <xsl:when test="@D='T'">
          <xsl:apply-templates select="$varNext" mode="modDocking">
            <xsl:with-param name="prmLeft"		select="$varLeft"/>
            <xsl:with-param name="prmRight"		select="$varRight"/>
            <xsl:with-param name="prmTop"		select="$varTop + $varHeight + $varVerticalMarginOffset"/>
            <xsl:with-param name="prmBottom"	select="$varBottom"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </xsl:when>
        <xsl:when test="@D='L'">
          <xsl:apply-templates select="$varNext" mode="modDocking">
            <xsl:with-param name="prmLeft"		select="$varLeft + $varWidth + $varHorizontalMarginOffset"/>
            <xsl:with-param name="prmRight"		select="$varRight"/>
            <xsl:with-param name="prmTop"		select="$varTop"/>
            <xsl:with-param name="prmBottom"	select="$varBottom"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </xsl:when>
        <xsl:when test="@D='R'">
          <xsl:apply-templates select="$varNext" mode="modDocking">
            <xsl:with-param name="prmLeft"		select="$varLeft"/>
            <xsl:with-param name="prmRight"		select="$varRight + $varWidth + $varHorizontalMarginOffset"/>
            <xsl:with-param name="prmTop"		select="$varTop"/>
            <xsl:with-param name="prmBottom"	select="$varBottom"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </xsl:when>
        <xsl:otherwise>
          <xsl:apply-templates select="$varNext" mode="modDocking">
            <xsl:with-param name="prmLeft"		select="$varLeft"/>
            <xsl:with-param name="prmRight"		select="$varRight"/>
            <xsl:with-param name="prmTop"		select="$varTop"/>
            <xsl:with-param name="prmBottom"	select="$varBottom"/>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
          </xsl:apply-templates>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
  </xsl:template>

  <xsl:template match="*[(@D and not(@D=''))]" mode="modUpdateDockedControl">
    <xsl:param name="prmHandledControl"/>
    <xsl:param name="prmLeft"	select="0"/>
    <xsl:param name="prmRight" select="0"/>
    <xsl:param name="prmTop" select="0"/>
    <xsl:param name="prmBottom" select="0"/>

    <xsl:variable name="varIsHandledControl"	select="@Id=$prmHandledControl/@Id"/>
    <xsl:variable name="varNext" select="following-sibling::*[(@D and not(@D=''))][position()=1]" />
    <xsl:variable name="varWidth"	select="number(not(@Attr.Visible) or @Attr.Visible='1')*@W" />
    <xsl:variable name="varHeight" select="number(not(@Attr.Visible) or @Attr.Visible='1')*@H" />

    <!--In case that current control is the handled control-->
    <xsl:if test="$varIsHandledControl">
      <xsl:apply-templates select="." mode="modLayoutItem">
        <xsl:with-param name="prmLeft"		select="$prmLeft"/>
        <xsl:with-param name="prmRight"		select="$prmRight"/>
        <xsl:with-param name="prmTop"		select="$prmTop"/>
        <xsl:with-param name="prmBottom"	select="$prmBottom"/>
      </xsl:apply-templates>
    </xsl:if>

    <!--In case that current control is not the handled control-->
    <xsl:if test="not($varIsHandledControl)">
      <xsl:if test="$varNext">
        <xsl:choose>
          <xsl:when test="@D='B'">
            <xsl:apply-templates select="$varNext" mode="modUpdateDockedControl">
              <xsl:with-param name="prmHandledControl"		select="$prmHandledControl"/>
              <xsl:with-param name="prmLeft"		select="$prmLeft"/>
              <xsl:with-param name="prmRight"		select="$prmRight"/>
              <xsl:with-param name="prmTop"		select="$prmTop"/>
              <xsl:with-param name="prmBottom"	select="$prmBottom + $varHeight"/>
            </xsl:apply-templates>
          </xsl:when>
          <xsl:when test="@D='T'">
            <xsl:apply-templates select="$varNext" mode="modUpdateDockedControl">
              <xsl:with-param name="prmHandledControl"		select="$prmHandledControl"/>
              <xsl:with-param name="prmLeft"		select="$prmLeft"/>
              <xsl:with-param name="prmRight"		select="$prmRight"/>
              <xsl:with-param name="prmTop"		select="$prmTop + $varHeight"/>
              <xsl:with-param name="prmBottom"	select="$prmBottom"/>
            </xsl:apply-templates>
          </xsl:when>
          <xsl:when test="@D='L'">
            <xsl:apply-templates select="$varNext" mode="modUpdateDockedControl">
              <xsl:with-param name="prmHandledControl"		select="$prmHandledControl"/>
              <xsl:with-param name="prmLeft"		select="$prmLeft + $varWidth"/>
              <xsl:with-param name="prmRight"		select="$prmRight"/>
              <xsl:with-param name="prmTop"		select="$prmTop"/>
              <xsl:with-param name="prmBottom"	select="$prmBottom"/>
            </xsl:apply-templates>
          </xsl:when>
          <xsl:when test="@D='R'">
            <xsl:apply-templates select="$varNext" mode="modUpdateDockedControl">
              <xsl:with-param name="prmHandledControl"		select="$prmHandledControl"/>
              <xsl:with-param name="prmLeft"		select="$prmLeft"/>
              <xsl:with-param name="prmRight"		select="$prmRight + $varWidth"/>
              <xsl:with-param name="prmTop"		select="$prmTop"/>
              <xsl:with-param name="prmBottom"	select="$prmBottom"/>
            </xsl:apply-templates>
          </xsl:when>
          <xsl:otherwise>
            <xsl:apply-templates select="$varNext" mode="modUpdateDockedControl">
              <xsl:with-param name="prmHandledControl"		select="$prmHandledControl"/>
              <xsl:with-param name="prmLeft"		select="$prmLeft"/>
              <xsl:with-param name="prmRight"		select="$prmRight"/>
              <xsl:with-param name="prmTop"		select="$prmTop"/>
              <xsl:with-param name="prmBottom"	select="$prmBottom"/>
            </xsl:apply-templates>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template match="WC:*">
    <xsl:if test="@D and not(@D='')">
      <!--Apply update docked control mode on the control's first sibling which has docking-->
      <xsl:apply-templates select="../*[@D and not(@D='')][position()=1]" mode="modUpdateDockedControl">
        <xsl:with-param name="prmHandledControl" select="."/>
      </xsl:apply-templates>
    </xsl:if>
    <xsl:if test="not(@D) or @D=''">
      <xsl:apply-templates select="." mode="modLayoutItem"/>
    </xsl:if>
  </xsl:template>

  <migration-ignore>
    <xsl:template match="WG:Tags.Response">
      <xsl:if test="not(@vwg_redraw='1')">
        <xsl:apply-templates select="//*[@vwg_redraw='1']" />
      </xsl:if>
      <xsl:if test="@vwg_redraw='1'">
        <xsl:apply-templates select="Tags.Menu[position()=1] | WG:Tags.Form[position()=1]" />
      </xsl:if>
    </xsl:template>
  </migration-ignore>

  <!-- Render Containd Controls -->
  <xsl:template name="tplDrawContained">
    <xsl:param name="prmLayoutType" select="'B'" />
    <xsl:param name="prmAutoSizeMode" select="'0'"/>
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmNodes" select="*[not(@Attr.AutoDrawn=0)]"/>
    <xsl:param name="prmBottom" select="0"/>
    <xsl:param name="prmTop" select="0"/>
    <xsl:param name="prmLeft" select="0"/>
    <xsl:param name="prmRight" select="0"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varPaddingAll" select="@Attr.PaddingAll" />
    <xsl:variable name="varPaddingLeft" select="@Attr.PaddingLeft" />
    <xsl:variable name="varPaddingRight" select="@Attr.PaddingRight" />
    <xsl:variable name="varPaddingTop" select="@Attr.PaddingTop" />
    <xsl:variable name="varPaddingBottom" select="@Attr.PaddingBottom" />

    <xsl:variable name="varHasControls" select="count($prmNodes) &gt; 0"/>
    <xsl:variable name="varHasDockedControls" select="count($prmNodes[@D and not(@D='')]) &gt; 0"/>
    <xsl:variable name="varHasAnchoredControls" select="count($prmNodes[@A and not(@A='')]) &gt; 0"/>
    <xsl:variable name="varHasValidControls" select="(($prmLayoutType='B' or $prmLayoutType='A') and $varHasAnchoredControls) or (($prmLayoutType='B' or $prmLayoutType='D') and $varHasDockedControls) or ($prmLayoutType='C' and $varHasControls)"/>

    <xsl:if test="not($varHasValidControls)">
      <div style="overflow:hidden"><xsl:call-template name="tplDrawEmptyImage"/></div>
    </xsl:if>
    <xsl:if test="$varHasValidControls">
      <xsl:if test="@Attr.Scrollbars and (@Attr.Scrollbars='B' or @Attr.Scrollbars='H' or @Attr.Scrollbars='V')">
        <xsl:call-template name="tplCompleteScrollCapabilities" />
      </xsl:if>
      <div data-cp="Contained">
        <xsl:attribute name="id">Contained<xsl:value-of select="@Attr.Id" /></xsl:attribute>
        <xsl:if test="@Attr.Scrollbars and (@Attr.Scrollbars='B' or @Attr.Scrollbars='H' or @Attr.Scrollbars='V')">
          <xsl:call-template name="tplApplyScrollableAttributes"/>
        </xsl:if>
        <xsl:attribute name="style">
          <xsl:if test="$prmAutoSizeMode='0'">position:absolute;</xsl:if>left:<xsl:value-of select="$prmLeft" />px;right:<xsl:value-of select="$prmRight" />px;top:<xsl:value-of select="$prmTop" />px;bottom:<xsl:value-of select="$prmBottom" />px;
        </xsl:attribute>
        <div data-vwgtype="container">
          <xsl:attribute name="style">
            position:relative;width:100%;height:100%;
            <xsl:if test="@Attr.MinimumClientWidth and not(@Attr.MinimumClientWidth='')">
              min-width:<xsl:value-of select="@Attr.MinimumClientWidth"/>px;
            </xsl:if>
            <xsl:if test="@Attr.MinimumClientHeight and not(@Attr.MinimumClientHeight='')">
              min-height:<xsl:value-of select="@Attr.MinimumClientHeight"/>px;
            </xsl:if>
          </xsl:attribute>
          <xsl:attribute name="data-vwgpaddingleft">
            <xsl:if test="$varPaddingAll">
              <xsl:value-of select="$varPaddingAll"/>
            </xsl:if>
            <xsl:if test="not($varPaddingAll)">
              <xsl:if test="$varPaddingLeft">
                <xsl:value-of select="$varPaddingLeft"/>
              </xsl:if>
              <xsl:if test="not($varPaddingLeft)">0</xsl:if>
            </xsl:if>
          </xsl:attribute>
          <xsl:attribute name="data-vwgpaddingright">
            <xsl:if test="$varPaddingAll">
              <xsl:value-of select="$varPaddingAll"/>
            </xsl:if>
            <xsl:if test="not($varPaddingAll)">
              <xsl:if test="$varPaddingRight">
                <xsl:value-of select="$varPaddingRight"/>
              </xsl:if>
              <xsl:if test="not($varPaddingRight)">0</xsl:if>
            </xsl:if>
          </xsl:attribute>
          <xsl:attribute name="data-vwgpaddingtop">
            <xsl:if test="$varPaddingAll">
              <xsl:value-of select="$varPaddingAll"/>
            </xsl:if>
            <xsl:if test="not($varPaddingAll)">
              <xsl:if test="$varPaddingTop">
                <xsl:value-of select="$varPaddingTop"/>
              </xsl:if>
              <xsl:if test="not($varPaddingTop)">0</xsl:if>
            </xsl:if>
          </xsl:attribute>
          <xsl:attribute name="data-vwgpaddingbottom">
            <xsl:if test="$varPaddingAll">
              <xsl:value-of select="$varPaddingAll"/>
            </xsl:if>
            <xsl:if test="not($varPaddingAll)">
              <xsl:if test="$varPaddingBottom">
                <xsl:value-of select="$varPaddingBottom"/>
              </xsl:if>
              <xsl:if test="not($varPaddingBottom)">0</xsl:if>
            </xsl:if>
          </xsl:attribute>
          <xsl:choose>
            <xsl:when test="$prmAutoSizeMode='1'">
              <xsl:apply-templates select="$prmNodes" mode="modAutoSize">
                <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation"/>
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:apply-templates>
            </xsl:when>
            <xsl:otherwise>
              <xsl:if test="$prmLayoutType='B' or $prmLayoutType='D'">
                <xsl:if test="$prmNodes[(@D and not(@D=''))][position()=1]">
                  <xsl:apply-templates select="$prmNodes[(@D and not(@D=''))][position()=1]" mode="modDocking">
                    <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                  </xsl:apply-templates>
                </xsl:if>
              </xsl:if>
              <xsl:if test="$prmLayoutType='B' or $prmLayoutType='A'">
                <xsl:apply-templates select="$prmNodes[(@A and not(@A=''))]" mode="modLayoutItem">
                  <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                </xsl:apply-templates>
              </xsl:if>
              <xsl:if test="$prmLayoutType='C'">
                <xsl:apply-templates select="$prmNodes" mode="modLayoutItem">
                  <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                </xsl:apply-templates>
              </xsl:if>
            </xsl:otherwise>
          </xsl:choose>
        </div>
        <xsl:if test="@Attr.Scrollbars and (@Attr.Scrollbars='B' or @Attr.Scrollbars='H' or @Attr.Scrollbars='V')">
          <xsl:apply-templates select="." mode="modScrollbars" />
        </xsl:if>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawAnchoredStyle">
    <xsl:param name="prmShowError" select="@Attr.ErrorMessage and not(@Attr.ErrorMessage='')"/>
    <xsl:variable name="varWidth" select="@Attr.Width"/>
    <xsl:variable name="varHeight" select="@Attr.Height"/>

    position:absolute;
    <xsl:choose>
      <xsl:when test="$prmShowError and (number($varWidth) &gt; 0 and number($varHeight) &gt; 0)">overflow:visible;</xsl:when>
      <xsl:otherwise>overflow:hidden;</xsl:otherwise>
    </xsl:choose>
    <xsl:if test="contains(@A,'R')">
      <xsl:value-of select="$pright"/>:<xsl:value-of select="@R"/>px;
    </xsl:if>
    <xsl:if test="contains(@A,'L')">
      <xsl:value-of select="$pleft"/>:<xsl:value-of select="@L"/>px;
    </xsl:if>
    <xsl:if test="contains(@A,'T')">
      top:<xsl:value-of select="@T"/>px;
    </xsl:if>
    <xsl:if test="contains(@A,'B')">
      bottom:<xsl:value-of select="@B"/>px;
    </xsl:if>
    <xsl:if test="contains(@A,'V')">
      top:<xsl:value-of select="@T"/>px;
    </xsl:if>
    <xsl:if test="contains(@A,'H')">
      <xsl:value-of select="$pleft"/>:<xsl:value-of select="@L"/>px;
    </xsl:if>
    <xsl:if test="$varHeight and (not(contains(@A,'T') and contains(@A,'B')))">
      height:<xsl:value-of select="$varHeight"/>px;
    </xsl:if>
    <xsl:if test="$varWidth and (not(contains(@A,'L') and contains(@A,'R')))">
      width:<xsl:value-of select="$varWidth"/>px;
    </xsl:if>
  </xsl:template>

  <!-- modLayoutItem item -->
  <xsl:template match="*" mode="modLayoutItem">
    <xsl:param name="prmLeft"		select="0"/>
    <xsl:param name="prmRight"		select="0"/>
    <xsl:param name="prmTop"		select="0"/>
    <xsl:param name="prmBottom"		select="0"/>
    <xsl:param name="prmIsNoneAnchored" select="contains(@A,'V') or contains(@A,'H') and (@A and not(@A=''))"/>
    <xsl:param name="prmVisible" select="not(@Attr.Visible='0')" />
    <xsl:param name="prmIsEnabled" />


    <xsl:variable name="varIsEnabled">
      <xsl:call-template name="tplIsEnabled">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:variable>

    <xsl:variable name="varError" select="@Attr.ErrorMessage and not(@Attr.ErrorMessage='')"/>
    <xsl:variable name="varApplyMargin" select="(@Attr.MarginAll or @Attr.MarginLeft or @Attr.MarginRight or @Attr.MarginTop or @Attr.MarginBottom)" />

    <xsl:if test="$prmIsNoneAnchored">
      <div data-vwgvisible="{number($prmVisible)}" data-vwgtype="control" data-vwgdocking="{@D}">
        <xsl:attribute name="style">
          position:absolute;overflow:visible;
          <xsl:if test="contains(@A,'H')">left:50%;width:0px;</xsl:if>
          <xsl:if test="contains(@A,'V')">top:50%;height:0px;</xsl:if>
          <xsl:if test="not(contains(@A,'H'))">left:0px;width:100%;</xsl:if>
          <xsl:if test="not(contains(@A,'V'))">top:0px;height:100%;</xsl:if>
        </xsl:attribute>
        <xsl:apply-templates select="." mode="modLayoutItem">
          <xsl:with-param name="prmLeft"		select="$prmLeft"/>
          <xsl:with-param name="prmRight"		select="$prmRight"/>
          <xsl:with-param name="prmTop"		select="$prmTop"/>
          <xsl:with-param name="prmBottom"	select="$prmBottom"/>
          <xsl:with-param name="prmIsNoneAnchored" select="0"/>
          <xsl:with-param name="prmIsEnabled" select="$varIsEnabled"/>
        </xsl:apply-templates>
      </div>
    </xsl:if>
    <xsl:if test="not($prmIsNoneAnchored)">
      <div data-vwgvisible="{number($prmVisible)}" data-vwgdocking="{@D}" data-vwgtype="control">
        <xsl:call-template name="tplSetControl" >
          <xsl:with-param name="prmIsEnabled" select="$varIsEnabled" />
        </xsl:call-template>
        <xsl:attribute name="style">
          <xsl:if test="not(@A) or @A=''">position:absolute;overflow:hidden;</xsl:if>
          <xsl:if test="not($prmVisible)">display:none;</xsl:if>
          <xsl:if test="@Attr.IsDelayedDrawing='1'">visibility:hidden;</xsl:if>
          <xsl:if test="$varApplyMargin"><xsl:call-template name="tplApplyMargins"/></xsl:if>

          <!--Set positions for docked control-->
          <xsl:if test="@D='L' or @D='R' or @D='F'">top:<xsl:value-of select="$prmTop"/>px;bottom:<xsl:value-of select="$prmBottom"/>px;</xsl:if>
          <xsl:if test="@D='L' or @D='R'">width:<xsl:value-of select="@W"/>px;</xsl:if>
          <xsl:if test="@D='L'">left:<xsl:value-of select="$prmLeft"/>px;</xsl:if>
          <xsl:if test="@D='R'">right:<xsl:value-of select="$prmRight"/>px;</xsl:if>
          <xsl:if test="@D='T' or @D='B' or @D='F'">left:<xsl:value-of select="$prmLeft"/>px;right:<xsl:value-of select="$prmRight"/>px;</xsl:if>
          <xsl:if test="@D='T' or @D='B'">height:<xsl:value-of select="@H"/>px;</xsl:if>
          <xsl:if test="@D='T'">top:<xsl:value-of select="$prmTop"/>px;</xsl:if>
          <xsl:if test="@D='B'">bottom:<xsl:value-of select="$prmBottom"/>px;</xsl:if>

          <!--Draw control with anchor style-->
          <xsl:if test="(@A and not(@A=''))">
            <xsl:call-template name="tplDrawAnchoredStyle">
              <xsl:with-param name="prmShowError" select="$varError"/>
            </xsl:call-template>
          </xsl:if>

          <xsl:call-template name="tplApplyMinMaxSizeStyle" />
          <xsl:if test="not($varError)">
            <xsl:apply-templates mode="modApplyStyle" select="." />
          </xsl:if>
        </xsl:attribute>

        <xsl:choose>
          <xsl:when test="not(@Attr.Visible='0') and not(@Attr.IsDelayedDrawing='1')">
            <xsl:if test="not($varError)">
              <xsl:apply-templates select="." mode="modContent" >
                <xsl:with-param name="prmIsEnabled" select="$varIsEnabled" />
              </xsl:apply-templates>
            </xsl:if>
          </xsl:when>
          <xsl:otherwise><xsl:call-template name="tplDrawEmptyImage"/></xsl:otherwise>
        </xsl:choose>
        <xsl:call-template name="tplApplyAfterDrawVisualEffects" />
        <xsl:if test="$varError">
          <xsl:apply-templates select="." mode="modErrorMessage">
            <xsl:with-param name="prmIsEnabled" select="$varIsEnabled" />
          </xsl:apply-templates>
        </xsl:if>
        <xsl:apply-templates select="." mode="modToolTip">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        </xsl:apply-templates>
        <xsl:call-template name="tplApplyUICapabilities" >
          <xsl:with-param name="prmIsEnabled" select="$varIsEnabled" />
        </xsl:call-template>
        <xsl:call-template name="tplApplySelectedIndicator"/> 
      </div>     
    </xsl:if>
  </xsl:template>

  <xsl:template match="*" mode="modErrorMessage">
    <xsl:param name="prmIsEnabled" />
    <div>
      <xsl:attribute name="style">
        position:absolute;width:100%;height:100%;overflow:hidden;
        <xsl:apply-templates mode="modApplyStyle" select="."/>
      </xsl:attribute>
      <xsl:apply-templates select="." mode="modContent">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </div>
    <xsl:call-template name="tplDrawErrorIcon" />
  </xsl:template>

  <!-- Draws a 9ner frame content -->
  <xsl:template name="tplDrawFrameContent">

    <!-- Parameters -->
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmCenterContent"/>
    <xsl:param name="prmIsEnabled" />

    <div class="{$prmContentClass} Common-FrameContent" data-vwgtype="control" data-vwgvisible="1">
      <xsl:apply-templates select="$prmCenterContent" mode="modFrameCenterContent">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </div>
  </xsl:template>

  <xsl:template name="tplApplyMinMaxResizeHandler"></xsl:template>

  <xsl:template name="tplDrawEditingTextInput">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmInputClass" select="'TextBox-Input'" />
    <xsl:param name="prmApplyFontStyles" select="'1'" />
    <xsl:param name="prmKeyDownHandler">
        mobjApp.Common_EditingControlInputKeyDown(this,'<xsl:value-of select="@Attr.Id" />',event,window);
    </xsl:param>
    <xsl:param name="prmBlurHandler">
        mobjApp.Common_EditingControlInputKeyBlur(this,'<xsl:value-of select="@Attr.Id" />',event,window);
    </xsl:param>
    <xsl:param name="prmMouseDownHandler">
        mobjApp.Web_EventCancelBubble(event, false, true);
    </xsl:param>
    <xsl:param name="prmMouseClickHandler">
        mobjApp.Web_EventCancelBubble(event, false, true);
    </xsl:param>
    
    <input type="text" class="{$prmInputClass}" data-vwgeditable="1">
      <xsl:attribute name="value">
        <xsl:call-template name="tplDecodeText">
          <xsl:with-param name="prmText" select="$prmText"/>
        </xsl:call-template>
      </xsl:attribute>      
      <xsl:attribute name="style">
        <xsl:if test="$prmApplyFontStyles='1'">
          <xsl:call-template name="tplApplyFontStyles" />
        </xsl:if>
      </xsl:attribute>
      <xsl:attribute name="onkeydown"><xsl:value-of select="$prmKeyDownHandler"/></xsl:attribute>
      <xsl:attribute name="onblur"><xsl:value-of select="$prmBlurHandler"/></xsl:attribute>
      <xsl:attribute name="onmousedown"><xsl:value-of select="$prmMouseDownHandler"/></xsl:attribute>
      <xsl:attribute name="onclick"><xsl:value-of select="$prmMouseClickHandler"/></xsl:attribute>
    </input>
  </xsl:template>
</xsl:stylesheet>
