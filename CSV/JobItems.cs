using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using CsvHelper.Configuration;
using System.ComponentModel;

namespace CSV
{
    public class JobItems
    {
        [DisplayName("Зарплата")]
        public float SalaryTotal { get; set; }
        [DisplayName("Название")]
        public String JobName { get; set; }
        [DisplayName("Регион")]
        public String Region { get; set; }
        [DisplayName("Направление")]
        public String Industry { get; set; }

        public static List<JobItems> LoadFile(String FileName)
        {
            List<JobItems> items = new List<JobItems>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null
            };

            using (var reader = new StreamReader(FileName, Encoding.GetEncoding("windows-1251")))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    if (!float.TryParse(csv.GetField("SalaryTotal"), out float salaryTotal))
                    {
                        salaryTotal = 0;
                    }
                    var jobItem = new JobItems
                    {
                        SalaryTotal = salaryTotal,
                        JobName = csv.GetField("JobName"),
                        Region = csv.GetField("Region3"),
                        Industry = csv.GetField("Industry"),

                    };
                    items.Add(jobItem);
                }
            }

            return items;
        }

        public override string ToString()
        {
            return $"{JobName} {SalaryTotal} {Region} {Industry}";
        }
    }
}
