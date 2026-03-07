(function($){

    // Handlers templte debuging
    var blnDebugTemplates = null;
    
    // The current debug subject
    var fncDebugSubject = "";
    
    // The total debug offset time for calculating exclusive template execution time
    var intDebugOffsetTime = 0;
    
    // The debug search offset time
    var intDebugEvaluationOffsetTime = 0;
    

    
    /// <object name="_JQTTemplates">
    /// <summary>
    /// Provides implemenation for jQuery templates
    /// </summary>
    function _JQTTemplates()
    {
        // The templates modes
        this.mobjTemplateModes = {};
        
        // The template names
        this.mobjTemplateNames = {};
        
        // The next template id
        this.mintTemplateId = 0;
        
        // The template methods
        this.mobjTemplatesMethods = {};
        
        // The template globals
        this.mobjTemplateGlobals = {};

         // The template globals
         this.mobjTemplateGlobals = {};
    }

    /// <summary>
    /// The jQuery templates methods
    /// </summary>
    _JQTTemplates.prototype = {
            

        /// <method name="setGlobalVariable">
        /// <summary>
        /// Sets a global variable
        /// </summary>
        setGlobalVariable : function(strName, strValue){
        
            // Store global variable
            this.mobjTemplateGlobals[strName] = strValue;
        },
        /// </method>

	    /// <method name="getGlobalVariable">
	    /// <summary>
	    /// Gets a global variable
	    /// </summary>
	    getGlobalVariable : function(strName, strValue){

		    // Get global variable
		    return this.mobjTemplateGlobals[strName];
	    },
	    /// </method>  
        
        /// <method name="getTemplate">
        /// <summary>
        /// Gets a named template
        /// </summary>
        getTemplate : function(strHash, strMode){
            return this.mobjTemplateModes[strHash];
        },
        /// </method>
        
        /// <method name="compileTemplates">
        /// <summary>
        /// Compiles the template selectors
        /// </summary>
        compileTemplates : function(objDocument){
        
            // If is not msie browser
            if(!mcntIsIE)
            {
                // Loop all template modes
                for(var strMode in this.mobjTemplateModes)
                {
                    
                    // Get mode hash
                    var objMode = this.mobjTemplateModes[strMode];
                    
                    // If there is a valid mode hash
                    if(objMode!=null)
                    {
                        // Loop all template hash
                        for(var strHash in objMode)
                        {
                            // Get mode selector
                            var objSelector = objMode[strHash];
                            
                            // If there is a valid selector
                            if(objSelector!=null)
                            {
                                // Compile templtes
                                objSelector.compileTemplates(objDocument);
                            }
                        }
                    }
                }
            }
        },
        /// </method>
        
        /// <method name="_generateTemplateId">
        /// <summary>
        /// Generates a template id
        /// </summary>
        _generateTemplateId : function()
        {
            // Increment the template id
            this.mintTemplateId++;
            return this.mintTemplateId;
        },
        /// </method>
        
        /// <method name="setTemplate">
        /// <summary>
        /// Sets a given template
        /// </summary>
        setTemplate : function(strXPath, strMode, fncTemplate, objMethods){
        
            // If there is a valid funtion
            if(typeof fncTemplate==="function") {
            
                // If is an empty mode
                if(this.isEmpty(strMode))
                {
                    // Set default mode
                    strMode = "default";
                }
                
                // Try to get existing mode hash
                var objMode = this.mobjTemplateModes[strMode];
                
                // If mode was not yet created
                if(!objMode)
                {
                    // Create mode hash
                    this.mobjTemplateModes[strMode] = objMode = {};
                }
                
                // Get the template match array
                var arrTemplateMatch = this._getTemplateMatch(strXPath);
                
                // Gets the next template id
                var strTemplateId = this._generateTemplateId();
                
                // If there are methods defined
                if(objMethods)
                {
                    // Loop all method names
                    for(var strMethod in objMethods)
                    {
                        // Store method with in method hash
                        this.mobjTemplatesMethods["T" + strTemplateId + "~" + strMethod] = objMethods[strMethod];
                    }
                }
                
                // Set the tempate context
                fncTemplate.objContext = new JQTTemplateContext(strTemplateId, this.mobjTemplateGlobals);

                // Set tracing variables
                fncTemplate.intCallCount = 0;
                fncTemplate.intCallTime = 0;
                fncTemplate.intEvaluateTime = 0;
                fncTemplate.intEvaluateCount = 0;
                fncTemplate.intSearchTime = 0;
                
                // Loop all template matches
                for(var intTemplateMatch = 0; intTemplateMatch < arrTemplateMatch.length; intTemplateMatch++)
                {
                    // Get the template match
                    var objTamplateMatch = arrTemplateMatch[intTemplateMatch];
                    
                    // Get the template hash
                    var strTemplateHash = objTamplateMatch[0];
                    
                    // If the template hash is a template name
                    if(strTemplateHash.indexOf("#") > -1)
                    {
                        // Store the template under the names hash
                        this.mobjTemplateNames[strTemplateHash.substr(1)] = fncTemplate;
                    }
                    else
                    {
                        // Get the template condition
                        var strTemplateCondition = objTamplateMatch[1];
                        
                        // Get the template priority
                        var intTemplatePriority = objTamplateMatch[2];
                        
                        // Get the template match
                        var strTemplateOriginalMatch = objTamplateMatch[3];
                        
                        // Get the template selector
                        var objTemplateSelector = objMode[strTemplateHash];
                        
                        // If template selector had not been initialized yet
                        if(!objTemplateSelector)
                        {
                            // Create a new template selector
                            objMode[strTemplateHash] = objTemplateSelector = new _JQTTemplateSelector();
                        }
                        
                        
                        // Register the template with in the template selector
                        objTemplateSelector.registerTemplate(fncTemplate, strTemplateCondition, intTemplatePriority, strTemplateOriginalMatch);
                    }
                }
            }
        },
        /// </method>


        /// <method name="_calculcateTemplatePatternRank">
        /// <summary>
        /// Calculate a rank for the recieved template pattern.
        /// </summary>
        _calculcateTemplatePatternRank : function(strTemplatePattern)
        {
            // Initialize criterias counter.
            var intCriterias = 0;

            // Initialize current pattern.
            var strCurrentPattern = strTemplatePattern;

            // Define an opening bracket index.
            var intOpenBracketIndex = -1;

            // Loop while criterias can still be found.
            while ((intOpenBracketIndex = strCurrentPattern.indexOf('[')) != -1) 
            {
                // Try getting a closing bracket index.
                var intCloseBracketIndex = strCurrentPattern.indexOf(']');
                if(intCloseBracketIndex != -1)
                {
                    // Raise criterias counter.
                    intCriterias+=1;

                    // Rebuild current pattern so it wont contain current criteria.
                    strCurrentPattern = (strCurrentPattern.substr(0,intOpenBracketIndex) + strCurrentPattern.substr(intCloseBracketIndex+1));
                }
                else
                {
                    // Return a zero rank for invalid pattern (openning bracket without a closing one).
                    return 0;
                }
            }

            // Return number of criterias plus number of levels in xpath (specified by the '/' character).
            return (strCurrentPattern.split("/").length - 1) + intCriterias;
        },
        /// </method>

        /// <method name="_getHashCodeRank">
        /// <summary>
        /// Gets a rank for the recieved hash code.
        /// </summary>
        _getHashCodeRank : function(objSubject,objMode,strHashCode)
        {
            var intHashCodeRank = 0;

            // Validate recieved arguments.
            if (objSubject && objMode && strHashCode)
            {
                // Get template selector.
                var objTemplateSelector = objMode[strHashCode];
                if(objTemplateSelector != null && objTemplateSelector.marrTemplates)
                { 
                    // Loop all templates.
                    for (var i = 0; i < objTemplateSelector.marrTemplates.length; i++) 
                    {
                        // Get current template.
                        var objTemplate = objTemplateSelector.marrTemplates[i];
                        if(objTemplate)
                        {
							// Check if subject matches template.
                            if (objTemplateSelector.isSubjectMatchesTemplate(objSubject, objTemplate))
                            {
                                // Get current template pattern.
                                var strTemplatePattern = objTemplate[5];
                                if(strTemplatePattern)
                                {
                                    // Calculcate current template rank.
                                    var intTemplateRank = this._calculcateTemplatePatternRank(strTemplatePattern);
                                
                                    // Check if current template rank is bigger the the last one found so far.
                                    if(intTemplateRank > intHashCodeRank)
                                    {
                                        intHashCodeRank = intTemplateRank;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return intHashCodeRank;
        },
        /// </method>

        /// <method name="_getModeSortedHasheCodes">
        /// <summary>
        /// Gets a sorted lsit of mode hashe codes.
        /// </summary>
        _getModeSortedHasheCodes : function(objSubject,objMode,strNodeNameHash)
        {
            // Define an empty array.
            var arrSortedHasheCodes = [];

            // Validate mode argument.
            if(objSubject && objMode)
            {
                // Add the generic hash.
                arrSortedHasheCodes = [{Hash:"*"}];

                // Validate node name hash.
                if(strNodeNameHash)
                {
                    // Add a node name hash.
                    arrSortedHasheCodes.push({Hash:strNodeNameHash});

                    // Split namespace
                    var arrHash = strNodeNameHash.split(":");
                            
                    // If tag name contains namespace
                    if(arrHash.length==2)
                    {
                        // Add a genericname space name hash.
                        arrSortedHasheCodes.push({Hash:arrHash[0]+":*"});
                    }
                }

                // Loop all hash codes.
                for(var i=0; i<arrSortedHasheCodes.length; i++)
                {
                    // Get current hash code.
                    var objHashCode = arrSortedHasheCodes[i];
                    if(objHashCode)
                    {
                        // Calculate rank for current hash code.
                        objHashCode.Rank = this._getHashCodeRank(objSubject,objMode,arrSortedHasheCodes[i].Hash);
                    }
                }

                // Sort array.
                arrSortedHasheCodes.sort(function(a,b)
                { 
                    // If rank is different, return the difference between b and a.
                    if( b.Rank != a.Rank)
                    {
                        return b.Rank - a.Rank; 
                    }

                    // Check if second hash code is the node hash.
                    if(b.Hash==strNodeNameHash)
                    {
                        // Return second hash code.
                        return 1;
                    }

                    // Check if first hash code is the node hash.
                    if(a.Hash==strNodeNameHash)
                    {
                        // Return first hash code.
                        return -1;
                    }

                    // Check if first hash code is the generic hash.
                    if(a.Hash=="*")
                    {
                        // Return second hash code.
                        return 1;
                    }

                    // Check if second hash code is the generic hash.
                    if(b.Hash=="*")
                    {
                        // Return first hash code.
                        return -1;
                    }

                    // Return equal result.
                    return 0;
                });

                // Loop all hash objects and preserve only the hash string.
                for(var i=0; i<arrSortedHasheCodes.length; i++)
                {
                    arrSortedHasheCodes[i] = arrSortedHasheCodes[i].Hash;
                }
            }

            return arrSortedHasheCodes;
        },
        /// </method>
        
        /// <method name="_getTemplateMatch">
        /// <summary>
        /// Gets the template match for the given xpath
        /// </summary>
        _getTemplateMatch : function(strXPath)
        {
            // The current position 
            var intPosition = 0;
            
            // The current [] nesting level
            var intLevel = 0;
            
            // The xpath parts
            var arrXPathParts = [];
            
            // Set the current xpath array
            var arrXPaths = [arrXPathParts]
            
            // Loop all expression charecters
            for(var intIndex=0; intIndex < strXPath.length; intIndex++)
            {
                // Get current char
                var chrCurrent = strXPath.charAt(intIndex);
                
                // If is a join axis and the level is 0
                if(chrCurrent=='/' && intLevel == 0)
                {   
                    // If is a valid selection
                    if(intIndex > intPosition)
                    {
                        // Add current selection to the xpath parts
                        arrXPathParts.push( strXPath.substr(intPosition, intIndex - intPosition));
                        
                        // Set the new starting position
                        intPosition = intIndex + 1;
                    }
                }
                // If is an xpath connector
                else if(chrCurrent=='|' && intLevel == 0)
                { 
                    // If is a valid selection
                    if(intIndex > intPosition)
                    {
                        // Add current selection to the xpath parts
                        arrXPathParts.push( strXPath.substr(intPosition, intIndex - intPosition));
                        
                        // Set the new starting position
                        intPosition = intIndex + 1;
                    }
                    
                    // Create a new array
                    arrXPathParts = [];
                    
                    // Add a new xpath array
                    arrXPaths.push(arrXPathParts);
                }
                // If a begining of [] nesting
                else if(chrCurrent=='[')
                {
                    intLevel++;
                }
                // If a ending of [] nesting
                else if(chrCurrent==']')
                {
                    intLevel--;
                }
                
            }
            
            // If there are left overs
            if(intIndex > intPosition)
            {
                // Add the last part
                arrXPathParts.push( strXPath.substr(intPosition, intIndex - intPosition));
            }
            
            // The results
            var arrResults = [];
            
            // Loop all generated xpath parts
            for(var intXPathIndex = 0; intXPathIndex < arrXPaths.length; intXPathIndex++)
            {
                // Get the current xpath parts
                arrXPathParts = arrXPaths[intXPathIndex]
                
                // The xpath condition
                var arrXPathCondition = [];
                
                // The xpath target node
                var strXPathTarget = null;
                
                // The xpath target part
                var blnXPathTarget = true;
                
                // The number of closure elements to add
                var intXPathClosure = 0;
                
                // Loop all generated xpath parts
                for(var intIndex = arrXPathParts.length-1; intIndex>=0; intIndex--)
                {
                    // Get the current xpath part
                    var strXPathPart = arrXPathParts[intIndex];
                    
                    // If is a valid xpath part
                    if(strXPathPart.length > 0)
                    {
                        // If we need to trim end the xpath part
                        if(strXPathPart.charAt(strXPathPart.length-1) == "]")
                        {
                            // Trim the end of the xpath
                            strXPathPart = strXPathPart.substr(0,strXPathPart.length-1);
                        }
                        
                        // Get the current part
                        var arrPart = strXPathPart.split("[" ,2);
                    
                        // Get the part tag
                        var strPartTag = arrPart[0];
                        
                        // Get the part condition
                        var strPartCondition = arrPart.length > 1 ? arrPart[1] : null;
                        
                        // If is xpath target
                        if(blnXPathTarget)
                        {
                            // Set the xpath target
                            strXPathTarget = strPartTag;
                            
                            // If there is a codition
                            if(strPartCondition!=null)
                            {
                                // push the current condition
                                arrXPathCondition.push(strPartCondition);
                            }
                            
                            // Indicates that no longer xpath target
                            blnXPathTarget = false;
                        }
                        else
                        {
                            // If there is a target condition
                            if(arrXPathCondition.length == 1)
                            {
                                arrXPathCondition.push(" and ");
                            }
                            
                            
                            // Add current parent codtion
                            arrXPathCondition.push("parent::");
                            arrXPathCondition.push(strPartTag)

                            // If there is a part condition or there is more parents 
                            if(intIndex != 0 || strPartCondition!=null)
                            {
                                arrXPathCondition.push("[");
                                
                                // Add closure count
                                intXPathClosure++;
                            }
                                                                        
                            // If there is a codition
                            if(strPartCondition!=null)
                            {
                                // push the current condition                            
                                arrXPathCondition.push(strPartCondition);
         
                                // If there are more parents
                                if(intIndex != 0)
                                {
                                    // Add parent codition
                                    arrXPathCondition.push(" and ");
                                }
                            }
                        }
                    }                                                
                }
                
                // Add all the required closures
                for(var i=0; i<intXPathClosure; i++)
                {
                    arrXPathCondition.push("]");
                }

                // Calculcate current template rank.
                var intTemplateRank = this._calculcateTemplatePatternRank(strXPath);

                // If there is a valid expression
                if(arrXPathCondition.length>0)
                {
			       // Ensure that IE get expression evalutaed to a node-set
                   // Return the generated path
                    arrResults.push([strXPathTarget, "self::*[" + arrXPathCondition.join("") + "]", intTemplateRank, arrXPathParts.join("/")]);
                }
                else
                {
                    // Return the generated path
                    arrResults.push([strXPathTarget, null, intTemplateRank, arrXPathParts.join("/")]);
                }
            }
            
            // Return the results
            return arrResults;
        },
        /// </method>
        
        /// <method name="callTemplate">
        /// <summary>
        /// Calls a given template
        /// </summary>
        callTemplate :  function(strHash, strMode, objSubject, objWriter, blnCallByName, objArguments) { 
        
            // If there is a valid hash
            if(strHash)
            {
                // If there is not writer
                var blnReturnDOM = this.isEmpty(objWriter);
                
                // If there is no writer
                if(blnReturnDOM)
                {
                    // Create the writer
                    objWriter = new JQTTemplateWriter();
                }
                

                
                // If arguments are empty
                if(!objArguments)
                {
                    // Get an empty object
                    objArguments = {};
                }
                

                
                var log = [];
                
                // The template method
                var fncTemplate = null;       
                                
                // The before search time
                var objBeforeSearchTime;   
                
                // The search offset 
                var intBeforeEvaluationOffsetTime;
                
                // If is in debug mode
                if(blnDebugTemplates) {
                
                    // Set current date
                    objBeforeSearchTime = new Date();
                    
                    // Get before search offset time
                    intBeforeEvaluationOffsetTime = intDebugEvaluationOffsetTime;
                }    
                        
                // If is call by name template
                if(blnCallByName)
                {
                    // Get the named template
                    fncTemplate = this.mobjTemplateNames[strHash];
                    
                    // If could not find named template 
                    if(!fncTemplate)
                    {
                        log.push("template: not found template name=" + strHash);
                    }
                }
                else
                {
                    // If is an empty mode
                    if(this.isEmpty(strMode))
                    {
                        // Set default mode
                        strMode = "default";
                    }
                
                    // Try to get existing mode hash
                    var objMode = this.mobjTemplateModes[strMode];
                    
                    // If mode was not yet created
                    if(objMode)
                    {
                        // Get a mode sorted hashe codes array.
                        var arrSortedHasheCodes = this._getModeSortedHasheCodes(objSubject,objMode,strHash);

                        // Loop a sorted list of mode hashe codes.
                        for(var i=0; i<arrSortedHasheCodes.length; i++)
                        {
                            var strHashCode = arrSortedHasheCodes[i];
                            if(strHashCode)
                            {
                                // Try to get template hash code
                                if(objTemplateSelector = objMode[strHashCode])
                                {
                                    // Try getting a template function
                                    if(fncTemplate = objTemplateSelector.getTemplate(objSubject, blnDebugTemplates))
                                    {
                                        // Break loop.
                                        break;
                                    }
                                    else
                                    {
                                        log.push("template: not found actualhash=" +strHash+ " hash=" + strHashCode + " mode=" + strMode);
                                    }
                                }
                            }
                        }
                    }
                }
                
                // If there is a valid template
                if(fncTemplate)
                {
                    // The time before call
                    var intBeforeCall = 0;
                    
                    // The debug offset
                    var intBeforeOffset = 0;
                    
                    // If should debug templates
                    if(blnDebugTemplates)
                    {
                        // Record the search time  minus the evaluation time                                    
                        fncTemplate.intSearchTime += ((new Date())-objBeforeSearchTime) - (intDebugEvaluationOffsetTime - intBeforeEvaluationOffsetTime);
                        
                        // Increment the template call type
                        fncTemplate.intCallCount++;
                        
                        // Get the current time
                        intBeforeCall = new Date();
                        
                        // Get the current debug offset
                        intBeforeOffset = intDebugOffsetTime;
                    }
                    
                    // Call template with subject, wirter, and method resolver
                    fncTemplate.call(objSubject, objWriter, fncTemplate.objContext, objArguments);
                    
                    // If should debug templates
                    if(blnDebugTemplates)
                    {
                        // Get the total time
                        var intCallTime = ((new Date())- intBeforeCall);
                        
                        // Get the exclusive time
                        var intExclusiveCallTime = intCallTime - (intDebugOffsetTime - intBeforeOffset);
                        
                        // Record execution time
                        fncTemplate.intExecuteTime += intCallTime;
                        
                        // Record exclusive time
                        fncTemplate.intCallTime += intExclusiveCallTime;
                        
                        // Update the debug offset time
                        intDebugOffsetTime += intExclusiveCallTime;
                    }
                }
                else
                {
			        if(mcntIsIE == false)
			        {
				        for(var i=0;i<log.length;i++)
				        {
					        console.log(log[i]);
				        }
                    }
                }
                        
                // If should return dom and there are valid results 
                if(blnReturnDOM)
                {
                    return $(objWriter.flush());
                }
            }
        },
        /// </method>
        
        /// <method name="callTemplate">
        /// <summary>
        /// Calls a given template
        /// </summary>
        callTemplateBySubject : function(objSubject, strMode, objWriter, objArguments){
        
            // Get hash from subject
            var strHash = this.getHashFromSubject(objSubject);
            if(strHash)
            {
                // Call the template
                return this.callTemplate(strHash, strMode, objSubject, objWriter, false, objArguments);
            }
        },
        /// </method>
        
        /// <method name="getHashFromSubject">
        /// <summary>
        /// Gets template has from subject
        /// </summary>
        getHashFromSubject : function(objSubject){
            
            // If there is a valid subject
            if(objSubject)
            {
                // If subject has a get method
                if(objSubject.get)
                {
                    // Get the subject instance
                    var objSubjectInstance = objSubject.get(0);
                    
                    // If there is a valid subject instance
                    if(objSubjectInstance!=null)
                    {
                        // Return the generated hash
                        return objSubjectInstance.tagName;
                    }
                }
            }
            
            return null;
        },
        /// </method>
        
        /// <method name="isEmpty">
        /// <summary>
        /// Indicates if a value is empty
        /// </summary>
        isEmpty : function(objValue){
            
            return ((typeof objValue == "undefined") || (objValue == null || objValue == ""));
            
        },
        /// </method>
        

        
        /// <method name="callMethod">
        /// <summary>
        /// Call the template method
        /// </summary>
        callMethod : function(strHash, objSource)
        {
            // Try to get existing method
            var objMethod = this.mobjTemplatesMethods[strHash];
            
            // If is not a method
            if($.isFunction(objMethod))
            {
                // Delegate the call 
                switch(arguments.length)
                {
                    case 2:
                        return objMethod.call(objSource);
                    case 3:
                        return objMethod.call(objSource, arguments[2]);   
                    case 4:
                        return objMethod.call(objSource, arguments[2], arguments[3]);  
                    case 5:
                        return objMethod.call(objSource, arguments[2], arguments[3], arguments[4]);  
                    case 6:
                        return objMethod.call(objSource, arguments[2], arguments[3], arguments[4], arguments[5]);  
                    case 7:
                        return objMethod.call(objSource, arguments[2], arguments[3], arguments[4], arguments[5], arguments[6]);  
                }               
            }
            
        },
        /// </method>
        
        /// <method name="_getTemplateSubjectList">
        /// <summary>
        /// Get template subject list
        /// </summary>
        _getTemplateSubjectList : function(objSubject) {
            
            // The template subject list
            var arrTemplateSubjectList = [];
            
            var intSubject = 0;
            
            // If there is a valid subject
            if(objSubject)
            {
                // If is a jquery object
                if(objSubject.jquery)
                {
					// Loop all items
                    for(var intIndex=0;intIndex<objSubject.length;intIndex++)
                    {
						// Add a jQuery wrapped item
                        arrTemplateSubjectList[intIndex] = xpath$(objSubject[intIndex]);
                    }
                }
                else
                {
                    // Add the current jQuery wrapped subject
                    arrTemplateSubjectList[intSubject++] = xpath$(objSubject);
                }
            }
            
            // Return the subject list
            return arrTemplateSubjectList;
        },
        /// </method>
        
        /// <method name="_getTemplateResult">
        /// <summary>
        /// Get template result
        /// </summary>
        _getTemplateResult : function(arrResults) {
        
            // If there are results
            if(arrResults.length > 0)
            {
                // If a single result
                if(arrResults.length == 1)
                {
                    // Return the first result
                    return arrResults[0];
                }
                else
                {
                    // Return the result array
                    return arrResults;
                }
            }
        },
        /// </method>   
        
        /// <method name="debug">
        /// <summary>
        /// Provides support for debugging the template engine
        /// </summary>
        debug : function(objAction, strParam) {
        
            // Calculates the avrage value
            function avg(intCount, intTime) {
                return intCount == 0 || intTime == 0 ? 0 : (intTime / intCount).toFixed(2);
            }
            
            var blnClear = false;
            
            // If is should turn debuggin on
            if(objAction == "on")
            {
                // Turn xpath debugging on
                $.xpath("debug","on");
                
                // Enable debugging
                blnDebugTemplates = true;
                return;
            }
            else if(objAction == "off")
            {
                // Turn xpath debugging off
                $.xpath("debug","off");
                
                // Clear debugging
                blnDebugTemplates = false;
                return;
            }
            else if(objAction == "clear")
            {
                // Turn xpath debugging off
                $.xpath("debug","clear");
                
                blnClear = true;
            }
            
            
            // If there is a valid debug function attached
            if(blnDebugTemplates || blnClear) {
            
                // The template information
                var arrTemlates = [];
                
                // The template function
                var fncTemplate = null;
                
                // Loop all template mode
                for(var strMode in this.mobjTemplateModes) {
                
                    // Get template hash
                    var objTemplateHash = this.mobjTemplateModes[strMode];
                    
                    // If there is a valid template hash
                    if(objTemplateHash!=null) {
                    
                        // Loop all template hash
                        for(var strHash in objTemplateHash) {
                
                            // Get the current selector
                            var objTemplateSelector = objTemplateHash[strHash];
                            
                            // If there is a valid template selector
                            if(objTemplateSelector) {
                            
                                // Get the array of templates
                                var arrSelectorTemplates = objTemplateSelector.marrTemplates;
                                
                                // Loop all templates
                                for(var intIndex=0; intIndex < arrSelectorTemplates.length; intIndex++)
                                {
                                    var objTemplate = arrSelectorTemplates[intIndex];
                                    
                                    // Get template
                                    if(fncTemplate = objTemplate[0]) {
                                        
                                        if(!blnClear) {
                                            // If there is a call time
                                            if(fncTemplate.intCallCount > 0) {
                                            
                                                // Add the template name / count / time / avarage
                                                arrTemlates.push([objTemplate[5],
                                                    strMode, 
                                                    fncTemplate.intCallCount, 
                                                    fncTemplate.intCallTime, 
                                                    avg(fncTemplate.intCallCount ,fncTemplate.intCallTime), 
                                                    fncTemplate.intEvaluateCount, 
                                                    fncTemplate.intEvaluateTime, 
                                                    avg(fncTemplate.intEvaluateCount, fncTemplate.intEvaluateTime),
                                                    fncTemplate.intSearchTime
                                                    ]);
                                            }
                                        } else {                                        
                                            // Clear template data
                                            fncTemplate.intCallCount = 0;
                                            fncTemplate.intCallTime = 0;
                                            fncTemplate.intEvaluateCount = 0;
                                            fncTemplate.intEvaluateTime = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                // Loop all template names
                for(var strName in this.mobjTemplateNames) {
                
                    // Get template
                    if(fncTemplate = this.mobjTemplateNames[strName]) {
                        
                        if(!blnClear) {
                            // If there is a call time
                            if(fncTemplate.intCallCount > 0) {
                            
                                // Add the template name / count / time / avarage
                                arrTemlates.push([
                                    strName,
                                    "", 
                                    fncTemplate.intCallCount, 
                                    fncTemplate.intCallTime, 
                                    avg(fncTemplate.intCallCount ,fncTemplate.intCallTime), 
                                    fncTemplate.intEvaluateCount, 
                                    fncTemplate.intEvaluateTime, 
                                    avg(fncTemplate.intEvaluateCount, fncTemplate.intEvaluateTime),
                                    fncTemplate.intSearchTime
                                    ]);
                            }
                        }
                        else {
                        
                            // Reset data
                            fncTemplate.intCallCount = 0;
                            fncTemplate.intCallTime = 0;
                            fncTemplate.intEvaluateCount = 0;
                            fncTemplate.intEvaluateTime = 0;
                        }
                    }
                }
                
                // Don't generate report on clear
                if(blnClear) {
                    return;
                }
                
                // Sort the templates by performance 
                arrTemlates.sort(function(a,b){
                    return b[3] - a[3];
                });
                
                var arrXPathBuffer = [];
                
                // Get the xpath breakdown and total query time
                var intTotalQueryTime = $.xpath("debug", arrXPathBuffer);
                
                // Create the information dump
                var arrBuffer = ["<div style=\""];
				arrBuffer.push("margin:3px 5px;");
				arrBuffer.push("\">");
                
                
                var intTotalCalls = 0;
                var intTotalCallTime = 0;
                var intTotalEvaluations = 0;
                var intTotalEvaluationTime = 0;
                var intTotalSearchTime = 0;
                
                // Loop all templates
                for(var intIndex=0; intIndex < arrTemlates.length; intIndex++)
                {
                    intTotalCalls+=arrTemlates[intIndex][2];
                    intTotalCallTime+=arrTemlates[intIndex][3];
                    intTotalEvaluations+=arrTemlates[intIndex][5];
                    intTotalEvaluationTime+=arrTemlates[intIndex][6];
                    intTotalSearchTime+=arrTemlates[intIndex][8];
                }
                
                arrBuffer.push("<h2>Template Perforamnce</h2>");
                arrBuffer.push("<table border=\"1\" cellspacing=\"0\">");
                arrBuffer.push("<tr><td>Calls</td><td>"+intTotalCalls+"</td></tr>");
                arrBuffer.push("<tr><td>Total Call Time</td><td>"+intTotalCallTime+" ms</td></tr>");
                arrBuffer.push("<tr><td>Avarage Call Time</td><td>"+avg(intTotalCalls,intTotalCallTime) +" ms</td></tr>");
                arrBuffer.push("<tr><td>Evaluations</td><td>"+intTotalEvaluations+"</td></tr>");
                arrBuffer.push("<tr><td>Total Evaluation Time</td><td>"+intTotalEvaluationTime+" ms</td></tr>");
                arrBuffer.push("<tr><td>Avarage Evaluation Time</td><td>"+avg(intTotalEvaluations,intTotalEvaluationTime) +" ms</td></tr>");
                arrBuffer.push("<tr><td>Total Search Time</td><td>"+intTotalSearchTime +" ms</td></tr>");
                arrBuffer.push("<tr><td>Total Query Time</td><td>"+intTotalQueryTime +" ms</td></tr>");
                arrBuffer.push("</table>");
                
                
                arrBuffer.push("<h2>Template Perforamnce Breakdown</h2>");
                arrBuffer.push("<table border=\"1\" cellspacing=\"0\"><tr>");
                arrBuffer.push("<td>Selector</td>");
                arrBuffer.push("<td>Mode</td>");
                arrBuffer.push("<td>Calls</td>");
                arrBuffer.push("<td>Total Call Time</td>");
                arrBuffer.push("<td>Avarage Call Time</td>");
                arrBuffer.push("<td>Evaluations</td>");
                arrBuffer.push("<td>Total Evaluation Time</td>");
                arrBuffer.push("<td>Avarage Evaluation Time</td>");
                arrBuffer.push("<td>Search Time</td>");
                arrBuffer.push("</tr>");
                
                
                
                // Loop all templates
                for(var intIndex=0; intIndex < arrTemlates.length; intIndex++)
                {
                    arrBuffer.push("<tr>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][0]+" </td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][1]+"&nbsp;</td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][2]+" </td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][3]+" ms</td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][4]+" ms</td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][5]+" </td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][6]+" ms</td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][7]+" ms</td>");
                    arrBuffer.push("<td> "+arrTemlates[intIndex][8]+" ms</td>");
                    arrBuffer.push("</tr>");
                }
                
                arrBuffer.push("</table>");
                
                // Add the xpath buffer
                arrBuffer.push(arrXPathBuffer.join(""), "</div>");
                                                
                // Call the debug template callback
                return (arrBuffer.join(""));
            }
            else {
            
				var message = ["<div style=\""];

				// Write the code styles
				message.push("color:black;");
				message.push("font-size:10pt;");
				message.push("font-family: Courier New, Courier, Monospace;");
				message.push("background-color: #ffffff;");	
				message.push("margin:3px 5px;");
				message.push("\">");
				
				message.push("<p>No debug data.</p>");
				message.push("<p>Press:<BR/>");
				message.push("<p>&nbsp;'Enable' to start data collecting.<BR/>");
				message.push("&nbsp;'Refresh' to show the collected data.<BR/>");
				message.push("&nbsp;'Open in a window' to open results in a window.<BR/>");
				message.push("&nbsp;'Clear' to reset performance counters.</p>");
				message.push("</div>");

                return message.join("");
            }
        }
        /// </method>
    };

    /// </object>




    /// <object name="_JQTTemplateSelector">
    /// <summary>
    /// Provides implemenation for jQuery  template selector
    /// </summary>
    function _JQTTemplateSelector()
    {
        // the template collection 
        this.marrTemplates = [];
        
    }

    /// <summary>
    /// The jQuery  template selector methods
    /// </summary>
    _JQTTemplateSelector.prototype = {

        /// <method name="isSubjectMatchesTemplate">
        /// <summary>
        /// Check if subject matches template.
        /// </summary>
        isSubjectMatchesTemplate : function (objSubject, objTemplate)
        {
            // Evaluate template condition        
            var blnIsMatch = false;

            if (objSubject && objTemplate)
            {
                // The before time 
                var objBeforeTime;

                // If is in debug mode
                if (blnDebugTemplates)
                {
                    // Validate template evaluation count.
                    if(objTemplate[0])
                    {
                        // Get before time
                        objBeforeTime = new Date();

                        // Incrememnt evaluation count
                        objTemplate[0].intEvaluateCount++;
                    }
                }

                // Validate template xpath.
                if (objTemplate[1])
                {
                    // If is ie
                    if (mcntIsIE)
                    {
                        // Get the element
                        var objElement = objSubject[0];
                        if (objElement)
                        {
                            // Check expression
                            blnIsMatch = objElement.selectSingleNode(objTemplate[1]) != null;
                        }
                        else
                        {
                            // Cound not match
                            blnIsMatch = false;
                        }
                    }
                    else
                    {
                        // Run query
                        blnIsMatch = $.xpath("bool", objSubject.xpath(objTemplate[1]));
                    }
                }

                // If is in debug mode
                if (blnDebugTemplates)
                {
                    // Validate template evaluation count.
                    if(objTemplate[0])
                    {
                        // Calculate the evaluation time
                        var intEvaluationTime = ((new Date()) - objBeforeTime);

                        // Increment the offset time
                        intDebugEvaluationOffsetTime += intEvaluationTime;

                        // Incrememnt evaluation time
                        objTemplate[0].intEvaluateTime += intEvaluationTime;
                    }
                }
            }

            return blnIsMatch;
        },
        /// </method>

        /// <method name="registerTemplate">
        /// <summary>
        /// Registers a template
        /// </summary>
        registerTemplate : function(fncTemplate, strTemplateExpression, intRank, strTemplateOriginalMatch) {
            // Apply order priority
            intRank += this.marrTemplates.length * 0.01;

            // Add template to template list
            this.marrTemplates.push([fncTemplate, strTemplateExpression, intRank, strTemplateExpression, strTemplateExpression, strTemplateOriginalMatch]);  
            
            // Sort the template array base on there ranking
            this.marrTemplates.sort(function(a,b){ return b[2] - a[2];});              
        },
        /// </method>
        
        /// <method name="compileTemplates">
        /// <summary>
        /// Gets a template
        /// </summary>
        compileTemplates : function(objDocument) {
        
            // Loop all registered templates    
            for(var intIndex=0; intIndex < this.marrTemplates.length; intIndex++)
            {
                // Get the current template
                var objTemplate = this.marrTemplates[intIndex];
                
                // Get the current template
                objTemplate[1] = $.xpath("compile", objDocument, objTemplate[3]);
            }
        },
        /// </method>
        
        /// <method name="getTemplate">
        /// <summary>
        /// Gets a template
        /// </summary>
        getTemplate : function(objSubject, blnDebug) {    
                                                         
            // Loop all registered templates    
            for(var intIndex=0; intIndex < this.marrTemplates.length; intIndex++)
            {
                // Get the current template
                var objTemplate = this.marrTemplates[intIndex];
                if (objTemplate)
                {
                    // If there is a template expression
                    if (objTemplate[1])
                    {   
                        // Check if subject matches template.
                        if (this.isSubjectMatchesTemplate(objSubject, objTemplate))
                        {                    
                            // Return the template method
                            return objTemplate[0];
                        }
                    }
                    else
                    {
                        // Return the template method
                        return objTemplate[0];
                    }
                }
            }
            
            return null;
        }
        /// </method>                        

    };
    /// </object>


    /// <object name="JQTTemplateContext">
    /// <summary>
    /// Provides implemenation for jQuery template context
    /// </summary>
    function JQTTemplateContext(strTemplateId, objGlobals)
    {
        this.strTemplateId = strTemplateId;
        this.globals = objGlobals;
    }


    /// <summary>
    /// The jQuery template context methods
    /// </summary>
    JQTTemplateContext.prototype = {


        /// <method name="getMethodCall">
        /// <summary>
        /// Gets a method call string
        /// </summary>
        getMethodCall : function(strMethod)
        {
            var arrBuffer = [];
            arrBuffer.push("$._jqttemplates.callMethod('T",this.strTemplateId,"~",strMethod,"',this");
            
            // Loop all arguments
            for(var intIndex=1; intIndex<arguments.length; intIndex++)
            {
                arrBuffer.push(",");
                
                // Get current argument
                var objArgument = arguments[intIndex];
                
                // If is not a number and not a boolean
                if(isNaN(objArgument) && (!(typeof objArgument == "boolean")))
                {            
                    // If argument is null
                    if(objArgument==null)
                    {
                        // Add null string
                        arrBuffer.push("null");
                    }                
                    else
                    {
                        arrBuffer.push("'",String(objArgument).replace("'","\\'"),"'");
                    }
                }
                else
                {
                    arrBuffer.push(objArgument);
                }
            }
            
            arrBuffer.push(");");
            
            return  arrBuffer.join("");
        }
        /// </method>
        
    };
    /// </object>

    /// <object name="JQTTemplateWriter">
    /// <summary>
    /// Provides implemenation for jQuery  template writer
    /// </summary>
    function JQTTemplateWriter()
    {
        // The writer bufffer 
        this.mobjBuffer = [];
        
        // Indicates if tag is open
        this.mblnIsTagOpen = false;
        
        // Indicates if attribute is open
        this.mblnIsAttributeOpen = false;
        
        // Indicates if in attribute content 
        this.mblnIsAttributeContent = false;
        
        // Track current writing position
        this.mintPosition = 0;
    }

    /// <summary>
    /// The jQuery  template writer methods
    /// </summary>
    JQTTemplateWriter.prototype = {

        /// <method name="write">
        /// <summary>
        /// Writes the given content
        /// </summary>
        write : function(){
            
            // Writer the start end tag if needed
            this._writeStartEndTagIfNeeeded();
            
            // Write the method arguments
            this._write(arguments);
        },
        /// </method>
        
        /// <method name="_writeStartEndTagIfNeeeded">
        /// <summary>
        /// Writes start tag end sign if needed
        /// </summary>
        _writeStartEndTagIfNeeeded : function()
        {
            // If not in tag open and in attribute open
            if(this.mblnIsTagOpen && !this.mblnIsAttributeOpen)
            {
                // Set tag open fals
                this.mblnIsTagOpen = false;
                
                // Push the start tag closing
                this.mobjBuffer[this.mintPosition++]=">";            
            }
        },
        
        /// <method name="write">
        /// <summary>
        /// Writes the given content
        /// </summary>
        _write : function(args){        
            
            // Get the write length
            var intLength = args.length;
            
            // Loop all input arguments
            for(var intIndex=0; intIndex<intLength; intIndex++)
            {
                // Push arguments
                this._writeValue(args[intIndex], false);
            }
        },
        /// </method>
        

        
        /// <method name="writeStartAttribute">
        /// <summary>
        /// Writes the begining of an attribute
        /// </summary>
        writeStartAttribute : function(strName){   
        
            // Indicate attribute is open
            this.mblnIsAttributeOpen = true;
            
            // Write attribute start     
            this.mobjBuffer[this.mintPosition++]=strName;                        
            this.mobjBuffer[this.mintPosition++]="=\"";                        
                
            // Indicate we are in attribute content if is an event attribute
            this.mblnIsAttributeContent =  this._isEventAttribute(strName);  
        },
        /// </method>
        

        
        
        /// <method name="writeEndAttribute">
        /// <summary>
        /// Writes the ending of an attribute
        /// </summary>
        writeEndAttribute : function(strName){ 
               
            // Indicate attribute content is done
            this.mblnIsAttributeContent = false;
            
            // Write the end buffer    
            this.mobjBuffer[this.mintPosition++]="\" ";  
            
            // Indicate attribute is closed
            this.mblnIsAttributeOpen = false;
        },
        /// </method>
        
        /// <method name="writeAttribute">
        /// <summary>
        /// Writes the given attribute name and content
        /// </summary>
        writeAttribute : function(strName){        
            
            // Write attribute start
            this.mobjBuffer[this.mintPosition++]=strName;  
            this.mobjBuffer[this.mintPosition++]="=\"";  
            
            // Indicate we are in attribute content if is an event attribute
            this.mblnIsAttributeContent = this._isEventAttribute(strName);
            
            // Get the argument length
            var intLength = arguments.length;
            
            // Loop all input arguments
            for(var intIndex=1; intIndex<intLength; intIndex++)
            {
                // Push arguments
                this._writeValue(arguments[intIndex], false);
            }
            
            // Indicate we are not in attribute content
            this.mblnIsAttributeContent = false;
            
            // Add the attribute ending
            this.mobjBuffer[this.mintPosition++]="\" ";  
        },
        /// </method>
        
        /// <method name="writeAsHtml">
        /// <summary>
        /// Writes the given content as html
        /// </summary>
        writeAsHtml: function(){        
        
            this._writeStartEndTagIfNeeeded();
            
            // Get the argument length
            var intLength = arguments.length;
            
            // Loop all input arguments
            for(var intIndex=0; intIndex<intLength; intIndex++)
            {
                // Push arguments
                this._writeValue(arguments[intIndex], true);
            }
        },
        /// </method>
        
        /// <method name="writeAsHtml">
        /// <summary>
        /// Writes the given content as html
        /// </summary>
        _writeValue : function(objValue, blnAsHtml){            
            
            // If is not a string value
            if(typeof objValue != "string") {
                        
                // If is function call it
                if(typeof objValue == "function")
                {
                    objValue();
                    return;
                }        
            
                // Get the string value from the object                    
                objValue = $.xpath("string",objValue);
            }
            
            // If should encode html                        
            if(blnAsHtml)
            {
                this.mobjBuffer[this.mintPosition++]=$.xpath("encodeHtml", objValue);  
            }
            else
            {
                // If shloud enclude attribute
                if(this.mblnIsAttributeContent)
                {
                    this.mobjBuffer[this.mintPosition++] = this._attrEncode(objValue);
                }
                else
                {
                    this.mobjBuffer[this.mintPosition++] = objValue;
                }
            }
            
        },
        /// </method>
        
        
        /// <method name="writeTagStrat">
        /// <summary>
        /// Writes the tag start
        /// </summary>
        writeTag : function(strName){      
            
            this._writeStartEndTagIfNeeeded();
              
            this.mblnIsTagOpen = true;
                    
            this.mobjBuffer[this.mintPosition++] = "<";
            this.mobjBuffer[this.mintPosition++] = strName;
            this.mobjBuffer[this.mintPosition++] = " ";
                     
            // Get the argument length
            var intLength = arguments.length;
                        
            // Loop all input arguments
            for(var intIndex=1; intIndex<intLength; intIndex++)
            {
                // Push arguments
                this._writeValue(arguments[intIndex], false);
            }
        },
        /// </method>
        
        /// <method name="writeFullTag">
        /// <summary>
        /// Writes the full tag
        /// </summary>
        writeFullTag : function(strName){      
            
            this._writeStartEndTagIfNeeeded();
             
            // Write the tag star            
            this.mobjBuffer[this.mintPosition++] = "<";
            this.mobjBuffer[this.mintPosition++] = strName;
                                 
            // Get the argument length
            var intLength = arguments.length;
            
            // Check if recieved arguments for the tag.
            if(intLength>1)
            {
                // Add a space after tag name.
                this.mobjBuffer[this.mintPosition++] = " ";                         
                
                // Loop all input arguments
                for(var intIndex=1; intIndex<intLength; intIndex++)
                {
                    // Push arguments
                    this._writeValue(arguments[intIndex], false);
                }
            }
                    
            this.mobjBuffer[this.mintPosition++] = "></";
            this.mobjBuffer[this.mintPosition++] = strName;
            this.mobjBuffer[this.mintPosition++] = ">";   
             
        },
        /// </method>
        
        /// <method name="writeEmptyTag">
        /// <summary>
        /// Writes an empty tag.
        /// </summary>
        writeEmptyTag : function(strName){      
            
            this._writeStartEndTagIfNeeeded();
             
            // Write the tag star            
            this.mobjBuffer[this.mintPosition++] = "<";
            this.mobjBuffer[this.mintPosition++] = strName;
                                 
            // Get the argument length
            var intLength = arguments.length;
            
            // Check if recieved arguments for the tag.
            if(intLength>1)
            {
                // Add a space after tag name.
                this.mobjBuffer[this.mintPosition++] = " ";                         
                
                // Loop all input arguments
                for(var intIndex=1; intIndex<intLength; intIndex++)
                {
                    // Push arguments
                    this._writeValue(arguments[intIndex], false);
                }
            }
                    
            this.mobjBuffer[this.mintPosition++] = "/>";                
        },
        /// </method>
        
        /// <method name="writeTagFullStrat">
        /// <summary>
        /// Writes the tag start
        /// </summary>
        writeTagFullStrat : function(strName){     
            
            this._writeStartEndTagIfNeeeded();
                          
            this.mobjBuffer[this.mintPosition++] = "<";
            this.mobjBuffer[this.mintPosition++] = strName;
            this.mobjBuffer[this.mintPosition++] = ">";   
        },
        /// </method>
        
        /// <method name="writeTagEnd">
        /// <summary>
        /// Writes the tag start
        /// </summary>
        writeTagEnd : function(strName){     
        
            this._writeStartEndTagIfNeeeded();
            
            this.mobjBuffer[this.mintPosition++] = "</";
            this.mobjBuffer[this.mintPosition++] = strName;
            this.mobjBuffer[this.mintPosition++] = ">";   
       
        },
        /// </method>
        
        
        /// <method name="_attrEncode">
        /// <summary>
        /// Encode an string to be safe for attribute content
        /// </summary>
	    _attrEncode : function(strValue) {
    	
	        // If there is a valid value
	        if(strValue != null && typeof strValue != "undefinied")
	        {
	            // If we need to cast to string
	            if(typeof strValue != "string")
	            {
	                strValue = String(strValue);
	            }
    	        
	            // Encode the provided string to be attribute content safe
	            strValue = strValue.replace(/(["><])/gm,function(strMatch){
	                switch(strMatch) {
                        case "\"": return "&quot;"; 
                        case ">": return "&gt;"; 
                        case "<": return "&lt"; 
                    }
                    return strMatch;
	            });
	        }
    	    
	        // Return the attribute content value
	        return strValue;
	    },
	    /// </method>
    	
	    /// <method name="_isEventAttribute">
        /// <summary>
        /// Indicates if the attribute name is an event
        /// </summary>
        _isEventAttribute : function(strName) {

            if(typeof strName == "string")
            {
                if(strName.charAt(0)=="o" && strName.charAt(1)=="n")
                {
                    return  true;    
                }
            }
            return false;
        },
        /// </method>
        
        /// <method name="flush">
        /// <summary>
        /// Flushes the content of the writer
        /// </summary>
        flush : function(strContent){
            return this.mobjBuffer.join('');
        }
        /// </method>

    };
    /// </object>


    // The instance of the _JQTTemplates
    $._jqttemplates = new _JQTTemplates();

    /// <method name="$.jqtcompiletemplates">
    /// <summary>
    /// Compiles the template selectors for a given document (enhanced performance)
    /// </summary>
    $.jqtcompiletemplates = function(objDocument) {
        $._jqttemplates.compileTemplates(objDocument);
    }
    /// </method>


    /// <method name="$.jqtregtemplatevar">
    /// <summary>
    /// Registers a global variable
    /// </summary>
    $.jqtregtemplatevar = function(strName, strValue) {
        $._jqttemplates.setGlobalVariable(strName, strValue);
    };
    /// </method>


    /// <method name="$.jqtregtemplate">
    /// <summary>
    /// Registers a template for a given hash
    /// </summary>
    $.jqtregtemplate = function() {
        
        switch(arguments.length)
        {
            case 2:
                return $._jqttemplates.setTemplate(arguments[0], "default" , arguments[1]);
                break;
            case 3:   
                if($.isFunction(arguments[1]))
                {
                    return $._jqttemplates.setTemplate(arguments[0], "default", arguments[1], arguments[2]);
                }
                else
                {
                    return $._jqttemplates.setTemplate(arguments[0], arguments[1], arguments[2]);
                }
                break;
            case 4:
                return $._jqttemplates.setTemplate(arguments[0], arguments[1], arguments[2],arguments[3]);
                break;
        }
    };
    /// </method>

    
    /// <method name="$.jqtapplytemplate">
    /// <summary>
    /// Executes a given template
    /// </summary>
    $.jqtapplytemplate = function(objSubject, strMode, objWriter, objArguments)
    {
        // The apply template results
        var arrResults = [];
        
        var intResult = 0;
        
        // Get the subject list
        var arrSubjects = $._jqttemplates._getTemplateSubjectList(objSubject);
        
        var intLength = arrSubjects.length;
        
        // Loop all template subjects
        for(var intIndex=0; intIndex< intLength; intIndex++)
        {        
            arrResults[intResult++] = $._jqttemplates.callTemplateBySubject(arrSubjects[intIndex], strMode , objWriter, objArguments);
        }
            
        return $._jqttemplates._getTemplateResult(arrResults);
    };
    /// </method>

    /// <method name="$.jqttemplate">
    /// <summary>
    /// Executes a given template
    /// </summary>
    $.jqtcalltemplate = function(strName, objSubject, objWriter, objArguments)
    {
        // The apply template results
        var arrResults = [];
        
        var intResult = 0;
        
        // Get the subject list
        var arrSubjects = $._jqttemplates._getTemplateSubjectList(objSubject);
        
        var intLength = arrSubjects.length;
        
        // Loop all template subjects
        for(var intIndex=0; intIndex< intLength; intIndex++)
        {
            arrResults[intResult++] = $._jqttemplates.callTemplate(strName, null, arrSubjects[intIndex], objWriter, true, objArguments); 
            
        }
            
        return $._jqttemplates._getTemplateResult(arrResults);
    };
    /// </method>

    /// <method name="$.jqtexectemplate">
    /// <summary>
    /// Calls the function and returns the generated content
    /// </summary>
    $.jqtexectemplate = function(objTarget, fncWriter)
    {
        var objWriter = new JQTTemplateWriter();
        fncWriter.call(objTarget, objWriter);
        return objWriter.flush();
    };		
    /// </method>	
    
    
     /// <method name="$.jqtcreatewriter">
    /// <summary>
    /// Creates a jqt writer
    /// </summary>
    $.jqtcreatewriter = function()
    {
        return new JQTTemplateWriter();
    };		
    /// </method>	
    
    
    /// <method name="$.jqtcreatewriter">
    /// <summary>
    /// Creates a jqt writer
    /// </summary>
    $.jqtdebug = function(objAction, strParamA)
    {
        return $._jqttemplates.debug(objAction, strParamA);
    };		
    /// </method>		


})(jQuery);
		


