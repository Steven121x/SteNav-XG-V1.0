using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace SteNav
{
    public partial class Form1 : Form
    {
        public WebBrowser Browser12;
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Visible = false;
            AutoSize.ToString();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Update();

            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE8KeyforWebBrowserControl(appName);

        }

        private void SetIE8KeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit machine
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                // If the path is not correct or
                // if the user haven't priviledges to access the registr
                if (Regkey == null)
                {
                    MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == "8000")
                {
                    MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                // If a key is not present add the key, Key value 8000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "8000")
                    MessageBox.Show("Application Settings Applied Successfully");
                else
                    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Settings Failed");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the Registr
                if (Regkey != null)
                    Regkey.Close();
            }
        }
        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void btnIr_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate(btnIr.Text.ToString());//Buscar 
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void btnIr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Visible = true;
                webBrowser1.Navigate($"https://www.google.com/search?q={btnIr.Text}");
            
            

            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
            webBrowser1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate("https://www.google.com/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate("https://www.facebook.com/"); 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate("https://www.instagram.com/"); 
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate("https://web.whatsapp.com/"); 
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate("https://www.youtube.com/");
        }

        private void btnIr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnIr2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate($"https://www.google.com/search?q={btnIr2.Text}");
                webBrowser1.Visible = true;
            }
        }

        private void webBrowser1_DocumentCompleted_3(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
