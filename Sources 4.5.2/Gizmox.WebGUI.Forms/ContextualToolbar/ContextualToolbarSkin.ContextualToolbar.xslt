<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.CustomStyle='ContextualToolbar']">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>

    <xsl:call-template name="tplDrawContextualToolbarContainerAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>      
  </xsl:template>

  <xsl:template name="tplDrawContextualToolbarContainerAPI">    
    <xsl:param name="prmContextualToolbarContainerClass" select="'ContextualToolbar-Container'" />
    <xsl:param name="prmIsEnabled" />
    
    <xsl:variable name="varContextualToolbar" select="."/>
                  
    <div>
      <xsl:call-template name="tplSetControl" />
      <xsl:attribute name="class">
        <xsl:value-of select="$prmContextualToolbarContainerClass"/>
      </xsl:attribute>
      <xsl:if test="$dir='RTL'"><xsl:attribute name="dir">rtl</xsl:attribute></xsl:if>

      <!-- The AlignToId will contain the component that the contextual toolbar is related to. -->
      <xsl:variable name="varAlignToId" select="@Attr.AlignTo" />
      <xsl:variable name="varAlignedObject" select="//*[@Id=$varAlignToId]"  migration-select="this.xpath(&quot;//*[@Id = &quot; + varAlignToId + &quot;]&quot;);"/>

      <xsl:apply-templates select="$varAlignedObject" mode="modContextualToolbarButtons" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        <xsl:with-param name="prmContextualToolbar" select="$varContextualToolbar" />
      </xsl:apply-templates>

    </div>
  </xsl:template>

  <xsl:template match="*" mode="modContextualToolbarButtons">
    <xsl:param name="prmContextualToolbar" />
    <xsl:param name="prmIsEnabled" />
      
    <xsl:call-template name="tplDrawContextualToolbarContainerButtonsAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmContextualToolbar" select="$prmContextualToolbar" />
    </xsl:call-template>      
  </xsl:template>

  <xsl:template name="tplDrawContextualToolbarContainerButtonsAPI">
    <xsl:param name="prmContextualToolbar" />
    <xsl:param name="prmIsEnabled" />
    
     <xsl:variable name="varContextualToolbarAlignTo" select="$prmContextualToolbar/@Attr.AlignTo"/> 
    
    <xsl:variable name="varContextualToolbarButtons" select="$prmContextualToolbar/*" />
    <xsl:for-each select="$varContextualToolbarButtons" >
      <xsl:apply-templates select="." mode="modContextualToolbarButton" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </xsl:for-each>
    
  </xsl:template>

  <xsl:template match="WC:Tags.ContextualToolbarButton" mode="modContextualToolbarButton">
      <xsl:param name="prmIsEnabled" />
    

    <xsl:call-template name="tplDrawContextualToolbarButtonAPI">
          <xsl:with-param name="prmContextualToolbarButtonClass" select="'ContextualToolbar-Button'" />
          <xsl:with-param name="prmContextualToolbarButtonImageContainerClass" select="'ContextualToolbar-ButtonImage'" />    
    </xsl:call-template>
  </xsl:template>
 
  <xsl:template name="tplDrawContextualToolbarButtonAPI">
    <xsl:param name="prmContextualToolbarButtonClass" select="'ContextualToolbar-Button'" />
    <xsl:param name="prmContextualToolbarButtonImageContainerClass" select="'ContextualToolbar-ButtonImage'" />
    <xsl:param name="prmContextualToolbarButtonPropertyName" select="@Attr.Name" />
    <xsl:param name="prmContextualToolbarButtonToolTip" select="@Attr.ToolTip" />
    <xsl:param name="prmContextualToolbarButtonImage" select="@Attr.Image" />
    <xsl:param name="prmContextualToolbarAlignTo" select="../@Attr.AlignTo" />

    <xsl:param name="varContextualButtonPosition" select="position()" />
    <div>
      <xsl:attribute name="title">
        <xsl:value-of select="$prmContextualToolbarButtonToolTip"/>
      </xsl:attribute>
      <xsl:attribute name="class"><xsl:value-of select="$prmContextualToolbarButtonClass"/><xsl:if test="$varContextualButtonPosition = 1"><xsl:value-of select="concat(' ',$prmContextualToolbarButtonClass,'_First')"/></xsl:if>        
      </xsl:attribute>
      <a>
        <xsl:attribute name="onclick" >
          <xsl:value-of select="concat('ContextualToolbar_ButtonClick(this, &quot;', $prmContextualToolbarButtonPropertyName ,'&quot;,&quot;', $prmContextualToolbarAlignTo, '&quot;);')"/>
        </xsl:attribute>
        <div>
          <xsl:attribute name="class">
            <xsl:value-of select="$prmContextualToolbarButtonImageContainerClass"/>
          </xsl:attribute>
          <xsl:attribute name="style">background-image:url(<xsl:value-of select="$prmContextualToolbarButtonImage"/>);</xsl:attribute>
        </div>
      </a>
    </div>
  </xsl:template>

</xsl:stylesheet>