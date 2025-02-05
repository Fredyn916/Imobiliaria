﻿using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DataBase.CloudinaryConfig;

public static class Startup
{
    public static void ConfigureServices(IConfiguration config, IServiceCollection services)
    {
        Account account = new Account("fredmarques", "386874283649321", "Fxyo7ol8SJSEYFDwc0wbtPWOLc0");

        var cloudinary = new Cloudinary(account);

        services.AddSingleton(cloudinary);
    }
}