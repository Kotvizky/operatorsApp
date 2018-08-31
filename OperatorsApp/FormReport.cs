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

        Parameters valuesList;

        public string result;

        public FormReport()
        {
            InitializeComponent();
        }

        public void initDialog(string contractInfo, string paramTemplate, string paramValue, string title)
        {
            this.Text = title;
            webContractInfo.DocumentText = contractInfo;
            valuesList = new Parameters(paramTemplate, paramValue);
            initValues();
        }

        void initValues()
        {

            result = string.Empty;

            TableLayoutPanel panel = paramTable;
            panel.Controls.Clear();
            panel.RowCount = 0;
            foreach (Props value in valuesList)
            {
                panel.RowCount = panel.RowCount + 1;
                MaskedTextBox curBox = new MaskedTextBox() { Dock = DockStyle.Bottom, Mask = value.Mask };
                curBox.DataBindings.Add(new Binding("Text", value, "Value"));
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
                panel.Controls.Add(new Label()
                {
                    Text = (value.LongName != null) ? value.LongName : value.ShortName,
                    Dock = DockStyle.Top
                }, 0, panel.RowCount - 1);
                panel.Controls.Add(curBox, 1, panel.RowCount - 1);
            }
            panel.RowCount = panel.RowCount + 1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Save(object sender, EventArgs e)
        {
            saveValues();
            Close();
        }

        void saveValues()
        {
            setTexBoxState(false);
            result = valuesList.JsonValues;
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

        private void FormReport_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    saveValues();
                    this.Close();
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Escape:
                    this.Close();
                    return false;
                case Keys.Enter:
                    saveValues();
                    this.Close();
                    return false;
            }
            return false;
        }

    }
}
