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
        Dim ipep = New IPEndPoint(IPAddress.Any, port)
        Dim b(1024) As Byte

        s.Bind(ipep)
        s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, New MulticastOption(ip, IPAddress.Any))

        While True

            Console.WriteLine("Press any key to listen for a message.")
            Console.ReadKey()

            s.Receive(b)
            Dim str = Encoding.ASCII.GetString(b, 0, b.Length)
            Console.WriteLine(str.Trim())

        End While

    End Sub
End Module
