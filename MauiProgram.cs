﻿using Microsoft.Extensions.Logging;

using DbMyDemo.DataTransactions;
namespace DbMyDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "Student.cs");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DBTrans>(s, _dbPath));

            return builder.Build();
        }
    }
}
