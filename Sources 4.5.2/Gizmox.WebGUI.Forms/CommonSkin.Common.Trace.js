/// <page name="Common.Trace.js">
/// <summary>
/// Trace related.
/// </summary>

var mblnTraceEnabled	= false;
var mobjTraceTime		= null;
var marrTraceBuffer		= []; 
var mintTraceLimit		= 0;
var mstrTraceFunction	= "none";
var mstrTraceClass		= "none";

/// <method name="Trace_Initialize">
/// <summary>
/// Trace initialization
/// </summary>
function Trace_Initialize()
{
	mblnTraceEnabled = Data_GetAttribute("/","Trace","0")=="1";
}
/// </method>

/// <method name="Trace_Time">
/// <summary>
/// Start time count
/// </summary>
/// <param name="strTraceClass">The tracing class.</param>
/// <param name="strTraceFunction">The tracing function.</param>
function Trace_Time(strTraceClass,strTraceFunction)
{
	if(mblnTraceEnabled)
	{
		mobjTraceTime		= new Date();
		mstrTraceFunction	= strTraceFunction;
		mstrTraceClass		= strTraceClass;
	}
}
/// </method>


/// <method name="Trace_Write">
/// <summary>
/// Write a tracing massage
/// </summary>
/// <param name="strMessage">The trace message.</param>
/// <param name="strGuid">The originating control ID.</param>
function Trace_Write(strMessage,strGuid)
{
	// If tracing is enabled
	if(mblnTraceEnabled)
	{
		// The trace diff
		var intTraceDiff = 0;
		
		// Set default control
		if(!strGuid) strGuid=0;
		
		// Current trace time
		var objTrace = new Date();
		
		// Calculate trace diff
		if(mobjTraceTime) intTraceDiff = objTrace - mobjTraceTime;
		
		// Set new trace time
		mobjTraceTime = objTrace;
		
		// if trace time is larger than the trace limit
		if(intTraceDiff>mintTraceLimit)
		{
			// Add tracing record
			marrTraceBuffer.push([strGuid,intTraceDiff,mstrTraceClass+"_"+mstrTraceFunction,strMessage]);
		}
	}
}
/// </method>

/// <method name="Trace_Reset">
/// <summary>
/// Reset the tracing data
/// </summary>
function Trace_Reset()
{
	marrTraceBuffer = [];
	mobjTraceTime = null;
}
/// </method>

/// <method name="Trace_Show">
/// <summary>
/// Alert the trace
/// </summary>
function Trace_Show()
{
	if(mblnTraceEnabled)
	{
		// If there is a trace buffer records
		if(marrTraceBuffer.length>0)
		{
			alert(marrTraceBuffer.join("\n"));
		}
		
		// Reset trace buffer
		Trace_Reset();
	}
}
/// </method>

/// <method name="Trace_Flush">
/// <summary>
/// Flushes the trace to the event queue sending.
/// </summary>
/// <param name="objBody">The event queue xml body to add the tracing attribute to.</param>
function Trace_Flush(objBody)
{
	if(mblnTraceEnabled)
	{
		// If there is a trace buffer records
		if(marrTraceBuffer.length>0)
		{
			// Write the trace attribute
			objBody.setAttribute("Trace",marrTraceBuffer.join("|"));
		}
		
		// Reset trace buffer
		Trace_Reset();
	}
}
/// </method>

/// </page>
