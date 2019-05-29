using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Newtonsoft.Json;
using System.Net;
using TestRestAsync.Common;
using System.Runtime.Serialization;
using TestRestAsync.Enums;

namespace TestRestAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvokeRest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.InvokeRestOperation(this.txtInput.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.InvokeRestDevices(this.txtInput.Text);
        }

        public void InvokeRest()
        {
            //Este es ejemplo para invocar estatus
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=doTest&name=admin&password=123456";
            var respuesta = UtilRest.InvocaServicioRest<EstatusTrx>(url, "data");
            txtResult.Text = respuesta.Codigo.ToString();
        }

        public void InvokeRestOperation(string opId)
        {
            //Este es ejemplo para validar operacion
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=askOperation&name=admin&password=123456&operationId=" + opId;

            var respuesta = UtilRest.InvocaServicioRest<OperationTrx>(url, "operation");
            txtResult.Text = respuesta.Codigo.ToString();

        }

        public void InvokeRestDevices(string opId)
        {
            //Este es ejemplo para validar Devices
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=askOperation&name=admin&password=123456&operationId=" + opId;

            var respuesta = UtilRest.InvocaServicioListRest<DevicesTrx>(url, "devices");
            txtResult.Text = respuesta.Codigo.ToString();
        }


        public void InvokeRestSale(string amount)
        {
            //Este es ejemplo para validar Device
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=startOperation&name=admin&password=123456&type=4&posid=Terminal3&posuser=admin&parameters={" + "\"amount\":" + "\"" + amount + "\"}";

            var respuesta = UtilRest.InvocaServicioRest<int>(url, "data");
            txtResult.Text = respuesta.Data.ToString();
        }

        public void InvokeExecuteSale(string opId)
        {
            //Este es ejemplo para validar Device
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=acknowledgeOperationId&name=admin&password=123456&operationId=" + opId;
            var respuesta = UtilRest.InvocaServicioRest<EstatusTrx>(url, "data");
            txtResult.Text = respuesta.Codigo.ToString();
        }

        public void InvokeCancelSale(string opId)
        {
            //Este es ejemplo para validar Device
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=finishOperation&name=admin&password=123456&operationId=" + opId + @"&type=2";
            var respuesta = UtilRest.InvocaServicioRest<EstatusTrx>(url, "data");
            txtResult.Text = respuesta.Codigo.ToString();

        }

        public void InvokeFinishSale(string opId)
        {
            //Este es ejemplo para validar Device
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=finishOperation&name=admin&password=123456&operationId=" + opId + @"&type=1";
            var respuesta = UtilRest.InvocaServicioRest<EstatusTrx>(url, "data");
            txtResult.Text = respuesta.Codigo.ToString();
        }

        public void InvokePayment(string amount)
        {
            //Este es ejemplo para validar Device
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=startOperation&name=admin&password=123456&type=3&posid=Terminal3&parameters={" + "\"amount\":" + "\"" + amount + "\"}";
            var respuesta = UtilRest.InvocaServicioRest<int>(url, "data");
            txtResult.Text = respuesta.Data.ToString();
        }

        public void InvokeCheckLevels(string sCurrency)
        {
            //Este es ejemplo para validar Device
            var url = "https://172.16.20.245/Cashdro3WS/index.php?operation=getPiecesCurrency&currencyId=" + sCurrency + "&includeImages=0&includeLevels=1&name=admin&password=123456";
            var respuesta = UtilRest.InvocaServicioListRest<LevelsTrx>(url, "data");
            txtResult.Text = respuesta.Codigo.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.InvokeRestSale(this.txtInput.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.InvokeExecuteSale(this.txtInput.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.InvokeCancelSale(this.txtInput.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.InvokeFinishSale(this.txtInput.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.InvokePayment(this.txtInput.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InvokeCheckLevels("CLP");
        }
    }

    [DataContract]
    public class EstatusTrx
    {
        [DataMember]
        public int code { get; set; }
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string data { get; set; }
    }

    [DataContract]
    public class LevelsTrx
    {
        [DataMember(Name = "CurrencyId", EmitDefaultValue = false)]
        public string CurrencyId { get; set; }
        [DataMember(Name = "Value", EmitDefaultValue = false)]
        public string Value { get; set; }
        [DataMember(Name = "Type", EmitDefaultValue = false)]
        public string Type { get; set; }
        [DataMember(Name = "Destination", EmitDefaultValue = false)]
        public string Destination { get; set; }
        [DataMember(Name = "MinLevel", EmitDefaultValue = false)]
        public string MinLevel { get; set; }
        [DataMember(Name = "MaxLevel", EmitDefaultValue = false)]
        public string MaxLevel { get; set; }
        [DataMember(Name = "MaxLevelTemp", EmitDefaultValue = false)]
        public string MaxLevelTemp { get; set; }
        [DataMember(Name = "DepositLevel", EmitDefaultValue = false)]
        public string DepositLevel { get; set; }
        [DataMember(Name = "DepositLevelTemp", EmitDefaultValue = false)]
        public string DepositLevelTemp { get; set; }
        [DataMember(Name = "MaxPiecesExchange", EmitDefaultValue = false)]
        public string MaxPiecesExchange { get; set; }
        [DataMember(Name = "MaxPiecesChange", EmitDefaultValue = false)]
        public string MaxPiecesChange { get; set; }
        [DataMember(Name = "MaxPiecesCancel", EmitDefaultValue = false)]
        public string MaxPiecesCancel { get; set; }
        [DataMember(Name = "IsChargeable", EmitDefaultValue = false)]
        public string IsChargeable { get; set; }
        [DataMember(Name = "State", EmitDefaultValue = false)]
        public string State { get; set; }
        [DataMember(Name = "Image", EmitDefaultValue = false)]
        public string Image { get; set; }
        [DataMember(Name = "LevelRecycler", EmitDefaultValue = false)]
        public string LevelRecycler { get; set; }
        [DataMember(Name = "LevelCasete", EmitDefaultValue = false)]
        public string LevelCasete { get; set; }
    }

    [DataContract(Name = "operation")]
    public class OperationTrx
    {
        [DataMember(Name = "operationid", EmitDefaultValue = false)]
        public string operationId { get; set; }
        [DataMember(Name = "batchid", EmitDefaultValue = false)]
        public string batchid { get; set; }
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string state { get; set; }
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public string total { get; set; }
        [DataMember(Name = "totalin", EmitDefaultValue = false)]
        public string totalIn { get; set; }
        [DataMember(Name = "totalout", EmitDefaultValue = false)]
        public string totalOut { get; set; }
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string type { get; set; }
        [DataMember(Name = "datefinish", EmitDefaultValue = false)]
        public string dateFinish { get; set; }
        [DataMember(Name = "hourfinish", EmitDefaultValue = false)]
        public string hourFinish { get; set; }
        [DataMember(Name = "amountchangenotavailable", EmitDefaultValue = false)]
        public string amountChangeNotAvailable { get; set; }
        [DataMember(Name = "totalrounded", EmitDefaultValue = false)]
        public string totalRounded { get; set; }
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public string error { get; set; }
        [DataMember(Name = "posuser", EmitDefaultValue = false)]
        public string posUser { get; set; }
        [DataMember(Name = "posid", EmitDefaultValue = false)]
        public string posId { get; set; }
        [DataMember(Name = "progressPartial", EmitDefaultValue = false)]
        public string progressPartial { get; set; }
        [DataMember(Name = "progressTotal", EmitDefaultValue = false)]
        public string progressTotal { get; set; }
        [DataMember(Name = "aliasid", EmitDefaultValue = false)]
        public string aliasId { get; set; }
        [DataMember(Name = "canceled", EmitDefaultValue = false)]
        public string canceled { get; set; }
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string userId { get; set; }
        [DataMember(Name = "userName", EmitDefaultValue = false)]
        public string userName { get; set; }
        [DataMember(Name = "roundValue", EmitDefaultValue = false)]
        public string roundValue { get; set; }
        [DataMember(Name = "finalStatus", EmitDefaultValue = false)]
        public string finalStatus { get; set; }
    }

    [DataContract(Name = "devices")]
    public class DevicesTrx
    {
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string type { get; set; }
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string state { get; set; }
        [DataMember(Name = "totalin", EmitDefaultValue = false)]
        public string totalIn { get; set; }
        [DataMember(Name = "totalout", EmitDefaultValue = false)]
        public string totalOut { get; set; }
    }
}
