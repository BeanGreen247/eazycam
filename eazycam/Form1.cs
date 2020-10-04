using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Math;
using System.Threading;
using System.Diagnostics;
using CASS.OpenCL;
using CASS.OpenCL.OpenGL;
using System.Runtime.CompilerServices;

namespace eazycam
{
    public partial class Form1 : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //string CameraNameFull = "";
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection) {
                comboBox1.Items.Add(Device.Name);
            }
            if (comboBox1.Items[0] == null)
            {
                radioButton1.Text = "DeviceName";
            }
            else if (comboBox1.Items[0].ToString() != null)
            {
                radioButton1.Text = comboBox1.Items[0].ToString();
            }
            if (comboBox1.Items[1] == null)
            {
                radioButton2.Text = "DeviceName";
            }
            else if (comboBox1.Items[1].ToString() != null)
            {
                radioButton2.Text = comboBox1.Items[1].ToString();
            }
            if (comboBox1.Items[2] == null)
            {
                radioButton3.Text = "DeviceName";
            }
            else if (comboBox1.Items[2].ToString() != null)
            {
                radioButton3.Text = comboBox1.Items[2].ToString();
            }
            //if (comboBox1.Items[3] == null)
            //{
            //    radioButton4.Text = "DeviceName";
            //}
            //else if (comboBox1.Items[3].ToString() != null)
            //{
            //    radioButton4.Text = comboBox1.Items[3].ToString();
            //}
            //if (comboBox1.Items[4] == null)
            //{
            //    radioButton5.Text = "DeviceName";
            //}
            //else if (comboBox1.Items[4].ToString() != null)
            //{
            //    radioButton5.Text = comboBox1.Items[4].ToString();
            //}
            //if (comboBox1.Items[5] == null)
            //{
            //    radioButton6.Text = "DeviceName";
            //}
            //else if (comboBox1.Items[5].ToString() != null)
            //{
            //    radioButton6.Text = comboBox1.Items[5].ToString();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
