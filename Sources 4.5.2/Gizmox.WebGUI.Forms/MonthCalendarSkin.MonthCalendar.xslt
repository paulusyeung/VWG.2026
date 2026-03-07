<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

	<xsl:template match="WC:Tags.MonthCalendar[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:attribute name="class">
      <xsl:text>MonthCalendar-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> MonthCalendar-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>
    <xsl:variable name="varTotal" select="@DisplayStart + @DisplayDays - 1"/>
		<xsl:variable name="varOverflow" select="$varTotal mod 7"/>
		<xsl:variable name="varNumElements">
			<xsl:choose>
				<xsl:when test="$varOverflow > 0">
					<xsl:value-of select="$varTotal + 7 - $varOverflow"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$varTotal"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
    <xsl:variable name="varDataMaximumDateYear">
      <xsl:choose>
        <xsl:when test="@Attr.MaximumDateYear and @Attr.MaximumDateYear!=''">
          <xsl:value-of select="@Attr.MaximumDateYear"/>
        </xsl:when>
        <xsl:otherwise>9998</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDataMaximumDateMonth">
      <xsl:choose>
        <xsl:when test="@Attr.MaximumDateMonth and @Attr.MaximumDateMonth!=''">
          <xsl:value-of select="@Attr.MaximumDateMonth"/>
        </xsl:when>
        <xsl:otherwise>12</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDataMaximumDateDay">
      <xsl:choose>
        <xsl:when test="@Attr.MaximumDateDay and @Attr.MaximumDateDay!=''">
          <xsl:value-of select="@Attr.MaximumDateDay"/>
        </xsl:when>
        <xsl:otherwise>31</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDataMinimumDateYear">
      <xsl:choose>
        <xsl:when test="@Attr.MinimumDateYear and @Attr.MinimumDateYear!=''">
          <xsl:value-of select="@Attr.MinimumDateYear"/>
        </xsl:when>
        <xsl:otherwise>1753</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDataMinimumDateMonth">
      <xsl:choose>
        <xsl:when test="@Attr.MinimumDateMonth and @Attr.MinimumDateMonth!=''">
          <xsl:value-of select="@Attr.MinimumDateMonth"/>
        </xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDataMinimumDateDay">
      <xsl:choose>
        <xsl:when test="@Attr.MinimumDateDay and @Attr.MinimumDateDay!=''">
          <xsl:value-of select="@Attr.MinimumDateDay"/>
        </xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaxYear">
      <xsl:choose>
        <xsl:when test="@DisplayYear=$varDataMaximumDateYear">
          <xsl:value-of select="$varDataMaximumDateYear"/>
        </xsl:when>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMinYear">
      <xsl:choose>
        <xsl:when test="@DisplayYear=$varDataMinimumDateYear">
          <xsl:value-of select="$varDataMinimumDateYear"/>
        </xsl:when>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaxMonth">
      <xsl:if test="$varMaxYear!=''">
        <xsl:value-of select="$varDataMaximumDateMonth"/>
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varMinMonth">
      <xsl:if test="$varMinYear!=''">
        <xsl:value-of select="$varDataMinimumDateMonth"/>
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varMaxDay">
      <xsl:if test="$varMaxYear!=''">
        <xsl:if test="@DisplayMonth=$varDataMaximumDateMonth">
          <xsl:value-of select="$varDataMaximumDateDay"/>
        </xsl:if>
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varMinDay">
      <xsl:if test="$varMinYear!=''">
        <xsl:if test="@DisplayMonth=$varDataMinimumDateMonth">
          <xsl:value-of select="$varDataMinimumDateDay"/>
        </xsl:if>
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varMinDecadeYear">
      <xsl:choose>
        <xsl:when test="@DisplayYear > 10">
          <xsl:value-of select="floor(number(@DisplayYear) div 10)"/><xsl:text>0</xsl:text>
        </xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaxDecadeYear">
      <xsl:choose>
        <xsl:when test="@DisplayYear > 10">
          <xsl:value-of select="floor(number(@DisplayYear) div 10)"></xsl:value-of><xsl:text>9</xsl:text>
        </xsl:when>
        <xsl:otherwise>9</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMinCenturyYear">
      <xsl:choose>
        <xsl:when test="@DisplayYear > 100">
          <xsl:value-of select="floor(number(@DisplayYear) div 100)"/><xsl:text>00</xsl:text>
        </xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaxCenturyYear">
      <xsl:choose>
        <xsl:when test="@DisplayYear > 100">
          <xsl:value-of select="floor(number(@DisplayYear) div 100)"></xsl:value-of><xsl:text>99</xsl:text>
        </xsl:when>
        <xsl:otherwise>99</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDisablePrevious">
      <xsl:choose>
        <xsl:when test="@Attr.CalanderViewType = '3'">
          <xsl:choose>
            <xsl:when test="$varMinCenturyYear &lt;= $varDataMinimumDateYear and $varDataMinimumDateYear &lt;= $varMaxCenturyYear">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:when test="@Attr.CalanderViewType = '2'">
          <xsl:choose>
            <xsl:when test="$varMinDecadeYear &lt;= $varDataMinimumDateYear and $varDataMinimumDateYear &lt;= $varMaxDecadeYear">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:when test="@Attr.CalanderViewType = '1'">
          <xsl:choose>
            <xsl:when test="$varMinMonth!=''">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="$varMinDay!=''">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varDisableNext">
      <xsl:choose>
        <xsl:when test="@Attr.CalanderViewType = '3'">
          <xsl:choose>
            <xsl:when test="$varMinCenturyYear &lt;= $varDataMaximumDateYear and $varDataMaximumDateYear &lt;= $varMaxCenturyYear">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:when test="@Attr.CalanderViewType = '2'">
          <xsl:choose>
            <xsl:when test="$varMinDecadeYear &lt;= $varDataMaximumDateYear and $varDataMaximumDateYear &lt;= $varMaxDecadeYear">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:when test="@Attr.CalanderViewType = '1'">
          <xsl:choose>
            <xsl:when test="$varMaxMonth!=''">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="$varMaxDay!=''">true</xsl:when>
            <xsl:otherwise>false</xsl:otherwise>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <table dir="{$dir}">
      <xsl:attribute name="class"><xsl:text>Common-CellPadding0 Common-CellSpacing0 Common-FontData Common-Unselectable Common-DefaultCursor MonthCalendar-Table</xsl:text>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:text> MonthCalendar-Control_Disabled</xsl:text></xsl:if></xsl:attribute>
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyStyles" >
          <xsl:with-param name="prmBorder" select="1" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
          <xsl:with-param name="prmVisualEffects" select="0" />
        </xsl:call-template>
      </xsl:attribute>
      <tr class="MonthCalendar-Caption">
        <td class="MonthCalendar-FontSigns Common-HandCursor Common-AlignCenter">
          <xsl:if test="$varDisablePrevious='false'">
            <xsl:attribute name="onclick">mobjApp.Calendar_Previous('<xsl:value-of select="@Attr.Id"/>')</xsl:attribute>
          </xsl:if>
          <div class="Common-Strech MonthCalendar-BidirectionalNavigateNextPreviousContainersStyle MonthCalendar-BidirectionalNavigatePreviousStyle" style="height:[Skin.CaptionHeight]px;line-height">
            <img width="[Skin.PreviousImageWidth]" height="[Skin.PreviousImageHeight]"  src="[Skin.PreviousImage]" alt="">
              <xsl:if test="not($ltr='LTR')">
                <xsl:attribute name="class">Common-FlipH</xsl:attribute>
              </xsl:if>
            </img>
          </div>
        </td>
        <td colspan="5">
          <xsl:if test="not(@Attr.CalanderViewType='3')">
            <xsl:attribute name="onclick">mobjApp.Calendar_SwitchView('<xsl:value-of select="@Attr.Id"/>');</xsl:attribute>
          </xsl:if>

          <!--CalanderViewType.Days-->
          <xsl:if test="not(@Attr.CalanderViewType)">
            <xsl:value-of select="@Attr.DisplayYearMonth"/>
          </xsl:if>

          <!--CalanderViewType.Month-->
          <xsl:if test="@Attr.CalanderViewType = '1'">
            <xsl:value-of select="@DisplayYear"/>
          </xsl:if>

          <!--CalanderViewType.Years-->
          <xsl:if test="@Attr.CalanderViewType = '2'">
            <xsl:if test="@DisplayYear > 10">
              <xsl:value-of select="floor(number(@DisplayYear) div 10)"></xsl:value-of>0-<xsl:value-of select="floor(number(@DisplayYear) div 10)"></xsl:value-of><xsl:text>9</xsl:text>
            </xsl:if>
            <xsl:if test="not(@DisplayYear > 10)">
              <xsl:text>0-9</xsl:text>
            </xsl:if>
          </xsl:if>

          <!--CalanderViewType.YearRange-->
          <xsl:if test="@Attr.CalanderViewType = '3'">
            <xsl:if test="@DisplayYear > 100">
              <xsl:value-of select="floor(number(@DisplayYear) div 100)"></xsl:value-of>00-<xsl:value-of select="floor(number(@DisplayYear) div 100)"></xsl:value-of><xsl:text>99</xsl:text>
            </xsl:if>
            <xsl:if test="not(@DisplayYear > 100)">
              <xsl:text>0-99</xsl:text>
            </xsl:if>
          </xsl:if>
        </td>
        <td class="MonthCalendar-FontSigns Common-HandCursor Common-AlignCenter">
          <xsl:if test="$varDisableNext='false'">
            <xsl:attribute name="onclick">mobjApp.Calendar_Next('<xsl:value-of select="@Attr.Id"/>')</xsl:attribute>
          </xsl:if>
          <div class="Common-Strech MonthCalendar-BidirectionalNavigateNextPreviousContainersStyle MonthCalendar-BidirectionalNavigateNextStyle">
            <img width="[Skin.NextImageWidth]" height="[Skin.NextImageHeight]"  src="[Skin.NextImage]" alt="" >
              <xsl:if test="not($ltr='LTR')">
                <xsl:attribute name="class">Common-FlipH</xsl:attribute>
              </xsl:if>
            </img>
          </div>
        </td>
      </tr>
      
      <!--CalanderViewType.Days-->
      <xsl:if test="not(@Attr.CalanderViewType)">
        <xsl:call-template name="tplDrawDays">
          <xsl:with-param name="prmNumElements" select="$varNumElements"/>
          <xsl:with-param name="prmMinDay" select="$varMinDay"/>
          <xsl:with-param name="prmMaxDay" select="$varMaxDay"/>
        </xsl:call-template>
     </xsl:if>
      
      <!--CalanderViewType.Month-->
      <xsl:if test="@Attr.CalanderViewType = '1'">
        <xsl:call-template name="tplDrawMonths">
          <xsl:with-param name="prmMinMonth" select="$varMinMonth"/>
          <xsl:with-param name="prmMaxMonth" select="$varMaxMonth"/>
        </xsl:call-template>
      </xsl:if>

      <!--CalanderViewType.Years-->
      <xsl:if test="@Attr.CalanderViewType = '2'">
        <xsl:call-template name="tplDrawYears">
          <xsl:with-param name="prmMinDecadeYear">
            <xsl:choose>
              <xsl:when test="$varMinDecadeYear &lt;= $varDataMinimumDateYear and $varDataMinimumDateYear &lt;= $varMaxDecadeYear">
                <xsl:value-of select="number($varDataMinimumDateYear) mod 10"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>0</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmMaxDecadeYear">
            <xsl:choose>
              <xsl:when test="$varMinDecadeYear &lt;= $varDataMaximumDateYear and $varDataMaximumDateYear &lt;= $varMaxDecadeYear">
                <xsl:value-of select="number($varDataMaximumDateYear) mod 10"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>9</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
        </xsl:call-template>
      </xsl:if>

      <!--CalanderViewType.YearsRange-->
      <xsl:if test="@Attr.CalanderViewType = '3'">
        <xsl:call-template name="tplDrawYearsRange">
          <xsl:with-param name="prmMinCenturyYear">
            <xsl:choose>
              <xsl:when test="$varMinCenturyYear &lt;= $varDataMinimumDateYear and $varDataMinimumDateYear &lt;= $varMaxCenturyYear">
                <xsl:value-of select="number($varDataMinimumDateYear) mod 100"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>0</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
          <xsl:with-param name="prmMaxCenturyYear">
            <xsl:choose>
              <xsl:when test="$varMinCenturyYear &lt;= $varDataMaximumDateYear and $varDataMaximumDateYear &lt;= $varMaxCenturyYear">
                <xsl:value-of select="number($varDataMaximumDateYear) mod 100"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:text>99</xsl:text>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:with-param>
        </xsl:call-template>
      </xsl:if>
    </table>
  </xsl:template>

  <!-- Disable styles that are not used in MonthCalendar -->
  <xsl:template match="WC:Tags.MonthCalendar[not(@Attr.CustomStyle)]" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBorder" select="0" />
      <xsl:with-param name="prmBackground" select="0" />
      <xsl:with-param name="prmFont" select="1" />
      <xsl:with-param name="prmCursor" select="1" />
    </xsl:call-template>
  </xsl:template>
  
  <!--CalanderViewType.Days-->
  <xsl:template name="tplDrawDays">
    <xsl:param name="prmNumElements"/>
    <xsl:param name="prmMinDay"/>
    <xsl:param name="prmMaxDay"/>
    	<tr Class="MonthCalendar-Headers">
				  <xsl:if test="@DisplayFirstWeekDay &lt; 2"><td class="Common-VAlignMiddle">Labels.SundayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &lt; 3"><td class="Common-VAlignMiddle">Labels.MondayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &lt; 4"><td class="Common-VAlignMiddle">Labels.TuesdayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &lt; 5"><td class="Common-VAlignMiddle">Labels.WednesdayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &lt; 6"><td class="Common-VAlignMiddle">Labels.ThursdayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &lt; 7"><td class="Common-VAlignMiddle">Labels.FridayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &lt; 8"><td class="Common-VAlignMiddle">Labels.SaturdayAbbreviated</td></xsl:if>
          <xsl:if test="@DisplayFirstWeekDay &gt; 1"><td class="Common-VAlignMiddle">Labels.SundayAbbreviated</td></xsl:if>
          <xsl:if test="@DisplayFirstWeekDay &gt; 2"><td class="Common-VAlignMiddle">Labels.MondayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &gt; 3"><td class="Common-VAlignMiddle">Labels.TuesdayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &gt; 4"><td class="Common-VAlignMiddle">Labels.WednesdayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &gt; 5"><td class="Common-VAlignMiddle">Labels.ThursdayAbbreviated</td></xsl:if>
				  <xsl:if test="@DisplayFirstWeekDay &gt; 6"><td class="Common-VAlignMiddle">Labels.FridayAbbreviated</td></xsl:if>
			</tr>
			<xsl:call-template name="tplCalendarMonth">
			  <xsl:with-param name="prmNumElements" select="$prmNumElements"/>
        <xsl:with-param name="prmMinDay" select="$prmMinDay"/>
        <xsl:with-param name="prmMaxDay" select="$prmMaxDay"/>
			</xsl:call-template>
  </xsl:template>
  
  <!--CalanderViewType.YearsRange-->
  <xsl:template name="tplDrawYearsRange">
    <xsl:param name="prmMinCenturyYear"/>
    <xsl:param name="prmMaxCenturyYear"/>
    <tr>
      <td colspan="7" style="[Skin.YearRangeViewPadding]">
        <table class="Common-FontData Common-CellPadding0 Common-CellSpacing0" style="height:100%;width:100%;table-layout:auto;" >
          <colgroup>
          <col style="width:25%"/>
          <col style="width:25%"/>
          <col style="width:25%"/>
          <col style="width:25%"/>
          </colgroup>
          <tr style="height:[Skin.MonthCellHeight]px;">
            <!--Drow empty cell-->
            <xsl:call-template name="tplDrawYearRangeCell"/>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="0"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="10"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="20"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
          </tr>
          <tr style="height:[Skin.MonthCellHeight]px;">
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="30"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="40"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="50"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="60"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
          </tr>
          <tr style="height:[Skin.MonthCellHeight]px;">
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="70"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="80"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearRangeCell">
              <xsl:with-param name="prmYear" select="90"/>
              <xsl:with-param name="prmMinCenturyYear" select="$prmMinCenturyYear"/>
              <xsl:with-param name="prmMaxCenturyYear" select="$prmMaxCenturyYear"/>
            </xsl:call-template>
            <!--Drow empty cell-->
            <xsl:call-template name="tplDrawYearRangeCell"/>
          </tr>
        </table>
      </td>
    </tr>
  </xsl:template>

  <!--CalanderViewType.YearsRange Cell-->
  <xsl:template name="tplDrawYearRangeCell">
    <xsl:param name="prmYear" select="-1"/>
    <xsl:param name="prmMinCenturyYear"/>
    <xsl:param name="prmMaxCenturyYear"/>

    <xsl:choose>
      <xsl:when test="not(number($prmYear) = -1) and (($prmYear &lt;= (ceiling(number($prmMaxCenturyYear) div 10) * 10)) and ($prmYear >= (floor(number($prmMinCenturyYear) div 10) * 10)))">
        <xsl:if test="number(@DisplayYear) > 100">
          <xsl:if test="number($prmYear) = 0">
            <xsl:variable name="varYear" select="floor(number(@DisplayYear) div 100) * 100"/>
            <td onclick="mobjApp.Calendar_Choose('{@Id}','{$varYear}',3);">
              <xsl:call-template name="tplSetHighlight"/>
              <xsl:if test="number(@DisplayYear) &gt; (number($varYear)-1) and number(@DisplayYear) &lt; number($varYear)+10"><xsl:attribute name="class">MonthCalendar-YearRangeSelected Common-VAlignMiddle</xsl:attribute></xsl:if>
              <xsl:if test="not(number(@DisplayYear) &gt; (number($varYear)-1) and number(@DisplayYear) &lt; number($varYear)+10)"><xsl:attribute name="class">MonthCalendar-YearRange Common-VAlignMiddle</xsl:attribute></xsl:if>
              <div><xsl:value-of select="$varYear"/>-</div>
              <div><xsl:value-of select="floor(number(@DisplayYear) div 100)"/>09</div>
            </td>
          </xsl:if>
          <xsl:if test="not(number($prmYear) = 0)">
            <xsl:variable name="varYear" select="floor(number(@DisplayYear) div 100) * 100 +$prmYear"/>
            <td onclick="mobjApp.Calendar_Choose('{@Id}','{$varYear}',3);">
              <xsl:call-template name="tplSetHighlight"/>
              <xsl:if test="number(@DisplayYear) &gt; (number($varYear)-1) and number(@DisplayYear) &lt; number($varYear)+10"><xsl:attribute name="class">MonthCalendar-YearRangeSelected Common-VAlignMiddle</xsl:attribute></xsl:if>
              <xsl:if test="not(number(@DisplayYear) &gt; (number($varYear)-1) and number(@DisplayYear) &lt; number($varYear)+10)"><xsl:attribute name="class">MonthCalendar-YearRange Common-VAlignMiddle</xsl:attribute>
                </xsl:if>
              <div><xsl:value-of select="floor(number(@DisplayYear) div 100)"/><xsl:value-of select="$prmYear"/>-</div>
              <div><xsl:value-of select="floor(number(@DisplayYear) div 100)"/><xsl:value-of select="number($prmYear)+9"/></div>
            </td>
          </xsl:if>
        </xsl:if>
        <xsl:if test="not(number(@DisplayYear) >100)">
          <xsl:if test="number($prmYear) = 0">
            <td onclick="mobjApp.Calendar_Choose('{@Id}',0,3)">
                <xsl:call-template name="tplSetHighlight"/>
                <xsl:if test="number(@DisplayYear) &gt; -1 and number(@DisplayYear) &lt; 10"><xsl:attribute name="class">MonthCalendar-YearRangeSelected Common-VAlignMiddle</xsl:attribute></xsl:if>
                <xsl:if test="not(number(@DisplayYear) &gt; -1 and number(@DisplayYear) &lt; 10)"><xsl:attribute name="class">MonthCalendar-YearRange Common-VAlignMiddle</xsl:attribute></xsl:if>0-9</td>
          </xsl:if>
          <xsl:if test="not(number($prmYear) = 0)">
            <td onclick="mobjApp.Calendar_Choose('{@Id}','{$prmYear}',3)">
                <xsl:call-template name="tplSetHighlight"/>
              <xsl:if test="number(@DisplayYear) &gt; (number($prmYear)-1) and number(@DisplayYear) &lt; number($prmYear)+10"><xsl:attribute name="class">MonthCalendar-YearRangeSelected Common-VAlignMiddle</xsl:attribute></xsl:if>
                <xsl:if test="not(number(@DisplayYear) &gt; (number($prmYear)-1) and number(@DisplayYear) &lt; number($prmYear)+10)"><xsl:attribute name="class">MonthCalendar-YearRange Common-VAlignMiddle</xsl:attribute></xsl:if>
              <div><xsl:value-of select="$prmYear"/>-</div>
              <div><xsl:value-of select="number($prmYear)+9"/></div>
            </td>
          </xsl:if>
        </xsl:if>
      </xsl:when>
      <xsl:otherwise><td/></xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--CalanderViewType.Years-->
  <xsl:template name="tplDrawYears">
    <xsl:param name="prmMinDecadeYear"/>
    <xsl:param name="prmMaxDecadeYear"/>
    <tr>
      <td colspan="7" style="[Skin.YearViewPadding]">
        <table class="Common-FontData Common-CellPadding0 Common-CellSpacing0" style="height:100%;width:100%;table-layout:auto;" >
          <colgroup>
          <col style="width:25%"/>
          <col style="width:25%"/>
          <col style="width:25%"/>
          <col style="width:25%"/>
          </colgroup>
          <tr style="height:[Skin.MonthCellHeight]px;">
            <xsl:call-template name="tplDrawYearCell"/>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="0"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="1"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="2"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
          </tr>
          <tr style="height:[Skin.MonthCellHeight]px;">
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="3"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="4"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="5"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="6"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
          </tr>
          <tr style="height:[Skin.MonthCellHeight]px;">
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="7"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="8"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell">
              <xsl:with-param name="prmYear" select="9"/>
              <xsl:with-param name="prmMinDecadeYear" select="$prmMinDecadeYear"/>
              <xsl:with-param name="prmMaxDecadeYear" select="$prmMaxDecadeYear"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawYearCell"/>
          </tr>
        </table>
      </td>
    </tr>
  </xsl:template>

  <!--CalanderViewType.Years cell-->
  <xsl:template name="tplDrawYearCell">
    <xsl:param name="prmYear" select="-1"/>
    <xsl:param name="prmMinDecadeYear"/>
    <xsl:param name="prmMaxDecadeYear"/>

    <xsl:variable name="varCalcYear" select="floor(number(@DisplayYear) div 10)"></xsl:variable>
    <xsl:choose>
      <xsl:when test="not($prmYear = '-1') and ($prmYear &lt;= $prmMaxDecadeYear) and ($prmYear >=$prmMinDecadeYear)">
        <td onclick="mobjApp.Calendar_Choose('{@Id}',{$varCalcYear}{$prmYear},2)">
            <xsl:call-template name="tplSetHighlight"/>
            <xsl:if test="floor(number(@DisplayYear) mod 10) = $prmYear"><xsl:attribute name="class">MonthCalendar-YearCellSelected Common-VAlignMiddle</xsl:attribute></xsl:if>          
            <xsl:if test="not(floor(number(@DisplayYear) mod 10) = $prmYear)"><xsl:attribute name="class">MonthCalendar-YearCell Common-VAlignMiddle</xsl:attribute></xsl:if>
          <xsl:if test="$varCalcYear > 0"><xsl:value-of select="$varCalcYear"/><xsl:value-of select="$prmYear"/></xsl:if>
          <xsl:if test="not($varCalcYear > 0)"><xsl:value-of select="$prmYear"/></xsl:if>
        </td>
      </xsl:when>
      <xsl:otherwise><td/></xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--CalanderViewType.Months -->
  <xsl:template name="tplDrawMonths">
    <xsl:param name="prmMinMonth"/>
    <xsl:param name="prmMaxMonth"/>
    <tr>
      <td colspan="7" style="[Skin.MonthViewPadding]">
        <table class="Common-FontData Common-CellPadding0 Common-CellSpacing0" style="height:100%;width:100%;table-layout:auto;" >
          <tr style="height:[Skin.MonthCellHeight]px;">              
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="1"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="2"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="3"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="4"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
          </tr>
          <tr style="height:[Skin.MonthCellHeight]px;">           
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="5"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="6"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="7"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="8"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
          </tr>
          <tr style="height:[Skin.MonthCellHeight]px;">              
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="9"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="10"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="11"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
            <xsl:call-template name="tplDrawMonthCell">
              <xsl:with-param name="prmMonth" select="12"/>
              <xsl:with-param name="prmMinMonth" select="$prmMinMonth"/>
              <xsl:with-param name="prmMaxMonth" select="$prmMaxMonth"/>
            </xsl:call-template>
          </tr>
        </table>
      </td>
    </tr>
  </xsl:template>

  <!--CalanderViewType.Months cell-->
  <xsl:template name="tplDrawMonthCell">
    <xsl:param name="prmMonth"/>
    <xsl:param name="prmMinMonth"/>
    <xsl:param name="prmMaxMonth"/>
    <xsl:choose>
      <xsl:when test="($prmMinMonth!='' and number($prmMinMonth) > number($prmMonth)) or ($prmMaxMonth!='' and number($prmMonth) > number($prmMaxMonth))">
        <td/>
      </xsl:when>
      <xsl:otherwise>
        <td onclick="mobjApp.Calendar_Choose('{@Id}',{$prmMonth},1)">
            <xsl:call-template name="tplSetHighlight"/>
          <xsl:if test="@DisplayMonth = $prmMonth">
            <xsl:attribute name="class">MonthCalendar-MounthCellSelected Common-VAlignMiddle</xsl:attribute>
          </xsl:if>
            <xsl:if test="not(@DisplayMonth = $prmMonth)" >
            <xsl:attribute name="class">MonthCalendar-MonthCell Common-VAlignMiddle</xsl:attribute>  
            </xsl:if> 
          <xsl:if test="$prmMonth = 1">Labels.JanuaryShort</xsl:if>
          <xsl:if test="$prmMonth = 2">Labels.FebruaryShort</xsl:if>
          <xsl:if test="$prmMonth = 3">Labels.MarchShort</xsl:if>
          <xsl:if test="$prmMonth = 4">Labels.AprilShort</xsl:if>
          <xsl:if test="$prmMonth = 5">Labels.MayShort</xsl:if>
          <xsl:if test="$prmMonth = 6">Labels.JuneShort</xsl:if>
          <xsl:if test="$prmMonth = 7">Labels.JulyShort</xsl:if>
          <xsl:if test="$prmMonth = 8">Labels.AugustShort</xsl:if>
          <xsl:if test="$prmMonth = 9">Labels.SeptemberShort</xsl:if>
          <xsl:if test="$prmMonth = 10">Labels.OctoberShort</xsl:if>
          <xsl:if test="$prmMonth = 11">Labels.NovemberShort</xsl:if>
          <xsl:if test="$prmMonth = 12">Labels.DecemberShort</xsl:if>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="tplCalendarMonth">
    <xsl:param name="prmIndex" select="1"/>
    <xsl:param name="prmWeeks" select="1"/>
    <xsl:param name="prmNumElements"/>
    <xsl:param name="prmMinDay"/>
    <xsl:param name="prmMaxDay"/>
    <xsl:if test="$prmWeeks &lt; 7">
      <xsl:call-template name="tplCalendarWeek">
        <xsl:with-param name="prmIndex" select="$prmIndex"/>
        <xsl:with-param name="prmMinDay" select="$prmMinDay"/>
        <xsl:with-param name="prmMaxDay" select="$prmMaxDay"/>
      </xsl:call-template>
      <xsl:call-template name="tplCalendarMonth">
        <xsl:with-param name="prmIndex" select="$prmIndex + 7"/>
        <xsl:with-param name="prmWeeks" select="$prmWeeks + 1"/>
        <xsl:with-param name="prmNumElements" select="$prmNumElements"/>
        <xsl:with-param name="prmMinDay" select="$prmMinDay"/>
        <xsl:with-param name="prmMaxDay" select="$prmMaxDay"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplCalendarWeek">
    <xsl:param name="prmIndex" select="1"/>
    <xsl:param name="prmMinDay"/>
    <xsl:param name="prmMaxDay"/>

    <xsl:if test="$prmIndex - @DisplayStart + 1 &lt;= @DisplayDays">
      <tr>
        <xsl:call-template name="tplCalendarDays">
          <xsl:with-param name="prmIndex" select="$prmIndex"/>
          <xsl:with-param name="prmCounter" select="$prmIndex + 6"/>
          <xsl:with-param name="prmMinDay" select="$prmMinDay"/>
          <xsl:with-param name="prmMaxDay" select="$prmMaxDay"/>
        </xsl:call-template>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplCalendarDays">
    <xsl:param name="prmIndex" select="1"/>
    <xsl:param name="prmCounter" select="1"/>
    <xsl:param name="prmMinDay"/>
    <xsl:param name="prmMaxDay"/>
    <xsl:variable name="varCurrentIndex" select="$prmIndex - @DisplayStart + 1"/>
    <xsl:choose>
      <xsl:when test="($prmMinDay!='' and $varCurrentIndex &lt; $prmMinDay) or ($prmMaxDay!='' and $varCurrentIndex > $prmMaxDay)">
        <!-- The day is less than MinDate or higher than MaxDate --> 
        <td class="MonthCalendar-NormalCell">&#160;</td>          
      </xsl:when>
      <xsl:otherwise><!--We're in range-->
        <xsl:variable name="varDisplayDay">
          <xsl:choose>
            <xsl:when test="$prmIndex &lt; @DisplayStart">
              <xsl:value-of select="number(@DisplayPreviousMonthLastDay) - number(@DisplayStart) + $prmIndex + 1" />
            </xsl:when>
            <xsl:when test="$varCurrentIndex &gt; @DisplayDays">
              <xsl:value-of select="$varCurrentIndex - number(@DisplayDays)" />
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="$varCurrentIndex"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        
        <xsl:variable name="varIsExternalMonth">
          <xsl:choose>
            <xsl:when test="($prmIndex &lt; @DisplayStart) or ($varCurrentIndex &gt; @DisplayDays)">1</xsl:when>
            <xsl:otherwise>0</xsl:otherwise>
          </xsl:choose>
        </xsl:variable>

        <xsl:variable name="varIsSelected">
          <xsl:choose>
            <xsl:when test="$prmIndex - @DisplayStart + 1 &gt;= @Attr.SelectionStartDay and $prmIndex - @DisplayStart + 1 &lt;= @Attr.SelectionEndDay and @DisplayMonth &gt;= @Attr.SelectionStartMonth and @DisplayMonth &lt;= @Attr.SelectionEndMonth and @DisplayYear &gt;= @Attr.SelectionStartYear and @DisplayYear &lt;= @Attr.SelectionEndYear">1</xsl:when>
            <xsl:otherwise>0</xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        
        <xsl:variable name="varIsToday">
          <xsl:choose>
            <xsl:when test="@TodayDay and @TodayDay=$varCurrentIndex">1</xsl:when>
            <xsl:otherwise>0</xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        
        <xsl:variable name="varClass">
          <xsl:choose>
            <xsl:when test="$varIsToday='1' and $varIsSelected='1'">MonthCalendar-TodaySelected</xsl:when>
            <xsl:when test="$varIsToday='1'">MonthCalendar-Today</xsl:when>
            <xsl:when test="$varIsExternalMonth='1'">MonthCalendar-ExternalMonthDays</xsl:when>
            <xsl:when test="$varIsSelected='1'">MonthCalendar-SelectedDay</xsl:when>
            <xsl:otherwise>MonthCalendar-NormalCell</xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        
        <xsl:variable name="varStyle">
          <xsl:if test="@Attr.Fore">
            <xsl:text>color:</xsl:text>
            <xsl:value-of select="@Attr.Fore"/>
            <xsl:text>;</xsl:text>
          </xsl:if>
          <xsl:if test="@Attr.BoldedDays">
            <xsl:if test="contains(concat(',',@Attr.BoldedDays,','),concat(',',$varCurrentIndex,','))">
              <xsl:text>font-weight:bold;</xsl:text>
            </xsl:if>
          </xsl:if>
        </xsl:variable>
        
        <td onclick="mobjApp.Calendar_Choose('{@Id}',{$varCurrentIndex},0)">
          <xsl:call-template name="tplSetHighlight"/>
            <xsl:attribute name="class">MonthCalendar-Cell <xsl:value-of select="$varClass" /></xsl:attribute>
            <xsl:attribute name="style"><xsl:value-of select="$varStyle" /></xsl:attribute>
          <xsl:value-of select="$varDisplayDay"/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
    <xsl:if test="$prmCounter > $prmIndex">
      <xsl:call-template name="tplCalendarDays">
        <xsl:with-param name="prmIndex" select="$prmIndex + 1"/>
        <xsl:with-param name="prmCounter" select="$prmCounter"/>
        <xsl:with-param name="prmMinDay" select="$prmMinDay"/>
        <xsl:with-param name="prmMaxDay" select="$prmMaxDay"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>