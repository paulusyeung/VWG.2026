
/// <summary>
/// Gets or sets the heading.
/// </summary>
vwgContext.compassHeading = function (dblHeading)
{
    compassHeading(dblHeading);
};

function compassHeading(dblHeading)
{
    var arrow = document.getElementById("VWG_ARROW");

    if (arrow && dblHeading >= 0 && dblHeading <= 360)
    {
        arrow.style.webkitTransform = "rotate(-" + dblHeading + "deg)";
    }
}