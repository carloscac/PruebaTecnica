//using Microsoft.Reporting.WebForms;
//using System;

namespace WebApp.WebApi.ReportesAspx
{
    //    public partial class rptSabanaRepuestos : System.Web.UI.Page
    //    {
    //        protected void Page_Load(object sender, EventArgs e)
    //        {
    //            if (!this.IsPostBack)
    //            {
    //                string Chasis = string.Empty;
    //                string DocumentoNombre= string.Empty;
    //                string FechaInicial = string.Empty;
    //                string FechaFinal = string.Empty;
    //                string usucodigoTecnico = string.Empty;
    //                string usucodigoUsuario = string.Empty;

    //                try
    //                {
    //                    #region Propiedades

    //                    string UserName = WebConfigurationManager.AppSettings["Username"];
    //                    string PassWord = WebConfigurationManager.AppSettings["Password"];
    //                    string DomainName = WebConfigurationManager.AppSettings["Domain"];

    //                    #endregion

    //                    #region Llenar propiedades desde QueryString

    //                    if (!string.IsNullOrEmpty(Request.QueryString["Chasis"]))
    //                    {
    //                        Chasis = Request.QueryString["Chasis"].ToString();
    //                    }
    //                    if (!string.IsNullOrEmpty(Request.QueryString["DocumentoNombre"]))
    //                    {
    //                        DocumentoNombre = Request.QueryString["DocumentoNombre"].ToString();
    //                    }
    //                    if (!string.IsNullOrEmpty(Request.QueryString["FechaInicial"]))
    //                    {
    //                        FechaInicial = Request.QueryString["FechaInicial"].ToString();
    //                    }
    //                    if (!string.IsNullOrEmpty(Request.QueryString["FechaFinal"]))
    //                    {
    //                        FechaFinal = Request.QueryString["FechaFinal"].ToString();
    //                    }
    //                    if (!string.IsNullOrEmpty(Request.QueryString["usucodigoTecnico"]))
    //                    {
    //                        usucodigoTecnico = Request.QueryString["usucodigoTecnico"].ToString();
    //                    }
    //                    if (!string.IsNullOrEmpty(Request.QueryString["usucodigoUsuario"]))
    //                    {
    //                        usucodigoUsuario = Request.QueryString["usucodigoUsuario"].ToString();
    //                    }

    //                    #endregion

    //                    #region Reporte

    //                    GenerarReporte(Chasis, DocumentoNombre, FechaInicial, FechaFinal, usucodigoTecnico, usucodigoUsuario);
    //                    #endregion
    //                }
    //                catch (Exception Ex)
    //                {
    //                    if (!(Ex is CustomException))
    //                    {
    //                        CustomException ExCustom = new CustomException(Ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, new string[] {
    //                            Ex.Message }, WebConfigurationManager.AppSettings["Application"]);
    //                        Ex = (Exception)ExCustom;
    //                    }
    //                    this.lblMessage.Text = Ex.Message;
    //                }
    //            }
    //        }

    //        /// <summary>
    //        /// Método que permite consultar reporte, con los filtros establecidos.
    //        /// </summary>
    //        /// <param name="Chasis">Chasis del vehiculo</param>
    //        /// <param name="DocumentoNombre">Documento o Nombre del cliente</param>
    //        /// <param name="FechaInicial">fecha inicial</param>
    //        /// <param name="FechaFinal">fecha final</param>
    //        /// <param name="usucodigoTecnico">Código de usuario del técnico</param>
    //        /// <param name="usucodigoUsuario">Código de usuario que genera el reporte</param>
    //        private void GenerarReporte( string Chasis, string DocumentoNombre, string FechaInicial, string FechaFinal, string usucodigoTecnico, string usucodigoUsuario)
    //        {
    //            try
    //            {
    //                #region Propiedades

    //                string UserName = WebConfigurationManager.AppSettings["Username"];
    //                string PassWord = WebConfigurationManager.AppSettings["Password"];
    //                string DomainName = WebConfigurationManager.AppSettings["Domain"];

    //                #endregion

    //                rptRepuestos.ProcessingMode = ProcessingMode.Remote;
    //                IReportServerCredentials irsc = new CustomReportCredentials(UserName, PassWord, DomainName);
    //                rptRepuestos.ServerReport.ReportServerCredentials = irsc;
    //                rptRepuestos.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["SSRS"]);

    //                RutaReportes objRutaReportes = new RutaReportes();
    //                string idAdress = objRutaReportes.GetLocalIPAddress();
    //                string ConnectionString = objRutaReportes.GetValor(idAdress);

    //                rptRepuestos.ServerReport.ReportPath = ConnectionString + "/TalleresEquiposIndustriales/SabanaDatosRepuestos";

    //                ReportParameter parametro;

    //                parametro = new ReportParameter();
    //                parametro.Name = "Chasis";
    //                parametro.Values.Add(Chasis);
    //                parametro.Visible = false;
    //                rptRepuestos.ServerReport.SetParameters(parametro);

    //                parametro = new ReportParameter();
    //                parametro.Name = "DocumentoNombre";
    //                parametro.Values.Add(DocumentoNombre);
    //                parametro.Visible = false;
    //                rptRepuestos.ServerReport.SetParameters(parametro);

    //                parametro = new ReportParameter();
    //                parametro.Name = "FechaInicial";
    //                parametro.Values.Add(FechaInicial);
    //                parametro.Visible = false;
    //                rptRepuestos.ServerReport.SetParameters(parametro);

    //                parametro = new ReportParameter();
    //                parametro.Name = "FechaFinal";
    //                parametro.Values.Add(FechaFinal);
    //                parametro.Visible = false;
    //                rptRepuestos.ServerReport.SetParameters(parametro);

    //                parametro = new ReportParameter();
    //                parametro.Name = "UsucodigoTecnico";
    //                parametro.Values.Add(usucodigoTecnico.ToString());
    //                parametro.Visible = false;
    //                rptRepuestos.ServerReport.SetParameters(parametro);

    //                parametro = new ReportParameter();
    //                parametro.Name = "UsucodigoUsuario";
    //                parametro.Values.Add(usucodigoUsuario.ToString());
    //                parametro.Visible = false;
    //                rptRepuestos.ServerReport.SetParameters(parametro);

    //                rptRepuestos.ServerReport.Refresh();
    //            }
    //            catch (Exception Ex)
    //            {
    //                if (!(Ex is CustomException))
    //                {
    //                    CustomException ExCustom = new CustomException(Ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, new string[] { Ex.Message }, WebConfigurationManager.AppSettings["Application"]);
    //                    Ex = (Exception)ExCustom;
    //                }
    //            }
    //        }
    //    }
}