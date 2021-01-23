using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public static class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            //tem que pesquisar qual é o servidor e a porta que vai utilizar para enviar o email 
            //exemplo do Gmail:
            //Servidor: smtp.gmail.com
            //porta: 587

          
            SmtpClient smtp = new SmtpClient("smtp-relay.gmail.com", 587);//SMTP-> Servidor que vai enviar a menssagem

            smtp.UseDefaultCredentials = false; //desabilita as credenciais padrão do sistema pos iremos utilizar o nosso próprio;
            smtp.Credentials = new NetworkCredential("brenofrancisco63@gmail.com", "BRENOFRANCISCOMORAIS"); //credencial de rede são dois parametros Usuário e Senha

            //habilitando conexão segura de criptografia
            smtp.EnableSsl = true;

            //mailMessage -> serve para Construir a Menssagem
            MailMessage messagem = new MailMessage();

            //responsável por envia a menssagem
            messagem.From = new MailAddress("brenofrancisco63@gmail.com");

            //para quem vai a menssagem, para quem vai a menssagem podemos colocar mais de um email por ser uma coleção
            messagem.To.Add("brenofrancisco63@gmail.com");
            //messagem.To.Add("brenofrancisco63@gmail.com");

            //assunto da menssagem
            messagem.Subject = "Contato - Loja Virtual" + contato.Email;

            //para permitir que o corpo da menssagem aceite HTML presisa ativar 
         

            //html que sera gerado no Corpo do Email
            string corpoHTML = string.Format("<h2>Contato Loja Virtual </h2>" +
             "<b>Nome</b>{0}<br>" +
             "<b>Email</b>{1}<br>" +
             "<b>Texto</b{2}><br>", contato.Nome, contato.Email, contato.Texto
             );
            messagem.IsBodyHtml = true;
            //conteudo do email
            messagem.Body = corpoHTML;

            //envaindo pela conexão SMTP a menssagem 
            smtp.Send(messagem);
        }
    }
}
