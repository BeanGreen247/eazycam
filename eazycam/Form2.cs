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

namespace eazycam
{
    public partial class Form2 : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public Form2()
        {
            Threads();
            InitializeComponent();
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
        }
        public void Threads()
        {
            Process.GetCurrentProcess().Threads[0].ProcessorAffinity = (IntPtr)1;
            Process.GetCurrentProcess().Threads[1].ProcessorAffinity = (IntPtr)2;
            Process.GetCurrentProcess().Threads[2].ProcessorAffinity = (IntPtr)3;
            Process.GetCurrentProcess().Threads[3].ProcessorAffinity = (IntPtr)4;
        }
        public VideoCapabilities VideoResolution { get; set; }
        public void Form2_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Form1 fm1 = new Form1();
            if (fm1.radioButton1.Checked == true)
            {
                if (fm1.radioButton1.Text== "DeviceName")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                }
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            if (fm1.radioButton2.Checked == true)
            {
                if (fm1.radioButton2.Text == "DeviceName")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                }
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[1].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            if (fm1.radioButton3.Checked == true)
            {
                if (fm1.radioButton3.Text == "DeviceName")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                }
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[2].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            if (fm1.radioButton4.Checked == true)
            {
                if (fm1.radioButton4.Text == "DeviceName")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                }
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[3].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            if (fm1.radioButton5.Checked == true)
            {
                if (fm1.radioButton5.Text == "DeviceName")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                }
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[4].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            if (fm1.radioButton6.Checked == true)
            {
                if (fm1.radioButton6.Text == "DeviceName")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                }
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[5].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            else
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();
            }
            //videoCaptureDevice.DesiredFrameRate = 30;
        }
        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ResizeBicubic filter = new ResizeBicubic(328, 275);
            Bitmap newImage = filter.Apply((Bitmap)eventArgs.Frame.Clone());
            pictureBox1.Image = newImage;
            //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        public void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
            else
                videoCaptureDevice.Stop();
                //Application.Exit();
        }
    }
}
