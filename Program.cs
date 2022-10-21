using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

var kvUrl = builder.Configuration["KeyVaultConfig:KVUrl"];
var tenantId = builder.Configuration["KeyVaultConfig:TenantId"];
var clientId = builder.Configuration["KeyVaultConfig:ClientId"];
var clientSecret = builder.Configuration["KeyVaultConfig:ClientSecretId"];

var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
var client = new SecretClient(new Uri(kvUrl), credential);

builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

Console.WriteLine(builder.Configuration["businessGmail"]);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
