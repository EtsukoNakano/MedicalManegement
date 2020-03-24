using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MedicalManegement
{
    public partial class StartMenuForm : Form
    {
        // 受診者管理・予約管理には空のモデルクラスを生成して渡す(修正モードで開くときにモデルクラスを参照させたいので)
        KanjaYoyakuModel model = new KanjaYoyakuModel();
        #region コンストラクタ
        public StartMenuForm()
        {
            InitializeComponent();
            /// 患者が1人も登録されていない場合は予約管理ボタンを無効にする
            if (CheckExistKanja()) // 患者がいる
            {
                btnYoyakuKanri.Enabled = true;
            }
            else                   // 患者がいない
            {
                btnYoyakuKanri.Enabled = false;
            }
        }
        #endregion

        #region 患者登録数確認
        /// <summary> DBに患者が1人でも登録されているか確認する静的メソッド
        /// <returns>患者がいればtrueを、いなければfalseを返す</returns>
        public static bool CheckExistKanja()
        {
            int count = 1;
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                string cmdStr = "SELECT COUNT(ID) FROM KANJA";
                MySqlCommand cmd = new MySqlCommand(cmdStr, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = int.Parse(reader[0].ToString());
                }
                // MessageBox.Show($"{count}"); // DEBUG OK
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー詳細：\n{ex.Message}：\n{ex.InnerException}");
            }
            finally
            {
                con.Close();
            }

            if (count == 0) // 患者が一人も登録されていない
            {
                MessageBox.Show("受診者登録がありません\n新規登録してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else            // 患者登録あり
            {
                return true;
            }
        }
        #endregion

        #region イベント
        /// <summary> 受診者管理ボタン押下
        private void btnJushinsyaKanri_Click(object sender, EventArgs e)
        {
            // デフォルトでは登録モードで呼び出すのでtrueを渡す
            JusinsyaKanriForm frmJusin = new JusinsyaKanriForm(true, model);
            frmJusin.ShowDialog();
        }

        /// <summary> 予約管理ボタン押下
        private void btnYoyakuKanri_Click(object sender, EventArgs e)
        {
            // デフォルトでは登録モードで呼び出すのでtrueを渡す
            YoyakuKanriForm frmYoyaku = new YoyakuKanriForm(true, model);
            frmYoyaku.ShowDialog();
        }
        #endregion

        /*#region 予約票デバッグ用(OKなら消す)
        private void button1_Click(object sender, EventArgs e)
        {
            // DEBUG用の情報を引き渡しておく(出力確認のための定義)
            YoyakuModel model = new YoyakuModel();
            model.Id = 999;
            model.Name = "確　認太郎";
            model.Sinryoka = "泌尿器科";
            model.YoyakuDay = "2XXX/XX/XX";
            model.YoyakuTime = "23:45-00:00";

            YoyakuhyouForm frmhyou = new YoyakuhyouForm(model);
            frmhyou.ShowDialog();
        }
        #endregion*/
    }
}
