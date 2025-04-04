using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;


namespace WordMemorizer.Core
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine();
            // "Warm.ssk";//"MacOS.ssk";//"XPSilver.ssk";// "EmeraldColor1.ssk";//"MidsummerColor3.ssk";
            // Emerald /DiamondBlue/ Page
            // Calmness  /  SteelBlack
            string skinName = "SteelBlack";
            skin.SkinFile = System.Environment.CurrentDirectory + "\\skins\\" + skinName + ".ssk";
            skin.Active = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            var synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new CultureInfo("pt-PT")); // 葡萄牙葡萄牙语
                                                                                                             // 或
                                                                                                             // synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new CultureInfo("pt-BR")); // 巴西葡萄牙语
            synthesizer.Speak("Olá, como você está?");
        }

        private void BtnSetWeek_Click(object sender, EventArgs e)
        {
            FormAddWeek formAddWeek = new FormAddWeek();
            formAddWeek.ShowDialog();
        }
    }
}
