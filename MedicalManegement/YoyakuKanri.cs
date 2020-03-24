using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalManegement
{
    public partial class YoyakuKanriForm : Form
    {
        private bool frmMode; // モード(true:登録, false:修正)
        private KanjaYoyakuModel model;
        public YoyakuKanriForm(bool mode, KanjaYoyakuModel yoyakumodel)
        {
            #region コンストラクタ
            frmMode = mode;
            model = yoyakumodel;
            InitializeComponent();
            InitYoyakuItems(); 
        }
        #endregion

        #region ウィジェット初期化
        /// <summary> Comboboxの表示・取得値設定、デフォルト表示設定
        private void InitYoyakuItems()
        {
            try
            { 
                string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
                MySqlConnection con = new MySqlConnection(strCon);
                con.Open();

                // データソースの接続
                MySqlDataAdapter daKanja = new MySqlDataAdapter("SELECT * FROM KANJA", con);
                MySqlDataAdapter daSinryoka = new MySqlDataAdapter("SELECT * FROM SINRYOKA", con);
                MySqlDataAdapter daJikantai = new MySqlDataAdapter("SELECT * FROM TIMETABLE", con);
                // データ格納
                DataTable dtKanja = new DataTable();
                daKanja.Fill(dtKanja);
                DataTable dtSinryoka = new DataTable();
                daSinryoka.Fill(dtSinryoka);
                DataTable dtJikantai = new DataTable();
                daJikantai.Fill(dtJikantai);
                // 接続終了
                con.Close();
                // 表示項目と値のセット(値は Listbox.SelectedValue.ToString() で取得可能)
                cmbYoyakuID.DisplayMember = "ID";     // Listboxに表示 ※.ToString("000")で0埋めはできない！
                cmbYoyakuID.ValueMember = "ID";       // ※表示のまま取得
                cmbYoyakuID.DataSource = dtKanja;     // 参照させるDataTableを指定
                cmbYoyakuName.DisplayMember = "氏名";
                cmbYoyakuName.ValueMember = "ID";     // IDと氏名は同じ値を参照させているので連動して動く
                cmbYoyakuName.DataSource = dtKanja;
                cmbSinryoka.DisplayMember = "診療科";
                cmbSinryoka.ValueMember = "管理番号";
                cmbSinryoka.DataSource = dtSinryoka;
                cmbYoyakuTime.DisplayMember = "時間帯";
                cmbYoyakuTime.ValueMember = "管理番号";
                cmbYoyakuTime.DataSource = dtJikantai;
                //dtpの最大値を一年後までに設定
                dtpYoyakuDay.MaxDate = DateTime.Now.Date.AddYears(1); // 最大は一年後までに設定
                if (frmMode)      // 登録モードなら表示の初期化
                {
                    lblTourokuTitle.Text = "予約新規登録フォーム";
                    btnYoyakuTouroku.Text = "新規登録 / 予約票出力";
                    btnYoyakuKensaku.Text = "予約検索 / 削除";
                    cmbYoyakuID.Enabled = true;       // 選択可能にする
                    cmbYoyakuName.Enabled = true;     // 選択可能にする
                    cmbYoyakuID.SelectedIndex = -1;   // 初期表示は空白にしておく
                    cmbYoyakuName.SelectedIndex = -1; // 初期表示は空白にしておく
                    cmbSinryoka.SelectedIndex = 0;    // 初期表示に戻す
                    cmbYoyakuTime.SelectedIndex = 0;  // 初期表示に戻す
                    DateTime minDate = DateTime.Now.Date.AddDays(1);
                    dtpYoyakuDay.MinDate = minDate;   // 新規の予約は今日の日付+1日から選択可能
                    dtpYoyakuDay.Value = minDate;     // 最小値に戻す※
                    // ※minDateよりValueが一秒でも多いとExceptionになるので同じものを代入(DateTime.NowにDateを付けているので問題ないと思うが念のため)
                }
                else if (!frmMode)// 修正モードなら選択した患者のデータをセット
                {
                    lblTourokuTitle.Text = "予約修正登録フォーム";
                    btnYoyakuTouroku.Text = "修正登録 / 予約票出力";
                    btnYoyakuKensaku.Text = "予約一覧に戻る";
                    cmbYoyakuID.Enabled = false;      // 選択不可にする
                    cmbYoyakuName.Enabled = false;    // 選択不可にする
                    cmbYoyakuID.Text = model.Id.ToString();
                    cmbYoyakuName.Text = model.Name;
                    dtpYoyakuDay.Text = model.YoyakuDay;
                    cmbYoyakuTime.Text = model.YoyakuTime;
                    cmbSinryoka.Text = model.Sinryoka;
                    dtpYoyakuDay.MinDate = DateTime.Now; // 予約の修正は今日の日付でも修正可能
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region イベント
        private void btnYoyakuTouroku_Click(object sender, EventArgs e)
        {
            if(frmMode) // 登録モード
            {
                YoyakuTouroku();
            }
            else       // 修正モード
            {
                YoyakuSyusei();
            }
        }
                /// <summary> 予約一覧を表示させる
        private void btnYoyakuKensaku_Click(object sender, EventArgs e)
        {
            if (!frmMode)
            {
                this.Hide();  // フォームが閉じるまで隠しておく
                this.Close(); // フォームを閉じる(frmIchiranが閉じたらクローズされる)
            }
            // 患者一覧・予約一覧で同じフレームを参照するので、boolでモードを渡す(falseは予約モード)
            IchiranKensaku frmIchiran = new IchiranKensaku(false);
            frmIchiran.ShowDialog();

        }
        #endregion

        #region 管理番号取得
        /// <summary> 文字列から管理番号を取得する静的メソッド
        //public static int GetKanriBango(string target, int numMode) // モードでも実行可能だが、モードばかりで定義しても面白みがないので
        public static int GetKanriBango(string target, string sql)    // SQL文の直渡しで取得先を分岐させてみる
        {
            int number = 0;
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                StringBuilder sb = new StringBuilder();
                //string cmdStr;
                //MySqlCommand cmd;
                /*switch (numMode)
                {
                    case 1: // 時間帯モード
                        cmdStr = "SELECT 管理番号 FROM TIMETABLE WHERE 時間帯=@TARGET";
                        cmd = new MySqlCommand(cmdStr, con);
                        break;
                    default: // 診療科モード
                        cmdStr = "SELECT 管理番号 FROM SINRYOKA WHERE 診療科=@TARGET";
                        cmd = new MySqlCommand(cmdStr, con);
                        break;
                }*/
                sb.AppendLine("SELECT 管理番号 FROM");
                sb.AppendLine(sql);
                sb.AppendLine("=@TARGET");
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.Add(new MySqlParameter("@TARGET", target));
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    number = int.Parse(reader[0].ToString());
                }
                // MessageBox.Show($"管理番号：\n{number}"); // DEBUG OK
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー詳細：\n{ex.Message}：\n{ex.InnerException}");
            }
            con.Close();
            return number;
        }
        #endregion

        #region 登録
        private void YoyakuTouroku()
        {
            // ID選択がなければ登録しない
            if (cmbYoyakuID.Text == "")
            {
                MessageBox.Show("受診者IDが選択されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";

            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // INSERT文を作成
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO YOYAKU");
                sb.AppendLine("(患者ID, 予約日, 予約時間, 受診科)");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@ID, @DATE, @TIMETABLE, @SINRYOKA)");
                // @パラメータをリスト化
                List<MySqlParameter> param = new List<MySqlParameter>();
                param.Add(new MySqlParameter("@ID", cmbYoyakuID.SelectedValue));//.ToString())); // ※int型なのでなくてもOK
                param.Add(new MySqlParameter("@DATE", dtpYoyakuDay.Value.ToShortDateString()));
                param.Add(new MySqlParameter("@TIMETABLE", cmbYoyakuTime.SelectedValue));
                param.Add(new MySqlParameter("@SINRYOKA", cmbSinryoka.SelectedValue.ToString()));
                // コマンドを生成し実行
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.AddRange(param.ToArray());
                // 新規登録の前に予約番号のインクリメント値をリセット
                string incrementReset = "ALTER TABLE YOYAKU AUTO_INCREMENT = 1";
                new MySqlCommand(incrementReset, con).ExecuteNonQuery();
                // メッセージボックスの選択内容で分岐(Yesの時だけ登録させる)
                DialogResult result = MessageBox.Show("この内容で登録しますか？", "最終確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();                       // コマンド実行
                    MessageBox.Show("予約をを新規登録しました"); // 処理結果をお知らせ
                    // 予約情報をモデルに格納して予約票フォームに渡す
                    model.Id = int.Parse(cmbYoyakuID.Text);
                    model.Name = cmbYoyakuName.Text;
                    model.Sinryoka = cmbSinryoka.Text;
                    model.YoyakuDay = dtpYoyakuDay.Value.ToShortDateString();
                    model.YoyakuTime = cmbYoyakuTime.Text;
                    // 予約票出力フォームをを呼び出す
                    Yoyakuhyou(model);
                }
                else
                {
                    MessageBox.Show("登録をキャンセルしました");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー詳細：\n{ex.Message}：\n{ex.InnerException}");
            }
            con.Close();
        }
        #endregion

        #region 修正
        private void YoyakuSyusei()
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";

            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // UPDATE文を作成
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("UPDATE YOYAKU");
                sb.AppendLine("SET 予約日=@DATE,");
                sb.AppendLine("    予約時間=@TIMETABLE,");
                sb.AppendLine("    受診科=@SINRYOKA");
                sb.AppendLine("WHERE");
                sb.AppendLine("    患者ID=@MODELID");
                sb.AppendLine("AND 予約日=@MODELDAY");
                sb.AppendLine("AND 予約時間=@MODELTIME");
                sb.AppendLine("AND 受診科=@MODELSINRYOKA");

                // @パラメータをリスト化
                List<MySqlParameter> param = new List<MySqlParameter>();
                param.Add(new MySqlParameter("@DATE", dtpYoyakuDay.Value.ToShortDateString()));
                //TIMETABLEから抽出した時間帯の管理番号を代入
                //param.Add(new MySqlParameter("@TIMETABLE", GetKanriBango(cmbYoyakuTime.Text, 1)));
                param.Add(new MySqlParameter("@TIMETABLE", GetKanriBango(cmbYoyakuTime.Text, "TIMETABLE WHERE 時間帯")));
                //param.Add(new MySqlParameter("@SINRYOKA", GetKanriBango(cmbSinryoka.Text, 2)));
                param.Add(new MySqlParameter("@SINRYOKA", GetKanriBango(cmbSinryoka.Text, "SINRYOKA WHERE 診療科")));
                param.Add(new MySqlParameter("@MODELID", model.Id));
                param.Add(new MySqlParameter("@MODELDAY", model.YoyakuDay));
                //param.Add(new MySqlParameter("@MODELTIME", GetKanriBango(model.YoyakuTime, 1)));
                param.Add(new MySqlParameter("@MODELTIME", GetKanriBango(model.YoyakuTime, "TIMETABLE WHERE 時間帯")));
                //param.Add(new MySqlParameter("@MODELSINRYOKA", GetKanriBango(model.Sinryoka, 2)));
                param.Add(new MySqlParameter("@MODELSINRYOKA", GetKanriBango(model.Sinryoka, "SINRYOKA WHERE 診療科")));

                // コマンドを生成し実行
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.AddRange(param.ToArray());

                // メッセージボックスの選択内容で分岐(Yesの時だけ登録させる)
                DialogResult result = MessageBox.Show("この内容で修正しますか？", "最終確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();                       // コマンド実行
                    MessageBox.Show("予約をを修正登録しました"); // 処理結果をお知らせ
                    // 予約情報をモデルに格納して予約票フォームに渡す
                    model.Id = int.Parse(cmbYoyakuID.Text);
                    model.Name = cmbYoyakuName.Text;
                    model.Sinryoka = cmbSinryoka.Text;
                    model.YoyakuDay = dtpYoyakuDay.Text;
                    model.YoyakuTime = cmbYoyakuTime.Text;
                    // 予約票出力フォームをを呼び出す
                    Yoyakuhyou(model);
                }
                else
                {
                    MessageBox.Show("修正をキャンセルしました");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー詳細：\n{ex.Message}：\n{ex.InnerException}");
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 予約票発行
        /// <summary> 登録後に自動呼出で表示させ、予約内容を印刷するかダイアログで確認する
        /// <param name="model">予約情報を格納したクラス</param>
        private void Yoyakuhyou(KanjaYoyakuModel model)
        {
            // 
            YoyakuhyouForm frmhyou = new YoyakuhyouForm(model);
            frmhyou.ShowDialog();
            if (frmMode) // 登録モード
            {
                InitYoyakuItems(); // 予約フォームは初期化する
            }
            else         // 修正モード
            {
                this.Hide();  // フォームが閉じるまで隠しておく
                this.Close(); // フォームを閉じる(frmhyouが閉じたらクローズされる)
                IchiranKensaku frmIchiran = new IchiranKensaku(false);
                frmIchiran.ShowDialog();
            }
        }
        #endregion
    }
}
