using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Diagnostics;

namespace WebAPI_using_HttpClient
{
    public partial class FormCashier : Form
    {
        private int storeId;
        private BindingList<int[]> productQuantity;
        // int[]: productId, price, quantity, categoryId
        private string[] colors;
        private static readonly Random randomColors = new Random(); // 隨機抽取色彩用

        public FormCashier()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // 色彩
            colors = new string[]
                {
                    "#9f7e53","#ddc47e","#b9a4b0","#d3e7e5","#f9eee3",
                    "#f98379","#aa0055","#5b4349","#f9e1d4","#cc764f",
                    "#abc43a","#619ad6","#7249d6","#a89f94","#849ca9",
                    "#eef3e5","#9e1316","#009977","#983d53","#a5a9b2",
                    "#b7e1a1","#f9e097","#d2d9cd","#c9e9e7","#f3dfd7",
                    "#e2ebe5","#134682","#ca7b80","#352235","#bcd8e2",
                    "#89cee0","#e9cdd8","#88ff11","#696b6d","#e4d99f",
                    "#dcc7ad","#f6e0a4","#e3d2cf","#ee172b","#595438",
                    "#7db7db","#e4ded8","#f60206","#da8f67","#dcc61f",
                    "#0011aa","#e94f58","#40534e","#a3c1ad","#ead988",

                };

            // 店家基礎設定
            storeId = 1;
            txtStoreInfo.Text = $"StoreId: {storeId}";
            pictureBox1.Image = Image.FromFile("C:\\ASP NET作品集\\WebAPI using HttpClient\\WebAPI using HttpClient\\Images\\store.jpeg");

            // 顯示店家所有商品類別按鈕
            _ = CreateProductCategoryTextButtonAsync(storeId);

            // 下單商品數量列表
            productQuantity = new BindingList<int[]>();
            productQuantity.ListChanged += new ListChangedEventHandler(productQuantity_ListChanged);
            lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged;

            //餐點留言功能
            txtMessage.Text = "請輸入客戶餐點留言";
            btnAddComment.Enabled = false;
            txtMessage.ForeColor = Color.Gray;
            txtMessage.Enter += new EventHandler(txtProductID_Enter);
            txtMessage.Leave += new EventHandler(txtProductID_Leave);

        }

        // 按下特定商品類別按鈕時，顯示該類別的所有商品在資料庫的名稱、單價、庫存
        private void FillProductsTable(DataTable products)
        {
            if(products.Rows.Count == 0)
            {
                return;
            }
            dataGridView1.AutoGenerateColumns = true;
           
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false; // 讓各列左側不顯示空白

            dataGridView1.DataSource = products;

        }

        // 根據目前下單商品數量，更新總金額
        private void UpdateTotalAmount(BindingList<int[]> productList)
        {
            int totalAmount = 0;

            foreach (var product in productList)
            {
                totalAmount += product[1] * product[2];  // Price * Quantity
            }

            lblTotalAmount.Text = $"總金額: {totalAmount:C0}";
        }

