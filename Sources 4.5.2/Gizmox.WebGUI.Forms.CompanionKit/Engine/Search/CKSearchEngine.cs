using System;
using System.Text;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Forms.KB.Engine.Data;
using Gizmox.WebGUI.Forms.KB.Engine.Search;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;

using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;
using System.Collections;
using System.IO;


namespace Gizmox.WebGUI.Forms.CompanionKit.Engine.Search
{
	public class CKSearchEngine: IRSearchEngine
	{
		protected bool		mblnSetAllowLeadingWildcard = true;

		public CKSearchEngine() : base(Path.Combine(SEOSite.Root.DataPath, "KB"))
		{
			menmEngineType = SearchEngineType.CK;
		}

		/// <summary>
		/// Setting to allow leading wildcard ? and * symbols in query terms.
		/// The reason to this that by default is false and ParseException thrown by QueryParser.
		/// The reason for that that in early version such queries were extremely slow on large
		/// indexes. In case of CK it's not closer to be a large ever medium.
		/// </summary>		
		public bool SetAllowLeadingWildcard
		{
			get { return mblnSetAllowLeadingWildcard; }
			set { mblnSetAllowLeadingWildcard = value; }
		}

		public override IEnumerable<IREntity> GetEntities()
		{
			return GetEntities(SEOSite.Root);
		}

		protected IEnumerable<IREntity> GetEntities(SEOFolder objRoot)
		{
			// Don't include index of folder items to avoid filtering result further more relevant searches
			// Only folder with Lobby will be included to inlcude texts of lobby elements
			if (objRoot.HasLobby && !objRoot.HasDefaultPage)
			{
				yield return new CKEntity(objRoot);
			}
			
			foreach (SEOItem objItem in objRoot.PlainItems)
				yield return new CKEntity(objItem);

			foreach (SEOFolder objSubFolder in objRoot.Folders)
				foreach (CKEntity objItem in GetEntities(objSubFolder))
					yield return objItem;
		}
		
		/// <summary>
		/// Adapt search results to expected format
		/// </summary>
		public SEOSearchItems SearchItems(string strWildcard, int intMaxResults)
		{
			SearchQuery		objQuery = new SearchQuery();
			SEOSearchItems	objFounds = new SEOSearchItems();
			IEnumerable		objResults = null;
			
			// Init the query with seached text
			objQuery.QueryText = strWildcard;

			try
			{
				// Search for results
				objResults = Search(objQuery);

				foreach (CKEntity objEntity in objResults)
				{
					objFounds.Add(new SEOSearchItem(objEntity.Item));
					// Leave the iteration - once achieved the maximum
					if(--intMaxResults == 0)
						break;
				}
			}
			catch(Exception objEx)
			{
				// It could be:
				// ParseException - for invlid queries
				// IOException - if IR directory not available 
				// System.Diagnostics.Debug.Assert(false, String.Concat("Check exception details: ", objEx.Message));
			}

			return objFounds;
		}

		public override System.Collections.IEnumerable Search(SearchQuery objQuery)
		{
			List<IREntity> results = new List<IREntity>();
			bool			create		= false;
			FSDirectory		irDir		= GetIRDirectory(out create);
			IndexSearcher	isearcher	= new IndexSearcher(irDir, true); // read-only=true

			// To exclude same item to be reported twice
			// it's possible for content/article(resource) entities
			Dictionary<string, CKEntity> entities = new Dictionary<string,CKEntity>();
			
			// Default field - content
			QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, "content", mobjAnalyser);
			parser.SetAllowLeadingWildcard(this.SetAllowLeadingWildcard);
			
			// Extarct query details from the raw text
			Query query = parser.Parse(objQuery.QueryText);

			// Search the query
			TopDocs objTopDocs = isearcher.Search(query, 5000);
			ScoreDoc[] hits = objTopDocs.scoreDocs;

