using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.IO;


namespace Dashboard.Controllers
{
    public class InvoiceController : Controller
    {
        ReportViewer reporte = new ReportViewer();

        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getInvoice()
        {
            string DirectorioReportesRelativo = "~/Reports/";
            string urlArchivo = string.Format("{0}.{1}", "Report1", "rdlc");
            string FullPath = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirectorioReportesRelativo), urlArchivo);


            //Reset
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullPath;
            reporte.ProcessingMode = ProcessingMode.Local;


            //DataSource
            DataTable dt = getData(1);
            DataTable dt2 = getOrderLines(1);

           // ReportDataSource rds1 = new ReportDataSource("DataSet1", dt);
            ReportDataSource rds = new ReportDataSource("DataSet2",dt);
            ReportDataSource rds1 = new ReportDataSource("DataSet1", dt2);


            reporte.LocalReport.DataSources.Add(rds);
            reporte.LocalReport.DataSources.Add(rds1);
            //Path


            //Parameters
            //ReportParameter[] rptParams = new ReportParameter[]
            //{
            //    new ReportParameter("idOrder","1")
            //};


            //Refresh
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDF");


            return File(new MemoryStream(file).ToArray(),
                        System.Net.Mime.MediaTypeNames.Application.Pdf,
                        string.Format("{0}{1}","archivoPrueba.","PDF"));
        }

        private DataTable getOrderLines(int idOrder)
        {
            DataTable dt = new DataTable();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["GaluEntities"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("getOrderLines", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("idOrder", SqlDbType.Int).Value = idOrder;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }

            return dt;
        }

        private DataTable getData(int idOrder)
        {
            DataTable dt = new DataTable();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["GaluEntities"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("getInvoiceFromOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("idOrder", SqlDbType.Int).Value = idOrder;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            
                return dt;
        }
        

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
