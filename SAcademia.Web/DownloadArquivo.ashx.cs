using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFF.Web
{
    /// <summary>
    /// Summary description for DownloadArquivo
    /// </summary>
    public class DownloadArquivo : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string Descricao = context.Request.QueryString[0].ToString();
            string extensao = context.Request.QueryString[1].ToString();

            Byte[] ArquivoBynary = null;
            
            ArquivoBynary = (byte[])context.Session["ArquivoDownload"];

            context.Response.ContentType = ArquivoBynary.ToString();

            if (Descricao.Length > 20)
                Descricao = Descricao.Substring(0, 20);

            context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", Descricao + extensao));
            context.Response.BinaryWrite(ArquivoBynary);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}