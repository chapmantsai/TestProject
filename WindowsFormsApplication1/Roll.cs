using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    public class Roll
    {
        public string aaa { get; set; }
        public string RollName { get; set; }
        public List<decimal> UsePossibleValue { get; set; }
        public virtual decimal Point { get { return UsePossibleValue[0]; } }

        public bool ProbabilityFailure { get; set; }
    }

    public class OrignalRoll : Roll
    {
        public OrignalRoll()
        {
            RollName = "普通卷軸";
            UsePossibleValue = new List<decimal>() { 1 };
            ProbabilityFailure = true;
        }
    }
    public class BlessedRoll : Roll
    {
        public BlessedRoll()
        {
            RollName = "祝福卷軸";
            UsePossibleValue = new List<decimal>() { 1, 2, 3 };
            ProbabilityFailure = true;
        }
        public string getName { get { return this.RollName; } }
        public override decimal Point
        {

            get
            {
                Random random = new Random();
                decimal RandomResult = (decimal)this.UsePossibleValue[(random.Next(this.UsePossibleValue.Count))];
                return RandomResult;
            }
        }

    }
    public class GoddamnedRoll : Roll
    {
        public GoddamnedRoll()
        {
            RollName = "詛咒卷軸";
            UsePossibleValue = new List<decimal>() { -1 };
            ProbabilityFailure = false;
        }

    }


}
