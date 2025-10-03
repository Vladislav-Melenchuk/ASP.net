using HW_FutureMe.Data;

namespace HW_FutureMe.Services
{
    public class LetterSenderService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly EmailService _emailService;

        public LetterSenderService(IServiceProvider services, EmailService emailService)
        {
            _services = services;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var today = DateTime.Today;
                    var letters = db.Letters.Where(l => l.SendDate.Date == today).ToList();

                    foreach (var letter in letters)
                    {
                        await _emailService.SendEmailAsync(
                            letter.Email,
                            "Письмо из прошлого",
                            letter.Message
                        );
                    }
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
