using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace proyecto5
{
    public partial class WarmUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsLocal)
            {
                Response.StatusCode = 403;
                Response.ContentType = "text/plain";
                Response.Write("Forbidden");
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            var t = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                ReportCache.PreloadAll("INVERSIONESGGSA");
                t.Stop();

                WriteWarmLog($"OK | {t.Elapsed}");
                Response.StatusCode = 200;
                Response.ContentType = "text/plain";
                Response.Write("WarmUp OK - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                t.Stop();
                WriteWarmLog($"ERROR: {ex.GetType().Name} - {ex.Message} | {t.Elapsed}");
                Response.StatusCode = 500;
                Response.ContentType = "text/plain";
                Response.Write("WarmUp ERROR - " + ex.Message);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private void WriteWarmLog(string message)
        {
            try
                {
                   var path = Server.MapPath("~/App_Data/warmup.log");
                    File.AppendAllText(path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}\r\n");
                }
            catch { }
        }
    }
}