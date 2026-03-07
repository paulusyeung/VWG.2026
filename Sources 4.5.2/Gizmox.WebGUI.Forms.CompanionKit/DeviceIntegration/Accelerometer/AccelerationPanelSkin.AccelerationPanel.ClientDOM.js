vwgContext.acceleratePanel = function (acceleration, ball, ballParent)
{    
   accelerateBall(acceleration, ball, ballParent);
};

function accelerateBall(acceleration, ball, ballParent)
{
    console.log("ACC accelerate func");
    if (acceleration && acceleration.x && acceleration.y) {
        var ballPosition = ball.position();
        
        var position = { "left": Math.max(0, Math.min(ballPosition.left - acceleration.x - acceleration.x, ballParent.width() - 50)), "top": Math.max(0, Math.min(ballPosition.top + acceleration.y + acceleration.y, ballParent.height() - 50)) };
        ball.css({"left": position.left + "px", "top" : position.top + "px"});
    }
}
