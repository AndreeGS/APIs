using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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



public class SendEmailController : Controller
{
    [HttpPost("/send-email")]
    public async Task<IActionResult> SendEmailAsync([FromBody] SendEmail request)
    {
        await EnviarEmailComCodigo(request.Destinatario, request.Codigo);
        return Ok("E-mail enviado com sucesso!");
    }

    private async Task EnviarEmailComCodigo(string destinatario, string codigo)
    {
        string fromMail = "roteiriza.suporte@gmail.com";
        string fromPassword = "xlxyrqpimzkkjmis";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);

        message.Subject = "Código de Verificação";
        message.To.Add(new MailAddress(destinatario));
        message.Body = $"<p>Seu código é: {codigo}<p>";
        message.IsBodyHtml = true;

        using (var smtpClient = new SmtpClient("smtp.gmail.com"))
        {
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(message);
        }
    }
}

public class SendEmail
{
    public string Destinatario { get; set; }
    public string Codigo { get; set; }
}