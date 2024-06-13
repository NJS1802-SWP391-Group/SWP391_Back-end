using Business.Services;
using Business.Services.Email;
using Common.Requests;
using Common.Responses;
using Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Services;
using System.Net.Mail;
using System.Text;
using static System.Net.WebRequestMethods;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public EmailController(EmailService emailService, UserService userService, OrderService orderService)
        {
            _emailService = emailService;
            _userService = userService;
            _orderService = orderService;
        }

        [HttpPost("Send-Email-Result")]
        public async Task<IActionResult> SendEmailResult(SendEmailRequest req)
        {
            try
            {
                var rs = await _orderService.GetOrderByIdIncludeCustomer(req.OrderID);

                var ord = rs.Data as GetOrderToSendMail;

                if (ord == null )
                {
                    return StatusCode(400, "Order does not exist");
                }

                var cus = await _userService.GetCustomerById(ord.CustomerId);

                if (cus == null)
                {
                    return StatusCode(400, "Customer does not exist");
                }
                else if (cus.Email == null)
                {
                    return StatusCode(400, "Customer email does not exist");
                }

                var mailData = new MailData()
                {
                    EmailToId = cus.Email,
                    EmailToName = "DiavanWebsite",
                    EmailBody = GenerateEmailBody($"{cus.FirstName} {cus.LastName}", ord),
                    EmailSubject = "YOUR DIAMOND VALUATION RESULT"
                };

                var result = await _emailService.SendEmailAsync(mailData);
                return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateEmailBody(string fullName, GetOrderToSendMail order)
        {
            StringBuilder emailBody = new StringBuilder();
            int i = 1;
            double totalServicePrice = 0;
            emailBody.Append($@"
           <body style=""color: black; display: flex; justify-content: center; align-items: center"">
<div
          style=""
color: black;
            align-items: center;
            border-radius: 25px;
            border: 1px solid black;
            box-shadow: inherit;
          ""
        >
          <div
            style=""
              display: flex;
              justify-content: center;
              align-items: center;
                text-align: center;
            ""
          >
            <div style=""text-align: center; padding: 10px 10px "">
                <img alt="""" src=""https://scontent.xx.fbcdn.net/v/t1.15752-9/441924933_974480357477832_8469075819425755363_n.png?stp=dst-png_p206x206&_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeGZC1zDQLT8WB4LD3WNzYYEjWsTHp6-zjuNaxMenr7OO1J5NG2Kig2e8Zzrlwfv_ysTloLyyYtLmy_zgGqLU0Ee&_nc_ohc=JO852HsoP1gQ7kNvgEE2Hrk&_nc_ad=z-m&_nc_cid=0&_nc_ht=scontent.xx&oh=03_Q7cD1QHy3APhmVQWBciW02SZ5JXt-h_6VWcp5FVM1Eo1iTnQig&oe=669146F6""
                        width=""60px""  height=""60px""/>
            </div>
            <h1 style=""text-align: center;"">Diavan</h1>
          </div>

          <br />
          <div style="" padding: 0 5% "">
            <div style="" margin: 10px 0 "">
              Xin chào {fullName},
              <br />
              Đơn nhận định giá 
              <span style="" font-weight: bold; color: green; "">
                {order.Code}
              </span> 
              của bạn đã được hoàn thành vào ngày 
              <span style="" font-weight: bold; color: green; "">
                {order.CompleteDate}
              </span>
              . Vui lòng đến Diavan để làm các thủ tục nhận lại sản phẩm. Nếu sau 30 ngày mà quý khách vẫn chưa đến làm thủ tục nhận lại, Diavan sẽ tiến hành niêm phong đơn định giá theo quy định của công ty.
            </div>
            <div style="" margin: 10px 0 "">
              <p style="" font-weight: bold "">
                Thông tin đơn nhận định giá
              </p>
              <div
                style=""
                  display: flex;
                  justify-content: space-between;
                  padding: 0 200px;
                ""
              >
                <div>
                  <ul style="" list-style: none "">
                    <li>Mã đơn nhận:</li>
                    <li>Số lượng:</li>
                    <li>Ngày thanh toán:</li>
                    <li>Ngày hoàn thành:</li>
                  </ul>
                </div>
                <div>
                  <ul style="" list-style: none "">
                    <li>
                      <span
                        style=""
                          text-decoration-line: underline;
                          color: green;
                        ""
                      >
                        {order.Code}
                      </span>
                    </li>

                    <li>{order.Quantity}</li>
                    <li
                      style=""
                        text-decoration-line: underline;
                        color: green;
                      ""
                    >
                      {order.Time}
                    </li>                   
                    <li
                      style=""
                        text-decoration-line: underline;
                        color: green;
                      ""
                    >
                      {order.CompleteDate}
                    </li>
                  </ul>
                </div>
              </div>

            ");

            foreach (var orderDetail in order.DetailValuations)
            {
        emailBody.Append($@"
              <div style=""color: black; padding: 0 200px; margin: 10px 0 "">
                <br/>
                <p>{i}. Chi tiết đơn hàng {i}</p>
                <div
                  style="" display: flex; justify-content: space-between ""
                >
                  <div>
                    <ul style="" list-style: none "">
                      <li>Mã đơn:</li>
                      <li>Loại dịch vụ:</li>
                      <li>Kích cỡ:</li>
                      <li>Giá dịch vụ:</li>
                      <li>Giá trị kim cương:</li>
                    </ul>
                  </div>
                  <div style="" margin-right: 15px "">
                    <ul style="" list-style: none "">
                      <li>{orderDetail.Code}</li>
                      <li>{orderDetail.ServiceName}</li>
                      <li>{orderDetail.EstimateLength} (mm)</li>
                      <li>{orderDetail.ServicePrice}$</li>
                      <li>{orderDetail.Price}$</li>
                    </ul>
                  </div>
                </div>
              </div>
");
                i++;
                totalServicePrice += orderDetail.ServicePrice;
            }

    emailBody.Append($@"

              <div
                style=""
color: black;
                  display: flex;
                  justify-content: space-between;
                  padding: 0 200px;
                  margin: 10px 0;
                ""
              >
                <p>Tổng thanh toán: </p>
                <p style="" margin-right: 115px "">{totalServicePrice}$</p>
              </div>
              <div style="" padding: 0 200px; margin: 10px 0 "">
                <p style="" font-weight: bold "">Bước tiếp theo</p>
                <p style="" font-style: italic "">
                  Vui lòng đến Diavan để nhận lại kim cương và giấy
                  chứng chỉ định giá. <br /> Chúc bạn luôn có những trải nghiệm tuyệt vời
                  khi trải nghiệm dịch vụ của Diavan.
                </p>
              </div>
              <div style="" padding: 0 200px; margin: 10px 0 "">
                Trân trọng, <br />
                Đội ngũ Diavan
              </div>
            </div>
          </div>
        </div>
  </body>

    ");

            return emailBody.ToString();
        }
    }
}
