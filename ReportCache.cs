using System;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace proyecto5
{
    public static class ReportCache
    {
        private const string SAP_Server = "192.168.0.5:30015";
        private const string SAP_DBUID = "SYSTEM";
        private const string SAP_DBPass = "V1nsoc4!";


        private static readonly System.Threading.SemaphoreSlim CrystalGate =
            new System.Threading.SemaphoreSlim(6);

        // --- Refresco en segundo plano: mantiene el caché SIEMPRE caliente ---
        // Antes el caché expiraba a las 8h y, entre warmups programados, quedaba un
        // "hueco" (p.ej. 09:00-12:00) en el que el primer usuario disparaba la carga
        // en frío de los 75 reportes y la página se caía. Ahora el caché no expira y
        // un timer interno lo refresca (para datos frescos) con patron cargar-y-cambiar.
        private static System.Threading.Timer _refreshTimer;
        private static readonly object _initLock = new object();
        private static volatile bool _initialized = false;

        // Cada cuánto se refrescan los reportes en segundo plano (freshness de datos).
        private static readonly TimeSpan RefreshInterval = TimeSpan.FromHours(4);

        /// <summary>
        /// Se llama UNA sola vez desde Application_Start (Global.asax).
        /// Calienta el caché en segundo plano (sin bloquear el arranque del sitio)
        /// y deja un timer que lo refresca periódicamente. Así, tras un reciclaje del
        /// App Pool o al iniciar la app, el caché se rellena solo.
        /// </summary>
        public static void Initialize(string baseDatos = "INVERSIONESGGSA")
        {
            if (_initialized) return;
            lock (_initLock)
            {
                if (_initialized) return;
                _initialized = true;

                // Calentado inicial en segundo plano (no bloquea el primer request).
                System.Threading.ThreadPool.QueueUserWorkItem(_ =>
                {
                    try { PreloadAll(baseDatos); }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Preload inicial falló: {ex.Message}");
                    }
                });

                // Refresco periódico: nunca deja el caché vacío (patrón cargar-y-cambiar).
                _refreshTimer = new System.Threading.Timer(_ =>
                {
                    try { PreloadAll(baseDatos); }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Refresco de reportes falló: {ex.Message}");
                    }
                }, null, RefreshInterval, RefreshInterval);
            }
        }

        /// <summary>
        /// Libera un ReportDocument viejo, pero DESPUÉS de un margen, por si algún
        /// request todavía lo está renderizando cuando se reemplaza en el caché.
        /// (No liberar los .rpt viejos agota el límite de trabajos de Crystal.)
        /// </summary>
        private static void SafeDisposeLater(ReportDocument doc)
        {
            if (doc == null) return;
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMinutes(2)).ContinueWith(_ =>
            {
                try { doc.Close(); } catch { }
                try { doc.Dispose(); } catch { }
            });
        }

        public static readonly string[] RptPaths = new[]
        {
            null,
            @"C:\Reportes_Sap\Dashboard\1-Facturación Anual Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\2-Facturación Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Facturacion Anual.rpt",
            @"C:\Reportes_Sap\Dashboard\3-Unidades Vendidas Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\4-Unidades Vendidas Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Unidades.rpt",
            @"C:\Reportes_Sap\Dashboard\M2 facturados año.rpt",
            @"C:\Reportes_Sap\Dashboard\M2 facturados mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual M2.rpt",
            @"C:\Reportes_Sap\Dashboard\19-% Crecimiento Año pasado vs Actual.rpt",
            @"C:\Reportes_Sap\Dashboard\20-% Crecimiento Mes Actual vs Mes año pasado.rpt",
            @"C:\Reportes_Sap\Dashboard\13- Disponible Grupo.rpt",
            @"C:\Reportes_Sap\Dashboard\5-Cobranza Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\6-Cobranza Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\21-% Crecimiento Año Actual vs Año pasado Cobranza.rpt",
            @"C:\Reportes_Sap\Dashboard\22-% Crecimiento Mes Actual vs  Mes Año pasado.rpt",
            @"C:\Reportes_Sap\Dashboard\14-Por Cobrar Grupo.rpt",
            @"C:\Reportes_Sap\Dashboard\Por Cobrar Grupo mes.rpt",
            @"C:\Reportes_Sap\Dashboard\15-Cartera Total.rpt",
            @"C:\Reportes_Sap\Dashboard\16-Morosidad.rpt",
            @"C:\Reportes_Sap\Dashboard\11-Inmuebles.rpt",
            @"C:\Reportes_Sap\Dashboard\11- Construidos.rpt",
            @"C:\Reportes_Sap\Dashboard\11- En construccion.rpt",
            @"C:\Reportes_Sap\Dashboard\11- Por construir.rpt",
            @"C:\Reportes_Sap\Dashboard\12-Pasivos del Grupo.rpt",
            @"C:\Reportes_Sap\Dashboard\18- Pasivos Bancos.rpt",
            @"C:\Reportes_Sap\Dashboard\Pasivos Accionistas.rpt",
            @"C:\Reportes_Sap\Dashboard\17- Tasa Promedio Pasivos Financieros.rpt",
            @"C:\Reportes_Sap\Dashboard\Cobertura.rpt",
            @"C:\Reportes_Sap\Dashboard\Unidades en alquiler al dia.rpt",
            @"C:\Reportes_Sap\Dashboard\unidades alquiladas año.rpt",
            @"C:\Reportes_Sap\Dashboard\unidades alquiladas mes.rpt",
            @"C:\Reportes_Sap\Dashboard\9-Facturacion Alquileres Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\10-Facturacion Alquileres Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Alquiler simple vs coc.rpt",
            @"C:\Reportes_Sap\Dashboard\Operaciones No Conciliadas.rpt",
            @"C:\Reportes_Sap\Dashboard\Monto No Conciliado.rpt",
            @"C:\Reportes_Sap\Dashboard\Informe Principal Colaboradores Administracion.rpt",
            @"C:\Reportes_Sap\Dashboard\Informe Principal Colaboradores Obreros.rpt",
            @"C:\Reportes_Sap\Dashboard\Informe Principal Colaboradores.rpt",
            @"C:\Reportes_Sap\Dashboard\25-Leads_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\26-Leads_mes_actual.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Leads.rpt",
            @"C:\Reportes_Sap\Dashboard\25-Leads_del_anho - Inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\26-Leads_mes_actual - inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\25-Leads_del_anho - organicos.rpt",
            @"C:\Reportes_Sap\Dashboard\26-Leads_mes_actual - organicos.rpt",
            @"C:\Reportes_Sap\Dashboard\33-visitas_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\34-visitas_del_mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Visitas Efectivas.rpt",
            @"C:\Reportes_Sap\Dashboard\31-efectivas_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\32-efectivas_del_mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Visitas Efectivas Inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\31-efectivas_del_anho - organicas.rpt",
            @"C:\Reportes_Sap\Dashboard\32-efectivas_del_mes - organicos.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Visitas Efectivas Organicas.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Inbound del Año.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Inbound del Mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Ventas Inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Organicas del Año.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Organicas del Mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Ventas Organicas.rpt",
            @"C:\Reportes_Sap\Dashboard\35-oportunidades_activas_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\36-oportunidades_activas_del_mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Oportunidades Facturacion.rpt",
            @"C:\Reportes_Sap\Dashboard\Entregas Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Entregas Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Entregas Pendientes.rpt",
            @"C:\Reportes_Sap\Dashboard\Ingresos_Maquinarias.rpt",
            @"C:\Reportes_Sap\Dashboard\Total Activos.rpt",//para saber los art construidos post venta 
            @"C:\Reportes_Sap\Dashboard\Marketing_Meta_kpi.rpt", //Metas marketing
            @"C:\Reportes_Sap\Dashboard\Proyectos_kpi.rpt", //Total de Ingresos y Egresos dpto de proyectos
            @"C:\Reportes_Sap\Dashboard\Maquinarias-Indice de cumplimiento.rpt",//Para saber los costos de las maquinarios y equipos
            @"C:\Reportes_Sap\Dashboard\INFORME EFECTIVIDAD COBRANZAS.rpt",//EFECTIVIDAD COBRANZAS 2025
            @"C:\Reportes_Sap\Dashboard\OBRAS KPI RENTABILDIAD_V3.rpt"//Total informe de efectividad de obras 
        };

        public static void PreloadAll(string baseDatos = "INVERSIONESGGSA")
        {
            string strConnection = string.Format(
            "DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};Timeout=30;",
            "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, baseDatos);

            for (int i = 1; i < RptPaths.Length; i++)
            {
                if (string.IsNullOrEmpty(RptPaths[i])) continue;
                if (!System.IO.File.Exists(RptPaths[i])) continue;

                string key = $"CR_DOC_{i}";

                bool acquired = CrystalGate.Wait(TimeSpan.FromSeconds(30));
                if (!acquired)
                {
                    System.Diagnostics.Debug.WriteLine($"Timeout esperando ranura para reporte {i}");
                    continue;   // conserva lo que ya estuviera en caché (sin hueco)
                }

                ReportDocument doc = null;
                try
                {
                    doc = new ReportDocument();
                    var localDoc = doc;
                    var loadTask = System.Threading.Tasks.Task.Run(() =>
                    {
                        localDoc.Load(RptPaths[i]);
                        ApplyConnection(localDoc, strConnection, SAP_Server, baseDatos);
                    });

                    if (!loadTask.Wait(TimeSpan.FromSeconds(60)))
                    {
                        // La carga se colgó: NO tocar el caché, conservar el reporte anterior.
                        SafeDisposeLater(doc);
                        System.Diagnostics.Debug.WriteLine($"Timeout cargando reporte {i} (se conserva el anterior)");
                        continue;
                    }

                    // Cargar-y-recién-cambiar: solo ahora reemplazo la entrada del caché.
                    var oldDoc = HttpRuntime.Cache[key] as ReportDocument;

                    HttpRuntime.Cache.Insert(key, doc, null,
                        System.Web.Caching.Cache.NoAbsoluteExpiration,   // ya NO expira a las 8h
                        System.Web.Caching.Cache.NoSlidingExpiration,
                        System.Web.Caching.CacheItemPriority.NotRemovable, // ni se descarta por presion de memoria
                        null);

                    // Liberar el anterior recién después (por si alguien lo estaba renderizando).
                    if (oldDoc != null) SafeDisposeLater(oldDoc);
                }
                catch (Exception ex)
                {
                    if (doc != null) SafeDisposeLater(doc);   // conserva el del caché
                    System.Diagnostics.Debug.WriteLine($"Error precargando {i}: {ex.Message}");
                }
                finally
                {
                    CrystalGate.Release();
                }
            }
        }


        public static ReportDocument GetOrLoad(int i, string baseDatos = "INVERSIONESGGSA")
        {
            string key = $"CR_DOC_{i}";
            var doc = HttpRuntime.Cache[key] as ReportDocument;

            if (doc == null)
            {
                string strConnection = string.Format(
                "DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};Timeout=30;",
                "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, baseDatos);

                bool acquired = CrystalGate.Wait(TimeSpan.FromSeconds(30));
                if (!acquired)
                    throw new TimeoutException($"Timeout esperando ranura de Crystal Reports para reporte {i}.");

                try
                {
                    doc = new ReportDocument();
                    var loadTask = System.Threading.Tasks.Task.Run(() =>
                    {
                        doc.Load(RptPaths[i]);
                        ApplyConnection(doc, strConnection, SAP_Server, baseDatos);
                    });

                    if (!loadTask.Wait(TimeSpan.FromSeconds(60)))
                    {
                        SafeDisposeLater(doc);
                        throw new TimeoutException($"Timeout cargando reporte {i} desde SAP HANA.");
                    }

                    HttpRuntime.Cache.Insert(key, doc, null,
                        System.Web.Caching.Cache.NoAbsoluteExpiration,   // ya NO expira a las 8h
                        System.Web.Caching.Cache.NoSlidingExpiration,
                        System.Web.Caching.CacheItemPriority.NotRemovable, // ni se descarta por presion de memoria
                        null);
                }
                finally
                {
                   CrystalGate.Release();
                }
            }

            return doc;
        }

        private static void ApplyConnection(ReportDocument doc, string strConnection, string server, string db)
        {
            var dsc = doc.DataSourceConnections[0];
            var logon = dsc.LogonProperties;
            logon.Set("Provider", "B1CRHPROXY");
            logon.Set("Server Type", "B1CRHPROXY");
            logon.Set("Connection String", strConnection);
            dsc.SetLogonProperties(logon);
            dsc.SetConnection(server, db, false);

            foreach (ReportDocument sub in doc.Subreports)
            {
                var s = sub.DataSourceConnections[0];
                var slogon = s.LogonProperties;
                slogon.Set("Provider", "B1CRHPROXY");
                slogon.Set("Server Type", "B1CRHPROXY");
                slogon.Set("Connection String", strConnection);
                s.SetLogonProperties(slogon);
                s.SetConnection(server, db, false);
            }
        }
    }
}