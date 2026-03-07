<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
               
	<xsl:template name="tplPageLobby">
		<xsl:param name="prmOwner"/>
		<xsl:param name="prmIsLabelEdit"/>

		<div class="GZNV_LobyHeader">
			<div style="float:left; overflow:visible;margin-top:10px;">
				<img src="[Skin.Path]favicon.png.wgx" align="absmiddle" />
				<xsl:text>&#160;</xsl:text>
				<xsl:value-of select="@Attr.Text"/>
			</div>
			<!-- Draw a button to open popup of themes -->
			<div style="position:relative; float:right; width:25px; margin-top:12px;">
				<img src="[Skin.Path]links.png.wgx" title="Press to get links to browse and download" onclick="NavigationView_ShowLinks({$prmOwner/@Id});" style='margin-left:2px;margin-right:5px;cursor:pointer;vertical-align:middle;'/>
			</div>
			<xsl:call-template name="tplShare"/>
		</div>
		<xsl:apply-templates select="GZSECTIONS/Section">
			<xsl:with-param name="prmBodyWidth" select="890"/>
			<xsl:with-param name="prmOwner" select="$prmOwner"/>
			<xsl:with-param name="prmIsLabelEdit" select="$prmIsLabelEdit"/>
			<xsl:with-param name="prmIsPreview" select="@Attr.View"/>
		</xsl:apply-templates>

	</xsl:template>

	<!--
	Renders section of elements
	-->
	<xsl:template match="Section">
		<xsl:param name="prmBodyWidth"/>
		<xsl:param name="prmOwner"/>
		<xsl:param name="prmIsLabelEdit"/>
		<xsl:param name="prmIsPreview"/>

		<xsl:variable name="varIsPreview" select="$prmIsPreview"/>
		<xsl:variable name="varCols" select="@cols"/>
		<xsl:variable name="varStyle" select="@name"/>
		<xsl:variable name="varWidth" select="round(($prmBodyWidth) div $varCols)"/>
		<xsl:variable name="varExStyle" select="Style"/>
		<xsl:variable name="varSectionID" select="@Attr.Id"/>

		<div>
			<!-- Edit SECTION -->
			<xsl:if test="$prmIsLabelEdit=1 and not($varIsPreview=1)">
				<div style="margin:3px 3px;">
					<img  class="GZNV_EditIcon" src="[Skin.Path]EditButton.png.wgx"  align="absmiddle"
						  onclick="NavigationView_EditLE('{$prmOwner/@Id}_{$prmOwner/@Attr.MemberID}', event, '{$varSectionID}', 'Section', '');"/>
				</div>
			</xsl:if>

			<!-- DIV:GZNV_LobyPreTitle -->
			<div class="{concat('GZNV_LobyPreTitle',$varStyle)}">
				<xsl:call-template name="tplSetStyle">
					<xsl:with-param name="prmVisible" select="string-length(@tlt)!=0"/>
					<xsl:with-param name="prmStyle" select="$varExStyle/@tlcss"/>
				</xsl:call-template>
				<xsl:call-template name="tplSetText">
					<xsl:with-param name="string" select="@tlt"/>
				</xsl:call-template>
			</div>

			<!-- DIV:GZNV_LobyPreBody -->
			<div class="{concat('GZNV_LobyPreBody',$varStyle)}">
				<xsl:call-template name="tplSetStyle">
					<xsl:with-param name="prmVisible" select="string-length(@pre)!=0"/>
					<xsl:with-param name="prmStyle" select="$varExStyle/@precss"/>
				</xsl:call-template>
				<xsl:call-template name="tplSetText">
					<xsl:with-param name="string" select="@pre"/>
				</xsl:call-template>
			</div>
		</div>
		<!-- TABLE:GZNV_LobyBody -->
		<table class="{concat('GZNV_LobyBody',$varStyle)}">
			<xsl:attribute name="style">
				<xsl:value-of select="$varExStyle/@concss"/>
			</xsl:attribute>
			<xsl:for-each select="R">
				<TR>
					<xsl:for-each select="GZPAGEELE">
						<xsl:variable name="varElStyle" select="Style"/>
						<xsl:variable name="varHasLink" select="Style/@Attr.Anchoring!='NoLink'"/>
						<xsl:variable name="varTDStyle" select="concat('width:',$varWidth,'px;',$varElStyle/@concss)"/>

						<!-- TD:GZNV_Loby -->
						<TD align="left" valign="top">

							<xsl:attribute name="class">
								<xsl:value-of select="concat('GZNV_Loby',$varStyle)"/>
							</xsl:attribute>

							<!-- TD: style attribute -->
							<xsl:attribute name="style">
								<xsl:choose>
									<xsl:when test="$varHasLink">
										<xsl:value-of select="concat('cursor:pointer;',$varTDStyle)"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="$varTDStyle"/>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:attribute>

							<!-- TD: onclick -->
							<xsl:attribute name="onclick">
								<xsl:choose>
									<xsl:when test="$varElStyle/@Attr.Anchoring='InnerItem'">
										<xsl:text>NavigationView_Navigate('</xsl:text>
										<xsl:value-of select="$prmOwner/@Id"/>
										<xsl:text>','</xsl:text>
										<xsl:value-of select="@Attr.Code"/>
										<xsl:text>');</xsl:text>
									</xsl:when>
									<xsl:when test="$varElStyle/@Attr.Anchoring='HyperLink'">
										<xsl:choose>
											<xsl:when test="$varElStyle/@Attr.WindowState='True'">
												<xsl:text>window.open('</xsl:text>
												<xsl:value-of select="@Attr.Code"/>
												<xsl:text>','');</xsl:text>
											</xsl:when>
											<xsl:otherwise>
												<!--see VWG-7556-->
												<xsl:text>mobjApp.Web_SetMainWindowLocation('</xsl:text>
												<xsl:value-of select="@Attr.Code"/>
												<xsl:text>');</xsl:text>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:when>
								</xsl:choose>
							</xsl:attribute>

							<!-- Edit ELEMENT -->
							<xsl:if test="$prmIsLabelEdit=1 and not($varIsPreview=1)">
								<div style="float:right;">
									<img  class="GZNV_EditIcon" src="[Skin.Path]EditButton.png.wgx"  align="absmiddle"
										  onclick="NavigationView_EditLE('{$prmOwner/@Id}_{$prmOwner/@Attr.MemberID}', event, '{$varSectionID}', 'Element', '{@Attr.Index}');"/>
								</div>
							</xsl:if>

							<!--DIV:GZNV_LobyTitle-->
							<div class="{concat('GZNV_LobyTitle',$varStyle)}">
								<xsl:call-template name="tplSetStyle">
									<xsl:with-param name="prmVisible" select="string-length(@Attr.Title)!=0"/>
									<xsl:with-param name="prmStyle" select="$varElStyle/@tlcss"/>
								</xsl:call-template>

								<xsl:call-template name="tplSetText">
									<xsl:with-param name="string" select="@Attr.Title"/>
								</xsl:call-template>
							</div>

							<!--IMG:GZNV_LobyImage,  Render image if url was specified-->
							<img class="{concat('GZNV_LobyImage',$varStyle)}" src="{@Attr.Image}">
								<xsl:call-template name="tplSetStyle">
									<xsl:with-param name="prmVisible" select="string-length(@Attr.Image)!=0"/>
									<xsl:with-param name="prmStyle" select="$varElStyle/@imgcss"/>
								</xsl:call-template>
							</img>

							<!--DIV:GZNV_LobyBodyText-->
							<div class="{concat('GZNV_LobyBodyText',$varStyle)}">
								<xsl:call-template name="tplSetStyle">
									<xsl:with-param name="prmVisible" select="string-length(@Attr.Text)!=0"/>
									<xsl:with-param name="prmStyle" select="$varElStyle/@bodycss"/>
								</xsl:call-template>
								<xsl:call-template name="tplSetText">
									<xsl:with-param name="string" select="@Attr.Text"/>
								</xsl:call-template>
							</div>
						</TD>
					</xsl:for-each>
				</TR>
			</xsl:for-each>
		</table>

	</xsl:template>

	<!--
	Appends style attribute with prmStyle value, in case prmVisible evaluates to true
	-->
	<xsl:template name="tplSetStyle">
		<xsl:param name="prmVisible"/>
		<xsl:param name="prmStyle"/>

		<xsl:attribute name="style">
			<xsl:choose>
				<xsl:when test="not($prmVisible)">
					<xsl:text>display:none</xsl:text>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$prmStyle"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:attribute>

	</xsl:template>

</xsl:stylesheet>