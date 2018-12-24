using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMachine.Client
{
	public partial class frmMain : Form
	{
        Order _order = new Order(); //PS: I don't like class variables.

		public frmMain()
		{
			InitializeComponent();
		}

		private void btnAddCoffee_Click(object sender, EventArgs e)
		{
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSize.Text))
                {
                    Coffee newCup = new Coffee();

                    if (ValidateSizeText(txtSize.Text))
                    {
                        newCup.Size = newCup.GetSize(txtSize.Text).Value;
                    }

                    if (_order.Coffees.Any())
                    {
                        DialogResult dialogResult = MessageBox.Show("Would you like another coffee to your order? ", "Another Coffee?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    _order.Coffees.Add(newCup);
                    AddToCurrentOrderTextbox($"{newCup.Size.ToString()} coffee started");
                }

                if (!string.IsNullOrWhiteSpace(txtCream.Text))
                {
                    Cream cream = new Cream();

                    if (_order.Coffees.Any() && ValidateCondimentQuantity(txtCream.Text))
                    {
                        cream.Quantity = cream.GetQuantity(txtCream.Text);
                        _order.Coffees.Last().Cream = cream;
                        AddToCurrentOrderTextbox($"{cream.Quantity} creamer(s) added");
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtSugar.Text))
                {
                    Sugar sugar = new Sugar();

                    if (_order.Coffees.Any() && ValidateCondimentQuantity(txtSugar.Text))
                    {
                        sugar.Quantity = sugar.GetQuantity(txtSugar.Text);
                        _order.Coffees.Last().Sugar = sugar;
                        AddToCurrentOrderTextbox($"{sugar.Quantity} sugar(s) added");
                    }
                }

                lblOrderTotal.Text = _order?.Total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Error");
            }

            ClearUI();
        }

        private bool ValidateCondimentQuantity(string text)
        {
            Condiment condiment = new Condiment();

            if (!condiment.IsValidQuantity(text.Trim()))
            {
                throw new Exception($"\"{text}\" is not a valid quantity. Please Enter: 1, 2, or 3");
            }

            return true;
        }

        private bool ValidateSizeText(string text)
        {
            Coffee coffee = new Coffee();

            if (!coffee.IsValidSize(text.Trim()))
            {
                throw new Exception($"\"{text}\" is not a valid size. Please Enter: small, medium, or large");
            }

            return true;
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPayment.Text))
                {
                    AddPaymentToOrder(txtPayment.Text, ref _order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Error");
            }
        }

        private bool ValidatePaymentAmount(string text)
        {
            Payment payment = new Payment();

            if (!payment.IsValidAmount(text))
            {
                throw new Exception($"\"{text}\" is not a valid monetary amount. Please use standard monetary increments (from $0.05 to $20)");
            }

            return true;
        }

        private void btnVend_Click(object sender, EventArgs e)
        {
            if (_order == null || !_order.Coffees.Any())
                return;

            try
            {
                if (_order.SumOfPayments < _order.Total)
                {
                    throw new Exception($"....Umm, give me more money.");
                }

                DialogResult dialogResult = MessageBox.Show("Would you like another?", "Coffee's ready!!!!", MessageBoxButtons.YesNo);

                decimal youChange = _order.Total - _order.SumOfPayments;
                youChange *= -1;

                if (dialogResult == DialogResult.No)
                {
                    if (youChange > 0)
                    {
                        MessageBox.Show($"Don't forget your change!! \n\n ${youChange}", " Dispense Change");
                    }

                    ClearUI(true);
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    ClearUI(true);

                    if (youChange > 0)
                    {
                        AddPaymentToOrder(youChange.ToString(), ref _order);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Error");
                ClearUI();
            }
        }

        private void AddPaymentToOrder(string text, ref Order order)
        {
            if (order == null)
            {
                order = new Order();
            }

            if (ValidatePaymentAmount(text))
            {
                Payment payment = new Payment();

                payment.Amount = payment.GetAmount(text);

                _order.Payments.Add(payment);

                lblCurrentPayment.Text = _order.SumOfPayments.ToString();

                AddToCurrentOrderTextbox($"{payment.Amount.ToString()} dollar payment added.");
            }
        }

        private void ClearUI(bool isNewOrder = false)
        {
            txtCream.Text = string.Empty;
            txtPayment.Text = string.Empty;
            txtSize.Text = string.Empty;
            txtSugar.Text = string.Empty;

            if (isNewOrder)
            {
                txtCurrentOrder.Text = string.Empty;
                lblCurrentPayment.Text = string.Empty;
                lblOrderTotal.Text = string.Empty;

                _order = new Order();
            }
        }

        private void AddToCurrentOrderTextbox(string text)
        {
            if (!string.IsNullOrWhiteSpace(txtCurrentOrder.Text))
            {
                txtCurrentOrder.Text += Environment.NewLine;
            }

            if (!string.IsNullOrWhiteSpace(text.Trim()))
            {
                txtCurrentOrder.Text += text.Trim();
            }
        }
    }
}
