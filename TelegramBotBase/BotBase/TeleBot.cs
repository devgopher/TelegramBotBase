/*
 * Пользователь: igor.evdokimov
 * Дата: 29.12.2015
 * Время: 11:40
 */
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using Logger;

namespace TelegramBotBase.BotBase
{
	public class JsonObjects {
		public Dictionary<String, Object> Content = new Dictionary<String, Object>();
		public String Serialize(  ) {
			return JsonConvert.SerializeObject( Content, new KeyValuePairConverter() );
		}
		
		static protected T Get<T>( string json_string  ) where  T : new() {
			T nw_obj = new T();
			
			(nw_obj as JsonObjects ).Content =
				JsonConvert.DeserializeObject<Dictionary<string,object>>(json_string);
			
			return nw_obj;
		}
		
		protected void SetValue( string inner_key, object inner_val ) {
			Content[inner_key] = inner_val;
		}
	}
	
	/// <summary>
	/// User {first_name = "", id = "..."}
	/// </summary>
	public class User : JsonObjects {
		public static User Get( string json_string ) {
			return JsonObjects.Get<User>(json_string);
		}
		
		public string FirstName {
			get {
				return ((String)Content["first_name"]);
			} set {
				SetValue( "first_name", value.ToString());
			}
		}
		
		public string SecondName {
			get {
				return ((String)Content["second_name"] );
			} set {
				SetValue( "second_name", value.ToString());
			}
		}
		
		public int Id {
			get {
				return ((int)Content["id"] );
			} set {
				SetValue( "id", value);
			}
		}
	}
	
	
	/// <summary>
	/// Request {message = ""}
	/// </summary>
	public class Request : JsonObjects {
		public static Request Get( string json_string ) {			
			var ret = JsonObjects.Get<Request>(json_string);
			
			var msg = JsonConvert.DeserializeObject<Message>( ret.Content["message"].ToString() );
			
			if ( msg != null ) {
				var cht = JsonConvert.DeserializeObject<Chat>( msg.Content["chat"].ToString() );
				msg.ToChat = cht;
			}
			
			return ret;
		}
		
		public Message Msg {
			get {
				return ((Message)Content["message"]);
			} set {
				SetValue( "message", value);
			}
		}
	}
	
	/// <summary>
	/// Chat {id = "", type = "..."}
	/// </summary>
	public class Chat : JsonObjects{
		public static Chat Get( string json_string ) {
			return JsonObjects.Get<Chat>(json_string);
		}
		
		public int Id {
			get {
				return ((int)Content["id"] );
			} set {
				SetValue( "id", value);
			}
		}
		
		public string Type {
			get {
				return ((String)Content["type"] );
			} set {
				SetValue( "type", value.ToString());
			}
		}
	}
	
	/// <summary>
	/// Message {message_id = "", date = ..., text = "...", chat = "..."}
	/// </summary>
	public class Message : JsonObjects {
		public static Message Get( string json_string ) {
			var ret = JsonObjects.Get<Message>(json_string);
			var cht = JsonConvert.DeserializeObject<Chat>( ret.Content["chat"].ToString() );
			ret.ToChat = cht;
			return ret;
		}
		
		public int MessageId {
			get {
				return ((int)Content["message_id"] );
			} set {
				SetValue( "message_id", value);
			}
		}
		
		public int Date {
			get {
				return ((int)Content["date"] );
			} set {
				SetValue( "date", value);
			}
		}
		
		public string Text {
			get {
				return ((String)Content["text"] );
			} set {
				SetValue( "text", value.ToString());
			}
		}
		
		[JsonIgnore]
		public Chat ToChat  {
			get {
				return ((Chat)Content["chat"] );
			} set {
				SetValue( "chat", value );
			}
		}
	}
	
	/// <summary>
	/// Description of TeleBot.
	/// https://core.telegram.org/bots/api
	/// </summary>
	public class TeleBot
	{
		private String token = String.Empty;
		private BotClient bot_client = null;
		private String api_url = "https://api.telegram.org/bot";
		
		#region BotUser
		private String bot_user_id = String.Empty;
		private int bot_id;
		private string first_name = String.Empty;
		private string last_name = String.Empty;
		#endregion
		
		private Logger.Logger logger = new Logger.Logger( "log.txt", "TeleBot", System.Text.Encoding.Default );
		
		
		public TeleBot( String _token )
		{
			token = _token;
			api_url += token+"/getMe";
		}
		
		protected void SendResponse( User user, Message message ) {
			//var response_stream = bot_client.GetStream();
			//	bot_client.Send( );
			
		}
		
		public void HelpMessage() {
			logger.WriteEntry( "/help command entered" );
			if ( !bot_client.Connected ) {
				logger.WriteError( "Bot isn't connected!" );
				return;
			}
			// TODO:
		}

		public void StartMessage() {
			logger.WriteEntry( "/start command entered" );
			if ( !bot_client.Connected ) {
				logger.WriteError( "Bot isn't connected!" );
				return;
			}
			// TODO:
		}
		
		public void StartService() {
			if ( bot_client == null )
				return;
			
			bot_client.Connect( api_url, 80 );
		}
	}
}
