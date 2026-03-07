<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:WC="wgcontrols"
                xmlns:WG="http://www.gizmox.com/webgui">

	<!-- Draw the navigation view control -->
  <xsl:template match="WC:GZNV" mode="modContent">
		<!-- vwgscrollable important to ensure correct calculation of scrollable drop downs of controls like combo -->
		<!-- "topcontainer" and "position:relative;" required to ensure correct behavior of autocomplete container on scrolling -->
		<div class="GZNV_Header">
                <!-- Add a link behind the logo to go to default CK page -->
      <div style="height: 144px;">
        <div class="GZNV_Header_Toplinks">
          <div class="GZNV_Header_Centered">
            <ul>
              <li>
                <a class="GZNV_Header_Toplink_Forums" href="http://www.visualwebgui.com/tabid/364/Default.aspx">Forums</a>
              </li>
              <li>
                <a class="GZNV_Header_Toplink_Login" href="http://www.visualwebgui.com/Home/Login/tabid/124/Default.aspx?returnurl=%2fDefault.aspx">Login</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="GZNV_Header_Topmenu">
          <div class="GZNV_Header_Centered">
            <xsl:call-template name="tplLogoLink" />

            <div class="GZNV_Header_Menu">
              <ul>
                <li>
                  <a href="http://www.visualwebgui.com">HOME</a>
                </li>
                <li>
                  <a href="http://visualwebgui.com/resources/">RESOURCES</a>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div class="GZNV_Header_SearchBox">
        <div style="height: 25px; width: 280px; float: left;">
          <xsl:call-template name="tplSearchBox">
            <xsl:with-param name="prmOwner" select="."/>
          </xsl:call-template>
        </div>

        <div style="position:absolute; left: 280px;">
        <!-- Draw the categories view -->
          <xsl:apply-templates select="GZCVIEW"/>
        </div>
      </div>
                
    </div>
    <div id="topcontainer" style="position:absolute; top: 177px; z-index:101;" class="GZNV_Container">            
	<table cellpadding="0" cellspacing="0" style="table-layout:auto;margin:0px;width:100%;" vwgscrollable="1" data-scrollable="yes">
		<col width="280px" />
		<col/>			
		<tr>
			<td valign="top" >
				<div style="width:280px;padding-left:10px;padding-top:10px;">
					<!-- Draw the nodes tree, first of all - expanded sub-category, after that all others -->
					<xsl:apply-templates select="GZNVIEW"/>
				</div>
			</td>
			<td valign="top" >
				<div style="padding-top:10px;padding-right:30px;">
					<!-- Draw the contained view -->
					<xsl:apply-templates select="GZMVIEW" />
				</div>
			</td>
		</tr>
	</table>			
