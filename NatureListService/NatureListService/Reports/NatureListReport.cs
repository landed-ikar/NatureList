using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NatureListService {
    public partial class NatureListReport : DevExpress.XtraReports.UI.XtraReport {
        public NatureListReport() {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            xrSubreport1.ReportSource.DataSource = this.DataSource;
        }
    }
}
