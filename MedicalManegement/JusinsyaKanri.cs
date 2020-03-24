using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalManegement
{
    public partial class JusinsyaKanriForm : Form
    {
        private bool mode; // モード(true:登録, false:修正)
        KanjaYoyakuModel model;
        #region コンストラクタ
        public JusinsyaKanriForm(bool frmMode, KanjaYoyakuModel kanjaModel)
        {
            model = kanjaModel;
            mode = frmMode;
            InitializeComponent();
            InitJusinsyaItems();
        }
        #endregion

        #region ウィジェット初期化
        /// <summary> Comboboxの表示・取得値設定、デフォルト表示設定
        private void InitJusinsyaItems()
        {
            // 生年月日の選択範囲を設定
            DateTime maxDate = DateTime.Now.Date;
            dtpBirthday.MaxDate = maxDate; // 誕生日の選択範囲を今日までに設定
            // cmbIDに格納するIDをDBから取得
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM KANJA", con);
            // データをDataTableに格納
            DataTable dtKanja = new DataTable();
            da.Fill(dtKanja);
            con.Close();
            // 表示項目と値をセット(修正モードでも値がないとcombobox.Textで表示できないのでセットが必要)
            cmbID.DisplayMember = "ID";    // 表示する項目名をセット
            cmbID.ValueMember = "ID";      // 実際の値として取得する項目名をセット
            cmbID.DataSource = dtKanja;
            if (mode) // 登録モード
            {
                // 表示の初期化
                cmbID.Enabled = true;          // comboboxの有効化
                cmbID.SelectedIndex = -1;      // 初期表示は空白にしておくため
                cmbGender.SelectedIndex = 0;   // 初期表示は男性にしておくため
                txtName.Text = "";
                dtpBirthday.Value = maxDate;
                txtHokensyo.Text = "";
                txtZipcode.Text = "";
                txtAddress.Text = "";
                txtTel.Text = "";
                txtDoctor.Text = "";
                txtKeika.Text = "";
                btnAny.Text = "受診者一覧を表示";
                btnTouroku.Text = "登録";
            }
            else // 修正モード
            {
                // ウィジェットに選択した患者の情報を表示する
                cmbID.Enabled = false;           // comboboxの無効化
                cmbID.Text = model.Id.ToString();
                txtName.Text = model.Name;
                dtpBirthday.Text = model.Birthday;
                cmbGender.Text = model.Gender;
                txtZipcode.Text = model.Zipcode;
                txtHokensyo.Text = model.Hokensyo;
                txtTel.Text = model.Tel;
                txtDoctor.Text = model.Doctor;
                txtAddress.Text = model.Address;
                txtKeika.Text = model.Keika;
                btnAny.Text = "削除";
                btnTouroku.Text = "修正";
            }
        }
        #endregion

        #region イベント
        /// <summary> 登録/修正ボタン押下処理
        private void btnTouroku_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) // チェック結果がfalseなら
            {
                return;        // 登録・修正せずに戻る
            }

            if (mode) // 登録モード(mode = true)
            {
                //MessageBox.Show("登録処理を行います"); // モード切替確認用(OKならコメントアウト)
                
                Touroku();
            }
            else     // 修正モード(mode = false)
            {
                //MessageBox.Show("修正処理を行います"); // DEBUG OK
                Syusei();
            }
        }

        /// <summary> 一覧表示/削除ボタン押下処理
        private void btnAny_Click(object sender, EventArgs e)
        {
            if (mode) // 登録モード(mode = true)なら患者一覧フォームを表示
            {
                ShowKanjaList();
            }
            else      // 修正モード(mode = false)なら選択した患者を削除する
            {
                Sakujo();
            }
        }
        #endregion

        #region モード変更(IDウィジェットのロストフォーカスイベント)
        /// <summary> IDが選択されたら、患者情報を転記し修正モードに切り替える
        private void cmbID_Leave(object sender, EventArgs e)
        {
            if(cmbID.SelectedItem == null) // 患者IDが選択されていない
            {
                return; // 何もしないで終了
            }
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // データソースの接続
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM KANJA", con);
                // データ格納
                DataTable dtKanja = new DataTable();
                da.Fill(dtKanja);
                // 表示項目と値のセット
                var cmbSI = cmbID.SelectedItem; // 現在選択中の行を取得
                // DataRowで任意の行の各列を配列化して値を取り出す(Row.ItemArray[0]が患者ID)
                DataRowView dataRow = (DataRowView)cmbSI; // 選択行を配列化
                txtHokensyo.Text = dataRow.Row.ItemArray[1].ToString();
                txtName.Text = dataRow.Row.ItemArray[2].ToString();
                //dtpBirthday.Value = DateTime.Parse(dataRow.Row.ItemArray[3].ToString()); // 設定は値をDateTime型に変換して渡す
                dtpBirthday.Text = dataRow.Row.ItemArray[3].ToString(); // Textで渡してもdtpに表示を反映できる
                switch (dataRow.Row.ItemArray[4].ToString())
                {
                    case "男性": cmbGender.SelectedIndex = 0; break;
                    case "女性": cmbGender.SelectedIndex = 1; break;
                    case "その他": cmbGender.SelectedIndex = 2; break;
                }
                txtZipcode.Text = dataRow.Row.ItemArray[5].ToString();
                txtAddress.Text = dataRow.Row.ItemArray[6].ToString();
                txtTel.Text = dataRow.Row.ItemArray[7].ToString();
                txtDoctor.Text = dataRow.Row.ItemArray[8].ToString();
                txtKeika.Text = dataRow.Row.ItemArray[9].ToString();
                // 削除ボタンの有効化と登録ボタンを修正ボタンに切替
                btnAny.Text = "削除";
                btnTouroku.Text = "修正";
                // 修正モードに変更
                mode = false;
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

        #region 入力チェック
        /// <summary> 登録する内容が不正でないか確認する
        /// <returns>結果を真偽値で返す</returns>
        private bool CheckInput()
        {
            bool result = true;
            string msg = "";
            // 必須項目の入力があるか
            if (txtName.Text == "")
            {
                result = false;
                msg += "氏名を入力してください\n";
            }
            //if (txtZipcode.Text == "") // →記号を挟むマスクを設定した場合は空判定できない
            if (!txtZipcode.MaskCompleted) // 必須入力がすべてマスクに入力されたかを真偽値で返す
            {
                result = false;
                msg += "郵便番号を入力してください\n";
            }
            if (txtHokensyo.Text == "")
            {
                result = false;
                msg += "保険証番号を入力してください\n";
            }
            if (txtTel.Text == "")
            {
                result = false;
                msg += "電話番号を入力してください\n";
            }
            if (txtDoctor.Text == "")
            {
                result = false;
                msg += "担当医を入力してください\n";
            }
            if (txtAddress.Text == "")
            {
                result = false;
                msg += "住所を入力してください\n";
            }
            if (txtKeika.Text == "")
            {
                result = false;
                msg += "治療経過を入力してください\n";
            }
            /* 桁数はプロパティのMaxLengthで制御しているので、チェックなしでOK
            // 文字列の桁数は範囲内か
            if (txtName.Text.Length > 20)
            {
                result = false;
                msg += "名前は20文字以内で入力してください\n";
            }
            if (txtZipcode.Text.Length > 10)
            {
                result = false;
                msg += "郵便番号は10文字以内で入力してください\n";
            }
            if (txtHokensyo.Text.Length > 8)
            {
                result = false;
                msg += "保険証番号は8文字以内で入力してください\n";
            }
            if (txtTel.Text.Length > 15)
            {
                result = false;
                msg += "電話番号は15文字以内で入力してください\n";
            }
            if (txtDoctor.Text.Length > 20)
            {
                result = false;
                msg += "担当医は20文字以内で入力してください\n";
            }
            if (txtAddress.Text.Length > 50)
            {
                result = false;
                msg += "住所は50文字以内で入力してください\n";
            }
            if (txtKeika.Text.Length > 100)
            {
                result = false;
                msg += "治療経過は100文字以内で入力してください";
            }*/
            if (!result) // チェック結果がfalseならメッセージを表示して警告
            {
                MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region 登録
        /// <summary> 患者を新規登録する
        private void Touroku()
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                
                // INSERT文を作成(患者IDは自由に設定できない仕様)※IDはプルダウン後ロストフォーカスで検索するだけで入力不可
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO KANJA");
                sb.AppendLine("(保険証番号, 氏名, 生年月日, 性別, 郵便番号, 電話番号, 住所, 担当医, 治療経過)");
                sb.AppendLine("VALUES");
                sb.AppendLine("(");
                sb.AppendLine("@HOKENSYO, @NAME, @BIRTHDAY, @GENDER, @ZIPCODE, @TEL, @ADDRESS, @DOCTOR, @KEIKA");
                sb.AppendLine(")"); //かっこをつけ忘れエラーになったので、VALUE句の後の()は個別に記述することにした

                // @パラメータをリスト化(追加する順番がSQL文の通りでなくても正しく認識される)
                List<MySqlParameter> param = new List<MySqlParameter>();
                param.Add(new MySqlParameter("@HOKENSYO", txtHokensyo.Text));
                param.Add(new MySqlParameter("@NAME", txtName.Text));
                param.Add(new MySqlParameter("@BIRTHDAY", dtpBirthday.Value.ToShortDateString()));
                param.Add(new MySqlParameter("@GENDER", cmbGender.Text));
                param.Add(new MySqlParameter("@ZIPCODE", txtZipcode.Text));
                param.Add(new MySqlParameter("@TEL", txtTel.Text));
                param.Add(new MySqlParameter("@ADDRESS", txtAddress.Text));
                param.Add(new MySqlParameter("@DOCTOR", txtDoctor.Text)); // cmbから表示させてもいいかも
                param.Add(new MySqlParameter("@KEIKA", txtKeika.Text));
                // コマンドを生成し実行
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.AddRange(param.ToArray());
                // 新規登録の前にIDのインクリメント値をリセット
                string incrementReset = "ALTER TABLE KANJA AUTO_INCREMENT = 1";
                new MySqlCommand(incrementReset, con).ExecuteNonQuery();
                // メッセージボックスの選択内容で分岐(Yesの時だけ登録させる)
                DialogResult result = MessageBox.Show("この内容で登録しますか？\n※患者IDは設定できません", "最終確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery(); // コマンド実行
                    MessageBox.Show($"{txtName.Text}様を新規登録しました"); // 処理結果をお知らせ
                    InitJusinsyaItems(); // 入力をデフォルトに戻す
                }

                else
                {
                    MessageBox.Show("登録をキャンセルしました"); // 処理結果をお知らせ
                }
            }
            catch (MySqlException) // 保険証番号がUNIQUE制約付きなので、重複でDuplicate entryエラーが出る
            {
                MessageBox.Show($"保険証番号 {txtHokensyo.Text} は他の患者様の番号と重複しています\n入力しなおしてください");
                txtHokensyo.Text = "";
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

        #region 修正
        /// <summary> 患者情報を修正する
        private void Syusei()
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // UPDATE文を作成(患者IDは修正できない仕様)
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("UPDATE KANJA");
                sb.AppendLine("SET 保険証番号=@HOKENSYO,");
                sb.AppendLine("    氏名=@NAME,");
                sb.AppendLine("    生年月日=@BIRTHDAY,");
                sb.AppendLine("    性別=@GENDER,");
                sb.AppendLine("    郵便番号=@ZIPCODE,");
                sb.AppendLine("    電話番号=@TEL,");
                sb.AppendLine("    住所=@ADDRESS,");
                sb.AppendLine("    担当医=@DOCTOR,");
                sb.AppendLine("    治療経過=@KEIKA");
                sb.AppendLine("WHERE");
                sb.AppendLine("    ID=@ID");
                // @パラメータをリスト化 
                List<MySqlParameter> param = new List<MySqlParameter>();
                param.Add(new MySqlParameter("@HOKENSYO", txtHokensyo.Text));
                param.Add(new MySqlParameter("@NAME", txtName.Text));
                param.Add(new MySqlParameter("@BIRTHDAY", dtpBirthday.Value.ToShortDateString()));
                param.Add(new MySqlParameter("@GENDER", cmbGender.Text));
                param.Add(new MySqlParameter("@ZIPCODE", txtZipcode.Text));
                param.Add(new MySqlParameter("@TEL", txtTel.Text));
                param.Add(new MySqlParameter("@ADDRESS", txtAddress.Text));
                param.Add(new MySqlParameter("@DOCTOR", txtDoctor.Text)); // cmbから表示させてもいいかも
                param.Add(new MySqlParameter("@KEIKA", txtKeika.Text));
                param.Add(new MySqlParameter("@ID", cmbID.SelectedValue));
                // コマンドを生成し実行
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.AddRange(param.ToArray());
                // メッセージボックスの選択内容で分岐(Yesの時だけ登録させる)
                DialogResult result = MessageBox.Show("この内容で修正しますか？\n※患者IDは変更できません", "最終確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"{txtName.Text}様の情報を変更しました");
                    mode = true;         // モードの初期化
                    InitJusinsyaItems(); // 入力をデフォルトに戻す
                }
                else
                {
                    MessageBox.Show("処理をキャンセルしました");
                }
            }
            catch (MySqlException) // 保険証番号がUNIQUE制約付きなので、重複でDuplicate entryエラーが出る
            {
                MessageBox.Show($"保険証番号 {txtHokensyo.Text} は他の患者様の番号と重複しています\n入力しなおしてください");
                txtHokensyo.Text = "";
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

        #region 削除
        /// <summary> 患者情報を削除する
        private void Sakujo()
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // DELETE文を作成
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("DELETE FROM KANJA");
                sb.AppendLine("WHERE");
                sb.AppendLine("ID=@ID");
                // コマンドを生成し実行
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.Add(new MySqlParameter("@ID", cmbID.SelectedValue));
                // メッセージボックスの選択内容で分岐(Yesの時だけ登録させる)
                DialogResult result = MessageBox.Show($"患者ID：{cmbID.SelectedValue}\n氏名：{txtName.Text} 様\nこの患者情報を削除しますか？", "最終確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"患者ID：{cmbID.SelectedValue}の情報を削除しました");
                    mode = true;         // モードの初期化
                    InitJusinsyaItems(); // 入力をデフォルトに戻す
                    StartMenuForm.CheckExistKanja(); // 登録受診者数を確認し0人なら新規登録を促す
                }
                else
                {
                    MessageBox.Show("処理をキャンセルしました");
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

        #region 一覧表示
        /// <summary> 登録済みの患者一覧を別枠で表示させる
        private void ShowKanjaList()
        {
            // 患者一覧・予約一覧で同じフレームを表示するので、boolでモードを設定(trueは患者一覧モード)
            // ※このメソッドはmode=trueの時にのみ呼ばれるので、modeをそのまま渡せばよい
            IchiranKensaku frmIchiran = new IchiranKensaku(mode);
            frmIchiran.ShowDialog();
            this.Hide();
            this.Close();
        }
        #endregion
    }
}
