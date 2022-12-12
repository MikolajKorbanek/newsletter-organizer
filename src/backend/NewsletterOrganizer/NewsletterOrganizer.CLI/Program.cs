// See https://aka.ms/new-console-template for more information

using NewsletterOrganizer.Domain.Mails;

Console.WriteLine("Hello, World!");

var client = new ImapMailService("imap.gmail.com", 993, true)
    .WithUser("", "")
    .FromInbox().Open();


var progressHandler = new Progress<int>((i) =>
{
    Console.WriteLine($"Progress: {i}%");
});

var messages = client.GetMessages(progressHandler);

foreach (var msg in messages)
{
    Console.WriteLine(msg.Subject);
}