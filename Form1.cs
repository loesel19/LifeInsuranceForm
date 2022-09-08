using System.Text.RegularExpressions;

namespace LifeInsuranceForm
{
    /**
     * Project Name : LifeInsuranceForm
     * Project Purpose : The purpose of this project is to provide a windows forms application for the Charge Em Life
     *                   Insurance company. This is an assignment for a class and the company (as far as I know) does
     *                   not exist.
     * Project Author : Andrew A. Loesel
     * Organization : This is for Saginaw Valley State University CS 421 taught by Scott James.
     *                   */
    public partial class Form1 : Form
    {
        /**
         * Class Name : Form1
         * Class Purpose : This class extends Form. This form is to be used by a Charge Em Life Insurance agent when they are 
         *                 meeting with a potential client. The agent will input certain information about a client : age, height,
         *                 weight, name, and total insurance policy coverage. The form will then validate data and run the numbers
         *                 through Charge Em's Risk Factor assessment. Lastly the total price of the policy will be shown to the agent.
         *                 The agent will be able to apply a discount if they choose as well. Beyond this the form is able to be cleared for
         *                 when the next client stops in.
         *                 This is the only file in the project so far.
         *                */
        private bool blnAllGood = true; //this field is a flag that will be used at certain points in program executation to help maintain the flow of the program.
        const double dblTaxPercent = 0.06; //the sales tax of whatever state this is program is being used in. 
        public Form1()
        {
            /**
             * Name : Form1
             * Params : None
             * Returns : None
             * Purpose : This is a Visual Studio generated default constructor for the Form1 class. This default
             *           constructor just calls an intialize method on the object to set up our form.
             *           */
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
            lblRisk.Text = "Risk Factor : "; //reset label for risk factor text
            lblCostPerK.Text = "Cost per $1000 : "; //reset label for cost per 1000 dollar
            lblSub.Text = "Sub Total : "; //reset subtotal label text
            lblDiscount.Text = "Discount : "; //reset discount label text
            lblTax.Text = "Tax (" + dblTaxPercent + ") : "; //reset tax label text, using the tax percent constant
            lblTotal.Text = "Total : "; //reset total label text
        }

