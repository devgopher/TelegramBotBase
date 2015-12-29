/*
 * Пользователь: igor.evdokimov
 * Дата: 29.12.2015
 * Время: 11:38
 */
using System;
using TelegramBotBase.BotBase;

namespace TelegramBotBase
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			Console.Write("Test serialization: ");
			
			var user = new TelegramBotBase.BotBase.User();
			user.FirstName = "Andrey";
			user.SecondName = "GG";
			user.Id = 102020;
			
			var chat= new BotBase.Chat();
			chat.Id= 1029;
			chat.Type = "private";

			var msg = new BotBase.Message();
			msg.MessageId = 54349;
			msg.Text = "ggtr";
			msg.Date = Utils.UnixTime(DateTime.Now);
			msg.ToChat = chat;
			
			var request = new BotBase.Request();
			request.Msg = msg;
			
			var user_ser = user.Serialize();			
			var user_deser = User.Get( user_ser );


			var chat_ser = chat.Serialize();			
			var chat_deser = Chat.Get( chat_ser );			
			
	
			
			var msg_ser = msg.Serialize();			
			var msgt_deser = Message.Get( msg_ser ) as Message;		

			var req_ser = request.Serialize();			
			var req_deser = Request.Get( req_ser ) as Request;

			
			Console.WriteLine(msg_ser);
			
			var ref_chat = msgt_deser.ToChat;
			var req_msg = request.Msg;

			Console.ReadKey(true);
		}
	}
}