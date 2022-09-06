namespace LifeInsuranceForm
{
    public partial class Form1 : Form
    {
        private bool blnAllGood = true; //this field is a flag that will be used at certain points in program executation to help maintain the flow of the program.
        const double dblTaxPercent = 0.06; //the sales tax of whatever state this is program is being used in. 
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            /**
             * Name : btnClear_Click
             * Params : sender - the control that fired this event.
             *          e - the event arguments.
             * Returns : None.
             * Purpose : The purpose of this subprocedure is to completely clear Form1 (the insurance policy form) when
             *           the user clicks. Clearing entails emptying all textboxes, and setting any labels that had text
             *           possibly changed back to the original text, and setting any other misc. controls back to the
             *           state they were in when the form first loads.
             * */
            //first we want to check that the user meant to hit the clear button
            var res = MessageBox.Show("Doing this will clear all information input and output from this form. Are you sure?", "Are you sure", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                //do nothing since the user hit no
                return;
            }
            //the user hit yes, so lets first clear all the textboxes. We have a method for this.
            clearTextboxes();
            resetLabels();
            resetMiscControls();
        }
        private void clearTextboxes()
        {
            /**
             * Name : clearTextboxes
             * Params : None.
             * Returns : None.
             * Purpose : The purpose of this method is simply to clear the text value of any textbox on this form.
             *           We just go through one by one and call their clear methods.
             *           */
            txtFirst.Clear();
            txtMI.Clear();
            txtLast.Clear();
            txtAge.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            txtCoverageAmount.Clear();
            txtAmount.Clear();
        }

        private void resetLabels()
        {
            /**
             * Name : resetLabels
             * Params : None.
             * Returns : None.
             * Purpose : The purpose of this method is to reset all labels to whatever they said when the form is first loaded.
             *           */
            lblRisk.Text = "Risk Factor: "; //reset label for risk factor text
            lblSub.Text = "Sub Total: "; //reset subtotal label text
            lblDiscount.Text = "Discount: "; //reset discount label text
            lblTax.Text = "Tax (0.06): "; //reset tax label text
            lblTotal.Text = "Total: "; //reset total label text
        }

        private void resetMiscControls()
        {
            /**
             * Name : resetMiscControl
             * Params : None.
             * Returns : None.
             * Purpose : The purpose of this method is to be an area to handle reseting any controls that are not
             *           textboxes or labels to whatever state we want them to be in when the form first loads.
             *           */
            lstMessage.Items.Clear(); //clear our listbox that is used to give messages to the user. 
        }
        private double calculateSalesTax(double dblSubTotal)
        {
            /**
             * Name : calculateSalesTax
             * Params : dblSubTotal - the pre-tax amount of the transaction that we wish to calculate the total sales tax for.
             * Returns : dblTax - the amount of tax we calculate for our transaction.
             * Purpose : The purpose of this function is to calculate and return the sales tax amount for a given transaction
             *           subtotal.
             *           */
            double dblTax = 0;
            dblTax = dblSubTotal * dblTaxPercent;
            return dblTax;
        }

        private double calculateRiskFactor(int intAge, double dblWeight, double dblHeight)
        {
            /**
             * Name : calculateRiskFactor
             * Params : dblHeight - a double representing the users height in inches. This was made a double to simplify logic around calculations.
             *          dblWeight - a double representing the users weight in pounds. This was made a double to simplify logic around calculations.
             *          intAge - an integer representing the users age
             * Returns : dblRiskFactor - the risk factor associated with a client
             * Purpose : The purpose of this function is to calculate the clients risk factor based on the parameters passed to the function. 
             *           The formula we will use to calculate risk factor is (age + sqrt(height^2 + (age * weight)))/ (weight - (4.01 * age))
             *           */
            double dblRiskFactor = 0; //the riskFactor associated with a client.
            double dblNumerator = 0; //the numerator of our equation.
            double dblDenominator = 0; //the denominator of our equation.
            double dblRadicand = 0; //the value under the square root symbol.

            //first lets evaluate the radicand
            dblRadicand = (dblHeight * dblHeight) + (intAge * dblWeight);
            /* with realistic numbers this equation will never spit out a value <= 0, but it only takes a few lines of
               code to check for this case, so lets make sure we are only taking the sqrt of positive numbers. */
            if(dblRadicand < 0)
            {
                /*this situation is a bit hairy. Something happened that should not have, but we can't just return a bogus value since in theory our equation
                 * can spit out any value. Let us first make the user aware that something isn't quite right. Let's also create a 'all good flag' and set it to
                 * false in this conditional block since everything is in fact not all good. Then we can control our program flow from outside of this method. */
                MessageBox.Show("Check client information.", "Error");
                lstMessage.Items.Add("Results may be incorrect. Please check client information and try again.");
                blnAllGood = false;
                //just return 0 here
                return 0;
            }
            dblNumerator = intAge + Math.Sqrt(dblRadicand);
            dblDenominator = dblWeight - (4.01 * intAge);
            if(dblDenominator == 0)
            {
                /* we can not divide by 0, so much like what we did in the radicand conditional block we should inform the user, set the flag and return 0
                 * */
                MessageBox.Show("Divide by zero, please check client information.", "Error");
                lstMessage.Items.Add("Results may be incorrect. Please check client information and try again.");
                blnAllGood = false;
                return 0;
            }
            //when we make it here everything is working as intended. Lets finish the calculation and return the result.
            dblRiskFactor = dblNumerator / dblDenominator;
            //lets set the flag to true here since we know this is an instance of the calculation performing correctly.
            blnAllGood = true;
            return dblRiskFactor;
        }

        private double calculateCoverageAmount(int intAge, double dblWeight, double dblHeight, double dblCoverageAmount)
        {
            /**
             * Name: calculateCoverageAmount
             * Params : dblCoverageAmount - the amount that the clientwould like his/her/their? policy to cover
             *          dblHeight - the height of the client in inches.
             *          dblWeight - the weight of the client in inches.
             *          intAge - the age of the client.
             * Returns : a double representing the total annual premium policy that the user will pay
             * Purpose : The purpose of this function is to take the client's information, and calculate the total annual
             *           payment based off of this information. The calculation is split into four conditions depending on the value of the risk factor.
             *           Note that we do not interact with our all good flag at all in the function. This is because we returned a value even when the 
             *           data caused our risk factor equation to make no sense. In this function we do not need to care if anything is all good, we will take care
             *           of higher level logic in the onclick function for our submit button.
             *           */
            //reset the labels, textboxes and other controls so that the previous output will be cleared if the user did not hit the clear button before typing in new client information
            resetLabels();
            //we need to get the risk factor before calculating the coverage amount.
            double dblRiskFactor = calculateRiskFactor(intAge, dblWeight, dblHeight); //the risk factor calculated with the clients information
            //show the original risk factor to the user
            lblRisk.Text += " " + dblRiskFactor.ToString();
            double dblAnnualCost = 0;
            //now there are four different conditionals that determine how the annual cost is calculated.
            //risk factor 0.0 to 10.0
            if(dblRiskFactor >= 0 && dblRiskFactor <= 10)
            {
                //our equation is (10.1 - risk factor) * 1/10 * coverage amount
                dblAnnualCost = (10.1 - dblRiskFactor) * (1.0/10.0) * dblCoverageAmount;
            }
            if(dblRiskFactor > 10)
            {
                //our equation is while(risk factor > 10){risk factor =/ 10} then do the same equation as the 0 to 10 range risk factor
                while(dblRiskFactor > 10)
                {
                    dblRiskFactor = dblRiskFactor / 10;
                }
                dblAnnualCost = ((10.1 - dblRiskFactor) * (1.0/10.0) * dblCoverageAmount);
            }
            if(dblRiskFactor < 0 && dblRiskFactor >= -10)
            {
                //our equation is (10.1 + risk factor) * 1/10 * coverage amount
                dblAnnualCost = ((10.1 + dblRiskFactor) * (1.0/10.0) * dblCoverageAmount);
            }
            if(dblRiskFactor < -10)
            {
                //again we loop until the risk factor is in the range of 0 > risk factor > -10 and then use the equation that we used for that range.
                while(dblRiskFactor < -10)
                {
                    dblRiskFactor = dblRiskFactor / 10;
                }
                dblAnnualCost = ((10.1 + dblRiskFactor) * (1.0/10.0) * dblCoverageAmount);
            }
            
            return dblAnnualCost;
        }
        public bool validateInputs()
        {
            return true;
        }
        public void btnSubmit_click(Object sender, EventArgs eventArgs)
        {
            /* Name: btnSubmit_click
             * Params : eventArgs - the event arguments passed to this method when the click event was fired.
             *          sender - the object that fired the click event.
             * Returns : None.
             * Purpose : The purpose of this function is to control the program flow when the user clicks the submit button.
             *           We will firstly call functions that check user input, perform calculations for risk factor and annual coverage amount.
             *           Then we make sure that nothing weird occurred by checking our flag. If something strange ocurred we want to notify the
             *           user that results are either iffy or were not able to be calculated. Then we display any pertinent information to the user.
             *           */
            //first thing we should do is clear the listbox (clear our message queue)
            lstMessage.Items.Clear();
            if (!validateInputs())
            {
                //inform user that we are exiting the calculation method since the inputs were not valid.
                lstMessage.Items.Add("Calculation canceled...");
                //return so that no other code in this function gets executed
                return;
            }
            //lets get the annual cost
            double dblCoverageAmount = calculateCoverageAmount(int.Parse(txtAge.Text), double.Parse(txtWeight.Text), double.Parse(txtHeight.Text), double.Parse(txtCoverageAmount.Text));
            lblSub.Text += "$" + dblCoverageAmount;
            //now lets get the tax
            double dblTax = calculateSalesTax(dblCoverageAmount);
            lblTax.Text += "$" + dblTax;
            //and do total cost (subtotal + tax)
            double dblTotal = dblCoverageAmount + dblTax;
            lblTotal.Text += "$" + dblTotal;
        }
    }
}