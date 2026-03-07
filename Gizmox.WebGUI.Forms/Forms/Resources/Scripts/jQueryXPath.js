// Create a sub jQuery for xpath
var xpath$ = jQuery.sub();

(function($){

    /// <method name="XPathResultTypes">
    /// <summary>
    /// Provides constants for xpath result types
    /// </summary>
    var ANY_TYPE                        = 0;
    var NUMBER_TYPE                     = 1;
    var STRING_TYPE                     = 2;
    var BOOLEAN_TYPE                    = 3;
    var UNORDERED_NODE_ITERATOR_TYPE    = 4;
    var ORDERED_NODE_ITERATOR_TYPE      = 5;
    var UNORDERED_NODE_SNAPSHOT_TYPE    = 6;
    var ORDERED_NODE_SNAPSHOT_TYPE      = 7;
    var ANY_UNORDERED_NODE_TYPE         = 8;    
    var FIRST_ORDERED_NODE_TYPE         = 9;
    /// </method>
    
    // The debugging flag
    var mblnXPathDebug = false;
    
    // The debugging data
    var mobjXPathDebug = {};
    
    xpath$.fn.extend({
		
		/// <method name="each">
        /// <summary>
        /// Provides support enumerating a list with a query item
        /// </summary>
		xeach : function() {
			
			// The callback method
			var fncEachCallback;
			
			// the items to iterate
			var arrItems;
			
			// Determine arguments
			switch(arguments.length) {
			
			    // Case single argument
			    case 1:
			        fncEachCallback = arguments[0];
			        arrItems = this;
			        break;
			      			      
			    // Case two argument
			    case 2:
			        fncEachCallback = arguments[1];
			        
			        // Run the xpath expression 
			        arrItems = this.xpath(arguments[0]);
			        break;
			        
			    default:
			        return this;
			        break;
			}
			
			// Loop all items
		    for(var i=0;i<arrItems.length; i++) {
		    
		        // Execute callback
		        fncEachCallback.call(xpath$(arrItems[i]), i);
		    };
		    
			
			// Return this for chainability
			return this;
		},
		/// </method>

		
		/// <method name="filter">
        /// <summary>
        /// Filters the context array in according to fncEachCallback call back.
        /// </summary>
		filter : function(fncEachCallback, objArgs) {
			
			// The filter results
			var arrResults = [];
			
			// The item index
			var intIndex = 0;
			
			// Loop all items
		    for(var i=0;i<this.length; i++) {
		    
		        // The current item
		        var objItem = this[i];
		        
		        // Execute callback
		        if(fncEachCallback.call(xpath$(objItem), i, objArgs)) {
		        
		            // Add current item
		            arrResults[intIndex++] = objItem;
		        }
		    };
			
			// Return this for chainability
			return xpath$(arrResults);
		},
		/// </method>
		
		/// <method name="xattr">
        /// <summary>
	    /// Provides support for testing if attribute exists
        /// </summary>
		hasAttr : function(strName) {
		
		    // Get the inner first item
	        var objItem = this[0];
	        
	        // If there is a valid item
	        if(objItem) {
	        
	            // If is not ie browser
	            if(!mcntIsIE) {
	            
	                // Get the has attribute value
    	            return objItem.hasAttribute(strName);
    	            
    	        } else {
    	        
    	            return objItem.getAttribute(strName) != null;
    	        }
    	    
    	    } else {
    	        
    	        return false;
    	    }    	                
		},
		/// </method>
		
		/// <method name="xname">
        /// <summary>
	    /// Provides support for getting the node name
        /// </summary>
		xname : function() {
		    var objItem = this[0];
		    return objItem ? objItem.nodeName : "";
		},
		/// </method>
		
		/// <method name="attr">
        /// <summary>
	    /// Extends jQuery with a fast attr function
        /// </summary>
	    attr : function(){
	
	        var objValue;	    
            
	        // Get the inner first item
	        var objItem = this[0];
    	    
    	    // Switch between attribute behavior
    	    switch(arguments.length) {
    	    
    	        // getAttribute synax
    	        case 1:
    	            // If there is a valid item
    	            if(objItem) {
    	            
    	                // Get the attribute value
    	                objValue = objItem.getAttribute(arguments[0]);
    	                
    	                // Set the default return value
    	                if(!objValue) {
    	                    objValue = "";
    	                }
    	                
    	            } else {
    	            
    	                // Set the default return value
    	                objValue = "";
    	            } 	        
    	            break;
    	            
    	            
    	        case 2:
    	            // If there is a valid item
    	            if(objItem) {
    	                // Set attribute
    	                objItem.setAttribute(arguments[0], arguments[1]);
    	            }       	         
    	            
    	            // Set this for chainability   
    	            objValue = this; 	        
    	            break;  
    	        case 3:
    	            
    	            // Get the attribute action
    	            var strAction = arguments[1];
    	            
    	            // Get the action value
    	            var objActionValue = arguments[2];
    	            
    	            // If there is a valid item
    	            if(objItem) {
    	            
    	                // Get the attribute value
    	                var objAttrValue = objItem.getAttribute(arguments[0]);
    	                
    	                // Choose action
    	                switch(strAction) {
    	                    case "==":
    	                        objValue = (objAttrValue == _getXPathPrimitiveValue(objActionValue));
    	                        break;
    	                    case "!=":
    	                        objValue = (objAttrValue != _getXPathPrimitiveValue(objActionValue));
    	                        break;
    	                    case ">=":
    	                        objValue = (_getXPathNumber(objAttrValue) >= _getXPathNumber(objActionValue));
    	                        break;
	                        case "<=":
	                            objValue = (_getXPathNumber(objAttrValue) <= _getXPathNumber(objActionValue));
	                            break;
	                        case "<":
	                            objValue = (_getXPathNumber(objAttrValue) < _getXPathNumber(objActionValue));
	                            break;
	                        case ">":
	                            objValue = (_getXPathNumber(objAttrValue) > _getXPathNumber(objActionValue));
	                            break;
	                        case "contains":
    	                        objValue = $.xpath("contains", objAttrValue, objActionValue);
    	                        break;
    	                    case "startsWith":
    	                        objValue = $.xpath("startsWith", objAttrValue, objActionValue);
    	                        break;
    	                    case "endsWith":
    	                        objValue = $.xpath("endsWith", objAttrValue, objActionValue);
    	                        break;
    	                    case "has":
    	                        if(objActionValue=="value") {
    	                            objValue = true;
    	                            objValue &= typeof objAttrValue != "undefinied";
    	                            objValue &= objAttrValue != null;
    	                            objValue &= objAttrValue != "";
    	                        }
    	                    
    	                    case "as":
    	                        
    	                        switch(objActionValue) {
    	                            case "bool":
    	                                objValue = $.xpath("bool", objAttrValue);
    	                                break;
    	                            case "number":
    	                                objValue = _getXPathNumber(objAttrValue);
    	                                break;
    	                        }
    	                        
    	                        break;
    	                }
    	            
    	            } else {
    	                
    	            }  	        
    	        
    	    }
    	    

	        return objValue;
	    
	    },
	    /// </method>
	
		/// <method name="attrs">
        /// <summary>
        /// Provides support for getting attributes for more then one node (used for aggregative functions)
        /// </summary>
		attrs : function(strName) {

            // The list of attributes
            var arrAttrs = [];
            var intArrts = 0;
            
            // Loop all the jquery items
            this.xeach(function(){
            
                // Add the current attribute
                arrAttrs[intArrts++] = this.attr(strName);
            });
		
		    // Return a jQuery list
		    return xpath$(arrAttrs);
		},
		/// </method>
		
		
		/// <method name="number">
        /// <summary>
        /// Provides support for xpath number function
        /// </summary>
		xnumber : function(objValue) {

            return _getXPathScalarValue(this, "number", objValue);            
		
		},
		/// </method>
		
		/// <method name="sum">
        /// <summary>
        /// Provides support for xpath sum function
        /// </summary>
		xsum : function(objValue) {
		    return _getXPathScalarValue(this, "sum", objValue);
		},
		/// </method>
		
		/// <method name="count">
        /// <summary>
        /// Provides support for xpath count function
        /// </summary>
		xcount : function(objValue) {
			return _getXPathScalarValue(this, "count", objValue);
		},
		/// </method>		
		
		/// <method name="floor">
        /// <summary>
        /// Provides support for xpath floor function
        /// </summary>
		xfloor : function(objValue) {
			return _getXPathScalarValue(this, "floor", objValue);
		},
		/// </method>
		
		/// <method name="round">
        /// <summary>
        /// Provides support for xpath round function
        /// </summary>
		xround : function(objValue) {
			return _getXPathScalarValue(this, "round", objValue);
		},
		/// </method>		

		/// <method name="ceiling">
        /// <summary>
        /// Provides support for xpath ceiling function
        /// </summary>
		xceiling : function(objValue) {
			return _getXPathScalarValue(this, "ceiling", objValue);
		},
		
		/// <method name="eval">
        /// <summary>
        /// 
        /// </summary>
		xeval : function(strXPath)
		{	
			return _getXPathResults(this, strXPath, ANY_TYPE, true);
		},
			
		/// </method>
		
		/// <method name="ceiling">
        /// <summary>
        /// Provides support for xpath ceiling function
        /// </summary>
		xposition : function(intIndex) {
			return xpath$(this[intIndex - 1]);
		},
		/// </method>
		
		/// <method name="hash">
        /// <summary>
        /// Provides support for xpath hashing function
        /// </summary>
		attrhash : function(strAttribute) {
			
			// Create an hash object
			var objHash = {};
			
			// Loop all the jquery items
            this.xeach(function(){
            
                // Get the hash key
                var strHashKey = this.attr(strAttribute);
                
                // If there is a valid hash key
                if(strHashKey){
                
                    // Store the item in the current hash
                    objHash[strHashKey] = this;
                }
            });
			
			// Return the generated hash
			return objHash;
			
		},
		/// </method>
		
		/// <method name="xpath">
        /// <summary>
        /// Provides support for xpath function
        /// </summary>
		xpath : function() {
		    
		    // If there are arguments
		    if(arguments.length > 0) {
		    
		    
		        // Execute the xpath expression
	            return _getXPathResults(this.get(), arguments[0], arguments[1] , arguments[2] ? true : false);
	            
	        } else {
	        
	            return this;
	        
	        }
		}
		/// </method>
		
		
	});
	/// </object>
	

	
	
	/// <method name="xpath">
    /// <summary>
	///
    /// </summary>
	$.fn.xpath = function(){
	
	    // If there are arguments
        if(arguments.length> 0) {
        
		    // Execute the xpath expression
	        return _getXPathResults(this.get(), arguments[0], ORDERED_NODE_ITERATOR_TYPE);
	        
	    } else {
	    
	        return xpath$(this);
	    }		
	}; 
	/// </method>

    /// <object name="XPathStaticMethods">
    /// <summary>
    /// Provides static xpath methods for xpath support
    /// </summary>
    function XPathStaticMethods() {
    
    }
    
    /// <summary>
    /// XPathStaticMethods methods
    /// </summary>
    XPathStaticMethods.prototype = {
		
    
		/// <method name="concat">
        /// <summary>
        /// Provides support for xpath concat function
        /// </summary>
		concat : function() {

            // The concating buffer
            var arrBuffer = [];
            var intBuffer = 0;
            
            // Loop all arguments
            for(var i=0; i< arguments.length; i++)
            {
                // Add the argument primative value
                arrBuffer[intBuffer++] = _getXPathString(arguments[i]);
            }
            
            // Return a joined string
		    return arrBuffer.join('');
		},
		/// </method>				
		
		/// <method name="number">
        /// <summary>
        /// Provides support for xpath number function
        /// </summary>
		number : function(objValue) {
		
		    return _getXPathNumber(objValue);
		},
		/// </method>
		
		/// <method name="definied">
        /// <summary>
        /// Provides support for checking if a value is definied
        /// </summary>
		definied : function(objValue){
		    return !(typeof objValue == "undefined");
		},
		/// </method>
		
		/// <method name="string">
        /// <summary>
        /// Provides support for xpath string function
        /// </summary>
		string : function(objValue) {
		
		    return _getXPathString(objValue);
		},
		/// </method>
		
		/// <method name="contains">
        /// <summary>
        /// Provides support for xpath contais function
        /// </summary>
		contains : function(objString, objValue) {
            return _getXPathString(objString).indexOf(_getXPathString(objValue)) > -1;
		},
		/// </method>
		
		/// <method name="startsWith">
        /// <summary>
        /// Provides support for xpath starts-with function
        /// </summary>
		startsWith : function(objString, objValue) {
            return _getXPathString(objString).indexOf(_getXPathString(objValue)) == 0;
		},
		/// </method>		
		
		stringLength : function(objValue) {
		    return _getXPathString(objValue).length;
		},
		
		/// <method name="substringAfter">
        /// <summary>
        /// Provides support for xpath substringAfter function
        /// </summary>
		substringAfter : function(objString, objValue) {
            // Get primitive string value.
            objString = _getXPathString(objString);
            
            // Get primitive string value.
            objValue = _getXPathString(objValue);

            // Find first occurance of value whithin recieved string.
            var intValueIndex = objString.indexOf(objValue);
            if(intValueIndex>=0)
            {
                // Return remain left over.
                return objString.substr(intValueIndex+1);
            }
		},
        /// </method>

        /// <method name="substringBefore">
        /// <summary>
        /// Provides support for xpath substringBefore function
        /// </summary>
		substringBefore: function (objString, objValue)
		{
		    // Get primitive string value.
		    objString = _getXPathString(objString);

		    // Get primitive string value.
		    objValue = _getXPathString(objValue);

		    // Find first occurance of value whithin recieved string.
		    var intValueIndex = objString.indexOf(objValue);
		    if (intValueIndex >= 0)
		    {
		        // Return remain left over.
		        return objString.substr(0, intValueIndex);
		    }
		},
        /// </method>
		
		/// <method name="endWith">
        /// <summary>
        /// Provides support for xpath end-with  function
        /// </summary>
		endWith : function(objString, objValue) {
		    var strArgs = [_getXPathString(objString), _getXPathString(objValue)];
            return strArgs[0].indexOf(strArgs[1]) == strArgs[0].length - strArgs[1].length;
		},
		/// </method>
		
		
		/// <method name="count">
        /// <summary>
        /// Provides support for xpath count function
        /// </summary>
		count : function(objValue) {
		
		    // If there is a valid value
            if(objValue)
            {              
                // If is a jQuery object
                if(objValue.jquery)
                {  
                    // Return the number items
                    return objValue.size();                
                }
                // if has a length property
                else if(objValue.length)
                {
                    return objValue.length; 
                }
            }
            return 0;            
		},
		/// </method>
		
		/// <method name="name">
        /// <summary>
        /// Provides support for xpath name function
        /// </summary>
		name : function(objValue) {
  
            // If is a jQuery object
            if(objValue && objValue.jquery)
            {           
                objValue = objValue.get(0);
            }
             
            // If there is a valid value
            if(objValue)
            {
                // Try to get node name from value
                var strName = objValue.nodeName;
                
                // If there is a valid name
                if(strName)
                {
                    return strName;
                }
            }
                
            return "";            
		},
		/// </method>
		
		/// <method name="decodeText">
        /// <summary>
        /// Decode the xpath text to text
        /// </summary>
		decodeText : function(objValue) {
            return _getXPathDecodedText(_getXPathString(objValue), false);
		},
		/// </method>
		
		/// <method name="decodeTextAsHtml">
        /// <summary>
        /// Decode the xpath text to html
        /// </summary>
		decodeTextAsHtml : function(objValue) {            
            return _getXPathDecodedText(_getXPathString(objValue), true);
		},
		/// </method>
		
		/// <method name="xpath">
        /// <summary>
        /// Provides static xpath methods for xpath support
        /// </summary>
		xpath : function(objContext, strXPath) {
			
			// If there is a valid context
			if(objContext!=null)
	        {
	            // If is a jquery object
	            if(objContext.jquery)
	            {
	                // Run xpath on jQuery object
	                return objContext.xpath(strXPath);
	            }
	            else
	            {
	                // Create a jQuery object and run it
	                return $xpath(objContext).xpath(strXPath);
	            }
	        }
	        
	        // Return an empty jQuery object
	        return xpath$([]);
		},
		/// </method>
		
		/// <method name="bool">
        /// <summary>
        /// Provides a boolean value from a given value
        /// </summary>
		bool : function(objValue){
		
		    // If there a value
			if(objValue)
	        {
	            // If is a jquery object
	            if(objValue.jquery)
	            {
	                // Get the size of the jQuery object
	                var intSize = objValue.size();
	                
	                // If there is one value
	                if(intSize == 1)
	                {
	                    // Check the value
	                    return _getXPathPrimitiveValue(objValue.get(0)) ? true : false;
	                }
	                else if(intSize > 1)
	                {
	                    // There are nodes
	                    return true;
	                }
	            }
	            else
	            {
	                // Value is true
	                return _getXPathPrimitiveValue(objValue) ? true : false;
	            }
	        }
	        
	        return false;
		},
		/// </method>
		
		/// <method name="compile">
		/// <summary>
		/// Compile string expression to create the expression object
		/// </summary>
		/// <example>
		///		objXMLResponseRoot.xpath($.xpath("compile","/WG:R/WG:F"))
		/// </example>
		compile : function(objDocument, strXPath)
		{
		    if(strXPath && strXPath!="" && objDocument)
		    {
			    return _getXPathExpression(objDocument, strXPath, _getXPathNSResolver);
			}
			return null;
		},
		/// </method>
		
		/// <method name="floor">
        /// <summary>
        /// 
        /// </summary>
		floor : function(objValue) {
			return Math.floor(_getXPathNumber(objValue));
		},		
		
		/// <method name="round">
        /// <summary>
        /// 
        /// </summary>
		round: function(objValue) {
			return Math.round(_getXPathNumber(objValue));
		},
		
		/// <method name="round">
        /// <summary>
        /// 
        /// </summary>
		ceiling: function(objValue) {
			return Math.ceil(_getXPathNumber(objValue));
		},
		
		/// <method name="sum">
        /// <summary>
        /// Provides support for xpath sum function
        /// </summary>
		sum : function(objValuesSet) {

            var objResult = 0;
            
            $.each(objValuesSet, function(){
                objResult += _getXPathNumber(this);
            });
		    
		    return objResult;
		},
		/// </method>		

		/// <method name="position">
        /// <summary>
        /// Provides support for xpath position() function
        /// </summary>
		position : function(objValue) {
		     
		    // The start position
		    var intPosition = 0;
		    
		    // If is a jquery object
		    if(objValue && objValue.jquery)
		    {
		        // Get element
		        objValue = objValue[0];
		    }
		    
		    // If there is a valid 
		    if(objValue!=null)
		    {
		        // Count previous siblings and self
		        do
		        {
		            intPosition++;		            		            
		        }
		        while(objValue = objValue.previousSibling);
		    }
		    
		    // Return the position
			return intPosition;
		},
		/// </method>	
		
		/// <method name="debug">
        /// <summary>
        /// Provides support for debugging xpath performance
        /// </summary>
		debug : function(objAction) {
		
		    var arrBuffer;
		    
		    var blnClear = false;
		    
		    if(objAction == "on") {
		        mblnXPathDebug = true;
		        return;
		    }		
		    else if(objAction == "off"){
		        mblnXPathDebug = false;
		        return;
		    }  
		    else if(objAction == "clear"){
		        blnClear = true;
		        return;
		    }  
		    else if(objAction){
		        arrBuffer = objAction;
		    }   

		    
		    // Calculates the avrage value
            function avg(intCount, intTime) {
                return intCount == 0 || intTime == 0 ? 0 : (intTime / intCount).toFixed(2);
            }
		    		    		                    
            var arrQueries = [];
            
            // Aggregation methods
            var intTotalQueryTime = 0;
            
		    // Loop all xpath stats
		    for(var strXPath in mobjXPathDebug) {
		        var objData = mobjXPathDebug[strXPath];		    
		        if(!blnClear) {                    
                    arrQueries.push([strXPath,objData[0],objData[1],avg(objData[0], objData[1])]);
                }
                else {
                    objData[0] = 0;
                    objData[1] = 0;
                }
		    }
		    
		    if(blnClear || !arrBuffer) {
		        return;
		    }
		     // Sort the queries by performance 
            arrQueries.sort(function(a,b){
                return b[2] - a[2];
            });
		    
		    
		    
		    arrBuffer.push("<h2>XPath Query Breakdown</h2>");
            arrBuffer.push("<table border=\"1\" cellspacing=\"0\"><tr>");
            arrBuffer.push("<td>XPath</td>");
            arrBuffer.push("<td>Quireis</td>");
            arrBuffer.push("<td>Total Query Time</td>");
            arrBuffer.push("<td>Avarage Query Time</td>");
            arrBuffer.push("</tr>");
            
		    // Loop all templates
            for(var intIndex=0; intIndex < arrQueries.length; intIndex++) {
            
		        arrBuffer.push("<tr>");
                arrBuffer.push("<td> "+arrQueries[intIndex][0]+" </td>");
                arrBuffer.push("<td> "+arrQueries[intIndex][1]+" </td>");
                arrBuffer.push("<td> "+arrQueries[intIndex][2]+" ms</td>");
                arrBuffer.push("<td> "+arrQueries[intIndex][3]+" ms</td>");
                arrBuffer.push("</tr>");
                
                // Add to total query time
                intTotalQueryTime+=arrQueries[intIndex][2];
            }    
            
            arrBuffer.push("</table>");           
		    
		    return intTotalQueryTime;
		    
		}
		/// </method>		
	};
	/// </object>
	
	// Create the static methods instance
	var mobjXPathStaticMethods = new XPathStaticMethods();
	
	/// <method name="xpath">
    /// <summary>
    /// Provides static xpath methods for xpath support
    /// </summary>
    $.xpath = function(strAction){
	    
	    // Try to get static method
	    var objXPathStaticMethod = mobjXPathStaticMethods[strAction];
	    
	    // If there is a static method defined
	    if (objXPathStaticMethod) {
	    
            // If has only two arguments
	        if(arguments.length==2) {
	        
                // Call static method
                return objXPathStaticMethod(arguments[1]); 
            }              
            else {
            
                // Return the method value
                return objXPathStaticMethod.apply(this, Array.prototype.slice.call(arguments, 1));
            }
        }
        else
        {
            throw "Could not resolve xpath operation named '" + strAction + "'.";
        }
	};
	/// </method>
	
	/// <method name="_debugXPath">
    /// <summary>
    /// Provides support for xpath debugging
    /// </summary>
	function _debugXPath(strXPath, objOldTime) {
	
	    // Get execution time
	    var intTime = ((new Date()) - objOldTime);
	    
	    // Try to get existing tracker
	    var arrTracker = mobjXPathDebug[strXPath];
	    
	    // Create tracker if not created before
	    if(!arrTracker) {
	        mobjXPathDebug[strXPath] = arrTracker = [0,0];
	    }
	    
	    // Increment occurences tracker
	    arrTracker[0]++;
	    
	    // Increment time tracker
	    arrTracker[1]+=intTime;
	}
	/// </method>
	
	/// <method name="_debugXPathTime">
    /// <summary>
    /// Provides support for xpath debugging
    /// </summary>
	function _debugXPathTime() {
	    return new Date();
	}
	/// </method>
	
	
	/// <method name="number">
    /// <summary>
    /// Provides support for xpath string function
    /// </summary>
	function _getXPathString(objValue) {
	
	    // Get primative value from node
	    objValue = _getXPathPrimitiveValue(objValue);
	    
	    // If is an undefined value
	    if(typeof objValue == "undefined")
	    {
	        objValue = "";
	    }
	    // If is a null value
	    else if (objValue==null)
	    {
	        objValue = "";
	    }
	    
	    return String(objValue);
	    
	}
	/// </method>
	
	/// <method name="number">
    /// <summary>
    /// Provides support for xpath number function
    /// </summary>
	function _getXPathNumber(objValue) {
	
	    // Get primative value from node
	    objValue = _getXPathPrimitiveValue(objValue);
        
        // If there is a valid argument
        var intValue = parseFloat(objValue);
        
        // If there is a valid number
        if(!isNaN(intValue))
        {
            // Return the number
            return intValue;
        }
        else
        {
            // Evaluate boolean value
            if($.xpath("bool", objValue)) {
                // Return 1 as a number representing true
                return 1;
            }
        }
	    return 0;
	}	
	/// </method>	
	
	/// <method name="_getXPathNodeValueOfSelf">
    /// <summary>
    /// Gets an xpath node value
    /// </summary>
	function _getXPathNodeValueOfSelf(objNode)
	{
		// If there is a valid node
	    if(objNode)
	    {
	        // If node can return value
			switch(objNode.nodeType)
			{
				case 2: // attribute
			    case 3: // text node
					return objNode.nodeValue;
			}
	    }
	    
	    // Return the actual node
	    return objNode;
	}
	/// </method>	
	
	
	/// <method name="_getXPathNode">
    /// <summary>
    /// Gets an xpath node
    /// </summary>
	function _getXPathNode(objNode, objContext)
	{
	    // If there is a valid node
	    if(objNode && objNode.nodeType==2)
	    {
	        return new _XPathAttributeNode(objNode, objContext);
	    }
	    return objNode;
	}
	/// </method>
	
	
	function _getXPathContext(objNode)
	{
	    // If there is a valid actual node
	    if(objNode && objNode.actualNode)
	    {
	        return objNode.actualNode;
	    }
	    return objNode;
	}
	
	/// <method name="_isPrimativeValue">
    /// <summary>
    /// Gets a flag indicating if value is primative
    /// </summary>
	function _isPrimativeValue(objValue)
	{
	    return typeof objValue == "string" || typeof objValue == "number" || typeof objValue == "boolean";
	}
	/// </method>	
	
	/// <method name="_getXPathPrimitiveValue">
    /// <summary>
    /// Gets a primative value by extracting from jQuery or node
    /// </summary>
	function _getXPathPrimitiveValue(objValue)
	{
	    // If there is a valid value
		if(objValue)
		{
		    // If is a primative value return it
			if(_isPrimativeValue(objValue))
			{
				return objValue;
			}
		    // If is a jquery object
			else if(objValue.jquery)
			{
			    // If the jQuery object has size
				if(objValue.size() > 0)
				{
				    // Get the first value from the jQuery object
					objValue = objValue.get(0);
					
					// If there is a valid value
					if(objValue)
					{
					    // If value is primative
						if(_isPrimativeValue(objValue))
						{
						    // Return the primative value
							return objValue;
						}
						else						
						{	
						    // Gets the node value
						    return _getXPathNodeValueOfSelf(objValue);
						}
					}
				}
				else
				{
				    // If the jquery object is empty
					return null;
				}
			}
			else
			{
			    // If is not a jquery object
				return _getXPathNodeValueOfSelf(objValue);
			}
		}
		
		// Return self if not any of the above
		return objValue;
	}
	/// </method>
	
	/// <method name="_getXPathExpression">
    /// <summary>
    /// Prepare xpath expression to expression object.
    /// </summary>
	function _getXPathExpression(objDocument, objXPathExpression, _getXPathNSResolver)
	{
		var objResult = objXPathExpression;
		
		if(mcntIsIE)
		{
			objResult = objXPathExpression;
		}
		else
		{
			objResult = objDocument.createExpression(objXPathExpression, _getXPathNSResolver);
		}
		return objResult;
	}
	/// </method>
	
	/// <method name="_getXPathResults_ie">
	/// <summary>
	/// Executes the xpath expression and returns an array of results
	/// </summary>
	function _getXPathResults(arrContexts, objXPathExpression, intResultType, blnEvalute)
	{
	    // If is in debug mode
        if(mblnXPathDebug) {
            objBeforeTime = _debugXPathTime();
        }
        
        // Protect the result to make sure it is valid
        intResultType = intResultType==null || isNaN(intResultType) ? ORDERED_NODE_ITERATOR_TYPE : intResultType;
        
        // Call static method
        var objValue;
        
        // If is ie browser
		if(mcntIsIE)
		{
		    // Get ie xpath results
			objValue = _getXPathResults_ie(arrContexts, objXPathExpression, intResultType, blnEvalute);
		}
        else
        {
            // Get non ie xpath results
		    objValue = _getXPathResults_nonie(arrContexts, objXPathExpression, intResultType, blnEvalute);
		}
		
		// If is in debug mode
        if(mblnXPathDebug) {
        
            // Record the method performance
            _debugXPath(objXPathExpression, objBeforeTime);
        }
	          
		
		return objValue;
	}

	/// <method name="_getXPathResults">
    /// <summary>
    /// NON-IE : Executes the xpath expression and returns an array of results
    /// </summary>
	function _getXPathResults_nonie(arrContexts, objXPathExpression, intResultType, blnEvalute)
	{
	    // The xpath results array
		var arrResults = [];
		var intResult = 0;
				
		
		// If there is a valid expression
		if(objXPathExpression)
		{		    		
    	
		    // Loop all targets
		    for(var intContextIndex=0; intContextIndex< arrContexts.length; intContextIndex++)
		    {

                // Run the expression on the current context
			    var objResults;
			    
			    // The current context element
			    var objContext = _getXPathContext(arrContexts[intContextIndex]);
			    
                // If is an string expression
		        if( typeof objXPathExpression == "string")
		        {
		            // Get the context document
		            var objDocument = null;
		            
		            if(!window.jsxpath)
		            {
		                objDocument = objContext.ownerDocument;
		            }
		            else
		            {
		                objDocument = document;
		            }
		            
		            // If there is a valid document
		            if(objDocument)
		            {
		                // Get results from the current document
		                objResults = objDocument.evaluate(objXPathExpression, objContext, _getXPathNSResolver, intResultType, null);
		            }
		        }
		        else 
		        {
		            // Execute xpath expression
		            objResults = objXPathExpression.evaluate(objContext, intResultType, null);
		        }
    			                
			    // Choose results type
			    switch(objResults.resultType)
			    {
				    case NUMBER_TYPE:
					    arrResults.push(objResults.numberValue);
					    break;
				    case STRING_TYPE:
					    arrResults.push(objResults.stringValue);
					    break;
				    case BOOLEAN_TYPE:
					    arrResults.push(objResults.booleanValue);
					    break;
			        case FIRST_ORDERED_NODE_TYPE:
			        
			        	if(blnEvalute)
						{
							// Extract value if asked to evaluate node
							arrResults[intResult++] = _getXPathNodeValueOfSelf(objResults.singleNodeValue);
						}
						else
						{
			        	    arrResults[intResult++] = _getXPathNode(objResults.singleNodeValue, objContext);
						}

				    default:
					    // The current node
					    var objNode = null;
                        
					    // Loop all current nodes
					    while(objNode = objResults.iterateNext())
					    {
						    // Add the node to the results
			        		if(blnEvalute)
							{
								// Extract value if asked to evaluate node
								arrResults[intResult++] = _getXPathNodeValueOfSelf(objNode);
							}
							else
							{
			        		    arrResults[intResult++] = _getXPathNode(objNode, objContext);
							}
					    }	
					    break;	
			    }
    			
			    // If found a node and in single node mode
			    if(intResultType == FIRST_ORDERED_NODE_TYPE && arrResults.length > 0)
			    {
				    break;
			    }
		    }	
		}

		if(blnEvalute)
		{
			// Return values instead of jquery object
			if(arrResults.length == 1)
			{
			    if(_isPrimativeValue(arrResults[0]))
			    {
				    return arrResults[0];
				}
				else
				{
				    xpath$(arrResults[0]);
				}
			}
			else
			{
				return xpath$(arrResults);
			}
		}

		// Return the results array
		return xpath$(arrResults);	
	}
	/// </method>
	
	/// <method name="_getXPathResults_ie">
    /// <summary>
    /// IE : Executes the xpath expression and returns an array of results
    /// </summary>
	function _getXPathResults_ie(arrContexts, objXPathExpression, intResultType, blnEvalute)
	{
		// The xpath results array
		var arrResults = [];
		var intResult = 0;
		
		// If there is a valid expression
		if(objXPathExpression)
		{
			// If is a single node selection
            if(intResultType == FIRST_ORDERED_NODE_TYPE)
            {
                // Loop all targets
			    for(var intContextIndex=0; intContextIndex< arrContexts.length; intContextIndex++)
			    {
			        // Run the expression on the current context
				    var objResult = _getXPathContext(arrContexts[intContextIndex]).selecSingletNode(objXPathExpression);
				    if( objResults)
				    {
				        // If is in evaluate mode
				        if(blnEvalute)
					    {
					        // Evaluate the node and get value
						    arrResults[intResult++] = _getXPathNodeValueOfSelf(objResult);
					    }
					    else
					    {
				            arrResults[intResult++] = _getXPathNode(objResult, arrContexts[intContextIndex]);
					    }
				        break;
				    }
			    }
            }
            else
            {
			    // Loop all targets
			    for(var intContextIndex=0; intContextIndex< arrContexts.length; intContextIndex++)
			    {
				    // Run the expression on the current context
				    var objResults = _getXPathContext(arrContexts[intContextIndex]).selectNodes(objXPathExpression);
				    
				    // If there is a valid reslut set
				    if( objResults.length > 0)
				    {
				        // Loop all results with in result
					    for(var i=0; i< objResults.length; i++)
					    {
					        // Node evaluation is needed
						    if(blnEvalute)
						    {
						        // Evaluate the current 
							    arrResults[intResult++] = _getXPathNodeValueOfSelf(objResults[i]);
						    }
						    else
						    {
						        // Add the result
						        arrResults[intResult++] = _getXPathNode(objResults[i], arrContexts[intContextIndex]);
						    }
					    }
				    }    			   	    
			    }
			}
		}
		
		if(blnEvalute)
		{
			// Return values instead of jquery object
			if(arrResults.length == 1)
			{
			    if(_isPrimativeValue(arrResults[0]))
			    {
				    return arrResults[0];
				}
				else
				{
				    xpath$(arrResults[0]);
				}
			}
			else
			{
				return xpath$(arrResults);
			}
		}	

		return 	xpath$(arrResults);
	}
	/// </method>
	
	/// <method name="_getXPathNSResolver">
    /// <summary>
    /// Provides support for resolving xpath namespaces
    /// </summary>
	function _getXPathNSResolver(strPrefix) 
	{
		if(strPrefix == "WG") 
		{
			return 'http://www.gizmox.com/webgui';
		}
		else if(strPrefix == "WC") 
		{
			return 'wgcontrols';
		}
        
		return null;
	}
	/// </method>
	

    /// <method name="_getXPathScalarValue">
    /// <summary>
    /// Returns a scallar from the given xpath and its function
    /// </summary>
	function _getXPathScalarValue(objContext, strFunction, strXPath)
	{
		var objResult;
		
		// If is ie
		if(mcntIsIE)
		{
			// IE unable to run scalar expressions
			// take xpath result and post-calculate the scalar expression with JS
			objResult = $.xpath(strFunction, objContext.xpath(strXPath, ANY_TYPE, false));
		}
		else
		{
			// Run number scalar expression on context target
			objResult = objContext.xpath(strFunction + "(" + strXPath + ")", ANY_TYPE, false);
		}
		
		objResult = _getXPathPrimitiveValue(objResult);

		return objResult;		
	}
	/// </method>

	
	/// <method name="_getXPathDecodedText">
    /// <summary>
    /// Decode an encoded text.
    /// </summary>
    /// <remarks>
    /// The methods decodes a text value that was encoded to prevent data loss when using
    /// attributes. This allows to use attributes for text values without loosing information
    /// due to xml attribute normalization.
    /// </remarks>
    /// <param name="strText"></param>
	function _getXPathDecodedText(strText, blnDecodeAsHtml) {
	
        if(strText)
        {
            if(blnDecodeAsHtml)
            {
                return strText.replace(/[<>&]|(\\\\)|(\\s)|(\\t)|(\\n)|(\\r)|(\\b)|(")/gm,_getXPathDecodedHtmlMatch);
            }
            else
            {
                return strText.replace(/(\\\\)|(\\s)|(\\t)|(\\n)|(\\r)|(\\b)|(<)|(>)|(&)|(")/gm, _getXPathDecodedTextMatch);
            }
        }
        else
        {
            return strText;
        }
    }

    /// <method name="_getXPathDecodedCommon"  access="private">
    /// <summary>
    /// Decodes a specific match
    /// </summary>
    /// <param name="strMatch">The current match to get its replacing value.</param>
    function _getXPathDecodedCommon(strMatch)
    {

        switch(strMatch)
        {
            case "\\r": return ""; 
            case "<": return "&lt;"; 
            case ">": return "&gt;"; 
            case "\\\\": return "\\"; 
            case "\"": return "&quot;";
            case "&": return "&amp;";
        }
        return strMatch;
    }
    /// </method>

    /// <method name="_getXPathDecodedTextMatch"  access="private">
    /// <summary>
    /// Decodes a specific match
    /// </summary>
    /// <param name="strMatch">The current match to get its replacing value.</param>
    function _getXPathDecodedTextMatch(strMatch) {
    
        switch(strMatch)
        {
            case "\\b": return " "; 
            case "\\t": return "\t"; 
            case "\\n": return "\n";
        }
        return _getXPathDecodedCommon(strMatch);
    }
    /// </method>

    /// <method name="_getXPathDecodedHtmlMatch"  access="private">
    /// <summary>
    /// Decodes a specific match
    /// </summary>
    /// <param name="strMatch">The current match to get its replacing value.</param>
    function _getXPathDecodedHtmlMatch(strMatch) {
    
        switch(strMatch)
        {
            case "\\b": return String.fromCharCode(160);
            case "\\t": return String.fromCharCode(160,160,160,160);
            case "\\n": return "<br/>";
        }
        return _getXPathDecodedCommon(strMatch);
    }
    /// </method>
	
		
	/// <object name="_XPathAttributeNode">
    /// <summary>
    /// Provides xpath support for node
    /// </summary>
	function _XPathAttributeNode(objAttrNode, objContext){
	    
	    // Get the owner element
	    var objOwnerElement = objContext;
	    
	    // If is ie
	    if(mcntIsIE)
		{
		    // Get parent for ie
		    objOwnerElement = objAttrNode.selectSingleNode("parent::*");
		}
		
	    // The owner element as parent node
	    this.parentNode = objOwnerElement;
	    
	    // The node type
	    this.nodeType = objAttrNode.nodeType;
	    
	    // The node value
	    this.nodeValue = objAttrNode.nodeValue;
	    
	    // The node child nodes
	    this.childNodes = objAttrNode.childNodes;
	    
	    // The first child
		this.firstChild = objOwnerElement.firstChild;
		
		// The last node
		this.lastChild = objOwnerElement.lastNode;
		
		// Node name
		this.nodeName = objAttrNode.nodeName;
		
		// Actual node
		this.actualNode = objAttrNode;
		
		// Set the owner document
		this.ownerDocument = objOwnerElement.ownerDocument;
	}
	
	_XPathAttributeNode.prototype = {
	
	    getAttribute : function(attr) {
			return this.parentNode.getAttribute(attr);
		},
		setAttribute : function(attr) {
			return this.parentNode.setAttribute(attr);
		},
		hasAttribute : function(attr){
		    return this.parentNode.hasAttribute(attr);
		},		
		getElementsByTagName : function(tagName){
		    return this.parentNode.getElementsByTagName(tagName);
	    }
	}
	/// </object>
	
	
	
	
})(jQuery);