using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;


namespace ProjectsReport
{
    public partial class FormReport : Form
    {

        Binding[] bindings;

        DataSet valuesTable = new DataSet();
        DataTable values;
        Parameters valuesList;

        const string TableName = "Values";

        public FormReport(string contractInfo, string paramTemplate,string paramValue)
        {
            InitializeComponent();
            webContractInfo.DocumentText = contractInfo;
            valuesList = new Parameters(paramTemplate,paramValue);
            valuesList.Table.TableName = TableName;
            valuesTable.Tables.Add(valuesList.Table);
            values = valuesTable.Tables[TableName];
            initValues();
        }

        void initValues()
        {
            TableLayoutPanel panel = paramTable;
            foreach (Paramerer value in valuesList)
            {
                panel.RowCount = panel.RowCount + 1;
                MaskedTextBox curBox = new MaskedTextBox() { Dock = DockStyle.Bottom, Mask = value.Mask };
                curBox.DataBindings.Add(new Binding("Text", value, "Value"));
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
                panel.Controls.Add(new Label() { Text = value.ShortName, Dock = DockStyle.Top }, 0, panel.RowCount - 1);
                panel.Controls.Add(curBox, 1, panel.RowCount - 1);
            }
            panel.RowCount = panel.RowCount + 1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        class Test {
            public int номер { set; get; }
            public string str { set; get; }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            setTexBoxState(false);
            foreach (Paramerer value in valuesList)
            {
                message += $"\r\n{value.ShortName} -- {value.Value}";
            }
            setTexBoxState(true);
            MessageBox.Show(message);
        }

        void setTexBoxState(bool state)
        {
            foreach (Control control in paramTable.Controls)
            {
                if (control is MaskedTextBox)
                {
                    control.Enabled = state;
                }
            }
        }

    }
}
