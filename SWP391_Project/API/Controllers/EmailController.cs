using Business.Services.Email;
using Common.Requests;
using Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Services;
using System.Net.Mail;
using static System.Net.WebRequestMethods;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        private readonly UserService _userService;

        public EmailController(EmailService emailService, UserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        [HttpPost("Send-Email-Result")]
        public async Task<IActionResult> SendEmailResult(SendEmailRequest req)
        {
            try
            {
                var cus = await _userService.GetCustomerByEmail(req.Email);

                if (cus == null )
                {
                    return StatusCode(400, "Customer email does not exist");
                }

                var mailData = new MailData()
                {
                    EmailToId = req.Email,
                    EmailToName = "DiavanWebsite",
                    EmailBody = GenerateEmailBody($"{cus.FirstName} {cus.LastName}", cus.Email),
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

        private string GenerateEmailBody(string fullName, string imgPath)
        {
            return $@"
   <body style=""color: black; display: flex; justify-content: center; align-items: center"">
<div
          style=""
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
              Xin chào VoMongLuan,
              <br />
              Đơn hàng{{"" ""}}
              <span style="" font-weight: bold; color: green; "">
                #240528GYY423E0
              </span>{{"" ""}}
              của bạn đã được giao thành công ngày{{"" ""}}
              <span style="" font-weight: bold; color: green; "">
                31/05/2024
              </span>
              . Vui lòng đăng nhập Diavan để xác nhận bạn đã nhận hàng và hài
              lòng với sản phẩm trong vòng 3 ngày. Sau khi bạn xác nhận, chúng
              tôi sẽ thanh toán cho Người bán vietcomtechnology.jsc. Nếu bạn
              không xác nhận trong khoảng thời gian này, Shopee cũng sẽ thanh
              toán cho Người bán.
            </div>
            <div style="" margin: 10px 0 "">
              <p style="" font-weight: bold "">
                Thông tin đơn hàng
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
                    <li>Mã đơn hàng:</li>
                    <li>Số viên :</li>
                    <li>Ngày đặt hàng:</li>
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
                        #240528GYY423E0
                      </span>
                    </li>

                    <li>2</li>
                    <li
                      style=""
                        text-decoration-line: underline;
                        color: green;
                      ""
                    >
                      28/05/2024 15:28:07
                    </li>
                  </ul>
                </div>
              </div>
              <div style="" padding: 0 200px; margin: 10px 0 "">
                </br>
                <p>1. Viên kim cương 1</p>
                <div
                  style="" display: flex; justify-content: space-between ""
                >
                  <div>
                    <ul style="" list-style: none "">
                      <li>Mã kim cương:</li>
                      <li>Loại dịch vụ:</li>
                      <li>Kích cỡ:</li>
                      <li>Giá dịch vụ:</li>
                      <li>Giá trị kim cương:</li>
                    </ul>
                  </div>
                  <div style="" margin-right: 15px "">
                    <ul style="" list-style: none "">
                      <li>123</li>
                      <li>Standard Valuation</li>
                      <li>10(mm)</li>
                      <li>100$</li>
                      <li>2000$</li>
                    </ul>
                  </div>
                </div>
              </div>
              <div
                style=""
                  display: flex;
                  justify-content: space-between;
                  padding: 0 200px;
                  margin: 10px 0;
                ""
              >
                <p>Tổng thanh toán:</p>
                <p style="" margin-right: 115px "">100$</p>
              </div>
              <div style="" padding: 0 200px; margin: 10px 0 "">
                <p style="" font-weight: bold "">Bước tiếp theo</p>
                <p style="" font-style: italic "">
                  Vui lòng đến Diavan Componay để nhận lại kim cương và giấy
                  thẩm định. <br /> Chúc bạn luôn có những trải nghiệm tuyệt vời
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

    ";
        }
    }
}
