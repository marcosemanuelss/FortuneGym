using System;
using System.Text;
using System.Web;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using Seguranca.IpAccess.IPCheckers;
using System.Web.SessionState;
using System.Diagnostics;
using System.Web.UI;
using Entidade.Usuarios;

namespace Seguranca
{
    /// <summary>
    /// Temp handler used to force the SessionStateModule to load session state.
    /// From Tomasz Jastrzebski http://forums.asp.net/p/1098574/1664675.aspx
    /// </summary>
    public class SessionHttpHandler : IHttpHandler, IReadOnlySessionState
    {
        internal readonly IHttpHandler OriginalHandler;

        public SessionHttpHandler(IHttpHandler originalHandler)
        {
            OriginalHandler = originalHandler;
        }

        public void ProcessRequest(HttpContext context)
        {

        }

        public bool IsReusable // IsReusable must be set to false since class has a member!
        {
            get { return false; }
        }
    }

    public class AccessProviderModule : IHttpModule, IRequiresSessionState
    {
        static readonly string loginPageName = ConfigurationManager.AppSettings["loginPageName"].ToString().ToLower();

        public AccessProviderModule()
        {
            CriarLog("Inicialização de Segurança (Construtor)");
            CriarLog("Login Page Name:" + loginPageName);
        }

        public void Init(HttpApplication context)
        {
            CriarLog("Inicialização de Segurança");
            CriarLog("Aplicação:" + context.Application.ToString());

            context.PostMapRequestHandler += PostMapRequestHandler;
            context.PostAcquireRequestState += PostAcquireRequestState;
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        static void PostMapRequestHandler(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            if (context.Handler is IReadOnlySessionState || context.Handler is IRequiresSessionState)
                return;

            context.Handler = new SessionHttpHandler(context.Handler);
        }

        static void PostAcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            SessionHttpHandler resourceHttpHandler = context.Handler as SessionHttpHandler;
            if (resourceHttpHandler != null)
                context.Handler = resourceHttpHandler.OriginalHandler;
        }

        static void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            VerificarAcesso((HttpApplication)sender);
        }

        static void VerificarAcesso(HttpApplication application)
        {
            string aspxPageName = application.Request.Url.AbsolutePath.ToLower();
            Page page = HttpContext.Current.Handler as Page;
            
            if (page != null)
            {
                VerificarPermissoes(application);
                //VerificarAcessoIP(application, aspxPageName);
            }

        }

        static void VerificarPermissoes(HttpApplication application)
        {
            //Page page = HttpContext.Current.Handler as Page;
            //Usuarios usuario = application.Context.Session["USUARIO"] as Usuarios;

            //if (usuario != null && page != null)
            //    CriarLog("Page: " + page.ToString() + " / Usuario: " + usuario.Transacoes.Count);

            //if (page != null && application.Session["Usuario"] != null && (application.Session["Usuario"] as Usuario).NomeLogin != "admin")
            //{
            //    var permissoes = page.GetType().BaseType.GetCustomAttributes<PermissaoAttribute>();

            //    CriarLog(" Permissoes: " + permissoes.Length);

            //    if (permissoes.Length < 1)
            //    {
            //        CriarLog(" Acesso Negado: falta de permissao");
            //        NegarAcesso();
            //    }
            //    var permissao = permissoes[0];

            //    CriarLog(" Necessita Autenticacao: " + permissao.NecessitaAutenticacao.ToString());

            //    if (permissao.NecessitaAutenticacao)
            //    {
            //        VerificarUsuarioLogado(application);

            //        //VerificarUsuarioAutorizado(application);

            //        CriarLog(" Sigla Transacao: " + permissao.SiglaTransacao);

            //        if (permissao.SiglaTransacao != null && !usuario.VerificarPermissao(permissao.SiglaTransacao))
            //        {
            //            CriarLog(" Acesso Negado: Por falta de transacao");
            //            NegarAcesso();
            //        }
            //    }
            //}
        }

        static void CriarLog(string valores)
        {
            //string nome_arquivo = AppDomain.CurrentDomain.BaseDirectory + "\\LogSIC.txt";
            //if (!System.IO.File.Exists(nome_arquivo))
            //    System.IO.File.Create(nome_arquivo).Close();

            //System.IO.TextWriter arquivo = System.IO.File.AppendText(nome_arquivo);
            //arquivo.WriteLine(valores);

            //arquivo.Close();
        }

        static void VerificarUsuarioLogado(HttpApplication application)
        {
            Usuarios usuario = application.Context.Session["USUARIO"] as Usuarios;

            if (usuario == null)
            {
                application.Response.Redirect(loginPageName);
                application.Response.End();
            }
        }

        static void VerificarUsuarioAutorizado(HttpApplication application)
        {
            //Usuarios usuario = application.Context.Session["USUARIO"] as Usuarios;

            //if (!usuario.Autorizado)
            //{
            //    application.Response.Redirect(loginPageName);
            //    application.Response.End();
            //}
        }


        static void VerificarAcessoIP(HttpApplication application, string aspxPageName)
        {
            //Usuarios usuario = application.Context.Session["USUARIO"] as Usuario;

            //if (usuario != null && aspxPageName.Contains("aspx"))
            //{
            //    IIpChecker checker = new IpAddressChecker(usuario.Codigo.Value);

            //    if (checker.CanBlockIp(ObterIPCliente(application.Request)))
            //    {
            //        NegarAcesso();
            //    }
            //}
        }

        [DebuggerStepThrough]
        private static void NegarAcesso()
        {
            throw new HttpException(403, "Acesso Negado");
        }

        static string ObterIPCliente(HttpRequest request)
        {
            string ip;
            try
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ip))
                {
                    if (ip.IndexOf(",") > 0)
                    {
                        string[] ipRange = ip.Split(',');
                        int le = ipRange.Length - 1;
                        ip = ipRange[le];
                    }
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch { ip = null; }

            return ip;
        }

        public void Dispose()
        {

        }
    }
}