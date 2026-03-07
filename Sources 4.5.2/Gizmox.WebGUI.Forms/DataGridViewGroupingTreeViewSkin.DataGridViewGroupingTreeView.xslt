<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  <!-- GroupingTreeView -->
  <xsl:template match="WC:Tags.TreeView[@Attr.CustomStyle='GroupingTreeView']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmTreeViewClass" select="'TreeView-Control'"/>
    <xsl:param name="prmGridId" select="ancestor::WC:Tags.DataGridView/@Attr.Id"/>

    <xsl:variable name="varTopNodePlaceHolderHeight" select="[Skin.TopNodePlaceHolderHeight]"/>

    <xsl:attribute name="class">
      <xsl:value-of select="$prmTreeViewClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmTreeViewClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:call-template name="tplCompleteScrollCapabilities"/>

    <div class="Common-Unselectable TreeView-Container" dir="{$dir}" style="overflow:auto;">
      <xsl:call-template name="tplApplyScrollableAttributes" />
      <xsl:call-template name="tplRestoreScroll" />
      <div class="TreeView-PaddingContainer" style="display:block;">
        <div style="width:100%; height: {$varTopNodePlaceHolderHeight}px;" id="VWGNODECONTAINER_{$prmGridId}">
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
        <xsl:apply-templates select="Tags.TreeNode" mode="modGrouping">
          <xsl:with-param name="prmTreeView" select="."/>
          <xsl:with-param name="prmGridId" select="$prmGridId"/>
        </xsl:apply-templates>
        <xsl:if test="count(Tags.TreeNode)=0">&#160;</xsl:if>
      </div>
    </div>
  </xsl:template>

  <!-- GroupingTreeView node-->
  <xsl:template match="Tags.TreeNode" mode="modGrouping">
    <!-- TreeNode parameters-->
    <xsl:param name="prmTreeView" select="ancestor::WC:Tags.TreeView"/>
    <xsl:param name="prmGridId"/>

    <xsl:variable name="varIsRootNode" select="name(parent::node())='WC:Tags.TreeView'"/>
    <xsl:variable name="prmTreeNodeJointImage" select="'[Skin.TreeNodeJointImage]'"/>
    <xsl:variable name="varTreeNodeJointClass" select="'DataGridViewGroupingTreeView-Joint'"/>
    <xsl:variable name="varTreeNodeClass" select="'DataGridViewGroupingTreeView-Node'"/>
    <xsl:variable name="varTreeNodeCloseButtonClass" select="'DataGridViewGroupingTreeView-CloseButton'"/>
    <xsl:variable name="varTreeNodeJointImageWidth" select="[Skin.TreeNodeJointImageWidth]"/>
    <xsl:variable name="varTreeNodeJointImageHeight" select="[Skin.TreeNodeJointImageHeight]"/>
    <xsl:variable name="varTreeNodeHeight" select="[Skin.TreeNodeHeight]"/>
    <xsl:variable name="varTreeNodePaddingTop" select="[Skin.TreeNodePaddingTop]"/>
    <xsl:variable name="varDataPropertyName" select="@Attr.Name"/>
    <xsl:variable name="varHeaderText"><xsl:call-template name="tplDecodeText"><xsl:with-param name="prmText" select="@Attr.Text"/></xsl:call-template></xsl:variable>

    <!-- TreeNode root element-->
    <div id="VWG_{@Attr.Id}">
      <!-- TreeNode row container -->
      <div id="VWGNODE_{@Attr.Id}" class="DataGridViewGroupingTreeView-RowContainer">

        <!-- TreeNode joint container -->
        <div id="VWGJOINT_{@Attr.Id}" class="{$varTreeNodeJointClass}">

          <xsl:if test="not($varIsRootNode)">
            <xsl:attribute name="style">
              background: url('<xsl:value-of select="$prmTreeNodeJointImage"/>') no-repeat <xsl:value-of select="$left"/> center;  padding-<xsl:value-of select="$left"/>: <xsl:value-of select="$varTreeNodeJointImageWidth"/>px;
            </xsl:attribute>
          </xsl:if>

          <!-- TreeNode text container -->
          <div id="VWGNODECONTAINER_{@Attr.Id}" class="DataGridViewGroupingTreeView-TextContainer" data-vwggroupingcolumnname="{$varDataPropertyName}">
            <span class="{$varTreeNodeClass}" id="VWGNODEBODY_{@Attr.Id}">
              <span class="nobr" id="VWGLE_{@Attr.Id}">
                <xsl:attribute name="style">
                  <xsl:if test="(not(@Attr.Font) and $prmTreeView/@Attr.Font) or (not(@Attr.Fore) and $prmTreeView/@Attr.Fore)">
                    <xsl:call-template name="tplApplyFontStyles">
                      <xsl:with-param name="prmTarget" select="$prmTreeView" />
                    </xsl:call-template>;
                  </xsl:if>
                  display: inline-block; float: <xsl:value-of select="$left"/>;
                </xsl:attribute>
                <xsl:if test="$varHeaderText and not($varHeaderText='')">
                  <xsl:call-template name="tplDecodeTextAsHtml"/>
                </xsl:if>
                <xsl:if test="not($varHeaderText) or $varHeaderText=''">&#160;</xsl:if>
              </span>
              <span class="Common-HandCursor {$varTreeNodeCloseButtonClass}" style="float: {$left};" onclick="mobjApp.DataGridViewGroupingTreeView_CloseGroup('{$prmTreeView/@Attr.Id}','{$varDataPropertyName}', event, window);">
                <xsl:call-template name="tplDrawEmptyImage"/>
              </span>
            </span>
          </div>
        </div>
      </div>

      <!-- If there are sub nodes-->
      <xsl:if test="count(Tags.TreeNode)>0">

        <!-- TreeNode child container element-->
        <div id="VWGSUBS_{@Attr.Id}" class="TreeView-SubNodesContainer">
          <xsl:attribute name="style">
            top: -<xsl:value-of select="number($varTreeNodeJointImageHeight - $varTreeNodeHeight - $varTreeNodePaddingTop)"/>px;
            <xsl:if test="not($varIsRootNode)">
              padding-<xsl:value-of select="$left"/>: <xsl:value-of select="$varTreeNodeJointImageWidth"/>px;
            </xsl:if>
          </xsl:attribute>
          <xsl:apply-templates select="Tags.TreeNode" mode="modGrouping" >
            <xsl:with-param name="prmTreeView" select="$prmTreeView"/>
            <xsl:with-param name="prmGridId" select="$prmGridId"/>
          </xsl:apply-templates>
        </div>
      </xsl:if>
    </div>
  </xsl:template>
</xsl:stylesheet>