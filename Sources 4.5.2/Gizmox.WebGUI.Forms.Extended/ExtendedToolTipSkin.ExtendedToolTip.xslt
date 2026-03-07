<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
    <xsl:template match="WC:*[@Attr.ExtendedToolTipKey='ExtendedToolTip']" mode="modToolTip">
        <xsl:call-template name="tplSetExtendedToolTipAPI">
            <xsl:with-param name="prmSkinPath" select="'[Skin.Path]'"/>
        </xsl:call-template>
    </xsl:template>
</xsl:stylesheet>