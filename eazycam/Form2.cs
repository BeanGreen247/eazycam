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
            string cameraname = File.ReadAllText("cameras.txt");
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
            {
                if (Device.Name == cameraname)
                {
                    cameraname = Device.Name;
                }
            }
                //videoCaptureDevice = new VideoCaptureDevice(cameraname);
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
            videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            //videoCaptureDevice.DesiredFrameRate = 30;
            videoCaptureDevice.Start();
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
        }
    }
}
