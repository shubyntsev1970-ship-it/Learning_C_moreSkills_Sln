using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Parser
{
    public  class Parser
    {
        public int TryCatchParse(string str)
        {
            int result;

            try
            {
                result = int.Parse(str);
            }
            catch (Exception ex)
            {
                result = 0;
            }

            return result;
        }
        public int TryParse(string str)
        {
            int result;

            if (!int.TryParse(str, out result))
            {
                result = 0;
            }

            return result;
        }
    }
}
