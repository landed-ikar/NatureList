using DevExpress.XtraEditors;

namespace ClientProject {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.sidePanel1 = new DevExpress.XtraEditors.SidePanel();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.sidePanel2 = new DevExpress.XtraEditors.SidePanel();
            this.rec_XmlFileContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.sidePanel3 = new DevExpress.XtraEditors.SidePanel();
            this.btn_OpenXml = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SendXml = new DevExpress.XtraEditors.SimpleButton();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.spr_Report = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.sidePanel4 = new DevExpress.XtraEditors.SidePanel();
            this.te_TrainNumber = new DevExpress.XtraEditors.TextEdit();
            this.btn_GetReport = new DevExpress.XtraEditors.SimpleButton();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.me_Log = new DevExpress.XtraEditors.MemoEdit();
            this.xmlOpenFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.sidePanel5 = new DevExpress.XtraEditors.SidePanel();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.btn_GetNlJson = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rec_JsonData = new DevExpress.XtraRichEdit.RichEditControl();
            this.sidePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            this.sidePanel2.SuspendLayout();
            this.sidePanel3.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            this.sidePanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_TrainNumber.Properties)).BeginInit();
            this.tabNavigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.me_Log.Properties)).BeginInit();
            this.sidePanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel1
            // 
            this.sidePanel1.Controls.Add(this.tabPane1);
            this.sidePanel1.Controls.Add(this.me_Log);
            this.sidePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidePanel1.Location = new System.Drawing.Point(0, 0);
            this.sidePanel1.Name = "sidePanel1";
            this.sidePanel1.Size = new System.Drawing.Size(1354, 676);
            this.sidePanel1.TabIndex = 0;
            this.sidePanel1.Text = "sidePanel1";
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tabNavigationPage3);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2,
            this.tabNavigationPage3});
            this.tabPane1.RegularSize = new System.Drawing.Size(1101, 676);
            this.tabPane1.SelectedPage = this.tabNavigationPage1;
            this.tabPane1.Size = new System.Drawing.Size(1101, 676);
            this.tabPane1.TabIndex = 4;
            this.tabPane1.Text = "Send XML";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Send Data";
            this.tabNavigationPage1.Controls.Add(this.sidePanel2);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(1101, 635);
            // 
            // sidePanel2
            // 
            this.sidePanel2.Controls.Add(this.rec_XmlFileContent);
            this.sidePanel2.Controls.Add(this.sidePanel3);
            this.sidePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidePanel2.Location = new System.Drawing.Point(0, 0);
            this.sidePanel2.Name = "sidePanel2";
            this.sidePanel2.Size = new System.Drawing.Size(1101, 635);
            this.sidePanel2.TabIndex = 2;
            this.sidePanel2.Text = "sidePanel2";
            // 
            // rec_XmlFileContent
            // 
            this.rec_XmlFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rec_XmlFileContent.Location = new System.Drawing.Point(0, 0);
            this.rec_XmlFileContent.Name = "rec_XmlFileContent";
            this.rec_XmlFileContent.Size = new System.Drawing.Size(1101, 599);
            this.rec_XmlFileContent.TabIndex = 0;
            // 
            // sidePanel3
            // 
            this.sidePanel3.Controls.Add(this.btn_OpenXml);
            this.sidePanel3.Controls.Add(this.btn_SendXml);
            this.sidePanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sidePanel3.Location = new System.Drawing.Point(0, 599);
            this.sidePanel3.Name = "sidePanel3";
            this.sidePanel3.Size = new System.Drawing.Size(1101, 36);
            this.sidePanel3.TabIndex = 3;
            this.sidePanel3.Text = "sidePanel3";
            // 
            // btn_OpenXml
            // 
            this.btn_OpenXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OpenXml.Location = new System.Drawing.Point(499, 3);
            this.btn_OpenXml.Name = "btn_OpenXml";
            this.btn_OpenXml.Size = new System.Drawing.Size(309, 30);
            this.btn_OpenXml.TabIndex = 0;
            this.btn_OpenXml.Text = "Open XML";
            this.btn_OpenXml.Click += new System.EventHandler(this.btn_OpenXml_Click);
            // 
            // btn_SendXml
            // 
            this.btn_SendXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendXml.Location = new System.Drawing.Point(814, 3);
            this.btn_SendXml.Name = "btn_SendXml";
            this.btn_SendXml.Size = new System.Drawing.Size(281, 30);
            this.btn_SendXml.TabIndex = 1;
            this.btn_SendXml.Text = "Send XML";
            this.btn_SendXml.Click += new System.EventHandler(this.btn_SendXml_Click);
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Get Excel Report";
            this.tabNavigationPage2.Controls.Add(this.spr_Report);
            this.tabNavigationPage2.Controls.Add(this.sidePanel4);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(1101, 635);
            // 
            // spr_Report
            // 
            this.spr_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spr_Report.Location = new System.Drawing.Point(0, 0);
            this.spr_Report.Name = "spr_Report";
            this.spr_Report.Size = new System.Drawing.Size(1101, 597);
            this.spr_Report.TabIndex = 0;
            this.spr_Report.Text = "spreadsheetControl1";
            // 
            // sidePanel4
            // 
            this.sidePanel4.Controls.Add(this.labelControl1);
            this.sidePanel4.Controls.Add(this.te_TrainNumber);
            this.sidePanel4.Controls.Add(this.btn_GetReport);
            this.sidePanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sidePanel4.Location = new System.Drawing.Point(0, 597);
            this.sidePanel4.Name = "sidePanel4";
            this.sidePanel4.Size = new System.Drawing.Size(1101, 38);
            this.sidePanel4.TabIndex = 1;
            this.sidePanel4.Text = "sidePanel4";
            // 
            // te_TrainNumber
            // 
            this.te_TrainNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.te_TrainNumber.EditValue = "2236";
            this.te_TrainNumber.Location = new System.Drawing.Point(615, 9);
            this.te_TrainNumber.Name = "te_TrainNumber";
            this.te_TrainNumber.Size = new System.Drawing.Size(125, 22);
            this.te_TrainNumber.TabIndex = 3;
            // 
            // btn_GetReport
            // 
            this.btn_GetReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetReport.Location = new System.Drawing.Point(814, 5);
            this.btn_GetReport.Name = "btn_GetReport";
            this.btn_GetReport.Size = new System.Drawing.Size(281, 30);
            this.btn_GetReport.TabIndex = 2;
            this.btn_GetReport.Text = "Get Nature List Report";
            this.btn_GetReport.Click += new System.EventHandler(this.btn_GetReport_Click);
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Get JSON Data";
            this.tabNavigationPage3.Controls.Add(this.rec_JsonData);
            this.tabNavigationPage3.Controls.Add(this.sidePanel5);
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(1101, 635);
            // 
            // me_Log
            // 
            this.me_Log.Dock = System.Windows.Forms.DockStyle.Right;
            this.me_Log.Location = new System.Drawing.Point(1101, 0);
            this.me_Log.Name = "me_Log";
            this.me_Log.Size = new System.Drawing.Size(253, 676);
            this.me_Log.TabIndex = 1;
            // 
            // xmlOpenFileDialog
            // 
            this.xmlOpenFileDialog.FileName = "XML File";
            this.xmlOpenFileDialog.Filter = "(*.xml)|*.xml";
            // 
            // sidePanel5
            // 
            this.sidePanel5.Controls.Add(this.labelControl2);
            this.sidePanel5.Controls.Add(this.textEdit2);
            this.sidePanel5.Controls.Add(this.btn_GetNlJson);
            this.sidePanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sidePanel5.Location = new System.Drawing.Point(0, 597);
            this.sidePanel5.Name = "sidePanel5";
            this.sidePanel5.Size = new System.Drawing.Size(1101, 38);
            this.sidePanel5.TabIndex = 2;
            this.sidePanel5.Text = "sidePanel5";
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "2236";
            this.textEdit2.Location = new System.Drawing.Point(615, 9);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(125, 22);
            this.textEdit2.TabIndex = 3;
            // 
            // btn_GetNlJson
            // 
            this.btn_GetNlJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetNlJson.Location = new System.Drawing.Point(814, 5);
            this.btn_GetNlJson.Name = "btn_GetNlJson";
            this.btn_GetNlJson.Size = new System.Drawing.Size(281, 30);
            this.btn_GetNlJson.TabIndex = 2;
            this.btn_GetNlJson.Text = "Get Nature List JSON";
            this.btn_GetNlJson.Click += new System.EventHandler(this.btn_GetNlJson_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(527, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Train Number";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(527, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Train Number";
            // 
            // rec_JsonData
            // 
            this.rec_JsonData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rec_JsonData.Location = new System.Drawing.Point(0, 0);
            this.rec_JsonData.Name = "rec_JsonData";
            this.rec_JsonData.Size = new System.Drawing.Size(1101, 597);
            this.rec_JsonData.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 676);
            this.Controls.Add(this.sidePanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sidePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            this.sidePanel2.ResumeLayout(false);
            this.sidePanel3.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            this.sidePanel4.ResumeLayout(false);
            this.sidePanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_TrainNumber.Properties)).EndInit();
            this.tabNavigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.me_Log.Properties)).EndInit();
            this.sidePanel5.ResumeLayout(false);
            this.sidePanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SidePanel sidePanel1;
        private DevExpress.XtraEditors.SimpleButton btn_SendXml;
        private DevExpress.XtraEditors.SimpleButton btn_OpenXml;
        private DevExpress.XtraEditors.XtraOpenFileDialog xmlOpenFileDialog;
        private DevExpress.XtraEditors.MemoEdit me_Log;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private SidePanel sidePanel2;
        private DevExpress.XtraRichEdit.RichEditControl rec_XmlFileContent;
        private SidePanel sidePanel3;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spr_Report;
        private SidePanel sidePanel4;
        private TextEdit te_TrainNumber;
        private SimpleButton btn_GetReport;
        private LabelControl labelControl1;
        private SidePanel sidePanel5;
        private LabelControl labelControl2;
        private TextEdit textEdit2;
        private SimpleButton btn_GetNlJson;
        private DevExpress.XtraRichEdit.RichEditControl rec_JsonData;
    }
}

