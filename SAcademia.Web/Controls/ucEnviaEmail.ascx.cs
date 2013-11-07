using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace SFF.Web.Controls
{
    public partial class ucEnviaEmail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Envia um email de acordo com os parametros passados
        /// </summary>
        /// <param name="Host">Servidor SMTP</param>
        /// <param name="Porta">Porta do servidor SMTP</param>
        /// <param name="Destino">Email de Destino</param>
        /// <param name="Origem">Email de Origem</param>
        /// <param name="Senha">Senha do Email de Origem</param>
        /// <param name="NomeOrigem">Nome de Origem</param>
        /// <param name="Assunto">Assunto do Email</param>
        /// <param name="Mensagem">Mensagem</param>
        public void SendMail(string Host, int Porta, bool Ssl, string Destino, string Origem, string Senha, string NomeOrigem, string Assunto, string Mensagem)
        {
            //Corpo da mensagem
            string Corpo = "De: " + NomeOrigem + "\n";
            Corpo += "Email: " + Origem + "\n";
            Corpo += "Assunto: " + Assunto + "\n";
            Corpo += "Descrição: \n" + Mensagem + "\n";

            // Configurações de SMTP
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();

            smtp.Host = Host;
            smtp.Port = Porta;
            smtp.EnableSsl = Ssl;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Origem, Senha);
            smtp.Timeout = 20000;

            // Enviando o email
            smtp.Send(Origem, Destino, Assunto, Corpo);
        }
    }
}