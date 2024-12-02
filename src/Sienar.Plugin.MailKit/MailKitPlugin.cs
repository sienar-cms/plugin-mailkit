#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sienar.Extensions;
using Sienar.Plugins;

namespace Sienar.Email;

/// <exclude />
public class MailKitPlugin : IWebPlugin
{
	public PluginData PluginData { get; } = new()
	{
		Name = "Sienar MailKit",
		Version = Version.Parse("0.1.0"),
		Author = "Christian LeVesque",
		AuthorUrl = "https://levesque.dev",
		Description = "Sienar MailKit provides access to mail delivery services over SMTP using the MailKit library for .NET.",
		Homepage = "https://sienar.io/plugins/mailkit"
	};

	public void SetupDependencies(WebApplicationBuilder builder)
	{
		builder.Services
			.AddScoped<IEmailSender, MailKitSender>()
			.AddScoped<ISmtpClient, SmtpClient>()
			.ApplyDefaultConfiguration<SmtpOptions>(
				builder.Configuration.GetSection("Sienar:Email:Smtp"));
	}
}