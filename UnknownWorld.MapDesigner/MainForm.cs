using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnknownWorld.Maker.World;

namespace UnknownWorld.MapDesigner
{
    public partial class MainForm : Form
    {
        int width, height;
        private List<int> cells = new List<int>();
        private string openedFile = "Untitled.map";
        private bool isOpened = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellEndEdit += CellEdit;
            UpdateTitle();
        }

        void UpdateTitle()
        {
            this.Text = "UnknownWorld.MapDesigner - " + openedFile;
        }

        private void CellEdit(object sender, DataGridViewCellEventArgs e)
        {
            var c = e.ColumnIndex;
            var r = e.RowIndex;

            var value = dataGridView1[c, r].Value.ToString();

            if (!String.IsNullOrEmpty(value.Trim()))
            {
                cells[height * c + r] = Int32.Parse(value);

                dataGridView1[c, r].Value = Cell.CellSymbol[cells[height * c + r]];
            }

            dataGridView1.AutoResizeColumn(c);
        }

        void CreateRowsColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < width; i++)
            {
                dataGridView1.Columns.Add("c" + i, "");
            }
            for (int i = 0; i < height; i++)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < width; i++)
            {
                dataGridView1.AutoResizeColumn(i);
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AllowDrop = false;

        }

        void SetCells()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dataGridView1[j, i].Value = Cell.CellSymbol[cells[height * j + i]];

                    dataGridView1.AutoResizeColumn(j);
                }
            }
        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newMap = new WidthHeightForm();
            if (newMap.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(newMap.Controls["textBox1"].Text.Trim()) && !String.IsNullOrEmpty(newMap.Controls["textBox2"].Text.Trim()))
                {
                    width = Int32.Parse(newMap.Controls["textBox1"].Text);
                    height = Int32.Parse(newMap.Controls["textBox2"].Text);

                    cells = new List<int>();
                    for (int i = 0; i < width * height; i++)
                    {
                        cells.Add(0);
                    }

                    CreateRowsColumns();

                    SetCells();

                    dataGridView1.ReadOnly = false;
                    dataGridView1.Refresh();

                    isOpened = false;
                    openedFile = "Untitled.map";
                }
                else
                {
                    MessageBox.Show("Error: You must provide width and height.");
                }
            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Map Files (*.map)|*.map",
                FilterIndex = 0,
                FileName = openedFile,
                RestoreDirectory = true,
                OverwritePrompt = true
            };

            if (!isOpened)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((stream = sfd.OpenFile()) != null)
                        {
                            using (stream)
                            {
                                BinaryWriter bw = new BinaryWriter(stream);
                                bw.Write("UnknownWorld.MapFile");
                                bw.Write(Convert.ToInt16(width));
                                bw.Write(Convert.ToInt16(height));

                                foreach (var cell in cells)
                                {
                                    bw.Write(Convert.ToInt16(cell));
                                }

                                bw.Close();

                                isOpened = true;
                                openedFile = sfd.FileName;

                                UpdateTitle();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Complete Error message : " + ex.Message);
                    }
                }
            }
            else
            {
                stream = new FileStream(openedFile, FileMode.Create);
                if (stream != null)
                {
                    using (stream)
                    {
                        BinaryWriter bw = new BinaryWriter(stream);
                        bw.Write("UnknownWorld.MapFile");
                        bw.Write(Convert.ToInt16(width));
                        bw.Write(Convert.ToInt16(height));

                        foreach (var cell in cells)
                        {
                            bw.Write(Convert.ToInt16(cell));
                        }

                        bw.Close();
                    }
                }
            }
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Map Files (*.map)|*.map|All Files (*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = opf.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            BinaryReader br = new BinaryReader(stream);
                            var authenticity = br.ReadString();

                            if (authenticity == "UnknownWorld.MapFile")
                            {
                                width = br.ReadInt16();
                                height = br.ReadInt16();

                                cells = new List<int>();
                                for (int i = 0; i < width * height; i++)
                                {
                                    cells.Add(br.ReadInt16());
                                }

                                UpdateGrid();
                                br.Close();

                                openedFile = opf.FileName;
                                isOpened = true;

                                UpdateTitle();
                            }
                            else
                            {
                                MessageBox.Show("Error: This is not a valid UnknownWorld.Map");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Complete Error message : " + ex.Message);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateGrid()
        {
            CreateRowsColumns();
            
            SetCells();

            dataGridView1.ColumnHeadersHeight = 4;
            dataGridView1.RowHeadersWidth = 4;

            dataGridView1.ReadOnly = false;
            dataGridView1.Refresh();
        }
    }
}
