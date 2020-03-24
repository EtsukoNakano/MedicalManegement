namespace MedicalManegement
{
    /// <summary> 患者情報・予約情報を格納するクラス
    public class KanjaYoyakuModel
    {
        // 共通
        public int Id { get; set; }
        public string Name { get; set; }
        // 患者のみ
        public string Hokensyo { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Zipcode { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Doctor { get; set; }
        public string Keika { get; set; }
        // 予約のみ
        public string Sinryoka { get; set; }
        public string YoyakuDay { get; set; }
        public string YoyakuTime { get; set; }
        public int SinryokaNum{ get; set; }
        public int TimeTableNum { get; set; }
    }
}
