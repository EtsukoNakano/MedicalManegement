using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MedicalManegement
{
    public partial class IchiranKensaku : Form
    {
        private bool mode;
        #region コンストラクタ
        public IchiranKensaku(bool frmMode)
        {
            // 受診者管理からならmode=trueで患者一覧、予約管理からならmode=falseで予約一覧を表示させる
            mode = frmMode;
            InitializeComponent();
            InitDisplay();
        }
        #endregion

        #region ウィジェット初期化
        private void InitDisplay()
        {
            if(mode) // 患者一覧モードの時の表示をセット
            {
                lblBirthYoyaku.Text = "生年月日";
                rdoReverse.Text = "患者IDの降順で表示する";
                lblGenderSinryoka.Text = "性　別";
                cmbGenderSinryoka.Items.Clear();
                // Comboboxの中身(性別)を配列で作成
                string[] genders = { "男性", "女性", "その他" };
                cmbGenderSinryoka.Items.AddRange(genders);
                // 誕生日の選択範囲を今日までに設定
                DateTime maxDate = DateTime.Now.Date;
                dtpBirthYoyakuFrom.MaxDate = maxDate;
                dtpBirthYoyakuTo.MaxDate = maxDate;
                dtpBirthYoyakuTo.Value = maxDate;
                // 検索結果を呼び出してグリッドに表示させる(デフォルトは生年月日でmin(1900/01/01)～max(現在の日付)の範囲を検索)
                KanjaKensaku();
            }
            else // 予約一覧モードの時の表示をセット
            {
                lblBirthYoyaku.Text = "予約日";
                rdoReverse.Text = "予約日の降順で表示する";
                lblGenderSinryoka.Text = "診療科";
                cmbGenderSinryoka.Items.Clear();
                // Comboboxの中身(診療科)はDBから取得する
                string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
                MySqlConnection con = new MySqlConnection(strCon);
                con.Open();
                // データソースの接続
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM SINRYOKA", con);
                // データ格納
                DataTable dtSinryoka = new DataTable();
                da.Fill(dtSinryoka);
                // 接続終了
                con.Close();
                // 表示項目と値のセット
                cmbGenderSinryoka.DisplayMember = "診療科"; // 表示する項目名をセット
                cmbGenderSinryoka.ValueMember = "管理番号"; // 実際の値として取得する項目名"をセット
                cmbGenderSinryoka.DataSource = dtSinryoka;
                cmbGenderSinryoka.SelectedIndex = -1;       // 初期表示は空白にしておくため
                // 予約日の選択上限を一年後までに設定
                DateTime maxDate = DateTime.Now.Date.AddYears(1);
                dtpBirthYoyakuFrom.MaxDate = maxDate;
                dtpBirthYoyakuTo.MaxDate = maxDate;
                dtpBirthYoyakuTo.Value = maxDate;
                // 検索結果を呼び出してグリッドに表示させる(デフォルトは予約日でmin(1900/01/01)～max(現在の一年後)の範囲を検索)
                YoyakuKensaku();
            }
        }
        #endregion

        #region イベント
        /// <summary> 検索ボタン押下
        private void btnKensaku_Click(object sender, EventArgs e)
        {
            if(mode) // 患者一覧モードなら
            {
                KanjaKensaku();
            }
            else        // 予約一覧モードなら
            {
                YoyakuKensaku();
            }
            rdoReverse.Checked = false; // ラジオボタンの解除(しないと降順表示しかできなくなる)
        }

        /// <summary> データグリッドクリック
        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // グリッドを取得
                DataGridView dgv = (DataGridView)sender;
                // ボタンクリックでモード値を変更する
                int mode = 0; // デフォルトモード値
                switch (dgv.Columns[e.ColumnIndex].Name)
                {
                    case "DELETE": mode = 1; break;
                    case "UPDATE": mode = 2; break;
                    case "YOYAKUHYO": mode = 3; break;
                }
                // 押されたのがボタン以外(mode = 0)なら処理しない
                if (mode == 0)
                {
                    return;
                }

                // モデルに選択行の値を格納する
                KanjaYoyakuModel model = new KanjaYoyakuModel();
                if (this.mode) // 患者一覧モード
                {
                    model.Id = int.Parse(dgv.Rows[e.RowIndex].Cells[2].Value.ToString());
                    model.Name = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    model.Hokensyo = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    model.Birthday = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                    model.Gender = dgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                    model.Zipcode = dgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                    model.Address = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                    model.Tel = dgv.Rows[e.RowIndex].Cells[9].Value.ToString();
                    model.Doctor = dgv.Rows[e.RowIndex].Cells[10].Value.ToString();
                    model.Keika = dgv.Rows[e.RowIndex].Cells[11].Value.ToString();
                }
                else         // 予約一覧モード
                {
                    model.Id = int.Parse(dgv.Rows[e.RowIndex].Cells[5].Value.ToString());
                    model.Name = dgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                    model.Sinryoka = dgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                    model.YoyakuDay = dgv.Rows[e.RowIndex].Cells[3].Value.ToString().Remove(10);
                    model.YoyakuTime = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    model.SinryokaNum = YoyakuKanriForm.GetKanriBango(model.Sinryoka, "SINRYOKA WHERE 診療科");
                    model.TimeTableNum = YoyakuKanriForm.GetKanriBango(model.YoyakuTime, "TIMETABLE WHERE 時間帯");
                }

                // 削除・修正・予約票発行ボタンでの処理
                if (mode == 1)      // 削除モード
                {
                    GridDelete(model);
                    if (this.mode) // 患者一覧を更新
                    {
                        KanjaKensaku();
                    }
                    else        // 予約一覧を更新
                    {
                        YoyakuKensaku();
                    }
                }
                else if (mode == 2) // 修正モード
                {
                    if (this.mode)    // 受診者管理フォームを修正モード(false)で表示する
                    {
                        JusinsyaKanriForm frmJusinsya = new JusinsyaKanriForm(false, model);
                        frmJusinsya.ShowDialog();
                    }
                    else            // 予約管理フォームを修正モード(false)で表示する
                    {
                        YoyakuKanriForm frmYoyaku = new YoyakuKanriForm(false, model);
                        frmYoyaku.ShowDialog();
                    }
                    this.Hide();
                    this.Close();
                }
                else if (mode == 3) // 予約票出力モード
                {
                    YoyakuhyouForm frmhyou = new YoyakuhyouForm(model);
                    frmhyou.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー詳細：\n{ex.Message}：\n{ex.InnerException}");
            }
        }
        #endregion

        #region グリッド設定
        /// <summary> 患者一覧グリッドの表示設定
        private void SetKanjaGrid(DataTable dt)
        {
            // グリッドの初期化(再検索で表示がずれないようにするため)
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            // 削除・修正ボタンをグリッドに配置
            DataGridViewButtonColumn colDelete = new DataGridViewButtonColumn();
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Name = "DELETE";
            colDelete.HeaderText = "";
            colDelete.Text = "削除";
            dgvList.Columns.Add(colDelete);
            DataGridViewButtonColumn colUpdete = new DataGridViewButtonColumn();
            colUpdete.UseColumnTextForButtonValue = true;
            colUpdete.Name = "UPDATE";
            colUpdete.HeaderText = "";
            colUpdete.Text = "修正";
            dgvList.Columns.Add(colUpdete);
            // グリッドにデータテーブルをセット
            dgvList.DataSource = dt;
            // グリッド幅調整
            dgvList.Columns[0].Width = 40;  // 0:削除ボタン
            dgvList.Columns[1].Width = 40;  // 1:修正ボタン
            dgvList.Columns[2].Width = 30;  // 2:ID
            dgvList.Columns[3].Width = 80;  // 3:氏名
            dgvList.Columns[4].Width = 90;  // 4:保険証番号
            dgvList.Columns[5].Width = 80;  // 5:生年月日
            dgvList.Columns[6].Width = 40;  // 6:性別
            dgvList.Columns[7].Width = 80;  // 7:〒
            dgvList.Columns[8].Width = 80; // 8:住所
            dgvList.Columns[9].Width = 80;  // 9:TEL
            dgvList.Columns[10].Width = 70; //10:担当医
            dgvList.Columns[11].Width = 100;//11:治療経過
        }

        /// <summary> 予約一覧グリッドの表示設定
        private void SetYoyakuGrid(DataTable dt)
        {
            // グリッドの初期化(再検索で表示がずれないようにするため)
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            // 予約票発行・削除・修正ボタンをグリッドに配置
            DataGridViewButtonColumn colYoyakuhyo = new DataGridViewButtonColumn();
            colYoyakuhyo.UseColumnTextForButtonValue = true;
            colYoyakuhyo.Name = "YOYAKUHYO";  // ボタン名
            colYoyakuhyo.HeaderText = "";     // ヘッダ名は非表示(デフォルトではボタン名になってしまうので)
            colYoyakuhyo.Text = "予約票発行"; // ボタン表示
            dgvList.Columns.Add(colYoyakuhyo);// データグリッド先頭に配置
            DataGridViewButtonColumn colDelete = new DataGridViewButtonColumn();
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Name = "DELETE";
            colDelete.HeaderText = "";
            colDelete.Text = "削除";
            dgvList.Columns.Add(colDelete);
            DataGridViewButtonColumn colUpdete = new DataGridViewButtonColumn();
            colUpdete.Name = "UPDATE";
            colUpdete.HeaderText = "";
            colUpdete.UseColumnTextForButtonValue = true;
            colUpdete.Text = "修正";
            dgvList.Columns.Add(colUpdete);
            // グリッドにデータテーブルをセット
            dgvList.DataSource = dt;
            // グリッド幅調整
            dgvList.Columns[0].Width = 70; // 0:予約票発行ボタン
            dgvList.Columns[1].Width = 40; // 1:削除ボタン
            dgvList.Columns[2].Width = 40; // 2:修正ボタン
            dgvList.Columns[3].Width = 90; // 3:予約日
            dgvList.Columns[4].Width = 60; // 4:時間帯
            dgvList.Columns[5].Width = 30; // 5:患者ID
            dgvList.Columns[6].Width = 80; // 6:氏名
            dgvList.Columns[4].Width = 80; // 7:受診科
            dgvList.Columns[5].Width = 70; // 8:受診済確認 //チェックボックスに置き換えてみる
            dgvList.Columns[6].Width = 70; // 9:投薬有無   //チェックボックスに置き換えてみる
            /*// チェックボックスを配置
            //※この定義で実装できるが、グリッドボタンクリックで「入力文字列の形式が正しくありません」と
            //　エラーになってしまうのでコメントアウトした
            DataGridViewCheckBoxColumn visitCheck = new DataGridViewCheckBoxColumn();
            visitCheck.Name = "VISIT";
            visitCheck.HeaderText = "受診済確認";
            dgvList.Columns.Add(visitCheck);
            DataGridViewCheckBoxColumn medicine = new DataGridViewCheckBoxColumn();
            medicine.Name = "MEDICINE";
            medicine.HeaderText = "投薬有無";
            dgvList.Columns.Add(medicine);*/
        }
        #endregion

        #region 検索
        /// <summary> 患者検索
        private void KanjaKensaku()
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // SELECT文を作成
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT");
                sb.AppendLine("ID, 氏名, 保険証番号, 生年月日, 性別, 郵便番号, 住所, 電話番号, 担当医, 治療経過");
                sb.AppendLine("FROM KANJA");
                sb.AppendLine("WHERE 1=1");
                List<MySqlParameter> param = new List<MySqlParameter>();
                // 生年月日始点～終点はDateTimePickerを使うと必ず選択されるので、パラメータを先に挿入しておく
                // ※期間の始点と終点の大小が逆なら表示を入れ替える
                if (dtpBirthYoyakuFrom.Value >= dtpBirthYoyakuTo.Value)
                {
                    string tempStartDay = dtpBirthYoyakuFrom.Text;   // Fromを一時的に格納
                    dtpBirthYoyakuFrom.Text = dtpBirthYoyakuTo.Text; // FromにToを代入
                    dtpBirthYoyakuTo.Text = tempStartDay;            // Toに格納させておいたFromを代入
                }
                sb.AppendLine("AND 生年月日 >= @BIRTHDAYFROM");
                param.Add(new MySqlParameter("@BIRTHDAYFROM", dtpBirthYoyakuFrom.Value.ToShortDateString()));
                sb.AppendLine("AND 生年月日 <= @BIRTHDAYTO");
                param.Add(new MySqlParameter("@BIRTHDAYTO", dtpBirthYoyakuTo.Value.ToShortDateString()));

                // 以降のSQL文は、検索項目に入力があれば追加する(ID,氏名,性別)
                if (txtKensakuID.Text != "")
                {
                    sb.AppendLine("AND ID = @ID");
                    param.Add(new MySqlParameter("@ID", txtKensakuID.Text));
                }
                if (txtKensakuName.Text != "")
                {
                    sb.AppendLine("AND 氏名 LIKE @NAME");
                    param.Add(new MySqlParameter("@NAME", GetLikeString(txtKensakuName.Text)));
                }
                if (cmbGenderSinryoka.Text != "")
                {
                    sb.AppendLine("AND 性別 = @GENDER");
                    param.Add(new MySqlParameter("@GENDER", cmbGenderSinryoka.Text));
                }
                // ラジオボタンのチェックの有無で検索結果の表示を降順・昇順切り替え
                if (rdoReverse.Checked == true)        // 「患者IDの降順で表示する」が選択されていたら
                {
                    sb.AppendLine("ORDER BY ID DESC"); // IDを降順(DESC)で並び替える
                    lblList.Text = "受診者情報一覧(降順)";
                }
                else if (rdoReverse.Checked != true)
                {
                    sb.AppendLine("ORDER BY ID");      // IDを昇順(ASC)で並び替える
                    lblList.Text = "受診者情報一覧(昇順)";
                }
                // コマンドを生成しデータを読み込む
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.AddRange(param.ToArray());
                MySqlDataReader dr = cmd.ExecuteReader();
                // 読み込んだデータをDataTable に変換してグリッドに渡す
                DataTable dt = new DataTable();
                dt.Load(dr);
                //dgvList.DataSource = dt; // ここでグリッドにデータをセットすると、ボタンが後ろの行についてしまうので×
                SetKanjaGrid(dt);
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

        /// <summary> 予約検索
        private void YoyakuKensaku()
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // SELECT文を作成
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT");
                sb.AppendLine("予約日, 時間帯, 患者ID, 氏名, 診療科 AS 受診科, 受診済確認, 投薬有無");
                sb.AppendLine("FROM YOYAKU");    // メインテーブル(予約テーブル)
                sb.AppendLine("JOIN TIMETABLE"); // 結合するテーブル その1(タイムテーブル)
                sb.AppendLine("ON YOYAKU.予約時間 = TIMETABLE.管理番号"); // 管理番号と照合して抽出した時間帯をメインテーブルに結合
                sb.AppendLine("JOIN KANJA");     // 結合するテーブル その2(患者テーブル)
                sb.AppendLine("ON YOYAKU.患者ID = KANJA.ID"); // IDと照合して抽出した氏名をメインテーブルに結合
                sb.AppendLine("JOIN SINRYOKA");  // 結合するテーブル その3(診療科テーブル)
                sb.AppendLine("ON YOYAKU.受診科 = SINRYOKA.管理番号");    // 照合して抽出した診療科をメインテーブルに結合(表示は別名)
                sb.AppendLine("WHERE 1=1");
                List<MySqlParameter> param = new List<MySqlParameter>();
                // 予約日始点～終点はDateTimePickerを使うと必ず選択されるので、パラメータを先に挿入しておく
                // ※期間の始点と終点の大小が逆なら表示を入れ替える
                if (dtpBirthYoyakuFrom.Value >= dtpBirthYoyakuTo.Value)
                {
                    string tempStartDay = dtpBirthYoyakuFrom.Text;   // Fromを一時的に格納
                    dtpBirthYoyakuFrom.Text = dtpBirthYoyakuTo.Text; // FromにToを代入
                    dtpBirthYoyakuTo.Text = tempStartDay;            // Toに格納させておいたFromを代入
                }
                sb.AppendLine("AND 予約日 >= @YOYAKUDAYFROM");
                param.Add(new MySqlParameter("@YOYAKUDAYFROM", dtpBirthYoyakuFrom.Value.ToShortDateString()));
                sb.AppendLine("AND 予約日 <= @YOYAKUDAYTO");
                param.Add(new MySqlParameter("@YOYAKUDAYTO", dtpBirthYoyakuTo.Value.ToShortDateString()));

                // 以降のSQL文は、検索項目に入力があれば追加する(患者ID,氏名,診療科)
                if (txtKensakuID.Text != "")
                {
                    sb.AppendLine("AND 患者ID = @ID");
                    param.Add(new MySqlParameter("@ID", txtKensakuID.Text));
                }
                if (txtKensakuName.Text != "")
                {
                    sb.AppendLine("AND 氏名 LIKE @NAME"); // LIKEを使うところには専用の関数でワイルドカード対応させる
                    param.Add(new MySqlParameter("@NAME", GetLikeString(txtKensakuName.Text)));
                }
                if (cmbGenderSinryoka.Text != "")
                {
                    sb.AppendLine("AND 診療科 = @SINRYOKA");
                    param.Add(new MySqlParameter("@SINRYOKA", cmbGenderSinryoka.Text));
                }
                // ラジオボタンのチェックの有無で検索結果の表示を降順・昇順切り替え
                if (rdoReverse.Checked == true) // 「予約日の降順で表示する」が選択されていたら
                {
                    sb.AppendLine("ORDER BY 予約日 DESC, 時間帯"); // 日付を降順(DESC)にする(時間帯は昇順のまま)
                    lblList.Text = "予約情報一覧(降順)"; // ラベル表示を変える(検索後はラジオを未選択にするので検索内容が分かるように)
                }
                else if (rdoReverse.Checked != true) 　　// ラジオボタンがチェックされていなければ、日時の昇順で並び替える
                {
                    sb.AppendLine("ORDER BY 予約日, 時間帯");
                    lblList.Text = "予約情報一覧(昇順)";
                }
                // コマンドを生成しデータを読み込む
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                cmd.Parameters.AddRange(param.ToArray());
                MySqlDataReader dr = cmd.ExecuteReader();
                // 読み込んだデータをDataTableに変換してグリッドに渡す
                DataTable dt = new DataTable();
                dt.Load(dr);        　     // データテーブルに読み込んだデータをセット
                SetYoyakuGrid(dt);         // データグリッドの表示設定メソッドを呼ぶ
                //MessageBox.Show("検索しました");
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

        /// <summary> ワイルドカードに対応したLIKE用の文字列に変換する
        /// <param name="str">変換前の文字列</param>
        /// <returns>ワイルドカード文字が含まれていたらエスケープし、%を先頭と末尾につけた文字を返す</returns>
        private string GetLikeString(string str)
        {
            str = Regex.Replace(str, "%", "\\%");
            str = Regex.Replace(str, "_", "\\_");
            return "%" + str + "%";
        }
        #endregion

        #region 削除
        /// <summary> グリッドボタンでの削除処理
        /// <param name="model">削除対象の情報</param>
        private void GridDelete(KanjaYoyakuModel model)
        {
            string strCon = "Server=localhost; Database=medical_manegement; Uid=root; Pwd=nekonyanta";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            try
            {
                // DELETE文を作成しパラメータを追加
                StringBuilder sb = new StringBuilder();
                MySqlCommand cmd;
                string msg;
                if (mode) // 患者一覧モードなら
                {
                    sb.AppendLine("DELETE FROM KANJA");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("ID=@ID");
                    cmd = new MySqlCommand(sb.ToString(), con);
                    cmd.Parameters.Add(new MySqlParameter("@ID", model.Id));
                    msg = $"患者ID：{model.Id}\n氏名：{model.Name} 様\n";
                }
                else         // 予約一覧モードなら
                {
                    sb.AppendLine("DELETE FROM YOYAKU");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("    患者ID=@ID");
                    sb.AppendLine("AND 予約日=@YOYAKUDAY");
                    sb.AppendLine("AND 予約時間=@YOYAKUTIME");
                    sb.AppendLine("AND 受診科=@SINRYOKA");
                    cmd = new MySqlCommand(sb.ToString(), con);
                    cmd.Parameters.Add(new MySqlParameter("@ID", model.Id));
                    cmd.Parameters.Add(new MySqlParameter("@YOYAKUDAY", model.YoyakuDay));
                    cmd.Parameters.Add(new MySqlParameter("@YOYAKUTIME", model.TimeTableNum));
                    cmd.Parameters.Add(new MySqlParameter("@SINRYOKA", model.SinryokaNum));
                    msg = $"患者ID：{model.Id}\n氏名：{model.Name} 様\n予約日：{model.YoyakuDay}\n予約時間：{model.YoyakuTime}\n受診科：{model.Sinryoka}";
                }
                
                DialogResult result = MessageBox.Show($"{msg}\nこの情報を削除しますか？", "最終確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"{msg}\nこの情報を削除しました");
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
    }
}
