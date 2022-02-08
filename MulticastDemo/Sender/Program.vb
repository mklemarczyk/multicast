Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module Program
    Sub Main(args As String())
        Dim ip = IPAddress.Parse("224.5.6.7")
        Dim port = 4567
        Console.WriteLine("Hello World!")

        Dim s = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim ipep = New IPEndPoint(ip, port)

        s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, New MulticastOption(ip))
        s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2)
        s.Connect(ipep)

        Console.Write("Write message to send: ")
        Dim msg = Console.ReadLine()
        Dim str = Encoding.ASCII.GetBytes(msg)
        s.Send(str, str.Length, SocketFlags.None)

        s.Close()

        Console.WriteLine("Press any key to close.")
        Console.ReadKey()

    End Sub
End Module
