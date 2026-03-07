<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">


    <xsl:template match="WC:Tags.Object" mode="modContent">
        <xsl:variable name="varObjectType" select="@Attr.ObjectType"/>
        <xsl:variable name="varParams" select="./Tags.Param"/>
        <xsl:variable name="varCodeBase" select="$varParams[@Attr.Name='codebase']"/>
        <xsl:variable name="varClassId" select="$varParams[@Attr.Name='classid']"/>
        <xsl:variable name="varObjectData" select="@Attr.Data"/>
        <object id="TRG_{@Id}" style="width:100%; height:100%; margin:0;">
            <xsl:if test="$varObjectType and not($varObjectType='')">
                <xsl:attribute name="type">
                    <xsl:value-of select="$varObjectType"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$varClassId and not($varClassId/@Attr.Value='') and not($varObjectType) and not($varObjectData)">
                <xsl:attribute name="classid">
                    <xsl:value-of select="$varClassId/@Attr.Value"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$varCodeBase and not($varCodeBase/@Attr.Value='') and not($varObjectType) and not($varObjectData)">
                <xsl:attribute name="codebase">
                    <xsl:value-of select="$varCodeBase/@Attr.Value"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$varObjectData and not($varObjectData='')">
                <xsl:attribute name="data">
                    <xsl:value-of select="$varObjectData"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:for-each select="$varParams">
                <param name="{@Attr.Name}" value="{@Attr.Value}" />
            </xsl:for-each>
        </object>
    </xsl:template>

</xsl:stylesheet>