        // 當商品數量列表有變動時，更新總金額
        private void productQuantity_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateTotalAmount(productQuantity);
        }

        // 當客人進入商品留言區時，placeholder移除文字且文字改為黑色
        private void txtProductID_Enter(object sender, EventArgs e)
        {
            if(txtMessage.Text == "請輸入客戶餐點留言")
            {
                txtMessage.Text = "";
                txtMessage.ForeColor = Color.Black;
            }
        }

        // 當客人點選商品數量列表中特定商品時，跳出編輯/刪除商品數量的ModalForm
        private async void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItem != null)
            {
                int selectedIndex = lstProducts.SelectedIndex;
                int productId = productQuantity[selectedIndex][0];
                int quantity =  productQuantity[selectedIndex][2];
                Product product = await GetProductAsync(productId);
                ProductModifyModalForm(selectedIndex, product, quantity);

            }
        }



        // 當客人離開商品留言區時，placeholder回歸原本文字且文字改為灰色
        private void txtProductID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                txtMessage.Text = "請輸入客戶餐點留言";
                txtMessage.ForeColor = Color.Gray;
            }
        }

        // 從WebAPI取得店家特定商品類別中所有商品功能
        private async Task<List<Product>> getProductPerProductCategoryAsync(int storeId, int categoryId)
        {
            try
            {
                var url = $"http://localhost:5119/api/Sales/Products/storeId={storeId}/categoryId={categoryId}";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<Product>>(content);
                    DataTable productsToShow = new DataTable();
                    productsToShow.Columns.Add("編號");
                    productsToShow.Columns.Add("名稱");
                    productsToShow.Columns.Add("單價");
                    productsToShow.Columns.Add("庫存");

                    foreach (var product in products)
                    {
                        productsToShow.Rows.Add(product.ProductId, product.ProductName, product.ProductUnitPrice.ToString("N0"), product.ProductUnitsInStock);
                    };

                    FillProductsTable(productsToShow);
                    return products;
                }
                else
                {
                    MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                    return new List<Product>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return new List<Product>();
            }
        }

        // 從WebAPI取得店家指定商品類別的功能
        public async Task<ProductCategory> GetProductCategoryAsync(int categoryId)
        {
            try
            {
                string url = $"http://localhost:5119/api/Sales/ProductCategory/{categoryId}";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) 
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var category = JsonConvert.DeserializeObject<ProductCategory>(content);
                    return category;
                }
                else
                {
                    MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        } 

        // 從WebAPI取得店家指定商品的功能
        public async Task<Product> GetProductAsync(int productId)
        {
            try
            {
                string url = $"http://localhost:5119/api/Sales/{productId}";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Product>(content);
                    return product;
                    
                }
                else
                {
                    MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }

        }

        // 點選特定商品按鈕時，讓客戶選購商品數量的ModalForm
        private void ProductDetailModalForm(Product product)
        {
            Form myForm = new Form
            { 
                Text = "購買選項",
                FormBorderStyle = FormBorderStyle.FixedDialog, //窗體為對話框模式
                StartPosition = FormStartPosition.CenterParent, //居中顯示
                Size = new System.Drawing.Size(500,300), //窗體大小
                MaximizeBox = false,
                MinimizeBox = false,

                Font = new System.Drawing.Font("微軟正黑體", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136))),
            };

            Label label = new Label 
            {
                Text = $"您要購買 {product.ProductName}，請選擇數量:",
                Location = new System.Drawing.Point(20, 20), //相對於父容器的位置
                AutoSize = true, //自動調整大小
                
            };
            myForm.Controls.Add(label);

            NumericUpDown numericUpDown = new NumericUpDown
            {
                Location = new System.Drawing.Point(200, 100),
                Maximum = 100,
                Minimum = 1,
                Value = 1, //預設值是1
                Width = 100, //寬度
            };

            myForm.Controls.Add(numericUpDown);

            Button ensureButton = new Button
            {
                Text = "確定",
                Location = new System.Drawing.Point(150, 200),
                Size = new System.Drawing.Size(100, 50),
                DialogResult = DialogResult.OK,
            };
            myForm.Controls.Add(ensureButton);
            ensureButton.Click += (sender, e) =>
            {
                productQuantity.Add(new int[] { product.ProductId, (int)product.ProductUnitPrice, (Int32)numericUpDown.Value, product.CategoryId});
                lstProducts.Items.Add($"{product.ProductId}, {product.ProductName} : {product.ProductUnitPrice.ToString("C0")} x {(Int32)numericUpDown.Value}");
            };       

            Button cancelButton = new Button
            {
                Text = "取消",
                Location = new System.Drawing.Point(250, 200),
                Size = new System.Drawing.Size(100, 50),
                DialogResult = DialogResult.Cancel,
            };
           myForm.Controls.Add(cancelButton);
            cancelButton.Click += (sender, e) =>
            {
                myForm.Close();
            };

            myForm.ShowDialog();

        }

        // 當客戶點選商品數量列表中的指定商品，跳出編輯或刪除商品數量的ModalForm
        private void ProductModifyModalForm(int selectedIndex, Product product, int quantity)
        {
            Form myForm = new Form
            {
                Text = "購買選項",
                FormBorderStyle = FormBorderStyle.FixedDialog, //窗體為對話框模式
                StartPosition = FormStartPosition.CenterParent, //居中顯示
                Size = new System.Drawing.Size(500, 300), //窗體大小
                MaximizeBox = false,
                MinimizeBox = false,

                Font = new System.Drawing.Font("微軟正黑體", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136))),
            };

            Label label = new Label
            {
                Text = $"請修改商品{product.ProductName} 購買數量:",
                Location = new System.Drawing.Point(20, 20), //相對於父容器的位置
                AutoSize = true, //自動調整大小

            };
            myForm.Controls.Add(label);

            NumericUpDown numericUpDown = new NumericUpDown
            {
                Location = new System.Drawing.Point(200, 100),
                Maximum = 100,
                Minimum = 1,
                Value = quantity,
                Width = 100, //寬度
            };

            myForm.Controls.Add(numericUpDown);

            Button ensureButton = new Button
            {
                Text = "修改",
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(100, 50),
                DialogResult = DialogResult.OK,
            };
            
            ensureButton.Click += (sender, e) =>
            {
                // 修改ProductQuantity列表內容
                productQuantity[selectedIndex][2] = (int)numericUpDown.Value;
                lstProducts.SelectedIndexChanged -= lstProducts_SelectedIndexChanged; //避免手動修正seleccted item後，再次觸發事件
                lstProducts.Items[selectedIndex] = $"{product.ProductId}, {product.ProductName} : {product.ProductUnitPrice.ToString("C0")} x {(Int32)numericUpDown.Value}";
                lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged; //重新設定事件
                UpdateTotalAmount(productQuantity);

                myForm.Close();
            };
            myForm.Controls.Add(ensureButton);

            Button deleteButton = new Button
            {
                Text = "刪除",
                Location = new System.Drawing.Point(150, 200),
                Size = new System.Drawing.Size(100, 50),
                DialogResult = DialogResult.OK,
            };
            deleteButton.Click += (sender, e) =>
            {
                productQuantity.RemoveAt(selectedIndex);
                lstProducts.Items.RemoveAt(selectedIndex);
                myForm.Close();

            };
            myForm.Controls.Add(deleteButton);

            Button cancelButton = new Button
            {
                Text = "取消",
                Location = new System.Drawing.Point(250, 200),
                Size = new System.Drawing.Size(100, 50),
                DialogResult = DialogResult.Cancel,
            };
            cancelButton.Click += (sender, e) =>
            {
                myForm.Close();
            };
            myForm.Controls.Add(cancelButton);

            myForm.ShowDialog();
            // Determine if the form is modal.
            //if (myForm.Modal == false)
            //{
            //    // Change borderstyle and make it not a top level window.
            //    myForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //    myForm.TopLevel = false;
            //}
        }

        private bool CheckProductAlreadySelected(int productId, out int selectedIndex, out int selectedQuantity)
        {
            int idx = -1;
            foreach (int[] item in productQuantity)
            {
                idx++;
                if( productId == item[0])
                {
                    selectedIndex = idx;
                    selectedQuantity = item[2];
                    return true;
                }
            }

            selectedIndex = -1;
            selectedQuantity = 0;
            return false;
        }

        // 點擊指定商品，先去API撈商品資訊，再跳出購買選項ProductDetailModalForm
        // 如果商品已被選擇(顯示到右側bindingList和lstProducts，則跳出編輯選項ProductModifyModalForm)
        private async void buttonProduct_Click(int productId)
        {
            Product product = await GetProductAsync(productId);
            if (CheckProductAlreadySelected(productId, out int a, out int b))
            {
                ProductModifyModalForm(a, product, b);
            }
            else
            {
                ProductDetailModalForm(product);
            }
        }
        
        // 在表單載入時，先從WebAPI撈取店家所有商品類別，再建立所有類別的按鈕，點擊按鈕後，會呼叫GenerateProductBtnsAsync方法
        private async Task CreateProductCategoryTextButtonAsync(int storeId)
        {
            flpCategories.Controls.Clear();
            try
            {
                string url = $"http://localhost:5119/api/Sales/ProductCategories/storeId={storeId}";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var productCategories = JsonConvert.DeserializeObject<List<string>>(content);

                    foreach (var productCategory in productCategories)
                    {
                        Button button = new Button();
                        button.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        button.Margin = new System.Windows.Forms.Padding(2);
                        button.Size = new System.Drawing.Size(120, 40);

                        button.Text = productCategory.Split(':')[1];
                        int categoryId = int.Parse(productCategory.Split(':')[0]);
                        button.Click += async (sender, e) =>
                        {
                            await GenerateProductBtnsAsync(storeId, categoryId);
                        };

                        flpCategories.Controls.Add(button);

                    }
                }
                else
                {
                    MessageBox.Show("WebAPIError: " + response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // 建立指定的商品按鈕，在按下特定商品類別建立多個商品按鈕時，會呼叫此方法
        private async Task CreateProductTextButtonAsync(int productId, string productName)
        {
            Button button = new Button();
            button.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            button.Margin = new System.Windows.Forms.Padding(2);
            button.Size = new System.Drawing.Size(100, 100);
            button.BackColor = await SetRandomButtonColorAsync();


            button.Text = productName;
            button.Click += (sender, e) => { buttonProduct_Click(productId); };
            flpProducts.Controls.Add(button);
        }

        // 從RGB的colors字串隨機抽取顏色，設定按鈕的背景色
        private async Task<Color> SetRandomButtonColorAsync()
        {
            int index = randomColors.Next(colors.Length); // Get a random index
            string colorHex = colors[index]; // Get the color at the random index
            Console.WriteLine(colors[index]);

            // Convert the hex color string to a Color object
            Color color = ColorTranslator.FromHtml(colorHex);
            return color;
            
        }

        // 點擊商品類別按鈕後，先清空原本在flowLayoutPanel上的商品按鈕，再從WebAPI撈取該類別的所有商品，再生成新的商品按鈕
        private async Task GenerateProductBtnsAsync(int storeId, int productCategoryId)
        {
            try
            {
                List<Product> products = await getProductPerProductCategoryAsync(storeId, productCategoryId);
                flpProducts.Controls.Clear();

                if (products.Count != 0)
                {
                    foreach (var product in products)
                    {
                        await CreateProductTextButtonAsync(product.ProductId, product.ProductName);
                    }
                }
                else
                {
                    MessageBox.Show("Add products to the database first.");
                }

            }
            catch
            {
                MessageBox.Show("WebAPIError: Please check the connection.");
            }
        }

     
        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text) )
            {
                btnAddComment.Enabled = true;
            }
            else
            {
                btnAddComment.Enabled = false;
            }
            
            
        }

        private void btnMakeOrders_Click(object sender, EventArgs e)
        {
            FormMakeOrders _formMakeOrders = new FormMakeOrders(this, txtMessage.Text, productQuantity);      
            _formMakeOrders.Show();

        }

        public void ResetForm()
        {
            this.Controls.Clear ();
            this.InitializeComponent();
            this.Form1_Load(this,EventArgs.Empty);
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text.Length > 0)
            {
                btnAddComment.Enabled=false;
                txtMessage.Enabled=false ;
            }
            else
            {
                MessageBox.Show("訂單訊息不可為空白");
            }
        }
    }
}
