(function($){
    
    // Defines gesture handling events
    $.fn.handlergestures = function(options) {


        // Indicates if not an empty element
        function _empty(element)
        {
            // If there is an element
            if(element)
            {
                // If there is a size function
                if($.isFunction(element.size))
                {
                    // If has items
                    return element.size() == 0;
                }
            }
            
            return true;
        }
        
        // Get the number of fingures
        function _fingures(e)
        {
            return e.targetTouches.length;
        }
        
        // Gets a position from the event
        function _position(e)
        {
            var targetTouch = e.targetTouches[0];
            return [targetTouch.clientX, targetTouch.clientY];
        }
        
        // Gets a target supporting ability
        function _target(target, ability)
        {            
            // If there is a valid target
            if(!_empty(target))
            {
                // If target has ability
                if(target.data(ability)=='yes')
                {
                    // Return target
                    return target;
                }
                else
                {
                    // Return parent
                    return _target(target.parent(), ability);
                }
            }
            
            // 
            return null;
        }

        // A flag indicating if in gesture mode
        var inGestureMode = false;
        
        // The 
        var _options = {           
            swipeHandler : function(){console.log('no swipe handler.');},
            swipeDelta : [100,100]            
        };
        
        // merge defaults with arguments
        $.extend(_options, options);
        
        // Loop all elements and bind events
        this.each(function(){  

            // Bind the touch event
            $(this).bind('touchstart', function(e) {  
            
                // If is a valid touch event
                if (_fingures(event) == 1 && !inGestureMode)
                {

                    // Get the target element
                    var target = $(e.target);

                    // Get the swipable target definition
                    var swipableTarget = _target(target, 'swipable');

                    // Get the current start position
                    var startpos = _position(event);

                    // Get the last position
                    var lastpos = startpos;

                    // The last touch move delta
                    var lastdelta = [0, 0];

                    // The last touch delta time 1
                    var lastdeltatime1 = null;

                    // The last touch delta time 2
                    var lastdeltatime2 = new Date();

                    // If should handle touch events
                    if (swipableTarget)
                    {              
                        // Handle touch move
                        function onTouchMove(e)
                        {
                            // If is a valid touch move event
                            if (_fingures(event)!=1 || inGestureMode) return false;
                        
                            // Get the current position
                            var currentpos = _position(event);
                        
                            // Get the delta
                            var delta = lastdelta = [currentpos[0]-lastpos[0], currentpos[1]-lastpos[1]];
                        
                            // Store last delta sample time
                            lastdeltatime1 = lastdeltatime2;
                        
                            // Store current sample time
                            lastdeltatime2 = new Date();
                        
						    // Set the current position
                            lastpos=currentpos;
                        }
                    
                            // Handler touch end
                        function onTouchEnd(e)
                        {
                            // If is a valid touch end event
                            if (_fingures(event) != 0 || inGestureMode) return false;

                            // If there is a swipable target
                            if (swipableTarget)
                            {
                                // Get the touch delta
                                var delta = [lastpos[0] - startpos[0], lastpos[1] - startpos[1]];

                                // If larger horizontal swipe
                                if (Math.abs(delta[0]) > _options.swipeDelta[0])
                                {
                                    // If within vertical delta
                                    if (Math.abs(delta[1]) <= _options.swipeDelta[1])
                                    {
                                        // Call the swipe handler
                                        _options.swipeHandler.call(swipableTarget, delta[0] > 0 ? "right" : "left");
                                    }
                                }
                            }                            
                        
                            // Unbind the touch events
                            target.unbind('touchmove', onTouchMove);
                            target.unbind('touchend', onTouchEnd);
                        }
                    
                    
                    
                        // Bind to the touch move and touch end events
                        target.bind('touchmove', onTouchMove);
                        target.bind('touchend', onTouchEnd);
                    }

                }
            });            
        });
    };
})(jQuery);

/// <method name="Array.Web_GetQueryStringParam">
/// <summary>
/// Gets an query string param value from a url.
/// </summary>
/// <param name="strUrl">The URL to extract params from.</param>
/// <param name="strParam">The param to extract.</param>
$(function(){

    // Implement gestures handlers
    $("body").handlergestures({
        
        swipeHandler : function(strDirection){
            // Get VWG source element.
            var objVwgSourceElement = Web_GetVwgElement(this[0]);
            if(objVwgSourceElement)
            {            
                // Get component ID.
                var strDataId = Data_GetDataId(objVwgSourceElement.id);
                if(!Aux_IsNullOrEmpty(strDataId))
                {
                    // Create a swipe event.
                    var objEvent = Events_CreateEvent(strDataId,"Swipe");
                
                    // Set the direction attribute value.
                    Events_SetEventAttribute(objEvent,"Attr.Direction",strDirection=="left"?"0":"1");
        	        
	                // Check if event is critical for tihs component.
                    if (Data_IsCriticalEvent(strDataId, "Event.Swipe"))
                    {
                        // Raise events.
                        Events_RaiseEvents();
                    }
                }
            }
        }
    });
});
/// </method>