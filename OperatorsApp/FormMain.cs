using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ProjectsReport
{
    public partial class Form1 : Form
    {
        DataTable projects = new DataTable();
        FormReport dialog = new FormReport();
        TeplateList templateList = new TeplateList();

        public Form1()
        {
            InitializeComponent();
            gNewProgects.AutoGenerateColumns = false;
            gOldProgects.AutoGenerateColumns = false;
            gNewProgects.DataSource = new BindingSource() { DataSource = new DataView(projects) };
            gOldProgects.DataSource = new BindingSource() { DataSource = new DataView(projects) };
        }


        string showReport(string contractInfo, string paramTemplate, string paramValue)
        {
            dialog.initDialog(contractInfo, paramTemplate, paramValue);
            dialog.ShowDialog();
            return string.Empty;
        }

        void tsUpdate_Click(object sender, EventArgs e)
        {
            (gNewProgects.DataSource as BindingSource).RemoveFilter();
            (gOldProgects.DataSource as BindingSource).RemoveFilter();
            fillProjects(projects);
            projects.AcceptChanges();
            (gNewProgects.DataSource as BindingSource).Filter = "report = 0";
            (gOldProgects.DataSource as BindingSource).Filter  = "report = 1";
            addColumns(gOldProgects);
            hideServiseColumn(gOldProgects);
            addColumns(gNewProgects);
            hideServiseColumn(gNewProgects);
        }

        void hideServiseColumn(DataGridView dgv)
        {
            string[] columns = new string[]
                {"ContractId","ActivityId","ContactWithId"};
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.Visible = (!columns.Contains(column.Name));
            }
        }


        void addColumns(DataGridView grid)
        {
            grid.Columns.Clear();
            foreach (DataColumn column in projects.Columns)
            {
                object textColumn;
                if (column.DataType.Equals(typeof(bool)))
                {
                    textColumn = new DataGridViewCheckBoxColumn()
                    {
                        DataPropertyName = column.ColumnName,
                        HeaderText = column.ColumnName,
                        Name = column.ColumnName
                    };
                    grid.Columns.Add((textColumn as DataGridViewCheckBoxColumn));
                }
                else if (column.ColumnName == "ContractNum")
                {
                    textColumn = new DataGridViewButtonColumn()
                    {
                        DataPropertyName = column.ColumnName,
                        HeaderText = column.ColumnName,
                        Name = column.ColumnName
                    };
                    grid.Columns.Add((textColumn as DataGridViewButtonColumn));
                }
                else
                {
                    textColumn = new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = column.ColumnName,
                        HeaderText = column.ColumnName,
                        Name = column.ColumnName
                    };
                    grid.Columns.Add((textColumn as DataGridViewTextBoxColumn));
                }
            }
        }

        void fillProjects(DataTable _projects)
        {
            testData.fillProjects(_projects);
        }

        private void gNewProgects_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            gHightLightChanged((sender as DataGridView), e.RowIndex, e.CellStyle);
        }

        private void gOldProgects_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            gHightLightChanged((sender as DataGridView), e.RowIndex, e.CellStyle);
        }


        void gHightLightChanged(DataGridView dvg, int i, DataGridViewCellStyle CellStyle)
        {
            if (i < 0) return;

            DataRowView dr = dvg.Rows[i].DataBoundItem as DataRowView;
            if (dr.Row.RowState != DataRowState.Unchanged)
            {
                CellStyle.BackColor = Color.YellowGreen;
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projects.AcceptChanges();
        }

        private void gNewProgects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dvg = (DataGridView)sender;

            if (dvg.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int row = e.RowIndex;
                DataRowView dr = dvg.Rows[row].DataBoundItem as DataRowView;
                DataGridViewCell contactReport = dvg.Rows[row].Cells["RepordDesc"];
                dialog.initDialog(testData.ContractInfoInit, testData.Tmpl, contactReport.Value.ToString());  
                dialog.ShowDialog();
                if (dialog.result != string.Empty)
                {
                    contactReport.Value = dialog.result;
                    dvg.Rows[row].Cells["report"].Value = true;
                }
                dr.EndEdit();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Close();
        }
    }

}
