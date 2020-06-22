﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Grepl.Tests
{
	public class TestBase
	{
		private Lazy<string> _slnDir = new Lazy<string>(() =>
		{
			var slnDir = typeof(Grep).Assembly.Location;
			while (slnDir.Length > 0)
			{
				slnDir = Path.GetDirectoryName(slnDir);
				if (Directory.GetFiles(slnDir, "*.sln").Length > 0)
				{
					return slnDir;
				}
			}

			throw new Exception("SLN DIR not found");
		});

		public (int Code, string Output, string Error) Grepl(params string[] args)
		{
			var slnDir = _slnDir.Value;
			var psi = new ProcessStartInfo("dotnet", $"run --project {Path.Combine(slnDir, "Grepl\\Grepl.csproj")} -- {string.Join(" ", args)}")
			{
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
			};
			Console.WriteLine($"{psi.FileName} {psi.Arguments}");
			var p = Process.Start(psi);
			// p.BeginOutputReadLine();
			// p.BeginErrorReadLine();
			// var output = "";
			// var error = "";
			// p.OutputDataReceived += (s, e) => output += e.Data;
			// p.ErrorDataReceived += (s, e) => error += e.Data;
			p.WaitForExit();
			var output = p.StandardOutput.ReadToEnd();
			var error = p.StandardError.ReadToEnd();

			Console.WriteLine($"ExitCode: {p.ExitCode}\r\nOUTPUT: {output}\r\nERROR: {error}");
			return (p.ExitCode, output, error);
		}
	}
}