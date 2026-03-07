<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.PictureBox" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:variable name="varImage" select="@Attr.Image"/>

    <img src="{$varImage}" onmousedown="mobjApp.Web_EventCancelBubble(event,true,false);" alt=""></img>
  </xsl:template>
  
	<xsl:template name="tplMatchPictureBoxNormal" match="WC:Tags.PictureBox" mode="modContent">
    <xsl:param name="prmControlClass" select="'PictureBox-Control'"/>
    <xsl:param name="prmImageSize" select="@Attr.ImageSize"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varImage" select="@Attr.Image"/>
    <xsl:variable name="varControls" select="WC:*"/>

    <!-- Set the control class -->
    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <div style="width:100%;height:100%;overflow:hidden;">     
        <xsl:if test="$varImage">
        <xsl:choose>
          <xsl:when test="$prmImageSize=1">
            <img src="{$varImage}" style="width:100%;height:100%" alt="">
              <xsl:attribute name="onmousedown">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
            </img>
          </xsl:when>
          <xsl:when test="$prmImageSize=3">
            <table class="Common-CellPadding0 Common-CellSpacing0" style="width:100%;height:100%;">
              <tr>
                <td>
                  <xsl:attribute name="style">
                    background-image:url('<xsl:value-of select="$varImage"/>');
                    background-repeat:no-repeat;background-position:center center;width:100%;height:100%
                  </xsl:attribute>
                </td>
              </tr>
            </table>
          </xsl:when>          
          <xsl:otherwise>
            <img src="{$varImage}" alt="">
              <xsl:attribute name="onmousedown">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
            </img>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:if>
      <xsl:if test="$varControls">
        <div class="Common-Strech" style="position:absolute;top:0px;left:0px;">
          <xsl:call-template name="tplDrawContained">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
        </div>
      </xsl:if>
      <xsl:if test="not($varImage) and not($varControls)"><xsl:call-template name="tplDrawEmptyImage"/></xsl:if>
    </div>
	</xsl:template>

  <xsl:template match="WC:Tags.PictureBox[@Attr.Image]" mode="modDragged">
    <div>
      <xsl:attribute name="style">
        overflow:hidden;
        <xsl:if test="@Attr.Width and @Attr.Height">
          width:<xsl:value-of select="@Attr.Width"/>px;
          height:<xsl:value-of select ="@Attr.Height"/>px;
        </xsl:if>
        <xsl:if test="not(@Attr.Width) or not(@Attr.Height)">width:100px;height:100px;</xsl:if>
      </xsl:attribute>
      <img src="{@Attr.Image}" alt="">
        <xsl:attribute name="onmousedown">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
      </img>
    </div>
    <!--</div>-->
  </xsl:template>
</xsl:stylesheet>

