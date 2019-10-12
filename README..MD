Serilog

Serilog is a diagnostic logging library for .NET applications. It is easy to set up, has a clean API, and runs on all recent .NET platforms. While it's useful even in the simplest applications, Serilog's support for structured logging shines when instrumenting complex, distributed, and asynchronous applications and systems.

Package Dependencies:-
Serilog.AspNetCore
Serilog.Extensions.Logging

Add below package for configuration file based settings
Serilog.Settings.Configuration

Add below package for asynchronous logging
Serilog.Sinks.Async

Add below package for file based logging
Serilog.Sinks.File

Add below package for console logging
Serilog.Sinks.Console

Add below package for logging in database
Serilog.Sinks.MSSqlServer

Changes in Program.cs
.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)

Changes in appsettings.json 
Update Logging to Serilog

In this demo, I have used Configuration based settings for serilog.
1. File based configuration
2. Include From Log Context, Machine Name & Thread Id in the log.
3. Max file size 11 KB
4. Generate rolling log files.
"Serilog": {
    "Using": [ "Serilog.Sinks.File" ],
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": "Errors/log-.txt",
          "fileSizeLimitBytes": "10000",
          "retainedFileCountLimit": 7,
          "rollOnFileSizeLimit": true,
          "rollingInterval": "Day",
          "buffered": true
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithMachineName", "WithThreadId" ],
    "Destructure": [
      {
        "Name": "ToMaximumDepth",
        "Args": { "maximumDestructuringDepth": 4 }
      },
      {
        "Name": "ToMaximumStringLength",
        "Args": { "maximumStringLength": 100 }
      },
      {
        "Name": "ToMaximumCollectionCount",
        "Args": { "maximumCollectionCount": 10 }
      }
    ],
    "Properties": {
      "Application": "SerilogInNetCore"
    }
  }

This will create log files with names like.. log-20191011.txt, log-20191011_001.txt, log-20191011_002.txt ... and so on.

Write to console:-
"Serilog": {
    "Using": [ "Serilog.Sinks.Console" ],
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "Console"
      }
    ],
    "Enrich": [ "FromLogContext", "WithMachineName", "WithThreadId" ],
    "Destructure": [
      {
        "Name": "ToMaximumDepth",
        "Args": { "maximumDestructuringDepth": 4 }
      },
      {
        "Name": "ToMaximumStringLength",
        "Args": { "maximumStringLength": 100 }
      },
      {
        "Name": "ToMaximumCollectionCount",
        "Args": { "maximumCollectionCount": 10 }
      }
    ],
    "Properties": {
      "Application": "SerilogInNetCore"
    }
  }
 