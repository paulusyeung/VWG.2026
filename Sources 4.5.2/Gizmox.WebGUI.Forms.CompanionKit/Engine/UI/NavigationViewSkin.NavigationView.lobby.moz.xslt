<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
	
	<xsl:template name="tplSetText">
		<migration-ignore>
		<xsl:param name="string"/>
			<img src="[Skin.CommonPath]Empty.gif.wgx" onload="$(this).replaceWith($(this).attr('vwgsource'))">
			<xsl:attribute name="vwgsource">
				<xsl:call-template name="tplDecodeText">
					<xsl:with-param name="prmText" select="$string"/>
				</xsl:call-template>
			</xsl:attribute>
		</img>
		</migration-ignore>
		<migration-write>
			objWriter.write(objArgs.string);
		</migration-write>
	</xsl:template>		
	
</xsl:stylesheet>