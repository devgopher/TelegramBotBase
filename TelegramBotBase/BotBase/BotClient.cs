/*
 * Пользователь: igor.evdokimov
 * Дата: 29.12.2015
 * Время: 11:46
 */
using System;
using System.Net;
using System.Net.Sockets;
using Logger;

namespace TelegramBotBase.BotBase
{
	
	/// <summary>
	/// Description of BotListener.
	/// </summary>
	public class BotClient : TcpClient
	{
		public delegate void ReceivedMessage( byte[] received );
		public delegate void SentMessage( byte[] sent );
		
		public event ReceivedMessage Received;
		public event ReceivedMessage Sent;
		private Logger.Logger logger;
		
		public BotClient( Logger.Logger _logger ) : base()
		{
			logger = _logger;
		}
		
		public BotClient(IPEndPoint local_ep, Logger.Logger _logger) : base(local_ep)
		{
			logger = _logger;
		}
		
		public BotClient(String host_name, int port, Logger.Logger _logger) : base(host_name, port)
		{
			logger = _logger;
		}
		
		public BotClient(AddressFamily address_family, Logger.Logger _logger) : base(address_family)
		{
			logger = _logger;
		}
		
		public int Receive(  byte[] buffer ) {
			int ret = base.Client.Receive(buffer);
			if ( ret > 0 )
				if ( Received != null )
					Received( buffer );
			return ret;
		}
		
		public int Send(  byte[] buffer ) {
			int ret = base.Client.Send( buffer );
			if ( ret > 0 )
				if ( Sent != null )
					Sent( buffer );
			return ret;
		}		
	}
}
