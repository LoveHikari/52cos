using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.AddressViewModels
{
    public class AddressViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户id必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [Required(ErrorMessage = "省必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "省必须是{2}到{1}个字符")]
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        [Required(ErrorMessage = "市必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "市必须是{2}到{1}个字符")]
        public string City { get; set; }
        /// <summary>
        /// 区/县
        /// </summary>
        [Required(ErrorMessage = "区/县必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "区/县必须是{2}到{1}个字符")]
        public string County { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Required(ErrorMessage = "详细地址必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "详细地址必须是{2}到{1}个字符")]
        public string Address { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        [Required(ErrorMessage = "邮政编码必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "邮政编码必须是{2}到{1}个字符")]
        public string ZipCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "姓名必须是{2}到{1}个字符")]
        public string Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Required(ErrorMessage = "手机号码必填", AllowEmptyStrings = false)]
        public string Phone { get; set; }
    }
}