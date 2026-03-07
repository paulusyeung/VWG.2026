<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:TV" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawTreeViewAPI">
      <xsl:with-param name="prmApplyScrollable" select="0"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawTreeViewAPI">
    <xsl:param name="prmApplyScrollable" select="1"/>
    <xsl:param name="prmControlClass" select="'TreeView-Control'"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:if test="$prmApplyScrollable='1'">
      <xsl:call-template name="tplCompleteScrollCapabilities"/>
    </xsl:if>
    <div class="Common-Unselectable TreeView-Container" dir="{$dir}" onkeydown="mobjApp.TreeView_KeyDown({@Id},window,event);" data-vwgfocuselement="1" tabindex="-1">
      <xsl:if test="$prmApplyScrollable='1'">
        <xsl:attribute name="style">overflow:auto;</xsl:attribute>
        <xsl:call-template name="tplApplyScrollableAttributes" />
        <xsl:call-template name="tplRestoreScroll" />
      </xsl:if>
      <div class="TreeView-PaddingContainer">
        <xsl:apply-templates select="TN">
          <xsl:with-param name="prmTreeView" select="."/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:apply-templates>
        <xsl:if test="count(TN)=0"><xsl:call-template name="tplDrawEmptyImage"/></xsl:if>
      </div>
    </div>
  </xsl:template>
  
  <!-- TreeView -->
  <xsl:template match="WC:TV[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawTreeViewAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template> 

  <!-- TreeNode -->
  <xsl:template match="TN[not(ancestor-or-self::WC:TV/@Attr.VisualTemplate)]">

    <!-- TreeNode parameters-->
    <xsl:param name="prmTreeView" select="ancestor::WC:TV"/>
    <xsl:param name="prmCheckBoxes" select="@Attr.CheckBoxes='1'"/>
    <xsl:param name="prmStateImageChecked" select="$prmTreeView/@Attr.StateImageChecked"/>
    <xsl:param name="prmStateImageUnchecked" select="$prmTreeView/@Attr.StateImageUnchecked"/>
    <xsl:param name="prmHidePlusMinus" select="$prmTreeView/@Attr.HidePlusMinus"/>
    <xsl:param name="prmShowLines" select="$prmTreeView/@Attr.ShowLines"/>
    <xsl:param name="prmHasNext" select="following-sibling::TN[position()=1]"/>
    <xsl:param name="prmHasPrev" select="1"/>
    <xsl:param name="prmIsRootNode" select="name(parent::node())='WC:TV'"/>
    <xsl:param name="prmExpandLable" select="not(@Attr.StateImage) and not(@Attr.CheckBoxes='1') and ../*[@Attr.StateImage]" />
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:variable name="varHeight" select="$prmTreeView/@Attr.ItemHeight"/>
    <!-- TreeNode root element-->
    <div id="VWG_{@Id}">
      <xsl:call-template name="tplSetClientUniqueId" />
      <xsl:attribute name="data-vwg_AfterCreateEventHandler">TreeView_AfterCreateTreeNodeEvents</xsl:attribute>

      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyOnDrawVisualEffects" />
      </xsl:attribute>
      <xsl:call-template name="tplApplyAfterDrawVisualEffects" />

      <xsl:call-template name="tplApplyDragAndDrop" />

      <!-- TreeNode row container -->
      <div id="VWGNODE_{@Id}" data-vwgtype="root"
           onmousedown="mobjApp.TreeView_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','mousedown',window,event)"
           onmouseup="mobjApp.TreeView_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','mouseup',window,event)"
           ondblclick="mobjApp.TreeView_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','dblclick',window,event)"
           onclick="mobjApp.TreeView_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','click',window,event)"
           style="height:{$varHeight}px;">


        <xsl:choose>
          <xsl:when test="@Attr.Selected='1'">
            <xsl:attribute name="class">TreeView-RowContainer TreeView-RowContainer_Selected</xsl:attribute>
          </xsl:when>
          <xsl:otherwise>
            <xsl:attribute name="class">TreeView-RowContainer</xsl:attribute>
          </xsl:otherwise>
        </xsl:choose>

        <!-- TreeNode joint container -->
        <div id="VWGJOINT_{@Id}" class="Common-HandCursor TreeView-ImageContainer" data-vwgtype="joint">

          <xsl:attribute name="style">

            <!-- If we need to draw the joint padding -->
            <xsl:if test="not($prmHidePlusMinus) or ($prmShowLines='1')">
              padding-<xsl:value-of select="$left"/>:17px;
              background-position:<xsl:value-of select="$left"/> center;
            </xsl:if>

            <!-- If we need to draw the joint -->
            <xsl:if test="not($prmIsRootNode) or ($prmShowLines='1') or not($prmHidePlusMinus)">
              <xsl:choose>
                <xsl:when test="count(TN)>0 and not(@Attr.Expanded='0') and not($prmHidePlusMinus)">
                  <xsl:choose>
                    <xsl:when test="$prmShowLines='1' and $prmHasNext and $prmHasPrev">
                      background-image:url([Skin.Path]TreeView11<xsl:value-of select="$dir"/>0.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and $prmHasNext and not($prmHasPrev)">
                      background-image:url([Skin.Path]TreeView01<xsl:value-of select="$dir"/>0.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and not($prmHasNext) and $prmHasPrev">
                      background-image:url([Skin.Path]TreeView10<xsl:value-of select="$dir"/>0.gif.wgx);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url([Skin.Path]TreeView0.gif.wgx);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="not(@Attr.HasNodes='0') and @Attr.Expanded='0' and not($prmHidePlusMinus)">
                  <xsl:choose>
                    <xsl:when test="$prmShowLines='1' and $prmHasNext and $prmHasPrev">
                      background-image:url([Skin.Path]TreeView11<xsl:value-of select="$dir"/>1.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and $prmHasPrev and not($prmHasNext)">
                      background-image:url([Skin.Path]TreeView10<xsl:value-of select="$dir"/>1.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and not($prmHasPrev) and $prmHasNext">
                      background-image:url([Skin.Path]TreeView01<xsl:value-of select="$dir"/>1.gif.wgx);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url([Skin.Path]TreeView1.gif.wgx);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:if test="not($prmShowLines='1')">
                    background-image:url([Skin.Path]Empty.gif.wgx);
                  </xsl:if>
                  <xsl:if test="$prmShowLines='1'">
                    <xsl:choose>
                      <xsl:when test="$prmShowLines='1' and $prmHasNext and $prmHasPrev">
                        background-image:url([Skin.Path]TreeViewEmpty11<xsl:value-of select="$dir"/>.gif.wgx);
                      </xsl:when>
                      <xsl:when test="$prmShowLines='1' and $prmHasNext and not($prmHasPrev)">
                        background-image:url([Skin.Path]TreeViewEmpty01<xsl:value-of select="$dir"/>.gif.wgx);
                      </xsl:when>
                      <xsl:when test="$prmShowLines='1' and not($prmHasNext) and $prmHasPrev">
                        background-image:url([Skin.Path]TreeViewEmpty10<xsl:value-of select="$dir"/>.gif.wgx);
                      </xsl:when>
                    </xsl:choose>
                  </xsl:if>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:if>
          </xsl:attribute>

          <!-- TreeNode checkbox / stateimage container -->
          <div id="VWGCHECKBOX_{@Id}" class="Common-HandCursor TreeView-ImageContainer" data-vwgtype="checkbox">

            <!-- If we need to draw the checkbox or the state image -->
            <xsl:choose>
              <xsl:when test="$prmCheckBoxes">
                <xsl:attribute name="style">
                  padding-<xsl:value-of select="$left"/>:17px;
                  background-position:<xsl:value-of select="$left"/> center;

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
                    <xsl:when test="count(TN)>0 and not(@Attr.Expanded='0') and @Attr.ExpandedImage">
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
                  <xsl:if test="$prmTreeView/@Attr.LabelEdit='1' and @Attr.Selected='1'"><xsl:attribute name="data-vwglabeledit">1</xsl:attribute></xsl:if>
                  <xsl:attribute name="style">
                    <xsl:if test="@Attr.Font or @Attr.Fore">
                      <xsl:call-template name="tplApplyFontStyles"/>;
                    </xsl:if>
                    <xsl:if test="(not(@Attr.Font) and $prmTreeView/@Attr.Font) or (not(@Attr.Fore) and $prmTreeView/@Attr.Fore)">
                      <xsl:call-template name="tplApplyFontStyles"><xsl:with-param name="prmTarget" select="$prmTreeView" /></xsl:call-template>;
                    </xsl:if>                    
                    <xsl:if test="@Attr.Background">background:<xsl:value-of select="@Attr.Background"/>;</xsl:if>
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
      </div>

      <!-- If there are sub nodes-->
      <xsl:if test="count(TN)>0">

        <!-- TreeNode child container element-->
        <div id="VWGSUBS_{@Id}" class="TreeView-SubNodesContainer">

          <xsl:attribute name="style">
            padding-<xsl:value-of select="$left" />:17px;
            <xsl:if test="@Attr.Expanded='0' or @Attr.Loaded='0'">
              display:none;
            </xsl:if>
            <xsl:if test="not($prmIsRootNode) or ($prmShowLines='1') or not($prmHidePlusMinus)">
              <xsl:if test="$prmShowLines='1' and $prmHasNext">
                background-image:url([Skin.Path]TreeViewConnector<xsl:value-of select="$dir" />.gif.wgx);
                background-position:<xsl:value-of select="$left" /> top;
                background-repeat:repeat-y;
              </xsl:if>
            </xsl:if>
          </xsl:attribute>

          <!--Check if node is expanded or loaded-->
          <xsl:if test="not(@Attr.Expanded='0') or not(@Attr.Loaded='0')">
            <xsl:apply-templates select="TN">
              <xsl:with-param name="prmTreeView" select="$prmTreeView"/>
              <xsl:with-param name="prmHidePlusMinus" select="$prmHidePlusMinus"/>
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:apply-templates>
          </xsl:if>
        </div>
      </xsl:if>

    </div>
  </xsl:template>

  <xsl:template match="TN" mode="modDragged">
    <div>
      <span class="nobr">
        <xsl:if test="@Attr.Image">
          <img class="Common-VAlignMiddle Common-Icon16X16" src="{@Attr.Image}" alt="{@Attr.Text}"/>
        </xsl:if>
        <span class="TreeView-Label" style="vertical-align:middle;">
          <xsl:if test="not(@Attr.Text='')">
            <xsl:call-template name="tplDecodeTextAsHtml"/>
          </xsl:if>
          <xsl:if test="@Attr.Text=''">&#160;</xsl:if>
        </span>
      </span>
    </div>
  </xsl:template>
</xsl:stylesheet>


