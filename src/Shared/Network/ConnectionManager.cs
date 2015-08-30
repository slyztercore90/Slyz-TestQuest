﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Melia.Shared.Network
{
	/// <summary>
	/// Accepts connections and sets them up.
	/// </summary>
	/// <typeparam name="TConnection"></typeparam>
	public class ConnectionManager<TConnection> where TConnection : Connection, new()
	{
		private Socket _socket;

		/// <summary>
		/// IP this manager listens on.
		/// </summary>
		public string Host { get; protected set; }

		/// <summary>
		/// Port this manager listens on.
		/// </summary>
		public int Port { get; protected set; }

		/// <summary>
		/// Address this manager listens on.
		/// </summary>
		public string Address { get { return string.Format("{0}:{1}", this.Host, this.Port); } }

		public TConnection[] Connections;

		/// <summary>
		/// Initializes connection manager.
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		private ConnectionManager()
		{
			this.Connections = new TConnection[1024];
		}

		/// <summary>
		/// Creates new connection manager.
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		public ConnectionManager(string host, int port)
			: this()
		{
			this.Host = host;
			this.Port = port;
		}

		/// <summary>
		/// Creates new connection  manager with "Any" as host.
		/// </summary>
		/// <param name="port"></param>
		public ConnectionManager(int port)
			: this("0.0.0.0", port)
		{
		}

		/// <summary>
		/// Starts accepting connections.
		/// </summary>
		public void Start()
		{
			this.ResetSocket();

			var ipAddress = this.Host == "0.0.0.0" ? IPAddress.Any : IPAddress.Parse(this.Host);

			_socket.Bind(new IPEndPoint(ipAddress, this.Port));
			_socket.Listen(10);

			this.BeginAccept();
		}

		/// <summary>
		/// Begins accepting of incoming connections.
		/// </summary>
		private void BeginAccept()
		{
			_socket.BeginAccept(this.OnAccept, null);
		}

		/// <summary>
		/// Shuts down current socket and creates a new one.
		/// </summary>
		private void ResetSocket()
		{
			if (_socket != null)
			{
				try { _socket.Shutdown(SocketShutdown.Both); }
				catch { }
				try { _socket.Close(2); }
				catch { }
			}

			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		/// <summary>
		/// Called when a new client connects.
		/// </summary>
		/// <param name="result"></param>
		private void OnAccept(IAsyncResult result)
		{
			try
			{
				var connectionSocket = _socket.EndAccept(result);

				var connection = new TConnection();
				this.AssignId(connection);
				connection.SessionId = 2;
				connection.SetSocket(connectionSocket);
				connection.Closed += this.OnConnectionClosed;
				connection.BeginReceive();

				Log.Info("Connection established from {0}", connection.Address);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex)
			{
				Log.Exception(ex, "While accepting connection.");
			}
			finally
			{
				this.BeginAccept();
			}
		}

		/// <summary>
		/// Raised when a connection closes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnConnectionClosed(object sender, EventArgs e)
		{
			var conn = sender as TConnection;

			lock (this.Connections)
			{
				this.Connections[conn.Index] = null;
				conn.Index = 0;
			}
		}

		/// <summary>
		/// Assigns an index to conn, that can be used to index Connections.
		/// </summary>
		/// <param name="conn"></param>
		private void AssignId(TConnection conn)
		{
			lock (this.Connections)
			{
				for (int i = 100; i < this.Connections.Length; ++i)
				{
					if (this.Connections[i] == null)
					{
						conn.Index = i;
						this.Connections[i] = conn;
						return;
					}
				}
			}

			throw new Exception("No index available in connection list.");
		}
	}
}
