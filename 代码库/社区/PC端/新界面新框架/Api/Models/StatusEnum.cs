using System.ComponentModel;

namespace Api.Models
{
    public enum StatusEnum
    {
        [Description("成功")]
        success = 200,
        [Description("服务器内部错误")]
        error = 500,
        [Description("无内容")]
        empty = 204,
        [Description("错误请求")]
        errorRequest = 400,
        [Description("资源不可用/已经存在")]
        forbidden = 403
    }
}