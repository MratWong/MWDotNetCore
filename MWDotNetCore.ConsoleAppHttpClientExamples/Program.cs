﻿using MWDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();
