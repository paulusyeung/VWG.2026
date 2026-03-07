<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!-- TreeView -->
  <xsl:template match="WC:Tags.TreeView[not(@Attr.CustomStyle) and @Attr.VisualTemplate='TreeViewVisualTemplateWithPaging']" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawVisualTemplateTreeViewAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawVisualTemplateTreeViewAPI">
    <xsl:param name="prmApplyScrollable" select="1"/>
    <xsl:param name="prmControlClass" select="'TreeView-Control'"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varSelectedNode" select="descendant-or-self::Tags.TreeNode[@SE = '1']" />
    <xsl:variable name="varSelectedNodeParent" select="$varSelectedNode/.." migration-select="varSelectedNode.xpath(&quot;..&quot;)"/>
    <xsl:variable name="varSelectedNodeParentId" select="$varSelectedNodeParent/@Id" />

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:if test="$prmApplyScrollable='1'">
      <xsl:call-template name="tplCompleteScrollCapabilities"/>
    </xsl:if>
    <div id="VWGTREECONTAINER_{@Id}" class="Common-Unselectable TreeView-Container" dir="{$dir}" onkeydown="mobjApp.TreeView_KeyDown({@Id},window,event);" data-vwgfocuselement="1" tabindex="-1">
      <xsl:if test="$prmApplyScrollable='1'">
        <xsl:attribute name="style">overflow:auto;</xsl:attribute>
        <xsl:call-template name="tplApplyScrollableAttributes" />
        <xsl:call-template name="tplRestoreScroll" />
      </xsl:if>
      <xsl:call-template name="tplDrawVisualTamplateTreeViewNodesContainer">
        <xsl:with-param name="prmTreeView" select="."/>
        <xsl:with-param name="prmSelectedNodeParentId" select="$varSelectedNodeParentId"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </div>
  </xsl:template>


  <xsl:template name="tplDrawVisualTamplateTreeViewNodesContainer">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmTreeView" select="ancestor::WC:Tags.TreeView"/>
    <xsl:param name="prmSelectedNodeParentId" />
    <xsl:param name="prmHidePlusMinus" select="$prmTreeView/@Attr.HidePlusMinus"/>
    <xsl:param name="prmIsRoot" select="'1'"/>
    <xsl:param name="prmVisualTemplateNodesContainerClass" select="'TreeViewVisualTemplate-PaddingContainer'"/>
    <xsl:param name="prmVisualTemplateBackContainerClass" select="'TreeViewVisualTemplate-BackContainer'"/>
    <xsl:param name="prmVisualTemplateBackButtonClass" select="'TreeViewVisualTemplate-BackButton'"/>

    <xsl:variable name="varCurrentViewedNodePage" select="$prmTreeView/@CURRENTVIEWEDNODEPAGE"/>
    <xsl:variable name="varRequestedViewedNodePage" select="$prmTreeView/@REQUESTEDVIEWEDNODEPAGE"/>
    <xsl:variable name="varRequestedViewedNode" select="$prmTreeView/descendant-or-self::Tags.TreeNode[@Id=$varRequestedViewedNodePage]" migration-select="prmTreeView.xpath(&quot;descendant-or-self::node()[@Id =&quot; + ((varRequestedViewedNodePage)?varRequestedViewedNodePage:'&quot;&quot;') + &quot;]&quot;)"/>
    <xsl:variable name="varRequestedViewedNodeParent" select="$varRequestedViewedNode/.." migration-select="varRequestedViewedNode.xpath(&quot;..&quot;)"/>
    <xsl:variable name="varRequestedViewedNodeParentId" select="$varRequestedViewedNodeParent/@Id" />
    <xsl:variable name="varCurrentId" select="@Id"/>
    <xsl:variable name="varParentId" select="../@Id"/>
    <xsl:variable name="varParentText">
      <xsl:if test="@Attr.Text and not(@Attr.Text='')"><xsl:value-of select="@Attr.Text"/></xsl:if>
      <xsl:if test="not(@Attr.Text) or @Attr.Text=''"><xsl:value-of select="$prmTreeView/@Attr.VisualTemplateTreeViewBackButtonText"/></xsl:if>
    </xsl:variable>
    <xsl:variable name="varIsShown" select="($varCurrentId=$varCurrentViewedNodePage and not($varRequestedViewedNodePage)) or (not($varRequestedViewedNodePage) and $prmIsRoot='1' and not($prmSelectedNodeParentId)) or ($prmSelectedNodeParentId = $varCurrentId and not($varRequestedViewedNodePage))" />
    <xsl:variable name="varIsRequested" select="$varCurrentId=$varRequestedViewedNodePage" />

    <div>
      <xsl:attribute name="id"><xsl:value-of select="concat('VWGSUBS_', $varCurrentId)"/></xsl:attribute>
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="$varIsShown">
            <xsl:value-of select="$prmVisualTemplateNodesContainerClass"/>
          </xsl:when>
          <xsl:when test="(not($varRequestedViewedNodePage) and $prmSelectedNodeParentId and $varCurrentId &lt; $prmSelectedNodeParentId) or ($varRequestedViewedNodePage and $varRequestedViewedNodeParentId and $varRequestedViewedNodeParentId = $varCurrentId)">
            <xsl:value-of select="concat($prmVisualTemplateNodesContainerClass,' ',$prmVisualTemplateNodesContainerClass,'_HiddenRight')"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="concat($prmVisualTemplateNodesContainerClass,' ',$prmVisualTemplateNodesContainerClass,'_HiddenLeft')"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:if test="$prmIsRoot='0'">
        <xsl:call-template name="tplDrawVisualTamplateTreeViewBack">
          <xsl:with-param name="prmCurrentId" select="$varCurrentId"/>
          <xsl:with-param name="prmParentId" select="$varParentId" />
          <xsl:with-param name="prmButtonText" select="$varParentText" />
          <xsl:with-param name="prmTreeView" select="$prmTreeView"/>
          <xsl:with-param name="prmVisualTemplateBackContainerClass" select="$prmVisualTemplateBackContainerClass" />
          <xsl:with-param name="prmVisualTemplateBackButtonClass" select="$prmVisualTemplateBackButtonClass" />
        </xsl:call-template>
      </xsl:if>
      <xsl:apply-templates select="Tags.TreeNode">
        <xsl:with-param name="prmTreeView" select="$prmTreeView"/>
        <xsl:with-param name="prmSelectedNodeParentId" select="$prmSelectedNodeParentId"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        <xsl:with-param name="prmHidePlusMinus" select="$prmHidePlusMinus"/>
      </xsl:apply-templates>
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod" select="concat('mobjApp.TreeViewVisualTemplate_NodesOnLoad(',$varCurrentId,',window,',$varIsRequested,');')"/>
      </xsl:call-template>
    </div>
  </xsl:template>


  <xsl:template name="tplDrawVisualTamplateTreeViewBack">
    <xsl:param name="prmCurrentId" />
    <xsl:param name="prmParentId" />
    <xsl:param name="prmButtonText" />
    <xsl:param name="prmTreeView" />
    <xsl:param name="prmVisualTemplateBackContainerClass" />
    <xsl:param name="prmVisualTemplateBackButtonClass" />

    <div class="{$prmVisualTemplateBackContainerClass}">
      <div class="{$prmVisualTemplateBackButtonClass}" onclick="mobjApp.TreeViewVisualTemplate_BackOnClick({$prmCurrentId},{$prmParentId},window,event);" style="height:{$prmTreeView/@Attr.VisualTemplateTreeViewBackButtonHeight}px;">
        <img>
          <xsl:attribute name="src">[Skin.TreeViewVisualTempalteButtonImage]</xsl:attribute>
          <xsl:attribute name="style">vertical-align:middle;</xsl:attribute>          
        </img>
        <span class="nobr" data-vwgtype="label"><xsl:value-of select="$prmButtonText"/></span>
      </div>
    </div>
  </xsl:template>

  <!-- TreeNode -->
  <xsl:template match="Tags.TreeNode[ancestor-or-self::WC:Tags.TreeView/@Attr.VisualTemplate='TreeViewVisualTemplateWithPaging']">
    <!-- TreeNode parameters-->
    <xsl:param name="prmTreeView" select="ancestor::WC:Tags.TreeView"/>
    <xsl:param name="prmSelectedNodeParentId"/>
    <xsl:param name="prmCheckBoxes" select="@Attr.CheckBoxes='1'"/>
    <xsl:param name="prmStateImageChecked" select="$prmTreeView/@Attr.StateImageChecked"/>
    <xsl:param name="prmStateImageUnchecked" select="$prmTreeView/@Attr.StateImageUnchecked"/>
    <xsl:param name="prmHidePlusMinus" select="$prmTreeView/@Attr.HidePlusMinus"/>
    <xsl:param name="prmShowLines" select="$prmTreeView/@Attr.ShowLines"/>
    <xsl:param name="prmHasNext" select="following-sibling::Tags.TreeNode[position()=1]"/>
    <xsl:param name="prmHasPrev" select="1"/>
    <xsl:param name="prmIsRootNode" select="name(parent::node())='WC:Tags.TreeView'"/>
    <xsl:param name="prmExpandLable" select="not(@Attr.StateImage) and not(@Attr.CheckBoxes='1') and ../*[@Attr.StateImage]" />
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:variable name="varHeight" select="$prmTreeView/@Attr.VisualTemplateTreeViewItemHeight"/>
    <!-- TreeNode root element-->
    <div id="VWG_{@Id}">
      <xsl:call-template name="tplSetClientUniqueId" />
      <xsl:attribute name="data-vwg_AfterCreateEventHandler">TreeView_AfterCreateTreeNodeEvents</xsl:attribute>

      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyOnDrawVisualEffects" />
      </xsl:attribute>
      <xsl:call-template name="tplApplyAfterDrawVisualEffects" />

      <!-- TreeNode row container -->
      <div id="VWGNODE_{@Id}" data-vwgtype="root"
           onmousedown="mobjApp.TreeViewVisualTemplate_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','mousedown',window,event)"
           onmouseup="mobjApp.TreeViewVisualTemplate_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','mouseup',window,event)"
           ondblclick="mobjApp.TreeViewVisualTemplate_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','dblclick',window,event)"
           onclick="mobjApp.TreeViewVisualTemplate_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','click',window,event)"
           style="height:{$varHeight}px;">


        <xsl:choose>
          <xsl:when test="@Attr.Selected='1'">
            <xsl:attribute name="class">TreeView-RowContainer TreeView-RowContainer_Selected</xsl:attribute>
          </xsl:when>
          <xsl:otherwise>
            <xsl:attribute name="class">TreeView-RowContainer</xsl:attribute>
          </xsl:otherwise>
        </xsl:choose>

        <xsl:if test="@Attr.HasNodes='1'">
          <!-- TreeNode joint container -->
          <div id="VWGJOINT_{@Id}" class="Common-HandCursor TreeView-ImageContainer TreeViewVisualTemplate-JointContainer" data-vwgtype="joint">
            <xsl:attribute name="style">background-image:url([Skin.TreeViewVisualTemplateNext]);background-position:<xsl:value-of select="$right"/> center;float:<xsl:value-of select="$right"/>;</xsl:attribute>
          </div>
        </xsl:if>

        <!-- TreeNode checkbox / stateimage container -->
        <div id="VWGCHECKBOX_{@Id}" class="Common-HandCursor TreeView-ImageContainer" data-vwgtype="checkbox">

          <!-- If we need to draw the checkbox or the state image -->
          <xsl:choose>
            <xsl:when test="$prmCheckBoxes">
              <xsl:attribute name="style">
                padding-<xsl:value-of select="$left"/>:17px;
                background-position:<xsl:value-of select="$left"/> center;
                <xsl:if test="@Attr.HasNodes='1'">
                  <xsl:choose>
                    <xsl:when test="$dir='RTL'">margin-left:[Skin.TreeViewVisualTemplateNextWidth]px;</xsl:when>
                    <xsl:otherwise>margin-right:[Skin.TreeViewVisualTemplateNextWidth]px;</xsl:otherwise>
                  </xsl:choose>
                </xsl:if>
                <!--If there is a state image defined (with CheckBoxes)-->
                <xsl:if test="$prmStateImageChecked">
                  <xsl:choose>
                    <xsl:when test="@Attr.Checked='1'">
                      background-image:url(<xsl:value-of select="$prmStateImageChecked"/>);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url(<xsl:value-of select="$prmStateImageUnchecked"/>);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:if>

                <!--If there is NOT a state image defined, only CheckBoxes -->
                <xsl:if test="not($prmStateImageChecked)">
                  <xsl:choose>
                    <xsl:when test="@Attr.Checked='1'">
                      background-image:url([Skin.Path]CheckBox1.gif.wgx);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url([Skin.Path]CheckBox0.gif.wgx);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:if>
              </xsl:attribute>
            </xsl:when>
            <xsl:when test="(@Attr.StateImage) and not(@Attr.CheckBoxes='1')">
              <xsl:attribute name="style">
                padding-<xsl:value-of select="$left"/>:17px;
                background-position:<xsl:value-of select="$left"/> center;
                background-image:url(<xsl:value-of select="@Attr.StateImage"/>);
              </xsl:attribute>
            </xsl:when>
          </xsl:choose>

          <!-- TreeNode icon container -->
          <div id="VWGICON_{@Id}" class="TreeView-ImageContainer" data-vwgtype="icon">

            <!-- If we need to draw node icon -->
            <xsl:if test="@Attr.Image">
              <xsl:attribute name="style">
                padding-<xsl:value-of select="$left"/>:17px;
                background-position:<xsl:value-of select="$left"/> center;

                <xsl:choose>
                  <xsl:when test="@Attr.Selected='1' and @Attr.SelectedImage">
                    background-image:url(<xsl:value-of select="@Attr.SelectedImage"/>);
                  </xsl:when>
                  <xsl:when test="count(Tags.TreeNode)>0 and not(@Attr.Expanded='0') and @Attr.ExpandedImage">
                    background-image:url(<xsl:value-of select="@Attr.ExpandedImage"/>);
                  </xsl:when>
                  <xsl:otherwise>
                    background-image:url(<xsl:value-of select="@Attr.Image"/>);
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:attribute>
            </xsl:if>

            <!-- TreeNode text container -->
            <div class="Common-HandCursor TreeView-TextContainer" data-vwgtype="text">
              <xsl:call-template name="tplSetToolTip">
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>

              <span id="VWGLE_{@Id}" class="nobr TreeView-Label" data-vwgtype="label">
                <xsl:if test="$prmTreeView/@Attr.LabelEdit='1' and @Attr.Selected='1'">
                  <xsl:attribute name="data-vwglabeledit">1</xsl:attribute>
                </xsl:if>
                <xsl:attribute name="style">
                  <xsl:if test="@Attr.Font or @Attr.Fore">
                    <xsl:call-template name="tplApplyFontStyles"><xsl:with-param name="prmFont"><xsl:if test="$prmTreeView/@Attr.VisualTemplateUseOriginalFont='1' and @Attr.Font"><xsl:value-of select="@Attr.Font"/></xsl:if></xsl:with-param></xsl:call-template>;
                  </xsl:if>
                  <xsl:if test="(not(@Attr.Font) and $prmTreeView/@Attr.Font) or (not(@Attr.Fore) and $prmTreeView/@Attr.Fore)">
                    <xsl:call-template name="tplApplyFontStyles">
                      <xsl:with-param name="prmTarget" select="$prmTreeView" />
                      <xsl:with-param name="prmFont"><xsl:if test="$prmTreeView/@Attr.VisualTemplateUseOriginalFont='1' and $prmTreeView/@Attr.Font"><xsl:value-of select="$prmTreeView/@Attr.Font"/></xsl:if></xsl:with-param>
                    </xsl:call-template>;
                  </xsl:if>
                  <xsl:if test="@Attr.Background">background:<xsl:value-of select="@Attr.Background"/>;</xsl:if>
                  line-height:<xsl:value-of select="$varHeight"/>px!important;
                </xsl:attribute>
                <xsl:if test="@Attr.Text and not(@Attr.Text='')">
                  <xsl:call-template name="tplDecodeTextAsHtml"/>
                </xsl:if>
                <xsl:if test="not(@Attr.Text) or @Attr.Text=''">&#160;</xsl:if>
              </span>
            </div>
          </div>
        </div>
      </div>



      <!-- If there are sub nodes-->
      <xsl:if test="count(Tags.TreeNode)>0">

        <xsl:call-template name="tplDrawVisualTamplateTreeViewNodesContainer" >
          <xsl:with-param name="prmTreeView" select="$prmTreeView"/>
          <xsl:with-param name="prmSelectedNodeParentId" select="$prmSelectedNodeParentId"/>
          <xsl:with-param name="prmHidePlusMinus" select="$prmHidePlusMinus"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          <xsl:with-param name="prmIsRoot" select="'0'"/>
        </xsl:call-template>


      </xsl:if>

    </div>
  </xsl:template>

</xsl:stylesheet>