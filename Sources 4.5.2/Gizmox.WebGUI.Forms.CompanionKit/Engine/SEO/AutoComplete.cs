using System;
using System.Xml;
using System.Web;
using System.Text;
using System.Collections.Generic;

using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.SEO
{
	public class AutoComplete : HostHttpHandler
	{
		// words from both published and drafted items to ensure uniqueness
		private static Dictionary<string,string>	mobjCommon		= new Dictionary<string,string>();

		// words for published SEOItem(s)
		private static Dictionary<string,string>	mobjCollected	= new Dictionary<string,string>();
		private static string[]						mobjOrdered		= null;

		// words for draft SEOItem(s)
		private static Dictionary<string,string>	mobjCollectedDraft	= new Dictionary<string,string>();
		private static string[]						mobjOrderedDraft	= null;

		private static object						mobjLock		= new object();
		
		// array of symbols non-allowed in a keyword
		private static char[]						marrSplits		= 
			new char[]{'\'',',',':','.',' ','~','!','@','#','$',';','|','%','^','&','*','(',')','[',']','<','>','/','\\','\r','\n','…'};
		
		#region HostHttpHandler Members

		/// <summary>
		/// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
		/// </returns>
		public override bool IsReusable
		{
			get { return true; }
		}

		/// <summary>
		/// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references 
		/// to the intrinsic server objects (for example, Request, Response, Session, and Server) used to 
		/// service HTTP requests.</param>
		public override void ProcessRequest(HostContext objContext)
		{
			// Template:
			//	{
			//	 query:'Li',
			//	 suggestions:['Liberia','Libyan Arab Jamahiriya','Liechtenstein','Lithuania'],
			//	 data:['LR','LY','LI','LT']
			//	}
			string strJSON ="{{query:'{0}', suggestions:[{1}], data:{2} }}";

			// What about quoting of ',",[,]
			objContext.Response.ContentType = "text/plain";
			objContext.Response.ContentEncoding = Encoding.UTF8;

			// Get query string
			string strQuery = objContext.Request["query"];

			// Get the flag indicating we are in Admin mode and should suggest keywords for Published and Draft items
			string strAdmin = objContext.Request["admin"];
			bool blnAdmin = strAdmin == null ? false : strAdmin.ToLower() == "true";

			// -= Get suggestions by query and mode =-
			string[][] arrResults = GetSuggestions(strQuery, blnAdmin);

			// Prepare suggestions as JSON array
			StringBuilder objSuggestions = new StringBuilder();
			foreach (string[] results in arrResults)
				foreach (string result in results)
					objSuggestions.AppendFormat("'{0}',", result);

			// Format resulting JSON object
			string strJSONResult = string.Format(strJSON, 
				objContext.Request["query"], //query
				objSuggestions.ToString().TrimEnd(new char[]{','}),  // suggestions
				"[]"); // data

			objContext.Response.Write(strJSONResult);
			objContext.Response.End();
		}

		#endregion

		/// <summary>
		/// Get suggestions according to query string parameter.
		/// </summary>
		public static string[][] GetSuggestions(string strQuery, bool blnAdmin)
		{
			StringComparison enmOption = StringComparison.InvariantCultureIgnoreCase;

			if (mobjOrdered == null)
				lock (mobjLock)
				{
					if (mobjOrdered == null)
						Collect();
				}

			strQuery = strQuery == null ? "" : strQuery;
			

			string[][] objSuggestions = {new string[]{},new string[]{}};
			if (strQuery.Length > 0)
			{
				objSuggestions[0] = Array.FindAll<string>(mobjOrdered, delegate(string check)
				{
					return check.IndexOf(strQuery, enmOption) > -1;
				});

				if (blnAdmin)
				{
					objSuggestions[1] = Array.FindAll<string>(mobjOrderedDraft, delegate(string check)
					{
						return check.IndexOf(strQuery, enmOption) > -1;
					});
				}
			}

			return objSuggestions;
		}

		/// <summary>
		/// Collect index information from the Root incuding all internal folders/items.
		/// </summary>
		public static void Collect()
		{
			lock (mobjLock)
			{
				CollectKeywords(SEOSite.Root);

				mobjOrdered			= new string[mobjCollected.Values.Count];
				mobjOrderedDraft	= new string[mobjCollectedDraft.Values.Count];
				
				mobjCollected.Values.CopyTo(mobjOrdered, 0);
				mobjCollectedDraft.Values.CopyTo(mobjOrderedDraft, 0);

				Array.Sort(mobjOrdered);
				Array.Sort(mobjOrderedDraft);

				// not needed anymore
				mobjCollected.Clear();
				mobjCollectedDraft.Clear();
				mobjCommon.Clear();
			}
			return;
		}

		/// <summary>
		/// Collect keywords for the folder and all internal folders/items.
		/// </summary>
		/// <param name="folder">The folder.</param>
		/// <param name="results">The results.</param>
		private static void CollectKeywords(SEOFolder folder)
		{
			Collect(folder);
		    
			foreach (SEOFolder subfolder in folder.Folders)
		    {
		        CollectKeywords(subfolder);
		    }

			foreach (SEOItem item in folder.PlainItems)
			{
				Collect(item);
			}

			return;
		}

		/// <summary>
		/// Collect keywords from the Item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="results">The results.</param>
		private static void Collect(SEOItem item)
		{
			Dictionary<string, string> results = 
				item.Status == SEOItemStatus.Publish? mobjCollected : mobjCollectedDraft;

			AddWords(item.Keywords, results);
			AddWords(item.Description.Split(marrSplits), results);
			AddWords(item.Title.Split(marrSplits), results);
			AddWords(item.DisplayName.Split(marrSplits), results);
		}

		private static void AddWords(string[] arrWords, Dictionary<string, string> results)
		{
			for (int iCnt = 0; iCnt < arrWords.Length; iCnt++)
			{
				string word = arrWords[iCnt];
				if (!String.IsNullOrEmpty(word))
				{
					word = CleanUp(word);
					bool blnAdd = word.Length > 3;
					string wordLower = word.ToLower();
					
					if (blnAdd && !mobjCommon.ContainsKey(wordLower))
					{
						blnAdd = PlularCheck(word, "s", "ses") && 
									PlularCheck(word, "", "s") &&
									PlularCheck(word, "x", "xes") && 
									// don't change properties <-> property, it's different searches
									// PlularCheck(word, "y", "ies") &&
									PlularCheck(word, "o", "oes");

						if (blnAdd)
						{
							//This method approaches an O(1) operation
							results[wordLower] = word;
							mobjCommon[wordLower] = word;
						}
					}
				}
			}
		}

		/// <summary>
		/// Checks where the word already added to dictionaries,
		/// if word added in plural form, will be replaced in singular form.
		/// 
		/// 	word		: class - classes, box - boxes
		/// 	strPlural	: ses, xes, ies, oes
		/// 	strSingle	: s  , x,   y,   o
		/// </summary>
		/// <example>
		///  Ad -es to singular nouns ending in: s, ss, ch, sh, x and most words ending in o.             
		///  watch - watches
		///  dish - dishes                                                                            
		///  potato - potatoes
		///  tomato - tomatoes
		///  bus - buses                                                                                  
		///  dress - dresses                                                                              
		///  box - boxes                                                                                  
		///  fox - foxes                                                                                  
		///  go - goes                                                                                    
		///  Bench - benches
		///  http://wiki.answers.com/Q/What_are_some_plural_words_ending_with_'es'
		///  It should be mentioned here that singular nouns ending in y change to i plus es in the plural
		///  cry - cries                                                                                  
		///  fry - fries                                                                                  
		///  try - tries                                                                           
		/// </example>
		private static bool PlularCheck(string word, string strSingle, string strPlural)
		{
			string wordLower = word.ToLower();
			bool blnAdd = true;

			// continue if non contains singular
			if (wordLower.EndsWith(strPlural))
			{
				blnAdd = !mobjCommon.ContainsKey(
					wordLower.Substring(0, wordLower.Length - strPlural.Length) + strSingle );
			}
			else if (wordLower.EndsWith(strSingle))
			{
				// add the word if doesn't contain plural
				string strWordPlural = wordLower.Substring(0, wordLower.Length - strSingle.Length) + strPlural;
				
				if (mobjCommon.ContainsKey(strWordPlural))
				{
					blnAdd = false;
					
					mobjCommon.Remove(strWordPlural);
					mobjCommon[wordLower] = word;
					
					// replace plural with singular
					if (mobjCollected.ContainsKey(strWordPlural))
					{
						mobjCollected.Remove(strWordPlural);
						mobjCollected[wordLower] = word;
					}
					else if (mobjCollectedDraft.ContainsKey(strWordPlural))
					{
						mobjCollectedDraft.Remove(strWordPlural);
						mobjCollectedDraft[wordLower] = word;
					}
				}
			}

			return blnAdd;
		}

		/// <summary>
		/// Removes all non-character symbols from the word
		/// </summary>
		private static string CleanUp(string word)
		{
			do{
				int index = word.IndexOfAny(marrSplits);
				if (index > -1)
					word = word.Remove(index, 1);
				else
				{
					word = word.Replace(Environment.NewLine, "");
					break;
				}
			}while(true);
			return word;
		}

	}
}
