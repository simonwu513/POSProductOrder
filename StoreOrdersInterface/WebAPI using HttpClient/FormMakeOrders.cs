using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace WebAPI_using_HttpClient
{
    public partial class FormMakeOrders : Form
    {
        private int _storeId;

        // 從FormCashier帶來的變數
        private  FormCashier _formCashier;

        // 根據FormCashier新建立的變數
        private List<int[]> _orderList;

        // 本表單新建立的變數
        private static FormMakeOrders _formMakeOrders;
        private List<Customer> customers;
        private int _customerId;
        private bool _storeUniformInvoiceVia;
        private byte _orderInvoiceType;
        private bool _orderPayment;
        private string _einvoiceNumber;
        private int totalAmount;


        public FormMakeOrders(FormCashier instance, string message, BindingList<int[]> ProductQuantity)
        {
            InitializeComponent();
            _storeId = 1;
            _formCashier = instance;
            _formMakeOrders = this;
            _orderList = new List<int[]>();

            totalAmount = 0;
            foreach (var item in ProductQuantity)
            {
                _orderList.Add(new int[] { item[0], item[1], item[2] });
                totalAmount += item[1] * item[2];
            }

            if (message == "請輸入客戶餐點留言")
            {
                txtMessage.Text = "";
            }
            else
            {
                txtMessage.Text = message;
            }
            
            dgvOrderListShow(instance, ProductQuantity);
        }

        private async void FormMakeOrders_Load(object sender, EventArgs e)
        {
            // 客戶選單
            customers = await GetCustomerList(_storeId);
            cboCustomerName.DataSource = customers;
            cboCustomerName.DisplayMember= "CustomerName";
            cboCustomerName.ValueMember = "CustomerId";
            cboCustomerName.SelectedIndexChanged += CboCustomerName_SelectedIndexChanged;


            txtEinvoiceInput.Text = "請填入載具號碼";
            txtEinvoiceInput.ForeColor = Color.Gray;
            txtEinvoiceInput.Enter += new EventHandler(txtEinvoiceInput_Enter);
            txtEinvoiceInput.Leave += new EventHandler(txtEinvoiceInput_Leave);

            // 發票開立方式，當店家不開立發票時，整個區塊被disabled
            Store _store= await GetStoreInfo(_storeId);
            if(_store != null)
            {
                _storeUniformInvoiceVia = _store.StoreUniformInvoiceVia;// 0:不開立, 1:開立
            }
            
            if(_storeUniformInvoiceVia == false)
            {
                radioNoInvoice.Checked = true;
                panelInvoiceChoice.Enabled = false;
                txtEinvoice.Enabled = false;
                txtEinvoiceInput.Enabled = false;
            }
            else
            {
                panelInvoiceChoice.Enabled = true;
                radioNoInvoice.Checked = false;
                radioNoInvoice.Enabled=false;
                txtEinvoice.Enabled = false;
            }

            

            // 總金額計算
            lblTotalAmount.Text = $"總金額: {totalAmount:C0}";

        }
        private void txtEinvoiceInput_Enter(object sender, EventArgs e)
        {
            if (txtEinvoiceInput.Text == "請填入載具號碼")
            {
                txtEinvoiceInput.Text = "";
                txtEinvoiceInput.ForeColor = Color.Black;
                return;
            }
            if (!string.IsNullOrEmpty(txtEinvoiceInput.Text))
            {
                txtEinvoiceInput.ForeColor = Color.Black;
            }
        }

        private void txtEinvoiceInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEinvoiceInput.Text))
            {
                txtEinvoiceInput.Text = "請填入載具號碼";
                txtEinvoiceInput.ForeColor = Color.Gray;
            }
        }



        // 當客戶被選取時，顯示該客戶的電話號碼(若存在)
        //                             載具號碼(若存在)
        private void CboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customers != null || customers.Count > 0)
            {
                int _customerId = (int)cboCustomerName.SelectedValue;
                string customerPhoneNumber = customers.SingleOrDefault(x => x.CustomerId == _customerId).CustomerCellPhone;
                string customerEinvoiceNumber = customers.SingleOrDefault(x => x.CustomerId == _customerId).CustomerEinvoiceNumber;

                if (customerPhoneNumber != null || String.IsNullOrEmpty(customerPhoneNumber))
                {                  
                    txtCustomerPhoneNumberInput.Text = customerPhoneNumber.Trim();
                }
                else
                {
                    txtCustomerPhoneNumberInput.Text = "";

                }

                if (customerEinvoiceNumber != null)
                {
                    // radioEinvoice.Checked = true;
                    _einvoiceNumber = customerEinvoiceNumber.Trim();
                    txtEinvoiceInput.Text = customerEinvoiceNumber.Trim();
                }

            }
        }

        // 表單提交前檢查
        private void btnEnsureOrders_Click(object sender, EventArgs e)
        {
            bool validated = true;
            string warningMessage = "";

            // cboCustomerName必填
            if (cboCustomerName.SelectedIndex == -1)
            {
                validated = false; 
                warningMessage += "請選擇客戶名稱\n";
            }

            // txtCustomerPhoneNumberInput必須是數字
            if(txtCustomerPhoneNumberInput.Text.Trim() != "")
            {
                if (!txtCustomerPhoneNumberInput.Text.Trim().All(char.IsDigit))
                {
                    validated = false;
                    warningMessage += "客戶電話號碼必須為數字\n";
                }
            }       

            // panelPayment必須有勾選
            if (!radioCash.Checked && !radioLINEPAY.Checked)
            {
                validated = false;
                warningMessage += "請選擇付款方式\n";            
            }

            // panelInvoiceChoice必須有勾選
            if (!radioNoInvoice.Checked && !radioEinvoice.Checked && !radioPaperInvoice.Checked)
            {
                validated = false;
                warningMessage += "請選擇發票開立方式\n";
            }

            // 若開立電子發票，必須輸入載具號碼
            if (radioEinvoice.Checked &&  (!Regex.IsMatch(txtEinvoiceInput.Text, "^[A-Za-z0-9/+*-]+$") || txtEinvoiceInput.Text.Trim() == ""))
            {
                validated = false;
                warningMessage += "必須填寫載具號碼\n";
            }

            if (validated)
            {
                SendOrders();
            }
            else
            {
                MessageBox.Show(warningMessage);
            }


        }

        private async void SendOrders()
        {
            

            if (radioCash.Checked)
            {
                _orderPayment =  false;
            }
            if (radioLINEPAY.Checked)
            {
                _orderPayment = true;
            }

            if (radioEinvoice.Checked)
            {
                _orderInvoiceType = 2;
                _einvoiceNumber = txtEinvoiceInput.Text.Trim();
            }
            else
            {
                _einvoiceNumber = "";
            }
            if (radioPaperInvoice.Checked)
            {
                _orderInvoiceType = 1;
            }
            if (radioNoInvoice.Checked)
            {
                _orderInvoiceType = 0;
            }

            //var data = new
            //{
            //    ProductSales = _orderList,
            //    customerId = _customerId,
            //    storeId = _storeId,
            //    orderPhoneNumber = txtCustomerPhoneNumberInput.Text.Trim(),
            //    orderPayment = _orderPayment,
            //    orderStoreMemo = txtMessage.Text.Trim(),
            //    uniformInvoiceVia = _orderInvoiceType,
            //    einvoiceNumber = _einvoiceNumber,
            //};

            try
            {
                string url = $"http://localhost:5119/api/Sales?customerId={_customerId}&storeId={_storeId}&orderPhoneNumber={txtCustomerPhoneNumberInput.Text.Trim()}&orderPayment={_orderPayment}&orderStoreMemo={txtMessage.Text.Trim()}&uniformInvoiceVia={_orderInvoiceType}&einvoiceNumber={_einvoiceNumber}";
                HttpClient client = new HttpClient();

                var json = JsonConvert.SerializeObject(_orderList);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    OrderAndDetailsResponse orderAndDetailsResponse = JsonConvert.DeserializeObject<OrderAndDetailsResponse>(result);
                    int orderId = orderAndDetailsResponse.OrderView.OrderId;
                    MessageBox.Show($"訂單已送出\n訂單編號為{orderId}");

                    _formCashier.ResetForm();

                    _formMakeOrders.Close();
                    _formMakeOrders.Dispose();

                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"WebAPIError: {errorContent}");
                    //MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        // 客戶名稱選單: 從WebAPI撈取目前客戶名稱
        private async Task<List<Customer>> GetCustomerList(int storeid)
        {
            try
            {
                string url = $"http://localhost:5119/api/Sales/Customers/{storeid}";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                    return customers;
                }

                else
                {
                    MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                    return null;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        
        }

        // 取得店家資訊: 主要拿來取得店家發票方式
        private async Task<Store> GetStoreInfo(int storeId)
        {
            try
            {
                string url = $"http://localhost:5119/api/Sales/Store/{storeId}";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var store = JsonConvert.DeserializeObject<Store>(content);
                    return store;
                }

                else
                {
                    MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                    return null;
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async void dgvOrderListShow(FormCashier instance,BindingList<int[]> orderList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("商品名稱");
            dt.Columns.Add("類別名稱");
            dt.Columns.Add("金額");
            dt.Columns.Add("數量");
            foreach(var item in orderList)
            {
                Product product = await instance.GetProductAsync(item[0]);
                ProductCategory category = await instance.GetProductCategoryAsync(item[3]);
                dt.Rows.Add(product.ProductName, category.CategoryName, item[1].ToString("N0"), item[2]);
            }
            dgvOrderDetails.AutoGenerateColumns = true;

            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AllowUserToDeleteRows = false;
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.RowHeadersVisible = false; // 讓各列左側不顯示空白

            dgvOrderDetails.DataSource = dt;
        }

        private void btnClosing_Click(object sender, FormClosingEventArgs e)
        {
            _formCashier.Show();
        }

        private void btnReturnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void radioEinvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEinvoice.Checked)
            {
                txtEinvoiceInput.Enabled = true;
                txtEinvoice.Enabled = true;
                txtEinvoiceInput.ForeColor = Color.Black;
                if(_einvoiceNumber != null || !String.IsNullOrEmpty(_einvoiceNumber))
                {
                    txtEinvoiceInput.Text = _einvoiceNumber;
                }
            }
            else
            {
                txtEinvoiceInput.Enabled = false;
                txtEinvoice.Enabled = false;
                txtEinvoiceInput.Text = "";
                txtEinvoiceInput.ForeColor = Color.Gray;
            }
        }

    }
}