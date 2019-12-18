using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void txtNhapten_TextChanged(object sender, EventArgs e)
        {
            lblLapTrinh.Text = txtNhapten.Text;
        }

        private void radGreen_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapten.ForeColor = System.Drawing.Color.Green;
            lblLapTrinh.ForeColor = System.Drawing.Color.Green;
        }

        private void radBlue_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapten.ForeColor = System.Drawing.SystemColors.Highlight;
            lblLapTrinh.ForeColor = System.Drawing.SystemColors.Highlight;
        }

        private void radRed_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapten.ForeColor = System.Drawing.Color.Red;
            lblLapTrinh.ForeColor = System.Drawing.Color.Red;
        }

        private void radBlack_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapten.ForeColor = System.Drawing.Color.Black;
            lblLapTrinh.ForeColor = System.Drawing.Color.Black;
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            updateFont();
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            updateFont();
        }

        private void chkUnderline_CheckedChanged(object sender, EventArgs e)
        {
            updateFont();
        }

        private void updateFont()
        {
            FontStyle bold = chkBold.Checked ? FontStyle.Bold : 0;
            FontStyle italic = chkItalic.Checked ? FontStyle.Italic : 0;
            FontStyle underline = chkUnderline.Checked ? FontStyle.Underline : 0;

            this.txtNhapten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle)(bold|italic|underline), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle)(bold | italic | underline), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
