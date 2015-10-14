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

        /// <summary>
        /// Adds a non-null, non-blank, non-whitespace only query value to the query string dictionary
        /// </summary>
        /// <param name="key">Key of the query string item</param>
        /// <param name="value">Value of the query string item, note that the value will be ToString'ed 
        /// and any special formats should beforehand.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
		public void Add(string key, object value)
		{
			if (value != null && !string.IsNullOrWhiteSpace (value.ToString ()))
				QueryDictionary.Add (key, value);
		}
	}
}

