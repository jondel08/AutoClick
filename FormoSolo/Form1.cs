using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AutoClick
{
    public partial class Form1 : Form
    {
        #region Variables
        MessageBoxTemporal mBT = new MessageBoxTemporal();
        private Timer timer;
        private int tiempoSeg;
        #endregion

        #region Constructor
        public Form1() {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void Form1_Load(object sender, EventArgs e) {

        }

        //private void btn_Click(object sender, EventArgs e) {
        //    tiempoSeg = Convert.ToInt32(txt_time.Text.Trim());
        //    mBT.Show("Contando...", "Auto \"Click\"", tiempoSeg, true);
        //    Thread.Sleep(3000);
        //    btn.PerformClick();
        //}

        /// <summary>
        /// Click del botón "Iniciar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e) {
            btn.Enabled = false;
            //tiempoSeg = Convert.ToInt32(txt_time.Text.Trim());
            tiempoSeg = ValidateTime();
            mBT.Show("Contando...", "Auto \"Click\"", tiempoSeg, true);
            timer = new Timer();
            timer.Interval = ValidatePause() * 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            btn.Enabled = true;
        }

        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e) {
            timer.Stop();
            btn.PerformClick();
        }

        /// <summary>
        /// Valida el dato del campo "tiempo"
        /// </summary>
        /// <returns></returns>
        private int ValidateTime() {
            try {
                if (Convert.ToInt32(txt_time.Text.Trim()) <= 0 || String.IsNullOrEmpty(txt_time.Text.Trim())) {
                    MessageBox.Show("Tiempo: valor inválido. Se agrega valor default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_time.Text = "20";
                    return 20;
                }
                else {
                    return Convert.ToInt32(txt_time.Text.Trim());
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Tiempo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_time.Text = "20";
                return 20;
            }

        }

        /// <summary>
        /// Valida el dato del campo "pausa"
        /// </summary>
        /// <returns></returns>
        private int ValidatePause() {
            try {
                if (Convert.ToInt32(txtPause.Text.Trim()) <= 0 || String.IsNullOrEmpty(txtPause.Text.Trim())) {
                    MessageBox.Show("Pausa: valor inválido. Se agrega valor default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPause.Text = "15";
                    return 15;
                }
                else {
                    return Convert.ToInt32(txtPause.Text.Trim());
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Pausa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPause.Text = "15";
                return 15;
            }
        }
        #endregion

    }//EndClass
}//EndNamespace
