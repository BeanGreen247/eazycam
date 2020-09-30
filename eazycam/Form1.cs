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
            string CameraNameFull = "";
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection) {
                comboBox1.Items.Add(Device.Name);
                if (Device.Name == "FaceCam 1000X")
                {
                    CameraNameFull = Device.Name;
                }
                //CameraNameFull = Convert.ToString(Device.Name);
            }
            File.WriteAllText("cameras.txt", CameraNameFull);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Website: beangreen247.github.io" + "\n" +
                            "Thomas Mozdren Software Development" + "\n" +
                            "mozdrent@gmail.com" + "\n" +
                            "Copyright © beangreen247.github.io 2020" + "\n" +
                            "Versio: 1.0.0", "About");
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