</div>
</xsl:template>

	<!-- Add a link behind the logo to go to default CK page -->
	<xsl:template name="tplLogoLink" >
		<xsl:param name="prmOwnerId" select="//WC:GZNV/@Id"/>
    <div onclick="mobjApp.NavigationView_GoHome('{$prmOwnerId}');" class="GZNV_CKLogo">
    </div>
	</xsl:template>
	
  <!-- Draw the search text box-->
  <xsl:template name ="tplSearchBox">
    <xsl:param name="prmOwner"/>

      <!-- Draw the search textbox -->
	  <div class="GZNV_NodeSearch" style="height:25px;width:205px;overflow:hidden;">

		  <div style="float:left; width:2px;   height:25px; background:transparent url('[Skin.Path]autocomplete.searchLeft.png.wgx') no-repeat right top;"></div>
		  <div style="float:left; width:181px; height:25px; background:transparent url('[Skin.Path]autocomplete.searchCenter.png.wgx') repeat-x right top;">
			  <input id="gznvsearch" class="GZVN_SearchGrayed" type="text" vwgeditable="1" value="Search text ..."
					 onkeydown="gznvsearch_ac.onKeyPress($.event.fix(event));"
					 onkeyup ="gznvsearch_ac.onKeyUp($.event.fix(event));"
					 onblur="gznvsearch_ac.enableKillerFn(); if(this.value.length==0){{$(this).toggleClass('GZVN_SearchGrayed');this.value='Search text ...';}}"
					 onfocus="gznvsearch_ac.fixPosition(); if(this.value=='Search text ...'){{this.value='';$(this).toggleClass('GZVN_SearchGrayed');}}" 
					 onmousedown="this.focus();mobjApp.Web_EventCancelBubble(event,false,true);mobjApp.Popups_HidePopups();"
					 />
		  </div>
		  <div class="GZVN_SearchButton"
			onclick="mobjApp.NavigationView_Search('{$prmOwner/@Id}',this.previousSibling.firstChild.value);">&#160;</div>
	  </div>
  </xsl:template>

  <!-- Draw the links above the page-->
  <xsl:template name ="tplPageLinks">
    <xsl:param name="prmOwnerId"/>
    <xsl:param name="prmIsLabelEdit"/>
    <div class="GZNV_PageLinks" style="position:static">
      <xsl:if test="$prmIsLabelEdit=1">
        <!-- Create new Item link -->
        <span class="GZNV_ToolItem" onclick="NavigationView_Create('{$prmOwnerId}');"
			  onmouseover="$(this).toggleClass('GZNV_ToolItem_Selected');" onmouseout="$(this).toggleClass('GZNV_ToolItem_Selected');"
			  title="Add a new item under the current parent.">
			<xsl:text>Add new</xsl:text>
        </span>
        <!-- Run Validation check link -->
        <span class="GZNV_ToolItem" onclick="NavigationView_Validate('{$prmOwnerId}',window);"
			  onmouseover="$(this).toggleClass('GZNV_ToolItem_Selected');" onmouseout="$(this).toggleClass('GZNV_ToolItem_Selected');"
			  title="Validate items: snippets instantiation, links correctness and resources availability.">
			<xsl:text>Validate</xsl:text>
		</span>
		<!-- Open root node in Admin mode -->
		<span class="GZNV_ToolItem" onclick="NavigationView_Edit('{$prmOwnerId}_N0',event,window);"
			  onmouseover="$(this).toggleClass('GZNV_ToolItem_Selected');" onmouseout="$(this).toggleClass('GZNV_ToolItem_Selected');"
			  title="Edit root item properties to set default CompanionKit item.">
			<xsl:text>Edit Root</xsl:text>
        </span>
		<!-- Switch mode - Admin/Main -->
		  <span class="GZNV_ToolItem" onclick="NavigationView_Mode('{$prmOwnerId}');"
				onmouseover="$(this).toggleClass('GZNV_ToolItem_Selected');" onmouseout="$(this).toggleClass('GZNV_ToolItem_Selected');"
			  title="Press to swith in preview mode. Useful for lobby like items design.">
			  <xsl:text>Mode</xsl:text>
		  </span>		
		<!-- open the sitemap -->
		<span class="GZNV_ToolItem"
			onmouseover="$(this).toggleClass('GZNV_ToolItem_Selected');" onmouseout="$(this).toggleClass('GZNV_ToolItem_Selected');"
			onclick="javascript:mobjApp.Web_SetMainWindowLocation('/sitemap.wgx');"
			title="Browse CompanionKit list of items and description articles.">
			<xsl:text>Sitemap</xsl:text>
		</span>
		<!-- reindex IR directory -->
		<span class="GZNV_ToolItem"
		  onmouseover="$(this).toggleClass('GZNV_ToolItem_Selected');" onmouseout="$(this).toggleClass('GZNV_ToolItem_Selected');"
		  onclick="NavigationView_ReIndex('{$prmOwnerId}');"
		  title="Recreate and optimize search index for all CompanionKit items.">
		  <xsl:text>Re-Index</xsl:text>
		</span>		  
      </xsl:if>
      <!-- General purpose links -->
	  <a href="http://www.visualwebgui.com" target="_self" onclick="GA_TrackEvent('outbound','VWG Home');">
        <img src="[Skin.Path]PageIcon.png.wgx" align="absmiddle"/>
		<span>Visual WebGui Home</span>
      </a>
      <a href="http://www.visualwebgui.com/tabid/110/default.aspx" target="_self" onclick="GA_TrackEvent('outbound','Download');">
        <img src="[Skin.Path]DownloadButton.png.wgx" align="absmiddle"/>
		<span>Downloads</span>
      </a>
      <a href="http://www.visualwebgui.com/tabid/364/Default.aspx" target="_self" onclick="GA_TrackEvent('outbound','Community');">
        <img src="[Skin.Path]CommunityButton.png.wgx" align="absmiddle"/>
		<span>Forums</span>
      </a>
      <a href="http://visualwebgui.com/Developers/KB/tabid/654/article/w_visual_webgui_overview_by_function/Default.aspx" target="_blank" onclick="GA_TrackEvent('outbound','Help');">
        <img src="[Skin.Path]HelpButton.png.wgx" align="absmiddle"/>
		<span>Knowledge Base</span>
      </a>
    </div>
  </xsl:template>

  <!-- Draw the contained "Main" view -->
  <xsl:template match="WC:GZNV/GZMVIEW">
    <xsl:param name="prmOwner" select="ancestor::WC:GZNV"/>
    <div id="VWG_{$prmOwner/@Id}_{@Attr.MemberID}" style="position:static;width:100%;overflow:visible;">
      <xsl:if test="@Attr.Type='P' or @Attr.Type='E'">
        <div class="GZNV_PageHeader">
			<div style="float:left; overflow:visible;margin-top:10px;"> 
				<img src="[Skin.Path]favicon.png.wgx" align="absmiddle" />
				<xsl:text>&#160;</xsl:text>
				<xsl:value-of select="@Attr.Text"/>
			</div>
			<!-- Draw a button to open popup of themes -->
			<div ID="themebuttonouter">
				<img src="[Skin.Path]links.png.wgx" title="Press to get links to browse and download" onclick="NavigationView_ShowLinks({$prmOwner/@Id});" style='margin-left:2px;margin-right:5px;cursor:pointer;vertical-align:middle;'/>
				<img src="[Skin.Path]themes.themelogo.png.wgx" style='margin-right:2px;cursor:default;vertical-align:middle;'/>
				<div id="themebutton" onclick="NavigationView_ThemeToggleOpen(this);" onmouseover="NavigationView_ThemeHighlightBtn(this);" onmouseout="NavigationView_ThemeHighlightBtn(this);"></div>
			</div>
			<xsl:call-template name="tplShare"/>
        </div>

        <!-- Draw the page body: control's frame and code pane -->
        <xsl:call-template name="tplPageBody">
          <xsl:with-param name="prmOwner" select="$prmOwner"/>
        </xsl:call-template>

      </xsl:if>
	  
		<!-- Render an article -->
      <xsl:if test="@Attr.Type='A'">
				<xsl:apply-templates select="GZAR">
					<xsl:with-param  name="prmOwner" select="$prmOwner"/>
				</xsl:apply-templates>
      </xsl:if>
		
	  <!-- Render a lobby -->
      <xsl:if test="@Attr.Type='L'">
			<xsl:call-template name="tplPageLobby">
			  <xsl:with-param name="prmOwner" select="$prmOwner"/>
			  <xsl:with-param name="prmIsLabelEdit" select="@Attr.LabelEdit"/>
			</xsl:call-template>			
      </xsl:if>

	  <!-- Render search/validation results -->
      <xsl:if test="@Attr.Type='S'">
          <div class="GZNV_PageHeader">
			  <div style="width:750px; float:left; overflow:visible;margin-top:10px;">
				  <img src="[Skin.Path]favicon.png.wgx" align="absmiddle" />
				  <xsl:text>&#160;</xsl:text>
				  <xsl:value-of select="concat('[', count(GZITEM) ,'] ',@Attr.Text)"/>
			  </div>			  
          </div>        
		  <xsl:if test="GZITEM">
			<div class="GZNV_PageBody GZNVS_Container">

			  <!-- Search text panel -->
			  <table ID="GZNVS_FilterTable" class ="GZNVS_Filterarea" width="882" style="" cellpadding="0" cellspacing="0" border="0">
				  <tbody>
					  <tr>
						  <td width="20" align="center" valign="middle">
							  <div style="display:block;margin:4px;width:15px;height:17px;cursor:pointer;">
								  <img title="Read the guidelines article describing the search engine." src="[Skin.Path]search.help.png.wgx"
									   onclick="mobjApp.NavigationView_Navigate('{$prmOwner/@Id}', 'item:CompanionKit.CompanionKit.CompanionKit.fullcontentsearch');"/>
							  </div>
						  </td>
						  <td width="40" align="center" valign="middle" class="GZNVS_Smalltext">
							  <b style="color:#436082;cursor:pointer;"
								 onclick="mobjApp.NavigationView_Navigate('{$prmOwner/@Id}', 'item:CompanionKit.CompanionKit.CompanionKit.fullcontentsearch');">Help</b>
						  </td>						  
						  <td width="25px" align="center" valign="middle">
							  <div ID="GZNVS_Closebutton">
								  <img title="Clear search" ID="GZNVS_closebuttonimage" src="[Skin.Path]search.close.png.wgx" 
									   onclick="GZNVS_SetInitial();"/>
							  </div>
						  </td>
						  <td width="90px" align="center" valign="middle" class="GZNVS_Smalltext">
							  <b>Search text:</b>
						  </td>
						  <td align="left" valign="middle">
							  <!-- vwgeditable ensures correct editing funcitonality of the textbox -->
							  <input vwgeditable="1" id="VWGFilterValue" onkeyup="GZNVS_Filter();" style="width:700px;" class="GZNVS_SelectedTagsValue GZNVS_Smalltext"/>
						  </td>
					  </tr>
				  </tbody>
			  </table>			  
			  
			<!-- search results -->
            <xsl:apply-templates select="GZITEM">
              <xsl:with-param name="prmOwner" select="$prmOwner"/>
            </xsl:apply-templates>

          </div>
        </xsl:if>
        <!-- Draw the 'no results' for the search -->
		<xsl:if test="not(GZITEM)">
		  <div class="GZNV_PageBody GZNVS_Container">
			  <div class="GZNVS_ItemContainer">
				  <div class="GZNVS_Item">
					  <div style="margin:5px;">
						  <p>
							  <xsl:text>Your search - </xsl:text>
							  <b>
								  <xsl:value-of select="substring(@Attr.Text,8)"/>
								  <!--omit 'search:'-->
							  </b> - did not match any documents.
						  </p>
						  <p>
							  Suggestions:
						  </p>
						  <ul>
							  <li>Make sure all words are spelled correctly.</li>
							  <li>Try different keywords.</li>
							  <li>Try more general keywords.</li>
							  <li>Try fewer keywords.</li>
							  <li>Read the guidelines
								  <span style="cursor:pointer;color:#00E;"
			onclick="mobjApp.NavigationView_Navigate('{$prmOwner/@Id}', 'item:CompanionKit.CompanionKit.CompanionKit.fullcontentsearch');">article</span>
								  <xsl:text> describing the search engine.</xsl:text>
							  </li>
							  <li>The special characters: +-&amp;|!(){}[]^&quot;~*?:\ should be escaped with the '\' character.
								  <BR/>For example to search for (1+1):2 use the query \(1\+1\)\:2</li>
						  </ul>
					  </div>
				  </div>
			  </div>
		  </div>
		</xsl:if>

      </xsl:if>
    </div>
  </xsl:template>

  <!-- *** Draw search results *** -->
  <xsl:template match ="GZITEM">
    <xsl:param name="prmOwner"/>
    <xsl:variable name="varKWCount" select="count(KWS/KW)"/>
    <xsl:variable name="varBCCount" select="count(PS/P)"/>
    <xsl:variable name ="varOwner" select ="parent::GZMVIEW"/>
      <!-- Item start -->
      <div class="GZNVS_ItemContainer">
        <div class="GZNVS_Item">
          
          <div class="GZNVS_ItemHeader GZNVS_Filterable" 
			   onclick="mobjApp.NavigationView_Navigate('{$prmOwner/@Id}','{@Attr.Code}');"
               onmouseover="$(this).addClass('GZNVS_Underline');" 
               onmouseout="$(this).removeClass('GZNVS_Underline');">
               <xsl:value-of select="@Attr.Text"/>
          </div>

		  <!-- The message (if provided) -->
		  <xsl:if test="string-length(@MSG)>0">
			  <div class="GZNVS_ItemHeader GZNVS_Filterable" style="color:red;">
                  <img align="middle" style="vertical-align:middle;" src="[Skin.Path]DescriptionIcon.png.wgx" width="27" height="26"/>&#160;
				  <xsl:value-of select="@MSG"/>
			  </div>
		  </xsl:if>

          <div class="GZNVS_ItemDescription GZNVS_Filterable">
            <xsl:value-of select="@DP"/>
          </div>
          
          <!-- Breadcrumbs-->
          <div class="GZNVS_BC GZNVS_Filterable">
            <xsl:for-each select ="PS/P">
              <!-- avoid image before first item -->
              <xsl:if test="not(position()=1) or $varBCCount=1">
                  <img src="[Skin.Path]search.arrow.png.wgx" width="15" height="10"/>
              </xsl:if>
              <div class="GZNVS_BCI GZNVS_Link" valign="center" 
				   onclick="mobjApp.NavigationView_Navigate('{$prmOwner/@Id}','{@Attr.Code}');"
                   onmouseover="$(this).addClass('GZNVS_Underline');"
                   onmouseout="$(this).removeClass('GZNVS_Underline');">
                <xsl:value-of select="@Attr.Text"/>
              </div>
            </xsl:for-each>
          </div>

          <!-- keywords shown (always in admin mode) or if defined in non-admin mode -->
          <xsl:if test="$varKWCount>0 or $varOwner/@Attr.LabelEdit">
            <div class="GZNVS_Keywords GZNVS_Filterable">
              
              <!-- Add edit icon to jump in editing mode and Item status if allowed -->
              <xsl:if test="$varOwner/@Attr.LabelEdit">
                <img style="margin-right:5px;background-color:#02365b;" class="GZNV_EditIcon" 
					 onclick="mobjApp.NavigationView_Edit('{$varOwner/@Attr.OwnerID}_N{@Attr.Code}',event,window);" 
					 src="[Skin.Path]EditButton.png.wgx"  align="absmiddle" alt="Edit the Item"/>
                <span style="margin-right:10px;">
                  <xsl:text>[Status: </xsl:text>
                  <xsl:value-of select ="@ST"/>
                  <xsl:text>]</xsl:text>
                </span>
              </xsl:if>
              
              <xsl:text>Keywords: </xsl:text>
              <xsl:for-each select ="KWS/KW">
                <span class="GZNVS_Keyword GZNVS_Link" onclick="mobjApp.NavigationView_Search('{$prmOwner/@Id}','{@Attr.Text}');"
                      onmouseover="$(this).addClass('GZNVS_Underline');"
                      onmouseout="$(this).removeClass('GZNVS_Underline');">
                  <xsl:value-of select="@Attr.Text"/>
                </span>
				<!-- avoid comma after the last keyword -->
				<xsl:if test="not(position()=$varKWCount)">
					<xsl:text>, </xsl:text>
				</xsl:if>
              </xsl:for-each>

            </div>
          </xsl:if>


        </div>
        <!-- Item end -->
      </div>

  </xsl:template>
  
  <!-- Draw the article body -->
  <xsl:template match="WC:GZNV/GZMVIEW/GZAR">
		<xsl:param name="prmOwner"/>
		<div class="GZNV_PageHeader">
			<div style="float:right;height:16px;margin-top:11px;width:130px;">
				<div id="toolbox" class="addthis_toolbox addthis_default_style" style="float:left;"></div>
				<img src="[Skin.Path]links.png.wgx" title="Press to get links to browse and download" onclick="NavigationView_ShowLinks({$prmOwner/@Id});" 
						 style='margin-right:5px;cursor:pointer;float:left;'/>
			</div>
		</div>
    <div id="PageBodyContainer" class="GZNV_Article">
			<table cellspacing="0" cellpadding="0" border="0" class="GZNVCP_ContainerTable">
			<col width="6"/>
			<col width="194"/>
			<col/>
			<col width="6"/>
			<tbody>
				<tr>
					<td><img height="6px" width="6px" src="[Skin.Path]CodePane_topLeftt.gif.wgx" align="absbottom"/></td>
					<td height="6" width="194px"><img height="6" width="194" align="absbottom" src="[Skin.Path]CodePane_TopGradBorder.gif.wgx"/></td>
					<td height="6"><img width="6px" height="6px" src="[Skin.Path]CodePane_top.gif.wgx" style="width: 100%;" align="absbottom"/></td>
					<td height="6"><img height="6" width="6" align="absbottom" src="[Skin.Path]CodePane_topRight.gif.wgx"/></td>
				</tr>
				<tr>
					<td style="background-image: url([Skin.Path]left.gif.wgx);"></td>
					<td id="ArticleCell" colspan="2" style="padding: 5px;" height="150">

						<!-- Dispalay a div with loading image/text, till will be actually loaded and then hidden -->
						<div id="Loading" align="center">
							<p class="LoadingText">Loading the article</p>
							<img src="[Skin.Path]redirect.gif.wgx" alt="loading"/>
							<p style="color:white;font-size:8px;font-family:verdana;">
								<xsl:value-of select="U/@Attr.Source"/>
							</p>
						</div>
						
						<!-- The IRFRAME height will be adjusted dynamically on page loading-->
						<iframe id ="ArticleFrame" src ="{U/@Attr.Source}" style="width:100%;border-style:none;display:none;" frameborder="0"/>
					
					</td>
					<td style="background-image: url([Skin.Path]CodePane_right.gif.wgx);"></td>
				</tr>
				<!-- We are in editing mode, add enlarge, shrink buttons -->
				<xsl:if test="U/@E='1'">
					<tr>
						<td style="background-image: url([Skin.Path]left.gif.wgx);"></td>
						<td colspan="2">
							<table cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed;">
								<tr>
									<td width="10%" onclick="NavigationView_ResizeIframe();" class="changesize" align="center">
										<img class="changesize" src="[Skin.Path]fittotext.png.wgx" width="19" height="22" border="0" alt=""/>
									</td>
									<td width="45%" onclick="NavigationView_EnlargeView();" class="changesize" height="24" align="center">
										<img class="changesize" src="[Skin.Path]arrow.down.png.wgx" width="24" height="24" border="0" alt=""/>
									</td>
									<td width="45%" onclick="NavigationView_MakeSmallerView();" class="changesize" height="24" style="border-style:none;" align="center">
										<img class="changesize" src="[Skin.Path]arrow.up.png.wgx" width="24" height="24" border="0" alt=""/>
									</td>
								</tr>
							</table>					
						</td>
						<td style="background-image: url([Skin.Path]CodePane_right.gif.wgx);"></td>
					</tr>
				</xsl:if>
				<tr>
					<td><img height="6px" width="6px" src="[Skin.Path]CodePane_bottomLeftT.gif.wgx" alt=""/></td>
					<td height="6" width="194px"><img height="6" width="194" align="absbottom" src="[Skin.Path]CodePane_TopGradBorder.gif.wgx"/></td>
					<td valign="top"><img width="6px" height="6px" src="[Skin.Path]CodePane_bottom.gif.wgx" style="width: 100%;" align="top"/></td>
					<td><img height="6" width="6" src="[Skin.Path]CodePane_rightBottom.gif.wgx" align="top"/></td>
				</tr>
			
			</tbody>
		</table>
    </div>
  </xsl:template>

  <!-- Draw the page body: control's frame and code pane -->
  <xsl:template name="tplPageBody">
    <xsl:param name="prmOwner"/>
	<!-- get the first item is CSharp section -->
    <xsl:variable name="varFirstCSItem" select="$prmOwner/GZMVIEW/GZRES/GZPAGERES[@L='All' or @L='CSharp']"/>

	  <!-- if resource is a file hide links for article -->
	  <xsl:variable name="varArticleResource">
		  <xsl:if test="count($varFirstCSItem)=0">display:none;</xsl:if>
		  <xsl:if test="$varFirstCSItem[position()=1 and @Attr.Type!='Article']">display:none;</xsl:if>
	  </xsl:variable>
	  <!-- if resource is an article hide links for file -->
	  <xsl:variable name="varFileResource">
		  <xsl:if test="count($varFirstCSItem)=0">display:none;</xsl:if>
		  <xsl:if test="$varFirstCSItem[position()=1 and @Attr.Type='Article']">display:none;</xsl:if>
	  </xsl:variable>
	  
    <xsl:if test="@Attr.Type='E'" >
      <div class="GZNV_PageBody" style="height:{@Attr.Height}px;" >
        <xsl:apply-templates select="$prmOwner/GZMVIEW/GZPAGE" />
      </div>
    </xsl:if>
    <xsl:if test="not(@Attr.Type='E')">
    <div id="PageBodyContainer">
      <table cellpadding="0" cellspacing="0" class="GZNVCP_ContainerTable" border="0">
        <col width="6" />
        <col width="194" />
        <col />
        <col width="6" />
        <tr>
          <td>
            <img src="[Skin.Path]CodePane_topLeftt.gif.wgx" align="absbottom" width="6px" height="6px" />
          </td>
          <td width="194px" height="6">
            <img align="absbottom" src="[Skin.Path]CodePane_TopGradBorder.gif.wgx" width="194" height="6" />
          </td>
          <td height="6"><img width="6px" height="6px" src="[Skin.Path]CodePane_top.gif.wgx" style="width: 100%;" align="absbottom"/></td>
          <td height="6"><img align="absbottom" src="[Skin.Path]CodePane_topRight.gif.wgx" width="6" height="6" /></td>
        </tr>
        <tr>
          <td style="background-image:url([Skin.Path]left.gif.wgx);">
          </td>
          <!-- IE unable to calc. properly the height of cell from internal content, without to set the value explicit on TD -->
          <td colspan="2" height="{number(@Attr.Height)+10}px" style="padding:5px 5px 5px 5px;">
            <div class="GZNV_PageBody" style ="width:100%;height:{@Attr.Height}px;">
              <!-- render user-control and inspector-->
              <xsl:apply-templates select="$prmOwner/GZMVIEW/GZPAGE" />
            </div>
          </td>
          <td height="6" style="background-image:url([Skin.Path]CodePane_right.gif.wgx);" />
        </tr>
        <tr>
          <td colspan="2"><img align="absbottom" src="[Skin.Path]CodePane_topLeft.gif.wgx" /></td>
          <td height="6px"><img width="6px" height="6px" src="[Skin.Path]CodePane_top.gif.wgx" style="width: 100%;" align="absbottom"/></td>
          <td height="20px"><img width="6px" height="20px" src="[Skin.Path]CodePane_RightT.gif.wgx" align="absbottom"/></td>
        </tr>
        <!-- the row with table containing the resources -->
        <tr>
          <td colspan="2" valign="top" class="GZNVCP_menuBottomCont">
            <!-- code pane tabs -->
            <DIV class="tabberlive" style="margin-top:5px;">
              <ul class="tabbernav">
                <li id="tabheader0" class="tabberactive" onclick="$(this).siblings().removeClass('tabberactive'); $(this).addClass('tabberactive').parents('div:eq(0)').children('div').addClass('tabinactive').eq(0).removeClass('tabinactive');NavigationView_ActivateTab(this);">
                  <span>C#</span>
                </li>
                <li id="tabheader1" class="" onclick="$(this).siblings().removeClass('tabberactive');$(this).addClass('tabberactive').parents('div:eq(0)').children('div').addClass('tabinactive').eq(1).removeClass('tabinactive');NavigationView_ActivateTab(this);">
                  <span>VB.NET</span>                  
                </li>
              </ul>              
              <DIV id="tab0" class="tabbertab" >
                <table cellpadding="0" cellspacing="0" border="0">
                  <col />
                  <tbody>
                    <tr>
                      <td height="5px" style="background-image:url([Skin.Path]CodePane_topTop.png.wgx)"/>
                    </tr>
                    <!-- Add all non vb-net resources-->
                    <xsl:for-each select="$prmOwner/GZMVIEW/GZRES/GZPAGERES[@L='All' or @L='CSharp']">
                      <tr>
                          <td onclick="NavigationView_TabClick(this,document);" vwgsrc="{@Attr.Source}" type="{@Attr.Type}" title="{@Attr.Title}">
                            <xsl:attribute name="class">GZNVCP_buttonText
                                <xsl:if test="position()=1"> GZNVCP_buttonTextSelected</xsl:if>
                            </xsl:attribute>
                            <!-- shorten the string to avoid overlap with borders-->
                              <xsl:call-template name="tplShortenString">
                                <xsl:with-param name ="prmLength" select="22"/>
                                <xsl:with-param name ="prmInput" select="@Attr.Title" />
                              </xsl:call-template>
                          </td>
                      </tr>
                    </xsl:for-each>
                    <!-- Zip entry -->
                    <tr style="position:relative;">
                      <td height="25" style="background-image:url([Skin.Path]menuItemZip.gif.wgx)">
                        <div style="position:relative;height:25px;">
                          <div class="ZipLink" onclick="NavigationView_ZipClick({$prmOwner/@Id},'ZipCS','{$prmOwner/GZMVIEW/@Link}');" title="Download example files in ZIP"/>
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <td height="42">
                        <img src="[Skin.Path]CodePane_menuBottom.gif.wgx" width="200"/>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </DIV>
              <DIV id="tab1" class="tabbertab tabinactive" >
                <table cellpadding="0" cellspacing="0" border="0">
                  <col />
                  <tbody>
                    <tr>
                      <td height="5px" style="background-image:url([Skin.Path]CodePane_topTop.png.wgx)"/>
                    </tr>
                    <!-- Add all non c-sharp resources-->
                    <xsl:for-each select="$prmOwner/GZMVIEW/GZRES/GZPAGERES[@L='All' or @L='VBNET']">
                      <tr>
                          <td onclick="NavigationView_TabClick(this,document);" vwgsrc="{@Attr.Source}" type="{@Attr.Type}"  title="{@Attr.Title}">
                              <xsl:attribute name="class">GZNVCP_buttonText
                                <xsl:if test="position()=1"> GZNVCP_buttonTextSelected</xsl:if>
                              </xsl:attribute>
                            <!-- shorten the string to avoid overlap with borders-->
                            <xsl:call-template name="tplShortenString">
                              <xsl:with-param name ="prmLength" select="22"/>
                              <xsl:with-param name ="prmInput" select="@Attr.Title" />
                            </xsl:call-template>
                          </td>
                      </tr>
                    </xsl:for-each>

                    <!-- Zip entry -->
                    <tr style="position:relative;">
                      <td height="25" style="background-image:url([Skin.Path]menuItemZip.gif.wgx)">
                        <div style="position:relative;height:25px;">
                          <div class="ZipLink" onclick="NavigationView_ZipClick({$prmOwner/@Id},'ZipVB','{$prmOwner/GZMVIEW/@Link}');" title="Download example files in ZIP"/>
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <td height="42">
                        <img src="[Skin.Path]CodePane_menuBottom.gif.wgx" width="200"/>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </DIV>
            </DIV>
          </td>
          <!-- description and code -->
          <td rowspan="2" valign="top" height="750px" style="padding:1px 1px 1px 1px; background-color:white;" >

            <!-- draw self expanding drop down with links for browse-->
            <div style="position:relative;">
              <div class="Floating Collapsed"
               onmouseover="$(this).removeClass('Collapsed').children('div').show();"
               onmouseout="$(this).addClass('Collapsed').children('div').hide();">
                
				<div id="DDLinkContainer" style="position:relative;text-align:center;top:4px;display:none;">

					<div style="position:relative;{$varFileResource}">
						<img class="DDLinkImage" onclick="NavigationView_DropDownClick({$prmOwner/@Id},'OpenLN',this);"   vwgtitle="{$varFirstCSItem/@Attr.Title}" vwgsrc="{$varFirstCSItem/@Attr.Source}" src="[Skin.Path]dd_external.ln.png.wgx" width="24" height="22" border="0" alt="Open in window (with line numbers)" title="Open in window (with line numbers)"/>
						<img class="DDLinkImage" onclick="NavigationView_DropDownClick({$prmOwner/@Id},'Open',this);"     vwgtitle="{$varFirstCSItem/@Attr.Title}" vwgsrc="{$varFirstCSItem/@Attr.Source}" src="[Skin.Path]dd_external.png.wgx" width="24" height="22" border="0"    alt="Open in window" title="Open in window"/>
						<img class="DDLinkImage" onclick="NavigationView_DropDownClick({$prmOwner/@Id},'Download',this);" vwgtitle="{$varFirstCSItem/@Attr.Title}" vwgsrc="{$varFirstCSItem/@Attr.Source}" src="[Skin.Path]dd_download.png.wgx" width="24" height="22" border="0"    alt="Download" title="Download"/>
					</div>

					<div style="position:relative;{$varArticleResource}">
						<img class="DDLinkImage" onclick="NavigationView_DropDownClick({$prmOwner/@Id},'Browse',this);" vwgtitle="{$varFirstCSItem/@Attr.Title}" vwgsrc="{$varFirstCSItem/@Attr.Source}" src="[Skin.Path]dd_external.png.wgx" width="24" height="22" border="0"    alt="Open in window" title="Open in window"/>
					</div>					

				</div>
              
			  </div>            
            </div>

            <iframe id="GZNV_CodePane" style="width:100%;height:100%;" marginheight="18px" marginwidth="8px" frameborder="0">
              <xsl:attribute name ="src">
                <!-- load the first non vb item on c-sharp tab -->
                <xsl:value-of select="$varFirstCSItem/@Attr.Source"/>
              </xsl:attribute>
            </iframe>
          </td>
          <!-- bottom triangle image-->
          <td rowspan="2" style="background-image:url([Skin.Path]CodePane_right.gif.wgx);">
          </td>
        </tr>
        <tr>
          <td colspan="2" valign="top" class="GZNVCP_menuBottomCont" height="55">
          </td>
        </tr>
        <tr>
          <td colspan="2"><img src="[Skin.Path]CodePane_bottomLeft.gif.wgx" width="200" height="6" align="top"/></td>
          <td valign="top"><img width="6px" height="6px" src="[Skin.Path]CodePane_bottom.gif.wgx" style="width: 100%;" align="top"/></td>
          <td><img src="[Skin.Path]CodePane_rightBottom.gif.wgx" width="6" height="6" align="top"/></td>
        </tr>
      </table>
    </div>
    </xsl:if>

  </xsl:template>

  <xsl:template match="WC:GZNV/GZMVIEW/GZPAGE">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawContained" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Draw the categories view -->
  <xsl:template match="WC:GZNV/GZCVIEW">
    <xsl:param name="prmOwner" select="ancestor::WC:GZNV"/>
    <xsl:param name="prmId" select="$prmOwner/@Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <div id="VWG_{$prmOwner/@Id}_{@Attr.MemberID}" style="height:32px;">
      <xsl:for-each select="GZCT">
        <xsl:if test="@Attr.LabelEdit=1">
          <img  class="GZNV_EditIcon" src="[Skin.Path]EditButton.png.wgx"  align="absmiddle" onclick="mobjApp.NavigationView_Edit('{$prmId}_{@Attr.MemberID}',event,window);"/>
        </xsl:if>
        <span title="{@Attr.ToolTip}" onclick="mobjApp.NavigationView_Click('{$prmId}_{@Attr.MemberID}',this, window);">
          <!-- highlight if the item is current-->
          <xsl:call-template name="tplSetCurrent">
            <xsl:with-param name="prmBaseClass" select="'GZNV_Category'" />
            <xsl:with-param name="prmIsCurrent" select="@CC" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:value-of select="@Attr.Title"/>
        </span>
        <img src="[Skin.Path]CategorySeprator.gif.wgx"  align="absmiddle"/>
      </xsl:for-each>
    </div>
  </xsl:template>

  <!-- Draw the nodes view -->
  <xsl:template match="WC:GZNV/GZNVIEW">
    <xsl:param name="prmOwner" select="ancestor::WC:GZNV"/>
    <div  id="VWG_{$prmOwner/@Id}_{@Attr.MemberID}" title="{@Attr.ToolTip}" style="width:250px;padding-bottom:100px;">
      <div>
        <xsl:apply-templates select="GZND[@Attr.Expanded='1']" />
        <xsl:apply-templates select="GZND[@Attr.Expanded='0']" />
      </div>
    </div>
  </xsl:template>

  <!-- Draw a single node view (sub-category)-->
  <xsl:template match="GZNVIEW/GZND">
    <xsl:param name="prmOwner" select="ancestor::WC:GZNV"/>
    <xsl:param name="prmId" select="$prmOwner/@Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <div id="VWG_{$prmId}_{@Attr.MemberID}">
      <div style="height:26px"  >
        <!-- highlight if the item is current-->
        <xsl:call-template name="tplSetCurrent">
          <xsl:with-param name="prmBaseClass" select="'GZNV_RootNode'" />
          <xsl:with-param name="prmIsCurrent" select="@CSC" />
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:if test="@Attr.LabelEdit=1">
          <img  class="GZNV_EditIcon" src="[Skin.Path]EditButton.png.wgx"  align="absmiddle" 
                onclick="mobjApp.NavigationView_Edit('{$prmOwner/@Id}_{@Attr.MemberID}',event,window)"/>
        </xsl:if>
        <span onclick="mobjApp.NavigationView_Click('{$prmId}_{@Attr.MemberID}',this,window);" title="{@Attr.ToolTip}">
          <img src="[Skin.Path]Icon.gif.wgx"  align="absmiddle"/>&#160;
          <xsl:value-of select="@Attr.Title"/>
        </span>
      </div>
      <xsl:if test="GZND">
        <div>
          <xsl:attribute name="style">
            <xsl:text>padding-left:20px;</xsl:text>
            <xsl:if test="@Attr.Expanded='0'">display:none;</xsl:if>
          </xsl:attribute>
          <xsl:apply-templates select="GZND" />
        </div>
      </xsl:if>
    </div>
  </xsl:template>

  <!-- Draw a single node view -->
  <xsl:template match="GZND">
    <xsl:param name="prmOwner" select="ancestor::WC:GZNV"/>
    <xsl:param name="prmId" select="$prmOwner/@Id"/>
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <div id="VWG_{$prmId}_{@Attr.MemberID}" style="padding-top:2px;">
      <div style="height:16px">
        <xsl:if test="@Attr.LabelEdit=1">
          <img  class="GZNV_EditIcon" src="[Skin.Path]EditButton.png.wgx"  align="absmiddle" onclick="mobjApp.NavigationView_Edit('{$prmId}_{@Attr.MemberID}',event,window)"/>
        </xsl:if>
        <xsl:choose>
          <xsl:when test="@Attr.Expanded='1'">
            <img src="[Skin.Path]NodeExpander1.png.wgx" onclick="mobjApp.NavigationView_Toggle('{$prmId}_{@Attr.MemberID}',this,window)" align="absmiddle"/>
          </xsl:when>
          <xsl:when test="@Attr.Expanded='0'">
            <img src="[Skin.Path]NodeExpander0.png.wgx" onclick="mobjApp.NavigationView_Toggle('{$prmId}_{@Attr.MemberID}',this,window)" align="absmiddle"/>
          </xsl:when>
          <xsl:otherwise>
            <img src="[Skin.CommonPath]Empty.gif.wgx"  align="absmiddle"/>
          </xsl:otherwise>
        </xsl:choose>
        <span title="{@Attr.ToolTip}" onclick="mobjApp.NavigationView_Click('{$prmId}_{@Attr.MemberID}',this, window)">
          <!-- highlight if the item is current-->
          <xsl:call-template name="tplSetCurrent">
            <xsl:with-param name="prmBaseClass" select="'GZNV_Node'" />
            <xsl:with-param name="prmIsCurrent" select="@Attr.CurrentPage" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:call-template>
          <xsl:text>&#160;</xsl:text>
          <xsl:value-of select="@Attr.Title"/>
        </span>
      </div>
      <xsl:if test="GZND">
        <div>
          <xsl:attribute name="style">
            <xsl:text>padding-left:10px;</xsl:text>
            <xsl:if test="@Attr.Expanded='0'">display:none;</xsl:if>
          </xsl:attribute>
          <xsl:apply-templates select="GZND" >
            <xsl:with-param name="prmClass" select="'GZNV_Node'" />
          </xsl:apply-templates>
        </div>
      </xsl:if>
    </div>
  </xsl:template>

  <!-- Highlights the current item to '_Selected' class in addition to base class -->
  <xsl:template name="tplSetCurrent">
    <!-- class on-top of it we will highlight the item-->
    <xsl:param name ="prmBaseClass"/>
    <!-- indicator: '1' to highlight, otherwise not-->
    <xsl:param name ="prmIsCurrent"/>
    <xsl:param name="prmIsEnabled" />
    <!-- If the item is current then apply additional '_Selected' style -->
    <xsl:choose>
      <xsl:when test="$prmIsCurrent='1'">
        <xsl:attribute name="class">
          <xsl:value-of select="concat($prmBaseClass,' ',$prmBaseClass,'_Selected')"/>
        </xsl:attribute>
      </xsl:when>
      <xsl:otherwise>
        <xsl:attribute name="class">
          <xsl:value-of select="$prmBaseClass"/>
        </xsl:attribute>
        <xsl:call-template name="tplSetHighlight" >
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>

  </xsl:template>

  <!-- Take first prmLength symbols from prmInput and if shorten then add '...' at the end -->
  <xsl:template name ="tplShortenString">
    <xsl:param name ="prmLength"/>
    <xsl:param name ="prmInput" />
    <xsl:choose>
      <xsl:when test ="string-length($prmInput)>$prmLength">
        <xsl:value-of select="concat(substring($prmInput,1,$prmLength),'...')"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$prmInput"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
	
	<!-- Draw content of themes popup, "theme selector"-->
	<xsl:template match="WG:GZTS">
	<div id="themecontainer" vwgowner='{//GZMVIEW/@Attr.OwnerID}'>      
      <xsl:call-template name='tplThemeContainer'>
        <xsl:with-param name='prmTheme' select='"Default"'/>
        <xsl:with-param name='prmTitle' select='"Default Theme"'/>
        <xsl:with-param name='prmImg' select='"default"'/>
      </xsl:call-template>
      <xsl:call-template name='tplThemeContainer'>
        <xsl:with-param name='prmTheme' select='"Vista"'/>
        <xsl:with-param name='prmTitle' select='"Vista Theme"'/>
        <xsl:with-param name='prmImg' select='"vista"'/>
      </xsl:call-template>            
	  <xsl:call-template name='tplThemeContainer'>
	  	<xsl:with-param name='prmTheme' select='"Gmail"'/>
	  	<xsl:with-param name='prmTitle' select='"Gmail"'/>
	  	<xsl:with-param name='prmImg' select='"gmail"'/>
	  </xsl:call-template>
	  <xsl:call-template name='tplThemeContainer'>
	  	<xsl:with-param name='prmTheme' select='"Analytics"'/>
	  	<xsl:with-param name='prmTitle' select='"Analytics"'/>
	  	<xsl:with-param name='prmImg' select='"analytics"'/>
	  </xsl:call-template>
	  <xsl:call-template name='tplThemeContainer'>
	  	<xsl:with-param name='prmTheme' select='"FaceBook"'/>
	  	<xsl:with-param name='prmTitle' select='"FaceBook"'/>
	  	<xsl:with-param name='prmImg' select='"facebook"'/>
	  </xsl:call-template>
	  <xsl:call-template name='tplThemeContainer'>
	  	<xsl:with-param name='prmTheme' select='"Office2010"'/>
	  	<xsl:with-param name='prmTitle' select='"Office 2010"'/>
	  	<xsl:with-param name='prmImg' select='"office2010"'/>
	  </xsl:call-template>
      <xsl:call-template name='tplThemeContainer'>
        <xsl:with-param name='prmTheme' select='"iOS"'/>
        <xsl:with-param name='prmTitle' select='"iOS"'/>
        <xsl:with-param name='prmImg' select='"ios"'/>
      </xsl:call-template>
      <xsl:call-template name='tplThemeContainer'>
        <xsl:with-param name='prmTheme' select='"Android"'/>
        <xsl:with-param name='prmTitle' select='"Android"'/>
        <xsl:with-param name='prmImg' select='"android"'/>
      </xsl:call-template>
      <xsl:call-template name='tplThemeContainer'>
        <xsl:with-param name='prmTheme' select='"Graphite"'/>
        <xsl:with-param name='prmTitle' select='"Graphite"'/>
        <xsl:with-param name='prmImg' select='"graphite"'/>
      </xsl:call-template>
      <xsl:call-template name='tplThemeContainer'>
          <xsl:with-param name='prmTheme' select='"iOS7"'/>
          <xsl:with-param name='prmTitle' select='"iOS7"'/>
          <xsl:with-param name='prmImg' select='"iOS7"'/>
      </xsl:call-template>

		</div>
	</xsl:template>

	<xsl:template name='tplThemeContainer'>
		<xsl:param name='prmTheme'/>
		<xsl:param name='prmTitle'/>
		<xsl:param name='prmImg'/>
		<div vwgtheme='{$prmTheme}' title='{$prmTitle}'
			onmouseover="NavigationView_ThemeHighlight(this);"
			onmouseout="NavigationView_ThemeHighlight(this);"
			onclick="NavigationView_ThemeClick(this);">
			<xsl:attribute name="class">
				<xsl:text>themeimagecontainer</xsl:text>
				<xsl:if test="'Context.CurrentTheme'=$prmTheme"> selectedtheme</xsl:if>
			</xsl:attribute>
      <span class="themetitle" style="display:block;"><xsl:value-of select="$prmTitle"/></span>
			<img class='themeimage' src="{concat('[Skin.Path]themes.',$prmImg,'.png.wgx')}"/>
		</div>
	</xsl:template>		
	
	<!-- Render the share toolbox -->
	<xsl:template name="tplShare">
		<div id="toolbox" class="addthis_toolbox addthis_default_style" 
			 style="float:right; margin:12px 0px; height:16px; overflow:hidden;">
		</div>
	</xsl:template>

</xsl:stylesheet>
