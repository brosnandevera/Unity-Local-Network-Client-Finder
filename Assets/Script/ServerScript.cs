using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
public class ServerScript : MonoBehaviour {

    UdpClient sender;
    UdpClient receiver;
    int remotePort = 19784;

    public void StartServer()
    {
       
        Network.incomingPassword = "password";
        Network.InitializeServer(3, 25000, false);


    }
    public void StartServerLocal()
    {
        Debug.Log("MyIP " + Network.player.ipAddress);
        sender = new UdpClient(remotePort, AddressFamily.InterNetwork);

        IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, remotePort);

        sender.Connect(groupEP);
        InvokeRepeating("BroadcastingIP", 0, 0.5f);
    }

    private void BroadcastingIP()
    {

        string customMessage = "MyGame" + "*" + Network.player.ipAddress;

        sender.Send(Encoding.ASCII.GetBytes(customMessage), customMessage.Length);
        Debug.Log("Broadcasting");
    }

    public void StartListening()
    {
        try
        {
            if (receiver == null)
            {
                receiver = new UdpClient(remotePort);
                receiver.BeginReceive(new AsyncCallback(ReceiveData), null);
            }
        }
        catch (SocketException e)
        {
            Debug.Log(e.Message);
        }
    }

    private void ReceiveData(System.IAsyncResult ar)
    {
        IPEndPoint receiveIPGroup = new IPEndPoint(IPAddress.Any, remotePort);
        byte[] received;
        if (receiver != null)
        {
            received = receiver.EndReceive(ar, ref receiveIPGroup);
        }
        else
        {
            return;
        }
        receiver.BeginReceive(new AsyncCallback(ReceiveData), null);
        string message = Encoding.ASCII.GetString(received);
        Debug.Log(message);
    }

    public void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.RegistrationSucceeded)
        {
            Debug.Log("registration success");
        }
        if (msEvent == MasterServerEvent.RegistrationFailedNoServer)
        {
            Debug.Log("No Server");
        }
        if (msEvent == MasterServerEvent.RegistrationFailedGameName)
        {
            Debug.Log("Failed Game Name");
        }
        if (msEvent == MasterServerEvent.RegistrationFailedGameType)
        {
            Debug.Log("Failed Game Type");
        }
        if (msEvent == MasterServerEvent.HostListReceived)
        {
            Debug.Log("Host List Received");
        }
    }

    
    void OnServerInitialized()
    {
        Debug.Log("server initialized");
        MasterServer.RegisterHost("TestNetwork", "game", "comments here!");

    }
}
