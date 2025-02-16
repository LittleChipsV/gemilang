﻿using Gemilang.Data;
using Gemilang.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gemilang.Views.Pages
{
    public partial class PageDashboard : UserControl
    {
        public PageDashboard()
        {
            InitializeComponent();

            var gemilangDbContext = new GemilangDbContext();

            labelTotalGuru.Text = gemilangDbContext.Guru.Count().ToString();
            labelTotalSiswa.Text = gemilangDbContext.Siswa.Count().ToString();
            labelTotalMapel.Text = gemilangDbContext.MataPelajaran.Count().ToString();
            labelTotalKelas.Text = gemilangDbContext.Kelas.Count().ToString();
        }
    }
}
