using System;
using System.Text;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Forms.KB.Engine.Search;

using Lucene.Net.Documents;
using Gizmox.WebGUI.Forms.KB.Engine.Data;

namespace Gizmox.WebGUI.Forms.CompanionKit.Engine.Search
{
	public class CKEntity : IREntity
	{
		protected SEOItem mobjItem = null;
		
		public SEOItem Item
		{
			get { return mobjItem; }
			set { mobjItem = value; }
		}

		public CKEntity(SEOItem Item)
		{
			this.Item = Item;
		}

		public override List<string> GetFieldsList()
		{
			List<string> fields = new List<string>();
			fields.Add("name");
			fields.Add("title");
			fields.Add("description");
			fields.Add("displayname");
			fields.Add("keyword");

			fields.Add("comment");
			fields.Add("status");
			fields.Add("type");
			fields.Add("entity");
			fields.Add("parententity");
			
			fields.Add("modified");
			fields.Add("haslobby");
			fields.Add("hasdefault");
			fields.Add("hasresources");
			fields.Add("sitemap");
			// Accumulative field to search compatibily with plain search engine
			fields.Add("content");
			
			// Created and Updated fields - [Datetime]
			// reserved: createdon

			return fields;
		}

		public override string GetDefaultField()
		{
			return "content";
		}

		public override List<Document> CreateIRDocument()
		{
			List<Document> docs = new List<Document>();
			Document doc = new Document();

			if (Item != null)
			{
				AddField(doc,"name", Item.Name, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"name", Item.Name, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"title", Item.Title, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"description", Item.Description, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"displayname", Item.DisplayName, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"keyword", string.Join("; ", Item.Keywords), Field.Store.YES, Field.Index.ANALYZED);
				
				AddField(doc,"comment", Item.Comment, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"status", Item.Status.ToString(), Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"type", Item.Type.ToString(), Field.Store.YES, Field.Index.ANALYZED);
				
				AddField(doc,"entity", Item.FullName, Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"parententity", Item.Parent != null ? Item.Parent.FullName : string.Empty, Field.Store.YES, Field.Index.ANALYZED);

				// Created and Updated fields - [Datetime]
				// reserved: createdon
				AddField(doc,"modified", DateTools.DateToString(Item.LastModified,DateTools.Resolution.SECOND), 
										Field.Store.YES, Field.Index.ANALYZED);

				bool blnHasLobby = false, blnHasDefault = false;
				if (Item.Type == SEOItemType.Folder)
				{
					SEOFolder objFolder = Item as SEOFolder;
					if( objFolder != null){
						blnHasDefault = objFolder.HasDefaultPage;
						blnHasLobby = objFolder.HasLobby;
					}
				}
				else if (Item.Type == SEOItemType.Lobby)
				{
					blnHasLobby = true;
					blnHasDefault = false;
				}

				AddField(doc,"haslobby", blnHasLobby.ToString(), Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"hasdefault", blnHasDefault.ToString(), Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"hasresources", ((bool)(Item.Resources.Length >0)).ToString(), 
										Field.Store.YES, Field.Index.ANALYZED);
				AddField(doc,"sitemap", Item.SiteMap.ToString(), Field.Store.YES, Field.Index.ANALYZED);

				StringBuilder objContent = new StringBuilder();
				if(!String.IsNullOrEmpty(Item.Name)) objContent.AppendLine(Item.Name);
				if(!String.IsNullOrEmpty(Item.Title)) objContent.AppendLine(Item.Title);
				if(!String.IsNullOrEmpty(Item.Description)) objContent.AppendLine(Item.Description);
				if(!String.IsNullOrEmpty(Item.DisplayName)) objContent.AppendLine(Item.DisplayName);
				objContent.AppendLine(doc.GetField("keyword").StringValue());

				if ( this.Item.Type == SEOItemType.Lobby || 
						 (blnHasLobby && !blnHasDefault ) )
				{
					// Lobby items and folders with lobby, but without redirect
					SEOLobby objLobby = this.Item as SEOLobby;
					if (objLobby != null)
					{
						foreach (SEOLobby.Section objSection in objLobby.Sections)
						{
							objContent.AppendLine(objSection.Title); // Title
							objContent.AppendLine(objSection.PreText); // Pre-Body-Text
							// section elements
							foreach (SEOPageElement objElement in objLobby.GetSectionElements(objSection.ID))
							{
								objContent.AppendLine(objElement.Title);
								objContent.AppendLine(objElement.Body);
							}
						}
					}
				}

				// Add content to the field, when HTML tags stripped (becuase of lobby elements)
				AddField(doc,"content", StripHTML(objContent.ToString()), Field.Store.YES, Field.Index.ANALYZED);

				docs.Add(doc);
			}

			return docs;
		}
	}
}
