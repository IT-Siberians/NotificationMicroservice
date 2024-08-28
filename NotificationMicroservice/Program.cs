using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Mapper;
using NotificationMicroservice.Application.Services;
using NotificationMicroservice.DataAccess;
using NotificationMicroservice.DataAccess.Repository;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Mapper;

namespace NotificationMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NotificationMicroserviceDbContext>(
                options =>
                {
                    var connectionString = builder.Configuration.GetConnectionString(nameof(NotificationMicroserviceDbContext));

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new InvalidOperationException("Connection string for NotificationMicroserviceDbContext is not configured.");
                    }

                    options.UseNpgsql(connectionString);
                });

            builder.Services.AddScoped<ITypeApplicationService, MessageTypeService>();
            builder.Services.AddScoped<IMessageTypeRepository, MessageTypeRepository>();

            builder.Services.AddScoped<ITemplateApplicationService, MessageTemplateService>();
            builder.Services.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();

            builder.Services.AddScoped<IMessageApplicationService, MessageService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddAutoMapper(typeof(PresentationProfile), typeof(ApplicationProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
