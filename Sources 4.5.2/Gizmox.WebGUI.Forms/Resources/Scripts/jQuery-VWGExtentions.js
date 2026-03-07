var mcntIsIE = /MSIE ([^;]*)|Trident.*; rv:([0-9.]+)/.test(navigator.userAgent);

// Add some unimplemented jQuery functions
(function ($)
{
    //List of events that matches mouse events for accessibility
    var arrAccessibilityEvents = [
        { sourceEvent: "mouseover", destinationEvent: "onfocus" },
        { sourceEvent: "mouseenter", destinationEvent: "onfocus" },
        { sourceEvent: "mouseout", destinationEvent: "onblur" },
        { sourceEvent: "mouseleave", destinationEvent: "onblur" },
        { sourceEvent: "mouseout", destinationEvent: "onfocusout" },
        { sourceEvent: "mouseleave", destinationEvent: "onfocusout" },
        { sourceEvent: "mousedown", destinationEvent: "onkeydown" },
        { sourceEvent: "mouseup", destinationEvent: "onkeyup" }
    ];


    if ($.fn)
    {
        if (!$.fn.scrollWidth)
        {
            $.fn.extend({
                scrollWidth: function ()
                {
                    return this[0].scrollWidth;
                }
            });
        }

        if (!$.fn.scrollHeight)
        {
            $.fn.extend({
                scrollHeight: function ()
                {
                    return this[0].scrollHeight;
                }
            });
        }

        if (!$.fn.clientHeight)
        {
            $.fn.extend({
                clientHeight: function ()
                {
                    return this[0].clientHeight;
                }
            });
        }

        if (!$.fn.clientWidth)
        {
            $.fn.extend({
                clientWidth: function ()
                {
                    return this[0].clientWidth;
                }
            });
        }

        //This functions checks if there are missing events for accessibility on the element and its descendents.
        //If there are missing events, It adds them to the element and they trigger the accessibility equivalent event.
        if (!$.fn.completeMissingAccessibilityEvents) {
            $.fn.extend({
                completeMissingAccessibilityEvents: function () {
                    var objElement = this;
                    if (isAccessibilityMode == false) {
                        return;
                    }
                    //Draw events handlers wherever they don't exist
                    $(arrAccessibilityEvents).each(function () {
                        var objAccessibilityEvent = this;
                        completeMissingAccessibilityEventsToElement(objElement, objAccessibilityEvent.sourceEvent, objAccessibilityEvent.destinationEvent);
                        $(objElement).find('[on' + objAccessibilityEvent.sourceEvent + ']').not('[' + objAccessibilityEvent.destinationEvent + ']').each(function () {
                            completeMissingAccessibilityEventsToElement(this, objAccessibilityEvent.sourceEvent, objAccessibilityEvent.destinationEvent);
                        });
                    });
                }
            });
        }

        //Thus function is used in the completeMissingAccessibilityEvents function, and it does the actual setting of the events on the element (if the event doesn't already exists)
        function completeMissingAccessibilityEventsToElement(objElement, sourceEvent, destinationEvent)
        { 
            if ($(objElement).is('[on' + sourceEvent + ']:not([' + destinationEvent + '])')) {
                var action = "$(this).trigger('" + sourceEvent + "');";
                if (destinationEvent == "onkeydown" || destinationEvent == "onkeyup") {
                    action = "if(event.keyCode == 13 || event.charCode == 13) {" + action + "}";
                }
                $(objElement).attr(destinationEvent, action);
            }
        }

        var oldreplaceWith = $.fn.replaceWith;
        $.fn.replaceWith = function () {
            var ret = oldreplaceWith.apply(this, arguments);
            $(arguments[0]).completeMissingAccessibilityEvents();
            return ret;
        }
        var oldappend = $.fn.append;
        $.fn.append = function () {
            var ret = oldappend.apply(this, arguments);
            ret.completeMissingAccessibilityEvents();
            return ret;
        }
        
        jQuery.sub = function() {
            function jQuerySub( selector, context ) {
                return new jQuerySub.fn.init( selector, context );
            }
            jQuery.extend( true, jQuerySub, this );
            jQuerySub.superclass = this;
            jQuerySub.fn = jQuerySub.prototype = this();
            jQuerySub.fn.constructor = jQuerySub;
            jQuerySub.sub = this.sub;
            jQuerySub.fn.init = function init( selector, context ) {
                if ( context && context instanceof jQuery && !(context instanceof jQuerySub) ) {
                    context = jQuerySub( context );
                }

                return jQuery.fn.init.call( this, selector, context, rootjQuerySub );
            };
            jQuerySub.fn.init.prototype = jQuerySub.fn;
            var rootjQuerySub = jQuerySub(document);
            
            return jQuerySub;
        };        
    }
})(jQuery);