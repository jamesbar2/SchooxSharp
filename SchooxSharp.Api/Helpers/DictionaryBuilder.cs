using System;
using System.Collections.Generic;

namespace SchooxSharp.Api.Helpers
{
	public class DictionaryQueryBuilder
	{
		/// <summary>
		/// Contains all the queries supplied by the helper.
		/// </summary>
		/// <value>The query dictionary.</value>
		public Dictionary<string, object> QueryDictionary { get; set;}
		
		public DictionaryQueryBuilder ()
		{
			QueryDictionary = new Dictionary<string, object> ();
		}

		public void Add(string key, object? value)
		{
			if(value.HasValue && value != null && !string.IsNullOrWhiteSpace(value.ToString()))
				QueryDictionary.Add(key, value.Value);
		}

		public void Add(string key, object value)
		{
			if (value != null && !string.IsNullOrWhiteSpace (value.ToString ()))
				QueryDictionary.Add (key, value);
		}
	}
}

