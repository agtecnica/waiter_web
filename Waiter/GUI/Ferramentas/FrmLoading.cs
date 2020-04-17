using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Ferramentas
{
    public partial class FrmLoading : Form
    {
        public Action Worker { get; set; }
        DataGridView dgvPrincipal { get; set; }

        Microsoft.Office.Interop.Excel.Application XcelApp;
        private Microsoft.Office.Interop.Excel.Worksheet planilha = null;
        public FrmLoading(DataGridView dgvPrincipal)
        {
            InitializeComponent();
            this.dgvPrincipal = dgvPrincipal;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(GerarExcel).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public void GerarExcel()
        {
            XcelApp = new Microsoft.Office.Interop.Excel.Application();
            if (dgvPrincipal.Rows.Count > 0)
            {
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvPrincipal.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvPrincipal.Columns[i - 1].HeaderText;
                    //XcelApp.Cells[1, i].EntireRow.Interior.Color = Color.Gray; //dgvPrincipal.Columns[i - 1].DefaultCellStyle.BackColor;
                }
                //
                for (int i = 0; i < dgvPrincipal.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPrincipal.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvPrincipal.Rows[i].Cells[j].Value.ToString();
                        //XcelApp.Cells[i + 2, j + 1].EntireRow.Interior.Color = dgvPrincipal.Rows[i].Cells[j].Style.BackColor;
                    }
                }
                //
                XcelApp.Columns.AutoFit();
                //
                XcelApp.Visible = true;
            }
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {

        }
    }
}
