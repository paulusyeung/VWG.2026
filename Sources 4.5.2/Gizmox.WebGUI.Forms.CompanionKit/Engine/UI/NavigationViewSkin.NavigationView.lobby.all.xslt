<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
	
	<xsl:template name="tplSetText">
		<migration-ignore>
			<xsl:param name="string"/>
			<!-- 
				Mozilla ignores the d-o-e and escapes output HTML
				That is the reason to split the implementation.
			-->
			<xsl:value-of select="$string" disable-output-escaping="yes"/>
		</migration-ignore>
		<migration-write>
			objWriter.write(objArgs.string);
		</migration-write>
	</xsl:template>	

</xsl:stylesheet>