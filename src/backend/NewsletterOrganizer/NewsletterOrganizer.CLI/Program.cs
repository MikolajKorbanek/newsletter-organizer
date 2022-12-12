// See https://aka.ms/new-console-template for more information

using NewsletterOrganizer.Domain.Mails;

Console.WriteLine("Hello, World!");

var client = new ImapMailService("imap.gmail.com", 993, true)
    .WithUser("korbanek.mikolaj@gmail.com", "")
    .FromInbox().Open();
    
var messages = client.GetMessages();

foreach (var msg in messages)
{
    Console.WriteLine(msg.Subject);
}