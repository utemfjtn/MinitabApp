﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestOnly {
    public partial class Form1 : Form {
        internal static Mtb.Application gMtbApp;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            gMtbApp = new Mtb.Application();
            foreach(string item in Enum.GetNames(typeof(Mtb.MtbOutputFileTypes))) {
                cB_DefaultOutputFileType.Items.Add(item);
            }
            cB_DefaultOutputFileType.SelectedItem = gMtbApp.Options.DefaultOutputFileType.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                gMtbApp.Options.DefaultOutputFileType = (Mtb.MtbOutputFileTypes)Enum.Parse(typeof(Mtb.MtbOutputFileTypes),cB_DefaultOutputFileType.SelectedItem.ToString());
            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
