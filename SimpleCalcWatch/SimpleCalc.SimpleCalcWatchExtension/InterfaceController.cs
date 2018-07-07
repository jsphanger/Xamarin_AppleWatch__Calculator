using System;

using WatchKit;
using Foundation;

namespace SimpleCalc.SimpleCalcWatchExtension
{
    public enum CalculationType
    {
        None = -1,
        Add = 0,
        Subtract = 1,
        Multiply = 2,
        Divide = 3,
        Caluclate = 4
    }

    public partial class InterfaceController : WKInterfaceController
    {
        public string displayString { get; set; }
        public double total { get; set; }
        public CalculationType calculation { get; set; }

        public void Calculate()
        {
            double currentVal = Convert.ToDouble(displayString);

            //adjust total
            switch(calculation)
            {
                case CalculationType.Add:
                    total = total + currentVal;
                    calculation = CalculationType.None;
                    ClearDisplay();
                    displayString = total.ToString();
                    UpdateDisplay();
                    break;
                case CalculationType.Subtract:
                    total = total - currentVal;
                    calculation = CalculationType.None;
					ClearDisplay();
					displayString = total.ToString();
					UpdateDisplay();
                    break;
                case CalculationType.Multiply:
                    total = total * currentVal;
                    calculation = CalculationType.None;
					ClearDisplay();
					displayString = total.ToString();
					UpdateDisplay();
                    break;
                case CalculationType.Divide:

                    if (currentVal > 0)
                    {
                        total = total / currentVal;
                        calculation = CalculationType.None;
						ClearDisplay();
						displayString = total.ToString();
						UpdateDisplay();
                    }
                    break;
                default:
                    total = currentVal;
                    ClearDisplay();
                    break;
            }

        }
        public void UpdateDisplay()
        {
            lblCalcDisplay.SetText(displayString); 
        }

        public void ClearDisplay(){
            displayString = "";
            lblCalcDisplay.SetText("");
        }

        protected InterfaceController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void Awake(NSObject context)
        {
            base.Awake(context);

            // Configure interface objects here.
            Console.WriteLine("{0} awake with context", this);
        }

        public override void WillActivate()
        {
            // This method is called when the watch view controller is about to be visible to the user.
            Console.WriteLine("{0} will activate", this);

            // init the inital app values
            total = 0.0d;
            calculation = CalculationType.None;
            displayString = "";
            UpdateDisplay();
        }

        public override void DidDeactivate()
        {
            // This method is called when the watch view controller is no longer visible to the user.
            Console.WriteLine("{0} did deactivate", this);
        }

        partial void BtnOne_Activated()
        {
            displayString += "1";
            UpdateDisplay();
        }

        partial void BtnTwo_Activated()
        {
			displayString += "2";
            UpdateDisplay();
        }

        partial void BtnThree_Activated()
		{
			displayString += "3";
            UpdateDisplay();
        }

        partial void BtnFour_Activated()
		{
			displayString += "4";
			UpdateDisplay();
        }

        partial void BtnFive_Activated()
		{
			displayString += "5";
			UpdateDisplay();
        }

		partial void BtnSix_Activated()
		{
			displayString += "6";
			UpdateDisplay();
		}

        partial void BtnSeven_Activated()
		{
			displayString += "7";
			UpdateDisplay();
        }

        partial void BtnEight_Activated()
		{
			displayString += "8";
			UpdateDisplay();
        }

        partial void BtnNine_Activated()
		{
			displayString += "9";
			UpdateDisplay();
        }

        partial void BtnZero_Activated()
		{
			displayString += "0";
			UpdateDisplay();
        }

        partial void BtnDecimal_Activated()
		{
			displayString += ".";
			UpdateDisplay();
        }

        partial void BtnDivide_Activated()
        {
            Calculate();
            calculation = CalculationType.Divide;
        }

        partial void BtnMultiply_Activated()
        {
            Calculate();
            calculation = CalculationType.Multiply;
        }

        partial void BtnMinus_Activated()
        {
            Calculate();
            calculation = CalculationType.Subtract;
        }

        partial void BtnAdd_Activated()
        {
            Calculate();
            calculation = CalculationType.Add;
        }

        partial void BtnEqual_Activated()
        {
            Calculate();
            calculation = CalculationType.None;
        }

        partial void BtnClear_Activated()
        {
			total = 0.0d;
			calculation = CalculationType.None;
			ClearDisplay();
        }
    }
}
