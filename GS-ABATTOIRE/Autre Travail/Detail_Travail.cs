﻿using GS_ABATTOIRE.Gestion_Des_Achats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Autre_Travail
{
    public partial class Detail_Travail : Form
    {
        List<String> data = new List<string>();
        public Detail_Travail(int id )
        {
            InitializeComponent();
            data = DataTravail.GetTravail(id);
            bunifuDatePicker1.Value = DateTime.Parse(data[11].ToString());
            bunifuTextBox2.Text = data[2];
            bunifuTextBox3.Text = data[3];
            bunifuTextBox1.Text = (double.Parse(bunifuTextBox2.Text) + double.Parse(bunifuTextBox3.Text)).ToString();
            bunifuTextBox4.Text = data[5];
            bunifuTextBox5.Text = (double.Parse(bunifuTextBox4.Text) * double.Parse(bunifuTextBox3.Text)).ToString();
            bunifuTextBox6.Text = data[4];
            bunifuTextBox6.Text = data[6];
            bunifuTextBox8.Text = (double.Parse(bunifuTextBox6.Text) * double.Parse(bunifuTextBox7.Text)).ToString();
            bunifuTextBox15.Text = data[16];
            bunifuTextBox16.Text = data[17];
            bunifuTextBox17.Text = (double.Parse(bunifuTextBox15.Text) * double.Parse(bunifuTextBox16.Text)).ToString();
            bunifuTextBox14.Text = (double.Parse(bunifuTextBox5.Text) + double.Parse(bunifuTextBox8.Text) + double.Parse(bunifuTextBox17.Text)).ToString();
            bunifuTextBox9.Text = data[8];
            bunifuTextBox10.Text = data[7];
            bunifuTextBox11.Text = data[9];
            bunifuTextBox12.Text = (double.Parse(bunifuTextBox10.Text) - double.Parse(bunifuTextBox11.Text)).ToString();
            bunifuTextBox13.Text = data[14];
            bunifuTextBox19.Text = data[15];
            bunifuTextBox20.Text = data[12];
            bunifuTextBox21.Text = data[13];
            bunifuTextBox22.Text = (double.Parse(bunifuTextBox10.Text) + Double.Parse(bunifuTextBox20.Text) + double.Parse(bunifuTextBox21.Text)).ToString();
           



        }

        private void Detail_Travail_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox21_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
