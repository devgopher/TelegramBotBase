/*
 * Пользователь: igor.evdokimov
 * Дата: 29.12.2015
 * Время: 11:40
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Logger;

namespace TelegramBotBase.BotBase
{

	/// <summary>
	/// User {first_name = "", id = "..."}
	/// </summary>
	public class User {
		public Dictionary<String, Object> Content = new Dictionary<String, Object>();
	}
	
	/// <summary>
	/// Chat {id = "", type = "..."}
	/// </summary>
	public class Chat {
		public Dictionary<String, Object> Content = new Dictionary<String, Object>();
	}
	
	/// <summary>
	/// Message {message_id = "", date = ..., text = "...", chat = "..."}
	/// </summary>
	public class Message {
		public Dictionary<String, Object> Content = new Dictionary<String, Object>();
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
			api_url += token+"/";
		}
		
		protected void SendResponse( User user, Message message ) {
			//var response_stream = bot_client.GetStream();
			bot_client.Send(  );
			
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
