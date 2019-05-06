using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        int SucessProbability = 30;


        class Weapon
        {
            public string Name { get; set; }
            public int StableValue { get; set; }
            public int WeaponValue { get; set; }
        }


        private Weapon CurrentWeapon = new Weapon();
        private Roll usingRoll;
        private void Using()
        {
            setWeapon();  
            string resultSucess = @"{1}{0} 一瞬間發出 {2}藍色的 光芒。 ";
            string resultFailure = @"{1}{0} 發出劇烈的光芒 就消失了。 ";
            string alertText = "";

            if(getResult){
                int addPoint = (int)usingRoll.Point;
                alertText = string.Format(resultSucess, CurrentWeapon.Name, CurrentWeapon.WeaponValue, addPoint);
                AddWeaponValue(addPoint);
            }else{
                RuinWeaponValue();
                alertText = string.Format(resultFailure, CurrentWeapon.Name, CurrentWeapon.WeaponValue);
            }

            textBox1.Text = alertText + "\r\n" +textBox1.Text;
        }

        private void setWeapon()
        {

            CurrentWeapon.Name = "細劍";
            CurrentWeapon.StableValue = 2;
        }

        private bool getResult {
            get
            {
                if (isRandom)
                {
                    Random random = new Random();
                    int Probability = random.Next(0, 100);
                    if (Probability > SucessProbability)
                    {
                        return true;
                    }
                }
                else { return true; }
                return false;
            }
        }
        private bool isRandom { 
            get{
                if (usingRoll.ProbabilityFailure)
                {
                    if (CurrentWeapon.WeaponValue >= CurrentWeapon.StableValue) { return true; }
                }
                return false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        private void AddWeaponValue(decimal point)
        {
            CurrentWeapon.WeaponValue+= (int)usingRoll.Point;
        }
        private void RuinWeaponValue()
        {
            CurrentWeapon.WeaponValue= 0;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usingRoll = new OrignalRoll();
            Using();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usingRoll = new BlessedRoll();
            Using();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usingRoll = new GoddamnedRoll();
            Using();

        }


    }
}
