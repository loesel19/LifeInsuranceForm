namespace LifeInsuranceForm
{
    public partial class Form1 : Form
    {
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
        }
    }
}