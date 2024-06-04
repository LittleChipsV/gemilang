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
using Gemilang.Models;
using Gemilang.Data;

namespace Gemilang.Views.Pages
{
    public partial class PagePrintNilai : UserControl
    {
        public PagePrintNilai()
        {
            InitializeComponent();

            SetStyleDataGridView();

            labelUsername.Focus();
        }

        public void SetLabels(string username, string kelas, string subjek)
        {
            labelUsername.Text = username;
            labelKelas.Text = kelas;
            labelSubjek.Text = subjek;
        }

        public void SetDataGridView(List<Nilai.NilaiPrintDTO> data)
        {
            dataGridView.DataSource = data;
        }

        private void SetStyleDataGridView()
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.BackgroundColor = Color.White;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 255);

            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11);

            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
