using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace TrialAPI_XBCAD_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Initialize Firebase
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(@"C:\Users\lab_services_student\Desktop\Firebase\gourmetguru-23c0a-firebase-adminsdk-dw05q-ff1f389dae.json")
            });

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
