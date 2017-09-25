using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Util;
using System;
using System.Diagnostics;
using Sfs2X.Exceptions;
using Sfs2X.Requests;

namespace Framework.Generality.Bases.Network
{
    public class Connection
    {
        private SmartFox _sfs;
        private ConfigData _config;

        private string HOST;
        private int PORT;
        private string ZONE;

        public Connection()
        {
            _sfs = new SmartFox();
            _config = new ConfigData();

            HOST = "127.0.0.1";
            PORT = 9933;
            ZONE = "BasicExamples";
        }

        public void Init()
        {
            _sfs.ThreadSafeMode = true;
            // setup congfig
            _config.Host = HOST;
            _config.Port = PORT;
            _config.Zone = ZONE;
            _config.Debug = true;

            // add listener
            AddListener();
        }
        public void Update()
        {
            if (_sfs != null)
                _sfs.ProcessEvents();
        }

        // send request
        public void SendConnectRequest(string zoneName = "BasicExamples")
        {
            try
            {
                ZONE = zoneName;
                _config.Zone = ZONE;
                _sfs.Connect(_config);
            }
            catch(Exception exp)
            {
                Debug.WriteLine("config error: " + exp.Message);
            }
        }
        public void SendLoginRequest(string userName,string zoneName = "BasicExamples")
        {
            _sfs.Send(new LoginRequest(userName,"",zoneName));
        }
        private void AddListener()
        {
            _sfs.AddEventListener(SFSEvent.CONNECTION, OnConnection);
            _sfs.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
            _sfs.AddEventListener(SFSEvent.LOGIN, OnLogin);
            _sfs.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
            _sfs.AddEventListener(SFSEvent.ROOM_JOIN, OnJoinRoom);
            _sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR, OnJoinRoomError);
            _sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE, OnExtensionReponse);
        }

        // hanlde events
        /// <summary>
        /// when a connection between the client and a SmartFoxServer 2X instance is attempted.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api </param>
        private void OnConnection(BaseEvent e)
        {
            bool success = (bool)e.Params["success"];
            if (success) Debug.WriteLine("connected");
            
        }
        /// <summary>
        /// when the connection between the client and the SmartFoxServer 2X instance is interrupted.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api </param>
        private void OnConnectionLost(BaseEvent e)
        {
            
        }
        /// <summary>
        ///  when the current user performs a successful login in a server Zone.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api</param>
        private void OnLogin(BaseEvent e)
        {

        }
        /// <summary>
        ///  if an error occurs while the user login is being performed.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api</param>
        private void OnLoginError(BaseEvent e)
        {

        }
        /// <summary>
        /// when a Room is joined by the current user.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api</param>
        private void OnJoinRoom(BaseEvent e)
        {

        }
        /// <summary>
        ///  when an error occurs while the current user is trying to join a Room.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api</param>
        private void OnJoinRoomError(BaseEvent e)
        {

        }
        /// <summary>
        ///  when data coming from a server-side Extension is received by the current user.
        /// </summary>
        /// <param name="e">Contain all events dispatched by sfs 2x C# api</param>
        private void OnExtensionReponse(BaseEvent e)
        {

        }
    }
}
