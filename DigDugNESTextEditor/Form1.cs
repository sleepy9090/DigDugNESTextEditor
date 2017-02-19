using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigDugNESTextEditor {
    public partial class Form1_DigDug : Form {
        public Form1_DigDug() {
            InitializeComponent();
        }

        private void buttonOpenROM_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK) {
                textBoxAbsoluteFilename.Text = ofd.FileName;

                clearTextBoxes();
                readRomText();
            }
        }

        private void clearTextBoxes() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        private void readRomText() {
            try {
                string absoluteFilename = textBoxAbsoluteFilename.Text;

                Backend backend = new Backend();

                backend.getText(absoluteFilename, textBox1, 0x5, 0x74C);
                backend.getText(absoluteFilename, textBox2, 0x3, 0x7CE);
                backend.getText(absoluteFilename, textBox3, 0x3, 0x7D3);
                backend.getText(absoluteFilename, textBox4, 0x5, 0x923);
                backend.getText(absoluteFilename, textBox5, 0x3, 0xC91);
                backend.getText(absoluteFilename, textBox6, 0x5, 0xC97);
                backend.getText(absoluteFilename, textBox7, 0x3, 0xC9F);
                backend.getText(absoluteFilename, textBox8, 0x5, 0xCA5);
                backend.getText(absoluteFilename, textBox9, 0x8, 0xD06);
                backend.getText(absoluteFilename, textBox10, 0x8, 0xD8A);
                backend.getText(absoluteFilename, textBox11, 0x9, 0xD95);
                backend.getText(absoluteFilename, textBox12, 0x16, 0xDAC);
                backend.getText(absoluteFilename, textBox13, 0x13, 0xDC5);
                backend.getText(absoluteFilename, textBox14, 0x3, 0xD00);
                backend.getText(absoluteFilename, textBox15, 0x3, 0xD11);

                enableButtons();
                enableMenuItems();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enableButtons() {
            buttonUpdateText.Enabled = true;
        }

        private void enableMenuItems() {
            updateTextToolStripMenuItem.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void openROMToolStripMenuItem_Click(object sender, EventArgs e) {
            buttonOpenROM_Click(sender, e);
        }

        private void buttonUpdateText_Click(object sender, EventArgs e) {

            try {
                string absoluteFilename = textBoxAbsoluteFilename.Text;
                Backend backend = new Backend();

                backend.updateROMText(absoluteFilename, 0x5, textBox1, 0x74C);
                backend.updateROMText(absoluteFilename, 0x3, textBox2, 0x7CE);
                backend.updateROMText(absoluteFilename, 0x3, textBox3, 0x7D3);
                backend.updateROMText(absoluteFilename, 0x5, textBox4, 0x923);
                backend.updateROMText(absoluteFilename, 0x3, textBox5, 0xC91);
                backend.updateROMText(absoluteFilename, 0x5, textBox6, 0xC97);
                backend.updateROMText(absoluteFilename, 0x3, textBox7, 0xC9F);
                backend.updateROMText(absoluteFilename, 0x5, textBox8, 0xCA5);
                backend.updateROMText(absoluteFilename, 0x8, textBox9, 0xD06);
                backend.updateROMText(absoluteFilename, 0x8, textBox10, 0xD8A);
                backend.updateROMText(absoluteFilename, 0x9, textBox11, 0xD95);
                backend.updateROMText(absoluteFilename, 0x16, textBox12, 0xDAC);
                backend.updateROMText(absoluteFilename, 0x13, textBox13, 0xDC5);
                backend.updateROMText(absoluteFilename, 0x3, textBox14, 0xD00);
                backend.updateROMText(absoluteFilename, 0x3, textBox15, 0xD11);

                MessageBox.Show("Updated Text!", "DigDug NES Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setMaxLengthOfTextBoxes() {
            textBox1.MaxLength = 0x5;
            textBox2.MaxLength = 0x3;
            textBox3.MaxLength = 0x3;
            textBox4.MaxLength = 0x5;
            textBox5.MaxLength = 0x3;
            textBox6.MaxLength = 0x5;
            textBox7.MaxLength = 0x3;
            textBox8.MaxLength = 0x5;
            textBox9.MaxLength = 0x8;
            textBox10.MaxLength = 0x8;
            textBox11.MaxLength = 0x9;
            textBox12.MaxLength = 0x16;
            textBox13.MaxLength = 0x13;
            textBox14.MaxLength = 0x3;
            textBox15.MaxLength = 0x3;
        }

        private void Form1DigDug_Load(object sender, EventArgs e) {
            setMaxLengthOfTextBoxes();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void updateTextToolStripMenuItem_Click(object sender, EventArgs e) {
            buttonUpdateText_Click(sender, e);
        }
    }
}
