/*
 * Пользователь: igor.evdokimov
 * Дата: 29.12.2015
 * Время: 12:58
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace TelegramBotBase
{
	/// <summary>
	/// Description of Utils.
	/// </summary>
	public class Utils
	{
		public Utils()
		{
		}
		public static string DictionaryToJson(Dictionary<String, String> dict)
		{
			var entries = dict.Select(d =>
			                          string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));
			return "{" + string.Join(",", entries) + "}";
		}
		
		public static string DictionaryToJson(Dictionary<String, int> dict)
		{
			var entries = dict.Select(d =>
			                          string.Format("\"{0}\": {1}", d.Key, string.Join(",", d.Value)));
			return "{" + string.Join(",", entries) + "}";
		}
		
		public static string DictionaryToJson(Dictionary<String, Object> dict)
		{
			var output = String.Empty;
			foreach ( var kvp in dict ) {
				if ( kvp.Key is int ) {
					output += String.Format("\"{0}\":{1}", kvp.Key, kvp.Value.ToString());
				} else if ( kvp.Key is String ) {
					output += String.Format("\"{0}\":\"{1}\"", kvp.Key, kvp.Value );					
				}
			}
			return "{" + output + "}";
		}
	}
}
