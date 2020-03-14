using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Helpers
{
    public class Functions
    {
        public string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public string ConvertToOutputDate(string input)
        {
            // 2020-02-02
            string year = input.Substring(0, 4);
            string month = input.Substring(5, 2);
            string day = input.Substring(8, 2);

            string overall = day;

            switch (month)
            {
                case ("01"):
                    overall += " Jan";
                    break;
                case ("02"):
                    overall += " Feb";
                    break;
                case ("03"):
                    overall += " Mar";
                    break;
                case ("04"):
                    overall += " Apr";
                    break;
                case ("05"):
                    overall += " May";
                    break;
                case ("06"):
                    overall += " Jun";
                    break;
                case ("07"):
                    overall += " Jul";
                    break;
                case ("08"):
                    overall += " Aug";
                    break;
                case ("09"):
                    overall += " Sep";
                    break;
                case ("10"):
                    overall += " Oct";
                    break;
                case ("11"):
                    overall += " Nov";
                    break;
                case ("12"):
                    overall += " Dec";
                    break;
                default:
                    throw new Exception("> That Month doesn't Exist!: " + month);
            }

            overall += " " + year;

            return overall;
        }
    }
}
