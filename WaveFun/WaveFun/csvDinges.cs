//DEZE KLASSE WODT NIET GEBRUIKT IN DIT PROJECT; HIJ IS VOOR LATER BEDOELD. GA HIER NIET DEBUGGEN DUTS!
// ALS JE DIT TOCH DOE UPDATE JE DUTS SCORE!
//Score aantal keren je toch zocht waarom hij niet inlas:   1 (8/11/'15),   2 (8/11/'15),   3(17/11/15)

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace WaveFun
{
    public class csvReader
    {        
        public Dictionary<char, float> data { get; set; }

        public Dictionary<char, float> readCsvFile(string path)
        {            
            //maak een file klaar
            StreamReader _streamReader = new StreamReader(path);

            //reset dictionary
            data = new Dictionary<char, float>();

            //lees de waarden in
            string[] _streamDataValues = null;
            while (!_streamReader.EndOfStream)
            {
                //overbodige spaties wegdoen
                String _streamLineData = _streamReader.ReadLine().Trim();

                //comentaar negeren
                if (_streamLineData.Length > 0 && _streamLineData.Substring(0, 2) != @"//")
                {
                    _streamDataValues = _streamLineData.Split(',');

                    //char waarde en Float waarde in de Dict toevoegen. vb: Ab,200f => [A][200.0]
                    data.Add(_streamDataValues[0][0], float.Parse(_streamDataValues[1], CultureInfo.InvariantCulture));
                }
            }

            _streamReader.Close();
            _streamReader.Dispose();

            return data;
        }
    }
}
