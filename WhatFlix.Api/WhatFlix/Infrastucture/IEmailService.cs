namespace WhatFlix.Infrastucture 
{
   interface IEmailService
   {
       void SendMail(string from, string to, string subject, string body);
   }
}