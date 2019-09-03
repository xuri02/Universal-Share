﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universal_Share.ProgMain;

namespace Universal_Share.Net {
    public class ServerBase : NetBase {
        public void SteamServer(TcpClient cl) {
            Console.WriteLine( "Server Started" );
            var errorCode = SocketError.NotConnected;

            var readBytes = -1;
            var buffer    = new byte[buffer_size];

            var blockCtr       = 0;
            var totalReadBytes = 0;

            while ( readBytes != 0 ) {
                readBytes = cl.Client.Receive( buffer, 0, buffer_size, SocketFlags.None, out errorCode );
                if ( readBytes <= 0 ) break;
                ( var message, var idRet ) = this.GlobalReversesProgresses( readBytes, buffer );

                var option = message == SUCCESS ? Net.Option.SUCCESS : Net.Option.ERROR;

                cl.Client.Send( Parts_To_Buffer( ßMainPoint.T, Encoding.UTF8.GetBytes( idRet.ToString() ), option, Encoding.UTF8.GetBytes( message ) ) );

                blockCtr++;
                totalReadBytes += readBytes;
            }
        }
    }
}