			// Iterate through the results:
			for (int i = 0; i < hits.Length; i++)
			{
				Document	hitDoc		= isearcher.Doc(hits[i].doc);
				string		strFullName	= hitDoc.Get("entity");
				string		strType		= hitDoc.Get("type");

				if (strType == "CONTENT" || strType == "RESARTICLE")
				{
					strFullName = hitDoc.Get("parententity");
				}
				
				SEOItem objItem = SEOSite.GetItemByFullName("item:" + strFullName);

				if (objItem != null && !entities.ContainsKey(strFullName))
				{
					CKEntity entity = new CKEntity(objItem);
					entity.Document = hitDoc;
					entity.ScoreDoc = hits[i];
					results.Add(entity);

					entities[strFullName] = entity;
				}
			}
			
			entities.Clear();
			isearcher.Close();
			irDir.Close();

			return results;
		}
		
		/// <summary>
		/// Deletes the index documents according to "entity" parameter - a key.
		/// </summary>		
		public void DeleteEntity(SEOItem item)
		{
			DeleteEntity(item, null, null);
		}

		/// <summary>
		/// Deletes the index documents according to "entity" parameter - a key.
		/// </summary>
		/// <param name="objItem">The item to process.</param>
		/// <param name="irDir">The Lucene directory object to process.</param>
		/// <param name="writer">The writer to use if irDir not null.</param>
		public void DeleteEntity(SEOItem item, FSDirectory irDir, IndexWriter writer)
		{
			// Delete entity
			// Delete all related entities (i.e. CONTENT/RESOURCE articles)
			string	entity = item.FullName;
			bool	create = false;
			bool	blnOwner = false;

			if (irDir == null)
			{
				blnOwner = true;
				irDir = GetIRDirectory(out create);
				writer = new IndexWriter(irDir, mobjAnalyser, create, IndexWriter.MaxFieldLength.UNLIMITED);
			}

			//default field - content
			QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, "content", mobjAnalyser);
			Query queryEntity = parser.Parse(string.Format("entity:\"{0}\"", entity));
			Query queryChild = parser.Parse(string.Format("parententity:\"{0}\"", entity));

			writer.DeleteDocuments(new Query[]{queryEntity, queryChild});

			if (blnOwner)
			{
				writer.Commit();
				writer.Close();
				irDir.Close();
			}

			return;
		}
		
		/// <summary>
		/// Adds the Item's index information to the lucene directory.
		/// </summary>
		public void AddEntity(SEOItem objItem)
		{
			AddEntity(objItem, null, null);
		}

		/// <summary>
		/// Adds the Item's index information to the lucene directory.
		/// </summary>
		/// <param name="objItem">The obj item.</param>
		/// <param name="irDir">The Lucene directory object to process.</param>
		protected void AddEntity(SEOItem objItem, FSDirectory irDir, IndexWriter writer)
		{
			bool create = false;
			bool blnOwner = false;

			if (irDir == null)
			{
				blnOwner = true;
				irDir = GetIRDirectory(out create);
				writer = new IndexWriter(irDir, mobjAnalyser, create, IndexWriter.MaxFieldLength.UNLIMITED);
			}

			IREntity objEntity  = new CKEntity(objItem);
			List<Document> objDocuments = objEntity.CreateIRDocument();
			foreach (Document doc in objDocuments)
			{
				writer.AddDocument(doc);
			}

			if (blnOwner)
			{
				writer.Commit();
				writer.Close();
				irDir.Close();
			}
		}

		/// <summary>
		/// Replaces the Item's index information to the lucene directory. As one atomic operation.
		/// </summary>
		/// <param name="objItem">The obj item.</param>
		public void ReplaceEntity(SEOItem item)
		{
			string		entity = item.FullName;
			bool		create = false;
			FSDirectory	irDir  = GetIRDirectory(out create);
			IndexWriter writer = new IndexWriter(irDir, mobjAnalyser, create, IndexWriter.MaxFieldLength.UNLIMITED);
			
			DeleteEntity(item, irDir, writer);
			AddEntity(item, irDir, writer);

			writer.Commit();
			writer.Close();
			irDir.Close();
		}


	}
}
