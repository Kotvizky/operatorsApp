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

        FormReport dialog;

        public Form1()
        {
            InitializeComponent();
            showReport();

            return;

            gNewProgects.AutoGenerateColumns = false;
            gOldProgects.AutoGenerateColumns = false;
            gNewProgects.DataSource = new BindingSource() { DataSource = new DataView(projects) };
            gOldProgects.DataSource = new BindingSource() { DataSource = new DataView(projects) };
        }

        #region dialogInit

        string contractInfoInit = @"
<html>
    <head>
    </head>
    <body>
    <h1>Number</h1>
    <h1>FIO</h1>
    </body>
</html>
";

        string questionInit = @"
";


        #endregion

        void showReport()
        {

            string contractInfo = contractInfoInit;

            if (dialog == null)
            {
                dialog = new FormReport(contractInfo, testData.Tmpl, testData.Values);
            }

            dialog.ShowDialog();
        }

        void tsUpdate_Click(object sender, EventArgs e)
        {

            (gNewProgects.DataSource as BindingSource).RemoveFilter();
            (gOldProgects.DataSource as BindingSource).RemoveFilter();
            fillProgects(projects);
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

        void fillProgects(DataTable _projects)
        {
            //DataTable _projects = projects;

            _projects.Clear();
            _projects.Columns.Clear();
            _projects.AcceptChanges();

            string[] columns = new string[] {
                    "ContractNum", "ExecuteDate" ,
                    "contractDesc ", "operatorDesc" ,
                    "Login", "ContractId", "ActivityId" ,
                    "report","ContactWithId"
            };

            foreach (string name in columns)
            {
                if (name.Contains("Id"))
                {
                    _projects.Columns.Add(name, typeof(int));
                }
                else if(name == "report")
                {
                    _projects.Columns.Add(name, typeof(bool));
                }
                else
                {
                    _projects.Columns.Add(name,typeof(string));
                }
            }

            _projects.Rows.Add(new object[]{
                "Р99.204.70904","2018-07-26 08:53:41.610","Доступен ДС : 1. Сума сплати (для клієнта) – 2 274,77 ; 2. Сума оплати для 3-ї особи (поручителя) – 3 101,31 ; 3. Дисконт 5 (для клієнта) – 568,6",
                null,"SKharchenko",48448969,222871955,true,6
            });

            _projects.Rows.Add(new object[]{
                "P32.198.71862","2018-07-26 12:56:51.007",
                "Доступен ДС : 1. Сума сплати (для клієнта) – 1 897,61 ; 2. Сума оплати для 3-ї особи (поручителя) – 2 587,11 ; 3. Дисконт 5 (для клієнта) – 474,4",
                "бывший муж саша ","DIefimchuk",48445159,222961868,0,6
            });

            _projects.Rows.Add(new object[]{
                "Л69.188.30314","2018-07-26 13:00:21.557","Доступен ДС : 1. Сума сплати (для клієнта) – 7 501,04 ; 2. Сума оплати для 3-ї особи (поручителя) – 10 226,57 ; 3. Дисконт 5 (для клієнта) – 1 875,2",
                "бывший муж Антон 0953294553","DIefimchuk",48492773,222963954,0,6
            });

            _projects.Rows.Add(new object[]{
                "Z37.546.70024","2018-07-26 17:22:21.863","Доступен ДС : 1. Сума сплати (для клієнта) – 8 828,83 ; 2. Сума оплати для 3-ї особи (поручителя) – 12 036,82 ; 3. Дисконт 5 (для клієнта) – 2 207,2",
                "не общ","DVolkova",48891690,223094133,0,6
            });

            _projects.Rows.Add(new object[]{
                "P25.030.74775","2018-07-26 17:26:15.037","Доступен ДС : 1. Сума сплати (для клієнта) – 25 691,14 ; 2. Сума оплати для 3-ї особи (поручителя) – 35 026,11 ; 3. Дисконт 5 (для клієнта) – 6 422,7",
                null,"DVolkova",48744510,223095770,0,6
            });
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
                MessageBox.Show(dr["ContractId"].ToString());
                dvg.Rows[row].Cells["report"].Value = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Close();
        }
    }

    static class dataPrepare
    {



    }

    //TODO create form with Data from the contract
}
