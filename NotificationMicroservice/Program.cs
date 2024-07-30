using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.Application.Services;
using NotificationMicroservice.DataAccess;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.DataAccess.Repository;
using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;

namespace NotificationMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NotificationMicroserviceDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(NotificationMicroserviceDbContext)));
                });

            builder.Services.AddScoped<IMessageTypeService, MessageTypeService>();
            builder.Services.AddScoped<IMessageTypeRepository<TypeEntity>, MessageTypeRepository>();

            builder.Services.AddScoped<IMessageTemplateService, MessageTemplateService>();
            builder.Services.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();

            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

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