        private void resetMiscControls()
        {
            /**
             * Name : resetMiscControl
             * Params : None.
             * Returns : None.
             * Purpose : The purpose of this method is to be an area to handle reseting any controls that are not
             *           textboxes or labels to whatever state we want them to be in when the form first loads.
             *           - Clear lstMessage (what acts as our message queue to the user)
             *           - disable and clear txtAmount (in the discount control group)
             *           - unselect all radio buttons in the discount control group
             *           */
            lstMessage.Items.Clear(); //clear our listbox that is used to give messages to the user. 
            //lets deal with the radio group as well.
            //clear txtAmount and disable it
            txtAmount.Clear();
            txtAmount.Enabled = false;
            //unselect all radio buttons
            rdoFlatRate.Checked = false;
            rdoPercentage.Checked = false;
            rdoNone.Checked = false;
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

        private double calculateRiskFactor(double dblAge, double dblWeight, double dblHeight)
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
            dblRadicand = (dblHeight * dblHeight) + (dblAge * dblWeight);
            /* with realistic numbers this equation will never spit out a value <= 0, but it only takes a few lines of
               code to check for this case, so lets make sure we are only taking the sqrt of positive numbers. */
            if(dblRadicand < 0)
            {
                /*this situation is a bit hairy. Something happened that should not have, but we can't just return a bogus value since in theory our equation
                 * can spit out any value. Let us first make the user aware that something isn't quite right. Let's also create a 'all good flag' and set it to
                 * false in this conditional block since everything is in fact not all good. Then we can control our program flow from outside of this method. */
                //this should never be hit since we have a squared value under our radical, and negative inputs aren't allowed, but to be safe we should cover this.
                MessageBox.Show("Check client information.", "Error");
                lstMessage.Items.Add("height^2 + (age * weight) is < 0. Somehow");
                lstMessage.Items.Add("Results may be incorrect. Please check client information and try again.");
                blnAllGood = false;
                //just return 0 here
                return 0;
            }
            dblNumerator = dblAge + Math.Sqrt(dblRadicand);
            dblDenominator = dblWeight - (4.01 * dblAge);
            if(dblDenominator == 0)
            {
                /* we can not divide by 0, so much like what we did in the radicand conditional block we should inform the user, set the flag and return 0
                 * */
                MessageBox.Show("Divide by zero, please check client information.", "Error");
                lstMessage.Items.Add("Divide by zero, please check client information.");
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

        private double calculateCoverageAmount(double dblAge, double dblWeight, double dblHeight, double dblCoverageAmount)
        {
            /**
             * Name: calculateCoverageAmount
             * Params : dblAge - the age of the client.
             *          dblCoverageAmount - the amount that the clientwould like his/her/their? policy to cover
             *          dblHeight - the height of the client in inches.
             *          dblWeight - the weight of the client in inches.
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
            double dblRiskFactor = calculateRiskFactor(dblAge, dblWeight, dblHeight); //the risk factor calculated with the clients information
            //caclulateRiskFactor sets a boolean value to false if anything anomalous happened during calculation 
            //lets make the user aware that something wasn't right
            if (!blnAllGood)
            {
                MessageBox.Show("Something went wrong in calculation, check listbox (lower right corner) for more details.", "Warning");
                //***being in this conditional is very rare since the numbers have to be just wrong enough to get us here, but still better safe than sorry.
            }
            //show the original risk factor to the user
            lblRisk.Text += " " + Math.Round(dblRiskFactor, 2);
            //show user whether client is a safe or unsafe insuree
            if(dblRiskFactor > 0)
            {
                lblRisk.Text += "   Safe";
            }
            if(dblRiskFactor <= 0)
            {
                lblRisk.Text += "   Unsafe";
            }
            double dblAnnualCost = 0; //the annual cost we will calculate with the coverage amount specified
            double dblCostRatio = 0; //the cost per dollar of coverage
            //now there are four different conditionals that determine how the annual cost is calculated.
            //risk factor 0.0 to 10.0
            if(dblRiskFactor >= 0 && dblRiskFactor <= 10)
            {
                //our equation is (10.1 - risk factor) * 1/10 * coverage amount
                dblCostRatio = (10.1 - dblRiskFactor) * (1.0 / 10.0);
            }
            //risk factor > 10
            if(dblRiskFactor > 10)
            {
                //our equation is while(risk factor > 10){risk factor =/ 10} then do the same equation as the 0 to 10 range risk factor
                while(dblRiskFactor > 10)
                {
                    dblRiskFactor = dblRiskFactor / 10;
                }
                dblCostRatio = (10.1 - dblRiskFactor) * (1.0/10.0);
            }
            //0 > risk factor >= -10
            if(dblRiskFactor < 0 && dblRiskFactor >= -10)
            {
                //our equation is (10.1 + risk factor) * 1/10 * coverage amount
                dblCostRatio = (10.1 + dblRiskFactor) * (1.0/10.0);
            }
            //risk factor < -10
            if(dblRiskFactor < -10)
            {
                //again we loop until the risk factor is in the range of 0 > risk factor > -10 and then use the equation that we used for that range.
                while(dblRiskFactor < -10)
                {
                    dblRiskFactor = dblRiskFactor / 10;
                }
                dblCostRatio = (10.1 + dblRiskFactor) * (1.0 / 10.0);
            }
            //see if the cost ratio is greater than 1. if this occurrs the client will have to pay more than the policy covers
            if(dblCostRatio > 1)
            {
                //this can occurr quite frequently with pretty standard numbers so let's just put a message in the listbox
                lstMessage.Items.Add("Warning. Policy costs more than coverage amt.");
                lstMessage.Items.Add("Double check client information.");
            }
            lblCostPerK.Text = "Cost per $1000 : $" + Math.Round(dblCostRatio * 1000, 2);
            dblAnnualCost = dblCostRatio * dblCoverageAmount;
            return dblAnnualCost;
        }
        public bool onlyLetters(string strInput)
        {
            /**
             * Name: onlyLetters
             * Params : strInput - could be any string
             * Returns : boolean - true : this string only contains letters. False : there are more than just letters.
             * Purpose : the purpose of this function is to take in a string and check if it contains just letters ->
             *           return true. otherwise return false. This will be used when validating input, specifically
             *           the name input fields. We check the string using regex.
             *           */
            if(Regex.IsMatch(txtFirst.Text, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }
        public bool validateInputs()
        {
            /**
             * Name : validateInputs
             * Params : None.
             * Returns : a boolean where true -> inputs were valid, false -> invalid inputs
             * Purpose : the purpose of this function is to ensure that the user input all required fields, and ensure
             *           that there are no 'fudged inputs' like an age of -22. All invalid inputs will be mentioned
             *           in lstMessage.
             *           */
            bool blnValid = true;
            //check the name fields lengths
            if(txtFirst.Text.Length < 1)
            {
                lstMessage.Items.Add("Please enter first name.");
                blnValid = false;
            }
            if(txtMI.Text.Length != 1)
            {
                lstMessage.Items.Add("Only input middle initial in M.I.");
                blnValid = false;
            }
            if(txtLast.Text.Length < 1)
            {
                lstMessage.Items.Add("Please enter last name.");
                blnValid = false;
            }
            //now check that all name fields only contain letters
            if(!onlyLetters(txtFirst.Text) || !onlyLetters(txtMI.Text) || !onlyLetters(txtLast.Text))
            {
                lstMessage.Items.Add("Name text fields can only contain letters.");
                blnValid = false;
            }
            //now lets do age, height, weight and total coverage amount. Make sure they are only numbers, and only positive.
            double dblParsedVal = 0; //this will be the value of whichever text field we parse if it can parse
            bool blnParse = true; //this will let us know if the text was parseable to a double.
            //now we will tryParse our numeric values 1 by 1.
            blnParse = double.TryParse(txtAge.Text, out dblParsedVal);
            if (!blnParse || dblParsedVal < 0)
            {
                lstMessage.Items.Add("Age must be a positive number.");
                blnValid = false;
            }
            blnParse = double.TryParse(txtHeight.Text, out dblParsedVal);
            if(!blnParse || dblParsedVal < 0)
            {
                lstMessage.Items.Add("Height must be a positive number.");
                blnValid = false;
            }
            blnParse = double.TryParse(txtWeight.Text, out dblParsedVal);
            if(!blnParse || dblParsedVal < 0)
            {
                lstMessage.Items.Add("Weight must be a positive number.");
                blnValid = false;
            }
            blnParse = double.TryParse(txtCoverageAmount.Text, out dblParsedVal);
            if(!blnParse || dblParsedVal < 0)
            {
                lstMessage.Items.Add("Coverage Amount must be a positive number.");
                blnValid = false;
            }
            return blnValid;
        }
        public double getDiscount(double dblAmount)
        {
            /**
             * Name : getDiscount
             * Params : dblAmount - the cost of coverage prior to any discount being applied.
             * Returns : a double representitive of the cost of coverage after a discount is/isn't applied
             * Purpose : The purpose of this function is to apply a discount to the sub total cost of the
             *           insurance policy. There are a few different cases we check for. First we try to parse
             *           the discount amount. Then we check if the textbox is enabled, because if it is that means
             *           rdoFlatRate or rdoPercent is selected. If txtAmount is not enabled there is no discount method
             *           and we just return dblAmount. We then make sure that the length of txtAmount.Text is > 0. if not
             *           we let the user know they had a discount method selected but didnt put antyhing in. we then make sure
             *           that whatever they put in was able to be parsed, and that the value of what they entered was positive.
             *           We can then check if the discount amount is greater than dblAmount and let the user know if so. Lastly we want
             *           to append the discount amount to lblDiscount, subtract it from dblAmount and return dblAmount.
             *           */
            double d = 0.0;
            bool blnResult = double.TryParse(txtAmount.Text, out d);
            if (!txtAmount.Enabled)
            {
                lblDiscount.Text += " None ";
                return dblAmount;
            }
            if(txtAmount.Text.Length < 1)
            {
                MessageBox.Show("Discount was selected, but no value given.");
                lstMessage.Items.Add("Discount was selected, but no value given.");
                lblDiscount.Text += " None ";
                return dblAmount;
            }
            if (!blnResult)
            {
                MessageBox.Show("Could not parse discount amount.");
                lstMessage.Items.Add("Please check discount amount. Parse Error.");
                lblDiscount.Text += " None ";
                return dblAmount;
            }
            if(d < 0)
            {
                MessageBox.Show("Negative discount amount not allowed.");
                lstMessage.Items.Add("Negative discount amount not allowed.");
                lblDiscount.Text += " None ";
                return dblAmount;
            }
            if (rdoFlatRate.Checked)
            {
                //check if the discount amount is greater than the cost.
                if (double.Parse(txtAmount.Text) > dblAmount)
                {
                    MessageBox.Show("Discounting more than 100% of cost.");
                    lstMessage.Items.Add("Warning! More than 100% of cost discounted.");
                }
                //subtract our flat rate from the given subtotal and return that value.
                lblDiscount.Text += "$" + Math.Round(double.Parse(txtAmount.Text), 2) + " -";
                return dblAmount - double.Parse(txtAmount.Text);
            }
            if (rdoPercentage.Checked)
            {
                //check if the discount amount is greater than the cost.
                if(double.Parse(txtAmount.Text) > 100)
                {
                    MessageBox.Show("Discounting more than 100% of cost.");
                    lstMessage.Items.Add("Warning! More than 100% of cost discounted.");
                }
                lblDiscount.Text += "$" + Math.Round((dblAmount * (double.Parse(txtAmount.Text) / 100)), 2) + " -";
                //return our new amount by multiplying the sub total that was given by 1 - %discount
                return dblAmount * (1- (double.Parse(txtAmount.Text)/100));
            }
            //if we hit this point assume no discount and return the passed in value.
            lblDiscount.Text += " None ";
            return dblAmount;
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
                lstMessage.Items.Add("Invalid inputs. Calculation canceled...");
                //return so that no other code in this function gets executed
                return;
            }
            //lets get the annual cost
            double dblCoverageAmount = calculateCoverageAmount(double.Parse(txtAge.Text), double.Parse(txtWeight.Text), double.Parse(txtHeight.Text), double.Parse(txtCoverageAmount.Text));
            lblSub.Text += "$" + Math.Round(dblCoverageAmount, 2);
            //see if there is a discount. If no discount selected the coverage amount will remain unchanged.
            dblCoverageAmount = getDiscount(dblCoverageAmount);
            //now lets get the tax
            double dblTax = calculateSalesTax(dblCoverageAmount);
            lblTax.Text += "$" + Math.Round(dblTax, 2);
            //and do total cost (subtotal + tax)
            double dblTotal = dblCoverageAmount + dblTax;
            lblTotal.Text += "$" +  Math.Round(dblTotal, 2);
        }
        public void checkChanged(Object sender, EventArgs e)
        {
            /**
             * Name : checkChanged
             * Params : sender - the object that fired the event
             *          e - the arguments for the event that was fired
             * Returns : none.
             * Purpose : The purpose of this function is to change our discount grouping control accordingly when one of the
             *           radio buttons in that group fires the checked changed event. First We will cast sender as a radio button
             *           we will then see which radio button was clicked. For Flat rate we want to add a '$' to the label, for 
             *           percentage we want to add a '%' to the label and for none we want to make sure the label just says amount. 
             *           We also make sure to enable txtAmount when we are discounting either a flat rate or percentage, and disable it
             *           if none is selected. If the radiobutton that sent the event is not checked we do nothing. This case occurs
             *           when a radiobutton is already selected and then the user selects a differnt button.
             *           */
            RadioButton radioButton = (RadioButton)sender;
            if (!radioButton.Checked)
            {
                return;
            }
            if (radioButton.Name == "rdoNone")
            {
                lblAmount.Text = "Amount";
                txtAmount.Enabled = false;
                return;            
            }
            if (radioButton.Name == "rdoFlatRate")
            {
                lblAmount.Text = "Amount ($)";
            }
            if(radioButton.Name == "rdoPercentage")
            {
                lblAmount.Text = "Amount (%)";
            }
            txtAmount.Enabled = true;
        }
    }
}