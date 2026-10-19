# Youssef Auth - Official C# (.NET) SDK & Example

<p align="center">
  <img src="https://youssefauth.wuaze.com/Youssef%20Auth.ico" width="80" alt="Youssef Auth Logo" />
  <br>
  <b>Next-Gen Software Licensing, HWID Locking & Authentication for .NET</b>
  <br>
  <a href="https://youssefauth.wuaze.com">Website</a> â€¢
  <a href="https://github.com/x97xff">GitHub Profile</a>
</p>

---

## âš¡ Features
- ðŸš€ **Full .NET Support**: Compatible with .NET Framework, .NET 6, .NET 7, .NET 8, and C# WinForms / WPF.
- ðŸ›¡ï¸ **HWID Locking**: Automatic Windows Machine GUID & SID detection.
- ðŸ”‘ **License Management**: Days-based, lifetime, and tiered subscriptions.
- ðŸŒ **Connected directly to your Youssef Auth Server**: `https://youssefauth.wuaze.com/api/1.2/`.

## ðŸš€ Quick Start

1. **Clone this repository**:
```bash
git clone https://github.com/x97xff/YoussefAuth-CS-Example.git
cd YoussefAuth-CS-Example
```

2. **Configure your credentials in `Program.cs`**:
```csharp
public static YoussefAuth.api Auth = new YoussefAuth.api(
    name: "YourAppName",
    ownerid: "YourOwnerId",
    secret: "YourAppSecret",
    version: "1.0"
);
```

3. **Build and Run**:
```bash
dotnet run
```

---
*Created by [x97xff](https://github.com/x97xff) with Youssef Auth.*