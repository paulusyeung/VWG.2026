<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols"
	xmlns:msxml="urn:schemas-microsoft-com:xslt" xmlns:Common="http://www.gizmox.com/webgui/common">

  <xsl:template match="WC:Tags.TableLayoutPanel" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTableLayoutPanelAPI" >    
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Table layout -->
  <xsl:template name="tplDrawTableLayoutPanelAPI">
    <xsl:param name="prmTableLayoutPanelControlClass" select="'TableLayoutPanel-Control'"/>
    <xsl:param name="prmIsEnabled" />
                    
    <xsl:variable name="varCols" select="Tags.TableLayoutCol" />
    <xsl:variable name="varRows" select="Tags.TableLayoutRow" />
    <xsl:variable name="varControls" select="WC:*" migration-select="this.xpath(&quot;WC:*&quot;)"/>
    <xsl:variable name="varBorderstyle" select="@Attr.BorderStyle" />

    <xsl:attribute name="class">
      <xsl:value-of select="$prmTableLayoutPanelControlClass" />
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' Common-InheritDisabled ',$prmTableLayoutPanelControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <div class="TableLayoutPanel-Table">
      <xsl:attribute name="style">
        <xsl:text>width:100%;height:100%;</xsl:text>
        <xsl:if test="$varBorderstyle">
          <xsl:call-template name="tplTableLayoutPanelSetBorderStyle">
            <xsl:with-param name="prmBorderstyle" select="$varBorderstyle" />
            <xsl:with-param name="prmFullBorder" select="'1'" />            
          </xsl:call-template>
        </xsl:if>
      </xsl:attribute>
      <xsl:for-each select="$varRows" migration-index="intRowIndex">
        <xsl:variable name="varRow" select="position()-1" migration-select="intRowIndex"/>
        <div class="TableLayoutPanel-Row" >
          <xsl:for-each select="$varCols" migration-index="intColumnIndex">
            <xsl:variable name="varCol" select="position()-1" migration-select="intColumnIndex"/>
            <xsl:variable name="varControl" select="$varControls[contains(concat(',',@Attr.Rows,','),concat(',',$varRow,','))and contains(concat(',',@Attr.Cols,','),concat(',',$varCol,','))]" />

            <xsl:variable name="varColCurrent" select="$varCols[position() = ($varCol + 1)]" />
            <xsl:variable name="varRowCurrent" select="$varRows[position() = ($varRow + 1)]" />
            
            <xsl:if test="count($varControl) > 0 and starts-with(concat($varControl/@Attr.Rows,','),concat($varRow,',')) and starts-with(concat($varControl/@Attr.Cols,','),concat($varCol,','))">
              <xsl:call-template name="tplTableLayoutPanelDrawCell" >
                <xsl:with-param name="prmColCurrent" select="$varColCurrent" />
                <xsl:with-param name="prmRowCurrent" select="$varRowCurrent" />
                <xsl:with-param name="prmRowAfterSpan" select="$varRows[position() = ($varRow + number($varControl/@Attr.Rowspan))]" />
                <xsl:with-param name="prmColAfterSpan" select="$varCols[position() = ($varCol + number($varControl/@Attr.Colspan))]" />
                <xsl:with-param name="prmCell" select="$varControl"/>
                <xsl:with-param name="prmBorderstyle" select="$varBorderstyle"/>
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </xsl:if>
            <xsl:if test="count($varControl)=0">
              <xsl:call-template name="tplTableLayoutPanelDrawCell" >
                <xsl:with-param name="prmColCurrent" select="$varColCurrent"/>
                <xsl:with-param name="prmRowCurrent" select="$varRowCurrent" />
                <xsl:with-param name="prmRowAfterSpan" select="$varRowCurrent" />
                <xsl:with-param name="prmColAfterSpan" select="$varColCurrent" />
                <xsl:with-param name="prmCell" select="$varControl"/>
                <xsl:with-param name="prmBorderstyle" select="$varBorderstyle"/>
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </xsl:if>
          </xsl:for-each>
        </div>
      </xsl:for-each>
    </div>
  </xsl:template>


  <xsl:template name="tplTableLayoutPanelDrawCell">
    <xsl:param name="prmColCurrent" />
    <xsl:param name="prmRowCurrent" />
    <xsl:param name="prmColAfterSpan" />
    <xsl:param name="prmRowAfterSpan" />
    <xsl:param name="prmCell" />
    <xsl:param name="prmBorderstyle" />
    <xsl:param name="prmIsEnabled" />

    <xsl:if test="$prmBorderstyle or count($prmCell) > 0">
      <div class="Common-VAlignTop TableLayoutPanel-Cell" dir="ltr">
        <xsl:attribute name="style">
          <xsl:if test="$prmBorderstyle">
            <xsl:call-template name="tplTableLayoutPanelSetBorderStyle">
              <xsl:with-param name="prmBorderstyle" select="$prmBorderstyle" />
            </xsl:call-template>
          </xsl:if>
          <xsl:if test="$dir='LTR'" >
            top:<xsl:value-of select="$prmRowCurrent/@Attr.Top"/>&#37;;margin-top:<xsl:value-of select="$prmRowCurrent/@Attr.MarginTop"/>px;bottom:<xsl:value-of select="$prmRowAfterSpan/@Attr.Bottom"/>&#37;;margin-bottom:<xsl:value-of select="$prmRowAfterSpan/@Attr.MarginBottom"/>px;left:<xsl:value-of select="$prmColCurrent/@Attr.Left"/>&#37;;margin-left:<xsl:value-of select="$prmColCurrent/@Attr.MarginLeft"/>px;right:<xsl:value-of select="$prmColAfterSpan/@Attr.Right"/>&#37;;margin-right:<xsl:value-of select="$prmColAfterSpan/@Attr.MarginRight"/>px;
          </xsl:if>
          <xsl:if test="$dir='RTL'" >
            <!-- When in RTL mode, I switch the left/right values to get the mirror look. -->
            top:<xsl:value-of select="$prmRowCurrent/@Attr.Top"/>&#37;;margin-top:<xsl:value-of select="$prmRowCurrent/@Attr.MarginTop"/>px;bottom:<xsl:value-of select="$prmRowAfterSpan/@Attr.Bottom"/>&#37;;margin-bottom:<xsl:value-of select="$prmRowAfterSpan/@Attr.MarginBottom"/>px;left:<xsl:value-of select="$prmColAfterSpan/@Attr.Right"/>&#37;;margin-left:<xsl:value-of select="$prmColAfterSpan/@Attr.MarginRight"/>px;right:<xsl:value-of select="$prmColCurrent/@Attr.Left"/>&#37;;margin-right:<xsl:value-of select="$prmColCurrent/@Attr.MarginLeft"/>px;
          </xsl:if>
        </xsl:attribute>
        <xsl:if test="count($prmCell) > 0">
          <div style="position:relative;width:100%;height:100%" class="Common-FlexContainer">
            <xsl:for-each select="$prmCell">
              <xsl:apply-templates select="." mode="modLayoutItem">
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
              </xsl:apply-templates>
            </xsl:for-each>
          </div>
        </xsl:if>
      </div>
    </xsl:if>
  </xsl:template>
  
  
  <xsl:template name="tplTableLayoutPanelSetBorderStyle">
    <xsl:param name="prmBorderstyle"/>
    <xsl:param name="prmFullBorder" select="'0'"/>

    <xsl:if test="$prmBorderstyle">
      <xsl:choose>
        <xsl:when test="$prmFullBorder='0'">
          <xsl:choose>
            <xsl:when test="$prmBorderstyle='1'">border-top:thin solid Gray; border-Left:thin solid Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='2'">border-top:thin inset Gray; border-left:thin inset Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='3'">border-top:medium inset Gray; border-left:medium inset Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='4'">border-top:thin outset Gray; border-left:thin outset Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='5' or $prmBorderstyle='6'">border-top:medium outset Gray; border-top:medium outset Gray;</xsl:when>
          </xsl:choose>
        </xsl:when>
        <xsl:when test="$prmFullBorder='1'">
          <xsl:choose>
            <xsl:when test="$prmBorderstyle='1'">border:thin solid Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='2'">border:thin inset Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='3'">border:medium inset Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='4'">border:thin outset Gray;</xsl:when>
            <xsl:when test="$prmBorderstyle='5' or $prmBorderstyle='6'">border:medium outset Gray;</xsl:when>
          </xsl:choose>
        </xsl:when>
      </xsl:choose>
      
    </xsl:if>
  </xsl:template>
  
  <xsl:template match="WC:Tags.TableLayoutPanel/*[(@D and not(@D=''))]" mode="modUpdateDockedControl">
    <xsl:param name="prmHandledControl"/>

    <xsl:apply-templates select="$prmHandledControl" mode="modLayoutItem"/>
  </xsl:template>
  
</xsl:stylesheet>
