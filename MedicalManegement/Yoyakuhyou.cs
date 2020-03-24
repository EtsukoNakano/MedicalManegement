using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MedicalManegement
{
    public partial class YoyakuhyouForm : Form
    {
        private KanjaYoyakuModel model;
        private int openCount = 0; // 文字列を改行加工するのは初回だけでよいので数えておく
        public YoyakuhyouForm(KanjaYoyakuModel yoyakuModel)
        {
            InitializeComponent();
            model = yoyakuModel;
        }
        /// <summary> 予約票出力画面の生成(文字列の出力)
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*//参考サイト(https://uchukamen.com/Programming1/Print/index.htm)の定義
            Graphics g = e.Graphics;
            // グラフィックス単位をミリメートル単位にする
            g.PageUnit = GraphicsUnit.Millimeter;
            // 描画部分　10㎝ * 10㎝の四角を描く
            g.DrawRectangle(new Pen(Color.Blue, 1F), 50, 50, 100, 100);
            // 次のページは無い
            e.HasMorePages = false;*/

            // 文字列出力用に定義 ※参考サイト(http://hiros-dot.net/VBNET2005/Control/PrintDocument/PrintDocument03.htm)※VB
            Graphics g = e.Graphics;

            // 氏名が長ければ10文字目で改行文字を挿入(ドキュメント作成後の初回のみ)
            if (model.Name.Length > 10 && openCount == 0)
            {
                model.Name = model.Name.Insert(10, "\n                  ");
                openCount += 1;
            }
            // 表示文字列を生成
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("　　　　○○クリニック　予約票");
            sb.AppendLine($"\n");
            sb.AppendLine($"患者様ＩＤ　　{model.Id}");
            sb.AppendLine($"お名前 　　　{model.Name} 様");
            sb.AppendLine($"予約日 　　　{model.YoyakuDay}");
            sb.AppendLine($"時　間　　　　{model.YoyakuTime}");
            sb.AppendLine($"診療科　　　 {model.Sinryoka}");
            // 文字サイズが異なるSBを定義(出力先は同じなので、文字が重ならないよう改行で調整)
            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine("\n");
            sb2.AppendLine($"　　　　　　　　　　　　　　　　　　　　　 発行日時：{DateTime.Now}");// .PadLeft(10, ' ')); ←StringBuilder内で空白埋めされない！
            sb2.AppendLine("\n\n\n\n\n\n\n\n\n\n\n\n\n");
            sb2.AppendLine("*********************************************************\n");
            sb2.AppendLine("　　　　　○○クリニック");
            sb2.AppendLine("　　　　　大阪市××区△△　０－０－０");
            sb2.AppendLine("　　　　　□□ビル １階");
            //出力
            g.DrawString(sb.ToString(), new Font("ＭＳ Ｐゴシック", 28), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
            g.DrawString(sb2.ToString(), new Font("ＭＳ Ｐゴシック", 16), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
            // このページで終了
            e.HasMorePages = false;
        }
        /// <summary> プレビューボタン押下イベント
        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }
        /// <summary> 印刷ボタン押下イベント
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    }
}
/*// B5サイズで固定出力にするので、以下の定義はコメントアウト(文字サイズ設定が面倒だったので)
#region プリントセットアップ(btnSetupのイベントハンドラ)
private void btnSetup_Click(object sender, EventArgs e)
{
    if(pageSetupDialog1.ShowDialog() == DialogResult.OK)
    {
        // ページ設定ダイアログのバグ(余白がダイアログ表示の都度変わってしまう)を
        // 回避するため、ダイアログのマージン数値(ミリ)を変換する
        int marg;
        marg = (int)(printDocument1.DefaultPageSettings.Margins.Left * 2.54);
        printDocument1.DefaultPageSettings.Margins.Left = marg;
        marg = (int)(printDocument1.DefaultPageSettings.Margins.Right * 2.54);
        printDocument1.DefaultPageSettings.Margins.Right = marg;
        marg = (int)(printDocument1.DefaultPageSettings.Margins.Top * 2.54);
        printDocument1.DefaultPageSettings.Margins.Top = marg;
        marg = (int)(printDocument1.DefaultPageSettings.Margins.Bottom * 2.54);
        printDocument1.DefaultPageSettings.Margins.Bottom = marg;

    }
    //DialogResult result = this.pageSetupDialog1.ShowDialog();
}
#endregion

#region 用紙サイズ変更
/// <summary> 出力する紙のサイズを変更するための定義
private void YoyakuhyouForm_Load(object sender, EventArgs e)
{
    InitializaPaperSizeComboBox();
}
/// <summary> ページサイズのcomboBox1を初期化する
private void InitializaPaperSizeComboBox()
{
    PrinterSettings.PaperSizeCollection psizecollection = this.printDocument1.PrinterSettings.PaperSizes;
    for(int i = 0; i < psizecollection.Count; i++)
        this.comboBox1.Items.Add(psizecollection[i].PaperName);
    this.comboBox1.SelectedIndex = 0;
}
/// <summary> comboBox1からサイズを選択
private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
{
    // printDocument1のページサイズを変更する
    PrinterSettings.PaperSizeCollection psizecollection = this.printDocument1.PrinterSettings.PaperSizes;
    this.printDocument1.DefaultPageSettings.PaperSize = psizecollection[this.comboBox1.SelectedIndex];
}
#endregion
}
}*/
