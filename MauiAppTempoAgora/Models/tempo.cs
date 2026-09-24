namespace MauiAppTempoAgora.Models
{
    internal class tempo
    {
        internal object lon;

        public double? Lon { get; set; }
        public double? lat { get; set; }


        public double? temp_min { get; set; }
        public double? temp_max { get; set; }



        public int? visibility { get; set; }

        public double? speed { get; set; }


        public string? main { get; set; }

        public string? description { get; set; }

        public String? sunrise { get; set; }
        public String? sunset { get; set; }


    }
}
