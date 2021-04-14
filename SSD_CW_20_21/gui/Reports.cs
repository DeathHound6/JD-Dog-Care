using System;
using System.Collections.Generic;
using System.Data;
using SSD_CW_20_21.DbAccess;
using SSD_CW_20_21.Objects;
using Microsoft.Reporting.WinForms;

namespace SSD_CW_20_21.gui
{
    public partial class Reports : Template
    {
        private OrderDBAccess orderAccess = Globals.orderAccess;
        private ServiceDBAccess serviceAccess = Globals.serviceAccess;
        private ServiceOrderDBAccess servOrderAccess = Globals.serviceOrderAccess;
        private DogDBAccess dogAccess = Globals.dogAccess;

        private ReportDataSource rds;

        public Reports()
        {
            InitializeComponent();
            dtpStart.MinDate = DateTime.Today.AddMonths(-6);
            dtpStart.MaxDate = DateTime.Today.AddMonths(6);
            dtpEnd.MinDate = dtpStart.Value;
            dtpEnd.MaxDate = DateTime.Today.AddMonths(6);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // BROKEN TABLE ADPATER STUFF
            //MessageBox.Show(orderAccess.exec($"SELECT * FROM ORDERS WHERE(ORDERS.Paid = 1) AND (ORDERS.Cancelled = 0) AND (CONVERT(datetime, {dtpStart.Value.ToShortDateString()}, 103) <= CONVERT(datetime, ORDERS.Date, 103)) AND (CONVERT(datetime, {dtpEnd.Value.ToShortDateString()}, 103) >= CONVERT(datetime, ORDERS.Date, 103))").Date);
            //MessageBox.Show("Start " + Convert.ToDateTime(dtpStart.Value.ToShortDateString()).ToString());
            //MessageBox.Show("End " + Convert.ToDateTime(dtpEnd.Value.ToShortDateString()).ToString());
            //DataTable1TableAdapter.Fill(ReportsDataSet.DataTable1, dtpStart.Value.ToShortDateString(), dtpEnd.Value.ToShortDateString());
            //repReports.RefreshReport();

            refreshTables();
        }

        private void refreshTables()
        {
            DataTable bookingCosts = new DataTable("ReportsDataTable");
            bookingCosts.Columns.Add("Cost", Type.GetType("System.Double"));
            bookingCosts.Columns.Add("Date", Type.GetType("System.String"));
            bookingCosts.DefaultView.Sort = "Date desc";

            List<Orders> orders = orderAccess.getAllOrders().FindAll(order => {
                return Convert.ToDateTime(dtpStart.Value.ToShortDateString()) <= Convert.ToDateTime(order.Date) && Convert.ToDateTime(dtpEnd.Value.ToShortDateString()) >= Convert.ToDateTime(order.Date) && order.Cancelled == 0 && order.Paid == 1;
            });
            foreach (Orders order in orders)
            {
                DataRow row = bookingCosts.NewRow();
                Orders firstOrder = orderAccess.getAllOrders().FindAll(o => dogAccess.getDogById(o.DogId).OwnerId == dogAccess.getDogById(order.DogId).OwnerId)[0];
                double cost = Globals.calcCost(order, serviceAccess.getServiceById(servOrderAccess.getObjectByOrderID(order.Id).ServiceID), order == firstOrder);
                row["Cost"] = cost;
                row["Date"] = order.Date;
                bookingCosts.Rows.Add(row);
            }
            rds = new ReportDataSource("ReportsDataSet", bookingCosts);

            repReports.LocalReport.DataSources.Clear();
            repReports.LocalReport.DataSources.Add(rds);

            repReports.Refresh();
            repReports.RefreshReport();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.MinDate = dtpStart.Value;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new GroomingMain().Show();
            Hide();
        }
    }
}
