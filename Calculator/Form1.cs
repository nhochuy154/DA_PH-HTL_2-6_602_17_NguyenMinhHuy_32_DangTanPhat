using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nunit_17_Huy_32_Phat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtkq.Enabled = false; 
            txtpt.Enabled = false;
            txtsnt.Enabled = false;
        }
        
        private void btncong_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            //Phép cộng
            int a, b, ketqua;
            a = int.Parse(txt1.Text);
            b = int.Parse(txt2.Text);
            Calculation_17_32 c = new Calculation_17_32(a, b);
            ketqua = c.Execute("+");
            txtkq.Text = ketqua.ToString();
        }

        private void btntru_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            //Phép trừ
            int a, b, ketqua;
            a = int.Parse(txt1.Text);
            b = int.Parse(txt2.Text);
            Calculation_17_32 c = new Calculation_17_32(a, b);
            ketqua = c.Execute("-");
            txtkq.Text = ketqua.ToString();
        }

        private void btnnhan_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            //Phép nhân
            int a, b, ketqua;
            a = int.Parse(txt1.Text);
            b = int.Parse(txt2.Text);
            Calculation_17_32 c = new Calculation_17_32(a, b);
            ketqua = c.Execute("*");
            txtkq.Text = ketqua.ToString();
        }

        private void btnchia_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            //Phép chia
            int a, b;
            int ketqua;
            a = int.Parse(txt1.Text);
            b = int.Parse(txt2.Text);
            Calculation_17_32 c = new Calculation_17_32(a, b);
            ketqua = c.Execute("/");
            txtkq.Text = ketqua.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pt2_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            float a = float.Parse(txta.Text);
            float b = float.Parse(txtb.Text);
            float c = float.Parse(txtc.Text);
            string ketqua = Giaipt_17_32.giaiB2(a, b,c);
            txtpt.Text = ketqua;

        }

        private void pt1_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            float a = float.Parse(txta.Text); 
            float b = float.Parse(txtb.Text);

            string ketqua = Giaipt_17_32.giaiB1(a, b);
            txtpt.Text = ketqua;
        }

        private void btnsnt_Click(object sender, EventArgs e)
        {
            int a= int.Parse(txtso.Text);

            string ketqua = Songuyento_17_32.Songuyento_17_Huy_32_Phat(a);
            txtsnt.Text = ketqua;
        }

        private void btnlamlai1_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txtkq.Text = "";
        }

        private void btnlamlai2_Click(object sender, EventArgs e)
        {
            txta.Text = "";
            txtb.Text = "";
            txtc.Text = "";
            txtpt.Text = "";
        }

        private void btnlamlai3_Click(object sender, EventArgs e)
        {
            txtso.Text = "";
            txtsnt.Text = "";
        }
    }
}
